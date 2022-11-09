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
    public class OrderDAL : IOrderDAL
    {
        private readonly IMapper mapper;
        public OrderDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public OrderDTO CreateOrder(OrderDTO order)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orderInDB = mapper.Map<Order>(order);
                entities.Order.Add(orderInDB);
                entities.SaveChanges();
                return mapper.Map<OrderDTO>(orderInDB);
            }
        }

        public void DeleteOrder(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orderToDelete = entities.Order.FirstOrDefault(x => x.OrderID == id);
                entities.Order.Remove(orderToDelete);
                entities.SaveChanges();
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orders = entities.Order.ToList();
                return mapper.Map<List<OrderDTO>>(orders);
            }
        }

        public OrderDTO GetOrderByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var order = entities.Order.FirstOrDefault(x => x.OrderID == id);
                return mapper.Map<OrderDTO>(order);
            }
        }

        public void UpdateOrder(OrderDTO order)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orderInDB = entities.Order.FirstOrDefault(x => x.OrderID == order.OrderID);
                //roleInDB = mapper.Map<Role>(role);
                orderInDB.GoodsID = order.GoodsID;
                orderInDB.ProviderID = order.ProviderID;
                orderInDB.ManagerID = order.ManagerID;
                orderInDB.DateOrdered = order.DateOrdered;
                orderInDB.DateArrives = order.DateArrives;
                orderInDB.Quantity = order.Quantity;

                entities.SaveChanges();
            }
        }
    }
}
