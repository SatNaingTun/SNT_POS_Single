using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SNT_POS_Single_Management
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
            //Application.Run(new LoginForm());
           
            using (LoginForm login = new LoginForm())
            {
                
                //sf.MdiParent = this.MdiParent;
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   // login.addSession();
                    Application.Run(new  POS_Management(login.getSession()));
                }

            }
           
            //SNT_POS_Common.utility.XmlData xmldata = new SNT_POS_Common.utility.XmlData(Environment.CurrentDirectory +"\\"+ "SNT_POS_Single.exe.config");
            //xmldata.readConnectionString();
        }
    }
}
