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
    public partial class Paintmaterial2 : Form
    {
        public static Paintmaterial2 _FormInstance;		// フォーム

        public Paintmaterial2()
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

            txtName.Text = Com.s_Name;
            txtName.SelectAll();
            txtName.Focus();

            txtColorPlat.Text = Com.s_ColorPlat;
            txtMaker.Text = Com.s_Maker;
            txtUnitNo.Text = Com.s_UnitNo;

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
                Com.s_Name = txtName.Text;
                Com.s_ColorPlat = txtColorPlat.Text;
                Com.s_Maker = txtMaker.Text;
                Com.s_UnitNo = txtUnitNo.Text;



                Com.s_TestItem = "";
                Com.s_UnitNo = "";
                Com.s_TotalUnit = "";
                Com.s_Day = ""; Com.s_Month = ""; Com.s_Year = "";
                Com.s_Remark = "";

                //Name
                if (txtName.Text == "")
                {
                    txtName.SelectAll();
                    txtName.Focus();
                    return;
                }

                //ColorPlat
                if (txtColorPlat.Text == "")
                {
                    txtColorPlat.SelectAll();
                    txtColorPlat.Focus();
                    return;
                }


                //Maker
                if (txtMaker.Text == "")
                {
                    txtMaker.SelectAll();
                    txtMaker.Focus();
                    return;
                }
                else if (false == Com.setMasterMaker())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtMaker.SelectAll();
                    return;

                }
                //Unit No.
                if (txtUnitNo.Text == "")
                {
                    txtUnitNo.SelectAll();
                    txtUnitNo.Focus();
                    return;
                }

                

                else if (PartTest3._FormInstance == null)
                {

                    Paintmaterial3 frm = new Paintmaterial3();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    Paintmaterial3._FormInstance.Show();
                    Paintmaterial3._FormInstance.setData();
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