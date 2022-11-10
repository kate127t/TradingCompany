using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Concrete;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDAL;
using TradingCompanyDTO;
using TradingCompanyDAL.Profiles;
using NUnit.Framework.Internal;

namespace TradingCompanyTests.TestsDAL
{
    [TestFixture]
    public class GoodsAndProvidersDALTests
    {
        private IMapper mapper;
        private IGoodsAndProvidersDAL goodsAndProvidersDAL;
        private GoodsAndProvidersDTO TestGoodsAndProviders;
        private GoodsAndProvidersDTO CreatedGoodsAndProviders;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.goodsAndProvidersDAL = new GoodsAndProvidersDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestGoodsAndProviders();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestGoodsAndProviders();
            DeleteCreatedGoodsAndProviders();
        }

        private void DeleteTestGoodsAndProviders()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDBList = entities.GoodsAndProviders.ToList();
                var goodsAndProvidersList = mapper.Map<List<GoodsAndProvidersDTO>>(goodsAndProvidersInDBList);
                var goodsAndProvidersIDList = goodsAndProvidersList.Select(r => r.GoodsAndProvidersID).ToList();
                if (goodsAndProvidersIDList.Contains(TestGoodsAndProviders.GoodsAndProvidersID))
                {
                    var goodsAndProvidersToDelete = entities.GoodsAndProviders.FirstOrDefault(x => x.GoodsAndProvidersID == TestGoodsAndProviders.GoodsAndProvidersID);
                    entities.GoodsAndProviders.Remove(goodsAndProvidersToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedGoodsAndProviders()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDBList = entities.GoodsAndProviders.ToList();
                var goodsAndProvidersList = mapper.Map<List<GoodsAndProvidersDTO>>(goodsAndProvidersInDBList);
                var goodsIDList = goodsAndProvidersList.Select(r => r.GoodsAndProvidersID).ToList();
                if (CreatedGoodsAndProviders != null && goodsIDList.Contains(CreatedGoodsAndProviders.GoodsAndProvidersID))
                {
                    var goodsAndProvidersToDelete = entities.GoodsAndProviders.FirstOrDefault(x => x.GoodsAndProvidersID == CreatedGoodsAndProviders.GoodsAndProvidersID);
                    entities.GoodsAndProviders.Remove(goodsAndProvidersToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void InsertTestGoodsAndProviders()
        {
            GoodsAndProvidersDTO goodsAndProviders = new GoodsAndProvidersDTO();
            goodsAndProviders.GoodsID = 1;
            goodsAndProviders.ProviderID = 1;
            goodsAndProviders.Price = 10.3;
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDBList = mapper.Map<GoodsAndProviders>(goodsAndProviders);
                entities.GoodsAndProviders.Add(goodsAndProvidersInDBList);
                entities.SaveChanges();
                TestGoodsAndProviders = mapper.Map<GoodsAndProvidersDTO>(goodsAndProvidersInDBList);
            }
        }

        [Test]
        public void TestGetAllGoodsAndProviders()
        {
            var GoodsAndProvidersList = goodsAndProvidersDAL.GetAllGoodsAndProviders();

            Assert.IsNotNull(GoodsAndProvidersList);
            Assert.Contains(TestGoodsAndProviders.GoodsAndProvidersID, GoodsAndProvidersList.Select(r => r.GoodsAndProvidersID).ToList());
        }

        [Test]
        public void TestGetGoodsAndProvidersByID()
        {
            var GoodsAndProvidersByID = goodsAndProvidersDAL.GetGoodsAndProvidersByID(TestGoodsAndProviders.GoodsAndProvidersID);

            Assert.IsNotNull(GoodsAndProvidersByID);
            Assert.IsNotNull(GoodsAndProvidersByID.GoodsAndProvidersID);
            Assert.IsNotNull(GoodsAndProvidersByID.GoodsID);
            Assert.IsNotNull(GoodsAndProvidersByID.ProviderID);
            //Assert.AreEqual(TestGoodsAndProviders.Name, GoodsAndProvidersByID.Name);
        }

        [Test]
        public void TestCreateGoodsAndProviders()
        {
            GoodsAndProvidersDTO newGoodsAndProviders = new GoodsAndProvidersDTO();
            newGoodsAndProviders.GoodsID = 1;
            newGoodsAndProviders.ProviderID = 1;
            newGoodsAndProviders.Price = 7.4;
            //newGoods.ProviderID = 7;
            CreatedGoodsAndProviders = goodsAndProvidersDAL.CreateGoodsAndProviders(newGoodsAndProviders);
            List<GoodsAndProvidersDTO> goodsAndProvidersList;

            //using (var entities = new TradingCompanyEntities())
            //{
            //    var goodsAndProvidersInDBList = entities.GoodsAndProviders.ToList();
            //    goodsAndProvidersList= mapper.Map<List<GoodsAndProvidersDTO>>(goodsAndProvidersInDBList);
            //}

            Assert.IsNotNull(CreatedGoodsAndProviders);
            //Assert.Contains(newGoodsAndProviders.Name, goodsAndProvidersList.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestUpdateGoodsAndProviders()
        {
            TestGoodsAndProviders.Price += 30;
            goodsAndProvidersDAL.UpdateGoodsAndProviders(TestGoodsAndProviders);
            GoodsAndProvidersDTO goodsAndProviders;
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDB = entities.GoodsAndProviders.FirstOrDefault(x => x.GoodsAndProvidersID == TestGoodsAndProviders.GoodsAndProvidersID);
                goodsAndProviders = mapper.Map<GoodsAndProvidersDTO>(goodsAndProvidersInDB);
            }

            Assert.AreEqual(TestGoodsAndProviders.Price, goodsAndProviders.Price);
        }

        [Test]
        public void TestDeleteGoodsAndProviders()
        {
            goodsAndProvidersDAL.DeleteGoodsAndProviders(TestGoodsAndProviders.GoodsAndProvidersID);

            List<GoodsAndProvidersDTO> goodsAndProvidersList;

            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDBList = entities.GoodsAndProviders.ToList();
                goodsAndProvidersList = mapper.Map<List<GoodsAndProvidersDTO>>(goodsAndProvidersInDBList);
            }

            CollectionAssert.DoesNotContain(goodsAndProvidersList.Select(r => r.GoodsAndProvidersID).ToList(), TestGoodsAndProviders.GoodsAndProvidersID);
        }
    }
}
