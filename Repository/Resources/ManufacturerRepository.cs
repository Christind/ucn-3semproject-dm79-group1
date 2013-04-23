using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class ManufacturerRepository
    {
        private BPDbContext db;

        public ManufacturerRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            return db.Manufacturers;
        }

        public Manufacturer GetManufacturerById(int value)
        {
            return db.Manufacturers.FirstOrDefault(x => x.ID == value);
        }

        public void Insert(Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
        }

        public void Update(Manufacturer manufacturer)
        {
            Manufacturer rManufacturer = GetManufacturerById(manufacturer.ID);

            if (rManufacturer == null)
                return;

            rManufacturer.Name = manufacturer.Name;
            rManufacturer.Website = manufacturer.Website;
        }

        public void Disable(int value)
        {
            Manufacturer rManufacturer = GetManufacturerById(value);

            if (rManufacturer == null)
                return;

            rManufacturer.IsActive = false;
            db.SaveChanges();
        }
    }
}