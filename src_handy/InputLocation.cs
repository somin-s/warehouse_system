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
    public partial class InputLocation : Form
    {
        public static InputLocation _FormInstance;		// フォーム

        public InputLocation()
        {
            InitializeComponent();
            changeFormLang();
        }

        public void changeFormLang()
        {
            Com.changeLang("InputLocation.cs", txtMessage);
            Com.changeLang("InputLocation.cs", lbl_location);
            Com.changeLang("InputLocation.cs", label1);
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

            txtScan.Text = Com.s_Loc1_CD;
            txtScan.SelectAll();
            txtScan.Focus();
            lblOperator.Text = Com.s_UserName;
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
                Com.s_Loc1_CD = txtScan.Text;

                if (false == Com.setMasterLoc1())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtScan.SelectAll();
                    return;
                }

                if (3 != Com.i_WorkMode)
                {
                    Com.s_ItemCD = "";
                    Com.s_ItemName = "";
                    Com.s_ItemUnit = "";

                    if ("1" == Com.ReadIniFile("LABEL_TYPE"))
                    {
                        if (InputQR._FormInstance == null)
                        {
                            InputQR frm = new InputQR();
                            frm.Show();
                            frm.setData();
                        }
                        else
                        {
                            InputQR._FormInstance.Show();
                            InputQR._FormInstance.setData();
                        }
                    }
                    else
                    {
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
                    }
                }
                else
                {
                    Com.s_Loc2_CD = "";
                    Com.s_Loc2_Name = "";

                    if (InputLocation2._FormInstance == null)
                    {
                        InputLocation2 frm = new InputLocation2();
                        frm.Show();
                        frm.setData();
                    }
                    else
                    {
                        InputLocation2._FormInstance.Show();
                        InputLocation2._FormInstance.setData();
                    }
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
            PartTest1._FormInstance.Show();
            PartTest1._FormInstance.setData();
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