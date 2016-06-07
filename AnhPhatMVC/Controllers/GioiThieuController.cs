using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class GioiThieuController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: GioiThieu
        public ActionResult Index()
        {
            return View(data.configs.FirstOrDefault(x=>x.key=="introduce"));
        }
     
    }
}