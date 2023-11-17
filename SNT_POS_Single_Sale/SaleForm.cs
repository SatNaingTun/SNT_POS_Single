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
using Microsoft.Reporting.WinForms;
using SNTPOS_UI_Common;
using SNT_POS_Common.utility;
using SNT_POS_Single.BussinessRule;


namespace SNT_POS_Single_Sale
{
    public partial class SaleForm : Form
    {
        StockController stockcontrol = new StockController();
        //AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
        DataTable dtStock; DataTable dtcustomer;
        Vouncher_Item item;
        SaleController salecontrol = new SaleController();
        SessionController sessioncontrol = new SessionController();
        SaleTypeController saletypecontrol = new SaleTypeController(); Session session;
        CompanyProfileController profilecontrol = new CompanyProfileController();
        CustomerController custCtrl = new CustomerController();
        //List<Vouncher_Item> vrlist=new List<Vouncher_Item>();

        /*
        public SaleForm()
        {
            InitializeComponent();
        }
         */
        public SaleForm(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            setAutoCompleteCustomer();
            try
            {
                addStockData(stockcontrol.getAllwithUnitName());
                comboSearch.setDataColName(ref dtStock);
                suggestGrid.changeImageLayout(DataGridViewImageCellLayout.Zoom);

                lblUserName.Text = session.user.Name;
                // lblSessionID.Text= sessioncontrol.getByUserId(LoginInfo.userId).Rows[0].Field<int>("ID").ToString();


                DataTable dtSaleType = saletypecontrol.getAll();
                comboSaleType.DataSource = dtSaleType;
                comboSaleType.ValueMember = dtSaleType.Columns["SaleTypeName"].ToString();
                comboSaleType.DisplayMember = dtSaleType.Columns["SaleTypeName"].ToString();
                if (comboSaleType.Items.Count >= 0)
                    comboSaleType.SelectedIndex = 0;

                /*
               DataTable dtSession = sessioncontrol.getByUserId(LoginInfo.userId);
          
                   int sessionid2=dtSession.Rows[0].Field<int>("ID");
                   lblSessionID.Text = sessionid2.ToString();
               */


                lblSessionID.Text = session.ID.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addStockData(DataTable dt)
        {
            this.dtStock = dt;
            if (dt != null)
            {
                suggestGrid.DataSource = dt;
                
            }


        }

        private void txtStockName_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                suggestGrid.DataSource = dtStock.filter(txtStockName.Text, comboSearch.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //selectRow();
            getStockdata(false);
            calculate();
            setData();
        }


        private void suggestGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            getStockdata();
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



        private void btnRefresh_Click(object sender, EventArgs e)
        {

            addStockData(stockcontrol.getAllwithUnitName());
            txtStockName.Clear();
            setAutoCompleteCustomer();
        }
        private void getStockdata(bool setStockName = true)
        {
            if (suggestGrid.CurrentRow != null && btnAddCart.Text != "Update")
            {
                item = new Vouncher_Item();
                //  item.stock=new Stock();
                //  item.stock.ID = (int)suggestGrid.CurrentRow.Cells["ID"].Value;
                // item.stock.Name = suggestGrid.CurrentRow.Cells["StockName"].Value.ToString();
                //item.stock.Price = (decimal)suggestGrid.CurrentRow.Cells["Price"].Value;
                item.stock = stockcontrol.getById((int)suggestGrid.CurrentRow.Cells["ID"].Value);
                item.quantity = txtquantity.Value;
                item.discount = txtdiscount.Value;

                if (setStockName)
                    txtStockName.Text = item.stock.Name;


                lblUnitName.Text = item.stock.unit.Name;
                lblUnitID.Text = item.stock.unit.ID.ToString();

            }
            else if (suggestGrid.CurrentRow != null && btnAddCart.Text == "Update")
            {
                item.stock.Price = (decimal)suggestGrid.CurrentRow.Cells["Price"].Value;
                item.quantity = txtquantity.Value;
                item.discount = txtdiscount.Value;
            }

        }

        private void setData()
        {
            if (item != null)
            {
                txtPrice.Text = item.stock.Price.ToString();
                txtAmount.Text = item.Amt.ToString();
                txtNetAmount.Text = item.NetAmt.ToString();
            }
        }
        private void calculate()
        {

            if (item != null)
            {
                item.Amt = (item.stock.Price * item.quantity);

                item.NetAmt = item.Amt - item.discount;
            }

        }


        private void data_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyData & e.KeyCode) == Keys.Enter || (e.KeyData & e.KeyCode) == Keys.Tab)
            {
                getStockdata();
                calculate();
                setData();
            }
            if ((e.KeyData & e.KeyCode) == Keys.F5)
            {
                addStockData(stockcontrol.getAllwithUnitName());
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            getStockdata();
            if (item != null)
            {


                calculate();
                setData();
                if (hasStockAlreadyExist() == false)
                {
                    saleGridView1.Rows.Add(item.toArray());
                }
                else if (btnAddCart.Text == "Update")
                {
                    updateSaleGrid(getStockindex());
                    btnAddCart.Text = "Add to Cart";
                    btn_delete.Visible = false;
                }
                else
                {
                    updateSaleGrid(getStockindex(), true);
                }
                //vrlist.Add(item);
                //saleGridView1.DataSource = vrlist;

                txtTotal.Text = getToalNetAmt().ToString();

                txtdiscount.Value = 0;
                txtquantity.Value = 1;
                addStockData(stockcontrol.getAllwithUnitName());
                txtStockName.Clear();


            }
            else
            {
                MessageBox.Show("User must add  stock data");
            }


        }
        private void updateSaleGrid(int ri, bool autoIncrement = false)
        {
            if (autoIncrement == true)
            {
                item.quantity += (decimal)saleGridView1.Rows[ri].Cells["Quantity"].Value;
                item.Amt += (decimal)saleGridView1.Rows[ri].Cells["Amount"].Value;
                item.discount += (decimal)saleGridView1.Rows[ri].Cells["Discount"].Value;
                item.NetAmt += (decimal)saleGridView1.Rows[ri].Cells["NetAmount"].Value;
            }
            calculate();

            saleGridView1.Rows[ri].Cells["Price"].Value = item.stock.Price;

            saleGridView1.Rows[ri].Cells["Quantity"].Value = item.quantity;

            saleGridView1.Rows[ri].Cells["Amount"].Value = item.Amt;

            saleGridView1.Rows[ri].Cells["Discount"].Value = item.discount;

            saleGridView1.Rows[ri].Cells["NetAmount"].Value = item.NetAmt;



        }

        private bool hasStockAlreadyExist()
        {
            foreach (DataGridViewRow row in saleGridView1.Rows)
            {
                if (item.stock.ID == (int)row.Cells["StockID"].Value) return true;
                //More code here
            }

            return false;
        }
        private double getToalNetAmt()
        {
            double total = 0;
            foreach (DataGridViewRow row in saleGridView1.Rows)
            {
                total += Convert.ToDouble(row.Cells["NetAmount"].Value);
            }
            return total;
        }
        private int getStockindex()
        {
            foreach (DataGridViewRow row in saleGridView1.Rows)
            {
                if (item.stock.ID == (int)row.Cells["StockID"].Value) return row.Index;
                //More code here
            }

            return -1;
        }



        private void SaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "SNT POS Closing", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    session.LogoutDT = DateTime.Now;
                    sessioncontrol.update(session);
                    //MessageBox.Show("Logout");
                    //logout();
                    Environment.Exit(0);

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void saleGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            item = new Vouncher_Item();
            item.stock = new Stock();
            item.stock.ID = (int)saleGridView1.CurrentRow.Cells["StockID"].Value;
            txtStockName.Text = item.stock.Name = saleGridView1.CurrentRow.Cells["StockName"].Value.ToString();
            item.stock.Price = (decimal)saleGridView1.CurrentRow.Cells["Price"].Value;
            item.quantity = (decimal)saleGridView1.CurrentRow.Cells["Quantity"].Value;
            txtquantity.Value = item.quantity;
            item.discount = (decimal)saleGridView1.CurrentRow.Cells["Discount"].Value;
            txtdiscount.Value = item.discount;
            item.Amt = (decimal)saleGridView1.CurrentRow.Cells["Amount"].Value;
            item.NetAmt = (decimal)saleGridView1.CurrentRow.Cells["NetAmount"].Value;
            setData();
            btnAddCart.Text = "Update";
            btn_delete.Visible = true;
        }

        private void btnVrSave_Click(object sender, EventArgs e)
        {
            StockManager stockMgr = new StockManager();
            if (saleGridView1.Rows.Count > 0)
            {


                try
                {
                    if (comboSaleType.SelectedValue.ToString() == "Credit" && string.IsNullOrEmpty(txtCustomerName.Text))
                    {
                        txtCustomerName.Focus();
                        throw new ArgumentException("Customer Info need to be added in credit sale");
                    }

                    string curDate = DateTime.Today.ToString("yyyyMMdd");

                    int VrCount = sessioncontrol.getVrCount((int)session.ID); VrCount++;

                    string VouncherID = "S" + lblSessionID.Text + "-" + curDate + "-" + VrCount.ToString("0000");


                    List<Vouncher_Item> list = toVouncherList(saleGridView1);
                    int CustomerID = 0;
                    if (!string.IsNullOrEmpty(txtCustomerName.Text))
                    {
                        try
                        {
                            CustomerID = getCustomerID(txtCustomerName.Text, txtCustomerPhone.Text, txtCustAddress.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Customer Data Error");
                        }
                        //MessageBox.Show("Return CustomerID is " + CustomerID);
                    }
                    foreach (Vouncher_Item item in list)
                    {
                        item.VouncherID = VouncherID;
                        item.saletype = new SaleType();
                        item.saletype = saletypecontrol.getByName(comboSaleType.SelectedValue.ToString());
                        if (string.IsNullOrEmpty(txtCustomerName.Text))
                        {
                            salecontrol.save(item, session);
                        }
                        else
                        {
                            salecontrol.save(item, session, CustomerID);
                        }
                        stockMgr.Dispatch(item.stock, item.quantity);
                        
                    }

                    sessioncontrol.setVrCount((int)session.ID, VrCount);
                    txtTotal.Text = "0";

                    DialogResult result = MessageBox.Show("Do you  want to Print?", "SNT POS Printing", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                        localPrint(salecontrol.getByVouncherID(VouncherID), profilecontrol.getAll());

                        /*
                        using (VrReport vr = new VrReport())
                        {
                            vr.LoadData(salecontrol.getByVouncherID(VouncherID), profilecontrol.getAll());
                            vr.Show();
                            vr.localPrint();
                        }
                         */
                    }


                    saleGridView1.Rows.Clear();
                    txtCustomerName.Clear();
                    txtCustomerPhone.Clear();
                    txtCustAddress.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void localPrint(DataTable dtSale, DataTable dtCompany)
        {
            try
            {
                LocalReport localReport = new LocalReport();
                localReport.ReportEmbeddedResource = "SNT_POS_Single_Sale.Report.Vouncher.rdlc";

                ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)dtSale);

                localReport.DataSources.Add(mydatasource);

                ReportDataSource mydatasource2 = new ReportDataSource("DataSet2", (DataTable)dtCompany);

                localReport.DataSources.Add(mydatasource2);

                localReport.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<Vouncher_Item> toVouncherList(DataGridView datagridview)
        {
            List<Vouncher_Item> vouncherlist = new List<Vouncher_Item>();

            foreach (DataGridViewRow row in datagridview.Rows)
            {

                vouncherlist.Add(new Vouncher_Item
                 {
                     stock = new Stock()
                     {
                         ID = (int)row.Cells["StockID"].Value,
                         Name = (string)row.Cells["StockName"].Value,
                         Price = (decimal)row.Cells["Price"].Value,
                         Balance = (decimal)row.Cells["StockBalance"].Value
                     },
                     quantity = (decimal)row.Cells["Quantity"].Value,
                     Amt = (decimal)row.Cells["Amount"].Value,
                     discount = (decimal)row.Cells["Discount"].Value,
                     NetAmt = (decimal)row.Cells["NetAmount"].Value,





                 });

            }


            return vouncherlist;
        }
        private int getCustomerID(string Name, string PhoneNumber, string Address)
        {
            try
            {
                Contact contact = custCtrl.getByNameAndPhone(Name, PhoneNumber);
                if (contact != null)
                    return (int)contact.ID;
                else
                    return custCtrl.save(Name, PhoneNumber, Address);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        private DataTable toDataTable(DataGridView datagridview)
        {
            DataTable dt = new DataTable();

            /*
             foreach (DataGridViewColumn column in datagridview.Columns)
                 dt.Columns.Add(column.Name, typeof(string));
         
            */
            dt.Columns.Add("StockID", typeof(int));
            dt.Columns.Add("StockName", typeof(string));
            for (int k = 2; k < datagridview.Columns.Count; k++)
                dt.Columns.Add(datagridview.Columns[k].Name, typeof(decimal));

            for (int i = 0; i < datagridview.Rows.Count; i++)
            {
                dt.Rows.Add();
                for (int j = 0; j < datagridview.Columns.Count; j++)
                {
                    dt.Rows[i][j] = datagridview.Rows[i].Cells[j].Value;

                }
            }
            return dt;

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                saleGridView1.Rows.RemoveAt(getStockindex());
                txtTotal.Text = getToalNetAmt().ToString();
                btnAddCart.Text = "Add to Cart";
                btn_delete.Visible = false;
            }
        }

        private void txtquantity_ValueChanged(object sender, EventArgs e)
        {
            getStockdata();
            calculate();
            setData();
        }

        private void txtdiscount_ValueChanged(object sender, EventArgs e)
        {
            getStockdata();
            calculate();
            setData();
        }

        private void btn_calc_Unit_Click(object sender, EventArgs e)
        {
            try
            {
                getStockdata();
                using (UnitCalculator calculator = new UnitCalculator())
                {
                    calculator.addData((int)item.stock.ID);
                    calculator.setConnectionString(Properties.Settings.Default.SNT_POS_DBConnectionString);
                    if (calculator.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {

                        txtquantity.Value = calculator.getCalculatedQuantity();
                        txtdiscount.Value = txtquantity.Value * item.stock.Price - calculator.getInsertedPrice();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                        var results2 = from myRow in dtcustomer.AsEnumerable()
                                       where myRow.Field<string>("Name") == txtCustomerName.Text
                                       select myRow.Field<String>("Address");
                        string result2 = results.FirstOrDefault<string>();
                        if (!string.IsNullOrEmpty(result2))
                            txtCustAddress.Text = result2;

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

                        var results2 = from myRow in dtcustomer.AsEnumerable()
                                       where myRow.Field<string>("Phone") == txtCustomerPhone.Text
                                       select myRow.Field<String>("Address");
                        string result2 = results.FirstOrDefault<string>();
                        if (!string.IsNullOrEmpty(result2))
                            txtCustAddress.Text = result2;
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

        public string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                System.Reflection.PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (System.Reflection.PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                            propertyInfo.GetValue(property, null),
                            propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                System.Reflection.PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        private void saleGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((saleGridView1.Rows[e.RowIndex].DataBoundItem != null) &&
        (saleGridView1.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = this.BindProperty(
                              saleGridView1.Rows[e.RowIndex].DataBoundItem,
                              saleGridView1.Columns[e.ColumnIndex].DataPropertyName
                            );
            }






        }
    }
}
