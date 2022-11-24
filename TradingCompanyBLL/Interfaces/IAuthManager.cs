using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyBLL.Interfaces
{
    public interface IAuthManager
    {
        bool Login(string login, string password);
        UserDTO GetUserByLogin(string login);
    }
}
