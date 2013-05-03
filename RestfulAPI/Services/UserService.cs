using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Logging;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;
using Utils.Helpers;

namespace RestfulAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepo;
        private readonly BookmarkRepository _bookmarkRepo;
        private readonly CarRepository _carRepo;
        private readonly UserCarRepository _userCarRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
            _bookmarkRepo = new BookmarkRepository();
            _carRepo = new CarRepository();
            _userCarRepo = new UserCarRepository();
        }

        #region user

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

        public User GetUserById(string value)
        {
            try
            {
                int userId;
                if (Int32.TryParse(value, out userId))
                {
                    return _userRepo.GetUserById(userId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetUserById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public User GetUserByUserName(string value)
        {
            try
            {
                return _userRepo.GetUserByUserName(value);
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetUserByUserName", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateUser(User user)
        {
            try
            {
                _userRepo.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateUser", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _userRepo.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateUser", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableUser(string value)
        {
            try
            {
                int userId;
                if (Int32.TryParse(value, out userId))
                {
                    _userRepo.Disable(userId);
                    return true;
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");

            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableUser", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region authentication

        public bool AuthenticateUser(string userName, string password)
        {
            try
            {
                var user = _userRepo.GetUserByUserName(userName);
                if (user == null)
                    return false;

                var hashedPassword = EncryptionHelper.GetSha512Hash(password + user.Salt);
                return user.Password.Equals(hashedPassword);
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - AuthenticateUser", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region bookmark

        public Bookmark GetBookmarkById(string value)
        {
            try
            {
                int bookmarkId;
                if (Int32.TryParse(value, out bookmarkId))
                {
                    return _bookmarkRepo.GetBookmarkById(bookmarkId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public List<Bookmark> GetBookmarksByUserId(string value)
        {
            try
            {
                int userId;
                if (Int32.TryParse(value, out userId))
                {
                    return _bookmarkRepo.GetBookmarksByUserId(userId).ToList();
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarksByUserId", 1, WebOperationContext.Current);
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
                HandleLogging.LogMessage(ex, "CreateBookmark", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateBookmark(Bookmark bookmark)
        {
            try
            {
                _bookmarkRepo.Insert(bookmark);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateBookmark", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableBookmark(string value)
        {
            try
            {
                int bookmarkId;
                if (Int32.TryParse(value, out bookmarkId))
                {
                    _bookmarkRepo.Disable(bookmarkId);
                    return true;
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");

            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableBookmark", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region user cars

        public List<Car> GetAllCars()
        {
            try
            {
                return _carRepo.GetAllCars().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - GetAllCars", 1, WebOperationContext.Current);
                return null;
            }
        }

        public Car GetCarById(string value)
        {
            try
            {
                int carId;
                if (Int32.TryParse(value, out carId))
                {
                    return _carRepo.GetCarById(carId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetCarById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateCar(Car car)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }

        public bool DisableCar(string userCar)
        {
            throw new NotImplementedException();
        }

        public bool CreateUserCar(string userValue, string carValue)
        {
            try
            {
                var user = _userRepo.GetUserById(Convert.ToInt32(userValue));
                var car = _carRepo.GetCarById(Convert.ToInt32(carValue));
                if (user == null || car == null)
                    return false;

                var userCar = new UserCar
                    {
                    CarId = car.ID,
                    UserId = user.ID,
                    IsActive = true
                };
                _userCarRepo.Insert(userCar);

                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "WCF - CreateUserCar", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateUserCar(UserCar userCar)
        {
            throw new NotImplementedException();
        }

        public bool DisableUserCar(string value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}