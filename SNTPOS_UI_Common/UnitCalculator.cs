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
using SNT_POS_Common.utility;

namespace SNTPOS_UI_Common
{
    public partial class UnitCalculator : Form
    {
        Stock stock;
        UnitController unitcontrol = new UnitController();
        UnitRSController unitRScontrol = new UnitRSController();
        decimal calculatedQuantity = 0,calculatedPrice=0;
        public UnitCalculator()
        {
            InitializeComponent();
           
        }
        public void setConnectionString(string conString)
        {
            OledbData.connString = conString;
        }
        public decimal getCalculatedQuantity()
        {
            return calculatedQuantity;
        }
        public decimal getCalculatedPrice()
        {
            return calculatedPrice;
        }
        public decimal getInsertedPrice()
        {
            return Price.Value;
        }
        public void addData(Stock stock)
        {
            this.stock = stock;
            TxtStockID.Text = stock.ID.ToString();
            StockName.Text = stock.Name;
            //TxtUnitID.Text = stock.unit.ID.ToString();
            //UnitName.Text = stock.unit.Name;
        }
        public void addData(int StockID)
        {
            StockController stockcontrol = new StockController();
           stock=stockcontrol.getById(StockID);

            
            TxtStockID.Text = stock.ID.ToString();
            StockName.Text = stock.Name;
            TxtUnitID.Text = stock.unit.ID.ToString();
            UnitName.Text = stock.unit.Name;
        }

        public decimal calculateChildValue(Unit desireUnit,Unit stockUnit,decimal originalValue,int stockID=-1)
        {
            if (stockID==-1)
            {
                UnitRS unitRS = unitRScontrol.getUnitRS((int)stock.ID,(int) stockUnit.ID,(int) desireUnit.ID);
                if (unitRS != null)
                {
                     calculatedQuantity = (unitRS.parentQuantity / unitRS.childQuantity) * quantity.Value;
                     calculatedPrice = Price.Value * (unitRS.parentQuantity / unitRS.childQuantity);
                    return calculatedQuantity;
                }
            }
            else
            {
                UnitRS unitRS = unitRScontrol.getUnitRS( (int)stockUnit.ID, (int)desireUnit.ID);
                if (unitRS != null)
                {
                     calculatedQuantity = (unitRS.parentQuantity / unitRS.childQuantity) * quantity.Value;
                     calculatedPrice = Price.Value * (unitRS.parentQuantity / unitRS.childQuantity);
                     return calculatedQuantity;
                }
            }
            return 0;
        }
        public decimal calculateParentValue( Unit desireUnit,Unit stockUnit,decimal originalValue,int StockID=0)
        {
            if (StockID != 0)
            {
                UnitRS unitRS = unitRScontrol.getUnitRS((int)stock.ID, (int)desireUnit.ID, (int)stockUnit.ID);
                if (unitRS != null)
                {
                     calculatedQuantity = (unitRS.childQuantity / unitRS.parentQuantity) * originalValue;
                     calculatedPrice = Price.Value / (unitRS.childQuantity / unitRS.parentQuantity);
                     return calculatedQuantity;
                }
            }
            else
            {
                UnitRS unitRS = unitRScontrol.getUnitRS( (int)desireUnit.ID, (int)stockUnit.ID);
                if (unitRS != null)
                {
                     calculatedQuantity = (unitRS.childQuantity / unitRS.parentQuantity) * originalValue;
                     calculatedPrice = Price.Value / (unitRS.childQuantity / unitRS.parentQuantity);
                    return calculatedQuantity;
                }
            }
            return 0;
        }


       

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (UnitCombo.SelectedValue.ToString() == UnitName.Text)
            {
                calculatedQuantity = quantity.Value;
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                
                Unit unit2 = unitcontrol.getByName(UnitCombo.SelectedValue.ToString());
                /*
                UnitRS unitRS = unitRScontrol.getUnitRS(stock.ID, stock.unit.ID, unit2.ID);
                if (unitRS != null)
                {
                    calculatedValue = (unitRS.parentQuantity / unitRS.childQuantity) * quantity.Value;
                   
                    MessageBox.Show("Calculated Value" + calculatedValue);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    
                    UnitRS unitRS2 = unitRScontrol.getUnitRS(stock.ID, unit2.ID, stock.unit.ID);
                    if (unitRS2 != null)
                    {
                        calculatedValue = (unitRS2.childQuantity / unitRS2.parentQuantity) * quantity.Value;
                        MessageBox.Show("Calculated Value" + calculatedValue);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("There is no Unit Relation in this Stock");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                 */
                if (calculateChildValue(unit2,stock.unit,quantity.Value,(int)stock.ID) != 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if (calculateParentValue( unit2,stock.unit, quantity.Value,(int)stock.ID) != 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
               
               else if (calculateChildValue( unit2,stock.unit, quantity.Value) != 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if (calculateParentValue( unit2,stock.unit, quantity.Value) != 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
               
                else
                {
                    MessageBox.Show("There is no Unit Relation in this Stock");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
           
            
        }
        private void addCombo()
        {
            try
            {
                DataTable dt = unitcontrol.getAll();
                //MessageBox.Show(dt.Rows.Count.ToString());
                UnitCombo.DataSource = dt;
              UnitCombo.DisplayMember = dt.Columns["UnitName"].ToString();
              UnitCombo.ValueMember = dt.Columns["UnitName"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UnitCalculator_Load(object sender, EventArgs e)
        {

            addCombo();
        }

        
    }
}
