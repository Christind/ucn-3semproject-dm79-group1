using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class CarRepository
    {
        private BPDbContext db;

        public CarRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Car> GetAllCars()
        {
            return db.Cars;
        }

        public Car GetCarById(int id)
        {
            return db.Cars.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Car> GetCarsByCarModel(CarModel model)
        {
            if (model == null)
                return null;

            return db.Cars.Where(x => x.CarModel.ID == model.ID);
        }

        public void Insert(Car car)
        {
            if (car == null)
                return;

            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Update(Car car)
        {
            if (car == null)
                return;
            Car dbCar = GetCarById(car.ID);
            if (dbCar == null)
                return;

            dbCar.Manufacturer = car.Manufacturer;
            dbCar.ManufacturerId = car.ManufacturerId;
            dbCar.ModelId = car.ModelId;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            Car dbCar = GetCarById(value);

            if (dbCar == null)
                return;

            dbCar.IsActive = false;
            db.SaveChanges();
        }
    }
}