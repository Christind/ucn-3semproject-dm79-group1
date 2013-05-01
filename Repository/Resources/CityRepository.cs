using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class CityRepository
    {
        private BPDbContext db;

        public CityRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<City> GetAllCities()
        {
            return db.Cities;
        }

        public City GetCityById(int cityId)
        {
            return db.Cities.FirstOrDefault(x => x.CityId.Equals(cityId));
        }

        public City GetCityByName(string cityName)
        {

            return db.Cities.FirstOrDefault(x => x.CityName.Equals(cityName, StringComparison.OrdinalIgnoreCase));
        }

        public City GetCityByZipCode(int zipCode)
        {
            return db.Cities.FirstOrDefault(x => x.ZipCode.Equals(zipCode));
        }
    }
}
