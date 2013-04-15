using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class ArchiveStationRepository
    {
        private BPDbContext db;

        public ArchiveStationRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<ArchiveStation> GetAllArchiveStations()
        {
            return db.ArchiveStations;
        }

        public ArchiveStation GetArchiveStationById(int id)
        {
            return db.ArchiveStations.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(ArchiveStation archiveStation)
        {
            db.ArchiveStations.Add(archiveStation);
            db.SaveChanges();
        }

        public void Update(ArchiveStation archiveStation)
        {
            ArchiveStation rArchiveStation = GetArchiveStationById(archiveStation.ID);
            if (rArchiveStation == null)
                return;

            rArchiveStation.Archive = archiveStation.Archive;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            ArchiveStation rArchiveStation = GetArchiveStationById(value);

            if (rArchiveStation == null)
                return;

            rArchiveStation.IsActive = false;
            db.SaveChanges();
        }
    }
}
