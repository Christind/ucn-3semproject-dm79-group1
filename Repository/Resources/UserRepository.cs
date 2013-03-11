using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class UserRepository
    {
        private BPDbContext db;

        public UserRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            return db.Users;
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(User user)
        {
            User rUser = GetUserById(user.ID);
            if (rUser == null)
                return;

            rUser.Email = user.Email;
            rUser.IsActive = user.IsActive;
            rUser.UserName = user.UserName;
            db.SaveChanges();
        }

        public void Delete(User user)
        {
            if (GetUserById(user.ID) == null)
                return;
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
