using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Repository.Models;
using RestfulAPI.Services;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI
{
    [ServiceContract]
    public interface IAPICollection : IUserService, IStationService, IRouteService
    { }

    public class APICollection : IAPICollection
    {
        #region user

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/users")]
        public List<User> GetAllUsers()
        {
            return new UserService().GetAllUsers();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/user/id/{value}")]
        public User GetUserById(string value)
        {
            return new UserService().GetUserById(value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/user/name/{value}")]
        public User GetUserByUserName(string value)
        {
            return new UserService().GetUserByUserName(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/user", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateUser(User user)
        {
            return new UserService().CreateUser(user);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/user", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateUser(User user)
        {
            return new UserService().UpdateUser(user);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/user/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableUser(string value)
        {
            return new UserService().DisableUser(value);
        }

        #endregion

        #region authentication

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "auth/{userName}@{password}")]
        public bool AuthenticateUser(string userName, string password)
        {
            return new UserService().AuthenticateUser(userName, password);
        }

        #endregion

        #region bookmark

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/bookmark/id/{value}")]
        public Bookmark GetBookmarkById(string value)
        {
            return new UserService().GetBookmarkById(value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/bookmark/userid/{value}")]
        public List<Bookmark> GetBookmarksByUserId(string value)
        {
            return new UserService().GetBookmarksByUserId(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/bookmark", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateBookmark(Bookmark bookmark)
        {
            return new UserService().CreateBookmark(bookmark);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/bookmark", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateBookmark(Bookmark bookmark)
        {
            return new UserService().UpdateBookmark(bookmark);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/bookmark/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableBookmark(string value)
        {
            return new UserService().DisableBookmark(value);
        }

        #endregion

        #region car

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/cars")]
        public List<Car> GetAllCars()
        {
            return new UserService().GetAllCars();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/car/id/{value}")]
        public Car GetCarById(string value)
        {
            return new UserService().GetCarById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/car", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateCar(Car car)
        {
            return new UserService().CreateCar(car);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/car", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateCar(Car car)
        {
            return new UserService().UpdateCar(car);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/car/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableCar(string value)
        {
            return new UserService().DisableCar(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/usercar", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateUserCar(string userValue, string carValue)
        {
            return new UserService().CreateUserCar(userValue, carValue);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/usercar", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateUserCar(UserCar userCar)
        {
            return new UserService().UpdateUserCar(userCar);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/usercar/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableUserCar(string value)
        {
            return new UserService().DisableUserCar(value);
        }

        #endregion

        #region station

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/stations")]
        public List<Station> GetAllStations()
        {
            return new StationService().GetAllStations();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/station/id/{value}")]
        public Station GetStationById(string value)
        {
            return new StationService().GetStationById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/station", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateStation(Station station)
        {
            return new StationService().CreateStation(station);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/station", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateStation(Station station)
        {
            return new StationService().UpdateStation(station);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/station/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableStation(string value)
        {
            return new StationService().DisableStation(value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/station/nearest/{lat}@{lng}")]
        public Station LocateNearestStation(string lat, string lng)
        {
            return new StationService().LocateNearestStation(lat, lng);
        }

        #endregion

        #region station maintenances

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/maintenances")]
        public List<StationMaintenance> GetAllStationMaintenances()
        {
            return new StationService().GetAllStationMaintenances();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/maintenance/id/{value}")]
        public StationMaintenance GetStationMaintenanceById(string value)
        {
            return new StationService().GetStationMaintenanceById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/maintenance", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateStationMaintenance(StationMaintenance stationMaintenance)
        {
            return new StationService().CreateStationMaintenance(stationMaintenance);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/maintenance", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateStationMaintenance(StationMaintenance stationMaintenance)
        {
            return new StationService().UpdateStationMaintenance(stationMaintenance);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/maintenance/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableStationMainteneance(string value)
        {
            return new StationService().DisableStationMainteneance(value);
        }

        #endregion

        #region maintenance types

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/maintenance/types")]
        public List<MaintenanceType> GetAllMaintenanceTypes()
        {
            return new StationService().GetAllMaintenanceTypes();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/maintenance/type/id/{value}")]
        public MaintenanceType GetMaintenanceTypeById(string value)
        {
            return new StationService().GetMaintenanceTypeById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/maintenance/type", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateMaintenanceType(MaintenanceType maintenanceType)
        {
            return new StationService().CreateMaintenanceType(maintenanceType);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/maintenance/type", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateMaintenanceType(MaintenanceType maintenanceType)
        {
            return new StationService().UpdateMaintenanceType(maintenanceType);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/maintenance/type/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableMaintenanceType(string value)
        {
            return new StationService().DisableMaintenanceType(value);
        }

        #endregion

        #region battery

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/batteries")]
        public List<Battery> GetAllBatteries()
        {
            return new StationService().GetAllBatteries();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/battery/id/{value}")]
        public Battery GetBatteryById(string value)
        {
            return new StationService().GetBatteryById(value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/battery/status/{value}")]
        public List<Battery> GetBatteriesByStatus(string value)
        {
            return new StationService().GetBatteriesByStatus(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "reserve/battery/{stationValue},{userValue}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool ReserveBattery(string stationValue, string userValue)
        {
            return new StationService().ReserveBattery(stationValue, userValue);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/battery", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateBattery(Battery battery)
        {
            return new StationService().CreateBattery(battery);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/battery", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateBattery(Battery battery)
        {
            return new StationService().UpdateBattery(battery);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/battery/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableBattery(string value)
        {
            return new StationService().DisableBattery(value);
        }

        #endregion

        #region edges

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/edges")]
        public List<Edge> GetAllEdges()
        {
            return new RouteService().GetAllEdges();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/edge/id/{value}")]
        public Edge GetEdgeById(string value)
        {
            return new RouteService().GetEdgeById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/edge", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateEdge(Edge edge)
        {
            return new RouteService().CreateEdge(edge);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "update/edge", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool UpdateEdge(Edge edge)
        {
            return new RouteService().UpdateEdge(edge);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "disable/edge/id/{value}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool DisableEdge(string value)
        {
            return new RouteService().DisableEdge(value);
        }

        #endregion

        #region route calculation

        // Needs to be reevaluated...
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "calculate/from/{sLat}@{sLng}/to/{eLat}@{eLng}")]
        public List<Station> CalculateRoute(string sLat, string sLng, string eLat, string eLng)
        {
            return new RouteService().CalculateRoute(sLat, sLng, eLat, eLng);
        }

        #endregion

        #region archive

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/archivedentries")]
        public List<Archive> GetAllArchivedEntries()
        {
            return new RouteService().GetAllArchivedEntries();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/archivedentry/id/{value}")]
        public Archive GetArchivedEntryById(string value)
        {
            return new RouteService().GetArchivedEntryById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/archivedentry", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateArchivedEntry(Archive archive)
        {
            return new RouteService().CreateArchivedEntry(archive);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/archivedstations")]
        public List<ArchiveStation> GetAllArchivedStations()
        {
            return new RouteService().GetAllArchivedStations();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/all/archivedstation/id/{value}")]
        public ArchiveStation GetArchivedStationById(string value)
        {
            return new RouteService().GetArchivedStationById(value);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "create/archivedstation", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public bool CreateArchivedStation(ArchiveStation archiveStation)
        {
            return new RouteService().CreateArchivedStation(archiveStation);
        }

        #endregion

        #region city

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/city/zipcode/{value}")]
        public City GetCityByZipCode(string value)
        {
            return new StationService().GetCityByZipCode(value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "get/city/name/{value}")]
        public City GetCityByName(string value)
        {
            return new StationService().GetCityByName(value);
        }

        #endregion
    }
}