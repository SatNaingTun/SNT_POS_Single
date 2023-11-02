using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNT_POS_Common.Entity
{
   public class StockIn:CommonUnit
    {
       
        public Stock stock { get; set; }
        public decimal InBalance { get; set; }
        public DateTime StockInDateTime { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime expireDate { get; set; }
        public Contact vendor;
       

        public StockIn()
        {

        }
        public StockIn(Stock stock,decimal InBalance,DateTime StockInDateTime,decimal BuyPrice)
        {
            this.stock = stock;
            this.InBalance = InBalance;
            this.StockInDateTime = StockInDateTime;
            this.BuyPrice = BuyPrice;
        }

        


    }
}
