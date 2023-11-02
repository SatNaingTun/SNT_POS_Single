using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;


namespace SNT_POS_Common.utility
{
   public class OledbData
    {
        #region  Vars
        OleDbConnection conn;
       // OleDbCommand cmd;
         public static string connString = SNT_POS_Single.Properties.Settings.Default.SNT_POS_DBConnectionString;
       // DataTable dt;
       
        #endregion
       
        protected  void openConnection()
        {
            this.conn = new OleDbConnection();
            this.conn.ConnectionString=connString;
            if (this.conn.State == System.Data.ConnectionState.Closed)
                this.conn.Open();

        }
        

        protected void closeConnection()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }

       

        public static Object ExecuteScalar(String commandText,
            CommandType commandType, String connectionString = null, List<OleDbParameter> parameters = null)
        {
            OledbData oledbdata = new OledbData();
            if (connectionString == null)
                connectionString = connString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.Clear();
                    if(parameters!=null)
                    cmd.Parameters.AddRange(parameters.ToArray());

                    conn.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }
        public static Object ExecuteScalar(String commandText,
           CommandType commandType, String connectionString = null,params OleDbParameter[] parameters )
        {
           
            if (connectionString == null)
                connectionString = connString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.Clear();
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                     conn.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable Execute(String commandText,
        CommandType commandType, List<OleDbParameter> parameters = null, String connectionString = null)
        {
            try
            {
                OledbData oledbdata = new OledbData();
                if (connectionString == null)
                    connectionString = connString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                    {
                        cmd.CommandType = commandType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters.ToArray());

                        conn.Open();
                        // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                        // IDataReader is closed.
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        conn.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
               Logger.errorLog(ex.Message);
            }
            return null;
        }

        public static DataTable Execute(String commandText,
       CommandType commandType,  String connectionString = null, params OleDbParameter [] parameters)
        {
            try
            {
                if (connectionString == null)
                    connectionString = connString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                    {
                        cmd.CommandType = commandType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters.ToArray());

                        conn.Open();
                        // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                        // IDataReader is closed.
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        conn.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.errorLog(ex.Message);
            }
            return null;
        }

        public static int ExecuteSave(String commandText,
       CommandType commandType, String connectionString = null, params OleDbParameter[] parameters)
        {
            try
            {
                if (connectionString == null)
                    connectionString = connString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                    {
                        cmd.CommandType = commandType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                        // IDataReader is closed.
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "Select @@Identity";
                        return (int)cmd.ExecuteScalar();


                    }
                }
            }
            catch (Exception ex)
            {
                Logger.errorLog(ex.Message);
                return -1;
            }
           
        }


        public static int ExecuteSave(String commandText,
       CommandType commandType, String connectionString = null, List< OleDbParameter> parameters=null)
        {
            try
            {
                if (connectionString == null)
                    connectionString = connString;
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                    {
                        cmd.CommandType = commandType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters.ToArray());

                        conn.Open();
                        // When using CommandBehavior.CloseConnection, the connection will be closed when the   
                        // IDataReader is closed.
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "Select @@Identity";
                        return (int)cmd.ExecuteScalar();

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.errorLog(ex.Message);
                return -1;
            }
            


        }
    }
}
