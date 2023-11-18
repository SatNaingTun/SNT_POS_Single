using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SNT_POS_Single_Management;

namespace SNT_POS_Single_Sale
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new SaleForm());
            //try
            //{
            //    using (SNTPOS_UI_Common.LoginForm login=new SNTPOS_UI_Common.LoginForm(Properties.Settings.Default.SNT_POS_DBConnectionString))
            //    {

            //        //sf.MdiParent = this.MdiParent;
            //        if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            login.addSession();
            //            Application.Run(new SaleForm(login.getSession()));
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            Application.Run(new Test());
        }
    }
}
