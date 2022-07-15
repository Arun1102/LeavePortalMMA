using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeavePortalMMA.ServiceLayers;
using LeavePortalMMA.ViewModels;

namespace LeavePortalMMA.ApiControllers
{
    public class AccountController : ApiController
    {
        IUsersService us;

        public AccountController(IUsersService us)
        {
            this.us = us;
        }
        
        //we will call this below method in ajax 
        public string Get(string Email)
        {
            if (this.us.GetUsersByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
