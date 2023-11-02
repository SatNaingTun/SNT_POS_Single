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
    public partial class UserForm : Form
    {
        User user;
        UserController uc = new UserController();
        RoleController rc = new RoleController();

        public UserForm()
        {
            InitializeComponent();
           
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
           
            //addRoles();
             DataTable dt = rc.getAll();
             RoleCombo.DataSource = dt;
             RoleCombo.ValueMember = dt.Columns["RoleName"].ToString();
             RoleCombo.DisplayMember = dt.Columns["RoleName"].ToString();
            
           // MessageBox.Show(role.getAll().Rows[0].Field<string>("RoleName"));
        }

        private void addRoles()
        {
           
            //RoleCombo.DataSource = role.getAll();
            DataTable dt = rc.getAll();
            foreach (DataRow row in dt.Rows)
            {
                //RoleCombo.Items.Add(row.Field<string>("RoleName"));
                MessageBox.Show(row.Field<string>("RoleName"));
            }
        }
        private void setData(User user)
        {
            txtboxUser.Text = user.Name;
            txtPwd.Text = user.password;
            txtcfmPwd.Text = user.password;
            
            RoleCombo.SelectedIndex = RoleCombo.FindString(user.role.Name);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtboxUser.Text == string.Empty || txtPwd.Text == string.Empty || txtcfmPwd.Text == string.Empty)
               MessageBox.Show("Textfield cannot be empty");
            else if (txtPwd.Text != txtcfmPwd.Text)
            {
                MessageBox.Show("Password and confirm password must be the same");
                txtcfmPwd.Focus();
            }
            else if(btnSave.Text=="Update" && user!=null)
            {
                UserController uc = new UserController();
                RoleController rc = new RoleController();
                
                user.Name = txtboxUser.Text;
                user.password = txtPwd.Text;
                user.role = rc.getByName(RoleCombo.SelectedValue.ToString());
                uc.update(user);
                MessageBox.Show("User updated");
                btnSave.Text = "Save";
                btn_delete.Visible = false;
            }

            else
            {
                UserController uc = new UserController();
                RoleController rc = new RoleController();
                user = new User();
                user.Name = txtboxUser.Text;
                user.password = txtPwd.Text;
                user.role = rc.getByName(RoleCombo.SelectedValue.ToString());
                uc.save(user);
                MessageBox.Show("New User Added");
                // user.RoleID=
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            using (SearchForm sf = new SearchForm())
            {
                sf.addData(uc.getAll());
                //sf.MdiParent = this.MdiParent;
                if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    user = uc.getById(sf.getID());
                   user.role = rc.getById((int)user.role.ID);
                   setData(user);
                   btnSave.Text = "Update";
                   btn_delete.Visible = true;
                }

            }
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                uc.delete((int)user.ID);
                btn_delete.Visible = false;
            }
        }
    }
}
