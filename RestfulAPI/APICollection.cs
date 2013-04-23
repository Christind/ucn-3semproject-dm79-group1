using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Repository.Models;
using RestfulAPI.Services;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI
{
    [ServiceContract]
    public interface IAPICollection : IUserService, IStationService, IBookmarkService
    {}

    public class APICollection : IAPICollection
    {
        #region User services

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<User> GetAllUsers()
        {
            return new UserService().GetAllUsers();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public User GetUserById(string id)
        {
            return new UserService().GetUserById(id);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edit", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool EditUserData(User editData)
        {
            return new UserService().EditUserData(editData);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "auth/{userName}/{password}")]
        public bool AuthenticateUser(string userName, string password)
        {
            return new UserService().AuthenticateUser(userName, password);
        }

        #endregion

        #region Station services

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<Station> GetAllStations()
        {
            return new StationService().GetAllStations();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public Station GetStationById(string id)
        {
            return new StationService().GetStationById(id);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "reservebattery", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool ReserveBattery(string stationId, string userId)
        {
            return new StationService().ReserveBattery(stationId, userId);
        }

        #endregion

        #region Bookmark Services

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<Bookmark> GetAllBookmarks()
        {
            return new BookmarkService().GetAllBookmarks();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public Bookmark GetBookmarkById(string id)
        {
            return new BookmarkService().GetBookmarkById(id);
        }

        //TODO: Better URI for this one
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/userbookmarks/{userId}")]
        public List<Bookmark> GetBookmarksByUser(string userId)
        {
            return new BookmarkService().GetBookmarksByUser(userId);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateBookmark(Bookmark bookmark)
        {
            return new BookmarkService().CreateBookmark(bookmark);
        }

        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "delete/{id}")]
        public bool DeleteBookmark(string id)
        {
            return new BookmarkService().DeleteBookmark(id);
        }

        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edit", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool EditBookmark(Bookmark bookmark)
        {
            return new BookmarkService().EditBookmark(bookmark);
        }

        #endregion
    }
}
