using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace InventoryMSystemBarcode
{
    public class InventoryCtl
    {
        string sqlSelectGetProductInfoTop0 =
            @"select  productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productStatus = '99' ;";
        string sqlSelectGetProductInfoByID =
    @"select productID as 产品编号,productName as 产品名称,produceDate as 生产日期
                ,productCategory as 产品类别,descript 产品备注信息 from tbProduct where 
                productID = @productID;";



        public DataTable GetProductInfoTable(string productID)
        {
            DataSet ds = null;
            try
            {
                //ds = SQLiteHelper.ExecuteDataSet(
                //          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                //           sqlSelectGetProductInfoByID,
                //           new object[1] { productID });
                ds = DbOperate.ExecuteDataSet(sqlSelectGetProductInfoByID, new object[1] { productID });

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
