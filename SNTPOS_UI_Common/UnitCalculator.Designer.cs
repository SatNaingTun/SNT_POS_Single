namespace SNTPOS_UI_Common
{
    partial class UnitCalculator
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
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.btnChange = new System.Windows.Forms.Button();
            this.UnitName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtUnitID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StockName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtStockID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UnitCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).BeginInit();
            this.SuspendLayout();
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(142, 167);
            this.quantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(107, 20);
            this.quantity.TabIndex = 32;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(83, 227);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 31;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // UnitName
            // 
            this.UnitName.AutoSize = true;
            this.UnitName.Location = new System.Drawing.Point(139, 110);
            this.UnitName.Name = "UnitName";
            this.UnitName.Size = new System.Drawing.Size(51, 13);
            this.UnitName.TabIndex = 29;
            this.UnitName.Text = "unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "ToChangeUnit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "UnitName";
            // 
            // TxtUnitID
            // 
            this.TxtUnitID.AutoSize = true;
            this.TxtUnitID.Location = new System.Drawing.Point(139, 82);
            this.TxtUnitID.Name = "TxtUnitID";
            this.TxtUnitID.Size = new System.Drawing.Size(51, 13);
            this.TxtUnitID.TabIndex = 23;
            this.TxtUnitID.Text = "unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "UnitID";
            // 
            // StockName
            // 
            this.StockName.AutoSize = true;
            this.StockName.Location = new System.Drawing.Point(139, 56);
            this.StockName.Name = "StockName";
            this.StockName.Size = new System.Drawing.Size(51, 13);
            this.StockName.TabIndex = 24;
            this.StockName.Text = "unknown";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "StockName";
            // 
            // TxtStockID
            // 
            this.TxtStockID.AutoSize = true;
            this.TxtStockID.Location = new System.Drawing.Point(139, 27);
            this.TxtStockID.Name = "TxtStockID";
            this.TxtStockID.Size = new System.Drawing.Size(51, 13);
            this.TxtStockID.TabIndex = 25;
            this.TxtStockID.Text = "unknown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "StockID";
            // 
            // UnitCombo
            // 
            this.UnitCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitCombo.FormattingEnabled = true;
            this.UnitCombo.Location = new System.Drawing.Point(142, 140);
            this.UnitCombo.Name = "UnitCombo";
            this.UnitCombo.Size = new System.Drawing.Size(107, 21);
            this.UnitCombo.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "quantity";
            // 
            // Price
            // 
            this.Price.DecimalPlaces = 3;
            this.Price.Location = new System.Drawing.Point(142, 193);
            this.Price.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(107, 20);
            this.Price.TabIndex = 34;
            this.Price.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Price";
            // 
            // UnitCalculator
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.UnitCombo);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.UnitName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtUnitID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StockName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtStockID);
            this.Controls.Add(this.label1);
            this.Name = "UnitCalculator";
            this.Text = "UnitCalculator";
            this.Load += new System.EventHandler(this.UnitCalculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label UnitName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TxtUnitID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StockName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TxtStockID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UnitCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Price;
        private System.Windows.Forms.Label label7;
    }
}