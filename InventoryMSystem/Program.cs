using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm = new Form1();
            //SQLConnConfig config = new SQLConnConfig();
            //if (config.testConnection())
            //{

            //}
            //else
            //{
            //    frm.SetMenuItemsEnableStatus(false);
            //    frm.SetMsg("提示：数据库配置错误！");
            //}

            Application.Run(frm);
        }
    }
}
