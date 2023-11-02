using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNT_POS_Common.Entity
{
  public  class Session:CommonUnit
    {
       
     
        public DateTime LoginDT { get; set; }
        public DateTime LogoutDT { get; set; }
        public User user { get; set; }
     
        
    }
}
