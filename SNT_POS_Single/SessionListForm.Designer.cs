namespace SNT_POS_Single_Management
{
    partial class SessionListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateGroup = new System.Windows.Forms.GroupBox();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioDate = new System.Windows.Forms.RadioButton();
            this.Loadbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.dateGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateGroup);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Loadbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 69);
            this.panel1.TabIndex = 2;
            // 
            // dateGroup
            // 
            this.dateGroup.Controls.Add(this.startDate);
            this.dateGroup.Controls.Add(this.endDate);
            this.dateGroup.Location = new System.Drawing.Point(14, 3);
            this.dateGroup.Name = "dateGroup";
            this.dateGroup.Size = new System.Drawing.Size(331, 38);
            this.dateGroup.TabIndex = 4;
            this.dateGroup.TabStop = false;
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(6, 12);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(148, 20);
            this.startDate.TabIndex = 1;
            this.startDate.Value = new System.DateTime(2018, 9, 29, 0, 0, 0, 0);
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(161, 12);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(164, 20);
            this.endDate.TabIndex = 2;
            this.endDate.Value = new System.DateTime(2018, 9, 29, 23, 59, 59, 0);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(353, 38);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(180, 20);
            this.searchBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioDate);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 37);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(161, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "TextBox";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioDate
            // 
            this.radioDate.AutoSize = true;
            this.radioDate.Checked = true;
            this.radioDate.Location = new System.Drawing.Point(28, 11);
            this.radioDate.Name = "radioDate";
            this.radioDate.Size = new System.Drawing.Size(71, 17);
            this.radioDate.TabIndex = 0;
            this.radioDate.TabStop = true;
            this.radioDate.Text = "DateTime";
            this.radioDate.UseVisualStyleBackColor = true;
            this.radioDate.CheckedChanged += new System.EventHandler(this.radioDate_CheckedChanged);
            // 
            // Loadbtn
            // 
            this.Loadbtn.Image = global::SNT_POS_Single_Management.Properties.Resources.download_database_21022;
            this.Loadbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Loadbtn.Location = new System.Drawing.Point(554, 15);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(94, 40);
            this.Loadbtn.TabIndex = 3;
            this.Loadbtn.Text = "load";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(676, 193);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // SessionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SessionListForm";
            this.Text = "SessionListForm";
            this.Load += new System.EventHandler(this.SessionListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.dateGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioDate;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.GroupBox dateGroup;
    }
}