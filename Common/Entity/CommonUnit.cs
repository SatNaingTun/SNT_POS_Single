using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SNT_POS_Common.Entity
{
   public abstract class CommonUnit:IComparable<CommonUnit>
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public virtual List<object> toList()
        {
           var bindingFlags = BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public;
            var fieldValues = this.GetType()
                                 .GetFields(bindingFlags)
                                 .Select(field => field.GetValue(this))
                                 .ToList();
            return fieldValues;
        }

        public virtual object[] toArray()
        {
            var bindingFlags = BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.Public;
            var fieldValues = this.GetType()
                                 .GetFields(bindingFlags)
                                 .Select(field => field.GetValue(this))
                                 .ToArray();
            return fieldValues;
        }



        public int CompareTo(CommonUnit other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
