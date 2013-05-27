using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Resources;
using Utils.Helpers;

namespace RestfulAPI.Resources
{
    public class ReserveBatteries
    {
        private readonly List<Station> _stations;
        private User _user;
        
        public ReserveBatteries(ReserveModel model)
        {
            List<Station> stations = JsonHelper.DeserializeJson<List<Station>>(model.Stations, true);
            UserRepository userRepository = new UserRepository();
            _user = userRepository.GetUserByUserName(model.User);
            _stations = stations;
        }

        public bool Reserve()
        {
            var batteryStorageRepo = new BatteryStorageRepository();

            var reservations = new List<Reservation>();
            var batteries = new List<Battery>();
            foreach (var station in _stations)
            {
                station.BatteryStorages = batteryStorageRepo.GetBatteryStorageByStationId(station.ID, true);
                if (station.BatteryStorages != null && station.BatteryStorages.Available > 0)
                {
                    var batteryCollection =
                        station.BatteryStorages.BatteryCollections.FirstOrDefault(x => x.Battery.Status.Equals(1));
                    if (batteryCollection != null)
                    {
                        batteryCollection.Battery.Status = 2;
                        var reservation = new Reservation
                                              {
                                                  CreatedDate = DateTime.Now,
                                                  ExpiredDate = DateTime.Now.AddMinutes(10),
                                                  IsActive = true,
                                                  Station = station,
                                                  StationId = station.ID,
                                                  User = _user,
                                                  UserId = _user.ID
                                              };

                        batteries.Add(batteryCollection.Battery);
                        reservations.Add(reservation);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            UpdateBatteries(batteries);
            InsertReservations(reservations);

            return true;
        }

        private void UpdateBatteries(IEnumerable<Battery> batteries)
        {
            var batteryRepo = new BatteryRepository();
            foreach (var battery in batteries)
            {
                batteryRepo.Update(battery);
            }
        }

        private void InsertReservations(IEnumerable<Reservation> reservations)
        {
            var resovationRepo = new ReservationRepository(); 
            foreach (var reservation in reservations)
            {
                resovationRepo.Insert(reservation);
            }
        }
    }
}
