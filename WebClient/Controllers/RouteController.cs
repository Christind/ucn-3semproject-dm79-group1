using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Repository.Models;
using Utils.Helpers;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class RouteController : Controller
    {
        //
        // GET: /Route/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CalculateRoute(string fromValue, string toValue)
        {
            try
            {
                var stationVertices = new List<Station>();

                var fromLocation = JsonHelper.DeserializeJson<GeoCoding>(String.Format(
                    "http://maps.googleapis.com/maps/api/geocode/json?address={0},+Denmark&sensor=false",
                    fromValue));

                var endLocation = JsonHelper.DeserializeJson<GeoCoding>(String.Format(
                    "http://maps.googleapis.com/maps/api/geocode/json?address={0},+Denmark&sensor=false",
                    toValue));

                var vertex = JsonHelper.DeserializeJson<Station>(String.Format(
                    "http://localhost:8732/calculate/from/{0}@{1}/to/{2}@{3}",
                    fromLocation.results.First().geometry.location.lat,
                    fromLocation.results.First().geometry.location.lng,
                    endLocation.results.First().geometry.location.lat,
                    endLocation.results.First().geometry.location.lng));

                stationVertices.Add(vertex);

                return View("Index", stationVertices);
            }
            catch
            {
                throw;
            }
        }
    }
}