using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
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
        public ActionResult Create(customer item)
        {
            try
            {
                data.customers.InsertOnSubmit(item);
                data.SubmitChanges();
                return RedirectToAction("Customer", "Customer");
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
        public ActionResult Edit(customer item)
        {
            try
            {
                customer _cus = data.customers.FirstOrDefault(x => x.id == item.id);
                _cus.name = item.name;
                _cus.describe_vn = item.describe_vn;
                _cus.describe_en = item.describe_en;
                _cus.image = item.image;
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