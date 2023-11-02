using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SNT_POS_Common.utility
{
  public static class ParameterToString
    {
      public static string toInsertCmd(this List<OleDbParameter> parametrers)
      {
          string parameterString="(";
         
          foreach (OleDbParameter para in parametrers)
          {
              parameterString += "[" + para.ParameterName + "],";
          }
          parameterString = parameterString.TrimEnd(',');
          parameterString += " )values(";
          foreach (OleDbParameter para in parametrers)
          {
              parameterString += "?,";
          }
          parameterString = parameterString.TrimEnd(',');
          parameterString += ")";
          return parameterString;
      }

      public static string toUpdateCmd(this List<OleDbParameter> parametrers,params string[] NullCols)
      {
          string parameterString = "";
          foreach (OleDbParameter para in parametrers)
          {
              
             
              parameterString += "[" + para.ParameterName + "]=?,";
             
          }
          foreach (string NullCol in NullCols)
          {
              if(NullCol!="")
                  parameterString += "[" + NullCol + "]=null,";
          }
          parameterString = parameterString.TrimEnd(',');
          return parameterString;
      }

    }
}
