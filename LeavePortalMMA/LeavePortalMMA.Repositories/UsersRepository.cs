using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePortalMMA.DomainModels;


namespace LeavePortalMMA.Repositories
{
    public interface IUsersRepository
    {
        void InsertUser(Users u);
        void UpdateUserDetails(Users u);
        void UpdateUserPassword(Users u);
        void DeleteUser(int uid);
        List<Users> GetUsers();
        List<Users> GetUsersByEmailAndPassword(string Email, string Password);
        List<Users> GetUsersByEmail(string Email);
        List<Users> GetUsersByUserID(int UserID);
        int GetLatestUserID();
    }
    
    public class UsersRepository:IUsersRepository
    {
        LeavePortalMMADatabaseDbcontext db;

        public UsersRepository()
        {
            db = new LeavePortalMMADatabaseDbcontext();
        }

        public void InsertUser(Users u)
        {
            db.User.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetails(Users u)
        {
            Users us = db.User.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(Users u)
        {
            Users us = db.User.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int uid)
        {
            Users us = db.User.Where(temp => temp.UserID == uid).FirstOrDefault();
            if (us != null)
            {
                db.User.Remove(us);
                db.SaveChanges();
            }
        }

        public List<Users> GetUsers()
        {
            List<Users> us = db.User.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.Name).ToList();
            return us;
        }

        public List<Users> GetUsersByEmailAndPassword(string Email, string PasswordHash)
        {
            List<Users> us = db.User.Where(temp => temp.Email == Email && temp.PasswordHash == PasswordHash).ToList();
            return us;
        }

        public List<Users> GetUsersByEmail(string Email)
        {
            List<Users> us = db.User.Where(temp => temp.Email == Email).ToList();
            return us;
        }

        public List<Users> GetUsersByUserID(int UserID)
        {
            List<Users> us = db.User.Where(temp => temp.UserID == UserID).ToList();
            return us;
        }

        public int GetLatestUserID()
        {
            int uid = db.User.Select(temp => temp.UserID).Max();
            return uid;
        }
    }
}
