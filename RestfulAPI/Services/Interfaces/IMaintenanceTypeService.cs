using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IMaintenanceTypeService
    {
        [OperationContract]
        List<MaintenanceType> GetAllMaintenanceTypes();

        [OperationContract]
        MaintenanceType GetMaintenanceTypeById(string id);

        [OperationContract]
        bool EditMaintenanceType(MaintenanceType maintenanceType);

        [OperationContract]
        bool InsertMaintenanceType(MaintenanceType maintenanceType);
    }
}
