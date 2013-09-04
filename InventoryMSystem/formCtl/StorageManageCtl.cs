using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public class StorageManageCtl
    {

        string sqlSelectNotInStorage =
                @"select productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productStatus = '0';";
        string sqlSelectInStorage =
        @"select productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productStatus = '1';";
        string sqlUpdateChangeStorageStatusToInStorage =
            @"update tbProduct set productStatus = '1' where productID = @productID;";
        string sqlUpdateChangeStorageStatusToNotInStorage=
            @"update tbProduct set productStatus = '0' where productStatus = '1' and
                productID = @productID;";

        public bool SetProductNotInStorage(string productID)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlUpdateChangeStorageStatusToNotInStorage
                //                             , new object[1]
                //                                    {
                //                                        productID
                //                                    }).ToString());
                int result = DbOperate.ExecuteNonQuery(sqlUpdateChangeStorageStatusToNotInStorage
                                             , new object[1]
                                                    {
                                                        productID
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("取消入库时出现错误：" + ex.Message);
            }
            return false;
        }

        public bool SetProductInStorage(string productID)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlUpdateChangeStorageStatusToInStorage
                //                             , new object[1]
                //                                    {
                //                                        productID
                //                                    }).ToString());
                int result = DbOperate.ExecuteNonQuery(sqlUpdateChangeStorageStatusToInStorage
                                             , new object[1]
                                                    {
                                                        productID
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("入库时出现错误：" + ex.Message);
            }
            return false;
        }
        public DataTable GetInStorageProductInfoTable()
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelectInStorage, null);
                ds = DbOperate.ExecuteDataSet(sqlSelectInStorage);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("查询数据库时出现错误：" + ex.Message);
            }
            return null;
        }
        public DataTable GetNotInStorageProductInfoTable()
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelectNotInStorage, null);
                ds = DbOperate.ExecuteDataSet(sqlSelectNotInStorage);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("查询数据库时出现错误：" + ex.Message);
            }
            return null;
        }
    }
}
