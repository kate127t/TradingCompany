using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL;
using TradingCompanyDAL.Concrete;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDAL.Profiles;
using TradingCompanyDTO;

namespace TradingCompanyTests.TestsDAL
{
    [TestFixture]
    public class OrderDALTests
    {
        private IMapper mapper;
        private IOrderDAL orderDAL;
        private OrderDTO TestOrder;
        private OrderDTO CreatedOrder;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.orderDAL = new OrderDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestOrder();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestOrder();
            DeleteCreatedOrder();
        }

        private void DeleteTestOrder()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var ordersInDB = entities.Order.ToList();
                var orders = mapper.Map<List<OrderDTO>>(ordersInDB);
                var ordersID = orders.Select(r => r.OrderID).ToList();
                if (ordersID.Contains(TestOrder.OrderID))
                {
                    var orderToDelete = entities.Order.FirstOrDefault(x => x.OrderID == TestOrder.OrderID);
                    entities.Order.Remove(orderToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedOrder()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var ordersInDB = entities.Order.ToList();
                var orders = mapper.Map<List<OrderDTO>>(ordersInDB);
                var ordersID = orders.Select(r => r.OrderID).ToList();
                if (ordersID.Contains(CreatedOrder.OrderID))
                {
                    var orderToDelete = entities.Order.FirstOrDefault(x => x.OrderID == CreatedOrder.OrderID);
                    entities.Order.Remove(orderToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void InsertTestOrder()
        {
            OrderDTO order = new OrderDTO();
            order.GoodsID = 12;
            order.ManagerID = 63;
            order.DateOrdered = DateTime.Now;
            order.DateArrives = DateTime.Now;
            order.Quantity = 1;
            using (var entities = new TradingCompanyEntities())
            {
                var orderInDB = mapper.Map<Order>(order);
                entities.Order.Add(orderInDB);
                entities.SaveChanges();
                TestOrder = mapper.Map<OrderDTO>(orderInDB);
            }
        }

        [Test]
        public void TestGetAllOrders()
        {
            var Orders = orderDAL.GetAllOrders();

            Assert.IsNotNull(Orders);
            Assert.Contains(TestOrder.OrderID, Orders.Select(r => r.OrderID).ToList());
        }

        [Test]
        public void TestGetOrderByID()
        {
            var OrderByID = orderDAL.GetOrderByID(TestOrder.OrderID);

            Assert.IsNotNull(OrderByID);
            Assert.AreEqual(TestOrder.OrderID, OrderByID.OrderID);
        }

        [Test]
        public void TestCreateOrder()
        {
            OrderDTO newOrder = new OrderDTO();
            newOrder.GoodsID = 12;
            newOrder.ManagerID = 63;
            newOrder.DateOrdered = DateTime.Now;
            newOrder.DateArrives = DateTime.Now;
            newOrder.Quantity = 3;
            CreatedOrder = orderDAL.CreateOrder(newOrder);
            List<OrderDTO> orders;

            using (var entities = new TradingCompanyEntities())
            {
                var ordersInDB = entities.Order.ToList();
                orders = mapper.Map<List<OrderDTO>>(ordersInDB);
            }

            Assert.Contains(CreatedOrder.OrderID, orders.Select(r => r.OrderID).ToList());
        }

        [Test]
        public void TestUpdateOrder()
        {
            TestOrder.Quantity = 10;
            orderDAL.UpdateOrder(TestOrder);
            OrderDTO order;
            using (var entities = new TradingCompanyEntities())
            {
                var orderInDB = entities.Order.FirstOrDefault(x => x.OrderID == TestOrder.OrderID);
                order = mapper.Map<OrderDTO>(orderInDB);
            }

            Assert.AreEqual(TestOrder.Quantity, order.Quantity);
        }

        [Test]
        public void TestDeleteOrder()
        {
            orderDAL.DeleteOrder(TestOrder.OrderID);

            List<OrderDTO> orders;

            using (var entities = new TradingCompanyEntities())
            {
                var ordersInDB = entities.Order.ToList();
                orders = mapper.Map<List<OrderDTO>>(ordersInDB);
            }

            CollectionAssert.DoesNotContain(orders.Select(r => r.OrderID).ToList(), TestOrder.OrderID);
        }
    }
}
