using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.BetterPlaceAPIRef;

//using WebClient.RouteServiceReference;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Index/
        BetterPlaceAPIRef.IUserService userService = new UserServiceClient();
        public ActionResult Index()
        {
            //IRouteService routeService = new RouteServiceClient();
            //var user = routeService.GetUserById(1);
            string users ="";
            users = userService.GetAllUsers().Aggregate(users, (current, user) => current + user.UserName);
            ViewBag.Users = users;
            return View();
        }

    }
}
