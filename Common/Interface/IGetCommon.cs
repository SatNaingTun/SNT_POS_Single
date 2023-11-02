using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SNT_POS_Common.Entity;


namespace SNT_POS_Common.Interface
{
    interface IGetCommon<T> where T:CommonUnit
    {
        T getById(int id);
        DataTable getAll();
        void save(T t);
        void update(T t);
        void delete(int id);
        
    }
}
