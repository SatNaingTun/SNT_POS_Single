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
using Microsoft.Reporting.WinForms;
using SNT_POS_Single.BussinessRule;

namespace SNT_POS_Single_Management
{
    public partial class SessionForm : Form
    {
        public Session session; 
        SaleController salecontrol = new SaleController();
        StockController stockcontrol = new StockController();
        SessionController sessioncontrol = new SessionController();
        Vouncher_Item item,originalItem;
        StockManager stockMgr = new StockManager();
        SaleTypeController saletypecontrol = new SaleTypeController();
        CompanyProfileController profilecontrol = new CompanyProfileController(); CustomerController custCtrl = new CustomerController();

        DataTable dtcustomer;
      
        public SessionForm()
        {
            InitializeComponent();
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {
            lblSessionID.Text = session.ID.ToString();
            startDate.Value = session.LoginDT;

            if (session.LogoutDT!=DateTime.MinValue)
            endDate.Value = session.LogoutDT;

            refreshData(salecontrol.getBySessionId((int)session.ID));
            DataTable dtStock=stockcontrol.getAll();
            StockCombo.DataSource = dtStock;
            StockCombo.ValueMember = dtStock.Columns["StockName"].ToString();
            StockCombo.DisplayMember = dtStock.Columns["StockName"].ToString();
            StockCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StockCombo.AutoCompleteSource = AutoCompleteSource.ListItems;

            DataTable dtSaleType = saletypecontrol.getAll();
            comboSaleType.DataSource = dtSaleType;
            comboSaleType.ValueMember = dtSaleType.Columns["SaleTypeName"].ToString();
            comboSaleType.DisplayMember = dtSaleType.Columns["SaleTypeName"].ToString();
            if (comboSaleType.Items.Count >= 0)
                comboSaleType.SelectedIndex = 0;

            setSaledata();
           
        }

        void refreshData(DataTable dt)
        {
            dataGridView1.DataSource = dt;
            setSaledata();

            setAutoCompleteCustomer();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            setSaledata();
        }

        private bool setSaledata()
        {
            if (dataGridView1.CurrentRow != null)
            {
              
                try
                {
                 //   item = new Vouncher_Item();
                 //   item.stock = new Stock();

                 //   item.ID = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                    

                 //  item.VouncherID = (string)dataGridView1.CurrentRow.Cells["VouncherID"].Value.ToString();
                 //   item.stock.ID = (int)dataGridView1.CurrentRow.Cells["StockID"].Value;
                 //   item.stock.Name = dataGridView1.CurrentRow.Cells["StockName"].Value.ToString();

                   

                 //item.stock.Price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Price"].Value);
                 //item.quantity = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Quantity"].Value);
                 //item.discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Discount"].Value);
                 //item.saletype = saletypecontrol.getById((int)dataGridView1.CurrentRow.Cells["SaleTypeID"].Value);
                 //item.Amt = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Amount"].Value);
                 //item.NetAmt = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["NetAmount"].Value);
                    originalItem = salecontrol.getItemById((int)dataGridView1.CurrentRow.Cells["ID"].Value);
                  item = salecontrol.getItemById((int)dataGridView1.CurrentRow.Cells["ID"].Value);
                 lblID.Text = item.ID.ToString();
                 StockCombo.SelectedIndex = StockCombo.FindString(item.stock.Name);
                 txtquantity.Value = item.quantity;
               

                  
                  comboSaleType.SelectedIndex = comboSaleType.FindString(item.saletype.Name);
                   

              
                 //txtCustomerName.Text = dataGridView1.CurrentRow.Cells["CustomerName"].Value.ToString();
                 //txtCustomerPhone.Text = dataGridView1.CurrentRow.Cells["CustomerPhone"].Value.ToString();
                 //lblCustomerID.Text = dataGridView1.CurrentRow.Cells["CustomerID"].Value.ToString();

                  txtCustomerName.Text = item.customer.Name;
                  txtCustomerPhone.Text = item.customer.Phone;
                  lblCustomerID.Text = item.customer.ID.ToString();

                txtAmount.Text = item.Amt.ToString();
               txtNetAmount.Text = item.NetAmt.ToString();
                //  comboSaleType.SelectedIndex = comboSaleType.FindString(item.saletype.Name);
               comboSellPrice.Items.Clear();
               comboSellPrice.Items.Add(item.stock.Price);
               comboSellPrice.Items.Add(stockcontrol.getStockPrice((int)item.stock.ID).ToString());
             

               if (comboSellPrice.Items.Count > 0)
                   comboSellPrice.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return true;
            }
            return false;
        }

       

        private void calculate()
        {
            
            if (item != null)
            {
                item.Amt = (item.stock.Price * item.quantity);

                item.NetAmt = item.Amt - item.discount;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                try
                {
                    item.stock = stockcontrol.getByName(StockCombo.SelectedValue.ToString());
                    item.saletype = saletypecontrol.getByName(comboSaleType.SelectedValue.ToString());
                    getText();
                    calculate();
                    salecontrol.update(item);
                    if (string.IsNullOrEmpty(txtCustomerName.Text))
                    {
                        salecontrol.updateSaleType(item);
                    }
                    else
                    {
                        salecontrol.updateSaleType(item,getCustomerID(txtCustomerName.Text,txtCustomerPhone.Text));
                    }
                    
                    

                    txtNetAmount.Text = item.NetAmt.ToString();
                   // MessageBox.Show(item.toArray().ToString());
                    refreshData(salecontrol.getBySessionId((int)session.ID));

                    stockMgr.Receive(originalItem.stock, originalItem.quantity);
                    stockMgr.Dispatch(item.stock, item.quantity);

                    MessageBox.Show("Updated");
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
               
            
        }

        private void getText()
        {
           
            item.quantity = txtquantity.Value;
            item.discount = txtdiscount.Value;

            if (!string.IsNullOrEmpty(comboSellPrice.SelectedItem.ToString()))
                item.stock.Price = Convert.ToDecimal(comboSellPrice.SelectedItem.ToString());
                        
           
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            sessioncontrol.update(session);
        }

        private void btn_Sec_delete_Click(object sender, EventArgs e)
        {
            sessioncontrol.delete((int)session.ID);

            this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
              DialogResult result = MessageBox.Show(" Do you want to delete this SaleData?", "SaleData Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
              if (result == DialogResult.Yes)
              {
                  salecontrol.delete(item.ID);
                  stockMgr.Receive(item.stock, item.quantity);
                  refreshData(salecontrol.getBySessionId((int)session.ID));
              }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if(setSaledata())
            localPrint(salecontrol.getByVouncherID(item.VouncherID), profilecontrol.getAll());

        }
        private int getCustomerID(string Name, string PhoneNumber)
        {
            try
            {
                Contact contact = custCtrl.getByNameAndPhone(Name, PhoneNumber);
                if (contact != null)
                    return (int)contact.ID;
                else if (!string.IsNullOrEmpty(lblCustomerID.Text) && lblCustomerID.Text != "0")
                {
                     custCtrl.update(Name, PhoneNumber, int.Parse(lblCustomerID.Text));
                     return int.Parse(lblCustomerID.Text);
                }
                else if (!string.IsNullOrEmpty(lblCustomerID.Text) && lblCustomerID.Text != "")
                {
                    custCtrl.update(Name, PhoneNumber, int.Parse(lblCustomerID.Text));
                    return int.Parse(lblCustomerID.Text);
                }
                else
                    return custCtrl.save(Name, PhoneNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        private void localPrint(DataTable dtSale, DataTable dtCompany)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.Vouncher.rdlc";

            ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)dtSale);

            localReport.DataSources.Add(mydatasource);

            ReportDataSource mydatasource2 = new ReportDataSource("DataSet2", (DataTable)dtCompany);

            localReport.DataSources.Add(mydatasource2);
            localReport.Print();
        }

        private void setAutoCompleteCustomer()
        {
             dtcustomer = custCtrl.getAll();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(dtcustomer.AsEnumerable().Select(r => r.Field<string>("Name")).ToArray());
            txtCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerName.AutoCompleteCustomSource = collection;

            AutoCompleteStringCollection collectionPhone = new AutoCompleteStringCollection();
            collectionPhone.AddRange(dtcustomer.AsEnumerable().Select(r => r.Field<string>("Phone")).ToArray());
            txtCustomerPhone.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCustomerPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerPhone.AutoCompleteCustomSource = collectionPhone;



        }
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            /*
            TextBox tb = (TextBox)sender;
            AutoCompleteStringCollection customSource = tb.AutoCompleteCustomSource;
            int index = customSource.IndexOf(tb.Text);

            if (index >= 0)
            {
                txtCustomerPhone.Text = txtCustomerPhone.AutoCompleteCustomSource[index];
            }
             */
            try
            {
                if (!string.IsNullOrEmpty(txtCustomerName.Text))
                {
                    AutoCompleteStringCollection collectionPhone = new AutoCompleteStringCollection();
                    if (dtcustomer != null)
                    {
                        var results = from myRow in dtcustomer.AsEnumerable()
                                      where myRow.Field<string>("Name") == txtCustomerName.Text
                                      select myRow.Field<String>("Phone");
                        string result = results.FirstOrDefault<string>();
                        if (!string.IsNullOrEmpty(result))
                            txtCustomerPhone.Text = result;
                        //collectionPhone.AddRange(results.ToArray());

                        //txtCustomerPhone.AutoCompleteCustomSource = collectionPhone;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            /*
            TextBox tb = (TextBox)sender;
            AutoCompleteStringCollection customSource = tb.AutoCompleteCustomSource;
            int index = customSource.IndexOf(tb.Text);

            if (index >= 0)
            {
                txtCustomerName.Text = txtCustomerName.AutoCompleteCustomSource[index];
            }
             */
            try
            {
                if (!string.IsNullOrEmpty(txtCustomerPhone.Text))
                {
                    AutoCompleteStringCollection collectionPhone = new AutoCompleteStringCollection();
                    if (dtcustomer != null)
                    {
                        var results = from myRow in dtcustomer.AsEnumerable()
                                      where myRow.Field<string>("Phone") == txtCustomerPhone.Text
                                      select myRow.Field<String>("Name");
                        string result = results.FirstOrDefault<string>();
                        if (!string.IsNullOrEmpty(result))
                            txtCustomerName.Text = result;
                        //collectionPhone.AddRange(results.ToArray());

                        //txtCustomerPhone.AutoCompleteCustomSource = collectionPhone;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StockCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!String.IsNullOrEmpty(StockCombo.SelectedValue.ToString()) && comboSellPrice.Items.Count > 1)
                {
                   
                    Stock changedstock = stockcontrol.getByName(StockCombo.SelectedValue.ToString());

                    if (changedstock != null)
                    {
                        comboSellPrice.Items.RemoveAt(1);
                        comboSellPrice.Items.Insert(1, changedstock.Price);
                        comboSellPrice.SelectedIndex = 1;
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
