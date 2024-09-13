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
    public partial class DefaultScreen : Form
    {
        public DefaultScreen()
        {
            InitializeComponent();
            ComFunc.Language("DefaultScreen.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error EXXXX";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
