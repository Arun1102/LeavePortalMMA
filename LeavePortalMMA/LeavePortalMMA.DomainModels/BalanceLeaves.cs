using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeavePortalMMA.DomainModels
{
    public class BalanceLeaves
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BalanceID { get; set; }
        public int UserID { get; set; }
        public int BalanceValue { get; set; }


        [ForeignKey("UserID")]
        public virtual Users User { get; set; }
    }
}
