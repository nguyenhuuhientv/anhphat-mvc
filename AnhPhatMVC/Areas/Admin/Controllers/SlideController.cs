using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {           

                    //Save image to file
                    var filename = Guid.NewGuid().ToString() + image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/images");
              
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);
                    slide _sli = new slide();
                    _sli.image = "/Content/images/" + filename;
                    data.slides.InsertOnSubmit(_sli);
                    data.SubmitChanges();
                    return RedirectToAction("Slide", "Slide");
                }
                else
                {
                    return View();
                }
               
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {

                    //Save image to file
                    var filename = Guid.NewGuid().ToString()+image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/images");
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);
                    slide _slide = data.slides.FirstOrDefault(x => x.id == id);
                    _slide.image = "/Content/images/" + filename;
                    data.SubmitChanges();
                    return RedirectToAction("Slide", "Slide");
                }else
                {
                    return View();
                }           
                
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