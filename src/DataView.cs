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
    public partial class DataView : Form
    {
        private string s_search = "";
        private double d_currency = 0;

        public DataView()
        {
            try
            {
                InitializeComponent();
                ComFunc.Language("DataView.cs", this);
                setScreen();
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0301";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private string getWhere()
        {
            string str = "";
            str = getSearch();

            if (false == chk_Zero.Checked)
            {
                if ("" == str)
                {
                    str = " WHERE ACT_STOCK <> 0";
                }
                else
                {
                    str = str + " AND (ACT_STOCK <> 0)";
                }
            }

            return str;
        }

        private string getSearch()
        {
            string str = "";

            if (false == chk_search1.Checked &&
                false == chk_search2.Checked &&
                false == chk_search3.Checked)
            {
                return "";
            }

            if ("" != txtSearch.Text)
            {
                str = str + " WHERE (";
                bool b_first = true;
                if (true == chk_search1.Checked)
                {
                    str = str + "( ACT.ITEM_ID LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                if (true == chk_search2.Checked)
                {
                    if (false == b_first)
                    {
                        str = str + " OR ";
                    }
                    str = str + "( ITEM.ITEM_NAME LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                if (true == chk_search3.Checked)
                {
                    if (false == b_first)
                    {
                        str = str + " OR ";
                    }
                    str = str + "( LOC.LOCATION_NAME LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                str = str + " ) ";
            }

            return str;
        }

        private void setScreen()
        {
            try
            {
                string str = "";
                if (0 == d_currency)
                {
                    str = "SELECT CURRENCY_NAME FROM TB_M_CURRENCY";
                    DataTable dt3 = ComFunc.ConnectDatabase(str);
                    if (null != dt3 && 0 != dt3.Rows.Count)
                    {
                        DataRow InsertRow = dt3.NewRow();
                        dt3.Rows.InsertAt(InsertRow, 0);
                        cmbCurrency.DataSource = dt3;
                        cmbCurrency.DisplayMember = "CURRENCY_NAME";
                        cmbCurrency.ValueMember = "CURRENCY_NAME";
                        cmbCurrency.SelectedIndex = -1;
                        int cnt = 0;
                        foreach (DataRow dr in dt3.Rows)
                        {
                            str = "SELECT RATE FROM TB_M_CURRENCY WHERE CURRENCY_NAME = '" + dr[0] + "'";
                            DataTable dt4 = ComFunc.ConnectDatabase(str);
                            if (null != dt4 && 0 != dt4.Rows.Count)
                            {
                                string s_rate = dt4.Rows[0][0].ToString();
                                if (1 == ComFunc.ConvertDouble(s_rate))
                                {
                                    cmbCurrency.SelectedIndex = cnt;
                                    d_currency = 1;
                                    break;
                                }
                            }
                            cnt++;
                        }
                    }
                }

                str = @"  SELECT L.LOCATION_NAME,COUNT(T.ACT_STOCK) AS REMAIN
  FROM TB_M_LOCATION AS L
  LEFT JOIN TB_R_ACTSTOCK AS T
  ON L.LOCATION_ID = T.LOCATION_ID
  GROUP BY L.LOCATION_ID,L.LOCATION_NAME";
                str = str + getWhere();
                DataTable dt = ComFunc.ConnectDatabase(str);
                double d_totalStock = 0;
                double d_totalAmt = 0;
                if (null != dt)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        d_totalStock = d_totalStock + 1;
                        d_totalAmt = d_totalAmt + ComFunc.ConvertDouble(dr["TOTAL_AMOUNT"].ToString());
                    }

                    dataGridView1.DataSource = dt;
                    dataGridView1.ClearSelection();
                    if (0 != dt.Rows.Count)
                    {
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    }

                    lbl_totalStock.Text = ComFunc.ConvertMoney(d_totalStock);
                    lbl_totalAmt.Text = ComFunc.ConvertMoney(d_totalAmt);
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0302";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = -1;
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    idx = r.Index;
                }
                if (-1 != idx)
                {
                    string s_item = dataGridView1.Rows[idx].Cells[2].Value.ToString();
                    string s_loc = dataGridView1.Rows[idx].Cells[0].Value.ToString();

                    string str = @" SELECT 
                                     RCIS.RCIS_DATE,
                                     RCIS.LOT,
                                     RCIS.RECEIVE_QTY,
                                     RCIS.ISSUE_QTY,
                                     RCIS.RCIS_QTY,
                                     RCIS.RCIS_TYPE,
                                     RCIS.HANDY_SCANNER,
                                     UST.USER_NAME
                                    FROM TB_R_RCIS_RESULT AS RCIS
                                    LEFT JOIN TB_M_USER AS UST
                                    ON RCIS.USER_ID = UST.USER_ID
                                    WHERE  RCIS.ITEM_ID = '" + s_item + "'" +
                                           "AND RCIS.LOCATION_ID = '" + s_loc + "'" +
                                    "ORDER BY RCIS.RCIS_DATE DESC";
                    DataTable dt = ComFunc.ConnectDatabase(str);
                    if (null != dt)
                    {
                        dataGridView2.DataSource = dt;
                        dataGridView2.ClearSelection();
                    }

                    str = @"SELECT
                             RCIS.RCIS_DATE,
                             RCIS.LOT,
                             VEN.VENDOR_NAME,
                             UST.USER_NAME,
                             RCIS.RECEIVE_QTY,
                             RCIS.HANDY_SCANNER,
                             RCIS.REMARKS
                            FROM (TB_R_RCIS_RESULT AS RCIS
                            LEFT JOIN TB_M_VENDOR AS VEN
                            ON RCIS.VENDOR_ID = VEN.VENDOR_ID)
                            LEFT JOIN TB_M_USER AS UST
                            ON RCIS.USER_ID = UST.USER_ID
                            WHERE RCIS.ITEM_ID = '" + s_item + "'" +
                            " AND RCIS.LOCATION_ID = '" + s_loc + "'" +
                            " AND RCIS.RCIS_TYPE = 'REC'" +
                            "ORDER BY RCIS.RCIS_DATE DESC";
                    dt = ComFunc.ConnectDatabase(str);
                    if (null != dt)
                    {
                        dataGridView3.DataSource = dt;
                        dataGridView3.ClearSelection();
                    }

                    str = @"SELECT
                             RCIS.RCIS_DATE,
                             RCIS.LOT,
                             CUS.CUSTOMER_NAME,
                             UST.USER_NAME,
                             RCIS.ISSUE_QTY,
                             RCIS.HANDY_SCANNER,
                             RCIS.REMARKS
                            FROM (TB_R_RCIS_RESULT AS RCIS
                            LEFT JOIN TB_M_CUSTOMER AS CUS
                            ON RCIS.CUSTOMER_ID = CUS.CUSTOMER_ID)
                            LEFT JOIN TB_M_USER AS UST
                            ON RCIS.USER_ID = UST.USER_ID
                            WHERE RCIS.ITEM_ID = '" + s_item + "'" +
                            "AND RCIS.LOCATION_ID = '" + s_loc + "'" +
                            "AND RCIS.RCIS_TYPE = 'ISS'" +
                            "ORDER BY RCIS.RCIS_DATE DESC";
                    dt = ComFunc.ConnectDatabase(str);
                    if (null != dt)
                    {
                        dataGridView4.DataSource = dt;
                        dataGridView4.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0303";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            s_search = txtSearch.Text;
            setScreen();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            s_search = txtSearch.Text;
            setScreen();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            setScreen();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ComFunc.GenerateDatagridview(dataGridView1, "PartsList", true);
        }

        private void btn_excel2_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    ComFunc.GenerateDatagridview(dataGridView2, "REC_ISS", true);
                    break;
                case 1:
                    ComFunc.GenerateDatagridview(dataGridView3, "Receive", true);
                    break;
                case 2:
                    ComFunc.GenerateDatagridview(dataGridView4, "Issue", true);
                    break;
                default:
                    break;
            }
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "SELECT RATE FROM TB_M_CURRENCY WHERE CURRENCY_NAME = '" + cmbCurrency.SelectedValue + "'";
            DataTable dt = ComFunc.ConnectDatabase(str);
            if (null != dt && 0 != dt.Rows.Count)
            {
                string s_rate = dt.Rows[0][0].ToString();
                d_currency = ComFunc.ConvertDouble(s_rate);
                dataGridView1.Focus();
                setScreen();
            }
        }

        private void chk_Zero_CheckedChanged(object sender, EventArgs e)
        {
            setScreen();
        }
    }
}
