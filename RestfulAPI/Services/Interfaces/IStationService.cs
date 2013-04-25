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
        Station GetStationById(string id);

        [OperationContract]
        bool ReserveBattery(string stationId, string userId);

        #endregion

        #region StationMaintenance

        [OperationContract]
        List<StationMaintenance> GetAllStationMaintenances();

        [OperationContract]
        StationMaintenance GetStationMaintenanceById(string id);

        [OperationContract]
        bool EditStationMaintenance(StationMaintenance stationMaintenance);

        [OperationContract]
        bool InsertStationMaintenance(StationMaintenance stationStationMaintenance);

        #endregion

        #region MaintenanceType

        [OperationContract]
        List<MaintenanceType> GetAllMaintenanceTypes();

        [OperationContract]
        MaintenanceType GetMaintenanceTypeById(string id);

        [OperationContract]
        bool EditMaintenanceType(MaintenanceType maintenanceType);

        [OperationContract]
        bool InsertMaintenanceType(MaintenanceType maintenanceType);

        #endregion

        #region Battery

        [OperationContract]
        List<Battery> GetAllBatteries();

        [OperationContract]
        Battery GetBatteryById(string id);

        [OperationContract]
        List<Battery> GetBatteriesByStatus(string status);

        [OperationContract]
        bool EditBattery(Battery battery);

        [OperationContract]
        bool InsertBattery(Battery battery);

        #endregion
    }
}
