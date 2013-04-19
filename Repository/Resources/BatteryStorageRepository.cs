using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class BatteryStorageRepository
    {
        private BPDbContext db;
        private BatteryCollectionRepository _batteryCollectionRepo;
        public BatteryStorageRepository()
        {
            db = new BPDbContext();
            _batteryCollectionRepo = new BatteryCollectionRepository();
        }

        public IQueryable<BatteryStorage> GetAllBatteryStorages()
        {
            return db.BatteryStorages;
        }

        public BatteryStorage GetBatteryStorageById(int id)
        {
            return db.BatteryStorages.FirstOrDefault(x => x.ID == id);
        }

        public BatteryStorage GetBatteryStorageByStationId(int stationId, bool getAssociations = false)
        {
            var batteryStorage = db.BatteryStorages.FirstOrDefault(x => x.StationId.Equals(stationId));
            if (batteryStorage == null)
                return null;

            if(getAssociations)
            {
                batteryStorage.BatteryCollections = _batteryCollectionRepo.GetBatteryCollectionByStorage(batteryStorage).ToList();
            }

            return batteryStorage;
        }

        public void Insert(BatteryStorage batteryStorage)
        {
            db.BatteryStorages.Add(batteryStorage);
            db.SaveChanges();
        }

        public void Update(BatteryStorage batteryStorage)
        {
            BatteryStorage rBatteryStorage = GetBatteryStorageById(batteryStorage.ID);
            if (rBatteryStorage == null)
                return;

            rBatteryStorage.Available = batteryStorage.Available;
            rBatteryStorage.Charging = batteryStorage.Charging;
            rBatteryStorage.Reserved = batteryStorage.Reserved;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            BatteryStorage rBatteryStorage = GetBatteryStorageById(value);

            if (rBatteryStorage == null)
                return;

            rBatteryStorage.IsActive = false;
            db.SaveChanges();
        }

        public void UpdateStorageStatus(BatteryStorage batteryStorage)
        {
            if(batteryStorage == null)
                return;

            int available = batteryStorage.BatteryCollections.Count(x => x.Battery.Status == 1);
            int charging = batteryStorage.BatteryCollections.Count(x => x.Battery.Status == 2);
            int reserved = batteryStorage.BatteryCollections.Count(x => x.Battery.Status == 3);

            batteryStorage.Available = available;
            batteryStorage.Charging = charging;
            batteryStorage.Reserved = reserved;

            Update(batteryStorage);
        }
    }
}