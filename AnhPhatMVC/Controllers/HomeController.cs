using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class HomeController : Controller
    {

        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        public ActionResult Index()
        {
            dynamic listModel = new ExpandoObject();
            listModel.Slides = data.slides.ToList();
            listModel.Partners = data.brands.ToList();
            return View(listModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}