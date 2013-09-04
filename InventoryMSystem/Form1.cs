using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.lblMsg.Text = string.Empty;
        }
        public void SetMsg(string msg)
        {
            this.lblMsg.Text = msg;
        }
        public void SetMenuItemsEnableStatus(bool bFlag)
        {
            this.仓库管理ToolStripMenuItem.Enabled = bFlag;
            this.订单管理ToolStripMenuItem.Enabled = bFlag;
            this.设置ToolStripMenuItem.Enabled = bFlag;
            this.仓库管理ToolStripMenuItem.Enabled = bFlag;
            this.仓库管理ToolStripMenuItem.Enabled = bFlag;
            this.仓库管理ToolStripMenuItem.Enabled = bFlag;

        }
#region button_click

        private void button1_Click(object sender, EventArgs e)
        {
            frmProductManage frmPM = new frmProductManage();
            frmPM.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStorageManage frmSM = new frmStorageManage();
            frmSM.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNewOrder frmNO = new frmNewOrder();
            frmNO.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmInventory frmI = new frmInventory();
            frmI.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTakeOutInventory frmTOI = new frmTakeOutInventory();
            frmTOI.ShowDialog();
        }

        private void btnProduceCodeBar_Click(object sender, EventArgs e)
        {
            frmBarCodeProduce frmBCP = new frmBarCodeProduce();
            frmBCP.ShowDialog();
        }

        private void btnSerialPortConf_Click(object sender, EventArgs e)
        {
            frmSerialPortConfig frm = new frmSerialPortConfig();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmEditEPC frm = new frmEditEPC();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmSQLConfig frm = new frmSQLConfig();
            frm.ShowDialog();
        }
#endregion

        private void 产品贴标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditEPC frm = new frmEditEPC();
            frm.ShowDialog();
        }

        private void 产品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStorageManage frmSM = new frmStorageManage();
            frmSM.ShowDialog();
        }

        private void 仓库盘点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory frmI = new frmInventory();
            frmI.ShowDialog();
        }

        private void 管理订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewOrder frmNO = new frmNewOrder();
            frmNO.ShowDialog();
        }

        private void 产品出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeOutInventory frmTOI = new frmTakeOutInventory();
            frmTOI.ShowDialog();
        }

        private void 串口设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSerialPortConfig frm = new frmSerialPortConfig();
            frm.ShowDialog();
        }

        private void 编辑标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditEPC frm = new frmEditEPC();
            frm.ShowDialog();
        }

        private void 数据库设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSQLConfig frm = new frmSQLConfig();
            frm.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();

        }

        private void 信息录入toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductManage frmPM = new frmProductManage();
            frmPM.ShowDialog();
        }

        private void 产品类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductCategory frm = new frmProductCategory();
            frm.ShowDialog();
        }

        private void 退出toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
