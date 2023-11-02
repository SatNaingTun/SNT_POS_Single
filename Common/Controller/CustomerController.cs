using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.utility;
using System.Data;
using System.Data.OleDb;
using SNT_POS_Common.Entity;
using SNT_POS_Common.Entity;

namespace SNT_POS_Common.Controller
{
  public  class CustomerController:SNT_POS_Common.Interface.IGetCommon<Contact>
    {
        public System.Data.DataTable getAll()
        {
            string query = "select ID,Name,Address,Phone from tbl_Customer where isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);
        }

        public void delete(int id)
        {
            string query = "update tbl_Customer set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }


        public Contact getById(int id)
        {
            string query = "select * from tbl_Customer where ID=@id and isDeleted=false";
          return  toCustomer( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }
        public Contact getByName(string Name)
        {
            string query = "select * from tbl_Customer where Name=@Name and isDeleted=false";
            return toCustomer(OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@Name", Name)));
        }
        public Contact getByNameAndPhone(string Name,string Phone)
        {
            string query = "select * from tbl_Customer where Name=@Name and Phone=@Phone and isDeleted=false";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@Name", Name));
            parameters.Add(new OleDbParameter("@Phone", Phone));
            return toCustomer(OledbData.Execute(query, CommandType.Text,  parameters));
        }


        public int save(Contact customer)
        {
            string query = "insert into tbl_customer ([Name],[Address],[Phone])values(?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Name", customer.Name));
            if(customer.Address!=null)
            parameters.Add(new OleDbParameter("Address", customer.Address));
            if(customer.Phone!=null)
            parameters.Add(new OleDbParameter("Phone", customer.Phone));
            
         return   OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        public int save(string Name,string Phone)
        {
            string query = "insert into tbl_customer ([Name],[Phone])values(?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Name", Name));
           
           if(Phone!=null&& !String.IsNullOrEmpty(Phone))
            parameters.Add(new OleDbParameter("Phone", Phone));

            return OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        public int save(string Name, string Phone,string Address)
        {
            /*
            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Phone))
                throw new ArgumentNullException();
            */
            string query = "insert into tbl_customer ([Name],[Phone],[Address])values(?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Name", Name));
            parameters.Add(new OleDbParameter("Phone", Phone));
            parameters.Add(new OleDbParameter("Address",Address));

            return OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
       
       

        public void update(Contact customer)
        {
            string query = "update tbl_customer  set [Name]=?,[Address]=?,[Phone]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Name", customer.Name));
            parameters.Add(new OleDbParameter("Address", customer.Address));
            parameters.Add(new OleDbParameter("Phone", customer.Phone));
            parameters.Add(new OleDbParameter("ID", customer.ID));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        public int update(string Name, string Phone,int ID)
        {
            string query = "update tbl_customer  set [Name]=?,[Phone]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Name", Name));
            parameters.Add(new OleDbParameter("Phone", Phone));
            parameters.Add(new OleDbParameter("ID", ID));
           return OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }


        private Contact toCustomer(DataTable dt)
        {
               if (dt != null && dt.Rows.Count>0)
            {
                Contact customer=new Contact();
                customer.ID = dt.Rows[0].Field<int>("ID");
                customer.Name = dt.Rows[0].Field<string>("Name");
               
                customer.Phone = dt.Rows[0].Field<string>("Phone");
                customer.Address = dt.Rows[0].Field<string>("Address");
                


                return customer;
            }
            return null;
        }



        void Interface.IGetCommon<Entity.Contact>.save(Entity.Contact customer)
        {
            string query = "insert into tbl_customer ([Name],[Address],[Phone])values(?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("Name", customer.Name));
            if (customer.Address != null)
                parameters.Add(new OleDbParameter("Address", customer.Address));

            parameters.Add(new OleDbParameter("Phone", customer.Phone));

             OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
    }
}
