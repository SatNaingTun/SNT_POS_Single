using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.utility;

namespace SNT_POS_Single_Management.utility
{
    class MyException:Exception
    { 
        public MyException()
        {

        }

        public MyException(string message)
            : base(message)
        {
           //Console.WriteLine(message);
            Logger.errorLog(message);
            
        }

        public MyException(string message, Exception inner)
            : base(message, inner)
        {
            //Console.WriteLine(message);
            Logger.errorLog(message);
        }


    }
}
