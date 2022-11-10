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
    public class ProviderDALTests
    {
        private IMapper mapper;
        private IProviderDAL providerDAL;
        private ProviderDTO TestProvider;
        private ProviderDTO CreatedProvider;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.providerDAL = new ProviderDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestProvider();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestProvider();
            DeleteCreatedProvider();
        }

        private void DeleteTestProvider()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var providersInDB = entities.Provider.ToList();
                var providers = mapper.Map<List<ProviderDTO>>(providersInDB);
                var providersID = providers.Select(r => r.ProviderID).ToList();
                if (providersID.Contains(TestProvider.ProviderID))
                {
                    var providerToDelete = entities.Provider.FirstOrDefault(x => x.ProviderID == TestProvider.ProviderID);
                    entities.Provider.Remove(providerToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedProvider()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var providersInDB = entities.Provider.ToList();
                var providers = mapper.Map<List<ProviderDTO>>(providersInDB);
                var providersID = providers.Select(r => r.ProviderID).ToList();
                if (CreatedProvider != null && providersID.Contains(CreatedProvider.ProviderID))
                {
                    var providerToDelete = entities.Provider.FirstOrDefault(x => x.ProviderID == CreatedProvider.ProviderID);
                    entities.Provider.Remove(providerToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void InsertTestProvider()
        {
            ProviderDTO provider = new ProviderDTO();
            provider.Name = "TestProvider";
            provider.PhoneNumber = "000";
            using (var entities = new TradingCompanyEntities())
            {
                var providerInDB = mapper.Map<Provider>(provider);
                entities.Provider.Add(providerInDB);
                entities.SaveChanges();
                TestProvider = mapper.Map<ProviderDTO>(providerInDB);
            }
        }

        [Test]
        public void TestGetAllProviders()
        {
            var Providers = providerDAL.GetAllProviders();

            Assert.IsNotNull(Providers);
            Assert.Contains(TestProvider.Name, Providers.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestGetProviderByID()
        {
            var ProviderByID = providerDAL.GetProviderByID(TestProvider.ProviderID);

            Assert.IsNotNull(ProviderByID);
            Assert.AreEqual(TestProvider.Name, ProviderByID.Name);
        }

        [Test]
        public void TestCreateProvider()
        {
            ProviderDTO newProvider = new ProviderDTO();
            newProvider.Name = "CreatedProvider";
            newProvider.PhoneNumber = "000";
            CreatedProvider = providerDAL.CreateProvider(newProvider);
            List<ProviderDTO> providers;

            using (var entities = new TradingCompanyEntities())
            {
                var providersInDB = entities.Provider.ToList();
                providers = mapper.Map<List<ProviderDTO>>(providersInDB);
            }

            Assert.IsNotNull(CreatedProvider);
            Assert.Contains(newProvider.Name, providers.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestUpdateProvider()
        {
            TestProvider.Name = "UpdatedTestProvider";
            providerDAL.UpdateProvider(TestProvider);
            ProviderDTO provider;
            using (var entities = new TradingCompanyEntities())
            {
                var providerInDB = entities.Provider.FirstOrDefault(x => x.ProviderID == TestProvider.ProviderID);
                provider = mapper.Map<ProviderDTO>(providerInDB);
            }

            Assert.AreEqual(TestProvider.Name, provider.Name);
        }

        [Test]
        public void TestDeleteProvider()
        {
            providerDAL.DeleteProvider(TestProvider.ProviderID);

            List<ProviderDTO> providers;

            using (var entities = new TradingCompanyEntities())
            {
                var providersInDB = entities.Provider.ToList();
                providers = mapper.Map<List<ProviderDTO>>(providersInDB);
            }

            CollectionAssert.DoesNotContain(providers.Select(r => r.ProviderID).ToList(), TestProvider.ProviderID);
        }
    }
}
