using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bt.ScanLib;
using Bt;

namespace BKHandy
{
    public partial class Setting : Form
    {
        public static Setting _FormInstance;		// フォーム

        public Setting()
        {
            InitializeComponent();
            changeFormLang();
        }

        public void changeFormLang()
        {
            Com.changeLang("Setting.cs", lblTitle);
            Com.changeLang("Setting.cs", label2);
            Com.changeLang("Setting.cs", label7);
            Com.changeLang("Setting.cs", label3);
            Com.changeLang("Setting.cs", label4);
            Com.changeLang("Setting.cs", cbSendLog);
            Com.changeLang("Setting.cs", rbLabel1);
            Com.changeLang("Setting.cs", btn_cancel);
            Com.changeLang("Setting.cs", btn_save);
        }

        public void setData()
        {
            Bt.ScanLib.Control.btScanDisable();

            if ("0" == Com.ReadIniFile("NETWORK_TYPE"))
            {
                rbNetwork1.Checked = true;
            }
            else
            {
                rbNetwork2.Checked = true;
            }

            string s_IP = Com.ReadIniFile("HOSTIP");
            string[] _s_IP = s_IP.Split('.');
            if (4 == _s_IP.Length)
            {
                txtIP1.Text = _s_IP[0];
                txtIP2.Text = _s_IP[1];
                txtIP3.Text = _s_IP[2];
                txtIP4.Text = _s_IP[3];
            }

            txtPort.Text = Com.ReadIniFile("HOSTPORT");

            if ("0" == Com.ReadIniFile("SENDLOG_TYPE"))
            {
                cbSendLog.Checked = true;
            }
            else
            {
                cbSendLog.Checked = false;
            }

            if ("0" == Com.ReadIniFile("LABEL_TYPE"))
            {
                rbLabel1.Checked = true;
            }
            else
            {
                rbLabel2.Checked = true;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 画面サイズ調整
            if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width == 240)
            {
                resolution.ScreenSize.VGAtoQVGA(this);
            }

            // フォームの最大化・最小化ボタン非表示
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            _FormInstance = this;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                // [F4] SAVE.
                btn_save_Click();
            }
            else if (e.KeyCode == Keys.F1)
            {
                // [F1] CANCEL.
                btn_cancel_Click();
            }
        }

        private void btn_save_Click()
        {
            if (true == rbNetwork1.Checked)
            {
                Com.WriteIniFile("NETWORK_TYPE","0");
            }
            else
            {
                Com.WriteIniFile("NETWORK_TYPE", "1");
            }

            if (0 == Com.ConvertDouble(txtPort.Text))
            {
                Com.Buzzer1(2);
                MessageBox.Show(Com.changeMessage("Invalid"), "BKHandy Application");
                txtPort.Focus();
                return;
            }

            string s_IP = Com.ConvertDouble(txtIP1.Text).ToString() + "." + 
                            Com.ConvertDouble(txtIP2.Text).ToString() + "." + 
                            Com.ConvertDouble(txtIP3.Text).ToString() + "." + 
                            Com.ConvertDouble(txtIP4.Text).ToString();
            Com.WriteIniFile("HOSTIP", s_IP);
            Com.WriteIniFile("HOSTPORT", txtPort.Text);

            if (true == cbSendLog.Checked)
            {
                Com.WriteIniFile("SENDLOG_TYPE", "0");
            }
            else
            {
                Com.WriteIniFile("SENDLOG_TYPE", "1");
            }

            if (true == rbLabel1.Checked)
            {
                Com.WriteIniFile("LABEL_TYPE", "0");
            }
            else
            {
                Com.WriteIniFile("LABEL_TYPE", "1");
            }

            MainForm._MainFormInstance.Show();
            this.Hide();
        }

        private void btn_cancel_Click()
        {
            // [F1] CANCEL.
            MainForm._MainFormInstance.Show();
            this.Hide();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_save_Click();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_cancel_Click();
        }

        /********************************************************************************
         * [フォーム終了時のリリース処理]
        ********************************************************************************/
        private void MainForm_Closed(object sender, EventArgs e)
        {
            Com.Form_ClosedCom();
        }

        private void rbNetwork_CheckedChanged()
        {
            if (true == rbNetwork1.Checked)
            {
                txtIP1.Enabled = true;
                txtIP2.Enabled = true;
                txtIP3.Enabled = true;
                txtIP4.Enabled = true;
                txtPort.Enabled = true;
            }
            else
            {
                txtIP1.Enabled = false;
                txtIP2.Enabled = false;
                txtIP3.Enabled = false;
                txtIP4.Enabled = false;
                txtPort.Enabled = false;
            }
        }

        private void rbNetwork1_CheckedChanged(object sender, EventArgs e)
        {
            rbNetwork_CheckedChanged();
        }

        private void rbNetwork2_CheckedChanged(object sender, EventArgs e)
        {
            rbNetwork_CheckedChanged();
        }
    }
}