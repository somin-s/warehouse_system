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

namespace BrightKeeper
{
    public partial class Master_Vendor : Form
    {
        private string s_selected = "";
        private string s_selectedBak = "";

        public Master_Vendor()
        {
            InitializeComponent();
            ComFunc.Language("Master_Vendor.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
                string str = "SELECT VENDOR_ID,VENDOR_NAME FROM TB_M_VENDOR";
                if (true == chb_id.Checked
                    || true == chb_name.Checked)
                {
                    str = str + " WHERE ";
                    bool b_first = true;
                    if (true == chb_id.Checked)
                    {
                        str = str + " VENDOR_ID LIKE '%" + txtSearch.Text + "%'";
                        b_first = false;
                    }
                    if (true == chb_name.Checked)
                    {
                        if (false == b_first)
                        {
                            str = str + " OR ";
                        }
                        str = str + " VENDOR_NAME LIKE '%" + txtSearch.Text + "%'";
                        b_first = false;
                    }
                }
                DataTable dt = ComFunc.ConnectDatabase(str);
                if (null != dt)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.ClearSelection();
                    lbl_Cnt.Text = dt.Rows.Count.ToString();
                    if (0 != dt.Rows.Count)
                    {
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    }
                }
                selectData();
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1501";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectData();
        }

        private void selectData()
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                s_selected = r.Cells[0].Value.ToString();
                txtID.Text = r.Cells[0].Value.ToString();
                txtName.Text = r.Cells[1].Value.ToString();

            }
        }

        private void selectAgain()
        {
            if ("" != s_selectedBak)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (s_selectedBak == dataGridView1[0, row.Index].Value.ToString())
                    {
                        dataGridView1[0, row.Index].Selected = true;
                    }
                }
                s_selectedBak = "";
            }
        }

        private void EnableChanged(bool b_data)
        {
            if (true == b_data)
            {
                gpDetail.Enabled = false;
                gpDetail.BackColor = Color.LightGray;
                gpData.Enabled = true;
            }
            else
            {
                gpDetail.Enabled = true;
                gpDetail.BackColor = Color.LightPink;
                gpData.Enabled = false;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            EnableChanged(false);
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            EnableChanged(false);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if ("" != s_selected)
                {
                    DialogResult result = MessageBox.Show(ComFunc.getMessage("M904"),
                        "",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        string s_SQL = "DELETE FROM TB_M_VENDOR" +
                                        " WHERE VENDOR_ID = '" + s_selected + "'";
                        if (null == ComFunc.ConnectDatabase(s_SQL))
                        {
                            string error_msg = @"System Error E1502";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                        setScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1503";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            s_selected = "";
            txtID.Text = "";
            txtName.Text = "";
            gpDetail.Enabled = true;
            dataGridView1.ClearSelection();
            EnableChanged(false);
            txtID.Focus();
        }

        private bool checkInput()
        {
            string error_msg = "";

            // check duplicate number.
            string str = "SELECT * FROM TB_M_VENDOR WHERE VENDOR_ID = '" + txtID.Text + "'";
            DataTable dt = ComFunc.ConnectDatabase(str);
            if ("" == s_selected)
            {
                // new mode.
                if (null == dt || 0 != dt.Rows.Count)
                {
                    MessageBox.Show(ComFunc.getMessage("E002"));
                    txtID.Focus();
                    return false;
                }
            }
            else
            {
                // edit mode.
                if (s_selected != txtID.Text)
                {
                    if (null == dt || 0 != dt.Rows.Count)
                    {
                        MessageBox.Show(ComFunc.getMessage("E002"));
                        txtID.Focus();
                        return false;
                    }
                }
            }

            // check blank.
            if ("" == txtID.Text)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                txtID.Focus();
                return false;
            }
            else if ("" == txtName.Text)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == checkInput())
                {
                    if ("" == s_selected)
                    {
                        // new mode.
                        string s_cmd = "INSERT INTO TB_M_VENDOR VALUES( " + "\n" +
                                       "'" + txtID.Text + "',\n" +
                                       "'" + txtName.Text + "',\n" +
                                       "'" + DateTime.Now + "',\n" +
                                       "'9999',\n" +
                                       "'" + DateTime.Now + "',\n" +
                                       "'9999')";
                        if (null == ComFunc.ConnectDatabase(s_cmd))
                        {
                            string error_msg = @"System Error E1504";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                    }
                    else
                    {
                        // edit mode.
                        string s_cmd = "UPDATE TB_M_VENDOR SET " + "\n" +
                                       " VENDOR_ID = '" + txtID.Text + "',\n" +
                                       " VENDOR_NAME = '" + txtName.Text + "',\n" +
                                       " UPDATE_DATE = '" + DateTime.Now + "',\n" +
                                       " UPDATE_BY = '9999'\n" +
                                       " WHERE VENDOR_ID = '" + s_selected + "'";
                        if (null == ComFunc.ConnectDatabase(s_cmd))
                        {
                            string error_msg = @"System Error E1505";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                    }
                    s_selectedBak = txtID.Text;
                    setScreen();
                    EnableChanged(true);
                    selectAgain();
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1506";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            EnableChanged(true);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            EnableChanged(true);
            dataGridView1.ClearSelection();
            setScreen();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            chb_id.Checked = true;
            chb_name.Checked = true;

            EnableChanged(true);
            dataGridView1.ClearSelection();
            setScreen();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ComFunc.GenerateDatagridview(dataGridView1, "VendorMaster", true);
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            ComFunc.ImportDatagridviewEXCEL(dataGridView1, "TB_M_VENDOR");
            setScreen();
        }
    }
}
