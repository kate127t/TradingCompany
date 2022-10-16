using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IRoleDAL
    {
        RoleDTO CreateRole(RoleDTO role);

        RoleDTO GetRoleByID(int id);
        List<RoleDTO> GetAllRoles();
        void UpdateRole(RoleDTO role);
        void DeleteRole(int id);
    }
}
