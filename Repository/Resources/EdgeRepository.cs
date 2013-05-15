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
            var edges = db.Edges.Where(x => x.StartStation.Equals(station.ID) || x.EndStation.Equals(station.ID));
            foreach (var edge in edges)
            {
                edge.StartStationObj = db.Stations.FirstOrDefault(x => x.ID.Equals(edge.StartStation));
                edge.EndStationObj = db.Stations.FirstOrDefault(x => x.ID.Equals(edge.EndStation));
            }

            return edges;
        }
    }
}
