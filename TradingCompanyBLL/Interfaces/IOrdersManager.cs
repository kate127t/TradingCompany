using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyBLL.Interfaces
{
    public interface IOrdersManager
    {
        OrderDTO AddOrder(OrderDTO order);
        void UpdateOrder(OrderDTO order);
        void DeleteOrder(OrderDTO order);

        OrderDTO GetOrderByID(int id);

        List<OrderDTO> GetAllOrders();
        List<ViewOrderDTO> GetAllViewOrders();
        List<GoodsDTO> GetAllGoods();

        GoodsDTO GetGoodsByID(int id);
        List<ProviderDTO> GetAllProvidersByGoodsID(int goodsID);
        ProviderDTO GetProviderByID(int id);
    }
}
