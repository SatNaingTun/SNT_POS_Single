using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SNT_POS_Single_Sale
{
    public partial class VrReport : Form
    {
        
        public VrReport()
        {
            InitializeComponent();
        }

        private void VrReport_Load(object sender, EventArgs e)
        {

           // this.reportViewer1.RefreshReport();
        }
        public void LoadData(DataTable dtSale, DataTable dtCompany)
        {
           this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNT_POS_Single_Sale.Report.Vouncher.rdlc";
           ReportDataSource mydatasource = new ReportDataSource("DataSet1", (DataTable)dtSale);
           this.reportViewer1.LocalReport.DataSources.Add(mydatasource);
           ReportDataSource mydatasource2 = new ReportDataSource("DataSet2", (DataTable)dtCompany);
           this.reportViewer1.LocalReport.DataSources.Add(mydatasource2);
            /*
           if (dtSale.Rows.Count > 3)
           {
               int Height = (dtSale.Rows.Count / 3) * 100 + 650;
               this.reportViewer1.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 350, Height);
           }
             */
           this.reportViewer1.RefreshReport();

        
          
        }

        public void localPrint()
        {
        
          LocalReport localreport = new LocalReport();
            localreport = reportViewer1.LocalReport;
            localreport.Print();
           
            
          
           
        }



      
    }
}
