using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class DichVuController : AnhPhatController
    {
        // GET: DichVu
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult View(string link)
        {
            dynamic Model = new Object();
            Model = data.sp_Get_Service_Item(this.getLanguageCode(), link).FirstOrDefault();
            return View(Model);
        }
    }
}