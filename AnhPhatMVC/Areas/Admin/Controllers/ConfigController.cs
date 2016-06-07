using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class ConfigController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Config
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Config()
        {
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Cấu hình";
            List<config> list_group = data.configs.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(list_group));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        public ActionResult Create(config item)
        {
            try
            {
                data.configs.InsertOnSubmit(item);
                data.SubmitChanges();
                return RedirectToAction("Config", "Config");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            config us = data.configs.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(config item, HttpPostedFileBase image)
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
                    config _item = data.configs.FirstOrDefault(x => x.id == item.id);
                    _item.value = "/Content/images/" + filename;                  
                    data.SubmitChanges();
                    return RedirectToAction("Config", "Config");
                }
                else
                {
                    config _config = data.configs.FirstOrDefault(x => x.id == item.id);
                    _config.value = item.value;
                    data.SubmitChanges();
                    return RedirectToAction("Config", "Config");
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
                data.configs.DeleteOnSubmit(data.configs.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Config", "Config");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            config us = data.configs.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }

    }
}