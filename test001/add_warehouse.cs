using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test001
{
    public partial class add_warehouse : Form
    {
        public add_warehouse()
        {
            InitializeComponent();
        }

        private void btn_add_warehouse_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_warehouse_Load(object sender, EventArgs e)
        {
            rbtn_active.PerformClick();
            cbx_market.Items.Add("LA");
            cbx_market.Items.Add("OC");
            cbx_market.Items.Add("SB");
            cbx_market.Items.Add("SD");
            cbx_market.Items.Add("NC");
            cbx_market.SelectedIndex = 0;
        }

        private void btn_add_warehouse_save_Click(object sender, EventArgs e)
        {
            if ((txb_wh_id.Text.Length == 0) || (txb_wh_name.Text.Length == 0) || (txb_tax.Text.Length == 0))
            {
                MessageBox.Show(" * Marked Fields cannot be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Warehouse Added Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    add_warehouse.ActiveForm.Close();
                }
            }
        }
    }
}
