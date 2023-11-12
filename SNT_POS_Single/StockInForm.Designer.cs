namespace SNT_POS_Single_Management
{
    partial class StockInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockInForm));
            this.label4 = new System.Windows.Forms.Label();
            this.txtquantity = new System.Windows.Forms.NumericUpDown();
            this.suggestGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.VendorCombo = new System.Windows.Forms.ComboBox();
            this.isKnownVendor = new System.Windows.Forms.CheckBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_calc_unit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSellPrice = new System.Windows.Forms.NumericUpDown();
            this.txtPercent = new System.Windows.Forms.NumericUpDown();
            this.btnSellPrice = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numBuyPrice = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hasExpireDate = new System.Windows.Forms.CheckBox();
            this.expireDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.stDate = new System.Windows.Forms.DateTimePicker();
            this.totalBuyAmt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtquantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suggestGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyPrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Quantity";
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(106, 17);
            this.txtquantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(87, 20);
            this.txtquantity.TabIndex = 2;
            this.txtquantity.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtquantity.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // suggestGrid
            // 
            this.suggestGrid.AllowUserToAddRows = false;
            this.suggestGrid.AllowUserToDeleteRows = false;
            this.suggestGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.suggestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suggestGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suggestGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.suggestGrid.Location = new System.Drawing.Point(0, 0);
            this.suggestGrid.Name = "suggestGrid";
            this.suggestGrid.RowTemplate.Height = 50;
            this.suggestGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suggestGrid.ShowEditingIcon = false;
            this.suggestGrid.Size = new System.Drawing.Size(821, 142);
            this.suggestGrid.TabIndex = 20;
            this.suggestGrid.TabStop = false;
            this.suggestGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suggestGrid_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 411);
            this.panel1.TabIndex = 24;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(821, 411);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.suggestGrid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(821, 142);
            this.panel4.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.comboSearch);
            this.panel2.Controls.Add(this.txtStockName);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 63);
            this.panel2.TabIndex = 28;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.VendorCombo);
            this.groupBox3.Controls.Add(this.isKnownVendor);
            this.groupBox3.Location = new System.Drawing.Point(452, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 52);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // VendorCombo
            // 
            this.VendorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VendorCombo.FormattingEnabled = true;
            this.VendorCombo.Location = new System.Drawing.Point(34, 25);
            this.VendorCombo.Name = "VendorCombo";
            this.VendorCombo.Size = new System.Drawing.Size(164, 21);
            this.VendorCombo.TabIndex = 6;
            // 
            // isKnownVendor
            // 
            this.isKnownVendor.AutoSize = true;
            this.isKnownVendor.Checked = true;
            this.isKnownVendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isKnownVendor.Location = new System.Drawing.Point(24, 7);
            this.isKnownVendor.Name = "isKnownVendor";
            this.isKnownVendor.Size = new System.Drawing.Size(100, 17);
            this.isKnownVendor.TabIndex = 5;
            this.isKnownVendor.Text = "isKnownVendor";
            this.isKnownVendor.UseVisualStyleBackColor = true;
            // 
            // comboSearch
            // 
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(25, 14);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(106, 24);
            this.comboSearch.TabIndex = 26;
            this.comboSearch.TabStop = false;
            // 
            // txtStockName
            // 
            this.txtStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockName.Location = new System.Drawing.Point(154, 15);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(142, 23);
            this.txtStockName.TabIndex = 1;
            this.txtStockName.TextChanged += new System.EventHandler(this.txtStockName_TextChanged);
            this.txtStockName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SNT_POS_Single_Management.Properties.Resources.data_icon;
            this.btnSearch.Location = new System.Drawing.Point(302, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 41);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::SNT_POS_Single_Management.Properties.Resources.refresh_arrows_14418;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(352, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 39);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_calc_unit);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.txtquantity);
            this.panel3.Controls.Add(this.numBuyPrice);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btn_delete);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.stDate);
            this.panel3.Controls.Add(this.totalBuyAmt);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 202);
            this.panel3.TabIndex = 29;
            // 
            // btn_calc_unit
            // 
            this.btn_calc_unit.Image = global::SNT_POS_Single_Management.Properties.Resources.calculate;
            this.btn_calc_unit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_calc_unit.Location = new System.Drawing.Point(213, 17);
            this.btn_calc_unit.Name = "btn_calc_unit";
            this.btn_calc_unit.Size = new System.Drawing.Size(113, 44);
            this.btn_calc_unit.TabIndex = 29;
            this.btn_calc_unit.Text = "Calculate Unit";
            this.btn_calc_unit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_calc_unit.UseVisualStyleBackColor = true;
            this.btn_calc_unit.Click += new System.EventHandler(this.btnChangeUnit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSellPrice);
            this.groupBox2.Controls.Add(this.txtPercent);
            this.groupBox2.Controls.Add(this.btnSellPrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(346, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 75);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SellPrice";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.DecimalPlaces = 3;
            this.txtSellPrice.Location = new System.Drawing.Point(133, 14);
            this.txtSellPrice.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(87, 20);
            this.txtSellPrice.TabIndex = 3;
            this.txtSellPrice.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(6, 36);
            this.txtPercent.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(44, 20);
            this.txtPercent.TabIndex = 2;
            this.txtPercent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtPercent.ValueChanged += new System.EventHandler(this.txtPercent_ValueChanged);
            // 
            // btnSellPrice
            // 
            this.btnSellPrice.Image = global::SNT_POS_Single_Management.Properties.Resources.price_tag_blue;
            this.btnSellPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSellPrice.Location = new System.Drawing.Point(126, 36);
            this.btnSellPrice.Name = "btnSellPrice";
            this.btnSellPrice.Size = new System.Drawing.Size(102, 33);
            this.btnSellPrice.TabIndex = 6;
            this.btnSellPrice.TabStop = false;
            this.btnSellPrice.Text = "SetSellPrice";
            this.btnSellPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSellPrice.UseVisualStyleBackColor = true;
            this.btnSellPrice.Click += new System.EventHandler(this.btnSellPrice_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "SellPrice";
            // 
            // numBuyPrice
            // 
            this.numBuyPrice.DecimalPlaces = 3;
            this.numBuyPrice.Location = new System.Drawing.Point(106, 43);
            this.numBuyPrice.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numBuyPrice.Name = "numBuyPrice";
            this.numBuyPrice.Size = new System.Drawing.Size(87, 20);
            this.numBuyPrice.TabIndex = 3;
            this.numBuyPrice.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBuyPrice.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hasExpireDate);
            this.groupBox1.Controls.Add(this.expireDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(346, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 71);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // hasExpireDate
            // 
            this.hasExpireDate.AutoSize = true;
            this.hasExpireDate.Location = new System.Drawing.Point(52, 22);
            this.hasExpireDate.Name = "hasExpireDate";
            this.hasExpireDate.Size = new System.Drawing.Size(95, 17);
            this.hasExpireDate.TabIndex = 5;
            this.hasExpireDate.Text = "hasExpireDate";
            this.hasExpireDate.UseVisualStyleBackColor = true;
            this.hasExpireDate.CheckedChanged += new System.EventHandler(this.hasExpireDate_CheckedChanged);
            // 
            // expireDate
            // 
            this.expireDate.CustomFormat = "dd/MM/yyyy";
            this.expireDate.Enabled = false;
            this.expireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expireDate.Location = new System.Drawing.Point(126, 39);
            this.expireDate.Name = "expireDate";
            this.expireDate.Size = new System.Drawing.Size(94, 20);
            this.expireDate.TabIndex = 3;
            this.expireDate.Value = new System.DateTime(2018, 9, 29, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "ExpireDate";
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::SNT_POS_Single_Management.Properties.Resources.Delete_Red_Icon;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(176, 140);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 35);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.TabStop = false;
            this.btn_delete.Text = "Delete";
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "BuyPrice";
            // 
            // stDate
            // 
            this.stDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.stDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stDate.Location = new System.Drawing.Point(103, 73);
            this.stDate.Name = "stDate";
            this.stDate.Size = new System.Drawing.Size(152, 20);
            this.stDate.TabIndex = 4;
            this.stDate.Value = new System.DateTime(2018, 9, 29, 0, 0, 0, 0);
            // 
            // totalBuyAmt
            // 
            this.totalBuyAmt.AutoSize = true;
            this.totalBuyAmt.Location = new System.Drawing.Point(105, 102);
            this.totalBuyAmt.Name = "totalBuyAmt";
            this.totalBuyAmt.Size = new System.Drawing.Size(13, 13);
            this.totalBuyAmt.TabIndex = 23;
            this.totalBuyAmt.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Total Buy Amt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "StockIn DateTime";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SNT_POS_Single_Management.Properties.Resources.Save_Blue_Icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(67, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // StockInForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 411);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockInForm";
            this.Text = "StockInForm";
            this.Load += new System.EventHandler(this.StockInForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtquantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suggestGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuyPrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtquantity;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView suggestGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker stDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBuyPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox hasExpireDate;
        private System.Windows.Forms.DateTimePicker expireDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown txtSellPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown txtPercent;
        private System.Windows.Forms.Button btnSellPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalBuyAmt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_calc_unit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox isKnownVendor;
        private System.Windows.Forms.ComboBox VendorCombo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
    }
}