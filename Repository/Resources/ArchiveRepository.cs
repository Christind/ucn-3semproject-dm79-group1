using System.Collections.Generic;
using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class ArchiveRepository
    {
        private BPDbContext db;

        public ArchiveRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Archive> GetAllArchives()
        {
            return db.Archives;
        }

        public Archive GetArchiveById(int id)
        {
            return db.Archives.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Archive> GetArchivesByUserId(int userId)
        {
            return db.Archives.Where(x => x.UserId == userId);
        }

        public void Insert(Archive archive)
        {
            db.Archives.Add(archive);
            db.SaveChanges();
        }

        public void Delete(Archive archive)
        {
            if (GetArchiveById(archive.ID) == null)
                return;
            db.Archives.Remove(archive);
            db.SaveChanges();
        }
    }
}
