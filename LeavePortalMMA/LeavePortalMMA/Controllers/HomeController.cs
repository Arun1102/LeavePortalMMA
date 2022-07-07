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

        public HomeController(ILeaveApplyService ls)
        {
            this.ls = ls;
        }
        public ActionResult Index()
        {
            List<LeaveListViewModel> leaves = this.ls.GetAllLeave().Take(10).ToList();
            return View(leaves);
        }
    }
}