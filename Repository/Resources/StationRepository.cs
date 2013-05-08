using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class StationRepository
    {
        private BPDbContext db;
        private BatteryStorageRepository _batteryStorageRepo;
        private EdgeRepository _edgeRepository;
        public StationRepository()
        {
            db = new BPDbContext();
            _batteryStorageRepo = new BatteryStorageRepository();
            _edgeRepository = new EdgeRepository();
        }

        public IQueryable<Station> GetAllStations()
        {
            return db.Stations;
        }

        public Station GetStationById(int value, bool getAssociations = false)
        {
            Station station = db.Stations.FirstOrDefault(x => x.ID == value);
            if (station == null)
                return null;

            if (getAssociations)
            {
                station.BatteryStorages = _batteryStorageRepo.GetBatteryStorageByStationId(station.ID, true);
                station.Edges = _edgeRepository.GetEdgesByStation(station).ToList();
                //station.StationType = _stationTypeRepo.GetStationTypeById(station.TypeId);
                //station.Reservations = _reservationRepo.GetReservationsByStationId(station.ID).ToList();
                //station.StationMaintenances = _maintenanceRepo.GetStationMaintenancesByStationId(station.ID).ToList();
            }

            return station;
        }

        public void Insert(Station station)
        {
            db.Stations.Add(station);
            db.SaveChanges();
        }

        public void Update(Station station)
        {
            Station rStation = GetStationById(station.ID);

            if (rStation == null)
                return;

            rStation.Title = station.Title;
            rStation.Description = station.Description;
            rStation.StationLat = station.StationLat;
            rStation.StationLong = station.StationLong;
            rStation.IsActive = station.IsActive;
            rStation.IsOperational = station.IsOperational;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            Station rStation = GetStationById(value);

            if (rStation == null)
                return;

            rStation.IsActive = false;
            db.SaveChanges();
        }
    }
}