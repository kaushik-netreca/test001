using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test001
{
    public partial class home_page : Form
    {
        public home_page(string user_name)
        {
            InitializeComponent();
            lb_user_name.Text = user_name;
            tb_ctrl_1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            tb_ctrl_1.SelectedTab = tabPage1;
        }
        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tb_ctrl_1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tb_ctrl_1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Segoe Script", (float)12.0, FontStyle.Bold);
            //Segoe Script, 12pt, style = Bold

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void Home_page_Load(object sender, EventArgs e)
        {
            cbx_market.Text = "LA";
            cbx_market.Items.Add("LA");
            cbx_market.Items.Add("OC");
            cbx_market.Items.Add("SB");
            cbx_market.Items.Add("SD");
            cbx_market.Items.Add("NC");
            tabPage1.Text = "Warehouse";
            tabPage2.Text = "Store";
            tabPage3.Text = "Employee";
            tabPage4.Text = "Purchase Order";
            tabPage5.Text = "Sales Order";
            tabPage6.Text = "Inventory";
            tabPage7.Text = "Invoice";
            tabPage8.Text = "Configuration";
            tabPage9.Text = "Settings";
        }

        private void Btn_signout_Click(object sender, EventArgs e)
        {
            this.Close();
            login lg = new login();
            lg.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_warehouse_Click(object sender, EventArgs e)
        {
            add_warehouse aw = new add_warehouse();
            aw.Show();
        }
    }
}
