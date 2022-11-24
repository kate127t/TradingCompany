using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyBLL.Concrete;
using TradingCompanyDAL;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyTests.TestsBLL
{
    [TestFixture]
    public class OrdersManagerTests
    {
        private Mock<IOrderDAL> orderDAL;
        private Mock<IGoodsDAL> goodsDAL;
        private Mock<IProviderDAL> providerDAL;
        private Mock<IGoodsAndProvidersDAL> goodsAndProvidersDAL;
        private Mock<IViewOrderDAL> viewOrderDAL;
        private OrdersManager ordersManager;

        [SetUp]
        public void Setup()
        {
            orderDAL = new Mock<IOrderDAL>(MockBehavior.Strict);
            goodsDAL = new Mock<IGoodsDAL>(MockBehavior.Strict);
            providerDAL = new Mock<IProviderDAL>(MockBehavior.Strict);
            goodsAndProvidersDAL = new Mock<IGoodsAndProvidersDAL>(MockBehavior.Strict);
            viewOrderDAL = new Mock<IViewOrderDAL>(MockBehavior.Strict);

            ordersManager = new OrdersManager(orderDAL.Object, goodsDAL.Object, providerDAL.Object, goodsAndProvidersDAL.Object, viewOrderDAL.Object);
        }

        [Test]
        public void TestAddOrder()
        {
            OrderDTO inOrder = new OrderDTO()
            {
                GoodsID = 1,
                ProviderID = 1,
                ManagerID = 2,
                DateOrdered = DateTime.Now,
                DateArrives = DateTime.Now,
                Quantity = 3
            };
            OrderDTO outOrder = new OrderDTO { OrderID = 1 };
            
            orderDAL.Setup(d => d.CreateOrder(inOrder)).Returns(outOrder);
            var res = ordersManager.AddOrder(inOrder);

            Assert.IsNotNull(res);
            Assert.AreEqual(outOrder.OrderID, res.OrderID);

        }

        [Test]
        public void TestGetOrderByID()
        {
            int expectedID = 11;
            OrderDTO expectedOrder = new OrderDTO()
            {
                OrderID = expectedID,
                GoodsID = 1,
                ProviderID = 1,
                ManagerID = 2,
                DateOrdered = DateTime.Now,
                DateArrives = DateTime.Now,
                Quantity = 3
            };

            orderDAL.Setup(d => d.GetOrderByID(expectedID)).Returns(expectedOrder);

            OrderDTO actualOrder = ordersManager.GetOrderByID(expectedID);

            Assert.IsNotNull(actualOrder);
            Assert.AreEqual(actualOrder, expectedOrder);

        }

        [Test]
        public void TestGetAllOrders()
        {
            OrderDTO order1 = new OrderDTO()
            {
                OrderID = 1,
                GoodsID = 1,
                ProviderID = 1,
                ManagerID = 2,
                DateOrdered = DateTime.Now,
                DateArrives = DateTime.Now,
                Quantity = 3
            };
            OrderDTO order2 = new OrderDTO()
            {
                OrderID = 2,
                GoodsID = 1,
                ProviderID = 1,
                ManagerID = 2,
                DateOrdered = DateTime.Now,
                DateArrives = DateTime.Now,
                Quantity = 3
            };

            List<OrderDTO> expectedOrders = new List<OrderDTO>() { order1,order2};

            orderDAL.Setup(d => d.GetAllOrders()).Returns(expectedOrders);

            List<OrderDTO> actualOrders = ordersManager.GetAllOrders();

            Assert.IsNotNull(actualOrders);
            Assert.Contains(order1.OrderID, actualOrders.Select(r => r.OrderID).ToList());
        }

        [Test]
        public void TestGetAllGoods()
        {
            GoodsDTO goods1 = new GoodsDTO()
            {
                GoodsID = 1,
                Name = "TestGoods1"
            };
            GoodsDTO goods2 = new GoodsDTO()
            {
                GoodsID = 2,
                Name = "TestGoods2"
            };

            List<GoodsDTO> expectedGoods = new List<GoodsDTO>() { goods1, goods2 };

            goodsDAL.Setup(d => d.GetAllGoods()).Returns(expectedGoods);

            List<GoodsDTO> actualGoods = ordersManager.GetAllGoods();

            Assert.IsNotNull(actualGoods);
            Assert.Contains(goods1.GoodsID, actualGoods.Select(r => r.GoodsID).ToList());
        }

        [Test]
        public void TestGetAllProvidersByGoodsID()
        {
            int GoodsID = 1;
            ProviderDTO provider1 = new ProviderDTO()
            {
                ProviderID = 1,
                Name = "ProviderByID"
            };
            ProviderDTO provider2 = new ProviderDTO()
            {
                ProviderID = 2,
                Name = "NotProviderByID"
            };

            List<ProviderDTO> expectedProviders = new List<ProviderDTO>() { provider1};

            providerDAL.Setup(d => d.GetListProvidersByGoodsID(GoodsID)).Returns(expectedProviders);

            List<ProviderDTO> actualProviders = ordersManager.GetAllProvidersByGoodsID(GoodsID);

            Assert.IsNotNull(actualProviders);
            Assert.Contains(provider1.ProviderID, actualProviders.Select(r => r.ProviderID).ToList());
            CollectionAssert.DoesNotContain(actualProviders.Select(r => r.ProviderID).ToList(), provider2.ProviderID);
        }
    }
}
