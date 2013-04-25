using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class StationService : IStationService
    {
        private readonly StationRepository _stationRepository;
        private readonly StationMaintenanceRepository _stationMaintenanceRepository;
        private readonly MaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly BatteryRepository _batteryRepository;


        public StationService()
        {
            _stationRepository = new StationRepository();
            _stationMaintenanceRepository = new StationMaintenanceRepository();
            _maintenanceTypeRepository = new MaintenanceTypeRepository();
            _batteryRepository = new BatteryRepository();
        }

        #region Station

        public List<Station> GetAllStations()
        {
            return _stationRepository.GetAllStations().ToList();
        }

        public Station GetStationById(string id)
        {
            return _stationRepository.GetStationById(Convert.ToInt32(id));
        }

        public bool ReserveBattery(string stationId, string userId)
        {
            var userRepo = new UserRepository();
            var reservationRepo = new ReservationRepository();
            var batteryRepo = new BatteryRepository();
            var station = _stationRepository.GetStationById(Convert.ToInt32(stationId), true);
            var user = userRepo.GetUserById(Convert.ToInt32(userId));

            if (user == null || station == null)
                return false;

            var isBatteryAvailable = station.BatteryStorages.Available > 0;
            if (isBatteryAvailable)
            {
                var batteryCollection =
                    station.BatteryStorages.BatteryCollections.FirstOrDefault(x => x.Battery.Status == 1);
                if (batteryCollection != null)
                {
                    var battery = batteryCollection.Battery;
                    battery.Status = 3;

                    var reservation = new Reservation
                    {
                        UserId = user.ID,
                        StationId = station.ID,
                        CreatedDate = DateTime.Now,
                        ExpiredDate = DateTime.Now.AddDays(1),
                        IsActive = true
                    };

                    reservationRepo.Insert(reservation);
                    batteryRepo.Update(battery);
                }
            }

            return false;
        }

        #endregion

        #region StationMaintenance

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

        #endregion

        #region MaintenanceType

        public List<MaintenanceType> GetAllMaintenanceTypes()
        {
            return _maintenanceTypeRepository.GetAllMaintenanceTypes().ToList();
        }

        public MaintenanceType GetMaintenanceTypeById(string id)
        {
            return _maintenanceTypeRepository.GetMaintenanceTypeById(Convert.ToInt32(id));
        }

        public bool EditMaintenanceType(MaintenanceType maintenanceType)
        {
            try
            {
                if (maintenanceType == null)
                    return false;

                _maintenanceTypeRepository.Update(maintenanceType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertMaintenanceType(MaintenanceType maintenanceType)
        {
            try
            {
                if (maintenanceType == null)
                    return false;

                _maintenanceTypeRepository.Insert(maintenanceType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Battery

        public List<Battery> GetAllBatteries()
        {
            return _batteryRepository.GetAllBatteries().ToList();
        }

        public Battery GetBatteryById(string id)
        {
            return _batteryRepository.GetBatteryById(Convert.ToInt32(id));
        }

        public List<Battery> GetBatteriesByStatus(string status)
        {
            var batteryList = _batteryRepository.GetAllBatteries().ToList();
            return batteryList.Where(battery => battery.Status == (Convert.ToInt32(status))).ToList();
        }

        public bool EditBattery(Battery battery)
        {
            try
            {
                if (battery == null)
                    return false;

                _batteryRepository.Update(battery);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertBattery(Battery battery)
        {
            try
            {
                if (battery == null)
                    return false;

                _batteryRepository.Insert(battery);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}