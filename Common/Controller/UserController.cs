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
   public class UserController:IGetCommon<User>
    {

        public User getUser(string name,string password)
        {
            string query = "select * from Users where UserName=@UserName and Password=@Password and isDeleted=false";

            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@UserName", name));
            parameters.Add(new OleDbParameter("@Password", password));
            return toUser( OledbData.Execute(query,CommandType.Text,parameters));
        }

        public bool isAuthorize(string name, string password)
        {
            string query = "select ID from Users where UserName=@UserName and Password=@Password and isDeleted=false";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@UserName", name));
            parameters.Add(new OleDbParameter("@Password", password));
            object value = OledbData.ExecuteScalar(query, CommandType.Text, null, parameters);
            if (value != null) return true;


            return false;

        }

        public int getUserID(string name, string password)
        {
            string query = "select ID from Users where UserName=@UserName and Password=@Password and isDeleted=false";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@UserName", name));
            parameters.Add(new OleDbParameter("@Password", password));
            object value = OledbData.ExecuteScalar(query, CommandType.Text, null, parameters);


            if (value != null)
                return (int)value;
            else
                return 0;

        }

        public System.Data.DataTable getAll()
        {

            string query = "select ID,UserName,RoleID from Users where isDeleted=false order by ID asc";

            return OledbData.Execute(query, CommandType.Text, null);
        }

        public void save(User user)
        {
            isEmptyString(user);
            string query = "insert into Users ([UserName],[Password],[RoleID]) values(?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("UserName", user.Name));
            parameters.Add(new OleDbParameter("Password", user.password));
            parameters.Add(new OleDbParameter("RoleID", user.role.ID));

            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }




        public void update(User user)
        {
            isEmptyString(user);
            string query = "update Users  set [UserName]=?,[Password]=?,[RoleID]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("UserName", user.Name));
            parameters.Add(new OleDbParameter("Password", user.password));
            parameters.Add(new OleDbParameter("RoleID", user.role.ID));
            parameters.Add(new OleDbParameter("ID", user.ID));

            OledbData.ExecuteSave(query, CommandType.Text,null,parameters);
        }

        public void isEmptyString(User user)
        {
            if (String.IsNullOrEmpty(user.Name) || String.IsNullOrEmpty(user.password))
                throw new ArgumentNullException();
        }




        public void delete(int id)
        {
            string query = "update Users set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }


        private User toUser(DataTable dt)
        {
            if (dt != null)
            {
                User user = new User();
                user.ID = dt.Rows[0].Field<int>("ID");
                user.Name = dt.Rows[0].Field<string>("UserName");
                user.password = dt.Rows[0].Field<string>("password");
                user.role = new Role();
                user.role.ID = dt.Rows[0].Field<int>("RoleID");

                return user;
            }
            return null;
        }

        public User getById(int id)
        {
            string query = "select * from Users where ID=@id and isDeleted=false";

            return toUser(OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }
    }
}
