using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using Logging;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class RouteService : IRouteService
    {
        private readonly EdgeRepository _edgeRepository;
        private readonly ArchiveRepository _archiveRepository;
        private readonly ArchiveStationRepository _archiveStationRepository;
        private readonly StationRepository _stationRepository;
        public RouteService()
        {
            _edgeRepository = new EdgeRepository();
            _archiveRepository = new ArchiveRepository();
            _archiveStationRepository = new ArchiveStationRepository();
            _stationRepository = new StationRepository();
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

        public List<Station> CalculateRoute(string sLat, string sLng, string eLat, string eLng)
        {
            try
            {
                return new AStar().CalculateRoute(sLat, sLng, eLat, eLng, 250000);
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CalculateRoute", 1, WebOperationContext.Current);
                return null;
            }
        }

        #endregion

        #region archived entries

        public List<Archive> GetAllArchivedEntries()
        {
            try
            {
                return _archiveRepository.GetAllArchives().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllArchivedEntries", 1, WebOperationContext.Current);
                return null;
            }
        }

        public Archive GetArchivedEntryById(string value)
        {
            try
            {
                int archiveId;
                if (Int32.TryParse(value, out archiveId))
                {
                    return _archiveRepository.GetArchiveById(archiveId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetArchivedEntryById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateArchivedEntry(Archive archive)
        {
            try
            {
                _archiveRepository.Insert(archive);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateArchivedEntry", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region archived stations

        public List<ArchiveStation> GetAllArchivedStations()
        {
            try
            {
                return _archiveStationRepository.GetAllArchiveStations().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllArchivedStations", 1, WebOperationContext.Current);
                return null;
            }
        }

        public ArchiveStation GetArchivedStationById(string value)
        {
            try
            {
                int stationId;
                if (Int32.TryParse(value, out stationId))
                {
                    return _archiveStationRepository.GetArchiveStationById(stationId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetArchivedStationById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateArchivedStation(ArchiveStation archiveStation)
        {
            try
            {
                _archiveStationRepository.Insert(archiveStation);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateArchivedStation", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion
    }
}