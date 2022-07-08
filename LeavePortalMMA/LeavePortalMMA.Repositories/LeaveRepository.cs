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
        void ApplyLeave(Leaves u);
        void UpdateLeaveDetails(Leaves u);
        void DeleteLeave(int uid);
        List<Leaves> GetAllLeave();
        List<Leaves> GetLeaveByLeaveID(int uid);
        void UpdateLeaveCount(int a, int value);
    }
    public class LeaveRepository : ILeaveRepository
    {
        LeavePortalMMADatabaseDbcontext db;

        public LeaveRepository()
        {
            db = new LeavePortalMMADatabaseDbcontext();
        }

        public void ApplyLeave(Leaves u)
        {
            db.Leave.Add(u);
            db.SaveChanges();
        }

        public void UpdateLeaveDetails(Leaves u)
        {
            Leaves us = db.Leave.Where(temp => temp.LeaveID == u.LeaveID).FirstOrDefault();
            if (us != null)
            {
                us.LeaveReason = u.LeaveReason;
                us.LeaveDateAndTime = u.LeaveDateAndTime;
                db.SaveChanges();
            }
        }

        public void DeleteLeave(int uid)
        {
            Leaves us = db.Leave.Where(temp => temp.LeaveID == uid).FirstOrDefault();
            if (us != null)
            {
                db.Leave.Remove(us);
                db.SaveChanges();
            }
        }



        public List<Leaves> GetAllLeave()
        {
            List<Leaves> us = db.Leave.ToList();
            return us;
        }

        public List<Leaves> GetLeaveByLeaveID(int uid)
        {
            List<Leaves> us = db.Leave.Where(temp => temp.LeaveID == uid).ToList();
            return us;
        }

        public void UpdateLeaveCount(int a, int value)
        {
            Leaves li = db.Leave.Where(temp => temp.LeaveID == a).FirstOrDefault();
            if (li != null)
            {
                li.LeaveCount -= value;
                db.SaveChanges();
            }
        }

    }
}
