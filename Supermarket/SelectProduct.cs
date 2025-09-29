using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class SelectProduct : Form
    {
        public Product CurrentlySelectedProduct { get; private set; }
        public int SelectedProductQuantity { get; private set; }
        private Catalog catalog;
        public SelectProduct()
        {
            InitializeComponent();

            IODataHandler.Initialize();
        }

        private void txb_code_TextChanged(object sender, EventArgs e)
        {
            Product productByCode = IODataHandler.GetProductByCode(txb_code.Text);
            CurrentlySelectedProduct = productByCode;
            UpdateLabel();
        }

        private void btn_loadCatalog_Click(object sender, EventArgs e)
        {
            catalog = new Catalog(true);
            catalog.SelectedProduct += SelectedProductEventReceiver;
            catalog.ShowDialog();
        }

        private void SelectedProductEventReceiver(object sender, Product product)
        {
            CurrentlySelectedProduct = product;
            UpdateLabel();
            catalog.Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if(!(nmu_quantity.Value > 0))
            {
                MessageBox.Show(this, "Seleziona una quantità!", "Errore",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmu_quantity.Select();
                return;
            }
            if(CurrentlySelectedProduct != null)
            {
                SelectedProductQuantity = (int)nmu_quantity.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void UpdateLabel()
        {
            if (CurrentlySelectedProduct != null)
            {
                lbl_selectedProduct.Text = CurrentlySelectedProduct.Name + "  |  " + CurrentlySelectedProduct.Code;
            }
            else
            {
                lbl_selectedProduct.Text = "Nessun Prodotto selezionato";
            }
        }
    }
}
