using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InventoryMSystemBarcode
{
    public partial class frmProductCategory : Form
    {
        ProductCategoryCtl ctlProductCategory = new ProductCategoryCtl();
        public frmProductCategory()
        {
            InitializeComponent();

            this.Shown += new EventHandler(frmNewOrder_Shown);

        }

        void frmNewOrder_Shown(object sender, EventArgs e)
        {
            this.RefreshOrderInfo();
        }
        public void RefreshOrderInfo()
        {
            DataTable table = null;
            table = ctlProductCategory.GetCategoryTable();
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
            if (this.textBox1.Text == null || this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("请输入产品类别名称!");
                return;
            }
            if (this.txtCodeID.Text == null || this.txtCodeID.Text == string.Empty)
            {
                MessageBox.Show("请输入产品类别编码!");
                return;
            }
            if (!Regex.IsMatch(this.txtCodeID.Text, "[0-9]"))
            {
                MessageBox.Show("产品类别编码只能使用数字！");
                return;
            }
            if (this.txtCodeID.Text.Length > 5)
            {
                MessageBox.Show("产品类别编码使用的数字太大，最高值 9999！");
                return;
            }
            this.ctlProductCategory.AddCategoryItem(this.textBox1.Text, this.txtCodeID.Text);
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
                    this.ctlProductCategory.DeleteCategoryItem(epc);
                }
            }
            this.RefreshOrderInfo();
        }
    }
}
