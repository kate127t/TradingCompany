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
        UserDTO CreateUser(UserDTO user);
        UserDTO GetUserByID(int id);
        List<UserDTO> GetAllUsers();
        void UpdateUser(UserDTO user);
        void DeleteUser(int id);
    }
}
