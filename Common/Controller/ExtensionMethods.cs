using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entity;
using System.Data;


namespace Common.Controller
{
  public static class ExtensionMethods
    {  

      /*
       public static object[] toArray(this Vouncher_Item item)
       {
           List<object> list=new List<object>();
           list.Add(item.stock.ID);
           list.Add(item.stock.Name);
           list.Add(item.stock.Price);
           list.Add(item.quantity);
           list.Add(item.Amt);
           list.Add(item.discount);
           list.Add(item.NetAmt);
           return list.ToArray();
          
       }
      */
   public static DataView filter(this DataView dv,string filterText)
   {
     
       if (filterText == string.Empty)
       {
           dv.RowFilter = string.Empty;
       }
       else
       {
          // dv.RowFilter = string.Format("StockName   LIKE '%{0}%' or GenericName  LIKE '%{0}%' ", filterText);
           dv.RowFilter = string.Format("StockName   LIKE '%{0}%' ", filterText);
       }
       return dv;
   }
     
      
    }
}
