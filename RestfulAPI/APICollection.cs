using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Repository.Models;
using RestfulAPI.Services;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI
{
    [ServiceContract]
    public interface IAPICollection : IUserService, IStationService
    {}

    public class APICollection : IAPICollection
    {
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
    }
}
