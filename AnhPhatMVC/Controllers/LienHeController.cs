using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class LienHeController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: LienHe
        public ActionResult Index()
        {
            return View(data.configs.FirstOrDefault(x => x.key == "contact"));
        }
    }
}