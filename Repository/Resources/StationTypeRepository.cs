using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class StationTypeRepository
    {
        private BPDbContext db;

        public StationTypeRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<StationType> GetAllStationTypes()
        {
            return db.StationTypes;
        }

        public StationType GetStationTypeById(int value)
        {
            return db.StationTypes.FirstOrDefault(x => x.ID == value);
        }

        public void Insert(StationType stationType)
        {
            db.StationTypes.Add(stationType);
            db.SaveChanges();
        }

        public void Update(StationType stationType)
        {
            StationType rType = GetStationTypeById(stationType.ID);

            if (rType == null)
                return;

            rType.Title = stationType.Title;
            rType.Description = stationType.Description;
            db.SaveChanges();
        }

        public void Delete(StationType stationType)
        {
            if (GetStationTypeById(stationType.ID) == null)
                return;

            db.StationTypes.Remove(stationType);
            db.SaveChanges();
        }
    }
}