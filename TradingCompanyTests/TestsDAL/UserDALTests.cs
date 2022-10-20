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
    public class UserDALTests
    {
        private IMapper mapper;
        private IUserDAL userDAL;
        private UserDTO TestUser;
        private UserDTO CreatedUser;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            this.mapper = config.CreateMapper();
            this.userDAL = new UserDAL(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            InsertTestUser();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteTestUser();
            DeleteCreatedUser();
        }

        private void DeleteTestUser()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var usersInDB = entities.User.ToList();
                var users = mapper.Map<List<UserDTO>>(usersInDB);
                var usersID = users.Select(r => r.UserID).ToList();
                if (usersID.Contains(TestUser.UserID))
                {
                    var userToDelete = entities.User.FirstOrDefault(x => x.UserID == TestUser.UserID);
                    entities.User.Remove(userToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void DeleteCreatedUser()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var usersInDB = entities.User.ToList();
                var users = mapper.Map<List<UserDTO>>(usersInDB);
                var usersNames = users.Select(r => r.UserID).ToList();
                if (usersNames.Contains(CreatedUser.UserID))
                {
                    var userToDelete = entities.User.FirstOrDefault(x => x.UserID == CreatedUser.UserID);
                    entities.User.Remove(userToDelete);
                    entities.SaveChanges();
                }
            }
        }

        private void InsertTestUser()
        {
            UserDTO user = new UserDTO();
            user.Login = "TestUser";
            user.Password = "TU12";
            user.FirstName = "Test";
            user.LastName = "User";
            user.RoleID = 235;
            using (var entities = new TradingCompanyEntities())
            {
                var userInDB = mapper.Map<User>(user);
                entities.User.Add(userInDB);
                entities.SaveChanges();
                TestUser = mapper.Map<UserDTO>(userInDB);
            }
        }

        [Test]
        public void TestGetAllUsers()
        {
            var Users = userDAL.GetAllUsers();

            Assert.IsNotNull(Users);
            Assert.Contains(TestUser.Login, Users.Select(r => r.Login).ToList());
        }

        [Test]
        public void TestGetUserByID()
        {
            var UserByID = userDAL.GetUserByID(TestUser.UserID);

            Assert.IsNotNull(UserByID);
            Assert.AreEqual(TestUser.Login, UserByID.Login);
        }

        [Test]
        public void TestCreateUser()
        {
            UserDTO newUser = new UserDTO();
            newUser.Login = "CreatedUser";
            newUser.Password = "TU12";
            newUser.FirstName = "Created";
            newUser.LastName = "User";
            newUser.RoleID = 235;
            CreatedUser = userDAL.CreateUser(newUser);
            List<UserDTO> users;

            using (var entities = new TradingCompanyEntities())
            {
                var usersInDB = entities.User.ToList();
                users = mapper.Map<List<UserDTO>>(usersInDB);
            }

            Assert.IsNotNull(CreatedUser);
            Assert.Contains(newUser.Login, users.Select(r => r.Login).ToList());
        }

        [Test]
        public void TestUpdateUser()
        {
            TestUser.Login = "UpdatedTestUser";
            userDAL.UpdateUser(TestUser);
            UserDTO user;
            using (var entities = new TradingCompanyEntities())
            {
                var userInDB = entities.User.FirstOrDefault(x => x.UserID == TestUser.UserID);
                user = mapper.Map<UserDTO>(userInDB);
            }

            Assert.AreEqual(TestUser.Login, user.Login);
        }

        [Test]
        public void TestDeleteUser()
        {
            userDAL.DeleteUser(TestUser.UserID);

            List<UserDTO> users;

            using (var entities = new TradingCompanyEntities())
            {
                var usersInDB = entities.User.ToList();
                users = mapper.Map<List<UserDTO>>(usersInDB);
            }

            CollectionAssert.DoesNotContain(users.Select(r => r.UserID).ToList(), TestUser.UserID);
        }
    }
}
