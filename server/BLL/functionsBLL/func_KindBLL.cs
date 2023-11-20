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
    public class func_KindBLL : IkindBLL
    {
        IkindDAL k1;
        IMapper m;
        public func_KindBLL(IkindDAL _k1, IMapper _m)
        {
            k1= _k1;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Mapper>();
            });
            m = config.CreateMapper();
        }
        public int AddKindBLL(KindDTO kind)
        {
            List<Kind> l1=k1.getAllKind();
            if (l1.FirstOrDefault(f => f.KindName == kind.KindName) != null)
                return -1;
            return k1.AddKind(m.Map<KindDTO, Kind>(kind));
        }

        public bool DeleteKindBLL(int id)
        {
            return k1.DeleteKind(id);
        }

        public List<KindDTO> getAllKindBLL()
        {
            return m.Map<List<Kind>, List<KindDTO>>(k1.getAllKind());
        }
        //apdate
        //return k1.update(m.Map<kindDTO,KIND>(kind);
    }
}
