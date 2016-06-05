using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Admin/Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KiemTra(ActionResult view)
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp != null && !temp.Equals(""))
                return RedirectToAction("Index", "Admin");
            else
                return view;
        }
        public ActionResult KiemTraDaDangNhap(ActionResult view)
        {
            try
            {
                String temp = "";
                try
                {
                    temp = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
                }
                catch { }
                if (temp != null && !temp.Equals(""))
                    return view;
                else
                    return RedirectToAction("Login", "Account");
            }
            catch
            {
                return view;
            }
        }
        public string convertToUnSign(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD)).Replace(" ", "-").ToLower(); 
        }
    }
}