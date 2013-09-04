using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace InventoryMSystemBarcode
{
    public class SQLConnConfig
    {

        public bool testConnection()
        {
            string connStr = string.Empty;
            switch ((int)ConfigManager.GetCurrentDBType())
            {
                case (int)DBType.sqlite:
                    connStr = ConfigManager.GetDBConnectString(DBType.sqlite);
                    if (connStr != string.Empty)
                    {
                        SQLiteConnection cn = new SQLiteConnection(connStr);
                        try
                        {
                            cn.Open();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                        finally
                        {

                            cn.Close();
                        }
                    }
                    break;
                case (int)DBType.sqlserver:
                    SqlConnection conn = new SqlConnection();
                    try
                    {
                        
                        conn.ConnectionString = connStr;
                        conn.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    break;
            }
            return false;
        }
    }
}
