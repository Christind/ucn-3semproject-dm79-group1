using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Resources;
using Utils.Helpers;

namespace WebClient.Controllers
{
    public class StationMaintenanceController : Controller
    {
        private StationMaintenanceRepository _stationMaintenanceRepository;
        //
        // GET: /StationMaintenance/

        public ActionResult Index()
        {
            var stationMaintenances = JsonHelper.DeserializeJson<List<StationMaintenance>>("http://localhost:8732/get/all/mainteneance");
            return View(stationMaintenances);
        }

        //
        // GET: /StationMaintenance/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
