using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public class ProductCategoryCtl
    {
        string sqlSelectCategoryItems =
            @"select categoryName as 类别名称,codeID as 编码 from tbProductCategory;";
        string sqlInsertAddCategoryItem =
            @"insert into tbProductCategory(categoryName,codeID) values(@categoryName,@codeID);";
        string sqlDeleteDeleteCategoryItem =
            @"delete from tbProductCategory where categoryName = @categoryName;";

        public bool DeleteCategoryItem(string category)
        {
            try
            {
                int result = DbOperate.ExecuteNonQuery(sqlDeleteDeleteCategoryItem
                                             , new object[1]
                                                    {
                                                        category
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("删除产品类别项时出现错误：" + ex.Message);
            }
            return false;
        }

        public bool AddCategoryItem(string category,string codeID)
        {
            try
            {
                int result = DbOperate.ExecuteNonQuery(sqlInsertAddCategoryItem
                                             , new object[2]
                                                    {
                                                         category
                                                         ,codeID
                                                    });
                if (result > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("添加产品类别项时出现错误：" + ex.Message);
            }
            return false;
        }

        public DataTable GetCategoryTable()
        {
            DataSet ds = null;
            try
            {
                ds = DbOperate.ExecuteDataSet(sqlSelectCategoryItems);
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
                MessageBox.Show("查询产品类别时出现错误：" + ex.Message);
            }
            return null;
        }
    }
}
