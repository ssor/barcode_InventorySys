using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public partial class frmNewOrder : Form
    {
        ctlProductName ctlProductName = new ctlProductName();
        NewOrderCtl ctlOrder = new NewOrderCtl();
        public frmNewOrder()
        {
            InitializeComponent();

            this.cbmProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dt = ctlProductName.GetProductName();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.cbmProduct.Items.Add(dr[0].ToString());
                }
            }

            this.cmbQuality.Items.Add("1");
            this.cmbQuality.Items.Add("2");
            this.cmbQuality.Items.Add("3");
            this.cmbQuality.Items.Add("4");

            this.Shown += new EventHandler(frmNewOrder_Shown);

        }

        void frmNewOrder_Shown(object sender, EventArgs e)
        {
            this.RefreshOrderInfo();
        }
        public void RefreshOrderInfo()
        {

            //DataTable table = new DataTable("order");
            //DataColumn column;
            //DataRow row;

            //// Create new DataColumn, set DataType, 
            //// ColumnName and add to DataTable.    
            //column = new DataColumn("产品编号");
            //table.Columns.Add(column);
            //column = new DataColumn("名称");
            //table.Columns.Add(column);
            //column = new DataColumn("数量");
            //table.Columns.Add(column);
            //for (int i = 0; i < 10; i++)
            //{
            //    row = table.NewRow();
            //    row["产品编号"] = "001" + i.ToString();
            //    row["名称"] = "john" + i.ToString();
            //    row["数量"] = i.ToString();
            //    table.Rows.Add(row);
            //}
            DataTable table = null;
            table = ctlOrder.GetOrderTable();
            this.dgvOrderInfo.DataSource = table;
            if (!this.dgvOrderInfo.Columns.Contains("checkColumn"))
            {
                DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
                cc.HeaderText = "";
                cc.Name = "checkColumn";
                cc.Width = 50;
                dgvOrderInfo.Columns.Insert(0, cc);
            }

            this.dgvOrderInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvOrderInfo.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvOrderInfo.Columns;
            columns[0].Width = 50;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dgvOrderInfo.Width)
            {
                int leftTotalWidht = this.dgvOrderInfo.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                for (int i = 1; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dgvOrderInfo.Rows;
            if (this.cbSelectAll.Checked)
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            try
            {
                quantity = int.Parse(this.cmbQuality.Text);
                if (quantity <= 0)
                {
                    MessageBox.Show("请输入正确的数量！");
                    return;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的数量！");
                return;
            }
            if (this.cbmProduct.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要订购的产品！");
                return;
            }
            this.ctlOrder.AddOrderItem(this.cbmProduct.Text, quantity);
            this.RefreshOrderInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dgvOrderInfo.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                if ((cbc.Value != null) && cbc.Value.ToString() == Boolean.TrueString)
                {
                    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                    string epc = (string)cepc.Value;
                    this.ctlOrder.DeleteOrderItem(epc);
                }
            }
            this.RefreshOrderInfo();
        }
    }
}
