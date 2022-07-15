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
    }
}