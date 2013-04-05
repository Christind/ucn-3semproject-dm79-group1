using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RouteAPI.Services.Interfaces;

namespace RouteAPI.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        private UserRepository userRepo;

        public UserService()
        {
            userRepo = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return userRepo.GetAllUsers().ToList();
        }

        public User GetUserById(int id)
        {
            return userRepo.GetUserById(id, true);
        }
    }
}
