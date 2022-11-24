namespace TradingCoompanyWindowsForms
{
    partial class ManageOrder
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
            this.mcDateArrives = new System.Windows.Forms.MonthCalendar();
            this.cbGoods = new System.Windows.Forms.ComboBox();
            this.goodsDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbProviders = new System.Windows.Forms.ComboBox();
            this.providerDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.goodsDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // mcDateArrives
            // 
            this.mcDateArrives.Location = new System.Drawing.Point(18, 126);
            this.mcDateArrives.MaxSelectionCount = 1;
            this.mcDateArrives.Name = "mcDateArrives";
            this.mcDateArrives.TabIndex = 0;
            // 
            // cbGoods
            // 
            this.cbGoods.DataSource = this.goodsDTOBindingSource;
            this.cbGoods.DisplayMember = "Name";
            this.cbGoods.FormattingEnabled = true;
            this.cbGoods.Location = new System.Drawing.Point(18, 29);
            this.cbGoods.Name = "cbGoods";
            this.cbGoods.Size = new System.Drawing.Size(262, 24);
            this.cbGoods.TabIndex = 1;
            this.cbGoods.SelectedIndexChanged += new System.EventHandler(this.cbGoods_SelectedIndexChanged);
            // 
            // goodsDTOBindingSource
            // 
            this.goodsDTOBindingSource.DataSource = typeof(TradingCompanyDTO.GoodsDTO);
            // 
            // cbProviders
            // 
            this.cbProviders.DataSource = this.providerDTOBindingSource;
            this.cbProviders.DisplayMember = "Name";
            this.cbProviders.FormattingEnabled = true;
            this.cbProviders.Location = new System.Drawing.Point(338, 29);
            this.cbProviders.Name = "cbProviders";
            this.cbProviders.Size = new System.Drawing.Size(262, 24);
            this.cbProviders.TabIndex = 2;
            // 
            // providerDTOBindingSource
            // 
            this.providerDTOBindingSource.DataSource = typeof(TradingCompanyDTO.ProviderDTO);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(485, 303);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(115, 30);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(338, 303);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(115, 30);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Goods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Provider";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Arrival date";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(485, 134);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(115, 22);
            this.nudQuantity.TabIndex = 11;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ManageOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 353);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.cbProviders);
            this.Controls.Add(this.cbGoods);
            this.Controls.Add(this.mcDateArrives);
            this.Name = "ManageOrder";
            this.Text = "ManageOrder";
            ((System.ComponentModel.ISupportInitialize)(this.goodsDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcDateArrives;
        private System.Windows.Forms.ComboBox cbGoods;
        private System.Windows.Forms.ComboBox cbProviders;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource goodsDTOBindingSource;
        private System.Windows.Forms.BindingSource providerDTOBindingSource;
        private System.Windows.Forms.NumericUpDown nudQuantity;
    }
}