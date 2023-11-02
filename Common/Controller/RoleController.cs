using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using SNT_POS_Common.Entity;
using SNT_POS_Common.utility;
using SNT_POS_Common.Interface;

namespace SNT_POS_Common.Controller
{
   public class RoleController:IGetCommon<Role>
    {

        public Role getById(int id)
        {
            string query = "select * from tbl_Role where ID=@id and isDeleted=false";
           
            return  toRole(OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }

      

        public Role getByName(string name)
        {
            string query = "select * from tbl_Role where RoleName=@RoleName and isDeleted=false";

            return toRole(OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@RoleName", name)));
        }

        
      
     


        public DataTable getAll()
        {

            string query = "select ID,RoleName from tbl_Role where isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);
           
        }

       
        public int save2(Role role)
        {
            if (String.IsNullOrEmpty(role.Name)) throw new ArgumentNullException();
            string query = "insert into tbl_Role ([RoleName]) values(?)";
          return  OledbData.ExecuteSave(query, CommandType.Text,null, new OleDbParameter("RoleName",role.Name));
        }
   

        

        public void update(Role role)
        {
            if (String.IsNullOrEmpty(role.Name)) throw new ArgumentNullException();
            string query = "update tbl_Role  set [RoleName]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("RoleName", role.Name));
            parameters.Add(new OleDbParameter("ID", role.ID));
            OledbData.ExecuteSave(query, CommandType.Text,null,parameters);
        }






        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        private  Role toRole( DataTable dt)
        {
            if (dt != null)
            {
                Role role = new Role();
                role.ID = dt.Rows[0].Field<int>("ID");
                role.Name = dt.Rows[0].Field<string>("RoleName");

                return role;
            }
            return null;
        }


      public void save(Role role)
        {
            if (String.IsNullOrEmpty(role.Name)) throw new ArgumentNullException();
            string query = "insert into tbl_Role ([RoleName]) values(?)";
             OledbData.ExecuteSave(query, CommandType.Text, null, new OleDbParameter("RoleName", role.Name));
        }
    }
}
