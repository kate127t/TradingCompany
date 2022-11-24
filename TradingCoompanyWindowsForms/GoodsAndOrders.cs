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
using TradingCompanyDAL;
using TradingCompanyDTO;

namespace TradingCoompanyWindowsForms
{
    public partial class GoodsAndOrders : Form
    {
        IGoodsInStockManager goodsInStockManager;
        IOrdersManager ordersManager;
        private List<ViewGoodsInStockDTO> goodsInStockList;
        private List<ViewOrderDTO> ordersList;
        UserDTO curUser;
        public GoodsAndOrders(IGoodsInStockManager goodsInStockManager,IOrdersManager ordersManager,UserDTO user)
        {
            InitializeComponent();
            this.goodsInStockManager = goodsInStockManager;
            this.ordersManager=ordersManager;
            this.curUser=user;

            if(curUser.RoleID != 3)
            {
                tabControlGoodsOrders.TabPages.Remove(tabOrders);
            }
            
            RefreshGoodsInStockGrid();
            RefreshOrdersGrid();
        }

        private void RefreshGoodsInStockGrid(string sortingType = "none",string name = "")
        {
            switch (sortingType)
            {
                case "none":
                    goodsInStockList = goodsInStockManager.GetAllViewGoodsInStock();
                    break;
                case "name":
                    goodsInStockList = goodsInStockManager.GetSortedByGoodsProviderViewGoodsInStock();
                    break;
                case "quantity":
                    goodsInStockList = goodsInStockManager.GetSortedByQuantityViewGoodsInStock();
                    break;
                case "find":
                    goodsInStockList = goodsInStockManager.FindByNameViewGoodsInStock(name);
                    break;
                default:
                    goodsInStockList = goodsInStockManager.GetAllViewGoodsInStock();
                    break;
            }
            //dgvGoodsInStock.AutoGenerateColumns= true;
       
            BindingList<ViewGoodsInStockDTO> list = new BindingList<ViewGoodsInStockDTO>(goodsInStockList);
            bsGoodsInStock.DataSource = list;

            //bnGoodsInStock.BindingSource = bsGoodsInStock;
            dgvGoodsInStock.DataSource = bsGoodsInStock.DataSource;
            //dgvGoodsInStock.DataSource = list;

            //dgvGoodsInStock.Show();
        }

        private void RefreshOrdersGrid()
        {
            ordersList = ordersManager.GetAllViewOrders();

            BindingList<ViewOrderDTO> list = new BindingList<ViewOrderDTO>(ordersList);
            bsOrders.DataSource = list;

            bnOrders.BindingSource = bsOrders;
            dgvOrders.DataSource = bsOrders;
        }

        private void GoodsAndOrders_Load(object sender, EventArgs e)
        {
            RefreshGoodsInStockGrid();
            RefreshOrdersGrid();
        }

        private void bnGoodsInStock_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            AddOrder();
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            AddOrder();
        }
        private void AddOrder()
        {
            ManageOrder mo = new ManageOrder(ordersManager, new OrderDTO(), curUser, true);
            if (mo.ShowDialog() == DialogResult.OK)
            {
                RefreshOrdersGrid();
            }
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(dgvOrders.CurrentRow.Index.ToString());
            OrderDTO orderToDelete = ordersManager.GetOrderByID(ordersList[dgvOrders.CurrentRow.Index].OrderID);
            //MessageBox.Show(orderToDelete.GoodsID.ToString());
            ordersManager.DeleteOrder(orderToDelete);
            RefreshOrdersGrid();
        }

        private void cbSortingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGoodsInStockGrid(cbSortingType.Text);
            tbFind.Clear();
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            RefreshGoodsInStockGrid("find",tbFind.Text);
            cbSortingType.SelectedIndex = 0;
        }

        private void dgvOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderDTO orderToEdit = ordersManager.GetOrderByID(ordersList[dgvOrders.CurrentCell.RowIndex].OrderID);
            ManageOrder mo = new ManageOrder(ordersManager, orderToEdit, curUser,false);
            if (mo.ShowDialog() == DialogResult.OK)
            {
                RefreshOrdersGrid();
            }
        }
    }
}
