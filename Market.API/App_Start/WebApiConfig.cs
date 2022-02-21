using Market.API.Filters;
using Market.Common.Contract;
using Market.Common.Helpers;
using System.Web.Http;

namespace Market.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new GlobalExceptionFilter(new SimpleLogger() ));
            // Web API configuration and services

            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
        }
    }
}
