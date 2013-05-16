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
            var edges = db.Edges.Where(x => x.StartStationId.Equals(station.ID));
            foreach (var edge in edges)
            {
                //edge.StartStation = db.Stations.FirstOrDefault(x => x.ID.Equals(edge.StartStation));
                edge.EndStation = db.Stations.FirstOrDefault(x => x.ID.Equals(edge.EndStationId));
            }

            return edges;
        }

        public Edge GetEdgeByStartEndStation(Station start, Station end)
        {
            return db.Edges.FirstOrDefault(x => x.StartStationId.Equals(start.ID) && x.EndStationId.Equals(end.ID));
        }
    }
}
