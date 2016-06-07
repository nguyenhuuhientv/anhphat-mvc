﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnhPhatMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            

            routes.MapRoute(
                name: "GioiThieu",
                url: "gioi-thieu",
                defaults: new { controller = "GioiThieu", action = "Index"},
                namespaces: new[] { "AnhPhatMVC.Controllers" }
            );

            routes.MapRoute(
                name: "DichVu",
                url: "dich-vu",
                defaults: new { controller = "DichVu", action = "Index" },
                namespaces: new[] { "AnhPhatMVC.Controllers" }
            );

            routes.MapRoute(
                name: "TinTuc",
                url: "tin-tuc",
                defaults: new { controller = "TinTuc", action = "Index" },
                namespaces: new[] { "AnhPhatMVC.Controllers" }
            );

            routes.MapRoute(
                name: "KhuyenMai",
                url: "khuyen-mai",
                defaults: new { controller = "KhuyenMai", action = "Index" },
                namespaces: new[] { "AnhPhatMVC.Controllers" }
            );

            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "LienHe", action = "Index" },
                namespaces: new[] { "AnhPhatMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "AnhPhatMVC.Controllers" }
            );
        }
    }
}
