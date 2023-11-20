using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfacesBLL
{
    public interface IuserBLL
    {
        List<UserDTO> getAllUserBLL();
        UserDTO GetUserByMailAndPaswordBLL(string mail, string password);
        int AddUserBLL(UserDTO user);
        bool DeleteUserBLL(int id);
        bool UpdateUserBLL(UserDTO user);
        List<TripDTO> GetAllTripsBLL(int id);
    }
}
