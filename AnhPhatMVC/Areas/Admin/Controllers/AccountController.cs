using AnhPhatMVC.Context;
using AnhPhatMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnhPhatMVC.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        AnhPhatDbContextDataContext data = new AnhPhatDbContextDataContext();
        public ActionResult Login()
        {          
            return new ManagerController().KiemTra(View());
        }

        [HttpPost]
        [AllowAnonymous]    
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var result = data.sp_DangNhap(model.Email, model.Password).ToList();//await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            int temp;
            if (result.Count>0)
                temp = 0;
            else
                temp = 1;

            switch (temp)
            {
                case 0:
                    System.Web.HttpContext.Current.Session["TaiKhoan"] = result.FirstOrDefault().username;
                    System.Web.HttpContext.Current.Session["Quyen"] = result.FirstOrDefault().role;
                    return RedirectToAction("Index","Admin");
                case 2:
                    return View("Lockout");
                case 3:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case 1:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            throw new NotImplementedException();
        }
        public ActionResult LogOff()
        {
            System.Web.HttpContext.Current.Session.Remove("TaiKhoan");
            System.Web.HttpContext.Current.Session.Remove("Quyen");
            return RedirectToAction("Login", "Account");
        }
       
    }
}