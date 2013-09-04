using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public class ctlProductName
    {
        string sqlSelectGetProductName =
            @"select productName from tbProductName;";


        public DataTable GetProductName()
        {
            DataSet ds = null;
            try
            {
                ds = SQLiteHelper.ExecuteDataSet(
                          ConfigManager.GetDBConnectString(ConfigManager.GetCurrentDBType()),
                           sqlSelectGetProductName, null);
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
                MessageBox.Show("获取产品名称时出现错误：" + ex.Message);
            }
            return null;
        }
    }
}
