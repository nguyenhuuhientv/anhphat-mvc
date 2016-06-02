using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = data.group_products.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.caption_vn

            });
            ViewBag.ListItem = items;
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(product item, HttpPostedFileBase image, string group_id)
        {
            IEnumerable<SelectListItem> items = data.group_products.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.caption_vn

            });
            ViewBag.ListItem = items;
            try
            {           
               
                if (image != null)
                {
                    string id = Request.Form["ListItem"].ToString();
                    //Save image to file
                    var filename = Guid.NewGuid().ToString() + image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/images");

                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);
                    product _item = new product();
                    _item.image = "/Content/images/" + filename;
                    _item.caption_vn = item.caption_vn;
                    _item.caption_en = item.caption_en;
                    _item.describe_vn = item.describe_vn;
                    _item.describe_en = item.describe_en;
                    _item.detail_vn = item.detail_vn;
                    _item.detail_en = item.detail_en;
                    _item.group_id = int.Parse(id);
                    data.products.InsertOnSubmit(_item);
                    data.SubmitChanges();
                    return RedirectToAction("Product", "Product");
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
            IEnumerable<SelectListItem> items = data.group_products.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.caption_vn

            });
            ViewBag.ListItem = items;
            product item = data.products.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product item, HttpPostedFileBase image)
        {

            IEnumerable<SelectListItem> items = data.group_products.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.caption_vn

            });
            ViewBag.ListItem = items;
            try
            {
                if (image != null)
                {
                    string id = Request.Form["ListItem"].ToString();
                    //Save image to file
                    var filename = Guid.NewGuid().ToString() + image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/images");

                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);
                    product _item = data.products.FirstOrDefault(x => x.id == item.id);
                    _item.image = "/Content/images/" + filename;
                    _item.caption_vn = item.caption_vn;
                    _item.caption_en = item.caption_en;
                    _item.describe_vn = item.describe_vn;
                    _item.describe_en = item.describe_en;
                    _item.detail_vn = item.detail_vn;
                    _item.detail_en = item.detail_en;
                    _item.group_id = int.Parse(id);
                    data.SubmitChanges();
                    return RedirectToAction("Product", "Product");
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