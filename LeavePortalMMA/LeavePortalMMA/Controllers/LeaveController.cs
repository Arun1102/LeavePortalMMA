using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeavePortalMMA.ServiceLayers;
using LeavePortalMMA.ViewModels;
using LeavePortalMMA.CustomFilters;
namespace LeavePortalMMA.Controllers
{
    public class LeaveController : Controller
    {
        // GET: Leave
        ILeaveApplyService qs;

        public LeaveController(ILeaveApplyService qs)
        {
            this.qs = qs;
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Create(NewLeaveApplyViewModel qvm)
        {
            if (ModelState.IsValid)
            {

                qvm.LeaveDateAndTime = DateTime.Now;
                qvm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.qs.ApplyLeave(qvm);
                return RedirectToAction("index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }




    }



    
}