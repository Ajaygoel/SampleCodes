using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace AvnonDemo.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes

            config.Routes.MapHttpRoute("ActionApi",
              "api/{controller}/{action}",
              null,
              new { action = @"[a-zA-Z]+" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, action = "Default" }
            );
            
        }
    }
}
