using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LeavePortalMMA.DomainModels
{
    public class LeavePortalMMADatabaseDbcontext:DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Leaves> Leave { get; set; }
        public DbSet<BalanceLeaves> BalanceLeave { get; set; }
        public DbSet<Categories> Category { get; set; }
    }
}
