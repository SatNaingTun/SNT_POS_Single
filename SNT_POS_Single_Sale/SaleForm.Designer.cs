namespace SNT_POS_Single_Sale
{
    partial class SaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblUnitID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_calc_unit = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.Label();
            this.btnAddCart = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txtdiscount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtquantity = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.suggestGrid = new System.Windows.Forms.DataGridView();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.saleGridView1 = new System.Windows.Forms.DataGridView();
            this.StockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboSaleType = new System.Windows.Forms.ComboBox();
            this.btnVrSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSessionID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustAddress = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtquantity)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suggestGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 462);
            this.panel1.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1072, 415);
            this.panel4.TabIndex = 22;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saleGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 415);
            this.splitContainer1.SplitterDistance = 548;
            this.splitContainer1.SplitterIncrement = 2;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblUnitName);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.lblUnitID);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.btn_calc_unit);
            this.panel6.Controls.Add(this.txtPrice);
            this.panel6.Controls.Add(this.btnAddCart);
            this.panel6.Controls.Add(this.btn_delete);
            this.panel6.Controls.Add(this.txtdiscount);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.txtquantity);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtAmount);
            this.panel6.Controls.Add(this.txtNetAmount);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 248);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(548, 167);
            this.panel6.TabIndex = 23;
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(390, 12);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(51, 13);
            this.lblUnitName.TabIndex = 31;
            this.lblUnitName.Text = "unknown";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(333, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "UnitName";
            // 
            // lblUnitID
            // 
            this.lblUnitID.AutoSize = true;
            this.lblUnitID.Location = new System.Drawing.Point(263, 12);
            this.lblUnitID.Name = "lblUnitID";
            this.lblUnitID.Size = new System.Drawing.Size(51, 13);
            this.lblUnitID.TabIndex = 31;
            this.lblUnitID.Text = "unknown";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "UnitID";
            // 
            // btn_calc_unit
            // 
            this.btn_calc_unit.Location = new System.Drawing.Point(216, 36);
            this.btn_calc_unit.Name = "btn_calc_unit";
            this.btn_calc_unit.Size = new System.Drawing.Size(108, 23);
            this.btn_calc_unit.TabIndex = 30;
            this.btn_calc_unit.Text = "Calculate Unit";
            this.btn_calc_unit.UseVisualStyleBackColor = true;
            this.btn_calc_unit.Click += new System.EventHandler(this.btn_calc_Unit_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.AutoSize = true;
            this.txtPrice.Location = new System.Drawing.Point(95, 12);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(51, 13);
            this.txtPrice.TabIndex = 20;
            this.txtPrice.Text = "unknown";
            // 
            // btnAddCart
            // 
            this.btnAddCart.Image = global::SNT_POS_Single_Sale.Properties.Resources.blue_cart;
            this.btnAddCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCart.Location = new System.Drawing.Point(43, 129);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(142, 38);
            this.btnAddCart.TabIndex = 4;
            this.btnAddCart.Text = "Add to Cart";
            this.toolTip1.SetToolTip(this.btnAddCart, "Add selected item data to salegrid");
            this.btnAddCart.UseVisualStyleBackColor = true;
            this.btnAddCart.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::SNT_POS_Single_Sale.Properties.Resources.iconfinder_trash_4341321_120557;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(195, 131);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(105, 35);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txtdiscount
            // 
            this.txtdiscount.Location = new System.Drawing.Point(98, 85);
            this.txtdiscount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(87, 20);
            this.txtdiscount.TabIndex = 3;
            this.txtdiscount.ValueChanged += new System.EventHandler(this.txtdiscount_ValueChanged);
            this.txtdiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Price";
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(98, 34);
            this.txtquantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(87, 20);
            this.txtquantity.TabIndex = 2;
            this.txtquantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtquantity.ValueChanged += new System.EventHandler(this.txtquantity_ValueChanged);
            this.txtquantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "NetAmount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Discount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "PaidAmount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Quantity";
            // 
            // txtAmount
            // 
            this.txtAmount.AutoSize = true;
            this.txtAmount.Location = new System.Drawing.Point(95, 64);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(51, 13);
            this.txtAmount.TabIndex = 20;
            this.txtAmount.Text = "unknown";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.AutoSize = true;
            this.txtNetAmount.Location = new System.Drawing.Point(95, 113);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(51, 13);
            this.txtNetAmount.TabIndex = 20;
            this.txtNetAmount.Text = "unknown";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SkyBlue;
            this.panel5.Controls.Add(this.suggestGrid);
            this.panel5.Controls.Add(this.txtStockName);
            this.panel5.Controls.Add(this.comboSearch);
            this.panel5.Controls.Add(this.btnRefresh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(548, 248);
            this.panel5.TabIndex = 20;
            // 
            // suggestGrid
            // 
            this.suggestGrid.AllowUserToAddRows = false;
            this.suggestGrid.AllowUserToDeleteRows = false;
            this.suggestGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.suggestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suggestGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.suggestGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.suggestGrid.Location = new System.Drawing.Point(0, 46);
            this.suggestGrid.Name = "suggestGrid";
            this.suggestGrid.RowTemplate.Height = 50;
            this.suggestGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suggestGrid.ShowEditingIcon = false;
            this.suggestGrid.Size = new System.Drawing.Size(548, 202);
            this.suggestGrid.TabIndex = 21;
            this.suggestGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suggestGrid_CellClick);
            this.suggestGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_KeyDown);
            // 
            // txtStockName
            // 
            this.txtStockName.Font = new System.Drawing.Font("Pyidaungsu", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockName.Location = new System.Drawing.Point(154, 6);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(211, 25);
            this.txtStockName.TabIndex = 1;
            this.txtStockName.TextChanged += new System.EventHandler(this.txtStockName_TextChanged);
            this.txtStockName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_KeyDown);
            // 
            // comboSearch
            // 
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(11, 7);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(123, 28);
            this.comboSearch.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::SNT_POS_Single_Sale.Properties.Resources.refresh_arrows_14418;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(371, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 40);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.toolTip1.SetToolTip(this.btnRefresh, "Reload the updated Stock Data");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // saleGridView1
            // 
            this.saleGridView1.AllowUserToAddRows = false;
            this.saleGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockID,
            this.StockName,
            this.Price,
            this.Quantity,
            this.Amount,
            this.Discount,
            this.NetAmount,
            this.UnitID,
            this.UnitName,
            this.StockBalance});
            this.saleGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saleGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.saleGridView1.Location = new System.Drawing.Point(0, 0);
            this.saleGridView1.Name = "saleGridView1";
            this.saleGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleGridView1.Size = new System.Drawing.Size(523, 358);
            this.saleGridView1.TabIndex = 30;
            this.toolTip1.SetToolTip(this.saleGridView1, "You can update the data by double clicking the row and click update button");
            this.saleGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGridView1_CellClick);
            this.saleGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.saleGridView1_CellFormatting);
            // 
            // StockID
            // 
            this.StockID.HeaderText = "StockID";
            this.StockID.Name = "StockID";
            // 
            // StockName
            // 
            this.StockName.HeaderText = "StockName";
            this.StockName.Name = "StockName";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "NetAmount";
            this.NetAmount.Name = "NetAmount";
            // 
            // UnitID
            // 
            this.UnitID.HeaderText = "UnitID";
            this.UnitID.Name = "UnitID";
            // 
            // UnitName
            // 
            this.UnitName.HeaderText = "UnitName";
            this.UnitName.Name = "UnitName";
            // 
            // StockBalance
            // 
            this.StockBalance.HeaderText = "StockBalance";
            this.StockBalance.Name = "StockBalance";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboSaleType);
            this.panel2.Controls.Add(this.btnVrSave);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 57);
            this.panel2.TabIndex = 22;
            // 
            // comboSaleType
            // 
            this.comboSaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSaleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSaleType.FormattingEnabled = true;
            this.comboSaleType.ItemHeight = 24;
            this.comboSaleType.Location = new System.Drawing.Point(208, 21);
            this.comboSaleType.Name = "comboSaleType";
            this.comboSaleType.Size = new System.Drawing.Size(134, 32);
            this.comboSaleType.TabIndex = 5;
            // 
            // btnVrSave
            // 
            this.btnVrSave.Image = global::SNT_POS_Single_Sale.Properties.Resources.Save_Icon_icon_icons_com_69139;
            this.btnVrSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVrSave.Location = new System.Drawing.Point(348, 19);
            this.btnVrSave.Name = "btnVrSave";
            this.btnVrSave.Size = new System.Drawing.Size(121, 35);
            this.btnVrSave.TabIndex = 6;
            this.btnVrSave.Text = "Save & Print";
            this.toolTip1.SetToolTip(this.btnVrSave, "Save the items from salegrid and print the vouncher");
            this.btnVrSave.UseVisualStyleBackColor = true;
            this.btnVrSave.Click += new System.EventHandler(this.btnVrSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(161, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(14, 15);
            this.txtTotal.TabIndex = 20;
            this.txtTotal.Text = "0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSessionID);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtCustAddress);
            this.panel3.Controls.Add(this.txtCustomerPhone);
            this.panel3.Controls.Add(this.txtCustomerName);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lblUserName);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1072, 47);
            this.panel3.TabIndex = 22;
            // 
            // lblSessionID
            // 
            this.lblSessionID.AutoSize = true;
            this.lblSessionID.Location = new System.Drawing.Point(192, 9);
            this.lblSessionID.Name = "lblSessionID";
            this.lblSessionID.Size = new System.Drawing.Size(55, 13);
            this.lblSessionID.TabIndex = 31;
            this.lblSessionID.Text = "SessionID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "SessionID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Cashier-";
            // 
            // txtCustAddress
            // 
            this.txtCustAddress.Location = new System.Drawing.Point(803, 3);
            this.txtCustAddress.Multiline = true;
            this.txtCustAddress.Name = "txtCustAddress";
            this.txtCustAddress.Size = new System.Drawing.Size(249, 41);
            this.txtCustAddress.TabIndex = 9;
            this.txtCustAddress.TextChanged += new System.EventHandler(this.txtCustomerPhone_TextChanged);
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(572, 6);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(136, 20);
            this.txtCustomerPhone.TabIndex = 8;
            this.txtCustomerPhone.TextChanged += new System.EventHandler(this.txtCustomerPhone_TextChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(342, 7);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(136, 20);
            this.txtCustomerName.TabIndex = 7;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(719, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "CustomerAddress";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(49, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 30;
            this.lblUserName.Text = "userName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "CustomerPhone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "CustomerName";
            // 
            // SaleForm
            // 
            this.AcceptButton = this.btnAddCart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 462);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaleForm_FormClosing);
            this.Load += new System.EventHandler(this.SaleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtquantity)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suggestGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView suggestGrid;
        private System.Windows.Forms.DataGridView saleGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.Button btnAddCart;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtNetAmount;
        private System.Windows.Forms.Label txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtquantity;
        private System.Windows.Forms.NumericUpDown txtdiscount;
        private System.Windows.Forms.Button btnVrSave;
        private System.Windows.Forms.Label lblSessionID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSaleType;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_calc_unit;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtCustAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblUnitID;
        private System.Windows.Forms.Label label12;
       
        private System.Windows.Forms.DataGridViewTextBoxColumn StockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockBalance;
    }
}

