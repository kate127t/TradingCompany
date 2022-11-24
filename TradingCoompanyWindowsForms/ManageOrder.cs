using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompanyBLL.Interfaces;
using TradingCompanyDTO;

namespace TradingCoompanyWindowsForms
{
    public partial class ManageOrder : Form
    {
        private readonly IOrdersManager ordersManager;
        List<GoodsDTO> listGoods;
        List<ProviderDTO> listProviders;
        OrderDTO order;
        UserDTO curUser;
        bool CreateNew;
        public ManageOrder(IOrdersManager ordersManager,OrderDTO order,UserDTO curUser,bool CreateNew = false)
        {
            InitializeComponent();
            this.order = order;
            this.curUser = curUser; 
            this.ordersManager = ordersManager;
            this.CreateNew = CreateNew;
            
            RefreshGoods();
            RefreshProviders();

            if (!CreateNew)
            {
                SetCurrentProperties();
            }
        }

        private void SetCurrentProperties()
        {
            cbGoods.SelectedIndex = listGoods.FindIndex(x => x.GoodsID == order.GoodsID);
            RefreshProviders();
            cbProviders.SelectedIndex = listProviders.FindIndex(x => x.ProviderID == order.ProviderID);
            mcDateArrives.SelectionStart = order.DateArrives;
            mcDateArrives.SelectionEnd = order.DateArrives;
            nudQuantity.Value = order.Quantity;
        }

        private void RefreshGoods()
        {
            listGoods = ordersManager.GetAllGoods();
            cbGoods.DataSource = listGoods;
        }

        private void RefreshProviders()
        {
            GoodsDTO curGoods = listGoods[cbGoods.SelectedIndex];
                listProviders = ordersManager.GetAllProvidersByGoodsID(curGoods.GoodsID);
                cbProviders.DataSource = listProviders;
        }

        private void cbGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProviders();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            GatherDataForOrder();

            if (CreateNew)
            {
                ordersManager.AddOrder(order);
            }
            else {
                ordersManager.UpdateOrder(order);
            }
        }

        private void GatherDataForOrder()
        {
            order.GoodsID = listGoods[cbGoods.SelectedIndex].GoodsID;
            order.ProviderID = listProviders[cbProviders.SelectedIndex].ProviderID;
            //DateTime a = mcDateArrives.SelectionStart;
            order.DateArrives = mcDateArrives.SelectionRange.Start;
            order.Quantity = int.Parse(nudQuantity.Value.ToString());
            if (CreateNew)
            {
                order.DateOrdered = DateTime.Now;
                order.ManagerID = curUser.UserID;
            }
        }
    }
}
