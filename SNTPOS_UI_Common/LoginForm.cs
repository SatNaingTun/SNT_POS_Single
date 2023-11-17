﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.ReportingServices.Common;
using SNT_POS_Common.Entity;
using SNT_POS_Common.Controller;
using SNT_POS_Common.utility;
using System.Data.OleDb;

namespace SNTPOS_UI_Common
{
    public partial class LoginForm : Form
    {
        UserController usercontrol = new UserController(); 
        SessionController sessioncontrol = new SessionController();
        FormMenuController formMenu = new FormMenuController();
        FormMenuControl_Controller formmenucontrol = new FormMenuControl_Controller();
        Session session;

        public EventHandler LoginSuccess=delegate {};
        public EventHandler LoginFail = delegate { };
        public LoginForm(string conn)
        {
            InitializeComponent();
       OledbData.connString=  conn;
        }

       
        public Session getSession() {
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
                     
                     session.user= usercontrol.getUser(txtboxUser.Text, txtPwd.Text);
                    session.LoginDT = DateTime.Now;
                    session.LogoutDT = new DateTime(1900, 01, 01);

                  int MenuID=  formMenu.getIDByName("SaleForm");
                    if (formmenucontrol.isAuthorize((int)session.user.role.ID, MenuID))
                    {
                        LoginSuccess.Invoke(this,e);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        LoginFail.Invoke(this, e);
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("You are not allowed access");
                    }

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
                using (SNTPOS_UI_Common.DataConnectFrom dcf = new SNTPOS_UI_Common.DataConnectFrom("SNT_POS_Single_Sale"))
                {
                    if (dcf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Access DB data location updated");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public int? addSession()
        {
         return session.ID=  sessioncontrol.save(session);
        }
    }
    
}
