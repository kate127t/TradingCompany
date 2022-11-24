using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IUserDAL
    {
        UserDTO CreateUser(UserDTO user, string password);
        UserDTO GetUserByLogin(string login);
        bool Login(string login,string password);
        UserDTO GetUserByID(int id);
        List<UserDTO> GetAllUsers();
        void UpdateUser(UserDTO user);
        void DeleteUser(int id);
        byte[] Hash(string Password, string Salt);
    }
}
