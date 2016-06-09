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
        public AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();

        [ChildActionOnly]
        public ActionResult SideBar()
        {            
            var model = data.sp_Get_Group_Product(this.getLanguageCode()).ToList();
            var productNewList = data.sp_Get_Product_New(this.getLanguageCode(), 3).ToList();

            dynamic modelDynamic = new ExpandoObject();
            modelDynamic.Groups = model;
            modelDynamic.Products = productNewList;

            ViewBag.YoutubeLink = data.configs.FirstOrDefault(x => x.key == "video_intro").value;
            ViewBag.Config_Skype = data.configs.FirstOrDefault(x => x.key == "skype").value;
            return PartialView(modelDynamic);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {

            ViewBag.Config_Description = data.configs.FirstOrDefault(x=>x.key== "description").value;
            ViewBag.Config_Facebook = data.configs.FirstOrDefault(x => x.key == "facebook").value;

            dynamic modelDynamic = new ExpandoObject();
            modelDynamic.Groups = data.sp_Get_Group_Product(this.getLanguageCode()).ToList();
            return PartialView(modelDynamic);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            ViewBag.Config_Logo = data.configs.FirstOrDefault(x => x.key == "logo").value;
            var a = data.configs.ToList();
            ViewBag.Config_Email = data.configs.FirstOrDefault(x => x.key == "email").value;
            ViewBag.Config_Phone = data.configs.FirstOrDefault(x => x.key == "phone").value;

            ViewBag.Config_Facebook = data.configs.FirstOrDefault(x => x.key == "facebook").value;
            ViewBag.Config_Gplus = data.configs.FirstOrDefault(x => x.key == "gplus").value;
            ViewBag.Config_Youtube = data.configs.FirstOrDefault(x => x.key == "youtube").value;
            ViewBag.Config_Twitter = data.configs.FirstOrDefault(x => x.key == "twitter").value;

            dynamic modelDynamic = new ExpandoObject();
            modelDynamic.Groups = data.sp_Get_Group_Product(this.getLanguageCode()).ToList();
            modelDynamic.Services = data.sp_Get_Service(this.getLanguageCode()).ToList();
            return PartialView(modelDynamic);
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
                else
                {
                    language = "vn";
                }
            }
            return language;
        }
    }
}