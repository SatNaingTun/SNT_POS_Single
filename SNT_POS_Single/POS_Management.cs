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

namespace SNT_POS_Single_Management
{
    public partial class POS_Management : Form
    {
        FormMenuController formmenu = new FormMenuController();
        FormMenuControl_Controller formmenucontrol = new FormMenuControl_Controller();
        Session session;
        /*
        public POS_Management()
        {
            InitializeComponent();
        }
         */ 

        public POS_Management(Session session)
        {
            this.session = session;
            
            InitializeComponent();
            MenuVisible();
           
        }

        private void POS_Managementcs_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Form  Closing", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    foreach (Form frm in this.MdiChildren)
                        frm.Close();

                    
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
        private void setFitIcon(Form form)
        {
            var bmp = new Bitmap(16, 16);
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(form.Icon.ToBitmap(), new Rectangle(0, 0, 16, 16));
            }
            var newIcon = Icon.FromHandle(bmp.GetHicon());
            form.Icon = newIcon;
        }
        
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm();
            uf.MdiParent = this;
            setFitIcon(uf);
            uf.Show();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleForm rf = new RoleForm();
            rf.MdiParent = this;
            setFitIcon(rf);
            rf.Show();

            
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockForm sf = new StockForm();
            sf.MdiParent = this;
            setFitIcon(sf);
            sf.Show();
        }

        private void POS_Management_Load(object sender, EventArgs e)
        {
            lblUserName.Text = session.user.Name;
            
             //MenuVisible();
        }
        public void MenuVisible()
        {

            foreach (ToolStripMenuItem menuItem in this.menuStrip1.Items)
            {
                int MenuID, ParentID;
                
                try
                {
                    if (formmenu.getIDByName(menuItem.Text) != 0)
                    {

                        menuItem.Visible = formmenucontrol.isAuthorize((int)session.user.role.ID, formmenu.getIDByName(menuItem.Text));
                        ParentID = formmenu.getIDByName(menuItem.Text);

                    }
                    else
                    {
                      MenuID=ParentID=  formmenu.save(menuItem.Text);
                      formmenucontrol.save((int)session.user.role.ID,MenuID, true);
                    }


                    foreach (ToolStripMenuItem subitem in menuItem.DropDownItems)
                    {
                        if (formmenu.getIDByName(subitem.Text) != 0)
                        {

                            subitem.Visible = formmenucontrol.isAuthorize((int)session.user.role.ID, formmenu.getIDByName(subitem.Text));


                        }
                        else
                        {
                           MenuID= formmenu.save(subitem.Text, ParentID);
                           formmenucontrol.save((int)session.user.role.ID, MenuID, true);

                        }
                       


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            
        }
        

        private void saleDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent=this;
            rf.Text = "Sale Detail Report";
            setFitIcon(rf);
          
            rf.Show();
        }
       

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInForm sif = new StockInForm();
            sif.MdiParent = this;
            setFitIcon(sif);
           
            sif.Show();
        }

        private void dailySaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Daily Sale Report";
            setFitIcon(rf);
            
            rf.Show();
        }

        private void sessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SessionListForm sessionList = new SessionListForm();
            sessionList.Show();
            setFitIcon(sessionList);
           
             
        }

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactform cf = new Contactform();
            cf.MdiParent = this;
            setFitIcon(cf);
            cf.Text = "Company Profile";
            cf.Show();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Stock In Report";
            rf.setMaxValue(365);
            
            setFitIcon(rf);
           
            rf.Show();
        }

        private void stockSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Stock Summary Report";
            setFitIcon(rf);
            
            rf.Show();
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitForm uf = new UnitForm();
            uf.MdiParent = this;
            setFitIcon(uf);
            uf.Show();
        }

        private void unitRelationShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitRSForm urf = new UnitRSForm();
            urf.MdiParent = this;
            setFitIcon(urf);
            urf.Show();
        }

        private void stockPriceDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Stock Price Difference Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void unitCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitRSForm urf = new UnitRSForm();
            urf.MdiParent = this;
            setFitIcon(urf);
            urf.Text = "Unit Calculator";
            urf.Show();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void dailySaleChartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Daily Sale Chart Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void unitRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Unit Relation Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void stockMenuReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Stock Menu Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void expireDateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Expire Date Report";
            setFitIcon(rf);
            rf.setMinValue(200);

            rf.Show();
        }

        private void customerProfleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactform cf = new Contactform();
            cf.MdiParent = this;
            setFitIcon(cf);
            cf.Text = "Customer Profile";
            cf.Show();
        }

        private void vendorProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactform cf = new Contactform();
            cf.MdiParent = this;
            setFitIcon(cf);
            cf.Text = "Vendor Profile";
            cf.Show();
        }

        private void lowBalanceStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Low Balance Stock Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void vendorListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Vendor List Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void customerListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Customer List Report";
            setFitIcon(rf);

            rf.Show();

        }

        private void latestStockWithStockImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Latest Stock with StockImage Report";
            setFitIcon(rf);

            rf.Show();
        }

        private void inactiveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InactiveForm icf = new InactiveForm();
            icf.MdiParent = this;
            setFitIcon(icf);
            icf.Show();
        }

        private void currencyUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitForm uf = new UnitForm();
            uf.MdiParent = this;
            uf.Text = "CurrencyUnitForm";
            setFitIcon(uf);
            uf.Show();
        }

        private void stockCheckerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.MdiParent = this;
            rf.Text = "Stock Checker Report";
            setFitIcon(rf);

            rf.Show();
        }

       
    }
}
