using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class GroupController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/Group
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Group()
        {
            List<group_product> list_group = data.group_products.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(list_group));
        }
        public ActionResult Create()
        {
           return  new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        public ActionResult Create(group_product item)
        {
            try
            {
                data.group_products.InsertOnSubmit(item);
                data.SubmitChanges();
                return RedirectToAction("Group", "Group");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            group_product us = data.group_products.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }

        [HttpPost]
        public ActionResult Edit(group_product item)
        {
            try
            {
                group_product _group = data.group_products.FirstOrDefault(x => x.id == item.id);
                _group.caption_vn = item.caption_vn;
                _group.caption_en = item.caption_en;               
                data.SubmitChanges();
                return RedirectToAction("Group", "Group");
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
                data.group_products.DeleteOnSubmit(data.group_products.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("Group", "Group");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {   group_product us = data.group_products.FirstOrDefault(x => x.id == id);                   
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
           
    }
}