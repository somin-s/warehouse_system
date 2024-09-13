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
    public partial class History : Form
    {
        public static History _FormInstance;		// フォーム
        private int CurrentPage = 1;

        public History()
        {
            InitializeComponent();
            changeFormLang();
        }

        public void changeFormLang()
        {
            Com.changeLang("History.cs", lblTitle);
            Com.changeLang("History.cs", label10);
            Com.changeLang("History.cs", label6);
            Com.changeLang("History.cs", label5);
            Com.changeLang("History.cs", label4);
            Com.changeLang("History.cs", label7);
            Com.changeLang("History.cs", label8);
            Com.changeLang("History.cs", label1);
            Com.changeLang("History.cs", lbl_Clear);
            Com.changeLang("History.cs", btn_back);
            Com.changeLang("History.cs", btn_next);
            Com.changeLang("History.cs", btn_delete);
        }

        public List<string> files;

        public void setFiles()
        {
            string[] FilesTmp = Directory.GetFiles(Com.OUT_FOLDER);
            files = new List<string>();
            if (0 != FilesTmp.Length)
            {
                foreach (string s in FilesTmp)
                {
                    string line = "";
                    using (var sr = new System.IO.StreamReader(s))
                    {
                        // ストリームの末尾まで繰り返す
                        while (!sr.EndOfStream)
                        {
                            // ファイルから一行読み込む
                            line = sr.ReadLine();
                        }
                    }
                    string[] each = line.Split(',');
                    if (each.Length > 3)
                    {
                        if (each[2] == Com.i_WorkMode.ToString())
                        {
                            files.Add(s);
                        }
                    }
                }
            }
        }

        public void showHistoryData(int page)
        {
            if (0 != files.Count)
            {
                lblNowPage.Text = page.ToString();
                lblTotalPage.Text = files.Count.ToString();

                string line = "";
                using (var sr = new System.IO.StreamReader(files[page-1]))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        line = sr.ReadLine();
                    }
                }
                string[] s_data = line.Split(',');
                if (10 == s_data.Length)
                {
                    lblDateTime.Text = s_data[0] + " " + s_data[1];
                    lblOperator.Text = Com.getUserName(s_data[3]);
                    lblLocation.Text = Com.getLocName(s_data[4]);
                    if ("3" == s_data[2])
                    {
                        label4.Visible = true;
                        lblDestination.Visible = true;
                        lblDestination.Text = Com.getLocName(s_data[5]);
                    }
                    else
                    {
                        label4.Visible = false;
                        lblDestination.Visible = false;
                    }
                    lblItem.Text = s_data[6];
                    txtItemName.Text = Com.getItemName(s_data[6]);
                    lblLot.Text = s_data[7];
                    lblQty.Text = s_data[8];
                }
            }
            else
            {
                CurrentPage = 0;
                lblNowPage.Text = "0";
                lblTotalPage.Text = "0";
                lblDateTime.Text = "";
                lblOperator.Text = "";
                lblLocation.Text = "";
                lblDestination.Text = "";
                lblItem.Text = "";
                txtItemName.Text = "";
                lblLot.Text = "";
                lblQty.Text = "";
            }
        }

        public void setData()
        {
            Com.changeLang("InputUser.cs", this, Com.i_WorkMode);

            switch (Com.i_WorkMode)
            {
                case 0:
                    lblTitle.BackColor = Color.LightGreen;
                    lblNowPage.BackColor = Color.LightGreen;
                    label3.BackColor = Color.LightGreen;
                    lblTotalPage.BackColor = Color.LightGreen;
                    break;
                case 1:
                    lblTitle.BackColor = Color.LightPink;
                    lblNowPage.BackColor = Color.LightPink;
                    label3.BackColor = Color.LightPink;
                    lblTotalPage.BackColor = Color.LightPink;
                    break;
                case 2:
                    lblTitle.BackColor = Color.LightSkyBlue;
                    lblNowPage.BackColor = Color.LightSkyBlue;
                    label3.BackColor = Color.LightSkyBlue;
                    lblTotalPage.BackColor = Color.LightSkyBlue;
                    break;
                case 3:
                    lblTitle.BackColor = Color.LightSalmon;
                    lblNowPage.BackColor = Color.LightSalmon;
                    label3.BackColor = Color.LightSalmon;
                    lblTotalPage.BackColor = Color.LightSalmon;
                    break;
                default:
                    lblTitle.BackColor = Color.LightGreen;
                    lblNowPage.BackColor = Color.LightGreen;
                    label3.BackColor = Color.LightGreen;
                    lblTotalPage.BackColor = Color.LightGreen;
                    break;
            }
            CurrentPage = 1;
            setFiles();
            showHistoryData(CurrentPage);
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
            if (e.KeyCode == Keys.Back)
            {
                // [C] CLEAR.
                this.Hide();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // [ENT] DELETE.
                btn_delete_Click();
            }
            else if (e.KeyCode == Keys.F1)
            {
                // [F1] BACK.
                btn_back_Click();
            }
            else if (e.KeyCode == Keys.F4)
            {
                // [F4] NEXT.
                btn_next_Click();
            }
        }

        private void btn_back_Click()
        {
            if (0 != files.Count && 1 != files.Count)
            {
                CurrentPage = CurrentPage - 1;
                if (0 == CurrentPage)
                {
                    CurrentPage = files.Count;
                }
                showHistoryData(CurrentPage);
            }
        }

        private void btn_next_Click()
        {
            if (0 != files.Count && 1 != files.Count)
            {
                CurrentPage = CurrentPage + 1;
                if (CurrentPage > files.Count)
                {
                    CurrentPage = 1;
                }
                showHistoryData(CurrentPage);
            }
        }

        private void btn_delete_Click()
        {
            if (0 != CurrentPage)
            {
                if (MessageBox.Show(Com.changeMessage("Delete"), "BKHandy Application",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    File.Delete(files[CurrentPage-1]);
                    CurrentPage = 1;
                    setFiles();
                    showHistoryData(CurrentPage);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            btn_back_Click();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            btn_next_Click();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            btn_delete_Click();
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