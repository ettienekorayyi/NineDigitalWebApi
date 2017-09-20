using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NineDigitalWebApi.Formatter;
using Newtonsoft.Json;

namespace NineDigitalWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {  
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new CustomJsonFormatter());
        }
    }
}
