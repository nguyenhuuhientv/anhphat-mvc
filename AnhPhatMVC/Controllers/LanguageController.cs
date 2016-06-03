using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(String LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}