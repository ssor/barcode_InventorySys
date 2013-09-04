using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace InventoryMSystemBarcode
{
    public enum DBType
    {
        sqlite,sqlserver
    }
    /// <summary>
    /// 提取，更新，设置各个设置选项
    /// </summary>
    public class ConfigManager
    {
        static string tableConfigExist =
            @"SELECT count(*) FROM sqlite_master where type = 'table' and tbl_name = 'tbConfig'";
        static string tableConfigCreate =
            @"CREATE TABLE tbConfig(key varchar(20) primary key
                                    ,value varchar(100) );";
        static string SqlSelectItem =
            @"SELECT value FROM tbConfig where key = @key;";
        static string SqlInsertItem =
            @"insert into tbConfig(key,value) values(@key,@value);";
        static string SqlUpdateItem =
            @"update tbConfig set value = @value where key = @key";

        public static bool InitialConfigDB()
        {
            try
            {
                int result = 0;
                result = int.Parse(SQLiteHelper.ExecuteScalar(dbInitializer.dbPath, tableConfigExist, null).ToString());
                if (!(result >= 1))
                {
                    result = int.Parse(SQLiteHelper.ExecuteScalar(dbInitializer.dbPath, tableConfigCreate, null).ToString());
                    if (result == 0)
                    {
                        //MessageBox.Show("Create table success");
                    }
                    else
                    {
                        MessageBox.Show("初始化数据库时出现错误！");
                        return false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("初始化数据库时出现错误！" + ex.Message);
                return false;
            }
            return true;
        }
        public static void SetSerialPort(ref SerialPort sp)
        {
            try
            {
                sp.PortName = ConfigManager.GetItemValue("PortName");
                sp.BaudRate = int.Parse(ConfigManager.GetItemValue("BaudRate"));
                sp.DataBits = int.Parse(ConfigManager.GetItemValue("DataBits"));
                sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigManager.GetItemValue("StopBits"));
                sp.Parity = (Parity)Enum.Parse(typeof(Parity), ConfigManager.GetItemValue("Parity"));

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
            }
        }
        /// <summary>
        /// 获取当前使用的数据库类型
        /// </summary>
        /// <returns>sqlite sqlserver</returns>
        public static DBType GetCurrentDBType()
        {
            string dbType = null;
            dbType =ConfigManager.GetItemValue("dbType");
            if (null == dbType || dbType == string.Empty)
            {
                dbType = DBType.sqlite.ToString();
                SaveConfigItem("dbType", dbType);
            }
            return (DBType)Enum.Parse(typeof(DBType),dbType);
        }
        public static bool SaveCurrentDBType(DBType dbType)
        {
            return SaveConfigItem("dbType", dbType.ToString());
        }
        public static bool SaveDBConnectString(DBType dbtype,string connectString)
        {
            return SaveConfigItem(dbtype.ToString(), connectString);
        }
        public static string GetDBConnectString(DBType dbtype)
        {
            string connStr = null;
            connStr = GetItemValue(dbtype.ToString());
            if (connStr == null || connStr == string.Empty)
            {
                connStr = string.Empty;
            }
            return connStr;
        }
        public static string GetLockMemSecret()
        {
            string strR = null;
            string secret =ConfigManager.GetItemValue("secret");
            //if (null != secret)
            //{
            //    strR = Encrypter.GetDecryptString(secret, Encrypter.PublicEncryptKey);
            //}
            return strR;
        }
        public static bool SaveLockMemSecret(string secret)
        {
            //if (null != secret)
            //{
            //    string encryptSecret = Encrypter.GetEncryptString(secret, Encrypter.PublicEncryptKey);
            //    return SaveConfigItem("secret", encryptSecret);
            //}
            return false;
        }
 
        public static void SaveSerialPortConfigurnation(string portName,string baudRate,string parity,string dataBits,string stopBits)
        {
            try
            {
                if (portName != null)
                {
                    SaveConfigItem("PortName", portName);
                }
                if (baudRate != null)
                {
                    SaveConfigItem("BaudRate", baudRate);
                }
                if (parity != null)
                {
                    SaveConfigItem("Parity", parity);
                }
                if (dataBits != null)
                {
                    SaveConfigItem("DataBits", dataBits);
                }
                if (stopBits != null)
                {
                    SaveConfigItem("StopBits", stopBits);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
            }
        }
        public static bool SaveConfigItem(string itemName,string value)
        {
            bool bR = false;
            DataSet dsAppSettings = new DataSet();
            try
            {
                if (dbInitializer.InitialDB())
                {
                    object returnO = null;
                    returnO = SQLiteHelper.ExecuteScalar(dbInitializer.dbPath, SqlSelectItem
                                                           , new object[1] { itemName });
                    if (returnO != null)
                    {
                        // update
                        SQLiteHelper.ExecuteScalar(dbInitializer.dbPath, SqlUpdateItem
                                                    , new object[2]
                                                    {
                                                        value,
                                                        itemName
                                                    });
                    }
                    else
                    {
                        SQLiteHelper.ExecuteScalar(dbInitializer.dbPath, SqlInsertItem
                                                    , new object[2]
                                                    {
                                                        itemName
                                                        ,value
                                                    });
                    }
                }
                bR = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
                bR = false;
            }
            return bR;
        }
   
        public static string GetItemValue(string itemName)
        {
            if (itemName == null)
            {
                return null;
            }
            string strValue = string.Empty;
            DataSet dsAppSettings = new DataSet();
            try
            {
                if (dbInitializer.InitialDB())
                {

                    strValue = (string)SQLiteHelper.ExecuteScalar(
                                                dbInitializer.dbPath, SqlSelectItem
                                                , new object[1] { itemName });
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
            }
            return strValue;
        }
    }
}
