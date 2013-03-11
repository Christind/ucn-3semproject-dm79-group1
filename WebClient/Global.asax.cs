﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebClient
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            Exception newException = HttpContext.Current.Server.GetLastError();
            if (newException != null)
            {
                Exception ex = newException.GetBaseException();
                if (ex.GetType() == typeof(HttpException))
                {
                    HttpException httpException = (HttpException)ex;
                    if (httpException.GetHttpCode() == 404)
                    {
                        Response.Redirect("~/PageNotFound");
                    }
                }
            }
        }
    }
}