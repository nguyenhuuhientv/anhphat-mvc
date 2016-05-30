using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Slide
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slide()
        {
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Slide";
            List<slide> _list = data.slides.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        public ActionResult Create(slide item)
        {
            try
            {
                data.slides.InsertOnSubmit(item);
                data.SubmitChanges();
                return RedirectToAction("Slide", "Slide");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            slide item = data.slides.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        public ActionResult Edit(slide item)
        {
            try
            {
                slide _slide = data.slides.FirstOrDefault(x => x.id == item.id);
                _slide.image = item.image;
                data.SubmitChanges();
                return RedirectToAction("Slide", "Slide");
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
                data.slides.DeleteOnSubmit(data.slides.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Slide", "Slide");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            slide us = data.slides.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
    }
}