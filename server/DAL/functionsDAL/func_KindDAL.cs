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
    public class func_KindDAL : IkindDAL
    {
        TripsDbContext db;
        public func_KindDAL(TripsDbContext _db)
        {
            db = _db;
        }

        public static object GetKind(int? kindId)
        {
            throw new NotImplementedException();
        }

        public int AddKind(Kind kind)
        { 
            db.Kinds.Add(kind);
            db.SaveChanges();
            return kind.KindId;
        }
        public bool DeleteKind(int id)
        {
            if (db.Kinds.FirstOrDefault(x => x.KindId == id) != null)
                return false;
            db.Kinds.Remove(db.Kinds.FirstOrDefault(f => f.KindId == id));
            db.SaveChanges();
            return true;    
        }

        public List<Kind> getAllKind()
        {
           return db.Kinds.Include(x=>x.Trips).ToList();
        }

        public Kind GetKind(int id)
        {
            return db.Kinds.FirstOrDefault(f => f.KindId == id);
        }

        //public bool UpdateKind(Kind kind)
        //{
        //    Kind k = db.Kinds.FirstOrDefault(f => f.KindId == kind.KindId);
        //    if(k==null) 
        //        return false;
        //    k.KindId=kind.KindId;
        //    k.KindName = kind.KindName;
        //    db.SaveChanges();
        //    return true;
        //}
    }
}
