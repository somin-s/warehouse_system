﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using ComFunction;

namespace BrightKeeper
{
    public partial class SystemMain : Form
    {
        public static string s_PathBak = "";

        public SystemMain()
        {
            InitializeComponent();
            ComFunc.Language("SystemMain.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
                string sql = @"SELECT * FROM TB_M_SYSTEM";
                DataTable dt = ComFunc.ConnectDatabase(sql);
                if (null != dt && 0 != dt.Rows.Count)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        switch (dr[0].ToString())
                        {
                            case "LICENSE":
                                if ("" != dr[1].ToString())
                                {
                                    lbl_warning1.Visible = false;
                                    lbl_warning2.Visible = true;
                                    btn_activate.Enabled = false;
                                    txt_lisence.Enabled = false;
                                }
                                else
                                {
                                    lbl_warning1.Visible = true;
                                    lbl_warning2.Visible = false;
                                    btn_activate.Enabled = true;
                                    txt_lisence.Enabled = true;
                                }
                                break;
                            case "LOG_DAYS":
                                cbLogDays.Text = dr[1].ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
                txt_AddPass.Text = ComFunc.getAddminPassword();

                string s_Export = ConfigurationManager.AppSettings.Get("EXCELCSV");
                if ("0" == s_Export)
                {
                    rbExport1.Checked = true;
                }
                else
                {
                    rbExport2.Checked = true;
                }

                string s_CSV = ConfigurationManager.AppSettings.Get("CSVLang");
                if ("0" == s_CSV)
                {
                    rbCSV1.Checked = true;
                }
                else
                {
                    rbCSV2.Checked = true;
                }

            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1701";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_activate_Click(object sender, EventArgs e)
        {
            try
            {
                bool b_activate = false;
                foreach (string str in ComFunc.s_Lisence)
                {
                    if (txt_lisence.Text == str)
                    {
                        b_activate = true;
                        break;
                    }
                }
                if (true == b_activate)
                {
                    string sql = @"UPDATE TB_M_SYSTEM SET [VALUE] = '" + txt_lisence.Text + "' WHERE [NAME] = 'LICENSE'";
                    if (null != ComFunc.ConnectDatabase(sql))
                    {
                        MessageBox.Show(ComFunc.getMessage("M016"));
                        MessageBox.Show(ComFunc.getMessage("M017"));
                        setScreen();
                    }
                }
                else
                {
                    string s_msg = ComFunc.getMessage("M018") + Environment.NewLine +
                                    ComFunc.getMessage("M014") + Environment.NewLine +
                                    ComFunc.getMessage("M015");
                    MessageBox.Show(s_msg);
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1702";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"UPDATE TB_M_SYSTEM SET [VALUE] = '" + cbLogDays.Text + "' WHERE [NAME] = 'LOG_DAYS'";
                if (null == ComFunc.ConnectDatabase(sql))
                {
                    string error_msg = @"System Error E1703";
                    ComFunc.WriteLogLocal(error_msg, "");
                }

                string s_Export = "0";
                if (true == rbExport2.Checked)
                {
                    s_Export = "1";
                }
                ComFunc.setSystemConfig("EXCELCSV", s_Export);

                string s_CSV = "0";
                if (true == rbCSV2.Checked)
                {
                    s_CSV = "1";
                }
                ComFunc.setSystemConfig("CSVLang", s_CSV);

                sql = @"UPDATE TB_M_SYSTEM SET [VALUE] = '" + txt_AddPass.Text + "' WHERE [NAME] = 'AD_PASS'";
                if (null == ComFunc.ConnectDatabase(sql))
                {
                    string error_msg = @"System Error E1704";
                    ComFunc.WriteLogLocal(error_msg, "");
                }

                MessageBox.Show(ComFunc.getMessage("M901"));
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1705";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }
    }
}
