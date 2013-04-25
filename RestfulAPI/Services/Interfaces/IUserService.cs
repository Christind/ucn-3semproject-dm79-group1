using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        #region User related methods

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUserById(string id);

        [OperationContract]
        bool EditUserData(User editData);

        [OperationContract]
        bool AuthenticateUser(string userName, string password);

        #endregion

        #region Bookmark related methods

        [OperationContract]
        Bookmark GetBookmarkById(string id);

        [OperationContract]
        List<Bookmark> GetBookmarksByUser(string userId);

        [OperationContract]
        bool CreateBookmark(Bookmark bookmark);

        [OperationContract]
        bool DeleteBookmark(string id);

        [OperationContract]
        bool EditBookmark(Bookmark bookmark);

        #endregion

        #region Car related methods

        [OperationContract]
        List<Car> GetAllCars();

        [OperationContract]
        Car GetCarById(int id);

        [OperationContract]
        bool AddUserCar(int userId, int carId);

        #endregion
    }
}