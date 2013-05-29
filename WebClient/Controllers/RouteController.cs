using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        public ViewResult CalculateRoute(string fromValue, string toValue, string maxRange)
        {
            try
            {
                var fromLocation = JsonHelper.DeserializeJson<GeoCoding>(String.Format(
                    "http://maps.googleapis.com/maps/api/geocode/json?address={0},+Denmark&sensor=false",
                    fromValue));

                var endLocation = JsonHelper.DeserializeJson<GeoCoding>(String.Format(
                    "http://maps.googleapis.com/maps/api/geocode/json?address={0},+Denmark&sensor=false",
                    toValue));

                var vertices = JsonHelper.DeserializeJson<List<Station>>(String.Format(
                    "http://localhost:8732/calculate/from/{0}@{1}/to/{2}@{3}/maxRange/{4}",
                    fromLocation.results.First().geometry.location.lat,
                    fromLocation.results.First().geometry.location.lng,
                    endLocation.results.First().geometry.location.lat,
                    endLocation.results.First().geometry.location.lng, 
                    maxRange));

                if (vertices == null)
                {
                    ViewBag.ErrorMessage = "Vi kunne desværre ikke planlægge en rute med den angivede rækkevidde. Dette kan enten skyldes der ikke er nok ledige batterier på de enkelte stationer, eller det ikke er muligt at finde stationer indenfor den angivet rækkevidde";
                    return View("Index");
                }

                TempData["Stations"] = vertices;

                return View("Index", vertices);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public ViewResult Reserve()
        {
            try
            {
                var stations = TempData["Stations"] as List<Station>;
                string jsonStations = JsonHelper.SerializeJson<List<Station>>(stations);

                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create("http://localhost:8732/reserve/batteries");

                UTF8Encoding encoding = new UTF8Encoding();
                string postData = "{\"Stations\": " + jsonStations;
                postData += ", \"User\": \"" + User.Identity.Name + "\" }";
                byte[] data = encoding.GetBytes(postData);

                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json; charset=utf-8";
                httpWReq.ContentLength = data.Length;

                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


                return View("Index", stations);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}