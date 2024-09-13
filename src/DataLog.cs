using System;
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
using Microsoft.VisualBasic.FileIO;

namespace BrightKeeper
{
    public partial class DataLog : Form
    {
        public DataLog()
        {
            try
            {
                InitializeComponent();
                ComFunc.Language("DataLog.cs", this);

                ut_from.Value = null;
                ut_to.Value = null;
                setScreen();
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0201";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private string getWhere()
        {
            string str = "";

            DateTime dtFrom;
            DateTime dtTo;
            if (null != ut_from.Value)
            {
                dtFrom = (DateTime)ut_from.Value;
            }
            else
            {
                dtFrom = new DateTime(1900, 1, 1);
            }
            if (null != ut_to.Value)
            {
                dtTo = (DateTime)ut_to.Value;
            }
            else
            {
                dtTo = new DateTime(2100, 1, 1);
            }

            if (dtFrom <= dtTo)
            {
				if("MSACCESS" == ConfigurationManager.AppSettings.Get("DBTYPE"))
				{
	                str = " AND (SCAN_DATE >= #" + dtFrom.ToString(ConfigurationManager.AppSettings.Get("DTformat"), System.Globalization.DateTimeFormatInfo.InvariantInfo) + "#\n" +
	                        " AND SCAN_DATE <= #" + dtTo.AddDays(1).ToString(ConfigurationManager.AppSettings.Get("DTformat"), System.Globalization.DateTimeFormatInfo.InvariantInfo) + "#)";
				}
				else
				{
	                str = " AND (SCAN_DATE >= '" + dtFrom.ToString(ConfigurationManager.AppSettings.Get("DTformat"), System.Globalization.DateTimeFormatInfo.InvariantInfo) + "'\n" +
	                        " AND SCAN_DATE <= '" + dtTo.AddDays(1).ToString(ConfigurationManager.AppSettings.Get("DTformat"), System.Globalization.DateTimeFormatInfo.InvariantInfo) + "')";
				}
            }

            return str;
        }

        private void setScreen()
        {
            try
            {
                string BaseStr1 = @" SELECT
                                     SCAN_DATE,
                                     USR.USER_NAME,
                                     LOC1.LOCATION_NAME AS [LOCATION_NAME],";

                string BaseStr2 = @" LOC2.LOCATION_NAME AS [LOCATION_NAME2],";

                string BaseStr3 = @" LOT,";
                string BaseStr4 = @" QTY,
                                     ITM.ITEM_NAME,
                                     HANDY,
                                     TR_NO,
                                     [ID]
                                    FROM
                                    (((TB_R_HANDY_LOG AS HLG
                                    LEFT JOIN TB_M_USER AS USR
                                    ON HLG.OPERATOR = USR.USER_ID)
                                    LEFT JOIN TB_M_LOCATION AS LOC1
                                    ON HLG.LOCATION1 = LOC1.LOCATION_ID)
                                    LEFT JOIN TB_M_LOCATION AS LOC2
                                    ON HLG.LOCATION2 = LOC2.LOCATION_ID)
                                    LEFT JOIN TB_M_ITEM AS ITM
                                    ON HLG.ITEM = ITM.ITEM_ID
                                    WHERE HLG.TYPE = ";
                string BaseWhere = getWhere();
                string BaseOrder = "\r\n ORDER BY HLG.SCAN_DATE DESC";

                string str1 = BaseStr1 + BaseStr3 + BaseStr4 + "0" + BaseWhere + BaseOrder;
                DataTable dt = ComFunc.ConnectDatabase(str1);
                if (null != dt)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.ClearSelection();
                    lbl_Cnt1.Text = ComFunc.ConvertMoney(dt.Rows.Count);
                }
                string str2 = BaseStr1 + BaseStr3 + BaseStr4 + "1" + BaseWhere + BaseOrder;
                dt = ComFunc.ConnectDatabase(str2);
                if (null != dt)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.ClearSelection();
                    lbl_Cnt2.Text = ComFunc.ConvertMoney(dt.Rows.Count);
                }
                string str3 = BaseStr1 + BaseStr3 + BaseStr4 + "2" + BaseWhere + BaseOrder;
                dt = ComFunc.ConnectDatabase(str3);
                if (null != dt)
                {
                    dataGridView3.DataSource = dt;
                    dataGridView3.ClearSelection();
                    lbl_Cnt3.Text = ComFunc.ConvertMoney(dt.Rows.Count);
                }
                string str4 = BaseStr1 + BaseStr2 + BaseStr3 + BaseStr4 + "3" + BaseWhere + BaseOrder;
                dt = ComFunc.ConnectDatabase(str4);
                if (null != dt)
                {
                    dataGridView4.DataSource = dt;
                    dataGridView4.ClearSelection();
                    lbl_Cnt4.Text = ComFunc.ConvertMoney(dt.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0202";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            setScreen();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            setScreen();
        }

        private void DeleteTransaction(string s_id, string s_tr_no, double d_qty)
        {
            string s_SQL = "DELETE FROM TB_R_HANDY_LOG" +
                            " WHERE [ID] = " + s_id;
            if (null != ComFunc.ConnectDatabase(s_SQL))
            {
                string error_msg = @"System Error E0203";
                ComFunc.WriteLogLocal(error_msg, "");
            }

            if (0 != d_qty)
            {
                s_SQL = "DELETE FROM TB_R_HANDY_LOG" +
                        " WHERE [ID] = " + s_id;
            }

            setScreen();
        }

        private void btn_delete1_Click(object sender, EventArgs e)
        {
            string s_tr_no = "";
            string s_id = "";
            double d_qty = 0;
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                d_qty = ComFunc.ConvertDouble(r.Cells[4].ToString());
                s_tr_no = r.Cells[6].ToString();
                s_id = r.Cells[7].ToString();
            }
            if ("" != s_tr_no)
            {
                DeleteTransaction(s_id, s_tr_no, d_qty);
            }
        }

        private void btn_delete2_Click(object sender, EventArgs e)
        {
            string s_tr_no = "";
            string s_id = "";
            double d_qty = 0;
            foreach (DataGridViewRow r in dataGridView2.SelectedRows)
            {
                d_qty = ComFunc.ConvertDouble(r.Cells[4].ToString());
                s_tr_no = r.Cells[6].ToString();
                s_id = r.Cells[7].ToString();
            }
            if ("" != s_tr_no)
            {
                DeleteTransaction(s_id, s_tr_no, d_qty);
            }
        }

        private void btn_delete3_Click(object sender, EventArgs e)
        {
            string s_tr_no = "";
            string s_id = "";
            double d_qty = 0;
            foreach (DataGridViewRow r in dataGridView3.SelectedRows)
            {
                d_qty = ComFunc.ConvertDouble(r.Cells[4].ToString());
                s_tr_no = r.Cells[6].ToString();
                s_id = r.Cells[7].ToString();
            }
            if ("" != s_tr_no)
            {
                DeleteTransaction(s_id, s_tr_no, d_qty);
            }
        }

        private void btn_delete4_Click(object sender, EventArgs e)
        {
            string s_tr_no = "";
            string s_id = "";
            double d_qty = 0;
            foreach (DataGridViewRow r in dataGridView4.SelectedRows)
            {
                d_qty = ComFunc.ConvertDouble(r.Cells[4].ToString());
                s_tr_no = r.Cells[6].ToString();
                s_id = r.Cells[7].ToString();
            }
            if ("" != s_tr_no)
            {
                DeleteTransaction(s_id, s_tr_no, d_qty);
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    ComFunc.GenerateDatagridview(dataGridView1, "ReceiveLog", true);
                    break;
                case 1:
                    ComFunc.GenerateDatagridview(dataGridView2, "IssueLog", true);
                    break;
                case 2:
                    ComFunc.GenerateDatagridview(dataGridView3, "InventoryLog", true);
                    break;
                case 3:
                    ComFunc.GenerateDatagridview(dataGridView4, "MoveLog", true);
                    break;
                default:
                    break;
            }
        }
    }
}
