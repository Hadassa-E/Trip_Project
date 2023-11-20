using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfacesDAL
{
    public interface ItripDAL
    {
        List<Trip> getAllTrip();
        Trip GetTrip(int id);
        bool DeleteTrip(int id);
        int AddTrip(Trip trip);
        bool UpdateTrip(Trip trip);
    }
}
