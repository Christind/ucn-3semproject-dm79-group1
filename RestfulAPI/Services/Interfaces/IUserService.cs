using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        #region user

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUserById(string value);

        [OperationContract]
        User GetUserByUserName(string value);

        [OperationContract]
        bool CreateUser(User user);

        [OperationContract]
        bool UpdateUser(User user);

        [OperationContract]
        bool DisableUser(string value);

        #endregion

        #region authentication

        [OperationContract]
        bool AuthenticateUser(string userName, string password);

        #endregion

        #region bookmark

        [OperationContract]
        Bookmark GetBookmarkById(string value);

        [OperationContract]
        List<Bookmark> GetBookmarksByUserId(string value);

        [OperationContract]
        bool CreateBookmark(Bookmark bookmark);

        [OperationContract]
        bool UpdateBookmark(Bookmark bookmark);

        [OperationContract]
        bool DisableBookmark(string value);

        #endregion

        #region car

        [OperationContract]
        List<Car> GetAllCars();

        [OperationContract]
        Car GetCarById(string value);

        [OperationContract]
        bool CreateCar(Car car);

        [OperationContract]
        bool UpdateCar(Car car);

        [OperationContract]
        bool DisableCar(string value);

        [OperationContract]
        bool CreateUserCar(string userValue, string carValue);

        [OperationContract]
        bool UpdateUserCar(UserCar userCar);

        [OperationContract]
        bool DisableUserCar(string value);

        #endregion
    }
}