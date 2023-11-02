using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SNT_POS_Common.Entity
{
  public  class Vouncher_Item
    {
        public int ID { get; set; }
      public Stock stock;
      public SaleType saletype { get; set; }
      public  decimal  Amt, quantity, discount, NetAmt;
      public string VouncherID;
      

      public Vouncher_Item()
      {
            
      }

    
      //public  object[] toArray( )
      //{
         
      //    List<object> list = new List<object>();
      //    list.Add(stock.ID);
      //    list.Add(stock.Name);
      //    list.Add(stock.Price);
      //    list.Add(quantity);
      //    list.Add(Amt);
      //    list.Add(discount);
      //    list.Add(NetAmt);
      //    list.Add(VouncherID);
          
      //    list.Add(stock.unit.ID);
      //    list.Add(stock.unit.Name);
          
      //    return list.ToArray();

      //}

      public virtual object[] toArray()
      {
          var bindingFlags = BindingFlags.Public
          |BindingFlags.Instance 
         // |BindingFlags.NonPublic 
                 ;
          var fieldValues = this.GetType()
                               .GetFields(bindingFlags)
                               .Select(field => field.GetValue(this))
                               .ToArray();
          return fieldValues;
      }
    
     
    
    }
}
