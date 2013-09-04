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
    public partial class frmProductManage : Form, IRefreshDGV
    {
        //RFIDHelper _RFIDHelper = new RFIDHelper();
        //SerialPort comport = new SerialPort();
        string tagUII = string.Empty;
        productManageCtl ctl = new productManageCtl();

        ctlProductName ctlProductName = new ctlProductName();
        public frmProductManage()
        {
            InitializeComponent();
            DataTable dt = ctlProductName.GetProductName();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.cmbName.Items.Add(dr[0].ToString());
                }
            }


            //this.operateUnit.registeCallback(new deleRfidOperateCallback(UpdateStatus));
            //this.operateUnit.openSerialPort();

            this.dateTimePicker1.Value = DateTime.Now;
            this.FormClosing += new FormClosingEventHandler(frmProductManage_FormClosing);
            this.Shown += new EventHandler(frmProductManage_Shown);
            //comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //使得Helper类可以向串口中写入数据
            //_RFIDHelper.evtWriteToSerialPort += new deleVoid_Byte_Func(RFIDHelper_evtWriteToSerialPort);
            // 处理当前操作的状态
            //_RFIDHelper.evtCardState += new deleVoid_RFIDEventType_Object_Func(_RFIDHelper_evtCardState);

        }

        void frmProductManage_Shown(object sender, EventArgs e)
        {
            ProductCategoryCtl ctlProductCategory = new ProductCategoryCtl();
            DataTable table = null;
            table = ctlProductCategory.GetCategoryTable();
            if (table!=null&&table.Rows.Count>0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    this.cmbFactory.Items.Add(dr[0]);
                }
            }
            this.refreshDGV();
        }

        void frmProductManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            /* 
            
            bool bOk = false;
            if (null != comport)
            {
                if (comport.IsOpen)
                {
                    bOk = _UpdateList.ChekcAllItem();
                    // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
                    while (!bOk)
                    {
                        Application.DoEvents();
                        bOk = _UpdateList.ChekcAllItem();
                    }
                    comport.Close();
                }
            }
            */
            this.Close();
        }

        private void btnGetPID_Click(object sender, EventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //this.txtPID.Text = dt.ToString("yyyyMMddHHmmssff");
            //this.operateUnit.OperateStart();
            //_RFIDHelper.StartCallback();
            //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_GetStatus, RFIDEventType.RMU_CardIsReady);

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
        void UpdateStatus(object o)
        {
            //operateMessage msg = (operateMessage)o;
            //if (msg.status == "fail")
            //{
            //    MessageBox.Show("出现错误：" + msg.message);
            //    return;
            //}
            //string value = msg.message;
            //if (this.statusLabel.InvokeRequired)
            //{
            //    this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
            //}
            //else
            //{
            //    UpdateStatusLable(value);
            //}
        }
        void UpdateStatusLable(string value)
        {
            this.txtPID.Text = value;
            //this.statusLabel.Text = value;
        }
        void UpdateEPCtxtBox(string value)
        {


            this.txtPID.Text = value;

        }

        private void btnSerialPortConf_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            frmSerialPortConfig frm = new frmSerialPortConfig();
            frm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductManageAdd frmAdd = new frmProductManageAdd(this);
            frmAdd.ShowDialog();
        }
        private void closeSerialPort()
        {
            // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
            //while (!bOk)
            {
                Application.DoEvents();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void refreshDGV()
        {

            this.dataGridView1.DataSource = ctl.GetProductInfoTable();

            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dataGridView1.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dataGridView1.Width)
                {
                    int leftTotalWidht = this.dataGridView1.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cmbName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择产品名称！");
                return;
            }
            if (ctl.UpdateProductItem(this.txtPID.Text, this.cmbName.Text,
                                    this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.cmbFactory.Text,
                                    this.txtComment.Text))
            {
                MessageBox.Show("更新产品信息成功！");
                this.refreshDGV();
            }
            else
            {
                MessageBox.Show("更新产品信息出错！");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ctl.DeleteProductItem(this.txtPID.Text))
            {
                MessageBox.Show("删除产品信息成功！");
                this.refreshDGV();
            }
            else
            {
                MessageBox.Show("删除产品信息出错！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.refreshDGV();
        }

        void SetLabelContent()
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb != null && tb.Rows.Count > 0)
            {
                txtPID.Text = tb.Rows[0][0].ToString();
                this.cmbName.Text = tb.Rows[0][1].ToString();
                try
                {
                    this.dateTimePicker1.Value = DateTime.Parse(tb.Rows[0][2].ToString());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.cmbFactory.Text = tb.Rows[0][3].ToString();
                this.txtComment.Text = tb.Rows[0][4].ToString();
            }
            else
            {
                txtPID.Text = null;
                cmbName.Text = null;
                this.dateTimePicker1.Value = DateTime.Now;
                cmbFactory.Text = null;
                txtComment.Text = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                txtPID.Text = tb.Rows[e.RowIndex][0].ToString();
                //this.cmbName.Text = tb.Rows[e.RowIndex][1].ToString();
                this.cmbName.SelectedIndex = this.cmbName.Items.IndexOf(tb.Rows[e.RowIndex][1].ToString());
                try
                {
                    this.dateTimePicker1.Value = DateTime.Parse(tb.Rows[e.RowIndex][2].ToString());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.cmbFactory.Text = tb.Rows[e.RowIndex][3].ToString();
                this.txtComment.Text = tb.Rows[e.RowIndex][4].ToString();
            }
        }
    }
}
