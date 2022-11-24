using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyBLL.Concrete;
using TradingCompanyBLL.Interfaces;
using TradingCompanyDAL.Concrete;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyTests.TestsBLL
{
    [TestFixture]
    public class AuthManagerTests
    {
        private Mock<IUserDAL> userDAL;
        private AuthManager authManager;

        [SetUp]
        public void Setup()
        {
            userDAL = new Mock<IUserDAL>(MockBehavior.Strict);

            this.authManager = new AuthManager(userDAL.Object);
        }

        [Test]
        public void TestGetUserByLogin()
        {
            string expectedLogin = "login123";
            UserDTO expectedUser = new UserDTO()
            {
                UserID = 1,
                Login = expectedLogin,

            };

            userDAL.Setup(d => d.GetUserByLogin(expectedLogin)).Returns(expectedUser);

            UserDTO actualUser = authManager.GetUserByLogin(expectedLogin);

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(actualUser, expectedUser);

        }

        [Test]
        public void TestLoginWrongInput()
        {
            string login = "login";
            string password = "password";

            userDAL.Setup(d => d.Login(login, password)).Returns(false);

            bool actualRes = authManager.Login(login, password);

            Assert.IsFalse(actualRes);
        }

        [Test]
        public void TestLoginCorrectInput()
        {
            string login = "login";
            string password = "password";

            userDAL.Setup(d => d.Login(login, password)).Returns(true);

            bool actualRes = authManager.Login(login, password);

            Assert.IsTrue(actualRes);
        }
    }
}
