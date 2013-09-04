using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMSystem
{
    public enum SerialPortConfigItemName
    {
        //GPSSerialPortConfig = 1,
        //UHFSerialPortConfig = 2,
        //GPRSSerialPortConfig = 3,
        //WSNSerialPortConfig = 4,
        //CommonSerialPortConfig = 5,
        GPS串口设置 = 1,
        超高频RFID串口设置 = 2,
        GSM模块串口设置 = 3,
        Zigbee模块串口设置 = 4,
        常用串口设置 = 5,
        实验 = 6
    }
    /// <summary>
    /// 串口参数的内容类，对串口的参数以及必要的操作进行封装
    /// </summary>
    public class SerialPortConfigItem : ISerialPortConfigItem
    {
        string _configName;
        public string ConfigName
        {
            get { return _configName; }
            set { _configName = value; }
        }
        string _spName;
        public string SpName
        {
            get { return _spName; }
            set { _spName = value; }
        }
        string _spBaudRate;
        public string SpBaudRate
        {
            get { return _spBaudRate; }
            set { _spBaudRate = value; }
        }
        string _spDataBits;
        public string SpDataBits
        {
            get { return _spDataBits; }
            set { _spDataBits = value; }
        }
        string _spStopBits;
        public string SpStopBits
        {
            get { return _spStopBits; }
            set { _spStopBits = value; }
        }
        string _spParity;
        public string SpParity
        {
            get { return _spParity; }
            set { _spParity = value; }
        }
        public string GetItemValue(string itemName)
        {
            string strR = null;
            if (itemName == "PortName")
            {
                strR = this._spName;
                return strR;
            }
            if (itemName == "BaudRate")
            {
                strR = this._spBaudRate;
                return strR;
            }
            if (itemName == "Parity")
            {
                strR = this._spParity;
                return strR;
            }
            if (itemName == "StopBits")
            {
                strR = this._spStopBits;
                return strR;
            }
            if (itemName == "DataBits")
            {
                strR = this._spDataBits;
                return strR;
            }
            return strR;
        }
        //void SaveConfigItem()
        //{
        //    ConfigManager.SaveSerialPortConfigurnation(this);
        //}
        public void SaveConfigItem(
                   string portName, string baudRate,
                   string parity, string dataBits, string stopBits)
        {
            this.SpName = portName;
            this.SpBaudRate = baudRate;
            this.SpParity = parity;
            this.SpDataBits = dataBits;
            this.SpStopBits = stopBits;
            ConfigManager.SaveSerialPortConfigurnation(this);
        }
        public SerialPortConfigItem(string name, string spName, string spBaudRate
                                , string spDataBits, string spStopBits, string spParity)
        {
            this._configName = name;
            this._spName = spName;
            this._spBaudRate = spBaudRate;
            this._spDataBits = spDataBits;
            this._spStopBits = spStopBits;
            this._spParity = spParity;
        }
        public SerialPortConfigItem(string name)
        {
            this._configName = name;
        }
        public string toString()
        {
            string strR = null;
            strR = string.Format(@"name = {0},spName = {1},BaudRate = {2} Databit = {3} 
                                    Stopbit = {4} Parity = {5}",
                                  this._configName, this._spName, this._spBaudRate
                                  , this._spDataBits, this._spStopBits, this._spParity);
            return strR;
        }
        public static SerialPortConfigItem GetConfigItem(SerialPortConfigItemName itemName)
        {
            SerialPortConfigItem spci = null;
            string name = Enum.GetName(typeof(SerialPortConfigItemName)
                                    , itemName);
            spci = new SerialPortConfigItem(name);
            ConfigManager.SetSerialPortConfigurnation(ref spci);
            return spci;
        }
        //public static SerialPortConfigItem GetGPSConfigItem()
        //{
        //    SerialPortConfigItem spci = null;
        //    string name = Enum.GetName(typeof(SerialPortConfigItemName)
        //                            , SerialPortConfigItemName.GPSSerialPortConfig);
        //    spci = new SerialPortConfigItem(name);
        //    ConfigManager.SetSerialPortConfigurnation(ref spci);
        //    return spci;
        //}
        //public static SerialPortConfigItem GetWSNConfigItem()
        //{
        //    SerialPortConfigItem spci = null;
        //    string name = Enum.GetName(typeof(SerialPortConfigItemName)
        //                            , SerialPortConfigItemName.WSNSerialPortConfig);
        //    spci = new SerialPortConfigItem(name);
        //    ConfigManager.SetSerialPortConfigurnation(ref spci);
        //    return spci;
        //}

    }
}
