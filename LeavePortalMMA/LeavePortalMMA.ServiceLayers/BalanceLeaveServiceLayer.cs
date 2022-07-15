using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePortalMMA.DomainModels;
using LeavePortalMMA.Repositories;
using LeavePortalMMA.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;


namespace LeavePortalMMA.ServiceLayers
{
    public interface IBalanceLeaveServiceLayer
    {
        //int getUserBalanceLeave(int b);
    }
    public class BalanceLeaveServiceLayer
    {
        IBalanceLeaveRepository qr;

        public BalanceLeaveServiceLayer()
        {
            qr = new BalanceLeaveRepository();
        }

        //public BalanceLeaveViewModel getUserBalanceLeave(int b)
        //{
        //    int q = qr.getUserBalanceLeave(b);
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<BalanceLeaves, BalanceLeaveViewModel>(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    BalanceLeaveViewModel qvm = mapper.Map< BalanceLeaves, BalanceLeaveViewModel> (q);
        //    return qvm;
        //}

    }
}
