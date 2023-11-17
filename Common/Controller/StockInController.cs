using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.utility;
using System.Data;
using SNT_POS_Common.Interface;
using System.Data.OleDb;
using SNT_POS_Common.Entity;

namespace SNT_POS_Common.Controller
{
   public class StockInController : IGetCommon<StockIn>
   {
       StockController stockControl = new StockController();

        public StockIn getById(int id)
        {
            string query = "select * from tbl_StockIn where ID=@id and isDeleted=false";

            return toStockIn( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }


        public DataTable getAll()
        {
            string query = "SELECT tbl_StockIn.ID,tbl_Stock.StockName, tbl_StockIn.StockID, tbl_StockIn.InBalance, tbl_StockIn.BuyPrice, tbl_StockIn.StockInDateTime,tbl_StockIn.TotalBuyAmount,tbl_StockIn.ExpireDate,tbl_StockIN.VendorID FROM tbl_Stock INNER JOIN tbl_StockIn ON tbl_Stock.ID = tbl_StockIn.StockID where tbl_StockIn.isDeleted=false ";

            return OledbData.Execute(query, CommandType.Text);
        }


        public DataTable getDeletedStockIn()
        {
            string query = "SELECT tbl_StockIn.ID,tbl_Stock.StockName, tbl_StockIn.StockID, tbl_StockIn.InBalance, tbl_StockIn.BuyPrice, tbl_StockIn.StockInDateTime,tbl_StockIn.TotalBuyAmount,tbl_StockIn.ExpireDate,tbl_StockIN.VendorID FROM tbl_Stock INNER JOIN tbl_StockIn ON tbl_Stock.ID = tbl_StockIn.StockID where tbl_StockIn.isDeleted=true ";

            return OledbData.Execute(query, CommandType.Text);
        }


        public DataTable getLatestStockBalance()
        {

            string query = "SELECT * FROM (SELECT tbl_StockIn.*, a.StockBalance, (Select sum(InBalance) from tbl_StockIN as tt where tt.ID<=tbl_StockIn.ID and tt.StockID=tbl_StockIn.StockID) AS RunningSum FROM tbl_StockIn LEFT JOIN (SELECT (sum(tbl_StockIn.InBalance)- sum(tbl_Sale.Quantity)) AS StockBalance, tbl_StockIn.StockID FROM tbl_StockIN LEFT JOIN tbl_Sale ON tbl_StockIn.StockID=tbl_Sale.StockID GROUP BY tbl_StockIn.StockID)  AS a ON tbl_StockIn.StockID=a.StockID ORDER BY tbl_StockIn.ID DESC , tbl_StockIn.StockID)  AS b LEFT JOIN tbl_Stock ON b.StockID=tbl_Stock.ID WHERE StockBalance>0 and( StockBalance-RunningSum)>0";
            return OledbData.Execute(query, CommandType.Text);
        }




        /*
       public void save(StockIn stockIn)
       {
           string query = "insert into tbl_StockIn ([StockID],[InBalance],[StockInDateTime],[BuyPrice],[TotalBuyAmount]) values(?,?,?,?,?)";
           List<OleDbParameter> parameters = new List<OleDbParameter>();
           parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
           parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
           parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
           parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
           parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance * stockIn.BuyPrice));
            
           OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
       }
      
        public void save(StockIn stockIn,DateTime expireDate)
        {
            string query = "insert into tbl_StockIn ([StockID],[InBalance],[StockInDateTime],[BuyPrice],[TotalBuyAmount],[ExpireDate]) values(?,?,?,?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
            parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
            parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
            parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance*stockIn.BuyPrice));
            parameters.Add(new OleDbParameter("ExpireDate", expireDate));

            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        */ 

        public void save(StockIn stockIn)
        {
            //string query = "insert into tbl_StockIn ([StockID],[InBalance],[StockInDateTime],[BuyPrice],[TotalBuyAmount],[ExpireDate],[VendorID]) values(?,?,?,?,?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
            parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
            parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
            parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance * stockIn.BuyPrice));

            

            if(stockIn.expireDate!=DateTime.MinValue)
            parameters.Add(new OleDbParameter("ExpireDate", stockIn.expireDate));
            if (stockIn.vendor != null)
            {
                if(stockIn.vendor.ID!=null)
                parameters.Add(new OleDbParameter("VendorID", stockIn.vendor.ID));
            }
           
           string query = "insert into tbl_StockIn "+parameters.toInsertCmd();
           


            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
           
        }
        /*
        public void update(StockIn stockIn)
        {
            string query = "update tbl_StockIn  set [StockID]=?,[InBalance]=?,[StockInDateTime]=?,[BuyPrice]=?,[TotalBuyAmount]=?,[ExpireDate]=null,[VendorID]=null where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
            parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
            parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
            parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
            parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance * stockIn.BuyPrice));
            parameters.Add(new OleDbParameter("ID", stockIn.ID));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
       
         public void update(StockIn stockIn, DateTime expireDate)
         {
             string query = "update tbl_StockIn  set [StockID]=?,[InBalance]=?,[StockInDateTime]=?,[BuyPrice]=?,[TotalBuyAmount]=?, [ExpireDate]=? where [ID]=?";
             List<OleDbParameter> parameters = new List<OleDbParameter>();
             parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
             parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
             parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
             parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
             parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance * stockIn.BuyPrice));
             parameters.Add(new OleDbParameter("ExpireDate", expireDate));
             parameters.Add(new OleDbParameter("ID", stockIn.ID));
             OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
         }
         */
        
          public void update(StockIn stockIn)
          {
             // string query = "update tbl_StockIn  set [StockID]=?,[InBalance]=?,[StockInDateTime]=?,[BuyPrice]=?,[TotalBuyAmount]=?, [ExpireDate]=?,[VendorID]=? where [ID]=?";
              string[] NullCol = { "", "" };
              List<OleDbParameter> parameters = new List<OleDbParameter>();
              parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
              parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
              parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
              parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
              parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance * stockIn.BuyPrice));
              if (stockIn.expireDate != DateTime.MinValue)
              {
                  parameters.Add(new OleDbParameter("ExpireDate", stockIn.expireDate));
              }
              else
              {
                  NullCol[0] = "ExpireDate";
              }
              
            
                  if (stockIn.vendor != null)
                  {
                      if(stockIn.vendor.ID!=null)
                      parameters.Add(new OleDbParameter("VendorID", stockIn.vendor.ID));
                      else
                          NullCol[1] = "VendorID";
                  }
                 else
                      NullCol[1] = "VendorID";  
                  
              string query = "update tbl_StockIn set " + parameters.toUpdateCmd(NullCol) + " where [ID]=?";
              parameters.Add(new OleDbParameter("ID", stockIn.ID));
              OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
              
          }
          /*
            public void update(StockIn stockIn,DateTime? expireDate,int? VendorID)
            {
                // string query = "update tbl_StockIn  set [StockID]=?,[InBalance]=?,[StockInDateTime]=?,[BuyPrice]=?,[TotalBuyAmount]=?, [ExpireDate]=?,[VendorID]=? where [ID]=?";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("StockID", stockIn.stock.ID));
                parameters.Add(new OleDbParameter("InBalance", stockIn.InBalance));
                parameters.Add(new OleDbParameter("StockInDateTime", stockIn.StockInDateTime.ToString("yyyy-MM-dd hh:mm:ss")));
                parameters.Add(new OleDbParameter("BuyPrice", stockIn.BuyPrice));
                parameters.Add(new OleDbParameter("TotalBuyAmount", stockIn.InBalance * stockIn.BuyPrice));
                if (stockIn.expireDate != DateTime.MinValue)
                {
                    parameters.Add(new OleDbParameter("ExpireDate", stockIn.expireDate));
                }
                else
                {
                    parameters.Add(new OleDbParameter("ExpireDate", null));
                }

            
                    if (stockIn.vendor.ID != null)
                        parameters.Add(new OleDbParameter("VendorID", VendorID));
                    else
                        parameters.Add(new OleDbParameter("VendorID", null));
            
                string query = "update tbl_StockIn set " + parameters.toUpdateCmd() + " where [ID]=?";
                parameters.Add(new OleDbParameter("ID", stockIn.ID));
                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
            }
            */




         public DataTable getByName(string name)
        {
            throw new NotImplementedException();
        }


        public void delete(int id)
        {
            string query = "update tbl_StockIn  set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);

        }

        public void reactivate(int id)
        {
            string query = "update tbl_StockIn  set [isDeleted]=false where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);

        }

       private StockIn toStockIn( DataTable dt)
        {
            if (dt != null)
            {
                StockIn stockIn = new StockIn();
                stockIn.ID = dt.Rows[0].Field<int>("ID");
                //stockIn.stock = new Stock();
                //stockIn.stock.ID = dt.Rows[0].Field<int>("StockID");
                //stockIn.stock.Balance = dt.Rows[0].Field<decimal>("StockBalance");
                stockIn.stock = stockControl.getById(dt.Rows[0].Field<int>("StockID"));

                stockIn.InBalance = dt.Rows[0].Field<decimal>("InBalance");
                stockIn.StockInDateTime = dt.Rows[0].Field<DateTime>("StockInDateTime");
                stockIn.BuyPrice = dt.Rows[0].Field<decimal>("BuyPrice");
               
                
               
                try
                {
                    stockIn.expireDate = dt.Rows[0].Field<DateTime>("ExpireDate");
                }
                catch (Exception ex)
                {
                    stockIn.expireDate = DateTime.MinValue;
                }

                try
                {
                    
                    if (!DBNull.Value.Equals(dt.Rows[0].Field<int>("VendorID")))
                    {
                        stockIn.vendor = new Contact();
                        stockIn.vendor.ID = dt.Rows[0].Field<int>("VendorID");
                    }
                }
                catch (Exception ex)
                { }
                    
               

               

                return stockIn;
            }
            return null;
        }
     
    }
}