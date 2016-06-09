using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Controllers
{
    public class SanPhamController : AnhPhatController
    {
        // GET: SanPham
        public ActionResult Index()
        {
            dynamic Model = new ExpandoObject();
            Model.Products = data.sp_Get_Product(this.getLanguageCode()).ToList();
            return View(Model);
        }

        public new ActionResult View(string link)
        {
            dynamic Model = new Object();
            Model = data.sp_Get_Product_Item(this.getLanguageCode(), link).FirstOrDefault();
            return View(Model);
        }

        public ActionResult Group(string link)
        {
            dynamic Model = new ExpandoObject();
            Model.Products = data.sp_Get_Product_List_Group(this.getLanguageCode(), link).ToList();
            return View(Model);
        }
    }
}