﻿using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class ArchiveRepository
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

        public void Disable(int value)
        {
            Archive rArchive = GetArchiveById(value);

            if (rArchive == null)
                return;

            rArchive.IsActive = false;
            db.SaveChanges();
        }
    }
}
