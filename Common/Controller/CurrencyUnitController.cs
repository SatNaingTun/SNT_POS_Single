using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using SNT_POS_Common.Entity;
using SNT_POS_Common.utility;
using SNT_POS_Common.Interface;

namespace SNT_POS_Common.Controller
{
   public class CurrencyUnitController:IGetCommon<Unit>
    {

        public Unit getById(int id)
        {
            string query = "select * from tbl_CurrencyUnits where ID=@id and isDeleted=false";
           
            return toUnit( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }

      

        public Unit getByName(string name)
        {
            string query = "select * from tbl_CurrencyUnits where CurrencyName=@CurrencyName and isDeleted=false";

            return toUnit( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@CurrencyName", name)));
        }

        
      
     


        public DataTable getAll()
        {

            string query = "select ID,CurrencyName from tbl_CurrencyUnits where isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);
           
        }


        public void save(Unit unit)
        {
            if (String.IsNullOrEmpty(unit.Name)) throw new ArgumentNullException();
            string query = "insert into tbl_CurrencyUnits ([CurrencyName]) values(?)";
            OledbData.ExecuteSave(query, CommandType.Text,null, new OleDbParameter("CurrencyName",unit.Name));
        }


        

        public void update(Unit unit)
        {
            if (String.IsNullOrEmpty(unit.Name)) throw new ArgumentNullException();
            string query = "update tbl_CurrencyUnits  set [CurrencyName]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("CurrencyName", unit.Name));
            parameters.Add(new OleDbParameter("UnitID", unit.ID));
            OledbData.ExecuteSave(query, CommandType.Text,null,parameters);
        }






        public void delete(int id)
        {
            string query = "update tbl_CurrencyUnits set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }


       private Unit toUnit( DataTable dt)
        {
            if (dt != null)
            {
                Unit unit = new Unit();
                unit.ID = dt.Rows[0].Field<int>("ID");
                unit.Name = dt.Rows[0].Field<string>("CurrencyName");


                return unit;
            }
            return null;
        }
    }
}
