using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public partial class frmInventory : Form
    {
        InventoryCtl ctlInventory = new InventoryCtl();

        bool bGettingTag = false;//是否正在获取标签


        public frmInventory()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmInventory_Shown);
            this.FormClosing += new FormClosingEventHandler(frmInventory_FormClosing);
        }

        void frmInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }
        void UpdateEpcList(object o)
        {
            //operateMessage msg = (operateMessage)o;
            //if (msg.status == "fail")
            //{
            //    MessageBox.Show("出现错误：" + msg.message);
            //    this.bGettingTag = false;
            //    this.btnScan.Text = "扫描";
            //    return;
            //}
            //string value = msg.message;
            ////把读取到的标签epc与产品的进行关联
            //if (this.dgvProductInfo.InvokeRequired)
            //{
            //    this.dgvProductInfo.Invoke(new deleUpdateContorl(LinkEPCToProduct), value);
            //}
            //else
            //    this.LinkEPCToProduct(value);
        }
        void LinkEPCToProduct(string epc)
        {

            DataTable dt1 = ctlInventory.GetProductInfoTable(epc);
            if (dt1.Rows.Count > 0)
            {
                //将具体的产品信息添加到详细列表里面
                if (this.dgvProductInfo.DataSource != null)
                {
                    DataTable dt = (DataTable)this.dgvProductInfo.DataSource;

                    //首先检查该产品是否已经扫描过
                    bool alreadyAdded = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr.ItemArray[0].ToString() == epc)
                        {
                            alreadyAdded = true;
                            break;
                        }
                    }
                    //如果尚未扫描过
                    if (!alreadyAdded)
                    {
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = dt1.Rows[0].ItemArray;
                        dt.Rows.Add(dr);
                    }
                }
            }

        }
        void frmInventory_Shown(object sender, EventArgs e)
        {
            this.refreshDGVProductDetail();
        }
        void refreshDGVProductDetail()
        {
            DataTable dt = ctlInventory.GetProductInfoTop0Table();
            this.dgvProductInfo.DataSource = dt;

            this.dgvProductInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvProductInfo.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvProductInfo.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvProductInfo.Width)
                {
                    int leftTotalWidht = this.dgvProductInfo.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            this.Close();
        }
        private void closeSerialPort()
        {
            //this.operateUnitStartGetTag.closeSerialPort();
            //bool bOk = _UpdateList.ChekcAllItem();
            //// 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
            //while (!bOk)
            //{
            //    Application.DoEvents();
            //    bOk = _UpdateList.ChekcAllItem();
            //}
            //if (this.bGettingTag)
            //{
            //    this.operateUnitStopGetTag.OperateStart(true);
            //}
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            //TODO:添加扫描条码接口


            //if (this.bGettingTag)
            //{
            //    this.bGettingTag = false;
            //    this.btnScan.Text = "扫描";
            //    this.operateUnitStartGetTag.closeSerialPort();
            //    this.operateUnitStopGetTag.OperateStart(true);
            //}
            //else
            //{
            //    this.bGettingTag = true;
            //    this.btnScan.Text = "停止";
            //    this.operateUnitStartGetTag.OperateStart();
            //}
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            //if (this.bGettingTag)
            //{
            //    this.bGettingTag = false;
            //    this.btnScan.Text = "扫描";
            //    this.operateUnitStartGetTag.closeSerialPort();
            //    this.operateUnitStopGetTag.OperateStart(true);
            //}
            List<Epc> list = new List<Epc>();
            //将具体的产品信息添加到详细列表里面
            if (this.dgvProductInfo.DataSource != null)
            {
                DataTable dt = (DataTable)this.dgvProductInfo.DataSource;

                foreach (DataRow dr in dt.Rows)
                {
                    Epc epc = new Epc(dr[0].ToString());
                    list.Add(epc);
                }
            }
            frmInventoryResult frm = new frmInventoryResult(list);
            frm.ShowDialog();

        }
    }
}
