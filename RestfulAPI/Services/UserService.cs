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
        private UserRepository _userRepo;
        private BookmarkRepository _bookmarkRepo;
        private CarRepository _carRepo;
        private UserCarRepository _userCarRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
            _bookmarkRepo = new BookmarkRepository();
            _carRepo = new CarRepository();
            _userCarRepo = new UserCarRepository();
        }

        #region User related methods

        public List<User> GetAllUsers()
        {
            try
            {
                return _userRepo.GetAllUsers().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - GetAllUsers", 1, WebOperationContext.Current);
                return null;
            }
        }

        public User GetUserById(string id)
        {
            try
            {
                return _userRepo.GetUserById(Convert.ToInt32(id), true);
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - GetUserById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool EditUserData(User editData)
        {
            try
            {
                if (editData == null)
                    return false;

                _userRepo.Update(editData);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - EditUserData", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool AuthenticateUser(string userName, string password)
        {
            try
            {
                var user = _userRepo.GetUserByUserName(userName);
                if (user == null)
                    return false;

                return user.Password.Equals(password);
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - AuthenticateUser", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region Bookmark related methods

        public Bookmark GetBookmarkById(string id)
        {
            try
            {
                int bookmarkId;
                if (Int32.TryParse(id, out bookmarkId))
                {
                    return _bookmarkRepo.GetBookmarkById(bookmarkId);
                }
                else
                {
                    throw new FormatException("The supplied id, is not of the datatype integer.");
                }
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public List<Bookmark> GetBookmarksByUser(string userId)
        {
            try
            {
                int id;
                if (Int32.TryParse(userId, out id))
                {
                    return _bookmarkRepo.GetBookmarksByUserId(id).ToList();
                }
                else
                {
                    throw new FormatException("The supplied id, is not of the datatype integer.");
                }
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateBookmark(Bookmark bookmark)
        {
            try
            {
                _bookmarkRepo.Insert(bookmark);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DeleteBookmark(string id)
        {
            try
            {
                int bookmarkId;
                if (Int32.TryParse(id, out bookmarkId))
                {
                    _bookmarkRepo.Disable(bookmarkId);
                    return true;
                }
                else
                {
                    throw new FormatException("The supplied id, is not of the datatype integer.");
                }
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool EditBookmark(Bookmark bookmark)
        {
            try
            {
                _bookmarkRepo.Update(bookmark);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region Car related methods

        public List<Car> GetAllCars()
        {
            return _carRepo.GetAllCars().ToList();
        }

        public Car GetCarById(int id)
        {
            return _carRepo.GetCarById(id);
        }

        public bool AddUserCar(int userId, int carId)
        {
            User user = _userRepo.GetUserById(userId);
            Car car = _carRepo.GetCarById(carId);
            if (user == null || car == null)
                return false;

            var userCar = new UserCar()
                                  {
                                      CarId = car.ID,
                                      UserId = user.ID,
                                      IsActive = true
                                  };
            _userCarRepo.Insert(userCar);

            return true;
        }

        #endregion
    }
}