using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IStationMaintenanceService
    {
        [OperationContract]
        List<StationMaintenance> GetAllStationMaintenances();

        [OperationContract]
        StationMaintenance GetStationMaintenanceById(string id);

        [OperationContract]
        bool EditStationMaintenance(StationMaintenance stationMaintenance);

        [OperationContract]
        bool InsertStationMaintenance(StationMaintenance stationStationMaintenance);
    }
}
