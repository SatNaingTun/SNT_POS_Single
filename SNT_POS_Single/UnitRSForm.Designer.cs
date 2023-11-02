namespace SNT_POS_Single_Management
{
    partial class UnitRSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitRSForm));
            this.comboParentUnit = new System.Windows.Forms.ComboBox();
            this.comboChildUnit = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parentQuantity = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.childQuantity = new System.Windows.Forms.NumericUpDown();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.suggestGrid = new System.Windows.Forms.DataGridView();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.saveGroupBox = new System.Windows.Forms.GroupBox();
            this.ignoreStock = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentQuantity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childQuantity)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suggestGrid)).BeginInit();
            this.saveGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboParentUnit
            // 
            this.comboParentUnit.FormattingEnabled = true;
            this.comboParentUnit.Location = new System.Drawing.Point(52, 19);
            this.comboParentUnit.Name = "comboParentUnit";
            this.comboParentUnit.Size = new System.Drawing.Size(121, 21);
            this.comboParentUnit.TabIndex = 0;
            // 
            // comboChildUnit
            // 
            this.comboChildUnit.FormattingEnabled = true;
            this.comboChildUnit.Location = new System.Drawing.Point(52, 19);
            this.comboChildUnit.Name = "comboChildUnit";
            this.comboChildUnit.Size = new System.Drawing.Size(121, 21);
            this.comboChildUnit.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parentQuantity);
            this.groupBox1.Controls.Add(this.comboParentUnit);
            this.groupBox1.Location = new System.Drawing.Point(49, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parent Unit";
            // 
            // parentQuantity
            // 
            this.parentQuantity.DecimalPlaces = 3;
            this.parentQuantity.Location = new System.Drawing.Point(52, 64);
            this.parentQuantity.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.parentQuantity.Name = "parentQuantity";
            this.parentQuantity.Size = new System.Drawing.Size(87, 20);
            this.parentQuantity.TabIndex = 4;
            this.parentQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.childQuantity);
            this.groupBox2.Controls.Add(this.comboChildUnit);
            this.groupBox2.Location = new System.Drawing.Point(339, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Child Unit";
            // 
            // childQuantity
            // 
            this.childQuantity.DecimalPlaces = 3;
            this.childQuantity.Location = new System.Drawing.Point(52, 64);
            this.childQuantity.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.childQuantity.Name = "childQuantity";
            this.childQuantity.Size = new System.Drawing.Size(87, 20);
            this.childQuantity.TabIndex = 4;
            this.childQuantity.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::SNT_POS_Single_Management.Properties.Resources.Delete_Red_Icon;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(120, 7);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(73, 32);
            this.btn_delete.TabIndex = 36;
            this.btn_delete.Text = "Delete";
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SNT_POS_Single_Management.Properties.Resources.Save_Blue_Icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(26, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 32);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.suggestGrid);
            this.panel2.Controls.Add(this.comboSearch);
            this.panel2.Controls.Add(this.txtStockName);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 171);
            this.panel2.TabIndex = 37;
            // 
            // suggestGrid
            // 
            this.suggestGrid.AllowUserToAddRows = false;
            this.suggestGrid.AllowUserToDeleteRows = false;
            this.suggestGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.suggestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suggestGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.suggestGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.suggestGrid.Location = new System.Drawing.Point(0, 47);
            this.suggestGrid.Name = "suggestGrid";
            this.suggestGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suggestGrid.ShowEditingIcon = false;
            this.suggestGrid.Size = new System.Drawing.Size(672, 124);
            this.suggestGrid.TabIndex = 20;
            this.suggestGrid.TabStop = false;
            this.suggestGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suggestGrid_CellClick);
            // 
            // comboSearch
            // 
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(25, 14);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(106, 21);
            this.comboSearch.TabIndex = 26;
            this.comboSearch.TabStop = false;
            // 
            // txtStockName
            // 
            this.txtStockName.Font = new System.Drawing.Font("Pyidaungsu", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockName.Location = new System.Drawing.Point(137, 15);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(109, 25);
            this.txtStockName.TabIndex = 1;
            this.txtStockName.TextChanged += new System.EventHandler(this.txtStockName_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SNT_POS_Single_Management.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(360, 3);
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
            this.btnRefresh.Location = new System.Drawing.Point(252, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 41);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // saveGroupBox
            // 
            this.saveGroupBox.Controls.Add(this.btn_delete);
            this.saveGroupBox.Controls.Add(this.btnSave);
            this.saveGroupBox.Location = new System.Drawing.Point(193, 318);
            this.saveGroupBox.Name = "saveGroupBox";
            this.saveGroupBox.Size = new System.Drawing.Size(230, 45);
            this.saveGroupBox.TabIndex = 38;
            this.saveGroupBox.TabStop = false;
            // 
            // ignoreStock
            // 
            this.ignoreStock.AutoSize = true;
            this.ignoreStock.Location = new System.Drawing.Point(152, 189);
            this.ignoreStock.Name = "ignoreStock";
            this.ignoreStock.Size = new System.Drawing.Size(194, 17);
            this.ignoreStock.TabIndex = 39;
            this.ignoreStock.Text = "Default Unit Relation (Ignore Stock)";
            this.ignoreStock.UseVisualStyleBackColor = true;
            // 
            // UnitRSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 366);
            this.Controls.Add(this.ignoreStock);
            this.Controls.Add(this.saveGroupBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnitRSForm";
            this.Text = "UnitRSForm";
            this.Load += new System.EventHandler(this.UnitRSForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parentQuantity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.childQuantity)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suggestGrid)).EndInit();
            this.saveGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboParentUnit;
        private System.Windows.Forms.ComboBox comboChildUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown parentQuantity;
        private System.Windows.Forms.NumericUpDown childQuantity;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView suggestGrid;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox saveGroupBox;
        private System.Windows.Forms.CheckBox ignoreStock;
    }
}