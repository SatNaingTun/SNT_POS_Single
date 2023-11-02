using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.Entity;
using SNT_POS_Common.Controller;
using SNT_POS_Common.utility;
using SNTPOS_UI_Common;
//using System.Text.RegularExpressions;


namespace SNT_POS_Single_Management
{
    public partial class StockForm : Form
    {
        Stock stock; StockController stockcontrol=new StockController();
        UnitController unitcontrol = new UnitController();
        //StockInController stockIn = new StockInController();
        public StockForm()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtStockName.Text = txtStockName.Text.TrimEnd(' ');
                if (btnSave.Text == "Update" && stock != null)
                {
                    stock.Name = txtStockName.Text;
                    stock.Price = price.Value;
                    stock.GenericName = txtGenericName.Text;
                    stock.Remark = txtRemark.Text;
                    stock.unit = unitcontrol.getByName(UnitCombo.SelectedValue.ToString());
                    if (pictureBox1.IsNullOrEmpty() != true)
                    {
                        stock.StockImage = pictureBox1.Image.toByteArray();
                    }
                    stockcontrol.update(stock);
                    MessageBox.Show("Stock updated");
                    btnSave.Text = "Save";
                    btn_delete.Visible = false;
                }
                else
                {
                    Stock oldstock = stockcontrol.getByName(txtStockName.Text);
                    Unit unit = unitcontrol.getByName(UnitCombo.SelectedValue.ToString());

                    if (oldstock == null)
                    {
                        //if (pictureBox1.Image != null || pictureBox1 != null)
                        if(pictureBox1.IsNullOrEmpty()!=true)
                       {
                            //MessageBox.Show("Picbox is not empty");
                            stockcontrol.save(new Stock(txtStockName.Text, txtGenericName.Text, price.Value, txtRemark.Text, unit, pictureBox1.Image.toByteArray()));
                        }
                        else
                        {
                            //MessageBox.Show("Picbox is empty");
                            stockcontrol.save(new Stock(txtStockName.Text, txtGenericName.Text, price.Value, txtRemark.Text, unit));

                        }
                        MessageBox.Show("New Stock added");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Stock Name has already existed !! \n Do you want to add this Stock Name?", "Stock Name existed", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            //if (pictureBox1.Image != null || pictureBox1 != null)
                            if (pictureBox1.IsNullOrEmpty() != true)
                                stockcontrol.save(new Stock(txtStockName.Text, txtGenericName.Text, price.Value, txtRemark.Text, unit, pictureBox1.Image.toByteArray()));
                            else
                            
                                stockcontrol.save(new Stock(txtStockName.Text, txtGenericName.Text, price.Value, txtRemark.Text, unit));
                            MessageBox.Show("New duplicate Stock added");
                        }

                    }
                }
                //pictureBox1.Image = null;
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
       

        private void setData(Stock stock)
        {
            txtStockName.Text = stock.Name;
            txtGenericName.Text = stock.GenericName;
            price.Value = stock.Price;
            txtRemark.Text = stock.Remark;
            UnitCombo.SelectedIndex = UnitCombo.FindString(stock.unit.Name);

            if (stock.StockImage != null)
                pictureBox1.Image = stock.StockImage.toImage();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            using (SearchForm sf = new SearchForm())
            {
                sf.addData(stockcontrol.getAllwithUnitName());
               sf.setHeight(50);
                //sf.MdiParent = this.MdiParent;
                if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    stock = stockcontrol.getById(sf.getID());
                    //stock.unit = unitcontrol.getById(stock.unit.ID);
                    setData(stock);
                    btnSave.Text = "Update";
                    btn_delete.Visible = true;
                }

            }

        }
        private void clearData()
        {
            txtStockName.Clear();
            txtGenericName.Clear();
            UnitCombo.SelectedIndex = 2;
            pictureBox1.Image = null;

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" Do you want to delete this Stock?", "Stock Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (stock != null)
                {
                    stockcontrol.delete((int)stock.ID);
                    txtStockName.Clear();
                    txtGenericName.Clear();
                    btnSave.Text = "Save";
                    btn_delete.Visible = false;
                }
            }
        }

        private void txtStockName_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
           
            var regex = new Regex(@"[^a-zA-Z0-9\s\b\u1000-\u109f]");

             if (regex.IsMatch(e.KeyChar.ToString()))
             {
                 e.Handled = true;
             }
           */
          

        
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            DataTable dt = unitcontrol.getAll();
            UnitCombo.DataSource = dt;
            UnitCombo.DisplayMember = dt.Columns["UnitName"].ToString();
            UnitCombo.ValueMember = dt.Columns["UnitName"].ToString();
            if (dt.Rows.Count > 2) 
            UnitCombo.SelectedIndex = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            ofd.Filter = "JPEG Images|*.jpg|PNG Images |*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                //pictureBox1.Text = String.Format("{0}*{1} pixels", pictureBox1.Image.Width, pictureBox1.Image.Height);
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            clearData();
        }

    }
}
