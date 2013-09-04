using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public partial class frmTakeOutInventory : Form
    {
        TakeOutInventoryCtl ctlTakeOutInventory = new TakeOutInventoryCtl();

        bool bGettingTag = false;//是否正在获取标签

        public frmTakeOutInventory()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(frmTakeOutInventory_FormClosing);
            this.Shown += new EventHandler(frmTakeOutInventory_Shown);

        }

        void frmTakeOutInventory_Shown(object sender, EventArgs e)
        {
            this.refreshDGVOrder();
            this.refreshDGVProductDetail();
        }
        void refreshDGVOrder()
        {
            DataTable dt = ctlTakeOutInventory.GetOrderTable();
            this.dgvTakenOutP.DataSource = dt;

            this.dgvTakenOutP.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvTakenOutP.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvTakenOutP.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvTakenOutP.Width)
                {
                    int leftTotalWidht = this.dgvTakenOutP.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
        }
        void refreshDGVProductDetail()
        {
            DataTable dt = ctlTakeOutInventory.GetProductInfoTop0Table();
            this.dgvDetailProductsInfo.DataSource = dt;

            this.dgvDetailProductsInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvDetailProductsInfo.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvDetailProductsInfo.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvDetailProductsInfo.Width)
                {
                    int leftTotalWidht = this.dgvDetailProductsInfo.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
        }
        void frmTakeOutInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }
        void UpdateEpcList(object o)
        {
            //if (msg.status == "fail")
            //{
            //    MessageBox.Show("出现错误：" + msg.message);
            //    this.bGettingTag = false;
            //    this.btnGetP.Text = "扫描";
            //    return;
            //}
            //string value = msg.message;
            ////把读取到的标签epc与产品的进行关联
            //if (this.dgvDetailProductsInfo.InvokeRequired)
            //{
            //    this.dgvDetailProductsInfo.Invoke(new deleUpdateContorl(LinkEPCToProduct), value);
            //}
            //else
            //    this.LinkEPCToProduct(value);
        }
        void LinkEPCToProduct(string epc)
        {

            DataTable dt1 = ctlTakeOutInventory.GetProductInfoTable(epc);
            if (dt1.Rows.Count > 0)
            {
                //将具体的产品信息添加到详细列表里面
                if (this.dgvDetailProductsInfo.DataSource != null)
                {
                    DataTable dt = (DataTable)this.dgvDetailProductsInfo.DataSource;

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
                        //检查该产品在出库单中是否已经足够，数量足够的话不需要再添加
                        bool bEnough = false;
                        string productName = dt1.Rows[0].ItemArray[1].ToString();
                        DataTable dtOrder = (DataTable)this.dgvTakenOutP.DataSource;
                        int quantityOrdered = -1;
                        int quantityNow = -1;
                        DataRow drOrderProduct = null;
                        if (dtOrder != null)
                        {
                            foreach (DataRow dr in dtOrder.Rows)
                            {
                                if (dr[0].ToString() == productName)
                                {
                                    drOrderProduct = dr;
                                    break;
                                }
                            }
                            try
                            {
                                quantityOrdered = int.Parse(drOrderProduct[1].ToString());
                                quantityNow = int.Parse(drOrderProduct[2].ToString());
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show("程序异常：" + ex.Message);
                                return;
                            }
                        }
                        if (quantityNow > -1 && quantityOrdered > -1)
                        {
                            if (quantityNow >= quantityOrdered)
                            {
                                bEnough = true;
                            }
                        }
                        if (!bEnough)
                        {
                            if (null != drOrderProduct)
                            {
                                drOrderProduct[2] = (++quantityNow).ToString();
                            }
                            DataRow dr = dt.NewRow();
                            dr.ItemArray = dt1.Rows[0].ItemArray;
                            dt.Rows.Add(dr);

                            if (this.CheckAllOrderEnough())
                            {
                                this.btnStartCheck.Enabled = true;
                            }
                        }

                    }
                }
            }
            //DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            //foreach (DataGridViewRow vr in rows)
            //{
            //    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
            //    if (((string)cepc.Value) == epc)
            //    {
            //        DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
            //        cbc.Value = Boolean.TrueString;
            //        break;
            //    }
            //}
        }
        bool CheckAllOrderEnough()
        {
            bool bEnough = true;
            DataTable dt = (DataTable)this.dgvTakenOutP.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                int quantityOrdered = -1;
                int quantityNow = -1;
                try
                {
                    quantityNow = int.Parse(dr[2].ToString());
                    quantityOrdered = int.Parse(dr[1].ToString());
                    if (quantityOrdered > quantityNow)
                    {
                        bEnough = false;
                        break;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("程序异常：" + ex.Message);
                }
            }
            return bEnough;
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
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            this.Close();
        }

        private void btnGetP_Click(object sender, EventArgs e)
        {
            //TODO:添加扫描条码接口
            
            
            //if (this.bGettingTag)
            //{
            //    this.bGettingTag = false;
            //    this.btnGetP.Text = "扫描";
            //    this.operateUnitStartGetTag.closeSerialPort();
            //    this.operateUnitStopGetTag.OperateStart(true);
            //}
            //else
            //{
            //    this.bGettingTag = true;
            //    this.btnGetP.Text = "停止";
            //    this.operateUnitStartGetTag.OperateStart();
            //}
        }

        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            DataTable dt = (DataTable)this.dgvDetailProductsInfo.DataSource;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string productID = dr[0].ToString();
                    this.ctlTakeOutInventory.InsertProductInfoIntoOutInventory(productID, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    this.ctlTakeOutInventory.ChangeProductStatusforOutInventory(productID);
                }
            }
            this.ctlTakeOutInventory.DeleteOrderInfo();
            this.frmTakeOutInventory_Shown(null, null);
        }
    }
}
