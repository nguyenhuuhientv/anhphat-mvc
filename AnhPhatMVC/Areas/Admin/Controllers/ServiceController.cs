using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service()
        {
            List<service> _list = data.services.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        public ActionResult Create(service item)
        {
            try
            {                  
                data.services.InsertOnSubmit(item);
                data.SubmitChanges();
                return RedirectToAction("Service", "Service");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            service item = data.services.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        public ActionResult Edit(service item)
        {
            try
            {
                service _newt = data.services.FirstOrDefault(x => x.id == item.id);
                _newt.caption_vn = item.caption_vn;
                _newt.caption_en = item.caption_en;
                _newt.detail_vn = item.detail_vn;
                _newt.detail_en = item.detail_en;              
                _newt.describe_vn = item.describe_vn;
                _newt.describe_en = item.describe_en;
                _newt.image = item.image;
                data.SubmitChanges();
                return RedirectToAction("Service", "Service");
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
                temp = System.Web.HttpContext.Current.Session["TaiKhoan"].ToString();
            }
            catch { }
            if (temp != null && !temp.Equals(""))
            {
                data.services.DeleteOnSubmit(data.services.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Service", "Service");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            service us = data.services.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
    }
}