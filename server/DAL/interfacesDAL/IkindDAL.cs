using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfacesDAL
{
    public interface IkindDAL
    {
        List<Kind> getAllKind();
        Kind GetKind(int id);
        int AddKind(Kind kind);
        bool DeleteKind(int id);
        //bool UpdateKind(Kind kind);
    }
}
