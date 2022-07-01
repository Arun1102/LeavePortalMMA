﻿using System;
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
        public DbSet<Leave> Leave { get; set; }
        public DbSet<BalanceLeave> BalanceLeave { get; set; }
    }
}
