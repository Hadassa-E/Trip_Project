using AutoMapper;
using BLL.interfacesBLL;
using DAL.functionsDAL;
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
    public class func_TripBLL : ItripBLL
    {
        ItripDAL t1;
        IMapper m;
        IorderDAL o1;
        public func_TripBLL(ItripDAL _t1, IMapper _m,IorderDAL _o1)
        {
            t1 = _t1;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Mapper>();
            });
            m = config.CreateMapper();
            o1 = _o1;
        }
        public int AddTripBLL(TripDTO trip)
        {
            if (trip.TripDate>DateTime.Today && 
              (DateTime)trip.TripDate > DateTime.Today.AddMonths(3)&&
              trip.TripHour>=3&&trip.TripHour<=12&&
              trip.TripAvailability>0&&
              trip.TripPrice>=0&&trip.TripPrice<=700)
                return t1.AddTrip(m.Map<TripDTO, Trip>(trip));
            return -1;
        }

        public bool DeleteTripBLL(int id)
        {
            return t1.DeleteTrip(id);
        }

        public List<TripDTO> getAllTripBLL()
        {
            return m.Map<List<Trip>, List<TripDTO>>(t1.getAllTrip());
        }

        public List<OrderDTO> GetInvitesToTrip(TripDTO trip)
        {
            Trip t1 = m.Map <TripDTO,Trip> (trip);
            List<Order> l1 = o1.getAllOrder().FindAll(x=>x.TripId==trip.TripId).ToList();
            return m.Map<List<Order>, List<OrderDTO>>(l1);
        }

        public TripDTO GetTripBLL(int id)
        {
            return m.Map<Trip, TripDTO>(t1.GetTrip(id));
        }

        public bool UpdateTripBLL(TripDTO trip)
        {
            if (trip.TripHour >= 3 && trip.TripHour <= 12 &&
                trip.TripAvailability > 0 &&
                trip.TripPrice >= 0 && trip.TripPrice <= 800&&
                trip.TripDate > DateTime.Today.AddMonths(3))
                return t1.UpdateTrip(m.Map<TripDTO, Trip>(trip));
            return false;
        }
    }
}
