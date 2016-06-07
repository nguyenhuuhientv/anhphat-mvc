using System;
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
                "GioiThieu",
                "{gioi-thieu}",
                new { controller = "GioiThieu", action = "Index" }
            );

            routes.MapRoute(
                "DichVu",
                "{dich-vu}",
                new { controller = "DichVu", action = "Index" }
            );

            routes.MapRoute(
                "TinTuc",
                "{tin-tuc}",
                new { controller = "TinTuc", action = "Index" }
            );

            routes.MapRoute(
                "KhuyenMai",
                "{khuyen-mai}",
                new { controller = "SanPham", action = "KhuyenMai" }
            );

            routes.MapRoute(
                "LienHe",
                "{lien-he}",
                new { controller = "LienHe", action = "Index" }
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
