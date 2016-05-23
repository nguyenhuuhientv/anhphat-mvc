using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        public ActionResult Index()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        public ActionResult QuanLyTaiKhoan()
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["Quyen"].ToString();
            }
            catch { }
            if (!temp.Equals("0"))
                return RedirectToAction("Index", "Admin");

            String temp_TK = "";
            try
            {
                temp_TK = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp != null && !temp.Equals(""))
            {
                var list = data.users.Where(x => x.role != 0).ToList();
                return View(list);
            }
            else
                return RedirectToAction("Login", "Account");
        }

        public ActionResult Create()
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["Quyen"].ToString();
            }
            catch { }
            if (!temp.Equals("0"))
                return RedirectToAction("Index", "Admin");
            String temp_TK = "";
            try
            {
                temp_TK = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp_TK != null && !temp_TK.Equals(""))
            {
                return View();
            }
            else
                return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Create(user item)
        {
            try
            {
                user _user = new user();
                _user.updated_at = DateTime.Now;
                _user.created_at = DateTime.Now;
                _user.username = item.username;
                _user.password = item.password;
                _user.email = item.email;
                _user.birthday = item.birthday;
                _user.role = item.role;           
                data.users.InsertOnSubmit(_user);
                data.SubmitChanges();
                return RedirectToAction("QuanLyTaiKhoan", "Admin");

            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["Quyen"].ToString();
            }
            catch { }
            if (!temp.Equals("0"))
                return RedirectToAction("Index", "Admin");
            String temp_TK = "";
            try
            {
                temp_TK = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp_TK != null && !temp_TK.Equals(""))
            {
                user us = data.users.FirstOrDefault(x => x.id == id);
                return View(us);
            }
            else
                return RedirectToAction("Login", "Account");
        }
        
        [HttpPost]
        public ActionResult Edit(user item)
        {
            try
            {
                user _user = data.users.FirstOrDefault(x => x.id == item.id);
                _user.updated_at = DateTime.Now;
                _user.username = item.username;
                _user.password = item.password;
                _user.email = item.email;
                _user.birthday = item.birthday;
                _user.role = item.role;
                data.SubmitChanges();
                return RedirectToAction("QuanLyTaiKhoan", "Admin");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["Quyen"].ToString();
            }
            catch { }
            if (!temp.Equals("0"))
                return RedirectToAction("Index", "Admin");
            String temp_TK = "";
            try
            {
                temp_TK = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp_TK != null && !temp_TK.Equals(""))
            {
                data.users.DeleteOnSubmit(data.users.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("QuanLyTaiKhoan", "Admin");
            }
            else
                return RedirectToAction("Login", "Account");
          
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            String temp = "";
            try
            {
                temp = System.Web.HttpContext.Current.Session["Quyen"].ToString();
            }
            catch { }
            if (!temp.Equals("0"))
                return RedirectToAction("Index", "Admin");
            String temp_TK = "";
            try
            {
                temp_TK = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp_TK != null && !temp_TK.Equals(""))
            {
                user us = data.users.FirstOrDefault(x => x.id == id);
                return View(us);
            }
            else
                return RedirectToAction("Login", "Account");
        }
    }
}