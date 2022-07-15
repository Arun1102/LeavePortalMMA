using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePortalMMA.DomainModels;


namespace LeavePortalMMA.Repositories
{
    public interface IBalanceLeaveRepository
    {
        void UpdateLeaveCount(int uid, int value);
        int getUserBalanceLeave(int b);
    }
    public class BalanceLeaveRepository:IBalanceLeaveRepository
    {
        LeavePortalMMADatabaseDbcontext db;

        public BalanceLeaveRepository()
        {
            db = new LeavePortalMMADatabaseDbcontext();
        }

        public void UpdateLeaveCount(int uid, int value)
        {
            int updateValue;
            //if (value < 0) updateValue = -1;
            //else updateValue = 1;
            if(value < 0)
            {
                updateValue = -1;
            }
            else
            {
                updateValue = 1;
            }

            BalanceLeaves vo = db.BalanceLeave.Where(temp=>temp.UserID == uid).FirstOrDefault();
            
            if (vo != null)
            {
                vo.BalanceValue = updateValue;
            }
            else
            {
                BalanceLeaves newVo = new BalanceLeaves() { UserID = uid, BalanceValue = updateValue };
            }
            db.SaveChanges();
        }

        public int getUserBalanceLeave(int b)
        {
            
            BalanceLeaves a = db.BalanceLeave.Where(temp=>temp.UserID == b).FirstOrDefault();
            int c;
            if (a != null)
            {
                c = a.BalanceValue;
            }
            else
            {
                c = 0;
            }
            return c;
        }
    }
}
