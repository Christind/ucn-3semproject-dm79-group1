using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class BatteryChargingRepository
    {
        private BPDbContext db;

        public BatteryChargingRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<BatteryCharging> GetAllBatteryChargings()
        {
            return db.BatteryChargings;
        }

        public BatteryCharging GetBatteryChargingById(int id)
        {
            return db.BatteryChargings.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(BatteryCharging batteryCharging)
        {
            db.BatteryChargings.Add(batteryCharging);
            db.SaveChanges();
        }

        public void Update(BatteryCharging batteryCharging)
        {
            BatteryCharging rBatteryCharging = GetBatteryChargingById(batteryCharging.ID);
            if (rBatteryCharging == null)
                return;

            rBatteryCharging.CompletedTime = batteryCharging.CompletedTime;
            rBatteryCharging.EstimatedTime = batteryCharging.EstimatedTime;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            BatteryCharging rBatteryCharging = GetBatteryChargingById(value);

            if (rBatteryCharging == null)
                return;

            rBatteryCharging.IsActive = false;
            db.SaveChanges();
        }
    }
}