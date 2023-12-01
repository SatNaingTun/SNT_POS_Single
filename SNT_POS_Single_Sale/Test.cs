using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.Entity;

namespace SNT_POS_Single_Sale
{
    public partial class Test : Form
    {
        List<Vouncher_Item> vouncher = new List<Vouncher_Item>();
        
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vouncher;
           
            //dataGridView1.DataMember = "Vouncher_Item";

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vouncher_Item item = new Vouncher_Item();
            item.ID = vouncher.Count+1;
            item.quantity = vouncher.Count + 1;
            item.Amt = 1000 * item.quantity;
            item.NetAmt = 1000 * item.quantity;
            item.stock = new Stock();
            item.stock.ID+=1;
            item.stock.Name = "StockName" + item.stock.ID;
            vouncher.Add(item);
        }
    }
}
