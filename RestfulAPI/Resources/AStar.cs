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
        private readonly MinHeap<Station, List<Station>> _openSet;
        private readonly Dictionary<Station, Station> _cameFrom;
        private readonly Dictionary<int, decimal> _gScores;
        private readonly Dictionary<Station, decimal> _fScores;
        private readonly List<Station> _path;

        public AStar()
        {
            _edgeRepository = new EdgeRepository();
            _stationService = new StationService();

            _closedSet = new List<Station>();
            _openSet = new MinHeap<Station, List<Station>>(1064);
            _cameFrom = new Dictionary<Station, Station>();
            _gScores = new Dictionary<int, decimal>();
            _fScores = new Dictionary<Station, decimal>();
            _path = new List<Station>();
        }

        public List<Station> CalculateRoute(string sLat, string sLng, string eLat, string eLng, decimal maxRange)
        {
            if (maxRange < 1)
                return null;

            maxRange = maxRange * 1000;
            Station firstStation = _stationService.LocateNearestStation(sLat, sLng);
            Station endStation = _stationService.LocateNearestStation(eLat, eLng);
            firstStation.Edges = _edgeRepository.GetEdgesByStartStation(firstStation);

            decimal firstStationFScore = Heuristic(firstStation, endStation);
            _gScores[firstStation.ID] = 0;
            _openSet.Insert(firstStation, new List<Station>(), firstStationFScore);

            while (_openSet.Count > 0)
            {
                var current = _openSet.Minimum;
                if (current.Element.ID == endStation.ID)
                {
                    current.Path.Add(current.Element);
                    return ReconstructPath(current.Path);
                }

                _openSet.RemoveMinimum();
                _closedSet.Add(current.Element);
                var edges = current.Element.Edges.Where(x => x.Distance < maxRange);
                foreach (var edge in edges)
                {
                    decimal distance = edge.Distance;
                    decimal tentativeGScore = _gScores[current.Element.ID] + distance;
                    bool isStationInClosedSet = _closedSet.Contains(edge.EndStation);
                    if (isStationInClosedSet)
                        if (tentativeGScore >= _gScores[edge.EndStationId])
                            continue;

                    bool isStationInOpenset = _openSet.Contains(edge.EndStation);
                    if (!isStationInOpenset || tentativeGScore < _gScores[edge.EndStationId])
                    {
                        _gScores[edge.EndStation.ID] = tentativeGScore;
                        var fScore = _gScores[edge.EndStationId] + Heuristic(edge.EndStation, endStation);
                        var path = new List<Station>(current.Path);
                        if (_fScores.ContainsKey(edge.EndStation) && _fScores[edge.EndStation] > fScore)
                        {
                            _fScores[edge.EndStation] = fScore;
                            path.Add(current.Element);
                            InsertVertex(edge.EndStation, path, fScore);
                        }

                        if (!isStationInOpenset && !isStationInClosedSet)
                        {
                            path.Add(current.Element);
                            InsertVertex(edge.EndStation, path, fScore);
                        }
                    }
                }
            }

            return null;
        }

        private List<Station> ReconstructPath(List<Station> path)
        {
            foreach (Station station in path)
            {
                station.Edges = null;
            }

            return path;
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

        private void InsertVertex(Station vert, List<Station> path, decimal fScore)
        {
            vert.Edges = _edgeRepository.GetEdgesByStartStation(vert);
            _openSet.Insert(vert, path, fScore);
        }
    }
}
