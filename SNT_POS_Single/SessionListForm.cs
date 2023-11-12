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
       
        SessionController sessionControl = new SessionController();

        public SessionListForm()
        {
            InitializeComponent();
        }

        private void SessionListForm_Load(object sender, EventArgs e)
        {
            startDate.Value = DateTime.Today;
            endDate.Value = DateTime.Today.AddDays(1);
            addData(sessionControl.getByDT(startDate.Value, endDate.Value));
            showVisible();

        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            if(radioDate.Checked)
            addData(sessionControl.getByDT(startDate.Value,endDate.Value));

            if (radioButton2.Checked)
            {

                if (String.IsNullOrEmpty(searchBox.Text))
                {
                    searchBox.Focus();
                }
                else
                {
                    SessionForm sessionForm = new SessionForm();
                    sessionForm.session = sessionControl.getById(int.Parse(searchBox.Text));
                    this.Close();
                }
            }
        }

        public void addData(DataTable dt)
        {
            
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
              string  ID = dataGridView1.Rows[rowindex].Cells["ID"].Value.ToString();
                SessionForm sessionForm = new SessionForm();
                sessionForm.session = sessionControl.getById(int.Parse(ID));
                this.Close();
            }

            //this.DialogResult = DialogResult.OK;
        }
        /*
        public int getID()
        {
            if (ID != null)
                return int.Parse(ID);

            return -1;
        }
         * */
        private void showVisible()
        {
            if (radioDate.Checked)
            {
                searchBox.Visible = false;
                dateGroup.Visible = true;
            }
            if(radioButton2.Checked)
            {
                searchBox.Visible = true;
                dateGroup.Visible = false;
                searchBox.Focus();
            }
        }


        private void radioDate_CheckedChanged(object sender, EventArgs e)
        {
            showVisible();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            showVisible();
        }

       
    }
}
