using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class BatteryRepository
    {
        private BPDbContext db;

        public BatteryRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Battery> GetAllBatteries()
        {
            return db.Batteries;
        }

        public Battery GetBatteryById(int id)
        {
            return db.Batteries.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(Battery battery)
        {
            db.Batteries.Add(battery);
            db.SaveChanges();
        }

        public void Update(Battery battery)
        {
            Battery rBattery = GetBatteryById(battery.ID);
            if (rBattery == null)
                return;

            rBattery.OutOfCommisionDate = battery.OutOfCommisionDate;
            rBattery.IsActive = battery.IsActive;
            db.SaveChanges();
        }

        public void Delete(Battery battery)
        {
            if (GetBatteryById(battery.ID) == null)
                return;
            db.Batteries.Remove(battery);
            db.SaveChanges();
        }
    }
}
