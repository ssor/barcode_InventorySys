using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace InventoryMSystemBarcode
{
    public class DbOperate
    {
        public static DataSet ExecuteDataSet(string commandText, params object[] paramList)
        {
            DataSet ds = null;
            int dbtype = (int)ConfigManager.GetCurrentDBType();
            string connectionString = ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType());
            switch (dbtype)
            {
                case (int)DBType.sqlite:
                    ds = SQLiteHelper.ExecuteDataSet(connectionString, commandText, paramList);
                    break;
                case (int)DBType.sqlserver:
                    ds = SqlHelper.ExecuteDatasetText(connectionString, commandText, paramList);
                    break;
            }

            return ds;
        }
        public static int ExecuteScalar(string commandText, params object[] paramList)
        {
            DataSet ds = null;
            int result = -1;
            int dbtype = (int)ConfigManager.GetCurrentDBType();
            string connectionString = ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType());
            switch (dbtype)
            {
                case (int)DBType.sqlite:
                    result = int.Parse(
                                SQLiteHelper.ExecuteScalar(
                                            connectionString,
                                            commandText,
                                            paramList).ToString());
                    break;
                case (int)DBType.sqlserver:
                    result = int.Parse(
                            SqlHelper.ExecuteScalar(connectionString, commandText, paramList).ToString());
                    break;
            }

            return result;
        }
        public static int ExecuteNonQuery(string commandText, params object[] paramList)
        {
            DataSet ds = null;
            int result = -1;
            int dbtype = (int)ConfigManager.GetCurrentDBType();
            string connectionString = ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType());
            switch (dbtype)
            {
                case (int)DBType.sqlite:
                    result = int.Parse(
                                SQLiteHelper.ExecuteNonQuery(
                                            connectionString,
                                            commandText,
                                            paramList).ToString());
                    break;
                case (int)DBType.sqlserver:
                    result = int.Parse(
                            SqlHelper.ExecuteNonQuery(connectionString, commandText, paramList).ToString());
                    break;
            }

            return result;
        }

    }
}
