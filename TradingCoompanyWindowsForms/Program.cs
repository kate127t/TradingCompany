using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompanyBLL.Interfaces;
using TradingCompanyBLL.Concrete;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDAL.Concrete;
using AutoMapper;
using TradingCompanyDAL.Profiles;
using Unity;
using TradingCompanyDTO;
using Unity.Resolution;

namespace TradingCoompanyWindowsForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static IMapper mapper = SetupMapper();
        static UnityContainer Container;
        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(RoleProfile).Assembly));
            return config.CreateMapper();
        }

        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            //DAL
            IGoodsInStockDAL goodsInStockDAL = new GoodsInStockDAL(mapper);
            IOrderDAL orderDAL = new OrderDAL(mapper);
            IGoodsDAL goodsDAL = new GoodsDAL(mapper);
            IProviderDAL providerDAL = new ProviderDAL(mapper);
            IGoodsAndProvidersDAL goodsAndProvidersDAL = new GoodsAndProvidersDAL(mapper);
            IViewGoodsInStockDAL viewGoodsInStockDAL = new ViewGoodsInStockDAL(mapper);
            IViewOrderDAL viewOrderDAL = new ViewOrderDAL(mapper);
            IUserDAL userDAL = new UserDAL(mapper);

            //BLL
            IGoodsInStockManager goodsInStockManager = new GoodsInStockManager(goodsInStockDAL,viewGoodsInStockDAL);
            IOrdersManager ordersManager = new OrdersManager(orderDAL,goodsDAL,providerDAL,goodsAndProvidersDAL,viewOrderDAL);
            //IAuthManager authManager = new AuthManager(userDAL);

           

            LoginForm lf =  Container.Resolve<LoginForm>();
            if(lf.ShowDialog() == DialogResult.OK)
            {
                UserDTO curUser = lf.curUser;
                Application.Run(new GoodsAndOrders(goodsInStockManager, ordersManager,curUser));
            }
            else
            {
                Application.Exit();
            }

            //Windows Form
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //var lf = new LoginForm(authManager);
            ////lf.ShowDialog();
            //if(lf.ShowDialog() == DialogResult.OK)
            //{
            //    UserDTO curUser = lf.curUser;
            //    var mainf = new GoodsAndOrders(goodsInStockManager, ordersManager, curUser);
            //}
            //Application.Run(new LoginForm(authManager));
            //Application.Run(new GoodsAndOrders(goodsInStockManager, ordersManager));
        }

        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(RoleProfile).Assembly);
                });

            Container= new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IGoodsAndProvidersDAL, GoodsAndProvidersDAL>()
                     .RegisterType<IGoodsDAL, GoodsDAL>()
                     .RegisterType<IGoodsInStockDAL, GoodsInStockDAL>()
                     .RegisterType<IOrderDAL, OrderDAL>()
                     .RegisterType<IProviderDAL, ProviderDAL>()
                     .RegisterType<IRoleDAL, RoleDAL>()
                     .RegisterType<IUserDAL, UserDAL>()
                     .RegisterType<IViewGoodsInStockDAL, ViewGoodsInStockDAL>()
                     .RegisterType<IViewOrderDAL, ViewOrderDAL>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IGoodsInStockManager, GoodsInStockManager>()
                     .RegisterType<IOrdersManager, OrdersManager>();
        }
    }
}
