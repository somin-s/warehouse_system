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
    public partial class PartTest3 : Form
    {
        public static PartTest3 _FormInstance;		// フォーム

        public PartTest3()
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

            txtTestItem.Text = Com.s_TestItem;
            txtTestItem.SelectAll();
            txtTestItem.Focus();

            txtUnitNo.Text = Com.s_UnitNo;
            txtTotalUnit.Text = Com.s_TotalUnit;
            txtDay.Text = Com.s_Day;
            txtMonth.Text = Com.s_Month;
            txtYear.Text = Com.s_Year;
            txtRemark.Text = Com.s_Remark;


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
                Com.s_Plant = txtTestItem.Text;//test
                Com.s_PartNo = txtUnitNo.Text;//test
                Com.s_ColorPlat = txtTotalUnit.Text;
                Com.s_Day = txtDay.Text;
                Com.s_Month = txtMonth.Text;
                Com.s_Year = txtYear.Text;
                Com.s_Remark = txtRemark.Text;

                //Plant
                if (txtTestItem.Text == "")
                {
                    txtTestItem.SelectAll();
                    txtTestItem.Focus();
                    return;
                }
                else if (false == Com.setMasterPlant())
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtTestItem.SelectAll();
                    return;

                }

                //Part No
                else if (txtUnitNo.Text == "")
                {
                    txtUnitNo.SelectAll();
                    txtUnitNo.Focus();
                    return;
                }
                
                //Color and plante code
                else if (txtTotalUnit.Text == "")
                {
                    txtTotalUnit.SelectAll();
                    txtTotalUnit.Focus();
                    return;
                }

                //Day
                else if (txtDay.Text == "")
                {
                    txtDay.SelectAll();
                    txtDay.Focus();
                    return;
                }
                else if (false == Com.setDMY("Day"))
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtDay.SelectAll();
                    return;

                }
                //Month
                else if (txtMonth.Text == "")
                {
                    txtMonth.SelectAll();
                    txtMonth.Focus();
                    return;
                }
                else if (false == Com.setDMY("Month"))
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtMonth.SelectAll();
                    return;

                }

                //Year
                else if (txtYear.Text == "")
                {
                    txtYear.SelectAll();
                    txtYear.Focus();
                    return;
                }
                else if (false == Com.setDMY("Year"))
                {
                    ErrorScreen frm = new ErrorScreen();
                    frm.Show();
                    txtYear.SelectAll();
                    return;

                }
                //Remark
                else if (txtRemark.Text == "")
                {
                    txtRemark.SelectAll();
                    txtRemark.Focus();
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
            PartTest2._FormInstance.Show();
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