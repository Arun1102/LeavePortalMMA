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
    public interface IUsersService
    {
        int InsertUser(RegisterViewModel rvm);
        void UpdateUserDetails(EditUserViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailandPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);
        UserViewModel GetUsersByUserID(int UserID);
    }
    public class UsersService : IUsersService
    {
        IUsersRepository ur;

        public UsersService()
        {
            ur = new UsersRepository();
        }

        public int InsertUser(RegisterViewModel rvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<RegisterViewModel, Users>(rvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(rvm.Password);
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();
            return uid;
        }
        public void UpdateUserDetails(EditUserViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserViewModel, Users>(uvm);
            ur.UpdateUserDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, Users>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserPasswordViewModel, Users>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUserPassword(u);
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetUsers()
        {
            List<Users> u = ur.GetUsers();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<Users>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmailandPassword(string Email, string Password)
        {
            Users u = ur.GetUsersByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            Users u = ur.GetUsersByEmail(Email).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(u);
            }
            return uvm;
        }


        public UserViewModel GetUsersByUserID(int UserID)
        {
            Users u = ur.GetUsersByUserID(UserID).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(u);
            }
            return uvm;
        }


    }
}
