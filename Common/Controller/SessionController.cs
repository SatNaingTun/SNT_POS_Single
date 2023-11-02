using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.Interface;
using System.Data.OleDb;
using SNT_POS_Common.utility;
using System.Data;
using SNT_POS_Common.Entity;

namespace SNT_POS_Common.Controller
{
   public class SessionController:IGetCommon<Session>
    {
        public Session getById(int id)
        {
            string query = "select * from tbl_Session where ID=@id and isDeleted=false";

            return toSession( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }
        public Session getByUserId(int id)
        {
            string query = "select * from tbl_Session where UserID=@Userid and LogoutDateTime Is Null  and isDeleted=false order by ID desc";

            return toSession( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@Userid", id)));
        }


        

        public int getVrCount(int id)
        {

            string query = "select VrCount from tbl_Session where ID=@id and isDeleted=false";

            return (int)OledbData.ExecuteScalar(query, CommandType.Text, null, new OleDbParameter("@id", id));

        }

        public void setVrCount(int id,int VrCount)
        {

            string query = "update tbl_Session  set [VrCount]=? where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("VrCount", VrCount));
            parameters.Add(new OleDbParameter("ID", id));
          
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);

        }


        public System.Data.DataTable getAll()
        {
            string query = "select ID,UserID,VrCount,LoginDateTime,LogoutDateTime from tbl_Session where isDeleted=false";

            return OledbData.Execute(query, CommandType.Text);
        }

        public System.Data.DataTable getByDT(DateTime startDT,DateTime endDT)
        {
            string query = "select ID,UserID,VrCount,LoginDateTime,LogoutDateTime from tbl_Session where LoginDateTime>@loginDT and  LogoutDateTime<@logoutDT and isDeleted=false";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
           
            parameters.Add(new OleDbParameter("LoginDateTime", startDT));
            parameters.Add(new OleDbParameter("LogoutDateTime", endDT));
            return OledbData.Execute(query, CommandType.Text, parameters);
        }

        public int save(Session session)
        {
            string query = "insert into tbl_Session ([UserID],[LoginDateTime],[LogoutDateTime]) values(?,?,?)";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("UserID", session.user.ID));
            parameters.Add(new OleDbParameter("LoginDateTime", session.LoginDT.ToString()));
            parameters.Add(new OleDbParameter("LogoutDateTime", session.LogoutDT.ToString()));
           return OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }
        public void update(Session session)
        {
            string query = "update  tbl_Session set [LoginDateTime]=?,[LogoutDateTime]=? where ID=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
           
            parameters.Add(new OleDbParameter("LoginDateTime", session.LoginDT.ToString()));
            parameters.Add(new OleDbParameter("LogoutDateTime", session.LogoutDT.ToString()));
            parameters.Add(new OleDbParameter("ID", session.ID));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }




        public void delete(int id)
        {
            string query = "update tbl_Session  set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
        }


       private Session toSession(DataTable dt)
        {
            if (dt != null)
            {
                Session session = new Session();
                session.ID = dt.Rows[0].Field<int>("ID");
                session.LoginDT = dt.Rows[0].Field<DateTime>("LoginDateTime");

                session.LogoutDT = dt.Rows[0].Field<DateTime>("LogoutDateTime");
                session.user = new User();
                session.user.ID = dt.Rows[0].Field<int>("UserID");

                return session;
            }
            return null;
        }


       void IGetCommon<Session>.save(Session t)
       {
           throw new NotImplementedException();
       }
    }
}
