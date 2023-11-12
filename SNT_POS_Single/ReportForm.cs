using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SNT_POS_Common.Controller;
using SNT_POS_Common.utility;

namespace SNT_POS_Single_Management
{
    public partial class ReportForm : Form
    {
        #region Ref
        SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_companyTableAdapter tbl_company = new SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_companyTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.SaleDataTable1TableAdapter tbl_Sale = new SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.SaleDataTable1TableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_StockSummaryTableAdapter tbl_StockSummary = new Data.SNT_POS_DBDataSetTableAdapters.tbl_StockSummaryTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.SaleSummaryTableAdapter SaleSummary = new Data.SNT_POS_DBDataSetTableAdapters.SaleSummaryTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_StockIn2TableAdapter tbl_StockIn = new Data.SNT_POS_DBDataSetTableAdapters.tbl_StockIn2TableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.UnitRS2TableAdapter tbl_UnitRS = new Data.SNT_POS_DBDataSetTableAdapters.UnitRS2TableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_StockTableAdapter tbl_Stock = new Data.SNT_POS_DBDataSetTableAdapters.tbl_StockTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.StockInSummaryTableAdapter StockInSummary = new Data.SNT_POS_DBDataSetTableAdapters.StockInSummaryTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_VendorTableAdapter vendorList = new Data.SNT_POS_DBDataSetTableAdapters.tbl_VendorTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.tbl_CustomerTableAdapter customerList = new Data.SNT_POS_DBDataSetTableAdapters.tbl_CustomerTableAdapter();
      SNT_POS_Single_Management.Data.SNT_POS_DBDataSetTableAdapters.StockSummary2TableAdapter StockSummary2 = new Data.SNT_POS_DBDataSetTableAdapters.StockSummary2TableAdapter();
      StockInController stockIn2 = new StockInController();
      DataTable dt;

      StockController stockcontrol = new StockController();
        #endregion

      public ReportForm()
        {
            InitializeComponent();
        }
        public void addCombo(DataTable dt)
        {
            try
            {
                if (dt != null)
                {


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

        private void ReportForm_Load(object sender, EventArgs e)
        {
            startDate.Value = DateTime.Today;
            endDate.Value = DateTime.Today.AddDays(1);
            //this.Dock = DockStyle.Fill;

            if (String.IsNullOrEmpty(txtfilter.Text))
            {
                if (this.Text == "Sale Detail Report")
                    previewSaleDetail();
                else if (this.Text == "Daily Sale Report")
                    previewDailySaleSummary();
                else if (this.Text == "Daily Sale Chart Report")
                    previewDailySaleChartSummary();
                else if (this.Text == "Stock Summary Report")
                    previewStockSummary();
                else if (this.Text == "Latest Stock with StockImage Report")
                    previewStockSummary2();
                else if (this.Text == "Stock In Report")
                    previewStockIN();
                else if (this.Text == "Stock Price Difference Report")
                    previewStockPriceDifference();
                else if (this.Text == "Unit Relation Report")
                    previewUnitRelation();
                else if (this.Text == "Stock Menu Report")
                    previewStockMenu();
                else if (this.Text == "Expire Date Report")
                    previewExpireDate();
                else if (this.Text == "Low Balance Stock Report")
                    previewLowBalanceStock();
                else if (this.Text == "Vendor List Report")
                    previewVendorList();
                else if (this.Text == "Customer List Report")
                    previewCustomerList();
                else if (this.Text == "Stock Checker Report")
                    previewStockChecker(string.Empty);

            }
            addCombo(this.dt);
           setAutoCompletefilter();
           // previewSaleDetail();
        }
        private void setAutoCompletefilter()
        {
            try
            {
                txtfilter.AutoCompleteSource = AutoCompleteSource.None;
                if (dt != null)
                {
                    
                    // DataTable dtStock = stockcontrol.getAll();
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    //collection.AddRange(dtStock.AsEnumerable().Select(r => r.Field<string>("StockName")).ToArray());
                    if(comboSearch.SelectedItem.ToString()=="StockName")
                    {
                        collection.AddRange(stockcontrol.getAll().AsEnumerable().Select(r => r.Field<string>("StockName")).Where<string>(s => !string.IsNullOrEmpty(s)).ToArray());
                    }
                    else if (dt.Columns[comboSearch.SelectedItem.ToString()].DataType == typeof(string))
                    {
                        collection.AddRange(dt.AsEnumerable().Select(r => r.Field<string>(comboSearch.SelectedItem.ToString())).Where<string>(s => !string.IsNullOrEmpty(s)).ToArray());
                    }
                    txtfilter.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtfilter.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtfilter.AutoCompleteCustomSource = collection;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void setMinValue(decimal num)
        {
            numMinValue.Value = num;
        }
        public void setMaxValue(decimal num)
        {
            numMaxValue.Value = num;
        }
        public void previewSaleDetail(string filterText=null)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.SaleDetail.rdlc";
           
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource mydatasource;
            if (String.IsNullOrEmpty(filterText))
            {
                this.dt = tbl_Sale.GetDataByDT(startDate.Value, endDate.Value);
                mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
            }
            else
            {
                mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_Sale.GetDataByDT(startDate.Value, endDate.Value).filter(filterText, comboSearch.SelectedItem.ToString()));
            }
           
            this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

            ReportDataSource mydatasource2 = new ReportDataSource("DataSet2", (DataTable)tbl_company.GetData());

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);

               
                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText",filterText==null?"null":filterText);
                this.reportViewer1.LocalReport.SetParameters(parameters);
           
           

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

        }
        public void previewUnitRelation(string filterText = null)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.UnitRelation.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource mydatasource;
            if (String.IsNullOrEmpty(filterText))
            {
                this.dt = tbl_UnitRS.GetData();
                mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
            }
            else
            {
                mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_UnitRS.GetData().filter(filterText, comboSearch.SelectedItem.ToString()));
            }

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

            ReportDataSource mydatasource2 = new ReportDataSource("DataSet2", (DataTable)tbl_company.GetData());

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
            parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
            parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
            this.reportViewer1.LocalReport.SetParameters(parameters);



            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

        }
        public void previewVendorList(string filterText = null)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.VendorListReport.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource mydatasource;
            if (String.IsNullOrEmpty(filterText))
            {
                this.dt = vendorList.GetData();
                mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
            }
            else
            {
                mydatasource = new ReportDataSource("DataSet1", (DataTable)vendorList.GetData().filter(filterText, comboSearch.SelectedItem.ToString()));
            }

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

            ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
            parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
            parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
            this.reportViewer1.LocalReport.SetParameters(parameters);



            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

        }
        public void previewCustomerList(string filterText = null)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.VendorListReport.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource mydatasource;
            if (String.IsNullOrEmpty(filterText))
            {
                this.dt = customerList.GetData();
                mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
            }
            else
            {
                mydatasource = new ReportDataSource("DataSet1", (DataTable)customerList.GetData().filter(filterText, comboSearch.SelectedItem.ToString()));
            }

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

            ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

            this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
            parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
            parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
            this.reportViewer1.LocalReport.SetParameters(parameters);



            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

        }
        public void previewStockIN(string filterText=null)
        {
           
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.StockIn.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                 ReportDataSource mydatasource;
                 if (String.IsNullOrEmpty(filterText))
                 {
                     this.dt = tbl_StockIn.GetDataByDT(startDate.Value, endDate.Value);
                     mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
                 }
                 else
                 {
                     mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockIn.GetDataByDT(startDate.Value, endDate.Value).filter(filterText,comboSearch.SelectedItem.ToString()));
                    
                 }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);

                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());

                this.reportViewer1.LocalReport.SetParameters(parameters);
                
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void previewExpireDate(string filterText = null)
        {

            try
            {
                dt = new DataTable();
                dt.Columns.Add("StockID", typeof(int));
                dt.Columns.Add("StockName", typeof(string));
                dt.Columns.Add("StockBalance", typeof(string));

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.ExpireDate.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource;
                if (String.IsNullOrEmpty(filterText))
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)StockInSummary.GetDataByExpireDate(DateTime.Today.AddDays(Convert.ToDouble(numMinValue.Value))));
                    //mydatasource = new ReportDataSource("DataSet1", (DataTable)stockIn2.getLatestStockBalance());
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)StockInSummary.GetDataByExpireDate(DateTime.Today.AddDays(Convert.ToDouble(numMinValue.Value))).filter(filterText, comboSearch.SelectedItem.ToString()));
                    //mydatasource = new ReportDataSource("DataSet1", (DataTable)stockIn2.getLatestStockBalance().DefaultView.filter(filterText).ToTable());

                }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);

                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());

                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void previewStockPriceDifference(string filterText = null)
        {
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.StockPriceDifference.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource;
                if (String.IsNullOrEmpty(filterText))
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockIn.GetDataByDT(startDate.Value, endDate.Value));
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockIn.GetDataByDT(startDate.Value, endDate.Value).filter(filterText,comboSearch.SelectedItem.ToString()));
                }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void previewStockMenu(string filterText = null)
        {
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.StockMenu.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource;
                if (String.IsNullOrEmpty(filterText))
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_Stock.GetData());
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_Stock.GetData().DefaultView.filter(filterText).ToTable());
                }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void previewStockSummary(string filterText = null)
        {
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.StockSummary.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource;
                if (string.IsNullOrEmpty(filterText))
                {
                    this.dt = tbl_StockSummary.GetStockDataByDT(startDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value, endDate.Value);
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetStockDataByDT(startDate.Value,startDate.Value, endDate.Value, startDate.Value, startDate.Value, endDate.Value).filter(filterText,comboSearch.SelectedItem.ToString()));
                   /* SearchForm sf = new SearchForm();
                    sf.addData(tbl_StockSummary.GetStockDataByDT(startDate.Value, endDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value).DefaultView.filter(filterText).ToTable());
                    sf.Show();
                   */
                }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);


                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Stock Summary Error");
            }
        }
        public void previewStockSummary2(string filterText = null)
        {
          
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.StockSummary2.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource;

               

               
                if (string.IsNullOrEmpty(filterText))
                {
                    this.dt = StockSummary2.GetData();
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)StockSummary2.GetData().filter(filterText, comboSearch.SelectedItem.ToString()));
                    
                   
                }
           
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);
                

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Stock Summary Error");
            }
            
        }

        public void previewLowBalanceStock(string filterText = null)
        {
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.LowBalanceStockSummary.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource;
                if (string.IsNullOrEmpty(filterText))
                {
                    this.dt = tbl_StockSummary.GetDataByClosingBalance(startDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value, endDate.Value);
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)dt);
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetStockDataByDT(startDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value, endDate.Value).DefaultView.filter(filterText).ToTable());
                    /* SearchForm sf = new SearchForm();
                     sf.addData(tbl_StockSummary.GetStockDataByDT(startDate.Value, endDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value).DefaultView.filter(filterText).ToTable());
                     sf.Show();
                    */
                }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);


                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void previewDailySaleSummary(string filterText = null)
        {
            try
            {
             
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.Summary.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource; ReportDataSource mydatasource3;
                
                dt = new DataTable();
                dt.Columns.Add("StockID", typeof(int));
                dt.Columns.Add("StockName", typeof(string));
                dt.Columns.Add("UnitName", typeof(string));
                if (string.IsNullOrEmpty(filterText))
                 {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetDataByDT(startDate.Value, endDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value));
                    mydatasource3 = new ReportDataSource("DataSet2", (DataTable)SaleSummary.GetDataByDT(startDate.Value, endDate.Value));
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetDataByDT(startDate.Value, endDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value).DefaultView.filter(filterText).ToTable());
                    mydatasource3 = new ReportDataSource("DataSet2", (DataTable)SaleSummary.GetDataByDT(startDate.Value, endDate.Value).DefaultView.filter(filterText).ToTable());
                }
               
               // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);

                
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource3);

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);
                
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void previewDailySaleChartSummary(string filterText = null)
        {
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.ChartSummary.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource mydatasource; ReportDataSource mydatasource3;

                dt = new DataTable();
                dt.Columns.Add("StockID", typeof(int));
                dt.Columns.Add("StockName", typeof(string));
                dt.Columns.Add("UnitName", typeof(string));
                if (string.IsNullOrEmpty(filterText))
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetDataByDT(startDate.Value, endDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value));
                    mydatasource3 = new ReportDataSource("DataSet2", (DataTable)SaleSummary.GetDataByDT(startDate.Value, endDate.Value));
                }
                else
                {
                    mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetDataByDT(startDate.Value, endDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value).DefaultView.filter(filterText).ToTable());
                    mydatasource3 = new ReportDataSource("DataSet2", (DataTable)SaleSummary.GetDataByDT(startDate.Value, endDate.Value).DefaultView.filter(filterText).ToTable());
                }

                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
                this.reportViewer1.LocalReport.DataSources.Add(mydatasource);


                this.reportViewer1.LocalReport.DataSources.Add(mydatasource3);

                ReportDataSource mydatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtfilter.Text))
            {
                if (this.Text == "Sale Detail Report")
                    previewSaleDetail();
                else if (this.Text == "Daily Sale Report")
                    previewDailySaleSummary();
                else if (this.Text == "Daily Sale Chart Report")
                    previewDailySaleChartSummary();
                else if (this.Text == "Stock Summary Report")
                    previewStockSummary();
                else if (this.Text == "Latest Stock with StockImage Report")
                    previewStockSummary2();
                else if (this.Text == "Stock In Report")
                    previewStockIN();
                else if (this.Text == "Stock Price Difference Report")
                    previewStockPriceDifference();
                else if (this.Text == "Unit Relation Report")
                    previewUnitRelation();
                else if (this.Text == "Stock Menu Report")
                    previewStockMenu();
                else if (this.Text == "Expire Date Report")
                    previewExpireDate();
                else if (this.Text == "Low Balance Stock Report")
                    previewLowBalanceStock();
                else if (this.Text == "Vendor List Report")
                    previewVendorList();
                else if (this.Text == "Customer List Report")
                    previewCustomerList();
                
            }
            else if(!String.IsNullOrEmpty(txtfilter.Text))
            {
               // MessageBox.Show("Testing filter");

                if (this.Text == "Sale Detail Report")
                    previewSaleDetail(txtfilter.Text);
                else if (this.Text == "Daily Sale Report")
                    previewDailySaleSummary(txtfilter.Text);
                else if (this.Text == "Daily Sale Chart Report")
                    previewDailySaleChartSummary(txtfilter.Text);
                else if (this.Text == "Stock Summary Report")
                    previewStockSummary(txtfilter.Text);
                else if (this.Text == "Latest Stock with StockImage Report")
                    previewStockSummary2(txtfilter.Text);
                else if (this.Text == "Stock Price Difference Report")
                    previewStockPriceDifference(txtfilter.Text);
                else if (this.Text == "Stock In Report")
                    previewStockIN(txtfilter.Text);
                else if (this.Text == "Unit Relation Report")
                    previewUnitRelation(txtfilter.Text);
                else if (this.Text == "Stock Menu Report")
                    previewStockMenu(txtfilter.Text);
                else if (this.Text == "Expire Date Report")
                    previewExpireDate(txtfilter.Text);
                else if (this.Text == "Low Balance Stock Report")
                    previewLowBalanceStock(txtfilter.Text);
                else if (this.Text == "Vendor List Report")
                    previewVendorList(txtfilter.Text);
                else if (this.Text == "Customer List Report")
                    previewCustomerList(txtfilter.Text);
                else if (this.Text == "Stock Checker Report")
                    previewStockChecker(txtfilter.Text);
            }

            setAutoCompletefilter();

            
            
        }
        private void previewStockChecker(string filterText)
        {
            try
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Management.Report.StockChecker.rdlc";

                this.reportViewer1.LocalReport.DataSources.Clear();

                dt = new DataTable();
                dt.Columns.Add("StockID", typeof(int));
                dt.Columns.Add("StockName", typeof(string));
                dt.Columns.Add("UnitName", typeof(string));
               
                if (string.IsNullOrEmpty(filterText))
                {
                    txtfilter.Focus();
                }
                else
                {
                    ReportDataSource companyDatasource2 = new ReportDataSource("DsCompany", (DataTable)tbl_company.GetData());

                    this.reportViewer1.LocalReport.DataSources.Add(companyDatasource2);
                    ReportDataSource summaryDatasource = new ReportDataSource("StockSummaryDataSet", (DataTable)tbl_StockSummary.GetStockDataByDT(startDate.Value, startDate.Value, endDate.Value, startDate.Value, startDate.Value, endDate.Value).filter(filterText, comboSearch.SelectedItem.ToString()));
                    this.reportViewer1.LocalReport.DataSources.Add(summaryDatasource);
                    ReportDataSource saleDatasource = new ReportDataSource("SaleDataSet", (DataTable)tbl_Sale.GetDataByDT(startDate.Value, endDate.Value).filter(filterText, comboSearch.SelectedItem.ToString()));
                    this.reportViewer1.LocalReport.DataSources.Add(saleDatasource);
                    ReportDataSource stockInDatasource = new ReportDataSource("StockInDataSet", (DataTable)tbl_StockIn.GetDataByDT(startDate.Value, endDate.Value).filter(filterText, comboSearch.SelectedItem.ToString()));
                    this.reportViewer1.LocalReport.DataSources.Add(stockInDatasource);
                   

                }
                // ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)tbl_StockSummary.GetData());
              


                


                ReportParameter[] parameters = new ReportParameter[5];
                parameters[0] = new ReportParameter("fromDate", startDate.Value.ToString());
                parameters[1] = new ReportParameter("toDate", endDate.Value.ToString());
                parameters[2] = new ReportParameter("filterText", filterText == null ? "null" : filterText);
                parameters[3] = new ReportParameter("minValue", numMinValue.Value.ToString());
                parameters[4] = new ReportParameter("maxValue", numMaxValue.Value.ToString());
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Stock Summary Error");
            }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilter.Clear();
            setAutoCompletefilter();
        }
    }
}
