using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public class dbInitializer
    {
        static bool bDBInitialized = false;
        public static string dbPath = "Data Source=IMS.db3";


        public static bool InitialDB()
        {
            if (!bDBInitialized) 
            {
                ConfigManager.InitialConfigDB();
                bDBInitialized = true;
            }
            return true;
        }

    }
}
