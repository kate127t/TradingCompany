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
    public class GoodsDALTests
    {
        private IMapper mapper;
        private IGoodsDAL goodsDAL;
        private GoodsDTO TestGoods;
        private GoodsDTO CreatedGoods;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.goodsDAL = new GoodsDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestGoods();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestGoods();
            DeleteCreatedGoods();
        }

        private void DeleteTestGoods()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDBList = entities.Goods.ToList();
                var goodsList = mapper.Map<List<GoodsDTO>>(goodsInDBList);
                var goodsIDList = goodsList.Select(r => r.GoodsID).ToList();
                if (goodsIDList.Contains(TestGoods.GoodsID))
                {
                    var goodsToDelete = entities.Goods.FirstOrDefault(x => x.GoodsID == TestGoods.GoodsID);
                    entities.Goods.Remove(goodsToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedGoods()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDBList = entities.Goods.ToList();
                var goodsList = mapper.Map<List<GoodsDTO>>(goodsInDBList);
                var goodsIDList = goodsList.Select(r => r.GoodsID).ToList();
                if (goodsIDList.Contains(CreatedGoods.GoodsID))
                {
                    var goodsToDelete = entities.Goods.FirstOrDefault(x => x.GoodsID == CreatedGoods.GoodsID);
                    entities.Goods.Remove(goodsToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void InsertTestGoods()
        {
            GoodsDTO goods = new GoodsDTO();
            goods.Name = "TestGoods";
            //goods.ProviderID = 7;
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDBList = mapper.Map<Goods>(goods);
                entities.Goods.Add(goodsInDBList);
                entities.SaveChanges();
                TestGoods = mapper.Map<GoodsDTO>(goodsInDBList);
            }
        }

        [Test]
        public void TestGetAllGoods()
        {
            var GoodsList = goodsDAL.GetAllGoods();

            Assert.IsNotNull(GoodsList);
            Assert.Contains(TestGoods.Name, GoodsList.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestGetGoodsByID()
        {
            var GoodsByID = goodsDAL.GetGoodsByID(TestGoods.GoodsID);

            Assert.IsNotNull(GoodsByID);
            Assert.AreEqual(TestGoods.Name, GoodsByID.Name);
        }

        [Test]
        public void TestCreateGoods()
        {
            GoodsDTO newGoods = new GoodsDTO();
            newGoods.Name = "CreatedGoods";
            //newGoods.ProviderID = 7;
            CreatedGoods = goodsDAL.CreateGoods(newGoods);
            List<GoodsDTO> goodsList;

            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDBList = entities.Goods.ToList();
                goodsList= mapper.Map<List<GoodsDTO>>(goodsInDBList);
            }

            Assert.IsNotNull(CreatedGoods);
            Assert.Contains(newGoods.Name, goodsList.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestUpdateGoods()
        {
            TestGoods.Name = "UpdatedTestGoods";
            goodsDAL.UpdateGoods(TestGoods);
            GoodsDTO goods;
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDB = entities.Goods.FirstOrDefault(x => x.GoodsID == TestGoods.GoodsID);
                goods = mapper.Map<GoodsDTO>(goodsInDB);
            }

            Assert.AreEqual(TestGoods.Name, goods.Name);
        }

        [Test]
        public void TestDeleteGoods()
        {
            goodsDAL.DeleteGoods(TestGoods.GoodsID);

            List<GoodsDTO> goodsList;

            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDBList = entities.Goods.ToList();
                goodsList = mapper.Map<List<GoodsDTO>>(goodsInDBList);
            }

            CollectionAssert.DoesNotContain(goodsList.Select(r => r.GoodsID).ToList(), TestGoods.GoodsID);
        }
    }
}
