using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Repository.Models;
using RestfulAPI.Services;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI
{
    [ServiceContract]
    public interface IAPICollection : IUserService, IStationService, IArchiveService, IGraphService
    {}

    public class APICollection : IAPICollection
    {
        #region UserService

        #region User related methods

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<User> GetAllUsers()
        {
            return new UserService().GetAllUsers();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/id:{value}")]
        public User GetUserById(string value)
        {
            return new UserService().GetUserById(value);
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

        #region Car related methods

        public List<Car> GetAllCars()
        {
            throw new System.NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool AddUserCar(int userId, int carId)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Bookmark related methods

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/bookmarks/get/id:{value}")]
        public Bookmark GetBookmarkById(string value)
        {
            return new UserService().GetBookmarkById(value);
        }

        //TODO: Better URI for this one
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/bookmarks/get/all/id:{userId}")]
        public List<Bookmark> GetBookmarksByUser(string userId)
        {
            return new UserService().GetBookmarksByUser(userId);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/bookmarks/create", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateBookmark(Bookmark bookmark)
        {
            return new UserService().CreateBookmark(bookmark);
        }

        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/bookmarks/delete/id:{id}")]
        public bool DeleteBookmark(string id)
        {
            return new UserService().DeleteBookmark(id);
        }

        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edit", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool EditBookmark(Bookmark bookmark)
        {
            return new UserService().EditBookmark(bookmark);
        }

        #endregion
        #endregion

        #region StatioService

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

        #region MaintenanceType related methods

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<MaintenanceType> GetAllMaintenanceTypes()
        {
            return new StationService().GetAllMaintenanceTypes();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public MaintenanceType GetMaintenanceTypeById(string id)
        {
            return new StationService().GetMaintenanceTypeById(id);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edit", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool EditMaintenanceType(MaintenanceType maintenanceType)
        {
            return new StationService().EditMaintenanceType(maintenanceType);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insert", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool InsertMaintenanceType(MaintenanceType maintenanceType)
        {
            return new StationService().InsertMaintenanceType(maintenanceType);
        }

        #endregion

        #region StationMaintenance related methods

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<StationMaintenance> GetAllStationMaintenances()
        {
            return new StationService().GetAllStationMaintenances();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public StationMaintenance GetStationMaintenanceById(string id)
        {
            return new StationService().GetStationMaintenanceById(id);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edit", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool EditStationMaintenance(StationMaintenance stationMaintenance)
        {
            return new StationService().EditStationMaintenance(stationMaintenance);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insert", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool InsertStationMaintenance(StationMaintenance stationMaintenance)
        {
            return new StationService().InsertStationMaintenance(stationMaintenance);
        }

        #endregion

        #region Battery related methods

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<Battery> GetAllBatteries()
        {
            return new StationService().GetAllBatteries();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public Battery GetBatteryById(string id)
        {
            return new StationService().GetBatteryById(id);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/status/{status}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public List<Battery> GetBatteriesByStatus(string status)
        {
            return new StationService().GetBatteriesByStatus(status);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edit", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool EditBattery(Battery battery)
        {
            return new StationService().EditBattery(battery);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insert", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool InsertBattery(Battery battery)
        {
            return new StationService().InsertBattery(battery);
        }

        #endregion
        #endregion

        #region Archive Services

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all")]
        public List<Archive> GetAllArchives()
        {
            return new ArchiveService().GetAllArchives();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/{id}")]
        public Archive GetArchiveById(string id)
        {
            return new ArchiveService().GetArchiveById(id);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/user/{id}")]
        public List<Archive> GetArchivesByUserId(string id)
        {
            return new ArchiveService().GetArchivesByUserId(id);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insert", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool InsertArchive(Archive archive)
        {
            return new ArchiveService().InsertArchive(archive);
        }

        #endregion

        #region graph service

        #region edges

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edge/get/all")]
        public List<Edge> GetAllEdges()
        {
            return new GraphService().GetAllEdges();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edge/get/id:{value}")]
        public Edge GetEdgeById(string value)
        {
            return new GraphService().GetEdgeById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edge/create", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateEdge(Edge edge)
        {
            return new GraphService().CreateEdge(edge);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edge/update", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateEdge(Edge edge)
        {
            return new GraphService().UpdateEdge(edge);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "edge/disable/id:{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableEdge(string value)
        {
            return new GraphService().DisableEdge(value);
        }

        #endregion

        #region route calculation

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "calculate/from:{sloc},to:{eloc}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CalculateRoute(string sloc, string eloc)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #endregion
    }
}