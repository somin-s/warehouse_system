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
    public partial class Master_Item_Label : Form
    {
        public Master_Item_Label()
        {
            InitializeComponent();
            ComFunc.Language("Master_Item_Label.cs", this);
        }

        public void setScreen(string s_no, string s_name)
        {
            try
            {
                txtID.Text = s_no;
                txtName.Text = s_name;

                txtFix.Text = "";
                txtStartLot.Text = "";
                txtAmt.Text = "";
                txtSample.Text = "";
                label9.Text = ConfigurationManager.AppSettings.Get("LabelItem1Text");
                label6.Text = ConfigurationManager.AppSettings.Get("LabelItem2Text");
                label10.Text = ConfigurationManager.AppSettings.Get("LabelItem3Text");
                txtItem1.Text = ConfigurationManager.AppSettings.Get("LabelItem1Default");
                txtItem2.Text = ConfigurationManager.AppSettings.Get("LabelItem2Default");
                txtItem3.Text = ConfigurationManager.AppSettings.Get("LabelItem3Default");
                if ("" == ConfigurationManager.AppSettings.Get("LabelItem1Text"))
                {
                    txtItem1.Enabled = false;
                }
                if ("" == ConfigurationManager.AppSettings.Get("LabelItem2Text"))
                {
                    txtItem2.Enabled = false;
                }
                if ("" == ConfigurationManager.AppSettings.Get("LabelItem3Text"))
                {
                    txtItem3.Enabled = false;
                }
                txtQty.Text = "";
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E2001";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            int iLen = txtStartLot.Text.Length;
            int iLen2 = txtAmt.Text.Length;
            int iStart = ComFunc.ConvertInt(txtStartLot.Text);
            int iAmt = ComFunc.ConvertInt(txtAmt.Text);
            if ("" == txtFix.Text)
            {
                MessageBox.Show("Invalid Value");
                txtFix.Focus();
                txtFix.SelectAll();
                return;
            }
            else if (1 > iAmt)
            {
                MessageBox.Show("Invalid Value");
                txtAmt.Focus();
                txtAmt.SelectAll();
                return;
            }
            else if (iLen < iLen2)
            {
                MessageBox.Show("Invalid Value");
                txtAmt.Focus();
                txtAmt.SelectAll();
                return;
            }
            else if ("" == txtQty.Text)
            {
                MessageBox.Show("Invalid Value");
                txtQty.Focus();
                txtQty.SelectAll();
                return;
            }

            if (ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("LabelLotLength"))
                    < txtFix.Text.Length + iLen)
            {
                MessageBox.Show("Invalid Value");
                txtFix.Focus();
                txtFix.SelectAll();
                return;
            }
            else if (ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("LabelQtyLength"))
                    < txtQty.Text.Length)
            {
                MessageBox.Show("Invalid Value");
                txtQty.Focus();
                txtQty.SelectAll();
                return;
            }

            if ("" != ConfigurationManager.AppSettings.Get("LabelItem1Text"))
            {
                if (ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("LabelItem1Length"))
                        < txtItem1.Text.Length)
                {
                    MessageBox.Show("Invalid Value");
                    txtItem1.Focus();
                    txtItem1.SelectAll();
                    return;
                }
            }
            if ("" != ConfigurationManager.AppSettings.Get("LabelItem2Text"))
            {
                if (ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("LabelItem2Length"))
                        < txtItem2.Text.Length)
                {
                    MessageBox.Show("Invalid Value");
                    txtItem2.Focus();
                    txtItem2.SelectAll();
                    return;
                }
            }
            if ("" != ConfigurationManager.AppSettings.Get("LabelItem3Text"))
            {
                if (ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("LabelItem1Length"))
                        < txtItem3.Text.Length)
                {
                    MessageBox.Show("Invalid Value");
                    txtItem3.Focus();
                    txtItem3.SelectAll();
                    return;
                }
            }

            //DialogResult result = MessageBox.Show(ComFunc.getMessage("M905"),
            DialogResult result = MessageBox.Show("Do you want to print label?",
                "",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                bool b_date = false;
                if ("Y" == ConfigurationManager.AppSettings.Get("LabelCSVDate"))
                {
                    b_date = true;
                }

                if (true == ComFunc.GenerateLabelCSV(txtID.Text,
                                                        txtName.Text,
                                                        txtQty.Text,
                                                        txtFix.Text,
                                                        ComFunc.ConvertInt(txtStartLot.Text),
                                                        txtStartLot.Text.Length,
                                                        ComFunc.ConvertInt(txtAmt.Text),
                                                        txtItem1.Text,
                                                        txtItem2.Text,
                                                        txtItem3.Text,
                                                        b_date))
                {
                    MessageBox.Show("Complete");
                    Close();
                }
                else
                {
                    MessageBox.Show("Generate CSV Error!!");
                }
            }
        }

        private void txtFix_TextChanged(object sender, EventArgs e)
        {
            _TextChanged();
        }

        private void txtStartLot_TextChanged(object sender, EventArgs e)
        {
            _TextChanged();
        }

        private void txtAmt_TextChanged(object sender, EventArgs e)
        {
            _TextChanged();
        }

        private void _TextChanged()
        {
            try
            {
                string smp = "";

                int iLen = txtStartLot.Text.Length;
                int iStart = ComFunc.ConvertInt(txtStartLot.Text);
                int iAmt = ComFunc.ConvertInt(txtAmt.Text);

                if (2 > iAmt)
                {
                    smp = txtFix.Text + String.Format("{0:D" + iLen.ToString() + "}", iStart);
                }
                else
                {
                    smp = txtFix.Text + String.Format("{0:D" + iLen.ToString() + "}", iStart);
                    smp = smp + " ～ ";
                    smp = smp + txtFix.Text + String.Format("{0:D" + iLen.ToString() + "}", iStart + iAmt - 1);
                }

                txtSample.Text = smp;
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E2002";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

    }
}
