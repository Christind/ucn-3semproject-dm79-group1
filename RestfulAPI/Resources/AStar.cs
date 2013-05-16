using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Logging;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services;
using Utils.Helpers;

namespace RestfulAPI.Resources
{
    public class AStar
    {
        //Repositories
        private readonly EdgeRepository _edgeRepository;
        private readonly StationRepository _stationRepository;

        //Collections
        private readonly List<Station> _closedSet;
        private readonly MinHeap<Station> _openSet;
        private readonly Dictionary<Station, Station> _cameFrom;
        private readonly Dictionary<Station, double> _gScores;
        private readonly Dictionary<Station, double> _fScores; 
        private readonly List<Station> _path;

        public AStar()
        {
            _edgeRepository = new EdgeRepository();
            _stationRepository = new StationRepository();

            _closedSet = new List<Station>();
            _openSet = new MinHeap<Station>(1064);
            _cameFrom = new Dictionary<Station, Station>();
            _gScores = new Dictionary<Station, double>();
            _fScores = new Dictionary<Station, double>();
            _path = new List<Station>();
        }

        public List<Station> CalculateRoute(string sLat, string sLng, string eLat, string eLng)
        {
            var stationService = new StationService();
            Station firstStation = stationService.LocateNearestStation(sLat, sLng);
            Station endStation = stationService.LocateNearestStation(eLat, eLng);
            firstStation.Edges = _edgeRepository.GetEdgesByStartStation(firstStation).ToList();

            double fScore = Heuristic(firstStation, endStation);
            _gScores[firstStation] = 0;
            _openSet.Insert(firstStation, fScore);
            
            while (_openSet.Count > 0)
            {
                var current = _openSet.Minimum;
                if (current.Element.ID == endStation.ID)
                {
                    ReconstructPath(current.Element);
                    return _path;
                }

                _openSet.RemoveMinimum();
                _closedSet.Add(current.Element);
                foreach (var edge in current.Element.Edges.Where(x => x.Distance < 250000)) //Replace with car range
                {
                    double tentativeGScore = _gScores[current.Element] + Convert.ToDouble(edge.Distance);
                    if(_closedSet.Contains(edge.EndStation))
                        if(tentativeGScore >= Convert.ToDouble(edge.Distance))
                            continue;

                    bool isStationInOpenset = _openSet.Contains(edge.EndStation);
                    if(!isStationInOpenset || tentativeGScore < Convert.ToDouble(edge.Distance))
                    {
                        //_cameFrom[edge.EndStation] = current.Element;
                        _gScores[edge.EndStation] = tentativeGScore;
                        _fScores[edge.EndStation] = _gScores[edge.EndStation] + Heuristic(edge.EndStation, endStation);
                        if (!isStationInOpenset)
                            _openSet.Insert(edge.EndStation, _fScores[edge.EndStation]);
                    }
                }

                _cameFrom[_openSet.Minimum.Element] = current.Element;
            }

            return null;
        }

        private void ReconstructPath(Station current)
        {
            Station temp;
            if (_cameFrom.TryGetValue(current, out temp))
            {
                ReconstructPath(temp);
                _path.Add(current);
            }
            else
                _path.Add(current);
        }

        private double Heuristic(Station start, Station end)
        {
            var edgeRepo = new EdgeRepository();
            var endEdge = edgeRepo.GetEdgeByStartEndStation(start, end);
            //var endEdge = start.Edges.FirstOrDefault(x => x.EndStationId.Equals(end.ID));
            if (endEdge != null)
            {
                var distance = endEdge.Distance;
                return Convert.ToDouble(distance);
            }

            return -1;
        }
    }
}
