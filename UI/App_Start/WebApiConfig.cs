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
            // ✅ Habilitar CORS para aceptar solicitudes externas
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Configurar rutas de atributos
            config.MapHttpAttributeRoutes();

            // Configurar rutas por defecto
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configurar Unity como el resolver de dependencias
            var container = UnityConfig.Container;
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Agregar manejo de errores global
            config.Filters.Add(new GlobalExceptionHandler());
        }

    }
}
