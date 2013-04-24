using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IGraphService
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

    }
}