using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class TinTucController : AnhPhatController
    {
        // GET: TinTuc
        public ActionResult Index()
        {
            dynamic modelDynamic = new ExpandoObject();
            modelDynamic.News = data.sp_Get_New(this.getLanguageCode(), true).ToList();
            return View(modelDynamic);
        }

        public new ActionResult View(string link)
        {
            dynamic Model = new Object();
            Model = data.sp_Get_New_Item(this.getLanguageCode(), true, link).FirstOrDefault();
            return View(Model);
        }
    }
}