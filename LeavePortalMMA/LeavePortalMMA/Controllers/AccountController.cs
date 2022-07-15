using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeavePortalMMA.ServiceLayers;
using LeavePortalMMA.ViewModels;

namespace LeavePortalMMA.Controllers
{
    public class AccountController : Controller
    {
        
        IUsersService us;

        public AccountController(IUsersService us)
        {
            this.us = us;   
        }
        public ActionResult Register()
        {
            return View();
        }

        //to avoid csr attack
        [ValidateAntiForgeryToken] 
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                int uid = this.us.InsertUser(rvm);
                //now we can use session to store the details of current users
                Session["CurrentUserID"] = uid;
                Session["CurrentUserName"] = rvm.Name;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("X", "Invalid data");
                return View();
            }


        }

        public ActionResult Login()
        {
            LoginViewModels lvm = new LoginViewModels();
            return View(lvm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModels lvm)
        {
            if (ModelState.IsValid)
            {
                UserViewModel uvm = this.us.GetUsersByEmailandPassword(lvm.Email, lvm.Password);
                if (uvm != null)
                {
                    Session["CurrentUserID"] = uvm.UserID;
                    Session["CurrentUserName"] = uvm.Name;
                    Session["CurrentUserEmail"] = uvm.Email;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserIsAdmin"] = uvm.IsAdmin;

                    if (uvm.IsAdmin)
                    {
                        return RedirectToRoute(new { controller = "Home", action = "Index" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password, check with administrator if already have an account");
                    return View(lvm);
                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(lvm);
            }
         }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }














            
        
    }
}