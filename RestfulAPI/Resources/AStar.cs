using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly StationService _stationService;

        //Collections
        private readonly List<Station> _closedSet;
        private readonly MinHeap<Station> _openSet;
        private readonly Dictionary<Station, Station> _cameFrom;
        private readonly Dictionary<Station, decimal> _gScores;
        private readonly Dictionary<Station, decimal> _fScores;
        private readonly List<Station> _path;

        public AStar()
        {
            _edgeRepository = new EdgeRepository();
            _stationService = new StationService();

            _closedSet = new List<Station>();
            _openSet = new MinHeap<Station>(1064);
            _cameFrom = new Dictionary<Station, Station>();
            _gScores = new Dictionary<Station, decimal>();
            _fScores = new Dictionary<Station, decimal>();
            _path = new List<Station>();
        }

        //Fjern ikke aktive og stationer uden batterier
        public List<Station> CalculateRoute(string sLat, string sLng, string eLat, string eLng, decimal maxRange)
        {
            if (maxRange < 1)
                return null;

            maxRange = maxRange * 1000;
            Station firstStation = _stationService.LocateNearestStation(sLat, sLng);
            Station endStation = _stationService.LocateNearestStation(eLat, eLng);
            firstStation.Edges = _edgeRepository.GetEdgesByStartStation(firstStation).ToList();

            decimal fScore = Heuristic(firstStation, endStation);
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
                var edges = current.Element.Edges.Where(x => x.Distance < maxRange);
                bool isEmpty = true;
                foreach (var edge in edges)
                {
                    decimal distance = edge.Distance;
                    decimal tentativeGScore = _gScores[current.Element] + distance;
                    bool isStationInClosedSet = _closedSet.Contains(edge.EndStation);
                    if (isStationInClosedSet)
                        if (tentativeGScore >= distance)
                            continue;

                    bool isStationInOpenset = _openSet.Contains(edge.EndStation);
                    if (!isStationInOpenset || tentativeGScore < distance)
                    {
                        _gScores[edge.EndStation] = tentativeGScore;
                        _fScores[edge.EndStation] = _gScores[edge.EndStation] + Heuristic(edge.EndStation, endStation);

                        if (!isStationInOpenset && !isStationInClosedSet)
                            InsertVertex(edge.EndStation, _fScores[edge.EndStation]);
                    }

                    isEmpty = false;
                }

                if (_openSet.Count > 0 && !isEmpty)
                    _cameFrom[_openSet.Minimum.Element] = current.Element;
            }

            return null;
        }

        private void ReconstructPath(Station current)
        {
            Station temp;
            if (_cameFrom.TryGetValue(current, out temp))
            {
                Edge e = _edgeRepository.GetEdgeByStartEndStation(temp, current);
                current.Edges = new List<Edge> { e };
                ReconstructPath(temp);
                _path.Add(current);
            }
            else
            {
                current.Edges = new List<Edge>();
                _path.Add(current);
            }
        }

        private decimal Heuristic(Station start, Station end)
        {
            var endEdge = _edgeRepository.GetEdgeByStartEndStation(start, end);
            return endEdge != null ? endEdge.Distance : -1;
        }

        private void InsertVertex(Station vert, decimal fScore)
        {
            vert.Edges = _edgeRepository.GetEdgesByStartStation(vert).ToList();
            _openSet.Insert(vert, fScore);
        }
    }
}
