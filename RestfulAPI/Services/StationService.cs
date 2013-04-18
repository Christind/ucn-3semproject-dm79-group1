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
        private StationRepository _stationRepository;

        public StationService()
        {
            _stationRepository = new StationRepository();
        }

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
            var station = _stationRepository.GetStationById(Convert.ToInt32(stationId));
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
                            Station = station,
                            User = user,
                            UserId = user.ID,
                            StationId = station.ID,
                            CreatedDate = DateTime.Now,
                            ExpiredDate = DateTime.Now.AddDays(1)
                        };

                    reservationRepo.Insert(reservation);
                    batteryRepo.Update(battery);
                }
            }

            return false;
        }
    }
}