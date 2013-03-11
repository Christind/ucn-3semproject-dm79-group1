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
            if(user == null)
                return;

            User dbUser = GetUserById(user.ID);
            if (dbUser == null)
                return;

            dbUser.Email = user.Email;
            dbUser.IsActive = user.IsActive;
            dbUser.UserName = user.UserName;
            db.SaveChanges();
        }

        public void Disable(int id)
        {
            User dbUser = GetUserById(id);
            if (dbUser == null)
                return;
            dbUser.IsActive = false;
            db.SaveChanges();
        }
    }
}
