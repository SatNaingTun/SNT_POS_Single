using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.Controller;
using SNT_POS_Common.Entity;
using SNTPOS_UI_Common;


namespace SNT_POS_Single_Management
{
    public partial class StockInForm : Form
    {
        DataTable dtStock;
        StockController stockcontrol = new StockController(); StockIn stockIn;
        StockInController stockIncontrol = new StockInController();
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        ContactController vendorCtrl = new ContactController("tbl_Vendor");
      
        public StockInForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            loadStockdata();
            totalBuyAmtCalculate();

           

            if (stockIn != null)
            {
                if (btnSave.Text == "Update")
                {
                    /*
                    if (hasExpireDate.Checked == false & isKnownVendor.Checked == false)
                        stockIncontrol.update(stockIn,null,null);
                    else if (hasExpireDate.Checked == false & isKnownVendor.Checked == true)
                        stockIncontrol.update(stockIn, null, stockIn.vendor.ID);
                    else if (hasExpireDate.Checked == true & isKnownVendor.Checked == false)
                        stockIncontrol.update(stockIn, expireDate.Value, null);
                    else
                        stockIncontrol.update(stockIn, expireDate.Value,stockIn.vendor.ID);
                    */
                   
                    stockIncontrol.update(stockIn);
                    

                    MessageBox.Show("StockIN updated");
                    btnSave.Text = "Save";
                    btn_delete.Visible = false;
                }
                else
                {
                    /*
                    if (hasExpireDate.Checked == false & isKnownVendor.Checked == false)
                        stockIncontrol.save(stockIn);
                    else if (hasExpireDate.Checked == false & isKnownVendor.Checked == true)
                        stockIncontrol.save(stockIn, null, vendor);
                    else if (hasExpireDate.Checked == true & isKnownVendor.Checked == false)
                        stockIncontrol.save(stockIn, expireDate.Value, null);
                    else
                        stockIncontrol.save(stockIn, expireDate.Value,vendor);
                     */
                   
                    stockIncontrol.save(stockIn);
                    //stockIncontrol.save();
                   
                    MessageBox.Show("New StockIN added");
                }
            }
            else
            {
                MessageBox.Show("Selected Stock should not be null");
            }
            

        }
        private void loadStockdata()
        {
            if (btnSave.Text == "Save")
            {
                stockIn = new StockIn();
            }
            if (suggestGrid.CurrentRow != null)
            {
                // stockIn = new StockIn();
                stockIn.stock = new Stock();
                stockIn.stock.ID = (int)suggestGrid.CurrentRow.Cells["ID"].Value;
                txtStockName.Text = stockIn.stock.Name = suggestGrid.CurrentRow.Cells["StockName"].Value.ToString();

                stockIn.stock.Price = (decimal)suggestGrid.CurrentRow.Cells["Price"].Value;
                stockIn.InBalance = txtquantity.Value;
                stockIn.BuyPrice = numBuyPrice.Value;
                stockIn.StockInDateTime = stDate.Value;
                if (hasExpireDate.Checked == true)
                {
                    stockIn.expireDate = expireDate.Value;
                }
                else
                    stockIn.expireDate = DateTime.MinValue;
                if (isKnownVendor.Checked == true)
                {
                    stockIn.vendor = vendorCtrl.getByName(VendorCombo.SelectedValue.ToString());
                }
                else if (stockIn.vendor != null)
                {
                    stockIn.vendor.ID = null;
                }
                else
                {

                    stockIn.vendor = null;

                }

            }
            else
            {
                stockIn = null;
            }

        }
       
        private void setData(StockIn stockIn)
        {
            if (stockIn != null)
            {
                txtStockName.Text = stockIn.stock.Name;
                txtquantity.Value = stockIn.InBalance;
                numBuyPrice.Value = stockIn.BuyPrice;
                stDate.Value = stockIn.StockInDateTime;
                txtSellPrice.Value = stockIn.stock.Price;
                totalBuyAmtCalculate();
                if (stockIn.expireDate != DateTime.MinValue)
                {
                    hasExpireDate.Checked = true;
                    expireDate.Enabled = true;
                    expireDate.Value = (DateTime)stockIn.expireDate;

                }
                else
                {
                    hasExpireDate.Checked = false;
                    expireDate.Enabled = false;
                }
                
                if (stockIn.vendor != null)
                {
                    isKnownVendor.Checked = true;
                    VendorCombo.SelectedIndex = VendorCombo.FindString(stockIn.vendor.Name);
                }
                else
                {

                    isKnownVendor.Checked = false;
                    stockIn.vendor = null;
                }
                
            }
        }

        private void addStockData(DataTable dt,bool isFirstTime=false)
        {
            this.dtStock = dt;
            if (dt != null)
            {
                suggestGrid.DataSource = dt;
                if (isFirstTime == true)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        comboSearch.Items.Add(dt.Columns[i].ColumnName);

                        if (dt.Columns[i].DataType == typeof(byte[]))
                        {
                            DataGridViewImageColumn imgCol = (DataGridViewImageColumn)suggestGrid.Columns[i];
                            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;


                        }
                    }
                    if (comboSearch.Items.Count >= 2)
                        comboSearch.SelectedIndex = 1;
                    else
                        comboSearch.SelectedIndex = 0;
                }
                
            }
        }

        private void getVendorList()
        {
            DataTable dt = vendorCtrl.getAll();
            VendorCombo.DataSource = dt;
            VendorCombo.ValueMember = dt.Columns["Name"].ToString();
            VendorCombo.DisplayMember = dt.Columns["Name"].ToString();

            if (dt.Rows.Count < 1)
                isKnownVendor.Checked = false;
        }

        private void Textfilter()
        {
            try
            {
                DataView dv = dtStock.DefaultView;
                // dv.RowFilter = string.Format(dt.Columns[1].ColumnName+"LIKE '%{0}%'", txtSearch.Text);
                if (dtStock.Columns[comboSearch.SelectedItem.ToString()].DataType == Type.GetType("System.Int32"))
                {
                    if (txtStockName.Text == string.Empty)
                    {
                        dv.RowFilter = string.Empty;
                    }
                    else
                        dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " = {0}", txtStockName.Text);
                }
                else
                {
                    dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " LIKE '%{0}%'", txtStockName.Text);
                }

                suggestGrid.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStockName_TextChanged(object sender, EventArgs e)
        {
            Textfilter();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            addStockData(stockcontrol.getAllwithUnitName());
            txtStockName.Clear();
        }
        /*
        private void Suggest(string toSuggestText)
        {
            autotext.AddRange(stockcontrol.getByName(toSuggestText).AsEnumerable().Select(r => r.Field<string>("StockName")).ToArray());
            txtStockName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtStockName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStockName.AutoCompleteCustomSource = autotext;
        }
        */
        private void data_KeyDown(object sender, KeyEventArgs e)
        {

           
            if ((e.KeyData & e.KeyCode) == Keys.F5)
            {
                addStockData(stockcontrol.getAll());
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SearchForm sf = new SearchForm())
                {
                    sf.addData(stockIncontrol.getAll());
                    //sf.MdiParent = this.MdiParent;
                    if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        stockIn = stockIncontrol.getById(sf.getID());
                        stockIn.stock = stockcontrol.getById((int)stockIn.stock.ID);
                        txtStockName.Text = stockIn.stock.Name;

                        if (stockIn.vendor != null)
                        {
                            stockIn.vendor = vendorCtrl.getById((int)stockIn.vendor.ID);
                        }
                        setData(stockIn);
                        btnSave.Text = "Update";
                        btn_delete.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void suggestGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            loadStockdata();
            txtSellPrice.Value = stockIn.stock.Price;
            
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            stDate.Value = DateTime.Now;
            addStockData(stockcontrol.getAllwithUnitName(),true);
            expireDate.Value = DateTime.Today.AddYears(1);
            getVendorList();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
              DialogResult result = MessageBox.Show(" Do you want to delete this StockIN?", "StockIN Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
              if (result == DialogResult.Yes)
              {
                  if (stockIn != null)
                  {
                      stockIncontrol.delete((int)stockIn.ID);
                  }
                  btnSave.Text = "Save";
                  btn_delete.Visible = false;

                  addStockData(stockcontrol.getAllwithUnitName());
                  txtStockName.Clear();
              }
           
        }

        private void hasExpireDate_CheckedChanged(object sender, EventArgs e)
        {
            if (hasExpireDate.Checked == true)
                expireDate.Enabled = true;
            if (hasExpireDate.Checked == false)
                expireDate.Enabled = false;
        }
        private void sellPriceCalculate()
        {
            txtSellPrice.Value = numBuyPrice.Value + numBuyPrice.Value * (txtPercent.Value / 100);
        }
        private void totalBuyAmtCalculate()
        {
            totalBuyAmt.Text = (numBuyPrice.Value * txtquantity.Value).ToString();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            sellPriceCalculate();
            totalBuyAmtCalculate();
        }
        

        private void btnSellPrice_Click(object sender, EventArgs e)
        {
              loadStockdata();
           
                stockIn.stock.Price = txtSellPrice.Value;
               
                stockcontrol.updatePrice(stockIn.stock);
                addStockData(stockcontrol.getAllwithUnitName());
                txtStockName.Text = stockIn.stock.Name;
                Textfilter();
                MessageBox.Show(stockIn.stock.Price + "Price updated");
          
           
        }

        private void txtPercent_ValueChanged(object sender, EventArgs e)
        {
            sellPriceCalculate();
        }

        private void btnChangeUnit_Click(object sender, EventArgs e)
        {
            try
            {
                loadStockdata();
                using (UnitCalculator calculator=new UnitCalculator())
                {
                    calculator.addData((int)stockIn.stock.ID);
                    calculator.setConnectionString(Properties.Settings.Default.SNT_POS_DBConnectionString);
                    if (calculator.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                       
                       txtquantity.Value= calculator.getCalculatedQuantity();
                       numBuyPrice.Value = calculator.getCalculatedPrice();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
