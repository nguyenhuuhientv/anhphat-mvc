using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            bool temp = new KiemTraDangNhapController().KiemTra();
            if (temp)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }       
    }
}