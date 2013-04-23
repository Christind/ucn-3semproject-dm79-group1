using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class StationMaintenanceRepository
    {
        private BPDbContext db;
        private StationRepository _stationRepo;
        private MaintenanceTypeRepository _maintenanceTypeRepo;
        public StationMaintenanceRepository()
        {
            db = new BPDbContext();
            _stationRepo = new StationRepository();
            _maintenanceTypeRepo = new MaintenanceTypeRepository();
        }

        public IQueryable<StationMaintenance> GetAllStationMaintenance()
        {
            return db.StationMaintenances;
        }

        public StationMaintenance GetStationMaintenanceById(int value, bool getAssociations = false)
        {
            var maintenance = db.StationMaintenances.FirstOrDefault(x => x.ID == value);
            if (maintenance == null)
                return null;

            if(getAssociations)
            {
                maintenance.Station = _stationRepo.GetStationById(value, true);
                maintenance.MaintenanceType = _maintenanceTypeRepo.GetMaintenanceTypeById(maintenance.TypeId);
            }

            return maintenance;
        }

        public IQueryable<StationMaintenance> GetStationMaintenancesByStationId(int stationId, bool getAssociations = false)
        {
            var maintenances = db.StationMaintenances.Where(x => x.StationId == stationId);

            if (getAssociations)
            {
                foreach (var maintenance in maintenances)
                {
                    maintenance.Station = _stationRepo.GetStationById(stationId, true);
                    maintenance.MaintenanceType = _maintenanceTypeRepo.GetMaintenanceTypeById(maintenance.TypeId);
                }
            }

            return maintenances;
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