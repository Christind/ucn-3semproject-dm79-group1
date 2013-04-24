using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class BatteryService : IBatteryService
    {
        private readonly BatteryRepository _batteryRepository;

        public BatteryService()
        {
            _batteryRepository = new BatteryRepository();
        }

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
    }
}