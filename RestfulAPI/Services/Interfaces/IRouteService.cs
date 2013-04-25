using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IRouteService
    {
        #region edges

        [OperationContract]
        List<Edge> GetAllEdges();

        [OperationContract]
        Edge GetEdgeById(string value);

        [OperationContract]
        bool CreateEdge(Edge edge);

        [OperationContract]
        bool UpdateEdge(Edge edge);

        [OperationContract]
        bool DisableEdge(string value);

        #endregion

        #region route calculation

        [OperationContract]
        bool CalculateRoute(string sloc, string eloc);

        #endregion

        #region archived entries

        [OperationContract]
        List<Archive> GetAllArchivedEntries();

        [OperationContract]
        Archive GetArchivedEntryById(string value);

        [OperationContract]
        bool CreateArchivedEntry(Archive archive);

        #endregion

        #region archived stations

        [OperationContract]
        List<ArchiveStation> GetAllArchivedStations();

        [OperationContract]
        ArchiveStation GetArchivedStationById(string value);

        [OperationContract]
        bool CreateArchivedStation(ArchiveStation archiveStation);

        #endregion

    }
}