using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RouteAPI.Services.Interfaces;

namespace RouteAPI.Services
{
    public class StationService : IStationService
    {
        private StationRepository stationRepo;

        public StationService()
        {
            stationRepo = new StationRepository();
        }

        public List<Station> GetAllStations()
        {
            return stationRepo.GetAllStations().ToList();
        }

        public Station GetStationById(int id)
        {
            return stationRepo.GetStationById(id);
        }
    }
}
