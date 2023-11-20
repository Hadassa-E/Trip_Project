using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfacesBLL
{
    public interface IorderBLL
    {
        List<OrderDTO> GetAllToTripBLL(int id);
        int AddOrderBLL(OrderDTO order);
        bool DeleteOrderBLL(int id);
    }
}
