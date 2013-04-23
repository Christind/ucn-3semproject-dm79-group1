using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class BatteryCollectionRepository
    {
        private BPDbContext db;
        private BatteryRepository _batteryRepo;
        public BatteryCollectionRepository()
        {
            db = new BPDbContext();
            _batteryRepo = new BatteryRepository();
        }

        public IQueryable<BatteryCollection> GetAllBatteryCollections()
        {
            return db.BatteryCollections;
        }

        public BatteryCollection GetBatteryCollectionById(int id)
        {
            return db.BatteryCollections.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<BatteryCollection> GetBatteryCollectionByStorage(BatteryStorage batteryStorage)
        {
            var batteryCollection = db.BatteryCollections.Where(x => x.BatteryStorageId.Equals(batteryStorage.ID));
            foreach (var collection in batteryCollection)
            {
                collection.Battery = _batteryRepo.GetBatteryById(collection.BatteryId);
            }

            return batteryCollection;
        }

        public void Insert(BatteryCollection batteryCollection)
        {
            db.BatteryCollections.Add(batteryCollection);
            db.SaveChanges();
        }

        public void Update(BatteryCollection batteryCollection)
        {
            BatteryCollection rBattery = GetBatteryCollectionById(batteryCollection.ID);
            if (rBattery == null)
                return;

            db.SaveChanges();
        }

        public void Disable(int value)
        {
            BatteryCollection rBatteryCollection = GetBatteryCollectionById(value);

            if (rBatteryCollection == null)
                return;

            rBatteryCollection.IsActive = false;
            db.SaveChanges();
        }
    }
}
