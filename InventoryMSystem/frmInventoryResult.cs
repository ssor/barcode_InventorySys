using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public partial class frmInventoryResult : Form
    {
        //扫描到的标签
        List<Epc> currentEpcList = null;
        //数据库中的标签列表
        List<Epc> DBEpcList = null;
        InventoryResultCtl ctlInventoryResult = new InventoryResultCtl();


        public frmInventoryResult(List<Epc> currentEpcList)
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmInventoryResult_Shown);
            this.currentEpcList = currentEpcList;

            this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_TabIndexChanged);
        }

        void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    //盘盈
                    this.refreshInventoryMore();
                    break;
                case 1:
                    this.refreshInventoryLess();
                    break;
                case 2:
                    this.refreshInventoryEqual();
                    break;
            }
        }

        void frmInventoryResult_Shown(object sender, EventArgs e)
        {
            DataTable dt = this.ctlInventoryResult.GetInStorageProductInfoTable();
            if (dt != null)
            {
                this.DBEpcList = new List<Epc>();
                foreach (DataRow dr in dt.Rows)
                {
                    this.DBEpcList.Add(new Epc(dr[0].ToString()));
                }
            }

            // 比较两个列表，计算盘亏和盘盈
            if (this.DBEpcList != null && this.currentEpcList != null)
            {
                //将两个列表中都含有的id标记为true
                //最后统计时标记为true的为正常
                // DBEpcList中标记为false的为盘盈
                //currentEpcList中标记为false的为盘亏
                foreach (Epc epc in DBEpcList)
                {
                    foreach (Epc epcIn in currentEpcList)
                    {
                        if (epc.id == epcIn.id)
                        {
                            epcIn.flag = true;
                            epc.flag = true;
                            break;
                        }
                    }
                }
            }
            this.tabControl1_TabIndexChanged(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void refreshInventoryMore()
        {
            //string ids = string.Empty;
            string ids = "' '";
            foreach (Epc epc in currentEpcList)
            {
                if (epc.flag == false)
                {
                    ids = ids + ",'" + epc.id + "'";
                }
            }
            if (ids != string.Empty)
            {
                //ids = ids.Substring(1);

                DataTable dt = this.ctlInventoryResult.GetInStorageProductInventoryByIDs(ids);
                //DataTable dt = this.ctlInventoryResult.GetInStorageProductInventoryMore(ids);
                this.dataGridView1.DataSource = dt;
            }
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
        void refreshInventoryLess()
        {
            string ids = "' '";
            foreach (Epc epc in DBEpcList)
            {
                if (epc.flag == false)
                {
                    ids = ids + ",'" + epc.id + "'";
                }
            }
            if (ids.Length > 0)
            //if (ids != string.Empty)
            {
                //ids = ids.Substring(1);
                //DataTable dt = this.ctlInventoryResult.GetInStorageProductInventoryMore(ids);
                DataTable dt = this.ctlInventoryResult.GetInStorageProductInventoryByIDs(ids);
                this.dataGridView2.DataSource = dt;
            }

            this.dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dataGridView2.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dataGridView2.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dataGridView2.Width)
                {
                    int leftTotalWidht = this.dataGridView2.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
        }
        void refreshInventoryEqual()
        {
            //string ids = string.Empty;
            string ids = "' '";
            foreach (Epc epc in DBEpcList)
            {
                if (epc.flag == true)
                {
                    ids = ids + ",'" + epc.id + "'";
                }
            }
            if (ids != string.Empty)
            {
                //ids = ids.Substring(1);
                //DataTable dt = this.ctlInventoryResult.GetInStorageProductInventoryMore(ids);
                DataTable dt = this.ctlInventoryResult.GetInStorageProductInventoryByIDs(ids);
                this.dgvRecordWithThing.DataSource = dt;
            }


            this.dgvRecordWithThing.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvRecordWithThing.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvRecordWithThing.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvRecordWithThing.Width)
                {
                    int leftTotalWidht = this.dgvRecordWithThing.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
        }



    }
    public class Epc
    {
        public string id;
        public bool flag = false;
        public Epc(string id)
        {
            this.id = id;
        }
    }
}
