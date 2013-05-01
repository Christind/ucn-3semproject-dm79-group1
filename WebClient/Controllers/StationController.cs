using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Utils.Helpers;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class StationController : Controller
    {
        //
        // GET: /Station/

        public ActionResult Index()
        {
            //List<Station> stations = new List<Station>();
            //stations.Add(new Station()
            //                 {
            //                     CreatedDate = DateTime.Now,
            //                     Description = "Verdens vildste",
            //                     IsActive = true,
            //                     IsOperational = true,
            //                     StationLat = new decimal(52.11),
            //                     StationLong = new decimal(11.52),
            //                     Title = "Vildste station",
            //                     ID = 1
            //                 });
            var stations = JsonHelper.DeserializeJson<List<Station>>("http://localhost:8732/get/all/stations");
            return View(stations);
        }

        [HttpPost]
        public ViewResult LocateNearestStation(string searchValue)
        {
            try
            {
                int zipCode;
                var stations = new List<Station>();
                if(Int32.TryParse(searchValue, out zipCode))
                {
                    var city =
                        JsonHelper.DeserializeJson<City>(String.Format("http://localhost:8732/get/city/zipcode/{0}",
                                                                       searchValue));
                    var geoLocation =
                        JsonHelper.DeserializeJson<GeoCoding>(String.Format(
                                "http://maps.googleapis.com/maps/api/geocode/json?address={0},+Denmark&sensor=false",
                                city.CityName));
                    
                    //replace
                    stations = JsonHelper.DeserializeJson<List<Station>>("http://localhost:8732/get/all/stations").Where(x => x.Title.Equals(city.CityName)).ToList();
                }
                else
                {
                    var geoLocation =
                        JsonHelper.DeserializeJson<GeoCoding>(String.Format(
                                "http://maps.googleapis.com/maps/api/geocode/json?address={0},+Denmark&sensor=false",
                                searchValue));
                    stations = JsonHelper.DeserializeJson<List<Station>>("http://localhost:8732/get/all/stations").Where(x => x.Title.Equals(searchValue)).ToList();
                }
               
                return View("Index", stations);
            }
            catch
            {
                throw;
            }
        }

        //
        // GET: /Station/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
