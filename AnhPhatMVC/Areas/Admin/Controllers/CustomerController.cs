using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer()
        {
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Khách hàng tiêu biểu";
            List<customer> _list = data.customers.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(customer item, HttpPostedFileBase image)
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
                    customer _item = new customer();
                    _item.image = "/Content/images/" + filename;
                    _item.name = item.name;
                    _item.describe_vn = item.describe_vn;
                    _item.describe_en = item.describe_en;
                    data.customers.InsertOnSubmit(_item);
                    data.SubmitChanges();
                    return RedirectToAction("Customer", "Customer");
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
            customer item = data.customers.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(customer item, HttpPostedFileBase image)
        {
            try
            {
                String _image = data.customers.FirstOrDefault(x => x.id == item.id).image;
                if (image != null)
                {

                    //Save image to file
                    var filename = Guid.NewGuid().ToString() + image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/images");
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);
                    _image = "/Content/images/" + filename;
                }
                customer _item = data.customers.FirstOrDefault(x => x.id == item.id);
                _item.image = _image;
                _item.name = item.name;
                _item.describe_vn = item.describe_vn;
                _item.describe_en = item.describe_en;
                data.SubmitChanges();
                return RedirectToAction("Customer", "Customer");

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
                data.customers.DeleteOnSubmit(data.customers.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Customer", "Customer");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            customer us = data.customers.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
    }
}