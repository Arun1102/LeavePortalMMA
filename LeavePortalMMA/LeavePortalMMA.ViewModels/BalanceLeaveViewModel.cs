using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeavePortalMMA.ViewModels
{
    public class BalanceLeaveViewModel
    {
        public int BalanceID { get; set; }
        public int UserID { get; set; }
        public int BalanceValue { get; set; }
    }
}
