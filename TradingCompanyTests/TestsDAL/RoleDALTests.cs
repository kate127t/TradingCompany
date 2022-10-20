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

    public class RoleDALTests 
    {
        private IMapper mapper;
        private IRoleDAL roleDAL;
        private RoleDTO TestRole;
        private RoleDTO CreatedRole;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.roleDAL = new RoleDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestRole();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestRole();
            DeleteCreatedRole();
        }

        private void DeleteTestRole()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var rolesInDB = entities.Role.ToList();
                var roles = mapper.Map<List<RoleDTO>>(rolesInDB);
                var rolesID = roles.Select(r=> r.RoleID).ToList();
                if (rolesID.Contains(TestRole.RoleID))
                {
                    var roleToDelete = entities.Role.FirstOrDefault(x => x.RoleID == TestRole.RoleID);
                    entities.Role.Remove(roleToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedRole()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var rolesInDB = entities.Role.ToList();
                var roles = mapper.Map<List<RoleDTO>>(rolesInDB);
                var rolesNames = roles.Select(r => r.RoleID).ToList();
                if (rolesNames.Contains(CreatedRole.RoleID))
                {
                    var roleToDelete = entities.Role.FirstOrDefault(x => x.RoleID == CreatedRole.RoleID);
                    entities.Role.Remove(roleToDelete);
                    entities.SaveChanges();
                }
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
            var Roles = roleDAL.GetAllRoles();

            Assert.IsNotNull(Roles);
            Assert.Contains(TestRole.Name, Roles.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestGetRoleByID()
        {
            var RoleByID = roleDAL.GetRoleByID(TestRole.RoleID);

            Assert.IsNotNull(RoleByID);
            Assert.AreEqual(TestRole.Name, RoleByID.Name);
        }

        [Test]
        public void TestCreateRole()
        {
            RoleDTO newRole = new RoleDTO();
            newRole.Name = "CreatedRole";
            CreatedRole = roleDAL.CreateRole(newRole);
            List<RoleDTO> roles;

            using (var entities = new TradingCompanyEntities())
            {
                var rolesInDB = entities.Role.ToList();
                roles = mapper.Map<List<RoleDTO>>(rolesInDB);
            }

            Assert.IsNotNull(CreatedRole);
            Assert.Contains(newRole.Name, roles.Select(r => r.Name).ToList());
        }

        [Test]
        public void TestUpdateRole()
        {
            TestRole.Name = "UpdatedTestRole";
            roleDAL.UpdateRole(TestRole);
            RoleDTO role;
            using (var entities = new TradingCompanyEntities())
            {
                var roleInDB = entities.Role.FirstOrDefault(x => x.RoleID == TestRole.RoleID);
                role = mapper.Map<RoleDTO>(roleInDB);
            }

            Assert.AreEqual(TestRole.Name, role.Name);
        }

        [Test]
        public void TestDeleteRole()
        {
            roleDAL.DeleteRole(TestRole.RoleID);

            List<RoleDTO> roles;

            using (var entities = new TradingCompanyEntities())
            {
                var rolesInDB = entities.Role.ToList();
                roles = mapper.Map<List<RoleDTO>>(rolesInDB);
            }

            CollectionAssert.DoesNotContain(roles.Select(r => r.RoleID).ToList(), TestRole.RoleID);
        }
    }
}
