using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNT_POS_Common.Entity
{
   public class UnitRS:CommonUnit
    {
       
        public Stock stock { get; set; }
        public Unit ParentUnit { get; set; }
        public Unit ChildUnit { get; set; }
        public decimal parentQuantity { get; set; }
        public decimal childQuantity { get; set; }
       
        
      
    }
}
