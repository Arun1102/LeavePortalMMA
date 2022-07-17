using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeavePortalMMA.ServiceLayers;
using LeavePortalMMA.ViewModels;

namespace LeavePortalMMA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ILeaveApplyService ls;
        //IUsersService us;
        public HomeController(ILeaveApplyService ls)
        {
            
            this.ls = ls;
        }
        public ActionResult Index()
        {
            List<LeaveListViewModel> leaves = this.ls.GetAllLeave().ToList();
            //List<UserViewModel> users = this.us.GetUsers().ToList();
            return View(leaves);
        }

        [Route("allleaves")]
        public ActionResult Leaves()
        {
            List<LeaveListViewModel> lv = this.ls.GetAllLeave();
            return View(lv);
        }

        public ActionResult Search(string str)
        {
            List<LeaveListViewModel> leaves = this.ls.GetAllLeave().Where(temp => temp.LeaveReason.ToLower().Contains(str.ToLower()) || temp.user.Name.ToLower().Contains(str.ToLower())).ToList();
            ViewBag.str = str;
            return View(leaves);
            
        }
    }
}