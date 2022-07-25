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
    public interface ILeaveApplyService
    {
        void ApplyLeave(NewLeaveApplyViewModel qvm);
        void UpdateLeaveDetails(EditLeaveApplyViewModel qvm);

        void UpdateCategoryDetails(EditLeaveApplyViewModel qvm);
        

        void UpdateLeaveCount(int qid, int value);
        void DeleteLeave(int qid);
        List<LeaveListViewModel> GetAllLeave();
        LeaveListViewModel GetLeaveByLeaveID(int leaveID);

        List<LeaveListViewModel> GetLeaveByUserID(int id);


    }
    public class LeaveApplyService:ILeaveApplyService
    {
        ILeaveRepository qr;

        public LeaveApplyService()
        {
            qr = new LeaveRepository();
        }

        public void ApplyLeave(NewLeaveApplyViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewLeaveApplyViewModel, Leaves>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leaves q = mapper.Map<NewLeaveApplyViewModel, Leaves>(qvm);
            qr.ApplyLeave(q); 
        }

        public void UpdateLeaveDetails(EditLeaveApplyViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditLeaveApplyViewModel, Leaves>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leaves q = mapper.Map<EditLeaveApplyViewModel, Leaves>(qvm);
            qr.UpdateLeaveDetails(q);
        }

        public void UpdateCategoryDetails(EditLeaveApplyViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditLeaveApplyViewModel, Leaves>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leaves q = mapper.Map<EditLeaveApplyViewModel, Leaves>(qvm);
            qr.UpdateCategoryDetails(q);
        }


        public void UpdateLeaveCount(int qid, int value)
        {
            qr.UpdateLeaveCount(qid, value);
        }
        public void DeleteLeave(int qid)
        {
            qr.DeleteLeave(qid);

        }
        

        public List<LeaveListViewModel> GetAllLeave()
        {
            List<Leaves> q = qr.GetAllLeave();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leaves, LeaveListViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<LeaveListViewModel> qvm = mapper.Map<List<Leaves>, List<LeaveListViewModel>>(q);
            return qvm;
        }

        public LeaveListViewModel GetLeaveByLeaveID(int leaveID)
        {
            Leaves q = qr.GetLeaveByLeaveID(leaveID).FirstOrDefault();
            
            
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leaves, LeaveListViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
           LeaveListViewModel qvm = mapper.Map<Leaves, LeaveListViewModel>(q);

               
            return qvm;
        } 

        public List<LeaveListViewModel> GetLeaveByUserID(int id)
        {
            List<Leaves> q = qr.GetLeaveByLeaveUserID(id).ToList();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leaves, LeaveListViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<LeaveListViewModel> qvm = mapper.Map<List<Leaves>, List<LeaveListViewModel>>(q);
            return qvm;
        }

    }
}
