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

        public bool EditUserData(string id, string editData)
        {
            throw new System.NotImplementedException();
        }

        public bool AuthenticateUser(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public List<Station> GetAllStations()
        {
            throw new System.NotImplementedException();
        }

        public Station GetStationById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
