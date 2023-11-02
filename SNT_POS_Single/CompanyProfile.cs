using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Controller;
using Common.Entity;
using SNT_POS_Single.Entity;

namespace SNT_POS_Single_Management
{
    public partial class CompanyProfile : Form
    {
        CompanyProfileController companyCtrl = new CompanyProfileController(); Contact company;
        public CompanyProfile()
        {
            InitializeComponent();

          
        }

      

        void getData()
        {
            company = companyCtrl.getCompanyProfile();
            
        }
        void setText()
        {
            txtName.Text = company.Name;
            if(company.Address!=null)
            txtAddress.Text = company.Address;
            if(company.Phone!=null)
            txtPhone.Text = company.Phone;
        }

        void setData()
        {
            company.Name = txtName.Text;
            company.Address = txtAddress.Text;
            company.Phone = txtPhone.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            setData();
            companyCtrl.update(company);
            MessageBox.Show("Updated");
        }

        private void Contactform_Load(object sender, EventArgs e)
        {
            getData();
            setText();
        }
    }
}
