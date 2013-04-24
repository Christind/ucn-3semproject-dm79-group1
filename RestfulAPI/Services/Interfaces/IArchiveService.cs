using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IArchiveService
    {
        [OperationContract]
        List<Archive> GetAllArchives();

        [OperationContract]
        Archive GetArchiveById(string id);

        [OperationContract]
        bool InsertArchive(Archive archive);

        [OperationContract]
        List<Archive> GetArchivesByUserId(string id);
    }
}
