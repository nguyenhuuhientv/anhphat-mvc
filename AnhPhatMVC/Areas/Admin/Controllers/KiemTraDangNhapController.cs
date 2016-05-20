using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class KiemTraDangNhapController : Controller
    {
        // GET: Admin/KiemTraDangNhap
        public ActionResult Index()
        {
            return View();
        }
        public bool KiemTra()
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }catch { }
            if (temp != null && !temp.Equals(""))
                return true;
            else
                return false;
        }
    }
}