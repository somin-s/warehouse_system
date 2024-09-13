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
    public partial class Manual_Receive : Form
    {
        public Manual_Receive()
        {
            InitializeComponent();
            ComFunc.Language("Manual_Receive.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
                ut_date.Value = null;

                string str = "SELECT USER_NAME FROM TB_M_USER";
                DataTable dt = ComFunc.ConnectDatabase(str);
                if (null != dt)
                {
                    cmb_worker.DataSource = dt;
                    cmb_worker.DisplayMember = "USER_NAME";
                    cmb_worker.ValueMember = "USER_NAME";
                    cmb_worker.SelectedIndex = -1;
                }
                str = "SELECT LOCATION_NAME FROM TB_M_LOCATION";
                dt = ComFunc.ConnectDatabase(str);
                if (null != dt)
                {
                    cmb_location.DataSource = dt;
                    cmb_location.DisplayMember = "LOCATION_NAME";
                    cmb_location.ValueMember = "LOCATION_NAME";
                    cmb_location.SelectedIndex = -1;
                }

                AutoCompleteStringCollection AC_ID;
                AC_ID = new AutoCompleteStringCollection();
                txtItemID.AutoCompleteCustomSource = AC_ID;
                AutoCompleteStringCollection AC_Name;
                AC_Name = new AutoCompleteStringCollection();
                txtItemName.AutoCompleteCustomSource = AC_Name;

                str = "SELECT ITEM_ID,ITEM_NAME FROM TB_M_ITEM";
                dt = ComFunc.ConnectDatabase(str);
                if (null != dt)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        AC_ID.Add(row[0].ToString());
                        AC_Name.Add(row[1].ToString());
                    }
                }

                str = "SELECT VENDOR_NAME FROM TB_M_VENDOR";
                dt = ComFunc.ConnectDatabase(str);
                if (null != dt)
                {
                    cmb_vendor.DataSource = dt;
                    cmb_vendor.DisplayMember = "VENDOR_NAME";
                    cmb_vendor.ValueMember = "VENDOR_NAME";
                    cmb_vendor.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0901";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Master_Item.i_mode = Master_Item.MODE_SEARCH3;
            Master_Item f = new Master_Item();
            f.f3 = this;
            f.Show();
        }

        private bool checkInput()
        {
            string error_msg = "";

            // check exist item.
            string str = "SELECT * FROM TB_M_ITEM WHERE ITEM_ID = '" + txtItemID.Text + "'";
            DataTable dt = ComFunc.ConnectDatabase(str);

            // check blank.
            if (null == ut_date.Value)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                ut_date.Focus();
                return false;
            }
            else if (-1 == cmb_worker.SelectedIndex)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                cmb_worker.Focus();
                return false;
            }
            else if (-1 == cmb_location.SelectedIndex)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                cmb_location.Focus();
                return false;
            }
            else if (null == dt || 0 == dt.Rows.Count)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                txtItemID.Focus();
                return false;
            }
            else if (-1 == cmb_vendor.SelectedIndex)
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                cmb_vendor.Focus();
                return false;
            }
            else if (0 == ComFunc.ConvertDouble(txt_qty.Text))
            {
                MessageBox.Show(ComFunc.getMessage("E001"));
                txt_qty.Focus();
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
                    string s_msg = ComFunc.getMessage("M902");
                                    DialogResult result = MessageBox.Show(s_msg,
                                    "",
                                    MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        string s_cmd = "INSERT INTO TB_R_RCIS_RESULT (ITEM_ID,LOCATION_ID,CUSTOMER_ID,VENDOR_ID,USER_ID,RCIS_TYPE,RCIS_DATE,LOT,RECEIVE_QTY,ISSUE_QTY,RCIS_QTY,HANDY_SCANNER,REMARKS,UPDATE_DATE,UPDATE_BY,CREATE_DATE,CREATE_BY) VALUES( " + "\n" +
                                        "'" + txtItemID.Text + "',\n" +
                                        "'" + ComFunc.Get_LocationID(ComFunc.ObjectText(cmb_location.SelectedValue)) + "',\n" +
                                        "'',\n" +
                                        "'" + ComFunc.Get_VendorID(ComFunc.ObjectText(cmb_vendor.SelectedValue)) + "',\n" +
                                        "'" + ComFunc.Get_UserID(ComFunc.ObjectText(cmb_worker.SelectedValue)) + "',\n" +
                                        "'REC',\n" +
                                        "'" + ut_date.Value + "',\n" +
                                        "'" + txtLot.Text + "',\n" +
                                        txt_qty.Text + ",\n" +
                                        "0,\n" +
                                        txt_qty.Text + ",\n" +
                                        "'PC OPE',\n" +
                                        "'" + txt_remark.Text + "',\n" +
                                        "'" + DateTime.Now + "',\n" +
                                        "'9999',\n" +
                                        "'" + DateTime.Now + "',\n" +
                                        "'9999')";
                        if (null == ComFunc.ConnectDatabase(s_cmd))
                        {
                            string error_msg = @"System Error E0902";
                            ComFunc.WriteLogLocal(error_msg, "");
                        }
                        else
                        {
                            ComFunc.setActualStock(txtItemID.Text,
                                                    ComFunc.Get_LocationID(ComFunc.ObjectText(cmb_location.SelectedValue)),
                                                    ComFunc.ConvertDouble(txt_qty.Text));
                            string msg = ComFunc.getMessage("M011");
                            MessageBox.Show(msg);
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0903";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }
        
        private void btn_close_Click(object sender, EventArgs e)
        {
            bool b_emp = false;
            if (null == ut_date.Value &&
                -1 == cmb_worker.SelectedIndex &&
                -1 == cmb_location.SelectedIndex &&
                -1 == cmb_vendor.SelectedIndex &&
                "" == txtItemID.Text &&
                "" == txt_qty.Text
                )
            {
                b_emp = true;
            }

            if (false == b_emp)
            {
                string s_msg = ComFunc.getMessage("M903");
                DialogResult result = MessageBox.Show(s_msg,
                    "",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private static bool b_semapho = false;
        private void txtItemID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (false == b_semapho)
                {
                    b_semapho = true;
                    string s_ret = "";
                    string str = "SELECT ITEM_ID,ITEM_NAME FROM TB_M_ITEM WHERE ITEM_ID = '" +
                                    txtItemID.Text + "'";
                    DataTable dt = ComFunc.ConnectDatabase(str);
                    if (null != dt && 0 != dt.Rows.Count)
                    {
                        s_ret = dt.Rows[0][1].ToString();
                    }
                    txtItemName.Text = s_ret;
                    b_semapho = false;
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0904";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (false == b_semapho)
                {
                    b_semapho = true;
                    string s_ret = "";
                    string str = "SELECT ITEM_ID,ITEM_NAME FROM TB_M_ITEM WHERE ITEM_NAME = '" +
                                    txtItemName.Text + "'";
                    DataTable dt = ComFunc.ConnectDatabase(str);
                    if (null != dt && 0 != dt.Rows.Count)
                    {
                        s_ret = dt.Rows[0][0].ToString();
                    }
                    txtItemID.Text = s_ret;
                    b_semapho = false;
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0905";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }
    }
}
