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


namespace SNT_POS_Single_Management
{
    public partial class Contactform : Form
    {
        CompanyProfileController companyCtrl = new CompanyProfileController(); 
       
        Contact contact;
        CustomerController customerCtrl = new CustomerController();

        ContactController vendorCtrl = new ContactController("tbl_Vendor");
        public Contactform()
        {
            InitializeComponent();


        }



        void getCompanyData()
        {
            contact = companyCtrl.getCompanyProfile();

        }
        void setText()
        {
            txtName.Text = contact.Name;
            if (contact.Address != null)
                txtAddress.Text = contact.Address;
            if (contact.Phone != null)
                txtPhone.Text = contact.Phone;
        }

        void setData()
        {
            contact.Name = txtName.Text;
            contact.Address = txtAddress.Text;
            contact.Phone = txtPhone.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Text == "Company Profile")
            {
                setData();
                companyCtrl.update(contact);
                MessageBox.Show("Company Profile Updated");
            }
            if (this.Text == "Customer Profile")
            {
                if (btnSave.Text == "Save")
                {
                    if (customerCtrl.getByNameAndPhone(txtName.Text,txtPhone.Text) == null)
                    {
                        contact = new Contact();
                        setData();
                        customerCtrl.save(contact);
                        MessageBox.Show("New Customer Info Saved");
                    }
                    else
                    {
                         DialogResult result = MessageBox.Show("Customer Name has already existed !! \n Do you want to add this Customer Name?", "Customer Name existed", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                         if (result == DialogResult.Yes)
                         {
                             contact = new Contact();
                             setData();
                             customerCtrl.save(contact);
                             MessageBox.Show("New Customer Info Saved");
                         }

                    }
                }
                if (btnSave.Text == "Update")
                {
                    setData();
                    customerCtrl.update(contact);
                    btnSave.Text = "Save";
                    btn_delete.Visible = false;
                    MessageBox.Show(" Customer Info Updated");
                }

            }
            if (this.Text == "Vendor Profile")
            {
                if (btnSave.Text == "Save")
                {
                    if (vendorCtrl.getByName(txtName.Text) == null)
                    {
                        contact = new Contact();
                        setData();
                        vendorCtrl.save(contact);
                        MessageBox.Show("New Vendor Info Saved");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Vendor Name has already existed !! \n Do you want to add this Vendor Name?", "Vendor Name existed", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            contact = new Contact();
                            setData();
                            vendorCtrl.save(contact);
                            MessageBox.Show("New Vendor Info Saved");
                        }
                    }
                }
                if (btnSave.Text == "Update")
                {
                    setData();
                    vendorCtrl.update(contact);
                    btnSave.Text = "Save";
                    btn_delete.Visible = false;
                    MessageBox.Show(" Vendor Info Updated");
                }

            }
        }

        private void Contactform_Load(object sender, EventArgs e)
        {
            if (this.Text == "Company Profile")
            {
                getCompanyData();
                setText();
                btnSearch.Visible = false;
            }
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
                {
                  
                if (this.Text == "Customer Profile")
                  {
                
                     using (SearchForm sf = new SearchForm())
                    {
                        sf.addData(customerCtrl.getAll());
                        //sf.MdiParent = this.MdiParent;
                        if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            contact = customerCtrl.getById(sf.getID());

                            setText();
                            btnSave.Text = "Update";

                            btn_delete.Visible = true;
                        }

                    }
               
                     }

                if (this.Text == "Vendor Profile")
                {

                    using (SearchForm sf = new SearchForm())
                    {
                        sf.addData(vendorCtrl.getAll());
                        //sf.MdiParent = this.MdiParent;
                        if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            contact = vendorCtrl.getById(sf.getID());

                            setText();
                            btnSave.Text = "Update";

                            btn_delete.Visible = true;
                        }

                    }

                }

                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (contact != null)
            {
                if (this.Text == "Customer Profile")
                    customerCtrl.delete((int)contact.ID);

                btnSave.Text = "Save";
                btn_delete.Visible = false;
            }
        }
    }
}
