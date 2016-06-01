using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Brand()
        {
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Thương hiệu";
            List<brand> _list = data.brands.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(brand item, HttpPostedFileBase image)
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
                    brand _item = new brand();
                    _item.image = "/Content/images/" + filename;
                    _item.link_action = item.link_action;
                    data.brands.InsertOnSubmit(_item);
                    data.SubmitChanges();
                    return RedirectToAction("Brand", "Brand");
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
            brand item = data.brands.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(brand item, HttpPostedFileBase image)
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
                    brand _item = data.brands.FirstOrDefault(x => x.id == item.id);
                    _item.image = "/Content/images/" + filename;
                    _item.link_action = item.link_action;
                    data.SubmitChanges();
                    return RedirectToAction("Brand", "Brand");
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
                data.brands.DeleteOnSubmit(data.brands.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Brand", "Brand");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            brand us = data.brands.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
    }
}