using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNT_POS_Single_Management
{
    public partial class SearchForm : Form
    {
        DataTable dt; string ID;
        public SearchForm()
        {
            InitializeComponent();
        }

        public void addData(DataTable dt)
        {
            this.dt = dt;
            if (dt != null)
            {
                dataGridView1.DataSource = dt;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    comboSearch.Items.Add(dt.Columns[i].ColumnName);

                    if (dt.Columns[i].DataType == typeof(byte[]))
                    {
                       DataGridViewImageColumn imgCol= (DataGridViewImageColumn)dataGridView1.Columns[i];
                       imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

                      
                    }
                }

                if (comboSearch.Items.Count >= 2)
                    comboSearch.SelectedIndex = 1;
                else
                    comboSearch.SelectedIndex = 0;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectRow();
            

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
                ID = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            }
           this.DialogResult = DialogResult.OK;
        }
        public int getID()
        {
            if (ID!=null)
            return int.Parse(ID);

            return -1;
        }

       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        { 
            DataView dv = dt.DefaultView;
            try
            {
                // dv.RowFilter = string.Format(dt.Columns[1].ColumnName+"LIKE '%{0}%'", txtSearch.Text);
                if (dt.Columns[comboSearch.SelectedItem.ToString()].DataType == Type.GetType("System.Int32"))
                {
                    if (txtSearch.Text == string.Empty)
                    {
                        dv.RowFilter = string.Empty;
                    }
                    else
                        dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " = {0}", txtSearch.Text);
                }
                else
                {
                    dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " LIKE '%{0}%'", txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = dv;

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            //Stretch(sender, e);
        }
        public void setHeight(int height)
        {
            dataGridView1.RowTemplate.Height = height;
            
        }
        private void Stretch(object sender, EventArgs e)
        {
            foreach (DataGridViewImageColumn column in
                dataGridView1.Columns)
            {
                column.ImageLayout = DataGridViewImageCellLayout.Zoom;
                column.Description = "Stretched";
            }
        }


       

    }
}
