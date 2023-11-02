using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.Interface;
using SNT_POS_Common.utility;
using System.Data;
using System.Data.OleDb;
using SNT_POS_Common.Entity;

namespace SNT_POS_Common.Controller
{
   public class StockController:IGetCommon<Stock>
   {
       UnitController unitcontrol = new UnitController();
      
        public Stock getById(int id)
        {
            string query = "select * from tbl_Stock where ID=@id and isDeleted=false";

            return toStock( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }
      

        public System.Data.DataTable getAll()
        {
            string query = "select ID,StockName,GenericName,Price,Remark,UnitID from tbl_Stock where isDeleted=false";

            return OledbData.Execute(query, CommandType.Text);
        }
        public System.Data.DataTable getAllwithUnitName()
        {
            string query = "select tbl_Stock.ID,StockName,GenericName,tbl_Stock.StockImage,Price,UnitName,UnitID,Remark from tbl_Stock left join tbl_Units On tbl_Stock.UnitID=tbl_Units.ID  where tbl_Stock.isDeleted=false";

            return OledbData.Execute(query, CommandType.Text);
        }

        public System.Data.DataTable getDeletedStock()
        {
            string query = "select tbl_Stock.ID,StockName,GenericName,tbl_Stock.StockImage,Price,UnitName,UnitID,Remark from tbl_Stock left join tbl_Units On tbl_Stock.UnitID=tbl_Units.ID  where tbl_Stock.isDeleted=true";

            return OledbData.Execute(query, CommandType.Text);
        }


        public System.Data.DataTable getInStockItem()
        {
            string query = "select ID,StockName,GenericName,Price,Remark,UnitID from tbl_Stock where isDeleted=false";

            return OledbData.Execute(query, CommandType.Text);
        }


        public Stock getByName(string name)
        {
            string query = "select * from tbl_Stock where StockName = @StockName and isDeleted=false ";

            return toStock( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("StockName", name)));
        }
       

        public void save(Stock stock)
        {
            if (String.IsNullOrEmpty(stock.Name)) throw new ArgumentNullException();

            if (stock.StockImage==null)
            {
                string query = "insert into tbl_Stock ([StockName],[GenericName],[Price],[Remark],[UnitID]) values(?,?,?,?,?)";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("StockName", stock.Name));
                parameters.Add(new OleDbParameter("GenericName", stock.GenericName));
                parameters.Add(new OleDbParameter("Price", stock.Price));
                parameters.Add(new OleDbParameter("Remark", stock.Remark));
                parameters.Add(new OleDbParameter("UnitID", stock.unit.ID));
                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
            }
            else
            {
                string query = "insert into tbl_Stock ([StockName],[GenericName],[Price],[Remark],[UnitID],[StockImage]) values(?,?,?,?,?,?)";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("StockName", stock.Name));
                parameters.Add(new OleDbParameter("GenericName", stock.GenericName));
                parameters.Add(new OleDbParameter("Price", stock.Price));
                parameters.Add(new OleDbParameter("Remark", stock.Remark));
                parameters.Add(new OleDbParameter("UnitID", stock.unit.ID));
                parameters.Add(new OleDbParameter("StockImage", stock.StockImage));
                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
            }
        }

        public void update(Stock stock)
        {
            if (String.IsNullOrEmpty(stock.Name)) throw new ArgumentNullException();
            if (stock.StockImage == null)
            {
                string query = "update tbl_Stock  set [StockName]=?,[GenericName]=?,[Price]=?,[Remark]=?,[UnitID]=?,[StockImage]=null where [ID]=?";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("StockName", stock.Name));
                parameters.Add(new OleDbParameter("GenericName", stock.GenericName));
                parameters.Add(new OleDbParameter("Price", stock.Price));
                parameters.Add(new OleDbParameter("Remark", stock.Remark));
                parameters.Add(new OleDbParameter("UnitID", stock.unit.ID));
              
                parameters.Add(new OleDbParameter("ID", stock.ID));
                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
            }
            else
            {
                string query = "update tbl_Stock  set [StockName]=?,[GenericName]=?,[Price]=?,[Remark]=?,[UnitID]=?,[StockImage]=? where [ID]=?";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("StockName", stock.Name));
                parameters.Add(new OleDbParameter("GenericName", stock.GenericName));
                parameters.Add(new OleDbParameter("Price", stock.Price));
                parameters.Add(new OleDbParameter("Remark", stock.Remark));
                parameters.Add(new OleDbParameter("UnitID", stock.unit.ID));
                parameters.Add(new OleDbParameter("StockImage", stock.StockImage));
                parameters.Add(new OleDbParameter("ID", stock.ID));
                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
            }
        }

        public void updatePrice(Stock stock)
        {
            string query = "update tbl_Stock  set [Price]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Price", stock.Price));
            parameters.Add(new OleDbParameter("ID", stock.ID));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }



        public void delete(int id)
        {
            string query = "update tbl_Stock set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        public void reactivate(int id)
        {
            string query = "update tbl_Stock set [isDeleted]=false where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        public decimal getStockPrice(int id)
        {
            string query = "select Price from tbl_Stock where isDeleted=false and  [ID]=?";
      
            return (decimal)OledbData.ExecuteScalar(query, CommandType.Text,null,new OleDbParameter("ID", id));
        }

    

        private Stock toStock( DataTable dt)
        {
            if (dt != null && dt.Rows.Count>0)
            {
                Stock stock = new Stock();
                stock.ID = dt.Rows[0].Field<int>("ID");
                stock.Name = dt.Rows[0].Field<string>("StockName");
                stock.GenericName = dt.Rows[0].Field<string>("GenericName");
                stock.Price = dt.Rows[0].Field<decimal>("Price");
                stock.Remark = dt.Rows[0].Field<string>("Remark");
                //stock.unit = new Unit();
               // stock.unit.ID = dt.Rows[0].Field<int>("UnitID");
                stock.unit = unitcontrol.getById(dt.Rows[0].Field<int>("UnitID"));
               
                    if(dt.Rows[0].Field<byte[]>("StockImage")!=null)
                    stock.StockImage = dt.Rows[0].Field<byte[]>("StockImage");
               
                return stock;
            }
            return null;
        }
   }
}
