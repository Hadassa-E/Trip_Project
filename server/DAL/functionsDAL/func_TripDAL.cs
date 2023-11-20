using DAL.interfacesDAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functionsDAL
{
    public class func_TripDAL : ItripDAL
    {
        TripsDbContext db;
        public func_TripDAL(TripsDbContext _db)
        {
            db = _db;
        }
        public int AddTrip(Trip trip)
        {
            db.Trips.Add(trip);
            db.SaveChanges();
            return trip.TripId;
        }

        public bool DeleteTrip(int id)
        {
            Trip tt = db.Trips.FirstOrDefault(f => f.TripId == id);
            if (tt== null||db.Orders.FirstOrDefault(x=>x.TripId==tt.TripId)!=null)
                return false;
            db.Trips.Remove(db.Trips.FirstOrDefault(f => f.TripId == id));
            db.SaveChanges();
            return true;
        }

        public List<Trip> getAllTrip()
        {
            return db.Trips.Include(x=>x.Kind).Include(y=>y.Orders).ThenInclude(z=>z.User).ToList();
        }

        public Trip GetTrip(int id)
        {
            return getAllTrip().FirstOrDefault(f => f.TripId == id);
        }

        public bool UpdateTrip(Trip trip)
        {
            Trip k = db.Trips.FirstOrDefault(f => f.TripId == trip.TripId);
            if (k == null)
                return false;
            k.TripId = trip.TripId;
            k.TripPrice = trip.TripPrice;
            k.TripHour = trip.TripHour; 
            k.TripImage = trip.TripImage;   
            k.TripDate = trip.TripDate;
            k.TripDestination= trip.TripDestination;    
            k.TripTime = trip.TripTime;
            k.TripAvailability= trip.TripAvailability;
            k.KindId=trip.KindId;
            db.SaveChanges();
            return true;
        }
    }
}
