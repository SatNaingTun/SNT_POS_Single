using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNT_POS_Common.Entity
{
   public class Stock:CommonUnit
    {
        
        public string GenericName { get; set; }
        public decimal Price;
        public string Remark;
        public Unit unit;
        public byte[] StockImage=null;

        public Stock()
        {

        }

        public Stock(string name,string genricname,decimal Price,string Remark,Unit unit)
        {
            this.Name = name;
            this.GenericName = genricname;
            this.Price = Price;
            this.Remark = Remark;
            this.unit = unit;
        }
        public Stock(string name, string genricname, decimal Price, string Remark, Unit unit, byte[] StockImage)
        {
            this.Name = name;
            this.GenericName = genricname;
            this.Price = Price;
            this.Remark = Remark;
            this.unit = unit;
            this.StockImage = StockImage;
        }

    }
}
