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
    public partial class Master_Item : Form
    {
        private string s_selected = "";
        private string s_selectedBak = "";
        public const int MODE_MASTER = 0;
        public const int MODE_SEARCH1 = 1;
        public const int MODE_SEARCH2 = 2;
        public const int MODE_SEARCH3 = 3;
        public const int MODE_SEARCH4 = 4;
        public const int MODE_SEARCH5 = 5;
        public const int MODE_SEARCH6 = 6;
        public const int MODE_SEARCH7 = 7;
        public Manual_Issue f1;
        public Manual_Move f2;
        public Manual_Receive f3;
        public InventoryStock f4;
        //public Manual_Issue2 f5;
        //public Manual_Move2 f6;
        public Manual_Receive2 f7;
        public string s_InvLoc = "";

        private static int _i_mode = MODE_MASTER;
        public static int i_mode
        {
            set { _i_mode = value; }
            get { return _i_mode; }
        }

        public Master_Item()
        {
            InitializeComponent();
            ComFunc.Language("Master_Item.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
                if (MODE_MASTER == i_mode)
                {
                    btn_save.Visible = true;
                    btn_cancel.Visible = true;
                    btn_delete.Visible = true;
                    btn_new.Visible = true;
                }
                else
                {
                    btn_save.Visible = false;
                    btn_cancel.Visible = false;
                    btn_delete.Visible = false;
                    btn_new.Visible = false;
                }

                string str = "SELECT UNIT_NAME FROM TB_M_UNIT";
                DataTable dt1 = ComFunc.ConnectDatabase(str);
                if (null != dt1)
                {
                    DataRow InsertRow = dt1.NewRow();
                    dt1.Rows.InsertAt(InsertRow, 0);
                    cmbUnit.DataSource = dt1;
                    cmbUnit.DisplayMember = "UNIT_NAME";
                    cmbUnit.ValueMember = "UNIT_NAME";
                    cmbUnit.SelectedIndex = -1;
                }

                str = "SELECT CUSTOMER_NAME FROM TB_M_CUSTOMER";
                DataTable dt2 = ComFunc.ConnectDatabase(str);
                if (null != dt2)
                {
                    DataRow InsertRow = dt2.NewRow();
                    dt2.Rows.InsertAt(InsertRow, 0);
                    cmbCustomerName.DataSource = dt2;
                    cmbCustomerName.DisplayMember = "CUSTOMER_NAME";
                    cmbCustomerName.ValueMember = "CUSTOMER_NAME";
                    cmbCustomerName.SelectedIndex = -1;
                }

                str = "SELECT VENDOR_NAME FROM TB_M_VENDOR";
                DataTable dt3 = ComFunc.ConnectDatabase(str);
                if (null != dt3)
                {
                    DataRow InsertRow = dt3.NewRow();
                    dt3.Rows.InsertAt(InsertRow, 0);
                    cmb_vendor.DataSource = dt3;
                    cmb_vendor.DisplayMember = "VENDOR_NAME";
                    cmb_vendor.ValueMember = "VENDOR_NAME";
                    cmb_vendor.SelectedIndex = -1;
                }

                str = "SELECT CURRENCY_NAME FROM TB_M_CURRENCY";
                DataTable dt4 = ComFunc.ConnectDatabase(str);
                if (null != dt4)
                {
                    DataRow InsertRow = dt4.NewRow();
                    dt4.Rows.InsertAt(InsertRow, 0);
                    cmbCurrency.DataSource = dt4;
                    cmbCurrency.DisplayMember = "CURRENCY_NAME";
                    cmbCurrency.ValueMember = "CURRENCY_NAME";
                    cmbCurrency.SelectedIndex = -1;
                }

                str = "SELECT ITEM_ID,ITEM_NAME,UNIT_NAME,ORDER_POINT,UNIT_AMOUNT,CURRENCY_NAME,VENDOR_NAME,ST_DELIVERY,CUSTOMER_NAME,'PRINT' AS LABEL, REMARK01, REMARK02, REMARK03, REMARK04, REMARK05 FROM" + "\n" +
                                "((TB_M_ITEM LEFT OUTER JOIN TB_M_UNIT" + "\n" +
                                "ON TB_M_ITEM.UNIT_ID = TB_M_UNIT.UNIT_ID)" + "\n" +
                                "LEFT OUTER JOIN TB_M_VENDOR" + "\n" +
                                "ON TB_M_ITEM.VENDOR_ID = TB_M_VENDOR.VENDOR_ID)" + "\n" +
                                "LEFT OUTER JOIN TB_M_CUSTOMER" + "\n" +
                                "ON TB_M_ITEM.CUSTOMER_ID = TB_M_CUSTOMER.CUSTOMER_ID";
                if (true == chb_id.Checked
                    || true == chb_name.Checked)
                {
                    str = str + " WHERE ";
                    bool b_first = true;
                    if (true == chb_id.Checked)
                    {
                        str = str + " ITEM_ID LIKE '%" + txtSearch.Text + "%'";
                        b_first = false;
                    }
                    if (true == chb_name.Checked)
                    {
                        if (false == b_first)
                        {
                            str = str + " OR ";
                        }
                        str = str + " ITEM_NAME LIKE '%" + txtSearch.Text + "%'";
                        b_first = false;
                    }
                }
                DataTable dt5 = ComFunc.ConnectDatabase(str);
                if (null != dt5)
                {
                    dataGridView1.DataSource = dt5;
                    dataGridView1.ClearSelection();
                    lbl_Cnt.Text = dt5.Rows.Count.ToString();
                    if (0 != dt5.Rows.Count)
                    {
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    }
                }

                int PrtItmLblColumnNum = ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("PrtItmLblColumnNum"));
                if ("Y" == ConfigurationManager.AppSettings.Get("PrtItmLbl"))
                {
                    dataGridView1.Columns[PrtItmLblColumnNum].Visible = true;
                }
                else
                {
                    dataGridView1.Columns[PrtItmLblColumnNum].Visible = false;
                }

                if ("" == lblRemark1.Text)
                {
                    txtRemark1.Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                }
                else
                {
                    txtRemark1.Visible = true;
                    dataGridView1.Columns[10].Visible = true;
                }
                if ("" == lblRemark2.Text)
                {
                    txtRemark2.Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                }
                else
                {
                    txtRemark2.Visible = true;
                    dataGridView1.Columns[11].Visible = true;
                }
                if ("" == lblRemark3.Text)
                {
                    txtRemark3.Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                }
                else
                {
                    txtRemark3.Visible = true;
                    dataGridView1.Columns[12].Visible = true;
                }
                if ("" == lblRemark4.Text)
                {
                    txtRemark4.Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                }
                else
                {
                    txtRemark4.Visible = true;
                    dataGridView1.Columns[13].Visible = true;
                }
                if ("" == lblRemark5.Text)
                {
                    txtRemark5.Visible = false;
                    dataGridView1.Columns[14].Visible = false;
                }
                else
                {
                    txtRemark5.Visible = true;
                    dataGridView1.Columns[14].Visible = true;
                }

                selectData();
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1101";
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
                string s_tmp = "";
                cmbUnit.SelectedIndex = -1;
                for (int i = 0; i < cmbUnit.Items.Count; i++)
                {
                    s_tmp = cmbUnit.GetItemText(cmbUnit.Items[i]);
                    if (s_tmp == r.Cells[2].Value.ToString())
                    {
                        cmbUnit.SelectedIndex = i;
                        break;
                    }
                }
                txtOrder.Text = r.Cells[3].Value.ToString();
                txtUnitAmt.Text = r.Cells[4].Value.ToString();

                cmbCurrency.SelectedIndex = -1;
                lblRate.Text = "";
                for (int i = 0; i < cmbCurrency.Items.Count; i++)
                {
                    s_tmp = cmbCurrency.GetItemText(cmbCurrency.Items[i]);
                    if (s_tmp == r.Cells[5].Value.ToString())
                    {
                        cmbCurrency.SelectedIndex = i;
                        break;
                    }
                }
                cmb_vendor.SelectedIndex = -1;
                for (int i = 0; i < cmb_vendor.Items.Count; i++)
                {
                    s_tmp = cmb_vendor.GetItemText(cmb_vendor.Items[i]);
                    if (s_tmp == r.Cells[6].Value.ToString())
                    {
                        cmb_vendor.SelectedIndex = i;
                        break;
                    }
                }

                txtSTDelivery.Text = r.Cells[7].Value.ToString();
                
                cmbCustomerName.SelectedIndex = -1;
                for (int i = 0; i < cmbCustomerName.Items.Count; i++)
                {
                    s_tmp = cmbCustomerName.GetItemText(cmbCustomerName.Items[i]);
                    if (s_tmp == r.Cells[8].Value.ToString())
                    {
                        cmbCustomerName.SelectedIndex = i;
                        break;
                    }
                }

                txtRemark1.Text = r.Cells[10].Value.ToString();
                txtRemark2.Text = r.Cells[11].Value.ToString();
                txtRemark3.Text = r.Cells[12].Value.ToString();
                txtRemark4.Text = r.Cells[13].Value.ToString();
                txtRemark5.Text = r.Cells[14].Value.ToString();
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

        private void selectItem()
        {
            switch (i_mode)
            {
                case MODE_MASTER:
                    EnableChanged(false);
                    break;
                case MODE_SEARCH1:
                    if (null != f1)
                    {
                        TextBox t1 = f1.Controls.Find("txtItemID", true).FirstOrDefault() as TextBox;
                        if (null != t1)
                        {
                            string s_selected = "";
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                s_selected = r.Cells[0].Value.ToString();
                            }
                            t1.Text = s_selected;
                        }
                    }
                    Close();
                    break;
                case MODE_SEARCH2:
                    if (null != f2)
                    {
                        TextBox t1 = f2.Controls.Find("txtItemID", true).FirstOrDefault() as TextBox;
                        if (null != t1)
                        {
                            string s_selected = "";
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                s_selected = r.Cells[0].Value.ToString();
                            }
                            t1.Text = s_selected;
                        }
                    }
                    Close();
                    break;
                case MODE_SEARCH3:
                    if (null != f3)
                    {
                        TextBox t1 = f3.Controls.Find("txtItemID", true).FirstOrDefault() as TextBox;
                        if (null != t1)
                        {
                            string s_selected = "";
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                s_selected = r.Cells[0].Value.ToString();
                            }
                            t1.Text = s_selected;
                        }
                    }
                    Close();
                    break;
                case MODE_SEARCH4:
                    if (null != f4)
                    {
                        DataGridView t1 = f4.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;
                        if (null != t1)
                        {
                            string s_selectedID = "";
                            string s_selectedName = "";
                            string s_selectedUnit = "";
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                s_selectedID = r.Cells[0].Value.ToString();
                                s_selectedName = r.Cells[1].Value.ToString();
                                s_selectedUnit = r.Cells[2].Value.ToString();
                            }
                            t1.Rows.Add(ComFunc.Get_LocationID(s_InvLoc), s_InvLoc, s_selectedID, s_selectedName,
                                            s_selectedUnit, "", "", "", "", "");
                        }
                    }
                    Close();
                    break;
                //case MODE_SEARCH5:
                //    if (null != f5)
                //    {
                //        TextBox t1 = f5.Controls.Find("txtItemID", true).FirstOrDefault() as TextBox;
                //        if (null != t1)
                //        {
                //            string s_selected = "";
                //            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                //            {
                //                s_selected = r.Cells[0].Value.ToString();
                //            }
                //            t1.Text = s_selected;
                //        }
                //    }
                //    Close();
                //    break;
                //case MODE_SEARCH6:
                //    if (null != f6)
                //    {
                //        TextBox t1 = f6.Controls.Find("txtItemID", true).FirstOrDefault() as TextBox;
                //        if (null != t1)
                //        {
                //            string s_selected = "";
                //            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                //            {
                //                s_selected = r.Cells[0].Value.ToString();
                //            }
                //            t1.Text = s_selected;
                //        }
                //    }
                //    Close();
                //    break;
                case MODE_SEARCH7:
                    if (null != f7)
                    {
                        TextBox t1 = f7.Controls.Find("txtItemID", true).FirstOrDefault() as TextBox;
                        if (null != t1)
                        {
                            string s_selected = "";
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            {
                                s_selected = r.Cells[0].Value.ToString();
                            }
                            t1.Text = s_selected;
                        }
                    }
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectItem();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            selectItem();
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
                        string s_SQL = "DELETE FROM TB_M_ITEM" +
                                        " WHERE ITEM_ID = '" + s_selected + "'";
                        if (null == ComFunc.ConnectDatabase(s_SQL))
                        {
                            string error_msg = @"System Error E1102";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                        setScreen();
                        ComFunc.updateUpdateMaster(1);
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1103";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            int ItemNum = dataGridView1.Rows.Count;
            if (8 < ItemNum)
            {
                if (false == ComFunc.checkAct())
                {
                    string s_msg = ComFunc.getMessage("M013") + Environment.NewLine +
                                    ComFunc.getMessage("M014") + Environment.NewLine +
                                    ComFunc.getMessage("M015");
                    MessageBox.Show(s_msg);
                    return;
                }
            }

            s_selected = "";
            txtID.Text = "";
            txtName.Text = "";
            cmbUnit.SelectedIndex = -1;
            cmbCurrency.SelectedIndex = -1;
            cmb_vendor.SelectedIndex = -1;
            txtSTDelivery.Text = "";
            cmbCustomerName.SelectedIndex = -1;
            txtOrder.Text = "";
            txtUnitAmt.Text = "";
            lblRate.Text = "";
            txtRemark1.Text = "";
            txtRemark2.Text = "";
            txtRemark3.Text = "";
            txtRemark4.Text = "";
            txtRemark5.Text = "";
            gpDetail.Enabled = true;
            dataGridView1.ClearSelection();
            EnableChanged(false);
            txtID.Focus();
        }

        private bool checkInput()
        {
            // check duplicate number.
            string str = "SELECT * FROM TB_M_ITEM WHERE ITEM_ID = '" + txtID.Text + "'";
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
            else if (-1 == cmbUnit.SelectedIndex)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                cmbUnit.Focus();
                return false;
            }
            else if (-1 == cmbCurrency.SelectedIndex)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                cmbCurrency.Focus();
                return false;
            }
            //else if (-1 == cmb_vendor.SelectedIndex)
            //{
            //    MessageBox.Show(ComFunc.getMessage("E001"));
            //    cmb_vendor.Focus();
            //    return false;
            //}
            //else if (-1 == cmbCustomerName.SelectedIndex)
            //{
            //    MessageBox.Show(ComFunc.getMessage("E001"));
            //    cmbCustomerName.Focus();
            //    return false;
            //}
            else if (0 == ComFunc.ConvertDouble(txtOrder.Text))
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                txtOrder.Focus();
                return false;
            }
            else if (0 == ComFunc.ConvertDouble(txtUnitAmt.Text))
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                txtUnitAmt.Focus();
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
                        string s_cmd = "INSERT INTO TB_M_ITEM VALUES( " + "\n" +
                                       "'" + txtID.Text + "',\n" +
                                       "'" + txtName.Text + "',\n" +
                                       "'" + ComFunc.Get_UnitID(ComFunc.ObjectText(cmbUnit.SelectedValue)) + "',\n" +
                                       ComFunc.ConvertDouble(txtOrder.Text) + ",\n" +
                                       ComFunc.ConvertDouble(txtUnitAmt.Text) + ",\n" +
                                       "'" + ComFunc.ObjectText(cmbCurrency.SelectedValue) + "',\n" +
                                       ComFunc.ConvertForSQL(ComFunc.Get_VendorID(ComFunc.ObjectText(cmb_vendor.SelectedValue))) + ",\n" +
                                       ComFunc.ConvertForSQL(txtSTDelivery.Text) + ",\n" +
                                       ComFunc.ConvertForSQL(ComFunc.Get_CustomerID(ComFunc.ObjectText(cmbCustomerName.SelectedValue))) + ",\n" +
                                       "'" + txtRemark1.Text + "',\n" +
                                       "'" + txtRemark2.Text + "',\n" +
                                       "'" + txtRemark3.Text + "',\n" +
                                       "'" + txtRemark4.Text + "',\n" +
                                       "'" + txtRemark5.Text + "',\n" +
                                       "'" + DateTime.Now + "',\n" +
                                       "'9999',\n" +
                                       "'" + DateTime.Now + "',\n" +
                                       "'9999')";
                        if (null == ComFunc.ConnectDatabase(s_cmd))
                        {
                            string error_msg = @"System Error E1104";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                    }
                    else
                    {
                        // edit mode.
                        string s_cmd = "UPDATE TB_M_ITEM SET " + "\n" +
                                       " ITEM_ID = '" + txtID.Text + "',\n" +
                                       " ITEM_NAME = '" + txtName.Text + "',\n" +
                                       " UNIT_ID = '" + ComFunc.Get_UnitID(ComFunc.ObjectText(cmbUnit.SelectedValue)) + "',\n" +
                                       " ORDER_POINT = " + ComFunc.ConvertDouble(txtOrder.Text) + ",\n" +
                                       " UNIT_AMOUNT = " + ComFunc.ConvertDouble(txtUnitAmt.Text) + ",\n" +
                                       " CURRENCY_NAME = '" + ComFunc.ObjectText(cmbCurrency.SelectedValue) + "',\n" +
                                       " VENDOR_ID = '" + ComFunc.Get_VendorID(ComFunc.ObjectText(cmb_vendor.SelectedValue)) + "',\n" +
                                       " ST_DELIVERY = '" + txtSTDelivery.Text + "',\n" +
                                       " REMARK01 = '" + txtRemark1.Text + "',\n" +
                                       " REMARK02 = '" + txtRemark2.Text + "',\n" +
                                       " REMARK03 = '" + txtRemark3.Text + "',\n" +
                                       " REMARK04 = '" + txtRemark4.Text + "',\n" +
                                       " REMARK05 = '" + txtRemark5.Text + "',\n" +
                                       " CUSTOMER_ID = '" + ComFunc.Get_CustomerID(ComFunc.ObjectText(cmbCustomerName.SelectedValue)) + "',\n" +
                                       " UPDATE_DATE = '" + DateTime.Now + "',\n" +
                                       " UPDATE_BY = '9999'\n" +
                                       " WHERE ITEM_ID = '" + s_selected + "'";
                        if (null == ComFunc.ConnectDatabase(s_cmd))
                        {
                            string error_msg = @"System Error E1105";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                    }
                    s_selectedBak = txtID.Text;
                    setScreen();
                    EnableChanged(true);
                    selectAgain();
                    ComFunc.updateUpdateMaster(1);
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1106";
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
            ComFunc.GenerateDatagridview(dataGridView1, "ItemMaster", true);
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != cmbCurrency.SelectedValue)
            {
                string str = @" SELECT
                             RATE
                            FROM TB_M_CURRENCY
                            WHERE CURRENCY_NAME = '" + ComFunc.ObjectText(cmbCurrency.SelectedValue) + "'";
                DataTable dt = ComFunc.ConnectDatabase(str);
                if (null != dt && 0 != dt.Rows.Count)
                {
                    lblRate.Text = dt.Rows[0][0].ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //"Button"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "Column9")
            {
                //MessageBox.Show(e.RowIndex.ToString() +
                //    "行のボタンがクリックされました。");
                Master_Item_Label f = new Master_Item_Label();

                f.setScreen(dgv.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                f.Show();
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            ComFunc.ImportDatagridviewEXCEL(dataGridView1, "TB_M_ITEM");
            setScreen();
        }
    }
}
