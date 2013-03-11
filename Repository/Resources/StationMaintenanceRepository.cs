using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class StationMaintenanceRepository
    {
        private BPDbContext db;

        public StationMaintenanceRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<StationMaintenance> GetAllStationMaintenance()
        {
            return db.StationMaintenances;
        }

        public StationMaintenance GetStationMaintenanceById(int value)
        {
            return db.StationMaintenances.FirstOrDefault(x => x.ID == value);
        }

        public void Insert(StationMaintenance stationMaintenance)
        {
            db.StationMaintenances.Add(stationMaintenance);
            db.SaveChanges();
        }

        public void Update(StationMaintenance stationMaintenance)
        {
            StationMaintenance rMaintenance = GetStationMaintenanceById(stationMaintenance.ID);

            if (rMaintenance == null)
                return;

            rMaintenance.ExpectedOperationalDate = stationMaintenance.ExpectedOperationalDate;
            rMaintenance.IsActive = stationMaintenance.IsActive;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            StationMaintenance rMaintenance = GetStationMaintenanceById(value);

            if (rMaintenance == null)
                return;

            rMaintenance.IsActive = false;
            db.SaveChanges();
        }
    }
}