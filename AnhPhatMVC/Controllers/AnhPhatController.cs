using AnhPhatMVC.Context;
using AnhPhatMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class AnhPhatController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: AnhPhat
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SideBar()
        {
            var language = Request.Cookies["Language"].Value;
            if (language == "vi")
            {
                language = "vn";
            } else
            {
                language = "en";
            }
            var model = data.sp_Get_Group_Product(language).ToList();
            return PartialView(model);
        }
    }
}