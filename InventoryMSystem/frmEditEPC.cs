using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace InventoryMSystemBarcode
{
    public partial class frmEditEPC : Form
    {

        EditEPCCtl ctl = new EditEPCCtl();

        List<string> categoryCodeIDList = new List<string>();
        Ean128 ean128 = new Ean128();

        // 记录当前返回写入数据成功提示时的操作意图，区分写入EPC还是密码成功
        // 0 为epc，1 为密码
        int nSingleWriteDataState = 0;
        string tagUII = string.Empty;

        public frmEditEPC()
        {
            InitializeComponent();

            this.Shown += new EventHandler(frmEditEPC_Shown);
            //this.lblSecretConfirm.Text = "";
            this.lblTip.Text = string.Empty;
            this.statusLabel.Text = "";
            //string secret = ConfigManager.GetLockMemSecret();
            //if (null == secret)
            //{
            //    secret = "12345678";
            //}
            //this.txtSecret.Text = secret;
            //this.txtSecretAgain.Text = secret;
            //this.operateUnitGetTagEpc.openSerialPort();

            this.FormClosing += new FormClosingEventHandler(frmEditEPC_FormClosing);

        }

        void frmEditEPC_Shown(object sender, EventArgs e)
        {
            ProductCategoryCtl ctlProductCategory = new ProductCategoryCtl();
            DataTable table = null;
            table = ctlProductCategory.GetCategoryTable();
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    this.comboBox1.Items.Add(dr[0].ToString());
                    this.categoryCodeIDList.Add(dr[1].ToString());
                }
            }
        }

        void frmEditEPC_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }
        void RFIDHelper_evtWriteToSerialPort(byte[] value)
        {
            //if (comport == null)
            //{
            //    return;
            //}
            //try
            //{
            //    if (!comport.IsOpen)
            //    {
            //        ConfigManager.SetSerialPort(ref comport);
            //        comport.Open();

            //    }
            //    comport.Write(value, 0, value.Length);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //try
            //{
            //    int n = comport.BytesToRead;//n为返回的字节数
            //    byte[] buf = new byte[n];//初始化buf 长度为n
            //    comport.Read(buf, 0, n);//读取返回数据并赋值到数组
            //    _RFIDHelper.Parse(buf);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        void UpdateStatus(string value)
        {
            if (this.statusLabel.InvokeRequired)
            {
                this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
            }
            else
            {
                UpdateStatusLable(value);
            }
        }

        // read tag epc
        private void button2_Click(object sender, EventArgs e)
        {

        }
        // write EPC to Tag
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ean128.Encoded_Image == null)
            {
                MessageBox.Show("尚未生成条码！");
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveTypes savetype = SaveTypes.UNSPECIFIED;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */ savetype = SaveTypes.BMP; break;
                    case 2: /* GIF */ savetype = SaveTypes.GIF; break;
                    case 3: /* JPG */ savetype = SaveTypes.JPG; break;
                    case 4: /* PNG */ savetype = SaveTypes.PNG; break;
                    case 5: /* TIFF */ savetype = SaveTypes.TIFF; break;
                    default: break;
                }//switch
                try
                {
                    ean128.SaveImage(sfd.FileName, savetype);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//if
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            this.Close();
        }

        private void txtSecretAgain_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSecret.Text == this.txtSecretAgain.Text)
            {
                this.lblSecretConfirm.Text = "密码一致";
                this.lblSecretConfirm.ForeColor = Color.Black;
                btnLockTag.Enabled = true;
            }
            else
            {
                this.lblSecretConfirm.Text = "密码不一致";
                this.lblSecretConfirm.ForeColor = Color.Red;
                btnLockTag.Enabled = false;
            }
        }

        private void btnLockTag_Click(object sender, EventArgs e)
        {
        }
        void UpdateStatusLable(string value)
        {
            this.statusLabel.Text = value;
        }

        private void btnSerialPortConfig_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            frmSerialPortConfig frm = new frmSerialPortConfig();
            frm.ShowDialog();
        }
        private void closeSerialPort()
        {
            // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
            //while (!bOk)
            //{
            //    Application.DoEvents();
            //}
        }
        private void btnSaveSecret_Click(object sender, EventArgs e)
        {
            if (this.txtSecret.Text != this.txtSecretAgain.Text)
            {
                MessageBox.Show("两次输入的密码不一致！");
                return;
            }
            string secret = "12345678";
            if (null != this.txtSecret)
            {
                secret = this.txtSecret.Text;
                secret += "00000000";
                secret = secret.Substring(0, 8);
            }
            //ConfigManager.SaveConfigItem("secret", secret);
            if (ConfigManager.SaveLockMemSecret(secret))
            {
                MessageBox.Show("密码保存成功！");
            }
            else
            {
                MessageBox.Show("密码保存失败！");
            }
        }

        private void txtSecret_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSecret.Text == this.txtSecretAgain.Text)
            {
                this.lblSecretConfirm.Text = "密码一致";
                this.lblSecretConfirm.ForeColor = Color.Black;
                this.btnLockTag.Enabled = true;
            }
            else
            {
                this.lblSecretConfirm.Text = "密码不一致";
                this.lblSecretConfirm.ForeColor = Color.Red;
                btnLockTag.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strSerial = this.txtSerialNumber.Text;
            if (!Regex.IsMatch(strSerial, "[0-9]"))
            {
                MessageBox.Show("产品序列号只能使用数字！");
                return;
            }
            if (strSerial.Length > 8)
            {
                MessageBox.Show("产品序列号使用的数字太大，最高支持8位数！");
                return;
            }
            int lenofSerial = strSerial.Length;
            strSerial = "00000000" + strSerial;
            strSerial = strSerial.Substring(lenofSerial);
            //strSerial = "21" + strSerial;//10位

            string strDate = this.dateTimePicker1.Value.ToString("yyMMdd");
            //strDate = "11" + strDate;//8位
            string strCategory = this.categoryCodeIDList[this.comboBox1.SelectedIndex].ToString();
            int len = strCategory.Length;
            strCategory = "0000" + strCategory;
            strCategory = strCategory.Substring(len);
            //strCategory = "10" + strCategory;// 6位


            int width = 400;
            int height = 100;
            List<AIData> list = new List<AIData>();
            AIData ai11 = new AIData("11", strDate);
            AIData ai10 = new AIData("10", strCategory);
            AIData ai21 = new AIData("21", strSerial);
            list.Add(ai11);
            list.Add(ai10);
            list.Add(ai21);

            this.pictureBox1.Image = ean128.getEncodeImage(list, width, height);

            string txtContent = ai11.ToString() + ai10.ToString() + ai21.ToString();
            if (this.ctl.CheckEpcExist(txtContent))
            {
                string Value = "当前EPC已经使用过，请重新指定！";
                this.lblTip.Text = Value;
            }
        }
    }
}
