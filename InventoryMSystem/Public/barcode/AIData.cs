using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMSystemBarcode
{
    public class AIData
    {
        public string AI = string.Empty;
        public string Data = string.Empty;
        string encodedData = string.Empty;

        public string EncodedData
        {
            get { return encodedData; }
            set { encodedData = value; }
        }



        public AIData(string ai, string data)
        {
            this.AI = ai;
            this.Data = data;
        }
        public override string ToString()
        {
            return this.AI + this.Data;
        }
    }
}
