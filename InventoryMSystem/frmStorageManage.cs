using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace InventoryMSystemBarcode
{
    public partial class frmStorageManage : Form
    {
        StorageManageCtl ctl = new StorageManageCtl();
        bool bGettingTag = false;//是否正在获取标签

        public frmStorageManage()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmStorageManage_Shown);
            this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            this.dgvNotStoragedPInfo.CellContentClick += new DataGridViewCellEventHandler(dgvNotStoragedPInfo_CellContentClick);
            this.dgvStoragedP.CellContentClick += new DataGridViewCellEventHandler(dgvStoragedP_CellContentClick);

            this.FormClosing += new FormClosingEventHandler(frmStorageManage_FormClosing);
        }

        void frmStorageManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }

        void dgvStoragedP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRowCollection rows = this.dgvStoragedP.Rows;
                DataGridViewRow row = rows[e.RowIndex];
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((string)cbc.Value == Boolean.FalseString)
                {
                        cbc.Value = Boolean.TrueString;
                }
                else
                {
                        cbc.Value = Boolean.FalseString;
                }
            }
        }

        void dgvNotStoragedPInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
                DataGridViewRow row = rows[e.RowIndex];
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((string)cbc.Value == Boolean.FalseString)
                {
                        cbc.Value = Boolean.TrueString;
                }
                else
                {
                        cbc.Value = Boolean.FalseString;
                }
            }
        }
        void UpdateEpcList(object o)
        {
            //if (msg.status == "fail")
            //{
            //    MessageBox.Show("出现错误：" + msg.message);
            //    this.bGettingTag = false;
            //    this.btnGetTag.Text = "扫描";
            //    return;
            //}
            //string value = msg.message;
            ////把读取到的标签epc与产品的进行关联
            //Debug.WriteLine(string.Format(
            //            "UpdateEpcList -> epc = {0}"
            //            , value));
            //this.LinkEPCToProduct(value);
        }
        void LinkEPCToProduct(string epc)
        {
            DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                if (((string)cepc.Value) == epc)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.TrueString;
                    break;
                }
            }
        }
        void frmStorageManage_Shown(object sender, EventArgs e)
        {
            this.RefreshNotStoragedPInfo();
        }

        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.RefreshNotStoragedPInfo();
            }
            else
            {
                RefreshStoragedPInfo();

            }
        }
        public void RefreshStoragedPInfo()
        {
            this.cbSelectAllStoragedP.Checked = false;

            DataTable table = null;
            table = ctl.GetInStorageProductInfoTable();
            this.dgvStoragedP.DataSource = table;
            if (!this.dgvStoragedP.Columns.Contains("checkColumn"))
            {
                DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
                cc.HeaderText = "";
                cc.Name = "checkColumn";
                cc.Width = 30;
                dgvStoragedP.Columns.Insert(0, cc);
            }
            this.dgvStoragedP.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvStoragedP.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvStoragedP.Columns;
            columns[0].Width = 50;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dgvStoragedP.Width)
            {
                int leftTotalWidht = this.dgvStoragedP.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                for (int i = 1; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }

        }
        public void RefreshNotStoragedPInfo()
        {
            this.cbSelectAllNotStoragedP.Checked = false;
            DataTable table = null;

            table = ctl.GetNotInStorageProductInfoTable();
            this.dgvNotStoragedPInfo.DataSource = table;
            if (!this.dgvNotStoragedPInfo.Columns.Contains("checkColumn"))
            {
                DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
                cc.HeaderText = "";
                cc.Name = "checkColumn";
                cc.Width = 50;
                dgvNotStoragedPInfo.Columns.Insert(0, cc);
            }

            this.dgvNotStoragedPInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvNotStoragedPInfo.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvNotStoragedPInfo.Columns;
            columns[0].Width = 50;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dgvNotStoragedPInfo.Width)
            {
                int leftTotalWidht = this.dgvNotStoragedPInfo.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                for (int i = 1; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }
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

        private void btnGetTag_Click(object sender, EventArgs e)
        {
            //TODO:添加扫描条码接口


            //if (this.bGettingTag)
            //{
            //    this.bGettingTag = false;
            //    this.btnGetTag.Text = "扫描";
            //    this.operateUnitStartGetTag.closeSerialPort();
            //    this.operateUnitStopGetTag.OperateStart(true);
            //}
            //else
            //{
            //    this.bGettingTag = true;
            //    this.btnGetTag.Text = "停止";
            //    this.operateUnitStartGetTag.OperateStart();
            //}
        }
        private void btnStorageP_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                if ((string)cbc.Value == Boolean.TrueString)
                {
                    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                    string epc = (string)cepc.Value;
                    ctl.SetProductInStorage(epc);
                }
            }
            this.RefreshNotStoragedPInfo();
            /* 
            
            DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];

                if (cbc.Value != null && bool.Parse(cbc.Value.ToString()))
                {
                    Debug.WriteLine(string.Format(
                                "btnStorageP_Click -> Select Index = {0}"
                                , cbc.RowIndex.ToString()));
                }
            }
            */

        }

        private void btnDeleteStoragedP_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dgvStoragedP.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];

                if (cbc.Value != null && bool.Parse(cbc.Value.ToString()))
                {
                    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                    string epc = (string)cepc.Value;
                    ctl.SetProductNotInStorage(epc);
                    /* 
                    
                    Debug.WriteLine(string.Format(
                                "btnDeleteStoragedP_Click -> Select Index = {0}"
                                , cbc.RowIndex.ToString()));
                    */
                }
            }
            this.RefreshStoragedPInfo();
        }

        private void cbSelectAllStoragedP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbSelectAllStoragedP.Checked)
            {
                DataGridViewRowCollection rows = this.dgvStoragedP.Rows;
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.TrueString;

                }
            }
            else
            {
                DataGridViewRowCollection rows = this.dgvStoragedP.Rows;
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.FalseString;
                }
            }
        }

        private void cbSelectAllNotStoragedP_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            if (this.cbSelectAllNotStoragedP.Checked)
            {
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.TrueString;

                }
            }
            else
            {
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.FalseString;
                }
            }
        }

        private void btnRefreshNotStoragedP_Click(object sender, EventArgs e)
        {
            this.RefreshNotStoragedPInfo();
        }

        private void btnRefreshStoragedP_Click(object sender, EventArgs e)
        {
            this.RefreshStoragedPInfo();
        }

    }
}
