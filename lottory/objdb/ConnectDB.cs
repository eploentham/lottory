using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using lottory.object1;
using MySql.Data.MySqlClient;

namespace lottory.objdb
{
    public class ConnectDB
    {
        public String Unamelogin = "";
        public OleDbConnection cntemp = new OleDbConnection();
        public int portnumber = 0;
        public String UName = "", User1 = "", SS = "";
        public OleDbConnection _mainConnection = new OleDbConnection();
        public MySql.Data.MySqlClient.MySqlConnection cMysql;

        public int _rowsAffected = 0;
        public SqlInt32 _errorCode = 0;
        public Boolean _isDisposed = false;
        public SqlConnection connMainHIS;
        private String hostname = "";
        //private IniFile iniFile;
        public String databaseNameMainHIS = "";
        public String hostNameMainHIS = "";
        public String userNameMainHIS = "";
        public String passwordMainHIS = "";
        public String databaseNameBua = "";
        public String hostNameBua = "";
        public String userNameBua = "";
        public String passwordBua = "";
        public String server = "";
        public String isBranch = "";
        private InitConfig initc;
        //public DataTable toReturn = new DataTable();
        public DataTable dt = new DataTable();
        //OleDbCommand cmdToExecute = new OleDbCommand();
        public ConnectDB(InitConfig  i)
        {
            initc = i;

            if (initc.StatusServer.ToLower().Equals("yes"))
            {
                if (initc.connectDatabaseServer.ToLower().Equals("yes"))
                {
                    cMysql = new MySql.Data.MySqlClient.MySqlConnection();
                    cMysql.ConnectionString = "server=" + initc.ServerIP + ";uid=" + initc.User + ";pwd=" + initc.Password + ";database=test;";
                }
                else
                {
                    if (Environment.Is64BitOperatingSystem)
                    {
                        _mainConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\source\\lottory\\lottory\\DataBase\\lottory.mdb;Persist Security Info=False";
                        _mainConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Environment.CurrentDirectory + "\\Database\\lottory.mdb;Persist Security Info=False";
                    }
                    else
                    {
                        _mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\\source\\lottory\\lottory\\DataBase\\lottory.mdb;Persist Security Info=False";
                        _mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Environment.CurrentDirectory + "\\Database\\lottory.mdb;Persist Security Info=False";
                    }
                }
            }
            else
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    //_mainConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\source\\lottory\\lottory\\DataBase\\lottory.mdb;Persist Security Info=False";
                    //_mainConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Environment.CurrentDirectory + "\\Database\\lottory.mdb;Persist Security Info=False";
                    _mainConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + "\\"+initc.pathShareData + "\\Database\\lottory.mdb;Persist Security Info=False";
                }
                else
                {
                    //_mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\\source\\lottory\\lottory\\DataBase\\lottory.mdb;Persist Security Info=False";
                    //_mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Environment.CurrentDirectory + "\\Database\\lottory.mdb;Persist Security Info=False";
                    _mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + "\\" + initc.pathShareData + "\\Database\\lottory.mdb;Persist Security Info=False";
                }
            }
            //_mainConnection = new OleDbConnection();
            //_mainConnection.ConnectionString = GetConfig("Main.ConnectionString");
            
            //_mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\\source\\lottory\\lottory\\DataBase\\lottory.mdb;Persist Security Info=False";
            _isDisposed = false;
        }
        public ConnectDB(String hostName)
        {
            if (hostName == "mainhis")
            {
                hostname = "mainhis";
                connMainHIS = new SqlConnection();
                //connMainHIS.ConnectionString = GetConfig(hostName);
                connMainHIS.ConnectionString = "Server="+hostNameMainHIS+";Database="+databaseNameMainHIS.ToString()+";Uid="+userNameMainHIS+";Pwd="+passwordMainHIS+";";
            }
            else if (hostName == "bangna")
            {
                hostname = "bangna";
                connMainHIS = new SqlConnection();
                //connMainHIS.ConnectionString = GetConfig(hostName);
                connMainHIS.ConnectionString = "Server="+hostNameBua+";Database="+databaseNameBua+";Uid="+userNameBua+";Pwd="+passwordBua+";";
            }
            else
            {
                _mainConnection = new OleDbConnection();
                //_mainConnection.ConnectionString = GetConfig("Main.ConnectionString");
                if (Environment.Is64BitOperatingSystem)
                {
                    _mainConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\source\\reportBangna\\reportBangna\\DataBase\\reportBangna.mdb;Persist Security Info=False";
                }
                else
                {
                    _mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\\source\\reportBangna\\reportBangna\\DataBase\\reportBangna.mdb;Persist Security Info=False";
                }
                //_mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\\source\reportBangna\\reportBangna\\DataBase\\reportBangna.mdb;Persist Security Info=False";
                _isDisposed = false;
            }
        }
        public String GetConfig(String key)
        {

            AppSettingsReader _configReader = new AppSettingsReader();
            // Set connection string of the sqlconnection object
            return _configReader.GetValue(key, "".GetType()).ToString();
        }
        public DataTable selectData(String sql)
        {
            DataTable toReturn = new DataTable();
            //toReturn.Clear();
            if (initc.StatusServer.Equals("yes"))
            {
                if (initc.connectDatabaseServer.Equals("yes"))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, cMysql);
                    //SqlDataAdapter adapMainhis = new SqlDataAdapter(comMainhis);
                    try
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(toReturn);
                        //return toReturn;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("", ex);
                    }
                    finally
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Close();
                        cmd.Dispose();
                    }
                }
                else
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, _mainConnection);
                    //cmdToExecute.Connection = _mainConnection;
                    try
                    {
                        _mainConnection.Open();
                        adapter.Fill(toReturn);
                        //return toReturn;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("", ex);
                    }
                    finally
                    {
                        _mainConnection.Close();
                        //cmdToExecute.Dispose();
                        adapter.Dispose();
                    }
                }
                
            }
            else
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, _mainConnection);
                //cmdToExecute.Connection = _mainConnection;
                try
                {
                    _mainConnection.Open();
                    adapter.Fill(toReturn);
                    //return toReturn;
                }
                catch (Exception ex)
                {
                    throw new Exception("", ex);
                }
                finally
                {
                    _mainConnection.Close();
                    //cmdToExecute.Dispose();
                    adapter.Dispose();
                }
            }
            return toReturn;            
        }
        public void selectDataN(String sql)
        {
            //DataTable toReturn = new DataTable();
            dt.Clear();
            if (initc.StatusServer.Equals("yes"))
            {
                if (initc.connectDatabaseServer.Equals("yes"))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, cMysql);
                    //SqlDataAdapter adapMainhis = new SqlDataAdapter(comMainhis);
                    try
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        //return toReturn;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("", ex);
                    }
                    finally
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Close();
                        cmd.Dispose();
                    }
                }
                else
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, _mainConnection);
                    try
                    {
                        _mainConnection.Open();
                        adapter.Fill(dt);
                        //return toReturn;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("", ex);
                    }
                    finally
                    {
                        _mainConnection.Close();
                        //cmdToExecute.Dispose();
                        adapter.Dispose();
                    }
                }
                
            }
            else
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, _mainConnection);
                try
                {
                    _mainConnection.Open();
                    adapter.Fill(dt);
                    //return toReturn;
                }
                catch (Exception ex)
                {
                    throw new Exception("", ex);
                }
                finally
                {
                    _mainConnection.Close();
                    //cmdToExecute.Dispose();
                    adapter.Dispose();
                }
            }
            //return toReturn;
        }
        public String ExecuteNonQuery(String sql)
        {
            String toReturn = "";
            if (initc.StatusServer.Equals("yes"))
            {
                if (initc.connectDatabaseServer.Equals("yes"))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, cMysql);
                    try
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Open();
                        _rowsAffected = cmd.ExecuteNonQuery();
                        toReturn = _rowsAffected.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExecuteNonQuery::Error occured.", ex);
                        toReturn = ex.Message;
                    }
                    finally
                    {
                        //_mainConnection.Close();
                        if (cMysql.State != ConnectionState.Open) cMysql.Close();
                        cmd.Dispose();
                    }
                }
                else
                {
                    OleDbCommand cmdToExecute = new OleDbCommand();
                    cmdToExecute.CommandText = sql;
                    cmdToExecute.CommandType = CommandType.Text;
                    cmdToExecute.Connection = _mainConnection;
                    try
                    {
                        _mainConnection.Open();
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        toReturn = _rowsAffected.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExecuteNonQuery::Error occured.", ex);
                        toReturn = ex.Message;
                    }
                    finally
                    {
                        _mainConnection.Close();
                        cmdToExecute.Dispose();
                    }
                }
                
            }
            else
            {
                OleDbCommand cmdToExecute = new OleDbCommand();
                cmdToExecute.CommandText = sql;
                cmdToExecute.CommandType = CommandType.Text;
                cmdToExecute.Connection = _mainConnection;
                try
                {
                    _mainConnection.Open();
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    toReturn = _rowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("ExecuteNonQuery::Error occured.", ex);
                    toReturn = ex.Message;
                }
                finally
                {
                    _mainConnection.Close();
                    cmdToExecute.Dispose();
                }
            }
            return toReturn;
        }
        public String ExecuteNonQueryNoClose(String sql)
        {
            String toReturn = "";
            if (initc.StatusServer.Equals("yes"))
            {
                if (initc.connectDatabaseServer.Equals("yes"))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, cMysql);
                    try
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Open();
                        _rowsAffected = cmd.ExecuteNonQuery();
                        toReturn = _rowsAffected.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExecuteNonQuery::Error occured.", ex);
                        toReturn = ex.Message;
                    }
                    finally
                    {
                        //_mainConnection.Close();
                        //comMainhis.Dispose();
                    }
                }
                else
                {
                    OleDbCommand cmdToExecute = new OleDbCommand();
                    cmdToExecute.CommandText = sql;
                    cmdToExecute.CommandType = CommandType.Text;
                    cmdToExecute.Connection = _mainConnection;
                    try
                    {
                        //_mainConnection.Open();
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        toReturn = _rowsAffected.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExecuteNonQuery::Error occured.", ex);
                        toReturn = ex.Message;
                    }
                    finally
                    {
                        //_mainConnection.Close();
                        //cmdToExecute.Dispose();
                    }
                }                
            }
            else
            {
                OleDbCommand cmdToExecute = new OleDbCommand();
                cmdToExecute.CommandText = sql;
                cmdToExecute.CommandType = CommandType.Text;
                cmdToExecute.Connection = _mainConnection;
                try
                {
                    //_mainConnection.Open();
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    toReturn = _rowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("ExecuteNonQuery::Error occured.", ex);
                    toReturn = ex.Message;
                }
                finally
                {
                    //_mainConnection.Close();
                    //cmdToExecute.Dispose();
                }
            }
            return toReturn;
        }
        public String OpenConnection()
        {
            String toReturn = "";
            if (initc.StatusServer.Equals("yes"))
            {
                if (initc.connectDatabaseServer.Equals("yes"))
                {
                    try
                    {
                        if (cMysql.State != ConnectionState.Open) cMysql.Open();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExecuteNonQuery::Error occured.", ex);
                        toReturn = ex.Message;
                    }
                    finally
                    {
                        //_mainConnection.Close();
                        //comMainhis.Dispose();
                    }
                }
                else
                {
                    //OleDbCommand cmdToExecute = new OleDbCommand();
                    ////cmdToExecute.CommandText = sql;
                    //cmdToExecute.CommandType = CommandType.Text;
                    //cmdToExecute.Connection = _mainConnection;
                    try
                    {
                        _mainConnection.Open();
                        //_rowsAffected = cmdToExecute.ExecuteNonQuery();
                        //toReturn = _rowsAffected.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExecuteNonQuery::Error occured.", ex);
                        toReturn = ex.Message;
                    }
                    finally
                    {
                        //_mainConnection.Close();
                        //cmdToExecute.Dispose();
                    }
                }
            }
            else
            {
                //OleDbCommand cmdToExecute = new OleDbCommand();
                ////cmdToExecute.CommandText = sql;
                //cmdToExecute.CommandType = CommandType.Text;
                //cmdToExecute.Connection = _mainConnection;
                try
                {
                    _mainConnection.Open();
                    //_rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //toReturn = _rowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("ExecuteNonQuery::Error occured.", ex);
                    toReturn = ex.Message;
                }
                finally
                {
                    //_mainConnection.Close();
                    //cmdToExecute.Dispose();
                }
            }
            return toReturn;
        }
        public void CloseConnection()
        {
            if (initc.connectDatabaseServer.Equals("yes"))
            {
                if (initc.connectDatabaseServer.Equals("yes"))
                {
                    cMysql.Close();
                }
                else
                {
                    connMainHIS.Close();
                }
                
            }
            else
            {
                connMainHIS.Close();
            }            
        }
    }
}
