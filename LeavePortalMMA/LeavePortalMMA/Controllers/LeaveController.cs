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
        ICategoriesServiceLayer cs;
        IUsersService us;

        public LeaveController(ILeaveApplyService qs, ICategoriesServiceLayer cs, IUsersService us)
        {
            this.qs = qs;
            this.cs = cs;
            this.us = us;
        }

        [UserAuthorizationFilterAttribute]
        public ActionResult UpdateCategory(int id)
        {
            List<CategoryViewModel> categories = this.cs.GetCategories();
            ViewBag.categories = categories;
            //int uid = Convert.ToInt32(Session["CurrentUserID"]);
            //LeaveListViewModel lvm = this.qs.GetLeaveByUserID(uid).FirstOrDefault();
            LeaveListViewModel lvm = this.qs.GetLeaveByLeaveID(id);
            EditLeaveApplyViewModel eudvm = new EditLeaveApplyViewModel() { LeaveID = lvm.LeaveID,UserID=lvm.UserID, LeaveText = lvm.LeaveReason };
            
            
            return View(eudvm);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttribute]
        public ActionResult UpdateCategory(EditLeaveApplyViewModel eudvm)
        {
           
            //this.qs.UpdateCategoryDetails(eudvm);
            //return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                eudvm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.qs.UpdateCategoryDetails(eudvm);
                //Session["CurrentCategoryID"] = eudvm.CategoryID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(eudvm);
            }
        }


        [UserAuthorizationFilterAttribute]
        public ActionResult Create()
        {
            List<CategoryViewModel> categories = this.cs.GetCategories();
            ViewBag.categories = categories;
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
                //qvm.CategoryID = Convert.ToInt32(Session["CurrentCategoryID"]);
                
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

       
        public ActionResult Delete(int id)
        {
            
            
            this.qs.DeleteLeave(id);
            return RedirectToAction("index", "Home");
        }

        


    }







    
}