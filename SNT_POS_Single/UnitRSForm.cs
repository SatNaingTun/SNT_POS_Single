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
using SNT_POS_Common.utility;

namespace SNT_POS_Single_Management
{
    public partial class UnitRSForm : Form
    {
        DataTable dtUnit,dtStock; UnitController uc = new UnitController(); UnitRSController urs = new UnitRSController();
        StockController stockcontrol = new StockController();
        UnitRS unitRS;
        public UnitRSForm()
        {
            InitializeComponent();
        }
        private void addComboData(DataTable dt)
        {
            this.dtUnit = dt;
            if (dt != null)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboParentUnit.Items.Add(dt.Rows[i].Field<string>("UnitName"));
                    comboChildUnit.Items.Add(dt.Rows[i].Field<string>("UnitName"));
                }
                if (comboParentUnit.Items.Count > 0)
                {
                    comboParentUnit.SelectedIndex = 0;
                }
                if (comboChildUnit.Items.Count > 1)
                {
                    comboChildUnit.SelectedIndex = 1;
                }
               
            }
            comboParentUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboParentUnit.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboChildUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboChildUnit.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void addStockData(DataTable dt, bool isFirstTime = false)
        {
            this.dtStock = dt;
            if (dt != null)
            {
                suggestGrid.DataSource = dt;
                if (isFirstTime == true)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                        comboSearch.Items.Add(dt.Columns[i].ColumnName);

                    if (comboSearch.Items.Count >= 2)
                        comboSearch.SelectedIndex = 1;
                    else
                        comboSearch.SelectedIndex = 0;
                }

            }
        }
        private void txtStockName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = dtStock.DefaultView;
                // dv.RowFilter = string.Format(dt.Columns[1].ColumnName+"LIKE '%{0}%'", txtSearch.Text);
                if (dtStock.Columns[comboSearch.SelectedItem.ToString()].DataType == Type.GetType("System.Int32"))
                {
                    if (txtStockName.Text == string.Empty)
                    {
                        dv.RowFilter = string.Empty;
                    }
                    else
                        dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " = {0}", txtStockName.Text);
                }
                else
                {
                    dv.RowFilter = string.Format(comboSearch.SelectedItem.ToString() + " LIKE '%{0}%'", txtStockName.Text);
                }

                suggestGrid.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SearchForm sf = new SearchForm())
            {
                sf.addData(urs.getAllwithUnitName());
                
                if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    unitRS = urs.getById(sf.getID());
                    setData(unitRS);
                    btnSave.Text = "Update";
                    btn_delete.Visible = true;
                }

            }

            
        }

        private void setData(UnitRS unitRS)
        {
           // RoleCombo.SelectedIndex = RoleCombo.FindString(user.role.RoleName);
            if (unitRS.stock != null)
            {
                unitRS.stock = stockcontrol.getById((int)unitRS.stock.ID);
                txtStockName.Text = unitRS.stock.Name;
            }
            else
            {
                ignoreStock.Checked = true;
            }
          
           unitRS.ParentUnit = uc.getById((int)unitRS.ParentUnit.ID);
           unitRS.ChildUnit = uc.getById((int)unitRS.ChildUnit.ID);
            comboParentUnit.SelectedIndex = comboParentUnit.FindString(unitRS.ParentUnit.Name);
            comboChildUnit.SelectedIndex = comboChildUnit.FindString(unitRS.ChildUnit.Name);
            parentQuantity.Value = unitRS.parentQuantity;
            childQuantity.Value = unitRS.childQuantity;
        }

        private void UnitRSForm_Load(object sender, EventArgs e)
        {
            addComboData(uc.getAll());
            addStockData(stockcontrol.getAll(), true);
            if (this.Text == "Unit Calculator")
            {
                saveGroupBox.Visible = false;
                btnSearch.Visible = false;
                this.childQuantity.ValueChanged += new System.EventHandler(this.childQuantity_ValueChanged);
                this.parentQuantity.ValueChanged += new System.EventHandler(this.parentQuantity_ValueChanged);
            }
        }
        private void loadStockdata()
        {
            if (btnSave.Text == "Save")
            {
                unitRS = new UnitRS();
            }

            if (ignoreStock.Checked == true)
            {
                unitRS.ParentUnit = uc.getByName(comboParentUnit.SelectedItem.ToString());
                unitRS.ChildUnit = uc.getByName(comboChildUnit.SelectedItem.ToString());
                unitRS.parentQuantity = parentQuantity.Value;
                unitRS.childQuantity = childQuantity.Value;
            }
            else if (suggestGrid.CurrentRow != null  )
            {
                // stockIn = new StockIn();
                try
                {
                    unitRS.stock = new Stock();
                    unitRS.stock.ID = (int)suggestGrid.CurrentRow.Cells["ID"].Value;
                    txtStockName.Text = unitRS.stock.Name = suggestGrid.CurrentRow.Cells["StockName"].Value.ToString();

                    unitRS.stock.Price = (decimal)suggestGrid.CurrentRow.Cells["Price"].Value;
                    unitRS.ParentUnit = uc.getByName(comboParentUnit.SelectedItem.ToString());
                    unitRS.ChildUnit = uc.getByName(comboChildUnit.SelectedItem.ToString());
                    unitRS.parentQuantity = parentQuantity.Value;
                    unitRS.childQuantity = childQuantity.Value;
                }
                catch (Exception ex)
                {
                    Logger.errorLog(ex.Message);
                    unitRS = null;
                }

            }
            else
            {
                unitRS = null;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loadStockdata();
            if (comboParentUnit.SelectedItem.ToString() == comboChildUnit.SelectedItem.ToString())
            {
                MessageBox.Show("Parent Unit and Child Unit should not equal");
            }
            else if(parentQuantity.Value>childQuantity.Value)
            {
                MessageBox.Show("Parent Quantity should be less than Child Qunatity");
             }
            else
            {
                if (btnSave.Text == "Update" && unitRS != null)
                {
                    if (ignoreStock.Checked == false)
                    {
                        urs.update(unitRS);
                    }
                    else
                    {
                       
                        urs.update(unitRS, true);
                    }
                    MessageBox.Show("unitRS updated");
                    btnSave.Text = "Save";
                    btn_delete.Visible = false;
                }
                else if (unitRS != null)
                {
                    if (ignoreStock.Checked == false)
                    {
                        UnitRS oldUnitRS = urs.getUnitRS(unitRS);
                        if (oldUnitRS == null)
                        {
                            urs.save(unitRS);
                            MessageBox.Show("New unitRS saved");
                        }
                        else
                        {
                           // MessageBox.Show("UnitRS ID="+oldUnitRS.ID.ToString()+" already exist!  You need to update");
                            oldUnitRS.parentQuantity = unitRS.parentQuantity;
                            oldUnitRS.childQuantity = unitRS.childQuantity;
                            urs.update(oldUnitRS);
                            MessageBox.Show("UnitRS updated");
                           
                        }
                    }
                    else
                    {
                        UnitRS oldUnitRS = urs.getUnitRS(unitRS,true);
                        if (oldUnitRS == null)
                        {
                            urs.save(unitRS, true);
                            MessageBox.Show("New unitRS saved");
                        }
                        else
                        {
                           // MessageBox.Show("UnitRS ID=" + oldUnitRS.ID.ToString() + " already exist!  You need to update");

                            oldUnitRS.parentQuantity = unitRS.parentQuantity;
                            oldUnitRS.childQuantity = unitRS.childQuantity;
                            urs.update(oldUnitRS,true);
                            MessageBox.Show("UnitRS updated");
                        }

                    }
                  
                }
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            addStockData(stockcontrol.getAll());
            txtStockName.Clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (unitRS != null)
                urs.delete((int)unitRS.ID);
            txtStockName.Clear();
            btn_delete.Visible = false;
            btnSave.Text = "Save";
            MessageBox.Show("UnitRS deleted");
        }

        

        private void suggestGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            loadStockdata();
        }

        private void childQuantity_ValueChanged(object sender, EventArgs e)
        {
            loadStockdata();
            if (unitRS != null)
            {
                UnitRS unitRS2Calculate = urs.getUnitRS(unitRS);

                if (unitRS2Calculate != null)
                    parentQuantity.Value = (unitRS2Calculate.parentQuantity / unitRS2Calculate.childQuantity) * childQuantity.Value;
                else
                    MessageBox.Show("No Unit Relation");
            }

        }

        private void parentQuantity_ValueChanged(object sender, EventArgs e)
        {
            loadStockdata();
            if (unitRS != null)
            {
                UnitRS unitRS2Calculate = urs.getUnitRS(unitRS);
                //MessageBox.Show("Parent Name:" + unitRS.ParentUnit.Name+"\n"+"Child Name:"+unitRS.ChildUnit.Name);

                if (unitRS2Calculate != null)
                    childQuantity.Value = (unitRS2Calculate.childQuantity / unitRS2Calculate.parentQuantity) * parentQuantity.Value;
                else
                    MessageBox.Show("No Unit Relation");
            }
             
        }
    }
}
