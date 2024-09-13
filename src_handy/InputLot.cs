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
    public partial class InputLot : Form
    {
        public static InputLot _FormInstance;		// フォーム

        public InputLot()
        {
            InitializeComponent();
            changeFormLang();
        }

        public void changeFormLang()
        {
            Com.changeLang("InputLot.cs", txtMessage);
            Com.changeLang("InputLot.cs", lbl_lot);
            Com.changeLang("InputLot.cs", label1);
            Com.changeLang("InputLot.cs", label2);
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

            txtScan.Text = Com.s_Lot;
            txtScan.SelectAll();
            txtScan.Focus();
            lblItem.Text = Com.s_ItemCD;
            txtItemName.Text = Com.s_ItemName;
            lblUnit.Text = Com.s_ItemUnit;
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
                Com.s_Lot = txtScan.Text;
                Com.s_Qty = "";

                if (InputQty._FormInstance == null)
                {
                    InputQty frm = new InputQty();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    InputQty._FormInstance.Show();
                    InputQty._FormInstance.setData();
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
            InputItem._FormInstance.Show();
            InputItem._FormInstance.setData();
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