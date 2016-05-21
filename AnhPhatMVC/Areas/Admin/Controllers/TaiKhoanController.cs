using AnhPhatMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        DataClassesDataContext data = new DataClassesDataContext();
        public ActionResult Index()
        {
            var temp_data = data.TAIKHOANs.ToList();
            
            bool temp = new KiemTraDangNhapController().KiemTra();
            if (temp)
                return View(temp_data);
            else
                return RedirectToAction("Login", "Account");
        }
        public ActionResult ListBookModel()
        {
            var temp = data.TAIKHOANs.ToList();
            return View(temp);
        }
    }
}