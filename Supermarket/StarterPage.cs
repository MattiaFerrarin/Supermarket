using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class StarterPage : Form
    {
        public StarterPage()
        {
            InitializeComponent();
        }

        private void btn_catalog_Click(object sender, EventArgs e)
        {
            Hide();
            Catalog form = new Catalog();
            form.FormClosed += showEventHandler;
            form.Show();
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            Hide();
            Checkout form = new Checkout();
            form.FormClosed += showEventHandler;
            form.Show();
        }
        private void showEventHandler(object sender, EventArgs e)
        {
            Show();
        }
    }
}
