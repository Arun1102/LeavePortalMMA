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
        void UpdateLeaveCount(int a, int uid, int value);
    }
    public class BalanceLeaveRepository
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

            BalanceLeave vo = db.BalanceLeave.Where(temp=>temp.UserID == uid).FirstOrDefault();
            
            if (vo != null)
            {
                vo.BalanceValue = updateValue;
            }
            else
            {
                BalanceLeave newVo = new BalanceLeave() { UserID = uid, BalanceValue = updateValue };
            }
            db.SaveChanges();
        }
    }
}
