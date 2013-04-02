using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class CarModelRepository
    {
        private BPDbContext db;

        public CarModelRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<CarModel> GetAllCarModels()
        {
            return db.CarModels;
        }

        public CarModel GetCarModelById(int id)
        {
            return db.CarModels.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(CarModel carModel)
        {
            db.CarModels.Add(carModel);
            db.SaveChanges();
        }

        public void Update(CarModel carModel)
        {
            CarModel rCarModel = GetCarModelById(carModel.ID);
            if (rCarModel == null)
                return;

            rCarModel.Cars = carModel.Cars;
            rCarModel.Name = carModel.Name;
            rCarModel.Range = carModel.Range;
            rCarModel.Website = carModel.Website;
            rCarModel.Year = carModel.Year;
            db.SaveChanges();
        }

        public void Delete(CarModel carModel)
        {
            if (GetCarModelById(carModel.ID) == null)
                return;
            db.CarModels.Remove(carModel);
            db.SaveChanges();
        }
    }
}
