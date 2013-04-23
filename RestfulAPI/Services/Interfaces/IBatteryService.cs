using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    interface IBatteryService
    {
        [OperationContract]
        List<Battery> GetAllBatteries();

        [OperationContract]
        Battery GetBatteryById(string id);

        [OperationContract]
        bool EditBattery(Battery battery);

        [OperationContract]
        bool InsertBattery(Battery battery);

        [OperationContract]
        List<Battery> GetBatteriesByStatus(int status);
    }
}
