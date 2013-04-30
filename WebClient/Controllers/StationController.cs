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
            var stations = JsonHelper.DeserializeJson<JsonCollectionWrapper<Station>>("http://localhost:8732/get/all/stations");
            return View(stations);
        }

        //
        // GET: /Station/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
