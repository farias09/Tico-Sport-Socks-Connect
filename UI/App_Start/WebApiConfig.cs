using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using UI.App_Start;
using Unity;
using Unity.WebApi;
using System.Web.Http.Cors;

namespace UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = UnityConfig.Container;
            config.DependencyResolver = new UnityDependencyResolver(container);

            config.Filters.Add(new GlobalExceptionHandler());
        }

    }
}
