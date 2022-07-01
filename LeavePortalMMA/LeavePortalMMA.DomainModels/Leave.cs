﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeavePortalMMA.DomainModels
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveID { get; set; }
        public string LeaveReason { get; set; }
        public DateTime LeaveDateAndTime { get; set; }
        public int UserID { get; set; }
        public int LeaveCount { get; set; }


        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
