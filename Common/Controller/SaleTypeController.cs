using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.Controller;
using System.Data;
using System.Data.OleDb;
using SNT_POS_Common.utility;
using SNT_POS_Common.Interface;
using SNT_POS_Common.Entity;

namespace SNT_POS_Common.Controller
{
   public class SaleTypeController:IGetCommon<SaleType>
    {

        public SaleType getById(int id)
        {
            string query = "select * from tbl_SaleType where ID=? and isDeleted=false";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            return toSaleType(OledbData.Execute(query, CommandType.Text,  parameters));
        }

        public SaleType getByName(string name)
        {
            string query = "select * from tbl_SaleType where SaleTypeName =? and isDeleted=false ";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("SaleTypeName", name));
            return toSaleType( OledbData.Execute(query, CommandType.Text, parameters));
        }

        public System.Data.DataTable getAll()
        {
            string query = "select * from tbl_SaleType where  isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);
        }
       
       



        public void delete(int id)
        {  
            
            string query = "update tbl_SaleType  set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        private SaleType toSaleType(DataTable dt)
        {
            SaleType saletype = new SaleType();
            saletype.ID = dt.Rows[0].Field<int>("ID");
            saletype.Name = dt.Rows[0].Field<string>("SaleTypeName");


            return saletype;
        }


        public void save(SaleType t)
        {
            throw new NotImplementedException();
        }

        public void update(SaleType t)
        {
            throw new NotImplementedException();
        }
    }
}
