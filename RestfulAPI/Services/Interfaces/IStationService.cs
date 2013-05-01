using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IStationService
    {
        #region Station

        [OperationContract]
        List<Station> GetAllStations();

        [OperationContract]
        Station GetStationById(string value);

        [OperationContract]
        bool CreateStation(Station station);

        [OperationContract]
        bool UpdateStation(Station station);

        [OperationContract]
        bool DisableStation(string value);

        #endregion

        #region StationMaintenance

        [OperationContract]
        List<StationMaintenance> GetAllStationMaintenances();

        [OperationContract]
        StationMaintenance GetStationMaintenanceById(string value);

        [OperationContract]
        bool CreateStationMaintenance(StationMaintenance stationMaintenance);

        [OperationContract]
        bool UpdateStationMaintenance(StationMaintenance stationMaintenance);

        [OperationContract]
        bool DisableStationMainteneance(string value);

        #endregion

        #region MaintenanceType

        [OperationContract]
        List<MaintenanceType> GetAllMaintenanceTypes();

        [OperationContract]
        MaintenanceType GetMaintenanceTypeById(string value);

        [OperationContract]
        bool CreateMaintenanceType(MaintenanceType maintenanceType);

        [OperationContract]
        bool UpdateMaintenanceType(MaintenanceType maintenanceType);

        [OperationContract]
        bool DisableMaintenanceType(string value);

        #endregion

        #region Battery

        [OperationContract]
        List<Battery> GetAllBatteries();

        [OperationContract]
        Battery GetBatteryById(string value);

        [OperationContract]
        List<Battery> GetBatteriesByStatus(string value);

        [OperationContract]
        bool ReserveBattery(string stationValue, string userValue);

        [OperationContract]
        bool CreateBattery(Battery battery);

        [OperationContract]
        bool UpdateBattery(Battery battery);

        [OperationContract]
        bool DisableBattery(string value);

        #endregion

        #region city

        [OperationContract]
        City GetCityByZipCode(string value);

        [OperationContract]
        City GetCityByName(string value);

        #endregion
    }
}
