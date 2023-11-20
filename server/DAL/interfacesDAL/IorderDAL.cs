using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfacesDAL
{
    public interface IorderDAL
    {
        List<Order> getAllOrder();
        Order GetOrder(int id);
        int AddOrder(Order order);
        bool DeleteOrder(int id);
    }
}
