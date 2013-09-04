namespace InventoryMSystemBarcode
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnProduceCodeBar = new System.Windows.Forms.Button();
            this.btnSerialPortConf = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.仓库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品贴标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息录入toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.产品入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库盘点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品类别管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(545, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "产品贴标";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(545, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "入库";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(545, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "生成订单";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(545, 298);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "出库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(545, 212);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "盘点";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnProduceCodeBar
            // 
            this.btnProduceCodeBar.Location = new System.Drawing.Point(545, 87);
            this.btnProduceCodeBar.Name = "btnProduceCodeBar";
            this.btnProduceCodeBar.Size = new System.Drawing.Size(75, 23);
            this.btnProduceCodeBar.TabIndex = 3;
            this.btnProduceCodeBar.Text = "生成条码";
            this.btnProduceCodeBar.UseVisualStyleBackColor = true;
            this.btnProduceCodeBar.Visible = false;
            this.btnProduceCodeBar.Click += new System.EventHandler(this.btnProduceCodeBar_Click);
            // 
            // btnSerialPortConf
            // 
            this.btnSerialPortConf.Location = new System.Drawing.Point(549, 338);
            this.btnSerialPortConf.Name = "btnSerialPortConf";
            this.btnSerialPortConf.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPortConf.TabIndex = 12;
            this.btnSerialPortConf.Text = "串口设置";
            this.btnSerialPortConf.UseVisualStyleBackColor = true;
            this.btnSerialPortConf.Visible = false;
            this.btnSerialPortConf.Click += new System.EventHandler(this.btnSerialPortConf_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(549, 377);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "编辑rfid标签";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(651, 199);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "数据库设置";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.仓库管理ToolStripMenuItem,
            this.订单管理ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.设置ToolStripMenuItem1,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 25);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 仓库管理ToolStripMenuItem
            // 
            this.仓库管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.产品贴标ToolStripMenuItem,
            this.信息录入toolStripMenuItem1,
            this.产品入库ToolStripMenuItem,
            this.仓库盘点ToolStripMenuItem,
            this.产品出库ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出toolStripMenuItem1});
            this.仓库管理ToolStripMenuItem.Name = "仓库管理ToolStripMenuItem";
            this.仓库管理ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.仓库管理ToolStripMenuItem.Text = "仓库管理(&I)";
            // 
            // 产品贴标ToolStripMenuItem
            // 
            this.产品贴标ToolStripMenuItem.Name = "产品贴标ToolStripMenuItem";
            this.产品贴标ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.产品贴标ToolStripMenuItem.Text = "产品贴标(&T)";
            this.产品贴标ToolStripMenuItem.Click += new System.EventHandler(this.产品贴标ToolStripMenuItem_Click);
            // 
            // 信息录入toolStripMenuItem1
            // 
            this.信息录入toolStripMenuItem1.Name = "信息录入toolStripMenuItem1";
            this.信息录入toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.信息录入toolStripMenuItem1.Text = "产品信息录入(&I)";
            this.信息录入toolStripMenuItem1.Click += new System.EventHandler(this.信息录入toolStripMenuItem1_Click);
            // 
            // 产品入库ToolStripMenuItem
            // 
            this.产品入库ToolStripMenuItem.Name = "产品入库ToolStripMenuItem";
            this.产品入库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.产品入库ToolStripMenuItem.Text = "产品入库(&R)";
            this.产品入库ToolStripMenuItem.Click += new System.EventHandler(this.产品入库ToolStripMenuItem_Click);
            // 
            // 仓库盘点ToolStripMenuItem
            // 
            this.仓库盘点ToolStripMenuItem.Name = "仓库盘点ToolStripMenuItem";
            this.仓库盘点ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.仓库盘点ToolStripMenuItem.Text = "仓库盘点(&P)";
            this.仓库盘点ToolStripMenuItem.Click += new System.EventHandler(this.仓库盘点ToolStripMenuItem_Click);
            // 
            // 产品出库ToolStripMenuItem
            // 
            this.产品出库ToolStripMenuItem.Name = "产品出库ToolStripMenuItem";
            this.产品出库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.产品出库ToolStripMenuItem.Text = "产品出库(&K)";
            this.产品出库ToolStripMenuItem.Click += new System.EventHandler(this.产品出库ToolStripMenuItem_Click);
            // 
            // 订单管理ToolStripMenuItem
            // 
            this.订单管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理订单ToolStripMenuItem});
            this.订单管理ToolStripMenuItem.Name = "订单管理ToolStripMenuItem";
            this.订单管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.订单管理ToolStripMenuItem.Text = "订单管理(&O)";
            // 
            // 管理订单ToolStripMenuItem
            // 
            this.管理订单ToolStripMenuItem.Name = "管理订单ToolStripMenuItem";
            this.管理订单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.管理订单ToolStripMenuItem.Text = "管理订单(&M)";
            this.管理订单ToolStripMenuItem.Click += new System.EventHandler(this.管理订单ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑标签ToolStripMenuItem,
            this.产品类别管理ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.设置ToolStripMenuItem.Text = "系统管理(&M)";
            // 
            // 编辑标签ToolStripMenuItem
            // 
            this.编辑标签ToolStripMenuItem.Name = "编辑标签ToolStripMenuItem";
            this.编辑标签ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.编辑标签ToolStripMenuItem.Text = "编辑标签(&E)";
            this.编辑标签ToolStripMenuItem.Visible = false;
            this.编辑标签ToolStripMenuItem.Click += new System.EventHandler(this.编辑标签ToolStripMenuItem_Click);
            // 
            // 产品类别管理ToolStripMenuItem
            // 
            this.产品类别管理ToolStripMenuItem.Name = "产品类别管理ToolStripMenuItem";
            this.产品类别管理ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.产品类别管理ToolStripMenuItem.Text = "产品类别管理(&C)";
            this.产品类别管理ToolStripMenuItem.Click += new System.EventHandler(this.产品类别管理ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口设置ToolStripMenuItem,
            this.数据库设置ToolStripMenuItem});
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(59, 21);
            this.设置ToolStripMenuItem1.Text = "设置(&T)";
            // 
            // 串口设置ToolStripMenuItem
            // 
            this.串口设置ToolStripMenuItem.Name = "串口设置ToolStripMenuItem";
            this.串口设置ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.串口设置ToolStripMenuItem.Text = "串口设置(&S)";
            this.串口设置ToolStripMenuItem.Click += new System.EventHandler(this.串口设置ToolStripMenuItem_Click);
            // 
            // 数据库设置ToolStripMenuItem
            // 
            this.数据库设置ToolStripMenuItem.Name = "数据库设置ToolStripMenuItem";
            this.数据库设置ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.数据库设置ToolStripMenuItem.Text = "数据库设置(&D)";
            this.数据库设置ToolStripMenuItem.Click += new System.EventHandler(this.数据库设置ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(12, 523);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 16;
            this.lblMsg.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 10);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 退出toolStripMenuItem1
            // 
            this.退出toolStripMenuItem1.Name = "退出toolStripMenuItem1";
            this.退出toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.退出toolStripMenuItem1.Text = "退出(&X)";
            this.退出toolStripMenuItem1.Click += new System.EventHandler(this.退出toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnSerialPortConf);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnProduceCodeBar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 仓储管理信息系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnProduceCodeBar;
        private System.Windows.Forms.Button btnSerialPortConf;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 仓库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品贴标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仓库盘点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品出库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑标签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 串口设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem 产品类别管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息录入toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出toolStripMenuItem1;
    }
}

