using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.utility;
using System.IO;


namespace SNTPOS_UI_Common
{
    public partial class DataConnectFrom : Form
    {
        string uri; 
        /*
        public DataConnectFrom()
        {
            InitializeComponent();
        }
         */ 
        public DataConnectFrom(string appname)
        {
            InitializeComponent();
            this.uri = Environment.CurrentDirectory + "\\" + appname + ".exe.config";
           
        }
       

        private void BttnSave_Click(object sender, EventArgs e)
        {


            saveConn();

        }

        private void saveConn()
        {
           // MessageBox.Show("" + Directory.GetCurrentDirectory());
            SNT_POS_Common.utility.XmlData xmldata = new SNT_POS_Common.utility.XmlData(uri);
            //MessageBox.Show( xmldata.readConnectionString());

            if (System.IO.File.Exists(textBox1.Text))
            {
                /*
                AppSetting setting = new AppSetting();
                string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=True", textBox1.Text);
                setting.SaveConnectionString("Properties.Settings.Default.SNT_POS_DBConnectionString", connectionString);
                */
                xmldata.updateConnectionString(textBox1.Text);
                Application.Restart();
                Environment.Exit(0);
               

            }
            else
            {
                MessageBox.Show("Provided Access Database is not valid");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select SNT POS DB";
            ofd.Filter = "Access Database|*.accdb";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                //pictureBox1.Text = String.Format("{0}*{1} pixels", pictureBox1.Image.Width, pictureBox1.Image.Height);
            }

        }
    }
}
