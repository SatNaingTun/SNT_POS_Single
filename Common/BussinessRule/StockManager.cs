using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.Entity;
using System.Data.OleDb;
using SNT_POS_Common.utility;
using System.Data;

namespace SNT_POS_Single.BussinessRule
{
  public  class StockManager
    {
      public void Receive(Stock stock,decimal receiveQuantity)
      {
          stock.Balance += receiveQuantity;
          updateBalance(stock);

      }
      public void Dispatch(Stock stock,decimal dispatchQuantity)
      {
          stock.Balance -= dispatchQuantity;
          updateBalance(stock);
      }
      private void updateBalance(Stock stock)
      {
          string query = "update tbl_Stock  set [StockBalance]=? where [ID]=?";
          List<OleDbParameter> parameters = new List<OleDbParameter>();
          parameters.Add(new OleDbParameter("StockBalance", stock.Balance));
          parameters.Add(new OleDbParameter("ID", stock.ID));
          OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
      }




    }
}
