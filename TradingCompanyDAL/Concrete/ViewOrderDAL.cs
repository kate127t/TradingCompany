using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Concrete
{
    public class ViewOrderDAL : IViewOrderDAL
    {
        private readonly IMapper mapper;
        public ViewOrderDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public List<ViewOrderDTO> GetListViewOrder()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewOrders = entities.View_Order.ToList();
                return mapper.Map<List<ViewOrderDTO>>(viewOrders);
            }
        }

        public ViewOrderDTO GetViewOrderByID(int orderID)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewOrder = entities.View_Order.FirstOrDefault(x => x.OrderID == orderID);
                return mapper.Map<ViewOrderDTO>(viewOrder);
            }
        }
    }
}
