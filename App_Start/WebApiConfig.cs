using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Test_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Routing per attributi
            config.MapHttpAttributeRoutes();

            // Route di fallback: api/{controller}/{id}
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // JSON di default (camelCase) e niente XML
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
