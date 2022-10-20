using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Concrete
{
    public class RoleDAL : IRoleDAL
    {
        private readonly IMapper mapper;
        public RoleDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public RoleDTO CreateRole(RoleDTO role)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roleInDB = mapper.Map<Role>(role);
                entities.Role.Add(roleInDB);
                entities.SaveChanges();
                return mapper.Map<RoleDTO>(roleInDB);
            }
        }

        public void DeleteRole(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roleToDelete = entities.Role.FirstOrDefault(x => x.RoleID == id);
                entities.Role.Remove(roleToDelete);
                entities.SaveChanges();
            }
        }

        public List<RoleDTO> GetAllRoles()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roles = entities.Role.ToList();
                return mapper.Map<List<RoleDTO>>(roles);

            }
        }

        public RoleDTO GetRoleByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var role = entities.Role.FirstOrDefault(x => x.RoleID == id);
                return mapper.Map<RoleDTO>(role);
            }
        }

        public void UpdateRole(RoleDTO role)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roleInDB = entities.Role.FirstOrDefault(x => x.RoleID == role.RoleID);
                //roleInDB = mapper.Map<Role>(role);
                roleInDB.Name = role.Name;
                entities.SaveChanges();
            }
        }
    }
}
