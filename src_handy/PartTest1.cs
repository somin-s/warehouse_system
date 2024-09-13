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
    public partial class PartTest1 : Form
    {
        public static PartTest1 _FormInstance;		// フォーム

        public PartTest1()
        {
            InitializeComponent();
            changeFormLang();
            
        }

        public void changeFormLang()
        {
            //Com.changeLang("InputUser.cs", txtMessage);
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

            txtRequestNo.Text = Com.s_Request_No;
            txtRequestNo.SelectAll();
            txtRequestNo.Focus();

            txtRequester.Text =  Com.s_Requester;
            txtTester.Text =  Com.s_Tester;
            txtProject.Text = Com.s_Project;

            //txtRequester.Text = Com.i_WorkMode + ""; test
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
        private void MainForm_KeyDown(object sender, KeyEventArgs e)//Tick
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
                Com.s_Request_No = txtRequestNo.Text;
                Com.s_Requester = txtRequester.Text;
                Com.s_Tester = txtTester.Text;
                Com.s_Project = txtProject.Text;

                Com.s_Plant = "";
                Com.s_PartNo = "";
                Com.s_ColorPlat = "";
                Com.s_TSH = "";

                //Request No.
                if (txtRequestNo.Text == "")
                {
                    txtRequestNo.SelectAll();
                    txtRequestNo.Focus();
                    return;
                }

                //Requester
                else if (txtRequester.Text == "")
                {
                    txtRequester.SelectAll();
                    txtRequester.Focus();
                    return;
                }
                else if (false == Com.setMasterRequester())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtRequester.SelectAll();
                    return;
                }

                //Tester
                else if (txtTester.Text == "")
                {
                    txtTester.SelectAll();
                    txtTester.Focus();
                    return;
                }
                else if (false == Com.setMasterTester())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtTester.SelectAll();
                    return;
                }

                //Project
                else if (txtProject.Text == "")
                {
                    txtProject.SelectAll();
                    txtProject.Focus();
                    return;
                }

                else if (PartTest2._FormInstance == null)
                {
                    PartTest2 frm = new PartTest2();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    PartTest2._FormInstance.Show();
                    PartTest2._FormInstance.setData();
                }
                this.Hide();

            }
        }
        private void MainForm_KeyDown_Sue(object sender, KeyEventArgs e)
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
                Com.s_UserID = txtRequester.Text;
                Com.s_Loc1_CD = "";
                Com.s_Loc1_Name = "";

                if (false == Com.setMasterUser())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtRequestNo.SelectAll();
                    return;
                }

                if (InputLocation._FormInstance == null)
                {
                    InputLocation frm = new InputLocation();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    InputLocation._FormInstance.Show();
                    InputLocation._FormInstance.setData();
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
            MainForm._MainFormInstance.Show();
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