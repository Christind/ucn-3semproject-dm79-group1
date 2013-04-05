using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;
using RouteAPI.Services.Interfaces;

namespace RouteAPI.Services
{
    [ServiceContract]
    public interface IAPIService : IStationService, IUserService
    {}

    public class APIServices : IAPIService
    {
        public List<Station> GetAllStations()
        {
            return new StationService().GetAllStations();
        }

        public Station GetStationById(int id)
        {
            return new StationService().GetStationById(id);
        }

        public List<User> GetAllUsers()
        {
            return new UserService().GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return new UserService().GetUserById(id);
        }
    }
}
