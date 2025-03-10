﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );

            routes.MapRoute(
            name: "Conversaciones",
            url: "Conversaciones",
            defaults: new { controller = "Conversaciones", action = "Index" }
            );

            routes.MapRoute(
            name: "Chat",
            url: "Conversaciones/Chat/{id}",
            defaults: new { controller = "Mensajes", action = "Chat", id = UrlParameter.Optional }
            );
        }
    }
}
