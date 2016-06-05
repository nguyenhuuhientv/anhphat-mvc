using AnhPhatMVC.Context;
using AnhPhatMVC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            var model = data.sp_Get_Group_Product(this.getLanguageCode()).ToList();
            var productNewList = data.sp_Get_Product(this.getLanguageCode()).ToList();

            dynamic modelDynamic = new ExpandoObject();
            modelDynamic.Groups = model;
            modelDynamic.Products = productNewList;

            ViewBag.YoutubeLink = "https://www.youtube.com/embed/t4H_Zoh7G5A";
            return PartialView(modelDynamic);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.Config_Description = "Get cái config description show ra đi";
            ViewBag.Config_Facebook = "https://www.facebook.com/khoailangmatdalat";
        
            var model = data.sp_Get_Group_Product(this.getLanguageCode()).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            ViewBag.Config_Logo = "/Content/images/logo.jpg";

            ViewBag.Config_Email = "nguyenhuuhientv@gmail.com";
            ViewBag.Config_Phone = "0988 234 726";

            ViewBag.Config_Facebook = "https://www.facebook.com/nguyenhuuhienit";
            ViewBag.Config_Gplus = "https://plus.google.com/u/0/";
            ViewBag.Config_Youtube = "https://www.youtube.com/channel/UCj6xSt-JP_rqMiwwIgaDEeQ";
            ViewBag.Config_Twitter = "https://twitter.com/JYHeffect";

            var model = data.sp_Get_Group_Product(this.getLanguageCode()).ToList();
            return PartialView(model);
        }

        public String getLanguageCode()
        {
            HttpCookie cookieLanguage = Request.Cookies["Language"];
            string language = "vn";
            if (cookieLanguage != null)
            {
                language = cookieLanguage.Value;
                if (language != null && language == "en")
                {
                    language = "en";
                }
            }
            return language;
        }
    }
}