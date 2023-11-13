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
   public class SaleController
   {

       StockController stockControl = new StockController();
       SaleTypeController saleTypeControl = new SaleTypeController();
       CustomerController customerControl = new CustomerController();

        public System.Data.DataTable getById(int id)
        {
            string query = "SELECT tbl_Sale.ID,tbl_Sale.StockID, tbl_Sale.SaleTypeID, tbl_Sale.Price, tbl_Sale.Quantity as Quantity, tbl_Sale.Amount, tbl_Sale.Discount, tbl_Sale.UserID, tbl_Sale.NetAmount, tbl_Sale.SessionID, tbl_Sale.SaleDateTime, tbl_Sale.VouncherID, tbl_SaleType.SaleTypeName, tbl_Stock.StockName, Users.UserName,tbl_Customer.Name as CustomerName,tbl_Customer.Phone as CustomerPhone FROM ((((tbl_Sale INNER JOIN tbl_SaleType ON tbl_Sale.SaleTypeID = tbl_SaleType.ID) INNER JOIN tbl_Stock ON tbl_Sale.StockID = tbl_Stock.ID) INNER JOIN Users ON tbl_Sale.UserID = Users.ID) left join tbl_Customer on tbl_Sale.CustomerID=tbl_Customer.ID) where tbl_Sale.ID=@id and tbl_Sale.isDeleted=false";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id));
        }

        public Vouncher_Item getItemById(int id)
        {
          return  toVouncherItem(getById(id));
        }

       
        public System.Data.DataTable getBySessionId(int id)
        {
            string query = "SELECT tbl_Sale.ID,tbl_Sale.StockID,tbl_Stock.StockName, tbl_Sale.SaleTypeID, tbl_Sale.Price, tbl_Sale.Quantity as Quantity, tbl_Sale.Amount, tbl_Sale.Discount, tbl_Sale.UserID, tbl_Sale.NetAmount, tbl_Sale.SessionID, tbl_Sale.SaleDateTime, tbl_Sale.VouncherID, tbl_SaleType.SaleTypeName,  Users.UserName,tbl_Sale.CustomerID, tbl_Customer.Name as CustomerName,tbl_Customer.Phone as CustomerPhone FROM ((((tbl_Sale INNER JOIN tbl_SaleType ON tbl_Sale.SaleTypeID = tbl_SaleType.ID) INNER JOIN tbl_Stock ON tbl_Sale.StockID = tbl_Stock.ID) INNER JOIN Users ON tbl_Sale.UserID = Users.ID) left join tbl_Customer on tbl_Sale.CustomerID=tbl_Customer.ID) where tbl_Sale.SessionID=@id and tbl_Sale.isDeleted=false";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id));
        }

        public System.Data.DataTable getByName(string name)
        {
            string query = "select * from tbl_Sale where VouncherID = @VouncherID and isDeleted=false ";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@VouncherID", name));
        }
      
        public System.Data.DataTable getByVouncherID(string name)
        {
           
            string query = "SELECT tbl_Sale.ID, tbl_Sale.StockID, tbl_Sale.SaleTypeID, tbl_Sale.Price, tbl_Sale.Quantity, tbl_Sale.Amount, tbl_Sale.Discount, tbl_Sale.UserID, tbl_Sale.NetAmount, tbl_Sale.SessionID, tbl_Sale.SaleDateTime, tbl_Sale.VouncherID, tbl_SaleType.SaleTypeName, tbl_Stock.StockName, Users.UserName, tbl_Customer.Name AS CustomerName,tbl_Customer.Phone as CustomerPhone FROM (((tbl_Sale INNER JOIN tbl_SaleType ON tbl_Sale.SaleTypeID = tbl_SaleType.ID) INNER JOIN tbl_Stock ON tbl_Sale.StockID = tbl_Stock.ID) INNER JOIN Users ON tbl_Sale.UserID = Users.ID) LEFT JOIN tbl_Customer ON tbl_Sale.CustomerID=tbl_Customer.ID WHERE VouncherID=?;";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@VouncherID", name));
        }

       

        public System.Data.DataTable getAll()
        {
            string query = "SELECT        tbl_Sale.StockID, tbl_Sale.SaleTypeID, tbl_Sale.Price, tbl_Sale.Quantity, tbl_Sale.Amount, tbl_Sale.Discount, tbl_Sale.UserID, tbl_Sale.NetAmount, tbl_Sale.SessionID, tbl_Sale.SaleDateTime, tbl_Sale.VouncherID, tbl_SaleType.SaleTypeName, tbl_Stock.StockName, tbl_Stock.Price AS Expr1, Users.UserName FROM (((tbl_Sale INNER JOIN tbl_SaleType ON tbl_Sale.SaleTypeID = tbl_SaleType.ID) INNER JOIN tbl_Stock ON tbl_Sale.StockID = tbl_Stock.ID) INNER JOIN Users ON tbl_Sale.UserID = Users.ID) where tbl_Sale.isDeleted=false";

            return OledbData.Execute(query, CommandType.Text);
        }

        public System.Data.DataTable getDeletedSale()
        {
            string query = "SELECT        tbl_Sale.StockID, tbl_Sale.SaleTypeID, tbl_Sale.Price, tbl_Sale.Quantity, tbl_Sale.Amount, tbl_Sale.Discount, tbl_Sale.UserID, tbl_Sale.NetAmount, tbl_Sale.SessionID, tbl_Sale.SaleDateTime, tbl_Sale.VouncherID, tbl_SaleType.SaleTypeName, tbl_Stock.StockName, tbl_Stock.Price AS Expr1, Users.UserName FROM (((tbl_Sale INNER JOIN tbl_SaleType ON tbl_Sale.SaleTypeID = tbl_SaleType.ID) INNER JOIN tbl_Stock ON tbl_Sale.StockID = tbl_Stock.ID) INNER JOIN Users ON tbl_Sale.UserID = Users.ID) where tbl_Sale.isDeleted=true";

            return OledbData.Execute(query, CommandType.Text);
        }

        public void save(Vouncher_Item item,Session session)
        {
            

            string query = "insert into tbl_Sale ([StockID],[Price],[Quantity],[Amount],[Discount],[NetAmount],[VouncherID],[SaleTypeID],[SessionID],[UserID],[SaleDateTime]) values(?,?,?,?,?,?,?,?,?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("StockID", item.stock.ID));
            parameters.Add(new OleDbParameter("Price", item.stock.Price));
            parameters.Add(new OleDbParameter("Quantity", item.quantity));
            parameters.Add(new OleDbParameter("Amount", item.Amt));
            parameters.Add(new OleDbParameter("Discount", item.discount));
            parameters.Add(new OleDbParameter("NetAmt", item.NetAmt));
            parameters.Add(new OleDbParameter("VouncherID", item.VouncherID));
            parameters.Add(new OleDbParameter("SaleTypeID", item.saletype.ID));

            parameters.Add(new OleDbParameter("SessionID", session.ID));
            parameters.Add(new OleDbParameter("UserID", session.user.ID ));
            parameters.Add(new OleDbParameter("SaleDateTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
            
           
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        public void save(Vouncher_Item item, Session session,int CustomerID)
        {


            string query = "insert into tbl_Sale ([StockID],[Price],[Quantity],[Amount],[Discount],[NetAmount],[VouncherID],[SaleTypeID],[SessionID],[UserID],[CustomerID],[SaleDateTime]) values(?,?,?,?,?,?,?,?,?,?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("StockID", item.stock.ID));
            parameters.Add(new OleDbParameter("Price", item.stock.Price));
            parameters.Add(new OleDbParameter("Quantity", item.quantity));
            parameters.Add(new OleDbParameter("Amount", item.Amt));
            parameters.Add(new OleDbParameter("Discount", item.discount));
            parameters.Add(new OleDbParameter("NetAmt", item.NetAmt));
            parameters.Add(new OleDbParameter("VouncherID", item.VouncherID));
            parameters.Add(new OleDbParameter("SaleTypeID", item.saletype.ID));

            parameters.Add(new OleDbParameter("SessionID", session.ID));
            parameters.Add(new OleDbParameter("UserID", session.user.ID));
            parameters.Add(new OleDbParameter("CustomerID", CustomerID));
            parameters.Add(new OleDbParameter("SaleDateTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));


            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        public void update(Vouncher_Item item)
        {
            string query = "update tbl_Sale set [StockID]=?,[Price]=?,[Quantity]=?,[Amount]=?,[Discount]=?,[NetAmount]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("StockID", item.stock.ID));
            parameters.Add(new OleDbParameter("Price", item.stock.Price));
            parameters.Add(new OleDbParameter("Quantity", item.quantity));
            parameters.Add(new OleDbParameter("Amount", item.Amt));
            parameters.Add(new OleDbParameter("Discount", item.discount));
            parameters.Add(new OleDbParameter("NetAmount", item.NetAmt));
            //parameters.Add(new OleDbParameter("VouncherID", item.VouncherID));
           // parameters.Add(new OleDbParameter("SaleTypeID", item.saletype.ID));
            parameters.Add(new OleDbParameter("ID", item.ID));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
      
        public void updateSaleType(Vouncher_Item item)
        {
            string query = "update tbl_Sale set [SaleTypeID]=?,[CustomerID]=null where [VouncherID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("SaleTypeID", item.saletype.ID));
            parameters.Add(new OleDbParameter("VouncherID", item.VouncherID));
           

             OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        public void updateSaleType(Vouncher_Item item,int CustomerID)
        {
            string query = "update tbl_Sale set [SaleTypeID]=?,[CustomerID]=? where [VouncherID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("SaleTypeID", item.saletype.ID));
            parameters.Add(new OleDbParameter("CustomerID", CustomerID));
            parameters.Add(new OleDbParameter("VouncherID", item.VouncherID));


            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }




        public void delete(int id)
        {
            string query = "update tbl_Sale  set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        public void reactivate(int id)
        {
            string query = "update tbl_Sale  set [isDeleted]=false where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        private Vouncher_Item toVouncherItem(DataTable dt)
        {
            if (dt != null)
            {
                Vouncher_Item item = new Vouncher_Item();
                 item.ID=dt.Rows[0].Field<int>("ID");

                 item.VouncherID = dt.Rows[0].Field<int>("VouncherID").ToString();

                 item.stock = stockControl.getById(dt.Rows[0].Field<int>("StockID"));

                 item.quantity = dt.Rows[0].Field<decimal>("Quantity");
                 item.discount = dt.Rows[0].Field<decimal>("Discount");
                  item.saletype = saleTypeControl.getById(dt.Rows[0].Field<int>("SaleTypeID"));
                  item.Amt = dt.Rows[0].Field<decimal>("Amount");
                  item.NetAmt = dt.Rows[0].Field<decimal>("NetAmount");

                  item.customer = customerControl.getById(dt.Rows[0].Field<int>("CustomerID"));

                  return item;


            }


            return null;
        }

        
    }
}
