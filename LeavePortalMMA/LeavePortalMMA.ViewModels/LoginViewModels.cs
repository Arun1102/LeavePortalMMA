using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeavePortalMMA.ViewModels
{
    public class LoginViewModels
    {
        [Required]
        public String Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
