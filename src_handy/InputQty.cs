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
    public partial class InputQty : Form
    {
        public static InputQty _FormInstance;		// フォーム

        public InputQty()
        {
            InitializeComponent();
            changeFormLang();
        }

        public void changeFormLang()
        {
            Com.changeLang("InputQty.cs", txtMessage);
            Com.changeLang("InputQty.cs", lbl_qty);
            Com.changeLang("InputQty.cs", label1);
            Com.changeLang("InputQty.cs", label2);
            Com.changeLang("InputQty.cs", label3);
            Com.changeLang("Common", btn_menu);
            Com.changeLang("Common", btn_back);
            Com.changeLang("Common", lbl_F2);
        }

        public void setData()
        {
            Bt.ScanLib.Control.btScanEnable();

            Com.changeLang("Common", lblTitle, Com.i_WorkMode);

            switch (Com.i_WorkMode)
            {
                case 0:
                    lblTitle.BackColor = Color.LightGreen;
                    break;
                case 1:
                    lblTitle.BackColor = Color.LightPink;
                    break;
                case 2:
                    lblTitle.BackColor = Color.LightSkyBlue;
                    break;
                case 3:
                    lblTitle.BackColor = Color.LightSalmon;
                    break;
                default:
                    lblTitle.BackColor = Color.LightGreen;
                    break;
            }

            txtScan.Text = Com.s_Qty;
            txtScan.SelectAll();
            txtScan.Focus();
            lblItem.Text = Com.s_ItemCD;
            txtItemName.Text = Com.s_ItemName;
            lblUnit.Text = Com.s_ItemUnit;
            lblLot.Text = Com.s_Lot;
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
            if (e.KeyCode == Keys.F1)
            {
                // [F1] MENU.
                btn_menu_Click();
            }
            else if (e.KeyCode == Keys.F4)
            {
                // [F4] BACK.
                btn_back_Click();
            }
            else if (e.KeyCode == Keys.F2)
            {
                // [F2] HISTORY.
                if (History._FormInstance == null)
                {
                    History frm = new History();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    History._FormInstance.Show();
                    History._FormInstance.setData();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // Enter.
                if (0 == Com.ConvertDouble(txtScan.Text))
                {
                    Com.Buzzer1(2);
                    MessageBox.Show(Com.changeMessage("Invalid"), "BKHandy Application");
                    return;
                }

                Com.Buzzer2();

                Com.s_Qty = txtScan.Text;

                saveLog();

                Com.s_ItemCD = "";
                Com.s_ItemName = "";
                Com.s_ItemUnit = "";
                Com.s_Lot = "";
                Com.s_Qty = "";
                if (InputItem._FormInstance == null)
                {
                    InputItem frm = new InputItem();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    InputItem._FormInstance.Show();
                    InputItem._FormInstance.setData();
                }
                this.Hide();
            }
        }

        private void saveLog()
        {
            // write log to CSV
            string s_log = DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            Com.writeLog(DateTime.Now.ToString("yyyy/MM/dd") + "," +
                                DateTime.Now.ToString("HH:mm:ss") + "," +
                                Com.i_WorkMode.ToString() + "," +
                                Com.s_Request_No + "," + 
                                Com.s_Loc1_CD + "," +
                                Com.s_Loc2_CD + "," +
                                Com.s_ItemCD + "," +
                                Com.s_Lot + "," +
                                Com.s_Qty + "," +
                                Com.s_TerminalName
                                , s_log);
        }

        private void btn_menu_Click()
        {
            // [F1] MENU.
            MainForm._MainFormInstance.Show();
            this.Hide();
        }

        private void btn_back_Click()
        {
            // [F4] BACK.
            InputLot._FormInstance.Show();
            InputLot._FormInstance.setData();
            this.Hide();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            btn_menu_Click();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            btn_back_Click();
        }

        /********************************************************************************
         * [フォーム終了時のリリース処理]
        ********************************************************************************/
        private void MainForm_Closed(object sender, EventArgs e)
        {
            Com.Form_ClosedCom();
        }
    }
}