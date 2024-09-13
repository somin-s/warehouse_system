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
    public partial class InventoryStock : Form
    {
        private string s_search = "";

        private int i_InvID = 0;
        public InventoryStock()
        {
            try
            {
                InitializeComponent();
                ComFunc.Language("InventoryStock.cs", this);

                ut_date.Value = null;

                string str = "SELECT USER_ID FROM TB_M_USER";
                DataTable dt = ComFunc.ConnectDatabase(str);
                if (null != dt && 0 != dt.Rows.Count)
                {
                    cbUser.DataSource = dt;
                    cbUser.DisplayMember = "USER_ID";
                    cbUser.ValueMember = "USER_ID";
                    cbUser.SelectedIndex = -1;
                }

                str = "SELECT LOCATION_NAME FROM TB_M_LOCATION";
                dt = ComFunc.ConnectDatabase(str);
                if (null != dt)
                {
                    cb_location.DataSource = dt;
                    cb_location.DisplayMember = "LOCATION_NAME";
                    cb_location.ValueMember = "LOCATION_NAME";
                    cb_location.SelectedIndex = -1;
                }

                setScreen(getInventoryMax());
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0501";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        public int getInventoryMax()
        {
            try
            {
                string s_max = @"SELECT MAX(SEQ_ID) FROM TB_R_INVSTOCK_H";
                DataTable dt = ComFunc.ConnectDatabase(s_max);
                int i_max = 0;
                if (null != dt && 0 != dt.Rows.Count)
                {
                    i_max = ComFunc.ConvertInt(dt.Rows[0][0].ToString());
                }
                return i_max;
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0502";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
                return 0;
            }
        }

        private string getWhere()
        {
            string str = "";

            if (false == chk_search1.Checked && 
                false == chk_search2.Checked && 
                false == chk_search3.Checked && 
                false == chk_search4.Checked)
            {
                return "";
            }

            if ("" != txtSearch.Text)
            {
                str = str + " AND (";
                bool b_first = true;

                if (true == chk_search1.Checked)
                {
                    if (false == b_first)
                    {
                        str = str + " OR ";
                    }
                    str = str + " ( LOC.LOCATION_ID LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                if (true == chk_search2.Checked)
                {
                    if (false == b_first)
                    {
                        str = str + " OR ";
                    }
                    str = str + " ( LOC.LOCATION_NAME LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                if (true == chk_search3.Checked)
                {
                    if (false == b_first)
                    {
                        str = str + " OR ";
                    }
                    str = str + " ( ITEM.ITEM_ID LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                if (true == chk_search4.Checked)
                {
                    if (false == b_first)
                    {
                        str = str + " OR ";
                    }
                    str = str + " ( ITEM.ITEM_NAME LIKE '%" + txtSearch.Text + "%' )" + "\n";
                    b_first = false;
                }
                str = str + ")";
            }

            return str;
        }
        
        public void setScreen(int seqID)
        {
            try
            {
                double d_total = 0;
                if (0 != seqID)
                {
                    string sql = @"SELECT USER_ID,INVENTORY_DATE,REMARKS,REFLECT_F FROM TB_R_INVSTOCK_H WHERE SEQ_ID = " + seqID.ToString();
                    DataTable dt = ComFunc.ConnectDatabase(sql);
                    if (null != dt && 0 != dt.Rows.Count)
                    {
                        lbl_UserName.Text = "";
                        cbUser.Text = dt.Rows[0][0].ToString();
                        ut_date.Value = ComFunc.ConvertDate(dt.Rows[0][1].ToString());
                        txtRemarks.Text = dt.Rows[0][2].ToString();
                        if ("1" == dt.Rows[0][3].ToString())
                        {
                            // already reflect.
                            dataGridView1.Columns[5].ReadOnly = true;
                            dataGridView1.ClearSelection();
                            cbUser.Enabled = false;
                            txtRemarks.Enabled = false;
                            btn_save.Enabled = false;
                            btn_reflect.Enabled = false;
                            btn_barcode.Enabled = false;
                            btn_insert.Enabled = false;
                            btn_delete.Enabled = false;

                            string s_msg = ComFunc.getMessage("M002");
                            MessageBox.Show(s_msg);
                        }
                        else
                        {
                            dataGridView1.Columns[5].ReadOnly = false;
                            cbUser.Enabled = true;
                            txtRemarks.Enabled = true;
                            btn_save.Enabled = true;
                            btn_reflect.Enabled = true;
                            btn_barcode.Enabled = true;
                            btn_insert.Enabled = true;
                            btn_delete.Enabled = true;
                        }
                    }

                    sql = @" SELECT
                                 LOC.LOCATION_ID,
                                 LOC.LOCATION_NAME,
                                 ITEM.ITEM_ID,
                                 ITEM.ITEM_NAME,
                                 UNIT.UNIT_NAME,
                                 INV.INVENTORY_QTY,
                                 INV.SYS_INVENTORY_QTY,
                                 (INV.INVENTORY_QTY - INV.SYS_INVENTORY_QTY) AS DIFF_QTY,
                                 INV.HANDY_SCANNER,
                                 USRT.USER_NAME
                                FROM (((TB_R_INVSTOCK_D AS INV
                                LEFT JOIN TB_M_LOCATION AS LOC
                                ON INV.LOCATION_ID = LOC.LOCATION_ID)
                                LEFT JOIN TB_M_ITEM AS ITEM
                                ON INV.ITEM_ID = ITEM.ITEM_ID)
                                LEFT JOIN TB_M_UNIT AS UNIT
                                ON ITEM.UNIT_ID = UNIT.UNIT_ID)
                                LEFT JOIN TB_M_USER AS USRT
                                ON INV.USER_ID = USRT.USER_ID WHERE INVENTORY_NO = " + seqID.ToString() + getWhere();
                    dt = ComFunc.ConnectDatabase(sql);
                    dataGridView1.Rows.Clear();
                    if (null != dt && 0 != dt.Rows.Count)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            dataGridView1.Rows.Add(dr[0].ToString(),
                                                    dr[1].ToString(),
                                                    dr[2].ToString(),
                                                    dr[3].ToString(),
                                                    dr[4].ToString(),
                                                    dr[5].ToString(),
                                                    dr[6].ToString(),
                                                    dr[7].ToString(),
                                                    dr[8].ToString(),
                                                    dr[9].ToString()
                                                    );
                            d_total = d_total + ComFunc.ConvertDouble(dr[6].ToString());
                        }
                    }
                    i_InvID = seqID;
                }
                lbl_totalStock.Text = ComFunc.ConvertMoney(d_total);
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0503";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            try
            {
                string s_msg = ComFunc.getMessage("M003");
                DialogResult result = MessageBox.Show(s_msg,
                    "",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                if (null == ut_date.Value || "" == ut_date.Value.ToString())
                {
                    ut_date.Focus();
                    MessageBox.Show(ComFunc.getMessage("E001"));
                    return;
                }

                cbUser.Text = "";
                txtRemarks.Text = "";
                string sql = @"INSERT INTO TB_R_INVSTOCK_H (
                            USER_ID,
                            INVENTORY_DATE,
                            REFLECT_F,
                            REMARKS,
                            UPDATE_DATE,
                            UPDATE_BY,
                            CREATE_DATE,
                            CREATE_BY
                            )VALUES(" +
                                "'" + cbUser.Text + "',\n" +
                                "'" + ut_date.Value + "',\n" +
                                "'0'," +
                                "'" + txtRemarks.Text + "',\n" +
                                "'" + DateTime.Now + "',\n" +
                                "'9999',\n" +
                                "'" + DateTime.Now + "',\n" +
                                "'9999')";
                if (null == ComFunc.ConnectDatabase(sql))
                {
                    string error_msg = @"System Error E5004";
                    ComFunc.WriteLogLocal(error_msg, ""); 
                    return;
                }
                int seqID = getInventoryMax();

                sql = "SELECT ITEM_ID,LOCATION_ID,ACT_STOCK FROM TB_R_ACTSTOCK";
                DataTable dt = ComFunc.ConnectDatabase(sql);
                if (null != dt && 0 != dt.Rows.Count && 0 != seqID)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sql = @"INSERT INTO TB_R_INVSTOCK_D (
                                INVENTORY_NO,
                                LOCATION_ID,
                                ITEM_ID,
                                SYS_INVENTORY_QTY,
                                UPDATE_DATE,
                                UPDATE_BY,
                                CREATE_DATE,
                                CREATE_BY
                            )VALUES(" +
                                    seqID.ToString() + ",\n" +
                                    "'" + dr[1].ToString() + "',\n" +
                                    "'" + dr[0].ToString() + "',\n" +
                                    dr[2].ToString() + ",\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'9999',\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'9999')";
                        if (null == ComFunc.ConnectDatabase(sql))
                        {
                            string error_msg = @"System Error E5005";
                            ComFunc.WriteLogLocal(error_msg, "");
                            return;
                        }
                    }
                }

                MessageBox.Show(ComFunc.getMessage("M004"));

                setScreen(seqID);
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0506";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "SELECT USER_NAME FROM TB_M_USER WHERE USER_ID = '" + cbUser.Text + "'";
                DataTable dt = ComFunc.ConnectDatabase(str);
                if (null != dt && 0 != dt.Rows.Count)
                {
                    lbl_UserName.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl_UserName.Text = "";
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0507";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if ("" == cb_location.Text)
            {
                MessageBox.Show(ComFunc.getMessage("M019"));
                cb_location.Focus();
                return;
            }

            Master_Item.i_mode = Master_Item.MODE_SEARCH4;
            Master_Item f = new Master_Item();
            f.f4 = this;
            f.s_InvLoc = cb_location.Text;
            f.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string s_msg = ComFunc.getMessage("M005");
                DialogResult result = MessageBox.Show(s_msg,
                    "",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if (true == c.Selected)
                        {
                            dataGridView1.Rows.Remove(r);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0508";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            InventoryHistory f = new InventoryHistory();
            f.f1 = this;
            f.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            s_search = txtSearch.Text;
            setScreen(i_InvID);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            s_search = txtSearch.Text;
            setScreen(i_InvID);
        }

        private void btn_reflect_Click(object sender, EventArgs e)
        {
            try
            {
                string s_msg = ComFunc.getMessage("M006");
                DialogResult result = MessageBox.Show(s_msg,
                    "",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                saveData();

                string sql = @" SELECT
                             ITEM_ID,
                             LOCATION_ID,
                             INVENTORY_QTY
                        FROM TB_R_INVSTOCK_D
                        WHERE INVENTORY_NO = " + i_InvID.ToString();
                DataTable dt = ComFunc.ConnectDatabase(sql);
                dataGridView1.Rows.Clear();
                if (null != dt && 0 != dt.Rows.Count)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ("" != dr[2].ToString().Trim())
                        {
                            ComFunc.setInventoryStock(dr[0].ToString(),
                                                        dr[1].ToString(),
                                                        ComFunc.ConvertDouble(dr[2].ToString()));
                        }
                    }
                }

                sql = "UPDATE TB_R_INVSTOCK_H SET " + "\n" +
                        " REFLECT_F = 1,\n" +
                        " UPDATE_DATE = '" + DateTime.Now + "',\n" +
                        " UPDATE_BY = '9999'\n" +
                        " WHERE SEQ_ID = " + i_InvID.ToString();
                if (null == ComFunc.ConnectDatabase(sql))
                {
                    string error_msg = @"System Error E5009";
                    ComFunc.WriteLogLocal(error_msg, "");
                }

                sql = "UPDATE TB_R_HANDY_LOG SET INVENTORY = 1";
                if (null == ComFunc.ConnectDatabase(sql))
                {
                    string error_msg = @"System Error E5010";
                    ComFunc.WriteLogLocal(error_msg, "");
                }

                s_msg = ComFunc.getMessage("M007");
                MessageBox.Show(s_msg);
                
                setScreen(i_InvID);
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0511";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void saveData()
        {
            try
            {
                string sql = "UPDATE TB_R_INVSTOCK_H SET " + "\n" +
                                " INVENTORY_DATE = '" + ut_date.Value + "',\n" +
                                " USER_ID = '" + cbUser.Text + "',\n" +
                                " REMARKS = '" + txtRemarks.Text + "',\n" +
                                " UPDATE_DATE = '" + DateTime.Now + "',\n" +
                                " UPDATE_BY = '9999'\n" +
                                " WHERE SEQ_ID = " + i_InvID.ToString();
                if (null == ComFunc.ConnectDatabase(sql))
                {
                    string error_msg = @"System Error E5012";
                    ComFunc.WriteLogLocal(error_msg, "");
                    return;
                }

                sql = @" DELETE FROM TB_R_INVSTOCK_D WHERE INVENTORY_NO = " + i_InvID.ToString();
                if (null != ComFunc.ConnectDatabase(sql))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string s_INVENTORY_QTY = row.Cells[5].Value.ToString();
                        string s_SYS_INVENTORY_QTY = row.Cells[6].Value.ToString();
                        if ("" == s_INVENTORY_QTY)
                        {
                            s_INVENTORY_QTY = "NULL";
                        }
                        if ("" == s_SYS_INVENTORY_QTY)
                        {
                            s_SYS_INVENTORY_QTY = "NULL";
                        }

                        sql = @"INSERT INTO TB_R_INVSTOCK_D (
                                INVENTORY_NO,
                                LOCATION_ID,
                                ITEM_ID,
                                INVENTORY_QTY,
                                SYS_INVENTORY_QTY,
                                HANDY_SCANNER,
                                USER_ID,
                                UPDATE_DATE,
                                UPDATE_BY,
                                CREATE_DATE,
                                CREATE_BY
                            )VALUES(" +
                                    i_InvID.ToString() + ",\n" +
                                    "'" + row.Cells[0].Value.ToString() + "',\n" +
                                    "'" + row.Cells[2].Value.ToString() + "',\n" +
                                    s_INVENTORY_QTY + ",\n" +
                                    s_SYS_INVENTORY_QTY + ",\n" +
                                    "'" + row.Cells[8].Value.ToString() + "',\n" +
                                    "'" + ComFunc.Get_UserID(row.Cells[9].Value.ToString()) + "',\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'9999',\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'9999')";
                        if (null == ComFunc.ConnectDatabase(sql))
                        {
                            string error_msg = @"System Error E5013";
                            ComFunc.WriteLogLocal(error_msg, "");
                            return;
                        }
                    }
                    string s_msg = ComFunc.getMessage("M901");
                    MessageBox.Show(s_msg);
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0514";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_barcode_Click(object sender, EventArgs e)
        {
            try
            {
                string s_msg = ComFunc.getMessage("M008");
                DialogResult result = MessageBox.Show(s_msg,
                    "",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string sql = @" SELECT HLOG.QTY, HLOG.HANDY, USR.USER_NAME
                                    FROM TB_R_HANDY_LOG AS HLOG
                                    LEFT JOIN TB_M_USER AS USR
                                    ON HLOG.OPERATOR = USR.USER_ID
                                    WHERE HLOG.TYPE = 2 AND 
                                    HLOG.ITEM = '" + dr.Cells[2].Value + "' AND " +
                                 @" HLOG.LOCATION1 = '" + dr.Cells[0].Value + "' " +
                                 @" ORDER BY HLOG.SCAN_DATE DESC ";
                    DataTable dt = ComFunc.ConnectDatabase(sql);
                    if (null != dt && 0 != dt.Rows.Count)
                    {
                        int i_qty = ComFunc.ConvertInt(dt.Rows[0][0].ToString());
                        int i_stock = ComFunc.ConvertInt(dr.Cells[6].Value.ToString());
                        dr.Cells[5].Value = i_qty.ToString();
                        dr.Cells[7].Value = (i_qty - i_stock).ToString();
                        dr.Cells[8].Value = dt.Rows[0][1].ToString();
                        dr.Cells[9].Value = dt.Rows[0][2].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0515";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ComFunc.GenerateDatagridview(dataGridView1, "Inventory", true);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string s_INVENTORY_QTY = row.Cells[5].Value.ToString();
                string s_SYS_INVENTORY_QTY = row.Cells[6].Value.ToString();
                if ("" != s_INVENTORY_QTY)
                {
                    int i_def = ComFunc.ConvertInt(s_INVENTORY_QTY) - ComFunc.ConvertInt(s_SYS_INVENTORY_QTY);
                    row.Cells[5].Value = ComFunc.ConvertInt(s_INVENTORY_QTY).ToString();
                    row.Cells[7].Value = i_def.ToString();
                }
            }
        }
    }
}
