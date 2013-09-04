namespace InventoryMSystemBarcode
{
    partial class frmTakeOutInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakeOutInventory));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTakenOutP = new System.Windows.Forms.DataGridView();
            this.btnStartCheck = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnGetP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetailProductsInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakenOutP)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailProductsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTakenOutP);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出库单信息";
            // 
            // dgvTakenOutP
            // 
            this.dgvTakenOutP.AllowUserToAddRows = false;
            this.dgvTakenOutP.AllowUserToDeleteRows = false;
            this.dgvTakenOutP.AllowUserToOrderColumns = true;
            this.dgvTakenOutP.AllowUserToResizeRows = false;
            this.dgvTakenOutP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTakenOutP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTakenOutP.Location = new System.Drawing.Point(3, 17);
            this.dgvTakenOutP.MultiSelect = false;
            this.dgvTakenOutP.Name = "dgvTakenOutP";
            this.dgvTakenOutP.ReadOnly = true;
            this.dgvTakenOutP.RowHeadersWidth = 20;
            this.dgvTakenOutP.RowTemplate.Height = 23;
            this.dgvTakenOutP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTakenOutP.Size = new System.Drawing.Size(697, 282);
            this.dgvTakenOutP.TabIndex = 0;
            // 
            // btnStartCheck
            // 
            this.btnStartCheck.Enabled = false;
            this.btnStartCheck.Location = new System.Drawing.Point(737, 92);
            this.btnStartCheck.Name = "btnStartCheck";
            this.btnStartCheck.Size = new System.Drawing.Size(90, 30);
            this.btnStartCheck.TabIndex = 2;
            this.btnStartCheck.Text = "出库";
            this.btnStartCheck.UseVisualStyleBackColor = true;
            this.btnStartCheck.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(658, 517);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 10);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(737, 543);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 30);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnGetP
            // 
            this.btnGetP.Location = new System.Drawing.Point(737, 43);
            this.btnGetP.Name = "btnGetP";
            this.btnGetP.Size = new System.Drawing.Size(90, 30);
            this.btnGetP.TabIndex = 2;
            this.btnGetP.Text = "扫描";
            this.btnGetP.UseVisualStyleBackColor = true;
            this.btnGetP.Click += new System.EventHandler(this.btnGetP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetailProductsInfo);
            this.groupBox2.Location = new System.Drawing.Point(15, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 189);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "待出库产品列表";
            // 
            // dgvDetailProductsInfo
            // 
            this.dgvDetailProductsInfo.AllowUserToAddRows = false;
            this.dgvDetailProductsInfo.AllowUserToDeleteRows = false;
            this.dgvDetailProductsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailProductsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailProductsInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvDetailProductsInfo.Name = "dgvDetailProductsInfo";
            this.dgvDetailProductsInfo.ReadOnly = true;
            this.dgvDetailProductsInfo.RowHeadersWidth = 20;
            this.dgvDetailProductsInfo.RowTemplate.Height = 23;
            this.dgvDetailProductsInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetailProductsInfo.Size = new System.Drawing.Size(691, 169);
            this.dgvDetailProductsInfo.TabIndex = 0;
            // 
            // frmTakeOutInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGetP);
            this.Controls.Add(this.btnStartCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTakeOutInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品出库";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakenOutP)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailProductsInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTakenOutP;
        private System.Windows.Forms.Button btnStartCheck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnGetP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetailProductsInfo;
    }
}