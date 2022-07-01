using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LeavePortalMMA.ViewModels
{
    public class LeaveListViewModel
    {
        public int LeaveID { get; set; }
        public string LeaveText { get; set; }
        public DateTime LeaveDateAndTime { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }

    }
}
