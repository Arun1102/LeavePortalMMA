using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeavePortalMMA.ViewModels
{
    public class EditLeaveApplyViewModel
    {
        //[Required]
        public int LeaveID { get; set; }
        [Required]
        public string LeaveText { get; set; }
        [Required]
        public DateTime LeaveDateAndTime { get; set; }

        //[Required]
        public int UserID { get; set; }
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int CategoryName { get; set; }
    }
}
