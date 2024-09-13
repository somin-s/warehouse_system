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
    public partial class Manual_Input : Form
    {
        public Manual_Input()
        {
            try
            {
                InitializeComponent();
                ComFunc.Language("Manual_Input.cs", this);
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E0601";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Rec_Click(object sender, EventArgs e)
        {
            if ("0" == ConfigurationManager.AppSettings.Get("MANUAL_TYPE"))
            {
                Manual_Receive f = new Manual_Receive();
                f.Show();
            }
            else
            {
                Manual_Receive2 f = new Manual_Receive2();
                f.Show();
            }
            Close();
        }

        private void btn_Iss_Click(object sender, EventArgs e)
        {
            if ("0" == ConfigurationManager.AppSettings.Get("MANUAL_TYPE"))
            {
                Manual_Issue f = new Manual_Issue();
                f.Show();
            }
            else
            {
                Manual_Issue2 f = new Manual_Issue2();
                f.Show();
            }
            Close();
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            if ("0" == ConfigurationManager.AppSettings.Get("MANUAL_TYPE"))
            {
                Manual_Move f = new Manual_Move();
                f.Show();
            }
            else
            {
                Manual_Move2 f = new Manual_Move2();
                f.Show();
            }
            Close();
        }
    }
}
