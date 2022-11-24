namespace TradingCoompanyWindowsForms
{
    partial class GoodsAndOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsAndOrders));
            this.tabControlGoodsOrders = new System.Windows.Forms.TabControl();
            this.tabGoodsInStock = new System.Windows.Forms.TabPage();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSortingType = new System.Windows.Forms.ComboBox();
            this.dgvGoodsInStock = new System.Windows.Forms.DataGridView();
            this.goodsInStockIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProviderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsGoodsInStock = new System.Windows.Forms.BindingSource(this.components);
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.bnOrders = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bsOrders = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateArrivesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlGoodsOrders.SuspendLayout();
            this.tabGoodsInStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGoodsInStock)).BeginInit();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnOrders)).BeginInit();
            this.bnOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGoodsOrders
            // 
            this.tabControlGoodsOrders.Controls.Add(this.tabGoodsInStock);
            this.tabControlGoodsOrders.Controls.Add(this.tabOrders);
            this.tabControlGoodsOrders.Location = new System.Drawing.Point(-1, 0);
            this.tabControlGoodsOrders.Name = "tabControlGoodsOrders";
            this.tabControlGoodsOrders.SelectedIndex = 0;
            this.tabControlGoodsOrders.Size = new System.Drawing.Size(887, 451);
            this.tabControlGoodsOrders.TabIndex = 0;
            this.tabControlGoodsOrders.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabGoodsInStock
            // 
            this.tabGoodsInStock.Controls.Add(this.tbFind);
            this.tabGoodsInStock.Controls.Add(this.label2);
            this.tabGoodsInStock.Controls.Add(this.label1);
            this.tabGoodsInStock.Controls.Add(this.cbSortingType);
            this.tabGoodsInStock.Controls.Add(this.dgvGoodsInStock);
            this.tabGoodsInStock.Location = new System.Drawing.Point(4, 25);
            this.tabGoodsInStock.Name = "tabGoodsInStock";
            this.tabGoodsInStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoodsInStock.Size = new System.Drawing.Size(879, 422);
            this.tabGoodsInStock.TabIndex = 0;
            this.tabGoodsInStock.Text = "GoodsInStock";
            this.tabGoodsInStock.UseVisualStyleBackColor = true;
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(380, 13);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(170, 22);
            this.tbFind.TabIndex = 4;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sort by";
            // 
            // cbSortingType
            // 
            this.cbSortingType.FormattingEnabled = true;
            this.cbSortingType.Items.AddRange(new object[] {
            "none",
            "name",
            "quantity"});
            this.cbSortingType.Location = new System.Drawing.Point(64, 11);
            this.cbSortingType.Name = "cbSortingType";
            this.cbSortingType.Size = new System.Drawing.Size(181, 24);
            this.cbSortingType.TabIndex = 1;
            this.cbSortingType.SelectedIndexChanged += new System.EventHandler(this.cbSortingType_SelectedIndexChanged);
            // 
            // dgvGoodsInStock
            // 
            this.dgvGoodsInStock.AutoGenerateColumns = false;
            this.dgvGoodsInStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsInStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodsInStockIDDataGridViewTextBoxColumn,
            this.GoodsName,
            this.ProviderName,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvGoodsInStock.DataSource = this.bsGoodsInStock;
            this.dgvGoodsInStock.Location = new System.Drawing.Point(0, 41);
            this.dgvGoodsInStock.Name = "dgvGoodsInStock";
            this.dgvGoodsInStock.RowHeadersWidth = 51;
            this.dgvGoodsInStock.RowTemplate.Height = 24;
            this.dgvGoodsInStock.Size = new System.Drawing.Size(883, 405);
            this.dgvGoodsInStock.TabIndex = 0;
            // 
            // goodsInStockIDDataGridViewTextBoxColumn
            // 
            this.goodsInStockIDDataGridViewTextBoxColumn.DataPropertyName = "GoodsInStockID";
            this.goodsInStockIDDataGridViewTextBoxColumn.HeaderText = "GoodsInStockID";
            this.goodsInStockIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.goodsInStockIDDataGridViewTextBoxColumn.Name = "goodsInStockIDDataGridViewTextBoxColumn";
            this.goodsInStockIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // GoodsName
            // 
            this.GoodsName.DataPropertyName = "GoodsName";
            this.GoodsName.HeaderText = "GoodsName";
            this.GoodsName.MinimumWidth = 6;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Width = 125;
            // 
            // ProviderName
            // 
            this.ProviderName.DataPropertyName = "ProviderName";
            this.ProviderName.HeaderText = "ProviderName";
            this.ProviderName.MinimumWidth = 6;
            this.ProviderName.Name = "ProviderName";
            this.ProviderName.Width = 125;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 125;
            // 
            // bsGoodsInStock
            // 
            this.bsGoodsInStock.DataSource = typeof(TradingCompanyDTO.ViewGoodsInStockDTO);
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.buttonAddOrder);
            this.tabOrders.Controls.Add(this.bnOrders);
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 25);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(879, 422);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "Orders";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(9, 390);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(249, 23);
            this.buttonAddOrder.TabIndex = 1;
            this.buttonAddOrder.Text = "Add Order";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonAddOrder_Click);
            // 
            // bnOrders
            // 
            this.bnOrders.AddNewItem = this.bindingNavigatorAddNewItem1;
            this.bnOrders.BindingSource = this.bsOrders;
            this.bnOrders.CountItem = this.bindingNavigatorCountItem1;
            this.bnOrders.DeleteItem = null;
            this.bnOrders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteItem1,
            this.toolStripButton1});
            this.bnOrders.Location = new System.Drawing.Point(3, 3);
            this.bnOrders.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bnOrders.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bnOrders.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bnOrders.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bnOrders.Name = "bnOrders";
            this.bnOrders.PositionItem = this.bindingNavigatorPositionItem1;
            this.bnOrders.Size = new System.Drawing.Size(873, 27);
            this.bnOrders.TabIndex = 1;
            this.bnOrders.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem1.Text = "Add new";
            this.bindingNavigatorAddNewItem1.Click += new System.EventHandler(this.bindingNavigatorAddNewItem1_Click);
            // 
            // bsOrders
            // 
            this.bsOrders.DataSource = typeof(TradingCompanyDTO.ViewOrderDTO);
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem1
            // 
            this.bindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem1.Image")));
            this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
            this.bindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem1.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem1.Text = "Delete";
            this.bindingNavigatorDeleteItem1.Click += new System.EventHandler(this.bindingNavigatorDeleteItem1_Click);
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.goodsNameDataGridViewTextBoxColumn,
            this.providerNameDataGridViewTextBoxColumn,
            this.dateArrivesDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn1});
            this.dgvOrders.DataSource = this.bsOrders;
            this.dgvOrders.Location = new System.Drawing.Point(0, 33);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.Size = new System.Drawing.Size(876, 351);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentDoubleClick);
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // goodsNameDataGridViewTextBoxColumn
            // 
            this.goodsNameDataGridViewTextBoxColumn.DataPropertyName = "GoodsName";
            this.goodsNameDataGridViewTextBoxColumn.HeaderText = "GoodsName";
            this.goodsNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.goodsNameDataGridViewTextBoxColumn.Name = "goodsNameDataGridViewTextBoxColumn";
            this.goodsNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // providerNameDataGridViewTextBoxColumn
            // 
            this.providerNameDataGridViewTextBoxColumn.DataPropertyName = "ProviderName";
            this.providerNameDataGridViewTextBoxColumn.HeaderText = "ProviderName";
            this.providerNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.providerNameDataGridViewTextBoxColumn.Name = "providerNameDataGridViewTextBoxColumn";
            this.providerNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // dateArrivesDataGridViewTextBoxColumn
            // 
            this.dateArrivesDataGridViewTextBoxColumn.DataPropertyName = "DateArrives";
            this.dateArrivesDataGridViewTextBoxColumn.HeaderText = "DateArrives";
            this.dateArrivesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateArrivesDataGridViewTextBoxColumn.Name = "dateArrivesDataGridViewTextBoxColumn";
            this.dateArrivesDataGridViewTextBoxColumn.Width = 90;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.Width = 80;
            // 
            // GoodsAndOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.tabControlGoodsOrders);
            this.Name = "GoodsAndOrders";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GoodsAndOrders_Load);
            this.tabControlGoodsOrders.ResumeLayout(false);
            this.tabGoodsInStock.ResumeLayout(false);
            this.tabGoodsInStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGoodsInStock)).EndInit();
            this.tabOrders.ResumeLayout(false);
            this.tabOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnOrders)).EndInit();
            this.bnOrders.ResumeLayout(false);
            this.bnOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGoodsOrders;
        private System.Windows.Forms.TabPage tabGoodsInStock;
        private System.Windows.Forms.DataGridView dgvGoodsInStock;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.BindingSource bsGoodsInStock;
        private System.Windows.Forms.BindingNavigator bnOrders;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.BindingSource bsOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsInStockIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProviderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbSortingType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateArrivesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
    }
}

