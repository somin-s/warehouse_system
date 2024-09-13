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
    public partial class InputItem : Form
    {
        public static InputItem _FormInstance;		// フォーム

        public InputItem()
        {
            InitializeComponent();
            changeFormLang();
        }

        public void changeFormLang()
        {
            Com.changeLang("InputItem.cs", txtMessage);
            Com.changeLang("InputItem.cs", lbl_item);
            Com.changeLang("InputItem.cs", label1);
            Com.changeLang("InputItem.cs", label2);
            Com.changeLang("InputItem.cs", label3);
            Com.changeLang("Common", btn_menu);
            Com.changeLang("Common", btn_back);
            Com.changeLang("Common", lbl_F2);
        }

        public void setData()
        {
            Bt.ScanLib.Control.btScanEnable();

            Com.changeLang("Common", lblTitle, Com.i_WorkMode);

            lblDestination.Visible = false;
            label3.Visible = false;
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
                    lblDestination.Visible = true;
                    label3.Visible = true;
                    break;
                default:
                    lblTitle.BackColor = Color.LightGreen;
                    break;
            }

            txtScan.Text = Com.s_ItemCD;
            txtScan.SelectAll();
            txtScan.Focus();
            lblOperator.Text = Com.s_UserName;
            lblLocation.Text = Com.s_Loc1_Name;
            lblDestination.Text = Com.s_Loc2_Name;
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
                Com.s_ItemCD = txtScan.Text;
                Com.s_Lot = "";

                if (false == Com.setMasterItem())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtScan.SelectAll();
                    return;
                }

                if (InputLot._FormInstance == null)
                {
                    InputLot frm = new InputLot();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    InputLot._FormInstance.Show();
                    InputLot._FormInstance.setData();
                }
                this.Hide();
            }
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
            if (3 != Com.i_WorkMode)
            {
                InputLocation._FormInstance.Show();
                InputLocation._FormInstance.setData();
            }
            else
            {
                InputLocation2._FormInstance.Show();
                InputLocation2._FormInstance.setData();
            }
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