using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class StationRepository
    {
        private BPDbContext db;

        public StationRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Station> GetAllStations()
        {
            return db.Stations;
        }

        public Station GetStationById(int value)
        {
            return db.Stations.FirstOrDefault(x => x.ID == value);
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