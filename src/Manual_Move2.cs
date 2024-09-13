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
    public partial class Manual_Move2 : Form
    {
        public Manual_Move2()
        {
            InitializeComponent();
            ComFunc.Language("Manual_Move2.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
                txtMessage.BackColor = Color.LightGreen;
                txtMessage.Text = ComFunc.getMessage("M912");

                txtPIC.Text = "";
                txtLocation.Text = "";
                txtLocation2.Text = "";
                txtItemID.Text = "";
                txtLot.Text = "";
                txt_qty.Text = "";

                lblPIC.Text = "";
                lblLocation.Text = "";
                lblLocation2.Text = "";
                lblItemName.Text = "";
                lblUnit.Text = "";

                txtPIC.BackColor = Color.LightPink;
                txtLocation.BackColor = Color.LightGray;
                txtLocation2.BackColor = Color.LightGray;
                txtItemID.BackColor = Color.LightGray;
                txtLot.BackColor = Color.LightGray;
                txt_qty.BackColor = Color.LightGray;

                txtPIC.Enabled = true;
                txtLocation.Enabled = false;
                txtLocation2.Enabled = false;
                txtItemID.Enabled = false;
                txtLot.Enabled = false;
                txt_qty.Enabled = false;

                txtPIC.Focus();
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E2301";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (Color.LightPink == txtPIC.BackColor || Color.LightPink == txtLocation.BackColor)
            {
                txtLocation.Text = "";
                lblLocation.Text = "";

                txtMessage.Text = ComFunc.getMessage("M912");

                txtPIC.BackColor = Color.LightPink;
                txtLocation.BackColor = Color.LightGray;
                txtLocation2.BackColor = Color.LightGray;
                txtItemID.BackColor = Color.LightGray;
                txtLot.BackColor = Color.LightGray;
                txt_qty.BackColor = Color.LightGray;

                txtPIC.Enabled = true;
                txtLocation.Enabled = false;
                txtLocation2.Enabled = false;
                txtItemID.Enabled = false;
                txtLot.Enabled = false;
                txt_qty.Enabled = false;

                txtPIC.Focus();
            }
            else if (Color.LightPink == txtLocation2.BackColor)
            {
                txtLocation2.Text = "";
                lblLocation2.Text = "";

                txtMessage.Text = ComFunc.getMessage("M913");

                txtPIC.BackColor = Color.LightGray;
                txtLocation.BackColor = Color.LightPink;
                txtLocation2.BackColor = Color.LightGray;
                txtItemID.BackColor = Color.LightGray;
                txtLot.BackColor = Color.LightGray;
                txt_qty.BackColor = Color.LightGray;

                txtPIC.Enabled = false;
                txtLocation.Enabled = true;
                txtLocation2.Enabled = false;
                txtItemID.Enabled = false;
                txtLot.Enabled = false;
                txt_qty.Enabled = false;

                txtLocation.Focus();
            }
            else if (Color.LightPink == txtItemID.BackColor)
            {
                txtItemID.Text = "";
                lblItemName.Text = "";
                lblUnit.Text = "";

                txtMessage.Text = ComFunc.getMessage("M914");

                txtPIC.BackColor = Color.LightGray;
                txtLocation.BackColor = Color.LightGray;
                txtLocation2.BackColor = Color.LightPink;
                txtItemID.BackColor = Color.LightGray;
                txtLot.BackColor = Color.LightGray;
                txt_qty.BackColor = Color.LightGray;

                txtPIC.Enabled = false;
                txtLocation.Enabled = false;
                txtLocation2.Enabled = true;
                txtItemID.Enabled = false;
                txtLot.Enabled = false;
                txt_qty.Enabled = false;

                txtLocation2.Focus();
            }
            else if (Color.LightPink == txtLot.BackColor)
            {
                txtLot.Text = "";

                txtMessage.Text = ComFunc.getMessage("M915");

                txtPIC.BackColor = Color.LightGray;
                txtLocation.BackColor = Color.LightGray;
                txtLocation2.BackColor = Color.LightGray;
                txtItemID.BackColor = Color.LightPink;
                txtLot.BackColor = Color.LightGray;
                txt_qty.BackColor = Color.LightGray;

                txtPIC.Enabled = false;
                txtLocation.Enabled = false;
                txtLocation2.Enabled = false;
                txtItemID.Enabled = true;
                txtLot.Enabled = false;
                txt_qty.Enabled = false;

                txtItemID.Focus();
            }
            else if (Color.LightPink == txt_qty.BackColor)
            {
                txt_qty.Text = "";

                txtMessage.Text = ComFunc.getMessage("M916");

                txtPIC.BackColor = Color.LightGray;
                txtLocation.BackColor = Color.LightGray;
                txtLocation2.BackColor = Color.LightGray;
                txtItemID.BackColor = Color.LightGray;
                txtLot.BackColor = Color.LightPink;
                txt_qty.BackColor = Color.LightGray;

                txtPIC.Enabled = false;
                txtLocation.Enabled = false;
                txtLocation2.Enabled = false;
                txtItemID.Enabled = false;
                txtLot.Enabled = true;
                txt_qty.Enabled = false;

                txtLot.Focus();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPIC_KeyDown(object sender, KeyEventArgs e)
        {
            lblPIC.Text = "";

            if (e.KeyCode == Keys.Enter)
            {
                string ret = ComFunc.Get_UserName(txtPIC.Text);

                if ("" != ret)
                {
                    lblPIC.Text = ret;

                    txtMessage.Text = ComFunc.getMessage("M913");

                    txtPIC.BackColor = Color.LightGray;
                    txtLocation.BackColor = Color.LightPink;
                    txtLocation2.BackColor = Color.LightGray;
                    txtItemID.BackColor = Color.LightGray;
                    txtLot.BackColor = Color.LightGray;
                    txt_qty.BackColor = Color.LightGray;

                    txtPIC.Enabled = false;
                    txtLocation.Enabled = true;
                    txtLocation2.Enabled = false;
                    txtItemID.Enabled = false;
                    txtLot.Enabled = false;
                    txt_qty.Enabled = false;

                    txtLocation.Focus();
                }
                else
                {
                    txtMessage.Text = ComFunc.getMessage("E001");
                    txtMessage.BackColor = Color.LightPink;
                    txtMessage.Update();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M912");

                    txtPIC.SelectAll();
                }
            }
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            lblLocation.Text = "";

            if (e.KeyCode == Keys.Enter)
            {
                string ret = ComFunc.Get_LocationName(txtLocation.Text);

                if ("" != ret)
                {
                    lblLocation.Text = ret;

                    txtMessage.Text = ComFunc.getMessage("M914");

                    txtPIC.BackColor = Color.LightGray;
                    txtLocation.BackColor = Color.LightGray;
                    txtLocation2.BackColor = Color.LightPink;
                    txtItemID.BackColor = Color.LightGray;
                    txtLot.BackColor = Color.LightGray;
                    txt_qty.BackColor = Color.LightGray;

                    txtPIC.Enabled = false;
                    txtLocation.Enabled = false;
                    txtLocation2.Enabled = true;
                    txtItemID.Enabled = false;
                    txtLot.Enabled = false;
                    txt_qty.Enabled = false;

                    txtLocation2.Focus();
                }
                else
                {
                    txtMessage.Text = ComFunc.getMessage("E001");
                    txtMessage.BackColor = Color.LightPink;
                    txtMessage.Update();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M913");

                    txtLocation.SelectAll();
                }
            }
        }

        private void txtLocation2_KeyDown(object sender, KeyEventArgs e)
        {
            lblLocation2.Text = "";

            if (e.KeyCode == Keys.Enter)
            {
                string ret = ComFunc.Get_LocationName(txtLocation2.Text);

                if (txtLocation.Text == txtLocation2.Text)
                {
                    txtMessage.Text = ComFunc.getMessage("M012");
                    txtMessage.BackColor = Color.LightPink;
                    txtMessage.Update();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M914");

                    txtLocation2.SelectAll();
                }
                else if ("" != ret)
                {
                    lblLocation2.Text = ret;

                    txtMessage.Text = ComFunc.getMessage("M915");

                    txtPIC.BackColor = Color.LightGray;
                    txtLocation.BackColor = Color.LightGray;
                    txtLocation2.BackColor = Color.LightGray;
                    txtItemID.BackColor = Color.LightPink;
                    txtLot.BackColor = Color.LightGray;
                    txt_qty.BackColor = Color.LightGray;

                    txtPIC.Enabled = false;
                    txtLocation.Enabled = false;
                    txtLocation2.Enabled = false;
                    txtItemID.Enabled = true;
                    txtLot.Enabled = false;
                    txt_qty.Enabled = false;

                    txtItemID.Focus();
                }
                else
                {
                    txtMessage.Text = ComFunc.getMessage("E001");
                    txtMessage.BackColor = Color.LightPink;
                    txtMessage.Update();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M914");

                    txtLocation2.SelectAll();
                }
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            lblItemName.Text = "";
            lblUnit.Text = "";

            if (e.KeyCode == Keys.Enter)
            {
                string ret = ComFunc.Get_ItemName(txtItemID.Text);

                if ("" != ret)
                {
                    lblItemName.Text = ret;

                    txtMessage.Text = ComFunc.getMessage("M916");

                    txtPIC.BackColor = Color.LightGray;
                    txtLocation.BackColor = Color.LightGray;
                    txtLocation2.BackColor = Color.LightGray;
                    txtItemID.BackColor = Color.LightGray;
                    txtLot.BackColor = Color.LightPink;
                    txt_qty.BackColor = Color.LightGray;

                    txtPIC.Enabled = false;
                    txtLocation.Enabled = false;
                    txtLocation2.Enabled = false;
                    txtItemID.Enabled = false;
                    txtLot.Enabled = true;
                    txt_qty.Enabled = false;

                    txtLot.Focus();
                }
                else
                {
                    txtMessage.Text = ComFunc.getMessage("E001");
                    txtMessage.BackColor = Color.LightPink;
                    txtMessage.Update();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M915");

                    txtLocation.SelectAll();
                }
            }
        }

        private void txtLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMessage.Text = ComFunc.getMessage("M917");

                txtPIC.BackColor = Color.LightGray;
                txtLocation.BackColor = Color.LightGray;
                txtLocation2.BackColor = Color.LightGray;
                txtItemID.BackColor = Color.LightGray;
                txtLot.BackColor = Color.LightGray;
                txt_qty.BackColor = Color.LightPink;

                txtPIC.Enabled = false;
                txtLocation.Enabled = false;
                txtLocation2.Enabled = false;
                txtItemID.Enabled = false;
                txtLot.Enabled = false;
                txt_qty.Enabled = true;

                txt_qty.Focus();
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (0 != ComFunc.ConvertInt(txt_qty.Text))
                {
                    txtMessage.Text = ComFunc.getMessage("M918");
                    txtMessage.BackColor = Color.LightYellow;
                    txtMessage.Update();

                    SaveItem();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M915");

                    txtItemID.Text = "";
                    lblItemName.Text = "";
                    lblUnit.Text = "";
                    txtLot.Text = "";
                    txt_qty.Text = "";

                    txtPIC.BackColor = Color.LightGray;
                    txtLocation.BackColor = Color.LightGray;
                    txtLocation2.BackColor = Color.LightGray;
                    txtItemID.BackColor = Color.LightPink;
                    txtLot.BackColor = Color.LightGray;
                    txt_qty.BackColor = Color.LightGray;

                    txtPIC.Enabled = false;
                    txtLocation.Enabled = false;
                    txtLocation2.Enabled = false;
                    txtItemID.Enabled = true;
                    txtLot.Enabled = false;
                    txt_qty.Enabled = false;

                    txtItemID.Focus();
                }
                else
                {
                    txtMessage.Text = ComFunc.getMessage("E001");
                    txtMessage.BackColor = Color.LightPink;
                    txtMessage.Update();

                    System.Threading.Thread.Sleep(
                        ComFunc.ConvertInt(ConfigurationManager.AppSettings.Get("MANUAL_SLEEP")));

                    txtMessage.BackColor = Color.LightGreen;
                    txtMessage.Text = ComFunc.getMessage("M917");

                    txt_qty.SelectAll();
                }
            }
        }

        private void SaveItem()
        {
            try
            {
                // Issue.
                string s_cmd = "INSERT INTO TB_R_RCIS_RESULT (ITEM_ID,LOCATION_ID,CUSTOMER_ID,VENDOR_ID,USER_ID,RCIS_TYPE,RCIS_DATE,LOT,RECEIVE_QTY,ISSUE_QTY,RCIS_QTY,HANDY_SCANNER,REMARKS,UPDATE_DATE,UPDATE_BY,CREATE_DATE,CREATE_BY) VALUES( " + "\n" +
                                "'" + txtItemID.Text + "',\n" +
                                "'" + txtLocation.Text + "',\n" +
                                "'',\n" +
                                "'',\n" +
                                "'" + txtPIC.Text + "',\n" +
                                "'ISS',\n" +
                                "'" + DateTime.Now + "',\n" +
                                "'" + txtLot.Text + "',\n" +
                                "0,\n" +
                                "-" + txt_qty.Text + ",\n" +
                                "-" + txt_qty.Text + ",\n" +
                                "'',\n" +
                                "'" + "" + "',\n" +
                                "'" + DateTime.Now + "',\n" +
                                "'9999',\n" +
                                "'" + DateTime.Now + "',\n" +
                                "'9999')";
                if (null == ComFunc.ConnectDatabase(s_cmd))
                {
                    string error_msg = @"System Error E2302";
                    ComFunc.WriteLogLocal(error_msg, "");
                }
                else
                {
                    // Receive.
                    s_cmd = "INSERT INTO TB_R_RCIS_RESULT (ITEM_ID,LOCATION_ID,CUSTOMER_ID,VENDOR_ID,USER_ID,RCIS_TYPE,RCIS_DATE,LOT,RECEIVE_QTY,ISSUE_QTY,RCIS_QTY,HANDY_SCANNER,REMARKS,UPDATE_DATE,UPDATE_BY,CREATE_DATE,CREATE_BY) VALUES( " + "\n" +
                                    "'" + txtItemID.Text + "',\n" +
                                    "'" + txtLocation2.Text + "',\n" +
                                    "'',\n" +
                                    "'',\n" +
                                    "'" + txtPIC.Text + "',\n" +
                                    "'REC',\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'" + txtLot.Text + "',\n" +
                                    txt_qty.Text + ",\n" +
                                    "0,\n" +
                                    txt_qty.Text + ",\n" +
                                    "'PC OPE',\n" +
                                    "'" + "" + "',\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'9999',\n" +
                                    "'" + DateTime.Now + "',\n" +
                                    "'9999')";
                    if (null == ComFunc.ConnectDatabase(s_cmd))
                    {
                        string error_msg = @"System Error E2303";
                        ComFunc.WriteLogLocal(error_msg, "");
                    }
                    else
                    {
                        ComFunc.setActualStock(txtItemID.Text,
                                                txtLocation.Text,
                                                ComFunc.ConvertDouble(txt_qty.Text));
                        ComFunc.setActualStock(txtItemID.Text,
                                                txtLocation2.Text,
                                                ComFunc.ConvertDouble(txt_qty.Text) * -1);
                        string msg = ComFunc.getMessage("M011");
                        MessageBox.Show(msg);
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E2304";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }
    }
}
