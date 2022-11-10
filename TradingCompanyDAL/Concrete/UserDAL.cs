using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Concrete
{
    public class UserDAL : IUserDAL
    {
        private readonly IMapper mapper;
        public UserDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public UserDTO CreateUser(UserDTO user, string password)
        {
            user.Password = Hash(password,user.Salt.ToString());
            using (var entities = new TradingCompanyEntities())
            {
                var userInDB = mapper.Map<User>(user);
                entities.User.Add(userInDB);
                entities.SaveChanges();
                return mapper.Map<UserDTO>(userInDB);
            }
        }

        public void DeleteUser(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var userToDelete = entities.User.FirstOrDefault(x => x.UserID == id);
                entities.User.Remove(userToDelete);
                entities.SaveChanges();
            }
        }

        public UserDTO GetUserByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var user = entities.User.FirstOrDefault(x => x.UserID == id);
                return mapper.Map<UserDTO>(user);
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var users = entities.User.ToList();
                return mapper.Map<List<UserDTO>>(users);
            }
        }

        public void UpdateUser(UserDTO user)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var userInDB = entities.User.FirstOrDefault(x => x.UserID == user.UserID);
                //userInDB = mapper.Map<User>(user);
                userInDB.Login = user.Login;
                //userInDB.Password = user.Password;
                userInDB.FirstName = user.FirstName;
                userInDB.LastName = user.LastName;
                userInDB.RoleID = user.RoleID;
                entities.SaveChanges();
            }
        }

        public byte[] Hash (string password,string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}

