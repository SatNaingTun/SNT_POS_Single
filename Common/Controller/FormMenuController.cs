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
   public class FormMenuController
    {

        public DataTable getById(int id)
        {
            string query = "select * from tbl_form_menu where ID=@id and isDeleted=false";
           
            return  OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id));
        }

        public DataTable getByName(string name)
        {
            string query = "select * from tbl_form_menu where MenuName=@MenuName and isDeleted=false";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@MenuName", name));
        }
        public int getIDByName(string name)
        {
            string query = "select ID from tbl_form_menu where MenuName=@MenuName and isDeleted=false";

            DataTable dt= OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@MenuName", name));
            if (dt != null && dt.Rows.Count>0)
                return dt.Rows[0].Field<int>("ID");
            else
                return 0;
        }


        public DataTable getByParentID(int id)
        {
            string query = "select * from tbl_form_menu where ParentID=@ParentID and isDeleted=false";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@ParentID", id));
        }

        public DataTable getWithoutParentID()
        {

            string query = "select ID,MenuName from tbl_form_menu where ParentID is Null and isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);

        }
      
     


        public DataTable getAll()
        {

            string query = "select ID,MenuName from tbl_form_menu where isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);
           
        }

        public int save(string MenuName)
        {
            string query = "insert into tbl_form_menu ([MenuName]) values(?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("MenuName", MenuName));
         
          return  OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }

        public int save(string MenuName,int ParentID)
        {
            string query = "insert into tbl_form_menu ([MenuName],[ParentID]) values(?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("MenuName", MenuName));
            parameters.Add(new OleDbParameter("ParentID", ParentID));
          return  OledbData.ExecuteSave(query, CommandType.Text,null, parameters);
        }


        

        public void update(string MenuName,int ParentID,int ID)
        {
            string query = "update tbl_form_menu  set [MenuName]=?,[ParentID]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("MenuName",MenuName));
            parameters.Add(new OleDbParameter("ParentID", ParentID));
            parameters.Add(new OleDbParameter("ID", ID));
            OledbData.ExecuteSave(query, CommandType.Text,null,parameters);
        }






        public void delete(int id)
        {
            string query = "update tbl_form_menu set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
    }
}
