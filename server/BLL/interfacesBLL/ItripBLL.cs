using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfacesBLL
{
    public interface ItripBLL
    {
        List<TripDTO> getAllTripBLL();
        TripDTO GetTripBLL(int id);
        int AddTripBLL(TripDTO trip);
        bool DeleteTripBLL(int id);
        bool UpdateTripBLL(TripDTO trip);
        List<OrderDTO> GetInvitesToTrip(TripDTO trip);
        //public bool IsParamedic(int tripid);
    }
}
