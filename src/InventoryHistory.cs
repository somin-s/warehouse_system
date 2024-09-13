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
    public partial class InventoryHistory : Form
    {
        public InventoryStock f1;
        public InventoryHistory()
        {
            InitializeComponent();
            ComFunc.Language("InventoryHistory.cs", this);
            setScreen();
        }

        private void setScreen()
        {
            try
            {
                string str = "SELECT SEQ_ID,USET.USER_NAME,INVENTORY_DATE,REFLECT_F,REMARKS FROM" + "\n" +
                                "TB_R_INVSTOCK_H AS INVH LEFT JOIN TB_M_USER AS USET" + "\n" +
                                "ON INVH.USER_ID = USET.USER_ID";
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
            }
            catch (Exception ex)
            {
                string error_msg = @"System Error E1801";
                ComFunc.WriteLogLocal(error_msg, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectItem()
        {
            if (null != f1)
            {
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    f1.setScreen(ComFunc.ConvertInt(r.Cells[0].Value.ToString()));
                    break;
                }
            }
            Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectItem();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            selectItem();
        }
    }
}
