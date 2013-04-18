using System;
using System.Collections.Generic;
using System.Linq;
using Logging;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _userRepository.GetAllUsers().ToList();
            }
            catch (Exception ex)
            {
                //HandleLogging.LogMessage(ex, "WCF - GetAllUsers", 1);
                //return null;
                throw;
            }
        }

        public User GetUserById(string id)
        {
            try
            {
                return _userRepository.GetUserById(Convert.ToInt32(id), true);
            }
            catch (Exception ex)
            {
                //HandleLogging.LogMessage(ex, "WCF - GetUserById", 1);
                //return null;
                throw;
            }
        }
    }
}