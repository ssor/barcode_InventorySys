using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace InventoryMSystemBarcode
{
    public partial class frmSerialPortConfig : Form
    {
        public frmSerialPortConfig()
        {
            InitializeComponent();
        }

        private void SerialPortConfig_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cmbPortName.Items.AddRange(ports);

            LoadConfig();

        }
        void LoadConfig()
        {
            try
            {
                string portname = ConfigManager.GetItemValue("PortName");
                //string portname = ConfigManager.GetItemValue("PortName");
                if (null == portname)
                {
                    cmbPortName.SelectedIndex = -1;
                }
                else
                {

                    cmbPortName.SelectedIndex = cmbPortName.Items.IndexOf(portname);
                }
                string baudRate = ConfigManager.GetItemValue("BaudRate");
                //string baudRate = ConfigManager.GetItemValue("BaudRate");
                if (null != baudRate)
                {
                    cmbBaudRate.SelectedIndex = cmbBaudRate.Items.IndexOf(baudRate);
                }
                else
                {
                    cmbBaudRate.SelectedIndex = -1;
                }
                string parity = ConfigManager.GetItemValue("Parity");
                //string parity = ConfigManager.GetItemValue("Parity");
                if (null != parity)
                {
                    cmbParity.SelectedIndex = cmbParity.Items.IndexOf(parity);
                }else
                {
                    cmbParity.SelectedIndex = -1;
                }
                string stopbites = ConfigManager.GetItemValue("StopBits");
                //string stopbites = ConfigManager.GetItemValue("StopBits");
                if (null != stopbites)
                {
                    cmbStopBits.SelectedIndex = cmbStopBits.Items.IndexOf(stopbites);
                }else
                {
                    cmbStopBits.SelectedIndex = -1;
                }
                string databits = ConfigManager.GetItemValue("DataBits");
                //string databits = ConfigManager.GetItemValue("DataBits");
                if (null != databits)
                {
                    cmbDataBits.SelectedIndex = cmbDataBits.Items.IndexOf(databits);
                }else
                {
                    cmbDataBits.SelectedIndex = -1;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            ConfigManager.SaveSerialPortConfigurnation(cmbPortName.Text,
                                             cmbBaudRate.Text,
                                             cmbParity.Text,
                                             cmbDataBits.Text,
                                             cmbStopBits.Text);
            StaticSerialPort.resetStaticSerialPort();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
