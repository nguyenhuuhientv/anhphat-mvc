using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.IO;
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
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Dịch vụ";
            List<service> _list = data.services.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(service item, HttpPostedFileBase image)
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
                    service _item = new service();
                    _item.image = "/Content/images/" + filename;
                    _item.caption_vn = item.caption_vn;
                    _item.caption_en = item.caption_en;
                    _item.detail_vn = item.detail_vn;
                    _item.detail_en = item.detail_en;
                    _item.describe_vn = item.describe_vn;
                    _item.describe_en = item.describe_en;
                    _item.link = new ManagerController().convertToUnSign(item.caption_vn);
                    data.services.InsertOnSubmit(_item);
                    data.SubmitChanges();
                    return RedirectToAction("Service", "Service");
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
            service item = data.services.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(service item, HttpPostedFileBase image)
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
                    service _item = data.services.FirstOrDefault(x=>x.id == item.id);
                    _item.image = "/Content/images/" + filename;
                    _item.caption_vn = item.caption_vn;
                    _item.caption_en = item.caption_en;
                    _item.detail_vn = item.detail_vn;
                    _item.detail_en = item.detail_en;
                    _item.describe_vn = item.describe_vn;
                    _item.describe_en = item.describe_en;
                    _item.link = new ManagerController().convertToUnSign(item.caption_vn);
                    data.SubmitChanges();
                    return RedirectToAction("Service", "Service");
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