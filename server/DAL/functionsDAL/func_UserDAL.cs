using DAL.interfacesDAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functionsDAL
{
    public class func_UserDAL : IuserDAL
    {
        TripsDbContext db;
        public func_UserDAL(TripsDbContext _db)
        {
            db = _db;
        }
        public int AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return db.Users.FirstOrDefault(u=>u.UserMail.Equals(user.UserMail) && u.UserPassword.Equals(user.UserPassword)).UserId;
        }

            public bool DeleteUser(int id)
        {
            if (db.Users.FirstOrDefault(f => f.UserId == id) == null)
                return false;
            db.Users.Remove(db.Users.FirstOrDefault(f => f.UserId == id));
            db.SaveChanges();
            return true;
        }

        public List<User> getAllUser()
        {
            return db.Users.Include(x=>x.Orders).ToList();
        }

        //public User GetUser(int id)
        //{
        //    return db.Users.FirstOrDefault(f => f.UserId == id);
        //}

        public User GetUserByMailAndPasword(string mail, string password)
        {
            return db.Users.FirstOrDefault(f => f.UserMail.Equals(mail) && f.UserPassword.Equals(password));
        }

        public bool UpdateUser(User user)
        {
            User k = db.Users.FirstOrDefault(f => f.UserId == user.UserId);
            if (k == null)
                return false;
            //k.UserId= user.UserId;
            k.UserLastName = user.UserLastName;
            k.UserPhon= user.UserPhon; 
            k.UserMail = user.UserMail;
            k.UserFirstName= user.UserFirstName;
            k.UserPassword= user.UserPassword;
            k.UserFirstAid= user.UserFirstAid;
            db.SaveChanges();
            return true;
        }
    }
}
