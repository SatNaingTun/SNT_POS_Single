using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.Controller;

namespace SNT_POS_Single_Management
{
    public partial class SessionListForm : Form
    {
        DataTable dt; string ID;
        
        public SessionListForm()
        {
            InitializeComponent();
        }

        private void SessionListForm_Load(object sender, EventArgs e)
        {
            startDate.Value = DateTime.Today;
            endDate.Value = DateTime.Today.AddDays(1);

        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            SessionController sessioncontrol = new SessionController();
            addData(sessioncontrol.getByDT(startDate.Value,endDate.Value));
        }

        public void addData(DataTable dt)
        {
            this.dt = dt;
            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selectRow();

        }

        private void selectRow()
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                ID = dataGridView1.Rows[rowindex].Cells["ID"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
        }
        public int getID()
        {
            if (ID != null)
                return int.Parse(ID);

            return -1;
        }
    }
}
