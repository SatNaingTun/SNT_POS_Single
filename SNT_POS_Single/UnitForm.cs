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
    public partial class UnitForm : Form
    {
        Unit unit; UnitController unitControl = new UnitController();
        CurrencyUnitController currencyControl = new CurrencyUnitController();

        public UnitForm()
        {
            InitializeComponent();
        }
        private void UnitForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Text == "UnitForm")
            {
                if (btnSave.Text == "Update" && unit != null)
                {
                    unit.Name = txtUnitName.Text;
                    unitControl.update(unit);
                    MessageBox.Show("Unit updated");
                }
                else
                {
                    unitControl.save(new Unit(txtUnitName.Text));

                    MessageBox.Show("New Unit added");
                }
            }

            if (this.Text == "CurrencyUnitForm")
            {
                if (btnSave.Text == "Update" && unit != null)
                {
                    unit.Name = txtUnitName.Text;
                    currencyControl.update(unit);
                    MessageBox.Show("CurrencyUnit updated");
                }
                else
                {
                    currencyControl.save(new Unit(txtUnitName.Text));

                    MessageBox.Show("New CurrencyUnit added");
                }
            }
        }
        private void setData(Unit unit)
        {
            txtUnitName.Text = unit.Name;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SearchForm sf = new SearchForm())
            {
                if (this.Text == "UnitForm")
                {
                    sf.addData(unitControl.getAll());
                    //sf.MdiParent = this.MdiParent;
                    if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (sf.getID() != -1)
                        {
                            unit = unitControl.getById(sf.getID());
                            setData(unit);
                            btnSave.Text = "Update";
                        }
                    }
                }

                if (this.Text == "CurrencyUnitForm")
                {
                    sf.addData(currencyControl.getAll());
                    //sf.MdiParent = this.MdiParent;
                    if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (sf.getID() != -1)
                        {
                            unit = currencyControl.getById(sf.getID());
                            setData(unit);
                            btnSave.Text = "Update";
                        }
                    }
                }



            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.Text == "UnitForm")
            {
                if (unit != null)
                {
                    unitControl.delete((int)unit.ID);
                    MessageBox.Show("Unit Deleted");
                }
            }

            if (this.Text == "CurrencyUnitForm")
            {
                if (unit != null)
                {
                    currencyControl.delete((int)unit.ID);
                    MessageBox.Show("CurrencyUnit Deleted");
                }
            }
        }

        
    }
}
