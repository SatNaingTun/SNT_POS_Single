using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNT_POS_Common.utility
{
  public  class CommonMethod
    {
      public static string RemoveSpecialCharacters(string str)
      {
          StringBuilder sb = new StringBuilder();
          for (int i = 0; i < str.Length; i++)
          {
              if ((str[i] >= '0' && str[i] <= '9')
                  || (str[i] >= 'A' && str[i] <= 'z'
                      || (str[i] == '.' )))
              {
                  sb.Append(str[i]);
              }
          }

          return sb.ToString();
      }

   
    


    }
}
