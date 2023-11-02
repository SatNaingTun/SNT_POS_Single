using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.Interface;
using SNT_POS_Common.utility;
using System.Data;
using System.Data.OleDb;
using SNT_POS_Common.Entity;


namespace SNT_POS_Common.Controller
{
  public  class CompanyProfileController:IGetCommon<Contact>
    {
      

        public System.Data.DataTable getAll()
        {
            string query = "select * from tbl_Company ";
            return OledbData.Execute(query, CommandType.Text);
        }

        public Contact getCompanyProfile()
        {
            string query = "select * from tbl_Company ";
            return toCompanyProfile( OledbData.Execute(query, CommandType.Text));
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Contact company)
        {
            string query = "update tbl_company  set [CompanyName]=?,[Address]=?,[Phone]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("CompanyName", company.Name));
            parameters.Add(new OleDbParameter("Address", company.Address));
            parameters.Add(new OleDbParameter("Phone", company.Phone));
            parameters.Add(new OleDbParameter("ID", company.ID));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        private Contact toCompanyProfile( DataTable dt)
        {
            if (dt != null)
            {
                Contact company = new Contact();
                company.ID = dt.Rows[0].Field<int>("ID");
                company.Name = dt.Rows[0].Field<string>("CompanyName");
                company.Phone = dt.Rows[0].Field<string>("Phone");
                company.Address = dt.Rows[0].Field<string>("Address");
                return company;
            }
            return null;
        }


        public Contact getById(int id)
        {
            throw new NotImplementedException();
        }


        public void save(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
