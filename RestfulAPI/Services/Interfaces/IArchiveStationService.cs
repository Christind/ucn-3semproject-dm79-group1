using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IArchiveStationService
    {
        [OperationContract]
        List<ArchiveStation> GetAllArchiveStation();

        [OperationContract]
        ArchiveStation GetArchiveStationById(string id);

        [OperationContract]
        bool EditArchiveStation(ArchiveStation archiveStation);

        [OperationContract]
        bool InsertArchiveStation(ArchiveStation archiveStation);

        [OperationContract]
        List<ArchiveStation> GetArchiveStationByArchive(string id);
    }
}
