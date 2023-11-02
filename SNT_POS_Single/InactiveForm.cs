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
    public partial class InactiveForm : Form
    {
        DataTable dt;
        StockController stockControl = new StockController();
        SaleController saleControl = new SaleController();
        StockInController stockInControl = new StockInController();

        public InactiveForm()
        {
            InitializeComponent();
        }
        /*
        public void addData(DataTable dt)
        {
            this.dt = dt;
            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
        }
         */
        public void addComboSearch(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    comboSearch.Items.Clear();

                    for (int i = 0; i < dt.Columns.Count; i++)
                        comboSearch.Items.Add(dt.Columns[i].ColumnName);
                    if (comboSearch.FindString("StockName") != -1)
                    {
                        comboSearch.SelectedIndex = comboSearch.FindString("StockName");
                    }
                    else
                        comboSearch.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getData()
        {
            
            if (comboBox1.SelectedIndex==0)
            {
                dt = stockControl.getDeletedStock();
            }
          else  if (comboBox1.SelectedIndex == 1)
            {
                dt = saleControl.getDeletedSale();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dt = stockInControl.getDeletedStockIn();
            }
            addComboSearch(dt);
           

            dataGridView1.DataSource = dt;
            setData();
        }


        private void setData()
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                if(dataGridView1.Columns.Contains("ID"))
                lbl_ID.Text = dataGridView1.Rows[rowindex].Cells["ID"].Value.ToString();
                else
                lbl_ID.Text=dataGridView1.Rows[rowindex].Cells["StockID"].Value.ToString();

            }
            else
            {
                lbl_ID.Text = "Unknown";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            setData();

        }

        private void reactivate_Click(object sender, EventArgs e)
        {
           
            if (lbl_ID.Text != "Unknown" && comboBox1.SelectedIndex == 0)
            {
                stockControl.reactivate(int.Parse(lbl_ID.Text));
            }
            else if (lbl_ID.Text != "Unknown" && comboBox1.SelectedIndex == 1)
            {
                saleControl.reactivate(int.Parse(lbl_ID.Text));
            }
            else if (lbl_ID.Text != "Unknown" && comboBox1.SelectedIndex == 2)
            {
                stockInControl.reactivate(int.Parse(lbl_ID.Text));
            }

            getData();
        }

        private void InactiveForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;
            getData();

        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void Textfilter()
        {
            try
            {
                DataView dv = dt.DefaultView;
                // dv.RowFilter = string.Format(dt.Columns[1].ColumnName+"LIKE '%{0}%'", txtSearch.Text);
                if (dt.Columns[comboSearch.SelectedItem.ToString()].DataType == Type.GetType("System.Int32"))
                {
                    if (txtfilter.Text == string.Empty)
                    {
                        dv.RowFilter = string.Empty;
                    }
                    else
                        dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " = {0}", txtfilter.Text);
                }
                else
                {
                    dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " LIKE '%{0}%'", txtfilter.Text);
                }

                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            Textfilter();
        }
    }
}
