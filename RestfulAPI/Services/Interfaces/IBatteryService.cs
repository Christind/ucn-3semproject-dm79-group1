using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IBatteryService
    {
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

    }
}