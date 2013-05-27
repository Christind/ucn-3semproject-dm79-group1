using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class EdgeRepository
    {
        private BPDbContext db;

        public EdgeRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Edge> GetAllEdges()
        {
            return db.Edges;
        }

        public Edge GetEdgeById(int id)
        {
            return db.Edges.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(Edge edge)
        {
            db.Edges.Add(edge);
            db.SaveChanges();
        }

        public void Update(Edge edge)
        {
            Edge rEdge = GetEdgeById(edge.ID);
            if (rEdge == null)
                return;

            rEdge.Distance = edge.Distance;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            Edge rEdge = GetEdgeById(value);

            if (rEdge == null)
                return;

            rEdge.IsActive = false;
            db.SaveChanges();
        }

        public IQueryable<Edge> GetEdgesByStation(Station station)
        {
            var edges = db.Edges.Where(x => x.StartStationId.Equals(station.ID) || x.EndStationId.Equals(station.ID));
            foreach (var edge in edges)
            {
                //edge.StartStation = db.Stations.FirstOrDefault(x => x.ID.Equals(edge.StartStation));
                edge.EndStation = db.Stations.FirstOrDefault(x => x.ID.Equals(edge.EndStationId));
            }

            return edges;
        }

        public IQueryable<Edge> GetEdgesByStartStation(Station station)
        {
            var edges = db.Edges.Where(x => x.StartStationId.Equals(station.ID) && x.EndStation.BatteryStorages.Available > 0);
            foreach (var edge in edges)
            {
                edge.EndStation = db.Stations.AsNoTracking().FirstOrDefault(x => x.ID.Equals(edge.EndStationId));
            }

            return edges;
        }

        public Edge GetEdgeByStartEndStation(Station start, Station end)
        {
            return db.Edges.AsNoTracking().FirstOrDefault(x => x.StartStationId.Equals(start.ID) && x.EndStationId.Equals(end.ID));
        }

        public List<Edge> GetEdgesByLocation(string _lat, string _lng)
        {
            _lat = _lat.Replace(".", ",");
            _lng = _lng.Replace(".", ",");
            double lat;
            decimal lat2 = Convert.ToDecimal(_lat);
            int lng = Convert.ToInt32(_lng.Substring(0, _lng.IndexOf(',')));

            if (Double.TryParse(_lat.Substring(0, _lat.IndexOf(',') + 1), out lat))
            {
                GeoCoordinate geoCoordinate = new GeoCoordinate(lat, lng);
                decimal dec = Math.Round(lat2, 1);
                var stations = db.Stations.Where(x => (Int32)x.StationLong == lng && Decimal.Round(x.StationLat,1) == dec);
                List<Edge> edges = new List<Edge>();
                foreach (var station in stations)
                {
                    double distance =
                        geoCoordinate.GetDistanceTo(new GeoCoordinate(Convert.ToDouble(station.StationLat),
                                                                      Convert.ToDouble(station.StationLong)));

                    Edge edge = new Edge{Distance = Convert.ToDecimal(distance), EndStationId = station.ID, EndStation = station, IsActive = true};
                    edges.Add(edge);
                }

                return edges;
            }

            return null;
        }
    }
}
