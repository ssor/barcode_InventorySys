using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace InventoryMSystemBarcode
{
    public class productManageCtl
    {
        // productStatus = 0 表示产品尚未入库
        // productStatus = 1 表示产品已入库
        // productStatus = 2 表示产品已出库


        string SqlInsertItem =
    @"insert into tbProduct(productID,productName,produceDate,productCategory,descript)
     values(@productID,@productName,@produceDate,@productCategory,@descript);";

        string sqlSelect =
            @"select productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productStatus = '0';";
        string sqlUpdate =
            @"update tbProduct set productName = @productName,produceDate = @produceDate
                ,productCategory = @productCategory,descript = @descript
                where productID = @productID; ";
        string sqlDelete =
            @"delete from tbProduct where productID = @productID ;";

        public DataTable GetProductInfoTable()
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelect, null);
                ds = DbOperate.ExecuteDataSet(sqlSelect);

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
        public bool UpdateProductItem(string productID, string productName
                                    , string produceDate, string productCategory
                                    , string descript)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlUpdate
                //                             , new object[5]
                //                                    {
                //                                        productName
                //                                        ,produceDate
                //                                        ,productCategory
                //                                        ,descript
                //                                        ,productID
                //                                    }).ToString());

                int result = DbOperate.ExecuteNonQuery(sqlUpdate
                                             , new object[5]
                                                    {
                                                        productName
                                                        ,produceDate
                                                        ,productCategory
                                                        ,descript
                                                        ,productID
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("更新数据时出现错误：" + ex.Message);
            }
            return false;
        }
        public bool AddProductItem(string productID, string productName
                                    , string produceDate, string productCategory
                                    , string descript)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             SqlInsertItem
                //                             , new object[5]
                //                                    {
                //                                        productID
                //                                        ,productName
                //                                        ,produceDate
                //                                        ,productCategory
                //                                        ,descript
                //                                    }).ToString());
                int result = DbOperate.ExecuteNonQuery(SqlInsertItem
                             , new object[5]
                                                    {
                                                        productID
                                                        ,productName
                                                        ,produceDate
                                                        ,productCategory
                                                        ,descript
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("添加数据时出现错误：" + ex.Message);
            }
            return false;
        }
        public bool DeleteProductItem(string productID)
        {
            try
            {
                //int result = int.Parse(SQLiteHelper.ExecuteNonQuery(ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //                             sqlDelete
                //                             , new object[1]
                //                                    {
                //                                        productID
                //                                    }).ToString());
                int result = DbOperate.ExecuteNonQuery(sqlDelete
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
    }
}
