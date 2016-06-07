
using AnhPhatMVC.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            System.Web.HttpContext.Current.Session["DanhMuc"] = "Tin tức - Khuyến mãi";
            List<new_new> _list = data.new_news.ToList();
            return new ManagerController().KiemTraDaDangNhap(View(_list));
        }
        public ActionResult Create()
        {
            return new ManagerController().KiemTraDaDangNhap(View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(new_new item, HttpPostedFileBase image)
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
                    new_new _newt = new new_new();
                    _newt.caption_vn = item.caption_vn;
                    _newt.caption_en = item.caption_en;
                    _newt.detail_vn = item.detail_vn;
                    _newt.detail_en = item.detail_en;
                    _newt.group_new = item.group_new;
                    _newt.describe_vn = item.describe_vn;
                    _newt.describe_en = item.describe_en;
                    _newt.link = new ManagerController().convertToUnSign(item.caption_vn);
                    _newt.image = "/Content/images/"+ filename;
                    _newt.created_at = DateTime.Now;
                    data.new_news.InsertOnSubmit(_newt);
                    data.SubmitChanges();
                    return RedirectToAction("New", "News");
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
            new_new item = data.new_news.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(new_new item, HttpPostedFileBase image)
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
                    new_new _newt = data.new_news.FirstOrDefault(x => x.id == item.id);
                    _newt.caption_vn = item.caption_vn;
                    _newt.caption_en = item.caption_en;
                    _newt.detail_vn = item.detail_vn;
                    _newt.detail_en = item.detail_en;
                    _newt.group_new = item.group_new;
                    _newt.describe_vn = item.describe_vn;
                    _newt.describe_en = item.describe_en;
                    _newt.created_at = item.created_at;
                    _newt.link = new ManagerController().convertToUnSign(item.caption_vn);
                    _newt.image = "/Content/images/" + filename;
                    data.SubmitChanges();
                    return RedirectToAction("New", "News");
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
                data.new_news.DeleteOnSubmit(data.new_news.FirstOrDefault(x => x.id == id));
                data.SubmitChanges();
                return RedirectToAction("New", "News");
            }
            else
                return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            new_new us = data.new_news.FirstOrDefault(x => x.id == id);
            return new ManagerController().KiemTraDaDangNhap(View(us));
        }
    }
}