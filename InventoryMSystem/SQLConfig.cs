using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMSystemBarcode
{
    public partial class frmSQLConfig : Form
    {
        private SQLConnConfig mySQLConnectionTest;
        public frmSQLConfig()
        {
            InitializeComponent();
            mySQLConnectionTest = new SQLConnConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (mySQLConnectionTest.testConnection())
            {
                MessageBox.Show("连接测试成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("连接测试失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initialForm()
        {
            DBType type = ConfigManager.GetCurrentDBType();
            if (type == DBType.sqlserver)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            else if (type== DBType.sqlite)
            {
                this.comboBox1.SelectedIndex = 1;
            }
            string connStr = ConfigManager.GetDBConnectString(type);
            this.txtConnString.Text = connStr;
        }

        private void SQLConfig_Load(object sender, EventArgs e)
        {
            initialForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //initialForm();
            switch (this.comboBox1.SelectedIndex)
            {
            case 0:
                    if (ConfigManager.SaveDBConnectString(DBType.sqlserver, this.txtConnString.Text))
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
            	break;
            case 1:
                    if(ConfigManager.SaveDBConnectString(DBType.sqlite, this.txtConnString.Text))
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
            	break;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
            case 0:
                    ConfigManager.SaveCurrentDBType(DBType.sqlserver);
                    this.txtConnString.Text = ConfigManager.GetDBConnectString(DBType.sqlserver);
            	break;
            case 1:
                    ConfigManager.SaveCurrentDBType(DBType.sqlite);
                    this.txtConnString.Text = ConfigManager.GetDBConnectString(DBType.sqlite);
            	break;
            }

        }


    }
}