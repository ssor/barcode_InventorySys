using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LogisTechBase
{
    public interface IProcessItem
    {
         List<string> GetItemNames();
         string GetItemText(string itemName);
         List<string> GetKeywords();
         List<string> GetStrings();
    }
}
