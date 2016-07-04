using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class GioiThieuController : AnhPhatController
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: GioiThieu
        public ActionResult Index()
        {
            if (this.getLanguageCode() == "vn")
            {
                return View(data.configs.FirstOrDefault(x => x.key == "introduce"));
            } else
            {
                return View(data.configs.FirstOrDefault(x=>x.key=="introduce_en"));
            }
            
        }
     
    }
}