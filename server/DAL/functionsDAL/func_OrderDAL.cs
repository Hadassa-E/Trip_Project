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
    public class func_OrderDAL : IorderDAL
    {
        
        static TripsDbContext db;
        public func_OrderDAL(TripsDbContext _db)
        {
            db = _db;
        }
        public int AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderId;
        }

        public bool DeleteOrder(int id)
        {
            if (db.Orders.FirstOrDefault(f => f.OrderId == id) == null)
                return false;
            db.Orders.Remove(db.Orders.FirstOrDefault(f => f.OrderId == id));
            db.SaveChanges();
            return true;
        }

        public List<Order> getAllOrder()
        {
            return db.Orders.Include(x => x.Trip).Include(x => x.User).ToList();
        }
        public Order GetOrder(int id)
        {
            return db.Orders.FirstOrDefault(f => f.OrderId == id);
        }
        public static void UpdateAvailability(int order_id,int trip_id,bool b)
        {
            Order order = db.Orders.FirstOrDefault(x => x.OrderId == order_id);
            Trip t=db.Trips.FirstOrDefault(x=>x.TripId==trip_id);
            if (b == true)//עבור הוספה
                t.TripAvailability -= order.OrderPlaces;
            else//עבור מחיקה
                t.TripAvailability += order.OrderPlaces;
            db.SaveChanges();
        }
        //public bool UpdateOrder(Order order)
        //{
        //    Order k = db.Orders.FirstOrDefault(f => f.OrderId == order.OrderId);
        //    if (k == null)
        //        return false;
        //    k.OrderId = order.OrderId;
        //    k.OrderPlaces = order.OrderPlaces;
        //    k.OrderDate = order.OrderDate;
        //    k.OrderTime= order.OrderTime;   
        //    k.UserId = order.UserId;    
        //    k.TripId = order.TripId;
        //   // k.Trip= order.Trip;
        //   // k.User= order.User;
        //    db.SaveChanges();
        //    return true;
        //}
    }
}
