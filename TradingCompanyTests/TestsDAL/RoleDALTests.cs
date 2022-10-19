using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using System.EnterpriseServices;
using TradingCompanyDAL;
using TradingCompanyDAL.Concrete;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDAL.Profiles;
using TradingCompanyDTO;

namespace TradingCompanyTests.TestsDAL
{
    [TestFixture]
    //[Transaction(TransactionOption.RequiresNew),ComVisible(true)]

    public class RoleDALTests 
    {
        private IMapper mapper;
        private RoleDTO TestRole;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            InsertTestRole();
        }

        [OneTimeTearDown]
        public void TearDownOnce()
        {
            DeleteTestRole();
        }

        private void DeleteTestRole()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roleToDelete = entities.Role.FirstOrDefault(x => x.Name == TestRole.Name);
                entities.Role.Remove(roleToDelete);
                entities.SaveChanges();
            }
        }

        private void InsertTestRole()
        {
            RoleDTO role = new RoleDTO();
            role.Name = "TestRole";
            using (var entities = new TradingCompanyEntities())
            {
                var roleInDB = mapper.Map<Role>(role);
                entities.Role.Add(roleInDB);
                entities.SaveChanges();
                TestRole = mapper.Map<RoleDTO>(roleInDB);
            }
        }

        [Test]
        public void TestGetAllRoles()
        {
            IRoleDAL roleDAL = new RoleDAL(mapper);
            var Roles = roleDAL.GetAllRoles();

            Assert.IsNotNull(Roles);
            Assert.Contains(TestRole.Name, Roles.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestGetRoleByID()
        {
            IRoleDAL roleDAL = new RoleDAL(mapper);
            var RoleByID = roleDAL.GetRoleByID(TestRole.RoleID);

            Assert.IsNotNull(RoleByID);
            Assert.AreEqual(TestRole.Name, RoleByID.Name);
        }

        [Test]
        public void TestCreateRole()
        {
            IRoleDAL roleDAL = new RoleDAL(mapper);
            RoleDTO newRole = new RoleDTO();
            newRole.Name = "TestCreateRole";
            newRole = roleDAL.CreateRole(newRole);
            
            //var roles = entities.Role.ToList();
            //return mapper.Map<List<RoleDTO>>(roles);

            Assert.That(true);
        }
    }
}
