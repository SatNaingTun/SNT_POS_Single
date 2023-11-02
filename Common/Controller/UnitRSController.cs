using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNT_POS_Common.utility;
using System.Data;
using SNT_POS_Common.Interface;
using System.Data.OleDb;
using SNT_POS_Common.Entity;

namespace SNT_POS_Common.Controller
{
   public class UnitRSController : IGetCommon<UnitRS>
    {

        public UnitRS getById(int id)
        {
            string query = "select * from Units_RS where ID=@id and isDeleted=false";

            return toUnitRS( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@id", id)));
        }

        public UnitRS getByStockId(int StockID)
        {
            string query = "SELECT Units_RS.ID,Units_RS.StockID,tbl_Stock.StockName,Units_RS.ParentUnitID,Units_RS.ChildUnitID,Units_RS.ParentQuantity,Units_RS.ChildQuantity FROM Units_RS INNER JOIN tbl_Stock ON tbl_Stock.ID = Units_RS.StockID where StockID=@id and Units_RS.isDeleted=false";

            return toUnitRS( OledbData.Execute(query, CommandType.Text, null, new OleDbParameter("@StockID", StockID)));
        }
        public UnitRS getUnitRS(UnitRS unitRS,bool ignoreStockID=false)
        {
            if (ignoreStockID == false)
            {
                string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID = @ParentUnitID and ChildUnitID = @ChildUnitID ";
                //string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ParentUnit.Name+"+' ) and ChildUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ChildUnit.Name+"')";
                List<OleDbParameter> parameters = new List<OleDbParameter>();
                parameters.Add(new OleDbParameter("@StockID", unitRS.stock.ID));
                parameters.Add(new OleDbParameter("@ParentUnitID", unitRS.ParentUnit.ID));
                parameters.Add(new OleDbParameter("@ChildUnitID", unitRS.ChildUnit.ID));

                return toUnitRS(OledbData.Execute(query, CommandType.Text, parameters));
            }
            else
            {
                string query = "SELECT * FROM Units_RS where  Units_RS.isDeleted=false and StockID is null and ParentUnitID = @ParentUnitID and ChildUnitID = @ChildUnitID ";
                //string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ParentUnit.Name+"+' ) and ChildUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ChildUnit.Name+"')";
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                parameters.Add(new OleDbParameter("@ParentUnitID", unitRS.ParentUnit.ID));
                parameters.Add(new OleDbParameter("@ChildUnitID", unitRS.ChildUnit.ID));

                return toUnitRS(OledbData.Execute(query, CommandType.Text, parameters));
            }
        }
        public UnitRS getUnitRS(int StockID, int ParentUnitID, int ChildUnitID)
        {
            string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID = @ParentUnitID and ChildUnitID = @ChildUnitID ";
            //string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ParentUnit.Name+"+' ) and ChildUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ChildUnit.Name+"')";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@StockID", StockID));
            parameters.Add(new OleDbParameter("@ParentUnitID", ParentUnitID));
            parameters.Add(new OleDbParameter("@ChildUnitID", ChildUnitID));

            return toUnitRS(OledbData.Execute(query, CommandType.Text, parameters));
        }
        public UnitRS getUnitRS( int ParentUnitID, int ChildUnitID)
        {
            string query = "SELECT * FROM Units_RS where  Units_RS.isDeleted=false and StockID is null and ParentUnitID = @ParentUnitID and ChildUnitID = @ChildUnitID ";
            //string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ParentUnit.Name+"+' ) and ChildUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ChildUnit.Name+"')";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
           
            parameters.Add(new OleDbParameter("@ParentUnitID", ParentUnitID));
            parameters.Add(new OleDbParameter("@ChildUnitID", ChildUnitID));

            return toUnitRS(OledbData.Execute(query, CommandType.Text, parameters));
        }
       /*
        public UnitRS getUnitRS(int StockID,string ParentUnitName,string ChildUnitName)
        {
            string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID In (select ID from tbl_Units where UnitName=@ParentUnitName ) and ChildUnitID In (select ID from tbl_Units where UnitName=@ChildUnitName )  ";
            //string query = "SELECT * FROM Units_RS where Units_RS.StockID=@StockID and Units_RS.isDeleted=false and ParentUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ParentUnit.Name+"+' ) and ChildUnitID in (select ID from tbl_Units where UnitName='"+unitRS.ChildUnit.Name+"')";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@StockID", StockID));
            parameters.Add(new OleDbParameter("@ParentUnitName", ParentUnitName));
            parameters.Add(new OleDbParameter("@ChildUnitName", ChildUnitName));

            return toUnitRS( OledbData.Execute(query, CommandType.Text, parameters));
        }
        */ 


        public System.Data.DataTable getAll()
        {
           string query = "SELECT Units_RS.ID,Units_RS.StockID,tbl_Stock.StockName,Units_RS.ParentUnitID,Units_RS.ChildUnitID,Units_RS.ParentQuantity,Units_RS.ChildQuantity FROM Units_RS  left JOIN tbl_Stock  ON  Units_RS.StockID=tbl_Stock.ID     where  Units_RS.isDeleted=false ";
            //string query = "SELECT Units_RS.ID, Units_RS.StockID, tbl_Stock.StockName, Units_RS.ParentUnitID, Units_RS.ChildUnitID, Units_RS.ParentQuantity, Units_RS.ChildQuantity, parentUnit.UnitName, childUnit.UnitName FROM tbl_Units AS childUnit INNER JOIN (tbl_Units AS parentUnit INNER JOIN (Units_RS LEFT JOIN tbl_Stock ON Units_RS.StockID = tbl_Stock.ID) ON (parentUnit.ID = Units_RS.ParentUnitID) AND (parentUnit.ID = tbl_Stock.UnitID)) ON (childUnit.ID = Units_RS.ChildUnitID) AND (childUnit.ID = tbl_Stock.UnitID) WHERE (((Units_RS.isDeleted)=False)) ";
            return OledbData.Execute(query, CommandType.Text);
        }

        public System.Data.DataTable getAllwithUnitName()
        {
            string query = "SELECT Units_RS.ID, Units_RS.StockID, tbl_Stock.StockName, Units_RS.ParentUnitID, Units_RS.ChildUnitID, Units_RS.ParentQuantity, Units_RS.ChildQuantity, tbl_Units.UnitName AS ParentUnitName, tbl_Units2.UnitName AS ChildUnitName FROM ((Units_RS LEFT JOIN tbl_Stock ON Units_RS.StockID = tbl_Stock.ID) LEFT JOIN tbl_Units ON Units_RS.ParentUnitID = tbl_Units.ID) LEFT JOIN tbl_Units AS tbl_Units2 ON Units_RS.ChildUnitID = tbl_Units2.ID WHERE (((Units_RS.isDeleted)=False)) ";
            //string query = "SELECT Units_RS.ID, Units_RS.StockID, tbl_Stock.StockName, Units_RS.ParentUnitID, Units_RS.ChildUnitID, Units_RS.ParentQuantity, Units_RS.ChildQuantity, parentUnit.UnitName, childUnit.UnitName FROM tbl_Units AS childUnit INNER JOIN (tbl_Units AS parentUnit INNER JOIN (Units_RS LEFT JOIN tbl_Stock ON Units_RS.StockID = tbl_Stock.ID) ON (parentUnit.ID = Units_RS.ParentUnitID) AND (parentUnit.ID = tbl_Stock.UnitID)) ON (childUnit.ID = Units_RS.ChildUnitID) AND (childUnit.ID = tbl_Stock.UnitID) WHERE (((Units_RS.isDeleted)=False)) ";
            return OledbData.Execute(query, CommandType.Text);
        }


       


        public void save(UnitRS unitRS,bool ignoreStock)
        {

            if (ignoreStock == true)
            {

                string query = "insert into Units_RS ([ParentUnitID],[ChildUnitID],[ParentQuantity],[ChildQuantity]) values(?,?,?,?)";
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                parameters.Add(new OleDbParameter("ParentUnitID", unitRS.ParentUnit.ID));
                parameters.Add(new OleDbParameter("ChildUnitID", unitRS.ChildUnit.ID));
                parameters.Add(new OleDbParameter("ParentQuantity", unitRS.parentQuantity));
                parameters.Add(new OleDbParameter("ChildQuantity", unitRS.childQuantity));

                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);

            }
            else
            {
                save(unitRS);
            }
            
        }


        public void update(UnitRS unitRS, bool ignoreStock)
        {
            if (ignoreStock == true)
            {
                string query = "update Units_RS  set [ParentUnitID]=?,[ChildUnitID]=?,[ParentQuantity]=?,[ChildQuantity]=?,StockID=NULL where [ID]=?";

                List<OleDbParameter> parameters = new List<OleDbParameter>();

                parameters.Add(new OleDbParameter("ParentUnitID", unitRS.ParentUnit.ID));
                parameters.Add(new OleDbParameter("ChildUnitID", unitRS.ChildUnit.ID));
                parameters.Add(new OleDbParameter("ParentQuantity", unitRS.parentQuantity));
                parameters.Add(new OleDbParameter("ChildQuantity", unitRS.childQuantity));
                parameters.Add(new OleDbParameter("ID", unitRS.ID));

                OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
            }
            else
            {
                update(unitRS);
            }
          

        }
      




        public DataTable getByName(string name)
        {
            throw new NotImplementedException();
        }


        public void delete(int id)
        {
            string query = "update Units_RS  set [isDeleted]=true where [ID]=?";
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("ID", id));
            OledbData.ExecuteSave(query, CommandType.Text, null, parameters);

        }


       private UnitRS toUnitRS(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                UnitRS unitRS = new UnitRS();
                unitRS.ID = dt.Rows[0].Field<int>("ID");

                //if (dt.Rows[0].Field<int>("StockID").Equals(DBNull.Value)!=true )
                if (dt.Rows[0]["StockID"] != DBNull.Value)
                {
                    unitRS.stock = new Stock();
                    unitRS.stock.ID = dt.Rows[0].Field<int>("StockID");
                }
                unitRS.ParentUnit = new Unit();
                unitRS.ParentUnit.ID = dt.Rows[0].Field<int>("ParentUnitID");
                unitRS.ChildUnit = new Unit();
                unitRS.ChildUnit.ID = dt.Rows[0].Field<int>("ChildUnitID");
                unitRS.parentQuantity = dt.Rows[0].Field<decimal>("ParentQuantity");
                unitRS.childQuantity = dt.Rows[0].Field<decimal>("ChildQuantity");


                return unitRS;
            }
            else
            {
                return null;
            }
        }


       public void save(UnitRS unitRS)
       {
           string query = "insert into Units_RS ([StockID],[ParentUnitID],[ChildUnitID],[ParentQuantity],[ChildQuantity]) values(?,?,?,?,?)";
           List<OleDbParameter> parameters = new List<OleDbParameter>();
           parameters.Add(new OleDbParameter("StockID", unitRS.stock.ID));
           parameters.Add(new OleDbParameter("ParentUnitID", unitRS.ParentUnit.ID));
           parameters.Add(new OleDbParameter("ChildUnitID", unitRS.ChildUnit.ID));
           parameters.Add(new OleDbParameter("ParentQuantity", unitRS.parentQuantity));
           parameters.Add(new OleDbParameter("ChildQuantity", unitRS.childQuantity));

           OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
       }

       public void update(UnitRS unitRS)
       {

           string query = "update Units_RS  set [StockID]=?,[ParentUnitID]=?,[ChildUnitID]=?,[ParentQuantity]=?,[ChildQuantity]=? where [ID]=?";

           List<OleDbParameter> parameters = new List<OleDbParameter>();
           parameters.Add(new OleDbParameter("StockID", unitRS.stock.ID));
           parameters.Add(new OleDbParameter("ParentUnitID", unitRS.ParentUnit.ID));
           parameters.Add(new OleDbParameter("ChildUnitID", unitRS.ChildUnit.ID));
           parameters.Add(new OleDbParameter("ParentQuantity", unitRS.parentQuantity));
           parameters.Add(new OleDbParameter("ChildQuantity", unitRS.childQuantity));
           parameters.Add(new OleDbParameter("ID", unitRS.ID));

           OledbData.ExecuteSave(query, CommandType.Text, null, parameters);
       }
    }
}