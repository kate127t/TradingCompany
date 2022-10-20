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
    public class GoodsInStockDALTests
    {
        private IMapper mapper;
        private IGoodsInStockDAL goodsInStockDAL;
        private GoodsInStockDTO TestGoodsInStock;
        private GoodsInStockDTO CreatedGoodsInStock;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.goodsInStockDAL = new GoodsInStockDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestGoodsInStock();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestGoodsInStock();
            DeleteCreatedGoodsInStock();
        }

        private void DeleteTestGoodsInStock()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDBList = entities.GoodsInStock.ToList();
                var goodsInStockList = mapper.Map<List<GoodsInStockDTO>>(goodsInStockInDBList);
                var goodsInStockIDList = goodsInStockList.Select(r => r.GoodsInStockID).ToList();
                if (goodsInStockIDList.Contains(TestGoodsInStock.GoodsID))
                {
                    var goodsInStockToDelete = entities.GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == TestGoodsInStock.GoodsInStockID);
                    entities.GoodsInStock.Remove(goodsInStockToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedGoodsInStock()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDBList = entities.GoodsInStock.ToList();
                var goodsInStockList = mapper.Map<List<GoodsInStockDTO>>(goodsInStockInDBList);
                var goodsInStockIDList = goodsInStockList.Select(r => r.GoodsInStockID).ToList();
                if (goodsInStockIDList.Contains(CreatedGoodsInStock.GoodsInStockID))
                {
                    var goodsInStockToDelete = entities.GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == CreatedGoodsInStock.GoodsInStockID);
                    entities.GoodsInStock.Remove(goodsInStockToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void InsertTestGoodsInStock()
        {
            GoodsInStockDTO goodsInStock = new GoodsInStockDTO();
            goodsInStock.GoodsID = 12;
            goodsInStock.Quantity = 1;
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDB = mapper.Map<GoodsInStock>(goodsInStock);
                entities.GoodsInStock.Add(goodsInStockInDB);
                entities.SaveChanges();
                TestGoodsInStock = mapper.Map<GoodsInStockDTO>(goodsInStockInDB);
            }
        }

        [Test]
        public void TestGetAllGoodsInStock()
        {
            var GoodsInStockList = goodsInStockDAL.GetAllGoodsInStock();

            Assert.IsNotNull(GoodsInStockList);
            Assert.Contains(TestGoodsInStock.GoodsInStockID, GoodsInStockList.Select(r => r.GoodsInStockID).ToList());
        }

        [Test]
        public void TestGetGoodsInStockByID()
        {
            var GoodsInStockByID = goodsInStockDAL.GetGoodsInStockByID(TestGoodsInStock.GoodsInStockID);

            Assert.IsNotNull(GoodsInStockByID);
            Assert.AreEqual(TestGoodsInStock.GoodsInStockID, GoodsInStockByID.GoodsInStockID);
        }

        [Test]
        public void TestCreateGoodsInStock()
        {
            GoodsInStockDTO newGoodsInStock = new GoodsInStockDTO();
            newGoodsInStock.GoodsID = 12;
            newGoodsInStock.Quantity = 1;
            CreatedGoodsInStock = goodsInStockDAL.CreateGoodsInStock(newGoodsInStock);
            List<GoodsInStockDTO> goodsInStockList;

            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDBList = entities.GoodsInStock.ToList();
                goodsInStockList= mapper.Map<List<GoodsInStockDTO>>(goodsInStockInDBList);
            }
            Assert.IsNotNull(CreatedGoodsInStock);
            Assert.Contains(CreatedGoodsInStock.GoodsInStockID, goodsInStockList.Select(r => r.GoodsInStockID).ToList());
        }

        [Test]
        public void TestUpdateRole()
        {
            TestGoodsInStock.Quantity = 2;
            goodsInStockDAL.UpdateGoodsInStock(TestGoodsInStock);
            GoodsInStockDTO goodsInStock;
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDB = entities.GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == TestGoodsInStock.GoodsInStockID);
                goodsInStock = mapper.Map<GoodsInStockDTO>(goodsInStockInDB);
            }

            Assert.AreEqual(TestGoodsInStock.Quantity, goodsInStock.Quantity);
        }

        [Test]
        public void TestDeleteGoodsInStock()
        {
            goodsInStockDAL.DeleteGoodsInStock(TestGoodsInStock.GoodsInStockID);

            List<GoodsInStockDTO> goodsInStockList;

            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDBList = entities.GoodsInStock.ToList();
                goodsInStockList = mapper.Map<List<GoodsInStockDTO>>(goodsInStockInDBList);
            }

            CollectionAssert.DoesNotContain(goodsInStockList.Select(r => r.GoodsInStockID).ToList(), TestGoodsInStock.GoodsInStockID);
        }
    }
}
