using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class BatteryStorageRepository
    {
        private BPDbContext db;

        public BatteryStorageRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<BatteryStorage> GetAllBatteryStorages()
        {
            return db.BatteryStorages;
        }

        public BatteryStorage GetBatteryStorageById(int id)
        {
            return db.BatteryStorages.FirstOrDefault(x => x.ID == id);
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

        public void Delete(BatteryStorage batteryStorage)
        {
            if (GetBatteryStorageById(batteryStorage.ID) == null)
                return;
            db.BatteryStorages.Remove(batteryStorage);
            db.SaveChanges();
        }
    }
}