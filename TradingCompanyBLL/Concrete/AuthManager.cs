using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyBLL.Interfaces;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyBLL.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserDAL userDAL;
        public AuthManager(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public UserDTO GetUserByLogin(string login)
        {
            return userDAL.GetUserByLogin(login);
        }

        public bool Login(string login, string password)
        {
           return userDAL.Login(login, password);
        }
    }
}
