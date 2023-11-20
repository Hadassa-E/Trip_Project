using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfacesBLL
{
    public interface IkindBLL
    {
        List<KindDTO> getAllKindBLL();
        int AddKindBLL(KindDTO kind);
        bool DeleteKindBLL(int id);
    }
}
