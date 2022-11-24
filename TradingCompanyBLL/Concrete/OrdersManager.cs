using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyBLL.Interfaces;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyBLL.Concrete
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrderDAL orderDAL;
        private readonly IGoodsDAL goodsDAL;
        private readonly IProviderDAL providerDAL;
        private readonly IGoodsAndProvidersDAL GoodsAndProvidersDAL;
        private readonly IViewOrderDAL viewOrderDAL;

        public OrdersManager (IOrderDAL orderDAL, IGoodsDAL goodsDAL, IProviderDAL providerDAL, IGoodsAndProvidersDAL goodsAndProvidersDAL, IViewOrderDAL viewOrderDAL)
        {
            this.orderDAL=orderDAL;
            this.goodsDAL=goodsDAL;
            this.providerDAL=providerDAL;
            this.GoodsAndProvidersDAL=goodsAndProvidersDAL;
            this.viewOrderDAL=viewOrderDAL;
        }

        public OrderDTO AddOrder(OrderDTO order)
        {
            return orderDAL.CreateOrder(order);
        }

        public void DeleteOrder(OrderDTO order)
        {
            orderDAL.DeleteOrder(order.OrderID);
        }

        public List<GoodsDTO> GetAllGoods()
        {
            return goodsDAL.GetAllGoods();
        }

        public List<OrderDTO> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public List<ViewOrderDTO> GetAllViewOrders()
        {
            return viewOrderDAL.GetListViewOrder();
        }

        public List<ProviderDTO> GetAllProvidersByGoodsID(int goodsID)
        {
            return providerDAL.GetListProvidersByGoodsID(goodsID);
        }

        public OrderDTO GetOrderByID(int id)
        {
           return orderDAL.GetOrderByID(id);
        }

        public void UpdateOrder(OrderDTO order)
        {
            orderDAL.UpdateOrder(order);
        }

        public GoodsDTO GetGoodsByID(int id)
        {
            return goodsDAL.GetGoodsByID(id);
        }

        public ProviderDTO GetProviderByID(int id)
        {
            return providerDAL.GetProviderByID(id);
        }
    }
}
