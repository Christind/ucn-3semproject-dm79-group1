using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
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
                if (WebOperationContext.Current != null)
                    HandleLogging.LogMessage(ex, "WCF - GetAllUsers", 1, WebOperationContext.Current.IncomingRequest);
                return null;
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

        public bool EditUserData(User editData)
        {
            try
            {
                if (editData == null)
                    return false;

                _userRepository.Update(editData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AuthenticateUser(string userName, string password)
        {
            var user = _userRepository.GetUserByUserName(userName);
            if (user == null)
                return false;

            return user.Password.Equals(password);
        }
    }
}