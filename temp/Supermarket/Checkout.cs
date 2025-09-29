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
    public partial class Checkout : Form
    {
        public List<(Product, int)> Cart;
        private Catalog catalog;
        public Checkout()
        {
            InitializeComponent();
            Cart = new List<(Product, int)> ();
            UpdateListView();
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            catalog = new Catalog(true);
            catalog.SelectedProduct += SelectedProductEventReceiver;
            catalog.ShowDialog();
        }

        private void SelectedProductEventReceiver(object sender, Product product) 
        {
            if (CartContainsProduct(product))
            {
                Cart[CartIndexOfProduct(product)] = (product, Cart[CartIndexOfProduct(product)].Item2+1); // Make so that the form which chooses if to use code or catalog pops up, all this is temporary
            }
            else
            {
                Cart.Add((product, 1)); // Also here the quantity is fixed to 1 but needs to be selected
            }
            catalog.Close();
            UpdateListView();
        }

        private void UpdateListView()
        {
            listView1.Items.Clear();
            foreach(var item in Cart)
            {
                var lstItem = new ListViewItem();
                lstItem.Text = item.Item1.Name;
                lstItem.SubItems.Add(item.Item1.Code);
                lstItem.SubItems.Add(item.Item2.ToString());
                listView1.Items.Add(lstItem);
            }
        }

        private bool CartContainsProduct(Product product)
        {
            foreach (var item in Cart)
            {
                if (item.Item1 == product)
                    return true;
            }
            return false;
        }

        private int CartIndexOfProduct(Product product)
        {
            for(int i = 0; i < Cart.Count; i++)
            {
                if (Cart[i].Item1 == product)
                    return i;
            }
            return -1;
        }
    }
}
