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
    public partial class MasterMain : Form
    {
        public MasterMain()
        {
            try
            {
                InitializeComponent();
                ComFunc.Language("MasterMain.cs", this);
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1601";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            Master_User f = new Master_User();
            f.Show();
            Close();
        }

        private void btn_Location_Click(object sender, EventArgs e)
        {
            Master_Location f = new Master_Location();
            f.Show();
            Close();
        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
            Master_Customer f = new Master_Customer();
            f.Show();
            Close();
        }

        private void btn_vendor_Click(object sender, EventArgs e)
        {
            Master_Vendor f = new Master_Vendor();
            f.Show();
            Close();
        }

        private void btn_unit_Click(object sender, EventArgs e)
        {
            Master_Unit f = new Master_Unit();
            f.Show();
            Close();
        }

        private void btn_currency_Click(object sender, EventArgs e)
        {
            Master_Currency f = new Master_Currency();
            f.Show();
            Close();
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Master_Item.i_mode = Master_Item.MODE_MASTER;
            Master_Item f = new Master_Item();
            f.Show();
            Close();
        }
    }
}
