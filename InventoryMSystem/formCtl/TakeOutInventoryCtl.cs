using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public class TakeOutInventoryCtl
    {
        string sqlSelectGetOrder =
            @"select  productName as 产品名称,productQuantity as 订购数量,
                productCount as 已扫描数量 from tbOrder;";
        string sqlSelectGetProductInfoByID =
            @"select productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productStatus = '1' and productID = @productID;";
        string sqlSelectGetProductInfoTop0 =
            @"select  productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productStatus = '99' ;";
        string sqlUpdateOutInventory =
            @"update tbProduct set productStatus = '2' where productID = @productID;";
        string sqlInsertOutInventory =
            @"insert into tbProductOutInventory(productID,productName,produceDate,productCategory,descript,OutDate)
                 select productID,productName,produceDate,productCategory,descript, @datetime from tbProduct
                  where productID = @productID";
        string sqlDeleteRemoveOrderInfo =
            @"delete from tbOrder;";


        public bool DeleteOrderInfo()
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlDeleteRemoveOrderInfo
                //                             , null).ToString());
                int result = DbOperate.ExecuteNonQuery(sqlDeleteRemoveOrderInfo
                                             , null);
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("删除数据时出现错误：" + ex.Message);
            }
            return false;
        }
        public bool InsertProductInfoIntoOutInventory(string productID, string datetime)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlInsertOutInventory
                //                             , new object[2]
                //                                    {
                //                                        datetime
                //                                        ,productID
                //                                    }).ToString());
                int result = DbOperate.ExecuteNonQuery(sqlInsertOutInventory
                                             , new object[2]
                                                    {
                                                        datetime
                                                        ,productID
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("插入数据时出现错误：" + ex.Message);
            }
            return false;
        }
        public bool ChangeProductStatusforOutInventory(string productID)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlUpdateOutInventory
                //                             , new object[1]
                //                                    {
                //                                        productID
                //                                    }).ToString());
                int result = DbOperate.ExecuteNonQuery(sqlUpdateOutInventory
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

                MessageBox.Show("删除数据时出现错误：" + ex.Message);
            }
            return false;
        }
        public DataTable GetOrderTable()
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelectGetOrder, null);
                ds = DbOperate.ExecuteDataSet(sqlSelectGetOrder);
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
        public DataTable GetProductInfoTable(string productID)
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelectGetProductInfoByID,
                //           new object[1] { productID });
                ds = DbOperate.ExecuteDataSet(sqlSelectGetProductInfoByID,
                           new object[1] { productID });
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
        public DataTable GetProductInfoTop0Table()
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelectGetProductInfoTop0,
                //           null);
                ds = DbOperate.ExecuteDataSet(sqlSelectGetProductInfoTop0);
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
