using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IOrderDAL
    {
        OrderDTO CreateOrder(OrderDTO order);

        OrderDTO GetOrderByID(int id);
        List<OrderDTO> GetAllOrders();
        void UpdateOrder(OrderDTO order);
        void DeleteOrder(int id);
    }
}
