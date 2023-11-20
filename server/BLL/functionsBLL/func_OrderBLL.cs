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
    public class func_OrderBLL : IorderBLL
    {
        IorderDAL o1;
        IMapper m;
        ItripDAL t1;
        public func_OrderBLL(IorderDAL _o1, IMapper _m, ItripDAL t1)
        {
            o1 = _o1;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Mapper>();
            });
            m = config.CreateMapper();
            this.t1 = t1;   
        }
        public int AddOrderBLL(OrderDTO order)
        { 
                Trip t = t1.GetTrip((int)order.TripId);
                if (t.TripDate > DateTime.Today && t.TripAvailability >= order.OrderPlaces)
                {
                    DateTime dt = DateTime.Today;
                    order.OrderDate = dt.Date;
                    order.OrderTime = dt.TimeOfDay;
                    int n= o1.AddOrder(m.Map<OrderDTO, Order>(order));
                DAL.functionsDAL.func_OrderDAL.UpdateAvailability(n,(int)order.TripId, true);
                return n;
                }
            return -1;
        }

        public bool DeleteOrderBLL(int id)
        {
            Order o = o1.GetOrder(id);
            Trip t = t1.GetTrip(Convert.ToInt32(o.TripId));
            if (t.TripDate > DateTime.Today)
            {
                DAL.functionsDAL.func_OrderDAL.UpdateAvailability(id,t.TripId,false);
                return o1.DeleteOrder(id);
            }
            return false;
        }

        public List<OrderDTO> GetAllToTripBLL(int id)
        {
            return m.Map<List<Order>, List<OrderDTO>>(o1.getAllOrder().Where(x => x.TripId == id).Distinct().ToList());
        }
    }
}
