namespace InventoryMSystemBarcode
{
    partial class frmInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProductInfo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 458);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘点产品信息";
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.AllowUserToAddRows = false;
            this.dgvProductInfo.AllowUserToDeleteRows = false;
            this.dgvProductInfo.AllowUserToResizeRows = false;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.ReadOnly = true;
            this.dgvProductInfo.RowHeadersWidth = 20;
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductInfo.Size = new System.Drawing.Size(664, 438);
            this.dgvProductInfo.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(708, 194);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(708, 492);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(93, 30);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(645, 461);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 10);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(708, 30);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(93, 30);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "扫描";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(708, 88);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(93, 30);
            this.btnResult.TabIndex = 5;
            this.btnResult.Text = "盘点结果";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 542);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存盘点";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnResult;
    }
}