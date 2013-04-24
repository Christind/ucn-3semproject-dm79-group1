using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using Logging;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class GraphService : IGraphService
    {
        private EdgeRepository _edgeRepository;

        public GraphService()
        {
            _edgeRepository = new EdgeRepository();
        }

        #region edges

        public List<Edge> GetAllEdges()
        {
            try
            {
                return _edgeRepository.GetAllEdges().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllEdges", 1, WebOperationContext.Current);
                return null;
            }
        }

        public Edge GetEdgeById(string value)
        {
            try
            {
                int edgeId;
                if (Int32.TryParse(value, out edgeId))
                {
                    return _edgeRepository.GetEdgeById(edgeId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetEdgeById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateEdge(Edge edge)
        {
            try
            {
                _edgeRepository.Insert(edge);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateEdge", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateEdge(Edge edge)
        {
            try
            {
                _edgeRepository.Update(edge);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateEdge", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableEdge(string value)
        {
            try
            {
                int edgeId;
                    if (Int32.TryParse(value, out edgeId))
                    {
                        _edgeRepository.Disable(edgeId);
                        return true;
                    }
                    throw new FormatException("The supplied id, is not of the datatype integer.");

            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableEdge", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region route calculation

        public bool CalculateRoute(string sloc, string eloc)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CalculateRoute", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion
    }
}