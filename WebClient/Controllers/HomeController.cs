using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.RouteServiceReference;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            IRouteService routeService = new RouteServiceClient();
            var user = routeService.GetUserById(1);
            return View();
        }

    }
}
