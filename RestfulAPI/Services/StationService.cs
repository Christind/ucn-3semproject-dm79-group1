using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class StationService : IStationService
    {
        private StationRepository stationRepo;
        private BatteryStorageRepository batteryStorageRepo;
        public StationService()
        {
            stationRepo = new StationRepository();
            batteryStorageRepo = new BatteryStorageRepository();
        }

        public List<Station> GetAllStations()
        {
            return stationRepo.GetAllStations().ToList();
        }

        public Station GetStationById(int id)
        {
            return stationRepo.GetStationById(id);
        }

        public bool ReserveBattery(int stationId, int userId)
        {
            var userRepo = new UserRepository();
            var reservationRepo = new ReservationRepository();
            var batteryRepo = new BatteryRepository();
            var station = stationRepo.GetStationById(stationId);
            var user = userRepo.GetUserById(userId);
            if (user == null || station == null)
                return false;

            bool isBatteryAvail = station.BatteryStorages.Available > 0;
            if(isBatteryAvail)
            {
                var batteryCollection = station.BatteryStorages.BatteryCollections.FirstOrDefault(x => x.Battery.Status == 1);
                if(batteryCollection != null)
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
