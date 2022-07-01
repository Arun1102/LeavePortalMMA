using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePortalMMA.DomainModels;


namespace LeavePortalMMA.Repositories
{
    public interface ILeaveRepository
    {
        void ApplyLeave(Leave u);
        void UpdateLeaveDetails(Leave u);
        void DeleteLeave(int uid);
        List<Leave> GetAllLeave();
        List<Leave> GetLeaveByLeaveID(int uid);
        void UpdateLeaveCount(int a, int value);
    }
    public class LeaveRepository : ILeaveRepository
    {
        LeavePortalMMADatabaseDbcontext db;

        public LeaveRepository()
        {
            db = new LeavePortalMMADatabaseDbcontext();
        }

        public void ApplyLeave(Leave u)
        {
            db.Leave.Add(u);
            db.SaveChanges();
        }

        public void UpdateLeaveDetails(Leave u)
        {
            Leave us = db.Leave.Where(temp => temp.LeaveID == u.LeaveID).FirstOrDefault();
            if (us != null)
            {
                us.LeaveReason = u.LeaveReason;
                us.LeaveDateAndTime = u.LeaveDateAndTime;
                db.SaveChanges();
            }
        }

        public void DeleteLeave(int uid)
        {
            Leave us = db.Leave.Where(temp => temp.LeaveID == uid).FirstOrDefault();
            if (us != null)
            {
                db.Leave.Remove(us);
                db.SaveChanges();
            }
        }



        public List<Leave> GetAllLeave()
        {
            List<Leave> us = db.Leave.ToList();
            return us;
        }

        public List<Leave> GetLeaveByLeaveID(int uid)
        {
            List<Leave> us = db.Leave.Where(temp => temp.LeaveID == uid).ToList();
            return us;
        }

        public void UpdateLeaveCount(int a, int value)
        {
            Leave li = db.Leave.Where(temp => temp.LeaveID == a).FirstOrDefault();
            if (li != null)
            {
                li.LeaveCount -= value;
                db.SaveChanges();
            }
        }

    }
}
