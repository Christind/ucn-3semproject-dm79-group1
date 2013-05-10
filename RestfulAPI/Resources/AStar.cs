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
            Station firstStation = new StationService().LocateNearestStation(sLat, sLng);
            Station endStation = new StationService().LocateNearestStation(eLat, eLng);
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
                    if(_closedSet.Contains(edge.EndStationObj))
                        if(tentativeGScore >= Convert.ToDouble(edge.Distance))
                            continue;

                    if(!_openSet.Contains(edge.EndStationObj) || tentativeGScore < Convert.ToDouble(edge.Distance))
                    {
                        _cameFrom[edge.EndStationObj] = current.Element;
                        _gScores[edge.EndStationObj] = tentativeGScore;
                        _fScores[edge.EndStationObj] = gScore + Heuristic(current.Element, edge.EndStationObj);
                        if(!_openSet.Contains(edge.EndStationObj))
                            _openSet.Insert(edge.EndStationObj, Heuristic(edge.EndStationObj, endStation));
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
            double distance = 0;
            Station current = start;
            while (current.ID != end.ID)
            {
                Edge edge = current.Edges.OrderBy(x => x.Distance).FirstOrDefault();
                distance += Convert.ToDouble(edge.Distance);
                current = _stationRepository.GetStationById(edge.EndStation);
            }

            return distance;
        }
    }
}
