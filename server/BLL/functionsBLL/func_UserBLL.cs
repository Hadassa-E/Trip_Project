using AutoMapper;
using BLL.interfacesBLL;
using DAL.interfacesDAL;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functionsBLL
{
    public class func_UserBLL : IuserBLL
    {
        IMapper m;
        IuserDAL u1;
        ItripDAL t1;
        public func_UserBLL(IMapper _m, IuserDAL u1,ItripDAL _t1)
        {
            this.u1 = u1;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Mapper>();
            });
            m = config.CreateMapper();
            t1 = _t1;
        }

        public int AddUserBLL(UserDTO user)
        {
            if (ChecksBLL.CheckName(user.UserFirstName) &&
                 ChecksBLL.CheckName(user.UserLastName) &&
                 ChecksBLL.CheckMail(user.UserMail) &&
                 ChecksBLL.CheckPhone(user.UserPhon) &&
                 ChecksBLL.CheckPassword(user.UserPassword))
                return u1.AddUser(m.Map<UserDTO,User>(user));
            return -1;
        }

        public bool DeleteUserBLL(int id)
        {
            User us = u1.getAllUser().FirstOrDefault(x => x.UserId == id);
            if(us == null) return false;
            List<Trip> lt = m.Map<List<TripDTO>, List<Trip>>(GetAllTripsBLL(us.UserId));
            if (lt == null || lt.Count == 0)
                return u1.DeleteUser(id);
             return false;
            
        }

        public List<TripDTO> GetAllTripsBLL(int id)
        {
            List<Trip> lt = new List<Trip>();
            User uu = u1.getAllUser().FirstOrDefault(x => x.UserId == id);
            if (uu != null) { 
            List<Order> oo = uu.Orders.ToList();
            foreach (Order o in oo)
            {
                Trip t = t1.getAllTrip().FirstOrDefault(x=>x.TripId==o.TripId);
                lt.Add(t);
            }}
           lt=lt.Distinct().ToList();
            return m.Map<List<Trip>, List<TripDTO>>(lt);
        }


        public List<UserDTO> getAllUserBLL()
        {
            return m.Map<List<User>, List<UserDTO>>(u1.getAllUser());
        }

        public UserDTO GetUserByMailAndPaswordBLL(string mail, string password)
        {
            List<User> l1=u1.getAllUser();
            //return m.Map<User,UserDTO>(l1.FirstOrDefault(x => x.UserMail == mail && x.UserPassword == password));
            return m.Map<User, UserDTO>(u1.GetUserByMailAndPasword(mail,password));
        }

        public bool UpdateUserBLL(UserDTO user)
        {
            if (ChecksBLL.CheckName(user.UserFirstName) &&
                ChecksBLL.CheckName(user.UserLastName) &&
                ChecksBLL.CheckMail(user.UserMail) &&
                ChecksBLL.CheckPhone(user.UserPhon) &&
                ChecksBLL.CheckPassword(user.UserPassword))
                return u1.UpdateUser(m.Map<UserDTO, User>(user));
            return false;
        }
    }
}
