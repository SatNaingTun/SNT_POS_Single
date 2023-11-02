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
   public class FormMenuControl_Controller
   {

       
        public DataTable getByRoleId(int Roleid)
        {
            string query = "select * from tbl_form_menu_control where RoleID=@RoleID and isDeleted=false";

            return OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@RoleID", Roleid));
        }

        public bool isAuthorize(int RoleID, int MenuID)
        {
            string query = "select isAuthorize from tbl_form_menu_control where RoleID=@RoleID and MenuID=@MenuID  and isDeleted=false";

            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@RoleID", RoleID));
            parameters.Add(new OleDbParameter("@MenuID", MenuID));
             object value=OledbData.ExecuteScalar(query, CommandType.Text, null, parameters);

             if (value != null)
                 return (bool)value;
             else
                 return false;
            
        }

     


        public DataTable getAll()
        {

            string query = "select * from tbl_form_menu_control where isDeleted=false";
            return OledbData.Execute(query, CommandType.Text);
           
        }


        public void save(int RoleID,int MenuID,bool isAuthorize)
        {
            string query = "insert into tbl_form_menu_control ([RoleID],[MenuID],[isAuthorize]) values(?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("RoleID", RoleID));
            parameters.Add(new OleDbParameter("MenuID", MenuID));
            parameters.Add(new OleDbParameter("isAuthorize", isAuthorize));
            OledbData.ExecuteSave(query, CommandType.Text,null, parameters);
        }


        

        public void update(int RoleID,int MenuID,bool isAuthorize)
        {
            string query = "update tbl_form_menu_control  set [isAuthorize]=? where [RoleID]=? and [MenuID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("isAuthorize", isAuthorize));
            parameters.Add(new OleDbParameter("RoleID", RoleID));
            parameters.Add(new OleDbParameter("MenuID", MenuID));
           
            OledbData.ExecuteSave(query, CommandType.Text,null,parameters);
        }






        public void delete(int id)
        {
            string query = "update tbl_form_menu_control set [isDeleted]=true where [RoleID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("RoleID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
    }
}
