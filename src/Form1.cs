﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using ComFunction;
using Microsoft.VisualBasic.FileIO;

namespace BrightKeeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                ComFunc.s_SystemPath = ConfigurationManager.AppSettings.Get("SystemPath");
                ComFunc.s_CurrentPath = Directory.GetCurrentDirectory();
                if (false == Directory.Exists(ComFunc.s_CurrentPath + "/Log"))
                {
                    Directory.CreateDirectory(ComFunc.s_CurrentPath + "/Log");
                }
                ComFunc.WriteLogLocal("START SYSTEM CLIENT", label6.Text);
                string s_cmd = "SELECT * FROM TB_M_LANGUAGE";
                DataTable dt = ComFunc.ConnectDatabase(s_cmd);
                if (null == dt)
                {
                    MessageBox.Show("Can not access to the Database!!");
                    Environment.Exit(0);
                }
                else
                {
                    setScreen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void setScreen()
        {
            try
            {
                string s_confirm = "1";
                if (true == rdb_NotCinfirm.Checked)
                {
                    s_confirm = "0 OR ACT.CONFIRM_F IS NULL";
                }
                cbb_Lang.SelectedIndex = ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("Language"));
                ComFunc.WriteLogLocal("LOGIN", "SUCCESS");

                ComFunc.checkLicenseKey();
                //ComFunc.deleteHandyLog();  move to BT-SERVER

                string str = @" SELECT 
                                 'Over Order Point' AS [DESC],
                                 ACT.ITEM_ID,
                                 ITEM.ITEM_NAME,
                                 SUM(ACT_STOCK) AS QTY,
                                 ITEM.ORDER_POINT
                                FROM TB_R_ACTSTOCK AS ACT
                                LEFT JOIN TB_M_ITEM AS ITEM
                                ON ACT.ITEM_ID = ITEM.ITEM_ID
                                WHERE ACT.CONFIRM_F = " + s_confirm + "\n" +
                                "GROUP BY ACT.ITEM_ID, ITEM.ITEM_NAME, ITEM.ORDER_POINT";
                DataTable dt = ComFunc.ConnectDatabase(str);
                dataGridView1.Rows.Clear();
                if (null != dt && 0 != dt.Rows.Count)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (ComFunc.ConvertDouble(dr[3].ToString()) <
                            ComFunc.ConvertDouble(dr[4].ToString()))
                        {
                            dataGridView1.Rows.Add(dr[0].ToString(),
                                                    dr[1].ToString(),
                                                    dr[2].ToString(),
                                                    dr[3].ToString(),
                                                    dr[4].ToString()
                                                    );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0101";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_DataView_Click(object sender, EventArgs e)
        {
            DataView f = new DataView();
            f.Show();
        }

        private void btn_DataLog_Click(object sender, EventArgs e)
        {
            DataLog f = new DataLog();
            f.Show();
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            if (true == ComFunc.InputPassword())
            {
                InventoryStock f = new InventoryStock();
                f.Show();
            }
        }

        private void btn_ManualInput_Click(object sender, EventArgs e)
        {
            if (true == ComFunc.InputPassword())
            {
                Manual_Input f = new Manual_Input();
                f.Show();
            }
        }

        private void btn_MasterMain_Click(object sender, EventArgs e)
        {
            if (true == ComFunc.InputPassword())
            {
                MasterMain f = new MasterMain();
                f.Show();
            }
        }

        private void btn_SystemMain_Click(object sender, EventArgs e)
        {
            if (true == ComFunc.InputPassword())
            {
                SystemMain f = new SystemMain();
                f.Show();
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == ComFunc.InputPassword())
                {
                    string s_msg = ComFunc.getMessage("M001");
                    DialogResult result = MessageBox.Show(s_msg,
                        "",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        string s_ItemID = "";
                        foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                        {
                            s_ItemID = r.Cells[1].Value.ToString();
                        }

                        string s_cmd = "UPDATE TB_R_ACTSTOCK SET CONFIRM_F = 1" + "\n" +
                                        "WHERE ITEM_ID = '" + s_ItemID + "'";

                        if (null == ComFunc.ConnectDatabase(s_cmd))
                        {
                            string error_msg = @"System Error E0102";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                        setScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0103";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void cbb_Lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComFunc.setSystemConfig("Language", cbb_Lang.SelectedIndex.ToString());
                ComFunc.Language("Form1.cs", this);
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0104";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void rdb_NotCinfirm_CheckedChanged(object sender, EventArgs e)
        {
            setScreen();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ComFunc.GenerateDatagridview(dataGridView1, "OrderPoint", true);
        }
    }
}
