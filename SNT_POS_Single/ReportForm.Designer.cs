namespace SNT_POS_Single_Management
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.numMaxValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMinValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.Loadbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinValue)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1027, 390);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboSearch);
            this.panel1.Controls.Add(this.numMaxValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numMinValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtfilter);
            this.panel1.Controls.Add(this.endDate);
            this.panel1.Controls.Add(this.startDate);
            this.panel1.Controls.Add(this.Loadbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 51);
            this.panel1.TabIndex = 1;
            // 
            // comboSearch
            // 
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(447, 8);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(134, 28);
            this.comboSearch.TabIndex = 22;
            this.toolTip1.SetToolTip(this.comboSearch, "Table Header Name of Filter Value");
            this.comboSearch.SelectedIndexChanged += new System.EventHandler(this.comboSearch_SelectedIndexChanged);
            // 
            // numMaxValue
            // 
            this.numMaxValue.Location = new System.Drawing.Point(861, 25);
            this.numMaxValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxValue.Name = "numMaxValue";
            this.numMaxValue.Size = new System.Drawing.Size(87, 20);
            this.numMaxValue.TabIndex = 20;
            this.toolTip1.SetToolTip(this.numMaxValue, "If Closing Balance > Max Value, the column shows Green");
            this.numMaxValue.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(809, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "MaxValue";
            // 
            // numMinValue
            // 
            this.numMinValue.Location = new System.Drawing.Point(861, 3);
            this.numMinValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinValue.Name = "numMinValue";
            this.numMinValue.Size = new System.Drawing.Size(87, 20);
            this.numMinValue.TabIndex = 20;
            this.toolTip1.SetToolTip(this.numMinValue, "If Closing Balance < Min Value, the column shows Red");
            this.numMinValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(809, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "MinValue";
            // 
            // txtfilter
            // 
            this.txtfilter.Font = new System.Drawing.Font("Pyidaungsu", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilter.Location = new System.Drawing.Point(591, 8);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(169, 25);
            this.txtfilter.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtfilter, "Filter the value");
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(183, 6);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(164, 23);
            this.endDate.TabIndex = 2;
            this.endDate.Value = new System.DateTime(2018, 9, 29, 23, 59, 59, 0);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(13, 6);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(153, 23);
            this.startDate.TabIndex = 1;
            this.toolTip1.SetToolTip(this.startDate, "Start Datetime");
            this.startDate.Value = new System.DateTime(2018, 9, 29, 0, 0, 0, 0);
            // 
            // Loadbtn
            // 
            this.Loadbtn.Image = global::SNT_POS_Single_Management.Properties.Resources.download_database_21022;
            this.Loadbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Loadbtn.Location = new System.Drawing.Point(373, 6);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(68, 36);
            this.Loadbtn.TabIndex = 3;
            this.Loadbtn.Text = "Load";
            this.Loadbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.Loadbtn, "Load the data between the start datetime and end datetime");
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 390);
            this.panel2.TabIndex = 2;
            // 
            // ReportForm
            // 
            this.AcceptButton = this.Loadbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinValue)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.NumericUpDown numMaxValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMinValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.ToolTip toolTip1;
       
    }
}