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
        //void UpdateUserBalanceLeave(BalanceLeaveViewModel b);
    }
    public class BalanceLeaveServiceLayer: IBalanceLeaveServiceLayer
    {
        IBalanceLeaveRepository qr;

        public BalanceLeaveServiceLayer()
        {
            qr = new BalanceLeaveRepository();
        }

        //public void UpdateUserBalanceLeave(BalanceLeaveViewModel b)
        //{
            
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<BalanceLeaveViewModel, BalanceLeaves>(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    BalanceLeaves qvm = mapper.Map<BalanceLeaveViewModel, BalanceLeaves>(b);
        //    qr.getUserBalanceLeave(qvm);
        //}

    }
}
