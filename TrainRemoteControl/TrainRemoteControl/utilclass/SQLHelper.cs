using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace TrainRemoteControl.utilclass
{
    class SQLHelper
    {

        private static readonly string connectionString = Program.g_dbPath;

        public static bool TestSqlConnection(string conStr)
        {
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(conStr);
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public static int ExecuteNonQuery(string sqlText, CommandType cmdType, string connectionString, params SqlParameter[] cmdParameters)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(sqlText, con);
                cmd.CommandType = cmdType;
                GetParameters(cmdParameters, cmd);
                con.Open();
                int val = cmd.ExecuteNonQuery();
                return val;
            }
            finally
            {
                Dispoal(con, cmd);
            }


        }


        public static int ExecuteNonQuery(string sqlText, params SqlParameter[] cmdParameters)
        {
            int val = SQLHelper.ExecuteNonQuery(sqlText, CommandType.Text, SQLHelper.connectionString, cmdParameters);
            return val;

        }

        public static int ExecuteNonQuery(string sqlText, CommandType cmdType, params SqlParameter[] cmdParameters)
        {
            int val = SQLHelper.ExecuteNonQuery(sqlText, cmdType, SQLHelper.connectionString, cmdParameters);
            return val;

        }

        public static object ExecuteScalar(string sqlText, string connectionString, CommandType cmdType, params SqlParameter[] cmdParameters)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(sqlText, con);
                cmd.CommandType = cmdType;
                GetParameters(cmdParameters, cmd);
                con.Open();
                object val = cmd.ExecuteScalar();
                return val;
            }
            finally
            {
                Dispoal(con, cmd);
            }

        }

        public static object ExecuteScalar(string sqlText, params SqlParameter[] cmdParameters)
        {
            object val = SQLHelper.ExecuteScalar(sqlText, SQLHelper.connectionString, CommandType.Text, cmdParameters);
            return val;
        }



        public static SQLiteDataReader ExecuteReader(string sqlText, string connectionString, params SQLiteParameter[] commandParameters)
        {
            SQLiteConnection con = null;
            SQLiteCommand cmd = null;
            try
            {
                con = new SQLiteConnection(connectionString);
                cmd = new SQLiteCommand(sqlText, con);
                //cmd.CommandType = cmdType;
                //GetParameters(cmdParameters, cmd);
                //AttachParameters(cmd, sqlText, commandParameters);

                if (commandParameters != null)
                {
                    cmd.Parameters.AddRange(commandParameters);
                } 


                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                SQLiteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;  
                
            }
            catch (Exception e)
            {
                Dispoal(con, cmd); //在dal关闭SqlDataReadeer关闭该链接 
                throw e;
            }
        }

        public static SQLiteDataReader ExecuteReader(string sqlText, params SQLiteParameter[] cmdParameters)
        {
            return ExecuteReader(sqlText, SQLHelper.connectionString, cmdParameters);
        }

        private static void GetParameters(SqlParameter[] cmdParameters, SqlCommand cmd)
        {
            if (cmdParameters != null)
            {
                foreach (SqlParameter parm in cmdParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        private static void AttachParameters(SQLiteCommand cmd, string commandText, params object[] paramList)
        {
            if (paramList == null || paramList.Length == 0) return;
            SQLiteParameterCollection coll = cmd.Parameters;
            string parmString = commandText.Substring(commandText.IndexOf("@", StringComparison.Ordinal));
            // pre-process the string so always at least 1 space after a comma.  
            parmString = parmString.Replace(",", " ,");
            // get the named parameters into a match collection  
            const string pattern = @"(@)\S*(.*?)\b";
            var ex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = ex.Matches(parmString);
            var paramNames = new string[mc.Count];
            int i = 0;
            foreach (Match m in mc)
            {
                paramNames[i] = m.Value;
                i++;
            }
            // now let's type the parameters  
            int j = 0;
            foreach (object o in paramList)
            {
                var parm = new SQLiteParameter();
                if (o == null)
                {
                    parm.DbType = DbType.Object;
                    parm.ParameterName = paramNames[j];
                    parm.Value = paramList[j];
                    coll.Add(parm);
                    j++;
                    continue;
                }
                Type t = o.GetType();
                switch (t.ToString())
                {
                    case ("DBNull"):
                    case ("Char"):
                    case ("SByte"):
                    case ("UInt16"):
                    case ("UInt32"):
                    case ("UInt64"):
                        throw new SystemException("Invalid data type");
                    case ("System.String"):
                        parm.DbType = DbType.String;
                        parm.ParameterName = paramNames[j];
                        parm.Value = paramList[j];
                        coll.Add(parm);
                        break;
                    case ("System.Byte[]"):
                        parm.DbType = DbType.Binary;
                        parm.ParameterName = paramNames[j];
                        parm.Value = paramList[j];
                        coll.Add(parm);
                        break;
                    case ("System.Int32"):
                        parm.DbType = DbType.Int32;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (int)paramList[j];
                        coll.Add(parm);
                        break;
                    case ("System.Boolean"):
                        parm.DbType = DbType.Boolean;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (bool)paramList[j];
                        coll.Add(parm);
                        break;
                    case ("System.DateTime"):
                        parm.DbType = DbType.DateTime;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDateTime(paramList[j]);
                        coll.Add(parm);
                        break;
                    case ("System.Double"):
                        parm.DbType = DbType.Double;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDouble(paramList[j]);
                        coll.Add(parm);
                        break;
                    case ("System.Decimal"):
                        parm.DbType = DbType.Decimal;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDecimal(paramList[j]);
                        break;
                    case ("System.Guid"):
                        parm.DbType = DbType.Guid;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (Guid)(paramList[j]);
                        break;
                    case ("System.Object"):
                        parm.DbType = DbType.Object;
                        parm.ParameterName = paramNames[j];
                        parm.Value = paramList[j];
                        coll.Add(parm);
                        break;
                    default:
                        throw new SystemException("Value is of unknown data type");
                } // end switch  
                j++;
            }
        }   


        private static void Dispoal(SqlConnection con, SqlCommand cmd)
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        private static void Dispoal(params IDisposable[] dis)
        {
            foreach (IDisposable d in dis)
            {
                if (d != null)
                {
                    d.Dispose();
                }
            }
        }
    }
}
