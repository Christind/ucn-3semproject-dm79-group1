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

        #region station

        public List<Station> GetAllStations()
        {
            try
            {
                return _stationRepository.GetAllStations().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllStations", 1, WebOperationContext.Current);
                return null;
            }
        }

        public Station GetStationById(string value)
        {
            try
            {
                int stationId;
                if (Int32.TryParse(value, out stationId))
                {
                    return _stationRepository.GetStationById(stationId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetStationById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateStation(Station station)
        {
            try
            {
                _stationRepository.Insert(station);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateStation", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateStation(Station station)
        {
            try
            {
                _stationRepository.Update(station);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateStation", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableStation(string value)
        {
            try
            {
                int stationId;
                if (Int32.TryParse(value, out stationId))
                {
                    _stationRepository.Disable(stationId);
                    return true;
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableStation", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region station maintenances

        public List<StationMaintenance> GetAllStationMaintenances()
        {
            try
            {
                return _stationMaintenanceRepository.GetAllStationMaintenances().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllStationMaintenances", 1, WebOperationContext.Current);
                return null;
            }
        }

        public StationMaintenance GetStationMaintenanceById(string value)
        {
            try
            {
                int maintenanceId;
                if (Int32.TryParse(value, out maintenanceId))
                {
                    return _stationMaintenanceRepository.GetStationMaintenanceById(maintenanceId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetStationMaintenanceById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateStationMaintenance(StationMaintenance stationMaintenance)
        {
            try
            {
                _stationMaintenanceRepository.Insert(stationMaintenance);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateStationMaintenance", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateStationMaintenance(StationMaintenance stationMaintenance)
        {
            try
            {
                _stationMaintenanceRepository.Update(stationMaintenance);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateStationMaintenance", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableStationMainteneance(string value)
        {
            try
            {
                int mainteneanceId;
                if (Int32.TryParse(value, out mainteneanceId))
                {
                    _stationMaintenanceRepository.Disable(mainteneanceId);
                    return true;
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableStationMainteneance", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region maintenances types

        public List<MaintenanceType> GetAllMaintenanceTypes()
        {
            try
            {
                return _maintenanceTypeRepository.GetAllMaintenanceTypes().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllMaintenanceTypes", 1, WebOperationContext.Current);
                return null;
            }
        }

        public MaintenanceType GetMaintenanceTypeById(string value)
        {
            try
            {
                int typeId;
                if (Int32.TryParse(value, out typeId))
                {
                    return _maintenanceTypeRepository.GetMaintenanceTypeById(typeId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetMaintenanceTypeById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateMaintenanceType(MaintenanceType maintenanceType)
        {
            try
            {
                _maintenanceTypeRepository.Insert(maintenanceType);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateMaintenanceType", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateMaintenanceType(MaintenanceType maintenanceType)
        {
            try
            {
                _maintenanceTypeRepository.Update(maintenanceType);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateMaintenanceType", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableMaintenanceType(string value)
        {
            try
            {
                int typeId;
                if (Int32.TryParse(value, out typeId))
                {
                    _maintenanceTypeRepository.Disable(typeId);
                    return true;
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableMaintenanceType", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion

        #region battery

        public List<Battery> GetAllBatteries()
        {
            try
            {
                return _batteryRepository.GetAllBatteries().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllBatteries", 1, WebOperationContext.Current);
                return null;
            }
        }

        public Battery GetBatteryById(string value)
        {
            try
            {
                int batteryId;
                if (Int32.TryParse(value, out batteryId))
                {
                    return _batteryRepository.GetBatteryById(batteryId);
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBatteryById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public List<Battery> GetBatteriesByStatus(string value)
        {
            try
            {
                int statusValue;
                if (Int32.TryParse(value, out statusValue))
                {
                    var batteryList = _batteryRepository.GetAllBatteries().ToList();
                    return batteryList.Where(battery => battery.Status == (Convert.ToInt32(statusValue))).ToList();
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBatteriesByStatus", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool ReserveBattery(string stationValue, string userValue)
        {
            var userRepo = new UserRepository();
            var reservationRepo = new ReservationRepository();
            var batteryRepo = new BatteryRepository();
            var station = _stationRepository.GetStationById(Convert.ToInt32(stationValue), true);
            var user = userRepo.GetUserById(Convert.ToInt32(userValue));

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

        public bool CreateBattery(Battery battery)
        {
            try
            {
                _batteryRepository.Insert(battery);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "CreateBattery", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool UpdateBattery(Battery battery)
        {
            try
            {
                _batteryRepository.Update(battery);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "UpdateBattery", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DisableBattery(string value)
        {
            try
            {
                int batteryId;
                if (Int32.TryParse(value, out batteryId))
                {
                    _batteryRepository.Disable(batteryId);
                    return true;
                }
                throw new FormatException("The supplied id, is not of the datatype integer.");
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "DisableBattery", 1, WebOperationContext.Current);
                return false;
            }
        }

        #endregion
    }
}
