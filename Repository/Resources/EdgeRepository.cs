using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class EdgeRepository
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

        public void Delete(Edge edge)
        {
            if (GetEdgeById(edge.ID) == null)
                return;
            db.Edges.Remove(edge);
            db.SaveChanges();
        }
    }
}
