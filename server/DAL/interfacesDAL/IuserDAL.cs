using DAL.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfacesDAL
{
    public interface IuserDAL
    {
        List<User> getAllUser();
        //User GetUser(int id);
        User GetUserByMailAndPasword(string mail,string password);
        int AddUser(User user);
        bool DeleteUser(int id);
        bool UpdateUser(User user);
    }
}
