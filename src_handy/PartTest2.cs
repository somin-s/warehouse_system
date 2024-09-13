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
    public partial class PartTest2 : Form
    {
        public static PartTest2 _FormInstance;		// フォーム

        public PartTest2()
        {
            InitializeComponent();
            changeFormLang();

        }

        public void changeFormLang()
        {
            //Com.changeLang("InputUser.cs", txtMessage);
            Com.changeLang("InputUser.cs", label0);
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

            txtPlant.Text = Com.s_Plant;
            txtPlant.SelectAll();
            txtPlant.Focus();

            txtPartNo.Text = Com.s_PartNo;
            txtCol_PlateCD.Text = Com.s_ColorPlat;
            txtTSH.Text = Com.s_TSH;

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
                Com.s_Plant = txtPlant.Text;//test
                Com.s_PartNo = txtPartNo.Text;//test
                Com.s_ColorPlat = txtCol_PlateCD.Text;
                Com.s_TSH = txtTSH.Text;


                Com.s_TestItem = "";
                Com.s_UnitNo = "";
                Com.s_TotalUnit = "";
                Com.s_Day = ""; Com.s_Month = ""; Com.s_Year = "";
                Com.s_Remark = "";
                //Plant
                if (txtPlant.Text == "")
                {
                    txtPlant.SelectAll();
                    txtPlant.Focus();
                    return;
                }
                else if (false == Com.setMasterPlant())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtPlant.SelectAll();
                    return;
                
                }

                //Part No
                else if (txtPartNo.Text == "")
                {
                    txtPartNo.SelectAll();
                    txtPartNo.Focus();
                    return;
                }
                //else if (false == Com.setMasterPartNo())
                //{
                //    ErrorScreen frm = new ErrorScreen();
                //    frm.Show();
                //    txtPartNo.SelectAll();
                //    return;
                //}

                //Color and plante code
                else if (txtCol_PlateCD.Text == "")
                {
                    txtCol_PlateCD.SelectAll();
                    txtCol_PlateCD.Focus();
                    return;
                }

                //TSH
                else if (txtTSH.Text == "")
                {
                    txtTSH.SelectAll();
                    txtTSH.Focus();
                    return;
                }
                else if (false == Com.setMasterTSH())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtTSH.SelectAll();
                    return;

                }

                else if (PartTest3._FormInstance == null)
                {
                    PartTest3 frm = new PartTest3();
                    frm.Show();
                    frm.setData();
                }
                else
                {
                    PartTest3._FormInstance.Show();
                    PartTest3._FormInstance.setData();
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