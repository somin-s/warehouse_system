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
using Bt.SysLib;

namespace BKHandy
{
    public partial class MainForm : Form
    {
        public static MainForm _MainFormInstance;		// フォーム

        public MainForm()
        {
            InitializeComponent();
            //cmb_lang.SelectedIndex = Com.ConvertInt(Com.ReadIniFile("LANG_TYPE"));

            getTerminalName();

            Bt.ScanLib.Control.btScanDisable();
        }

        private void getTerminalName()
        {
            string s_terminalName = "";

            // 端末名
            Int32 ret = 0;
            UInt32 idSet = 0;
            IntPtr pValueGetDef_HtName = Marshal.AllocCoTaskMem((int)((LibDef.BT_SYS_HTNAME_MAXLEN + 1) * sizeof(Char)));
            idSet = LibDef.BT_SYS_PRM_HTNAME;
            ret = Terminal.btGetHandyParameter(idSet, pValueGetDef_HtName);
            if (ret != LibDef.BT_OK)
            {
                return;
            }
            s_terminalName = Marshal.PtrToStringUni(pValueGetDef_HtName);
            
            lblTerminal.Text = s_terminalName;
            Com.s_TerminalName = s_terminalName;
        }

        public void changeFormLang()
        {
            Com.changeLang("MainForm.cs", btn_menu1);
            Com.changeLang("MainForm.cs", btn_menu2);
            Com.changeLang("MainForm.cs", btn_menu3);
            //Com.changeLang("MainForm.cs", btn_menu4);
            //Com.changeLang("MainForm.cs", btn_menu5);
            //Com.changeLang("MainForm.cs", btn_menu5);
            Com.changeLang("MainForm.cs", btn_close);
            Com.changeLang("MainForm.cs", btn_send);
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
            _MainFormInstance = this;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btn_close_Click();
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                btn_menu1_Click();
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                btn_menu2_Click();
            }
            else if (e.KeyCode == Keys.NumPad3)
            {
                btn_menu3_Click();
            }
            else if (e.KeyCode == Keys.NumPad4)
            {
                btn_menu4_Click();
            }
            else if (e.KeyCode == Keys.NumPad5)
            {
                btn_menu5_Click();
            }
            //else if (e.KeyCode == Keys.NumPad6)
            //{
            //    cmb_lang.Focus();
            //}
            else if (e.KeyCode == Keys.F4)
            {
                btn_send_Click();
            }
        }

        private void btn_close_Click()
        {
            string s_msg = Com.changeMessage("Close");
            if (MessageBox.Show(s_msg, "BKHandy Application",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_send_Click()
        {
            string s_msg = Com.changeMessage("Send");
            if (MessageBox.Show(s_msg, "BKHandy Application",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if ("0" == Com.ReadIniFile("NETWORK_TYPE"))
                {
                    Com.sendMessage(true);
                    Com.getMaster();
                }
                else
                {
                    Com.KPSendReceive();
                }
            }
        }

        private void move_screen()
        {
            Bt.ScanLib.Control.btScanEnable();

            

            if (Com.i_WorkMode == 0)//for recieve
            {
                if (Com.s_ScreenType == "PartTest")
                {
                    #region PartTest1
                    Com.s_Request_No = "";
                    Com.s_Requester = "";
                    Com.s_Tester = "";
                    Com.s_Project = "";
                    #endregion

                    if (PartTest1._FormInstance == null)
                    {
                        PartTest1 frm = new PartTest1();
                        frm.setData();
                        frm.Show();
                    }
                    else
                    {
                        PartTest1._FormInstance.setData();
                        PartTest1._FormInstance.Show();
                    }
                }
                else if (Com.s_ScreenType == "PaintMeterial")
                {
                    #region PaintMaterial1
                    Com.s_Request_No = "";
                    Com.s_Requester = "";
                    Com.s_Plant = "";
                    Com.s_Material_Type = "";
                    Com.s_Material_Name = "";
                    #endregion
                    if (PaintMaterial1._FormInstance == null)
                    {
                        PaintMaterial1 frm = new PaintMaterial1();
                        frm.setData();
                        frm.Show();
                    }
                    else
                    {
                        PaintMaterial1._FormInstance.setData();
                        PaintMaterial1._FormInstance.Show();
                    }
                }
                else if (Com.s_ScreenType == "TestPanel")
                {
                    #region TestPanel1
                    #endregion

                    if (TestPanel1._FormInstance == null)
                    {
                        TestPanel1 frm = new TestPanel1();
                        frm.setData();
                        frm.Show();
                    }
                    else
                    {
                        PartTest1._FormInstance.setData();
                        PartTest1._FormInstance.Show();
                    }
                }

                this.Hide();
            }
            else if (Com.i_WorkMode == 1)//for issue
            {
                if (InputItem._FormInstance == null)
                {
                    InputItem frm = new InputItem();
                    frm.setData();
                    frm.Show();
                }
                else
                {
                    InputItem._FormInstance.setData();
                    InputItem._FormInstance.Show();
                }
                this.Hide();    
            }
            
        }

        private void btn_menu1_Click()
        {
            Com.s_ScreenType = "PartTest";
            move_screen();
        }

        private void btn_menu2_Click()
        {
            Com.s_ScreenType = "PaintMeterial";
            move_screen();
        }

        private void btn_menu3_Click()
        {
            Com.s_ScreenType = "TestPanel";
            move_screen();
        }

        private void btn_menu4_Click()
        {
            //Com.i_WorkMode = 3;
            //move_screen();
        }
        private void btn_menu5_Click()
        {
            if (Setting._FormInstance == null)
            {
                Setting frm = new Setting();
                frm.Show();
                frm.setData();
            }
            else
            {
                Setting._FormInstance.Show();
                Setting._FormInstance.setData();
            }
            this.Hide();
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_Click();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            btn_send_Click();
        }

        private void btn_menu1_Click(object sender, EventArgs e)
        {
            btn_menu1_Click();
        }

        private void btn_menu2_Click(object sender, EventArgs e)
        {
            btn_menu2_Click();
        }

        private void btn_menu3_Click(object sender, EventArgs e)
        {
            btn_menu3_Click();
        }
        private void btn_menu5_Click(object sender, EventArgs e)
        {
            btn_menu5_Click();
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
            if (true == radioButton1.Checked)
            {
                Com.i_WorkMode = 0;
            }
            else if (true == radioButton2.Checked)
            {
                Com.i_WorkMode = 1;
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rbNetwork_CheckedChanged();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rbNetwork_CheckedChanged();
        }




    }
}