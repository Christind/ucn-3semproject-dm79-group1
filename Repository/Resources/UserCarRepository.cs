using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class UserCarRepository
    {
        private readonly BPDbContext db;

        public UserCarRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<UserCar> GetAllUserCars()
        {
            return db.UserCars;
        }

        public UserCar GetUserCarById(int id)
        {
            return db.UserCars.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<UserCar> GetUserCarsByUser(User user)
        {
            return db.UserCars.Where(x => x.UserId == user.ID);
        }

        public void Insert(UserCar userCar)
        {
            if (userCar == null)
                return;

            db.UserCars.Add(userCar);
            db.SaveChanges();
        }

        public void Update(UserCar userCar)
        {
            if (userCar == null)
                return;

            UserCar dbUserCar = GetUserCarById(userCar.ID);
            if (dbUserCar == null)
                return;

            dbUserCar.CarId = userCar.CarId;
            db.SaveChanges();
        }

        public void Delete(UserCar userCar)
        {
            if (userCar == null)
                return;

            db.UserCars.Remove(userCar);
            db.SaveChanges();
        }
    }
}