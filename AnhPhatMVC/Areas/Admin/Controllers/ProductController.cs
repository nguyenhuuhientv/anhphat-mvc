using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Sản phẩm";
            List<product> _list = data.products.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        public ActionResult Create(product item)
        {
            try
            {
                data.products.InsertOnSubmit(item);
                data.SubmitChanges();
                return RedirectToAction("Product", "Product");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            product item = data.products.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        public ActionResult Edit(product item)
        {
            try
            {
                product _product = data.products.FirstOrDefault(x => x.id == item.id);               
                _product.caption_vn = item.caption_vn;
                _product.caption_en = item.caption_en;
                _product.describe_vn = item.describe_vn;
                _product.describe_en = item.describe_en;
                _product.detail_vn = item.detail_vn;
                _product.detail_en = item.detail_en;
                _product.group_id = item.group_id;
                data.SubmitChanges();
                return RedirectToAction("Product", "Product");
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
                data.products.DeleteOnSubmit(data.products.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Product", "Product");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            product us = data.products.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
    }
}