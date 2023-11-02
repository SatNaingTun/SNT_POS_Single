using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.Entity;
using System.Data;
using System.Globalization;


namespace SNT_POS_Common.utility
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
   public static DataTable filter(this DataTable dt, string filterText)
   {
       DataView dv = dt.DefaultView;
       if (filterText == string.Empty)
       {
           dv.RowFilter = string.Empty;
       }
       else
       {
           // dv.RowFilter = string.Format("StockName   LIKE '%{0}%' or GenericName  LIKE '%{0}%' ", filterText);
           dv.RowFilter = string.Format("StockName   LIKE '%{0}%' ", filterText);
       }
       return dv.ToTable();
   }

   public static DataTable filter(this DataTable dt, string filterText,string filtercol)
   {
        DataView dv = dt.DefaultView;
      
       if (filterText == string.Empty||filtercol==string.Empty)
       {
           dv.RowFilter = string.Empty;
       }
       else
       {
           try
           {
               // dv.RowFilter = string.Format("StockName   LIKE '%{0}%' or GenericName  LIKE '%{0}%' ", filterText);
               if (dt.Columns[filtercol].DataType == typeof(int))
               {
                   dv.RowFilter = string.Format(filtercol + " = {0}", filterText);
               }
               else if (dt.Columns[filtercol].DataType == typeof(decimal))
               {
                   dv.RowFilter = string.Format(filtercol + " = {0}", filterText);
               }
               else if (dt.Columns[filtercol].DataType == typeof(double))
               {
                   dv.RowFilter = string.Format(filtercol + " = {0}", filterText);
               }
               else if (dt.Columns[filtercol].DataType == typeof(DateTime))
               {

                  DateTime date = DateTime.ParseExact(filterText, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                   //DateTime date = DateTime.Now;
                  
                  DateTime startDT = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                  DateTime endDT = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                  dv.RowFilter = string.Format(filtercol + " >= CONVERT('{0}', 'System.DateTime') and "+filtercol+"<= CONVERT('{1}', 'System.DateTime')", startDT, endDT);
                  
                   //dv.RowFilter = string.Format(filtercol + "= '{0}' ", date);
               }
               else
               {
                   dv.RowFilter = string.Format(filtercol + " LIKE '%{0}%'", filterText);
               }
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }
       return dv.ToTable();
   }
     
      
    }
}
