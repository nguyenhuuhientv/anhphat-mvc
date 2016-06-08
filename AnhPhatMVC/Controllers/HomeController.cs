using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class HomeController : AnhPhatController
    {
       
        public ActionResult Index()
        {
            dynamic listModel = new ExpandoObject();
            listModel.Slides = data.slides.ToList();
            listModel.Partners = data.brands.ToList();
            listModel.ProductHot = data.sp_Get_Product_Highlight(this.getLanguageCode(), 6).ToList();
            listModel.Services = data.sp_Get_Service(this.getLanguageCode()).ToList();

            listModel.NewFirst = data.sp_Get_New_Limit(this.getLanguageCode(), true, 1).FirstOrDefault();
            listModel.News = data.sp_Get_New_Limit(this.getLanguageCode(), true, 3).ToList();
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