using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    class MaintenanceTypeRepository
    {
        private BPDbContext db;

        public MaintenanceTypeRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<MaintenanceType> GetAllMaintenanceTypes()
        {
            return db.MaintenanceTypes;
        }

        public MaintenanceType GetMaintenanceTypeById(int value)
        {
            return db.MaintenanceTypes.FirstOrDefault(x => x.ID == value);
        }

        public void Insert(MaintenanceType maintenanceType)
        {
            db.MaintenanceTypes.Add(maintenanceType);
            db.SaveChanges();
        }

        public void Update(MaintenanceType maintenanceType)
        {
            MaintenanceType rType = GetMaintenanceTypeById(maintenanceType.ID);

            if (rType == null)
                return;

            rType.Title = maintenanceType.Title;
            rType.Description = maintenanceType.Description;
            db.SaveChanges();
        }

        public void Delete(MaintenanceType maintenanceType)
        {
            if (GetMaintenanceTypeById(maintenanceType.ID) == null)
                return;

            db.MaintenanceTypes.Remove(maintenanceType);
            db.SaveChanges();
        }
    }
}