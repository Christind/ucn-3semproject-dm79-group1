using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class BatteryCollectionRepository
    {
        private BPDbContext db;

        public BatteryCollectionRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<BatteryCollection> GetAllBatteryCollections()
        {
            return db.BatteryCollections;
        }

        public BatteryCollection GetBatteryCollectionById(int id)
        {
            return db.BatteryCollections.FirstOrDefault(x => x.ID == id);
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
