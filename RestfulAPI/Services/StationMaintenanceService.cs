using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class StationMaintenanceService : IStationMaintenanceService
    {
        private StationMaintenanceRepository _stationMaintenanceRepository;

        public StationMaintenanceService()
        {
            _stationMaintenanceRepository = new StationMaintenanceRepository();
        }

        public List<StationMaintenance> GetAllStationMaintenances()
        {
            return _stationMaintenanceRepository.GetAllStationMaintenances().ToList();
        }

        public StationMaintenance GetStationMaintenanceById(string id)
        {
            return _stationMaintenanceRepository.GetStationMaintenanceById(Convert.ToInt32(id));
        }

        public bool EditStationMaintenance(StationMaintenance stationMaintenance)
        {
            try
            {
                if (stationMaintenance == null)
                    return false;

                _stationMaintenanceRepository.Update(stationMaintenance);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertStationMaintenance(StationMaintenance stationStationMaintenance)
        {
            try
            {
                if (stationStationMaintenance == null)
                    return false;

                _stationMaintenanceRepository.Insert(stationStationMaintenance);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
