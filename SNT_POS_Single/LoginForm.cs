using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.utility;
using System.Data.OleDb;
using SNT_POS_Common.Entity;
using SNT_POS_Common.Controller;
using SNTPOS_UI_Common;


namespace SNT_POS_Single_Management
{
    public partial class LoginForm : Form
    {
        UserController usercontrol = new UserController(); 
        SessionController sessioncontrol = new SessionController();
        Session session = new Session();
        //User user;
        

        public LoginForm()
        {
            InitializeComponent();
            OledbData.connString = Properties.Settings.Default.SNT_POS_DBConnectionString;
        }
        public Session getSession()
        {
            return session;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (usercontrol.isAuthorize(txtboxUser.Text, txtPwd.Text))
                {
                    session = new Session();
                    session.user = new User();
                    session.user.Name = txtboxUser.Text;
                    session.user = usercontrol.getUser(txtboxUser.Text, txtPwd.Text);


                    session.LoginDT = DateTime.Now;
                    session.LogoutDT = DateTime.MinValue;

                    // user = usercontrol.getById(LoginInfo.userId).toUser();
                    // this.Hide();
                    //  POS_Management mf = new POS_Management();
                    //  mf.Show();
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }
            catch (OleDbException olex)
            {
                Logger.errorLog(olex.Message);
                this.DialogResult = DialogResult.Cancel;
                using (SNTPOS_UI_Common.DataConnectFrom dcf = new SNTPOS_UI_Common.DataConnectFrom("SNT_POS_Single"))
                {
                    if (dcf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Access DB data location updated");
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void addSession()
        {
           
            sessioncontrol.save(session);
        }
    }
}
