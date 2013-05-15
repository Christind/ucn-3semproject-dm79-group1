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
            firstStation.Edges = _edgeRepository.GetEdgesByStation(firstStation).ToList();

            double gScore = 0;
            double fScore = gScore + Heuristic(firstStation, endStation);
            _openSet.Insert(firstStation, fScore);
            
            while (_openSet.Count > 0)
            {
                var current = _openSet.Minimum;
                if (current.Element == endStation)
                {
                    ReconstructPath(current.Element);
                    return _path;
                }

                _openSet.RemoveMinimum();
                _closedSet.Add(current.Element);
                foreach (var edge in current.Element.Edges)
                {
                    double tentativeGScore = gScore + Convert.ToDouble(edge.Distance);
                    if(_closedSet.Contains(edge.EndStation))
                        if(tentativeGScore >= Convert.ToDouble(edge.Distance))
                            continue;

                    bool isStationInOpenset = _openSet.Contains(edge.EndStation);
                    if(!isStationInOpenset || tentativeGScore < Convert.ToDouble(edge.Distance))
                    {
                        _cameFrom[edge.EndStation] = current.Element;
                        _gScores[edge.EndStation] = tentativeGScore;
                        _fScores[edge.EndStation] = gScore + Heuristic(current.Element, edge.EndStation);
                        if (!isStationInOpenset)
                            _openSet.Insert(edge.EndStation, Heuristic(edge.EndStation, endStation));
                    }
                }
            }

            return null;
        }

        private void ReconstructPath(Station current)
        {
            Station temp;
            if (_cameFrom.TryGetValue(current, out temp))
            {
                ReconstructPath(temp);
                _path.Add(temp);
            }
            else
                _path.Add(current);
        }

        private double Heuristic(Station start, Station end)
        {
            var endEdge = start.Edges.FirstOrDefault(x => x.EndStationId.Equals(end.ID));
            if (endEdge != null)
            {
                var distance = endEdge.Distance;
                return Convert.ToDouble(distance);
            }

            return -1;
        }
    }
}
