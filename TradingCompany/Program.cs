using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Concrete;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDAL.Profiles;
using TradingCompanyDTO;

namespace TradingCompany
{
    internal class Program
    {
        static IMapper mapper = SetupMapper();
        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            return config.CreateMapper();
        }

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine(@"Welcome to the trading company!
Which table would you like to test?
1.User
2.Role
3.Exit
Choose your option:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        UserMenu();
                        break;
                    case "2":
                        RoleMenu();
                        break;
                    case "3":
                        showMenu = false;
                        break;
                    default:
                        showMenu = false;
                        break;

                }
            }
        }

        private static void RoleMenu()
        {
            IRoleDAL roleDAL = new RoleDAL(mapper);
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine(@"What action do you want to do?
1.Create new role
2.Get role by id
3.Get all roles
4.Update role name
5.Delete role
6.Return to main menu
Choose your option:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RoleDTO newRole = new RoleDTO();
                        Console.WriteLine("Write the name of the role:");
                        newRole.Name = Console.ReadLine();
                        roleDAL.CreateRole(newRole);
                        break;
                    case "2":
                        Console.WriteLine("Enter role`s id:");
                        int id = Int32.Parse(Console.ReadLine());
                        RoleDTO roleByID = roleDAL.GetRoleByID(id);
                        Console.WriteLine(roleByID.ToString());
                        break;
                    case "3":
                        List<RoleDTO> roles = roleDAL.GetAllRoles();
                        for (int i = 0; i < roles.Count; i++)
                        {
                            Console.WriteLine(roles[i].ToString());
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter role`s id:");
                        int id1 = Int32.Parse(Console.ReadLine());
                        RoleDTO updatedRole = roleDAL.GetRoleByID(id1);
                        Console.WriteLine("Write the changed name of the role:");
                        updatedRole.Name = Console.ReadLine();
                        roleDAL.UpdateRole(updatedRole);
                        break;
                    case "5":
                        Console.WriteLine("Enter role`s id:");
                        int id2 = Int32.Parse(Console.ReadLine());
                        roleDAL.DeleteRole(id2);
                        break;
                    case "6":
                        showMenu = false;
                        break;
                    default:
                        showMenu = false;
                        break;
                }
            }
        }

        private static void UserMenu()
        {
            IUserDAL userDAL = new UserDAL(mapper);
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine(@"What action do you want to do
1.Create new user
2.Get user by id
3.Get all users
4.Update user`s first name and last name
5.Delete user
6.Return to main menu
Choose your option:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        UserDTO user = ReadNewUserFromConsole();
                        userDAL.CreateUser(user);
                        break;
                    case "2":
                        Console.WriteLine("Enter user`s id:");
                        int id = Int32.Parse(Console.ReadLine());
                        UserDTO userByID = userDAL.GetUserByID(id);
                        Console.WriteLine(userByID.ToString());
                        break;
                    case "3":
                        List<UserDTO> users = userDAL.GetAllUsers();
                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.WriteLine(users[i].ToString());
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter user`s id:");
                        int id1 = Int32.Parse(Console.ReadLine());
                        UserDTO updatedUser = userDAL.GetUserByID(id1);
                        Console.WriteLine("Write the changed first name:");
                        updatedUser.FirstName = Console.ReadLine();
                        userDAL.UpdateUser(updatedUser);
                        break;
                    case "5":
                        Console.WriteLine("Enter user`s id:");
                        int id2 = Int32.Parse(Console.ReadLine());
                        userDAL.DeleteUser(id2);
                        break;
                    case "6":
                        showMenu = false;
                        break;
                    default:
                        showMenu = false;
                        break;
                }
            }
        }

        private static UserDTO ReadNewUserFromConsole()
        {
            UserDTO user = new UserDTO();
            Console.WriteLine("Enter properties of the new user:");
            Console.WriteLine("Login: ");
            user.Login = Console.ReadLine();
            Console.WriteLine("Password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("First name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("RoleID: ");
            user.RoleID = Int32.Parse(Console.ReadLine());
            return user;
        }
    }
}
