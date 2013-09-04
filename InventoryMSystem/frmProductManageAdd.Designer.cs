namespace InventoryMSystemBarcode
{
    partial class frmProductManageAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductManageAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFactory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetPID = new System.Windows.Forms.Button();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "编码：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbFactory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGetPID);
            this.groupBox1.Controls.Add(this.cmbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(83, 111);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(553, 118);
            this.txtComment.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "说明：";
            // 
            // cmbFactory
            // 
            this.cmbFactory.FormattingEnabled = true;
            this.cmbFactory.Items.AddRange(new object[] {
            "厂家一",
            "厂家二"});
            this.cmbFactory.Location = new System.Drawing.Point(444, 61);
            this.cmbFactory.Name = "cmbFactory";
            this.cmbFactory.Size = new System.Drawing.Size(192, 20);
            this.cmbFactory.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "产品类别：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "生产日期：";
            // 
            // btnGetPID
            // 
            this.btnGetPID.Location = new System.Drawing.Point(286, 16);
            this.btnGetPID.Name = "btnGetPID";
            this.btnGetPID.Size = new System.Drawing.Size(66, 23);
            this.btnGetPID.TabIndex = 14;
            this.btnGetPID.Text = "读取";
            this.btnGetPID.UseVisualStyleBackColor = true;
            this.btnGetPID.Click += new System.EventHandler(this.btnGetPID_Click);
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(444, 17);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(192, 20);
            this.cmbName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "名称：";
            // 
            // txtPID
            // 
            this.txtPID.Location = new System.Drawing.Point(83, 17);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(197, 21);
            this.txtPID.TabIndex = 1;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(589, 339);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(93, 28);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(469, 339);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "确定";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(13, 534);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 12);
            this.statusLabel.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(13, 312);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "完成后关闭本窗口";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmProductManageAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 375);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductManageAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品管理--增加产品信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetPID;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFactory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}