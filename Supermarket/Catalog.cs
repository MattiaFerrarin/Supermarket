using System;
using System.Collections;
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
    public partial class Catalog : Form
    {
        public DatabaseNode Database;
        public Navigator Navigator;
        private bool IsForSelection = false;
        public EventHandler<Product> SelectedProduct;
        public Catalog(bool isForSelection = false)
        {
            InitializeComponent();
            if (!IODataHandler.Initialized)
            {
                IODataHandler.Initialize();
            }
            Database = IODataHandler.Database;
            Navigator = new Navigator(Database);
            UpdateListView();
            IsForSelection = isForSelection;
        }

        private void tsb_back_Click(object sender, EventArgs e)
        {
            Navigator.NavigateUp();
            UpdateListView();
        }

        private void tsmi_addProduct_Click(object sender, EventArgs e)
        {
            MessageBoxTextbox msbname = new MessageBoxTextbox("Inserisci Nome del Prodotto", (string s) => { if (s.Length > 0) { return true; } else { return false; } });
            if (msbname.ShowDialog() == DialogResult.OK)
            {
                string name = msbname.Data;
                MessageBoxTextbox msbcode = new MessageBoxTextbox("Inserisci Codice del Prodotto", (string s) => { if (s.Length==12 && IODataHandler.GetProductByCode(s) == null) { return true; } else { return false; } });
                if (msbcode.ShowDialog() == DialogResult.OK)
                {
                    string code = msbcode.Data;
                    MessageBoxNumericUpDown msbcost = new MessageBoxNumericUpDown("Inserisci Costo del Prodotto", (Decimal n) => { if(n>0) { return true; } else { return false; } });
                    if(msbcost.ShowDialog() == DialogResult.OK)
                    {
                        float cost = (float)msbcost.Data;
                        Navigator.CurrentLocation.Items.Add(new Product(name, code, cost));
                        Navigator.CurrentLocation.Items.Sort(CompareByType);
                        UpdateListView();
                        IODataHandler.UpdateDatabase(Navigator.Root);
                    }
                }
            }
        }

        private void tsmi_addSection_Click(object sender, EventArgs e)
        {
            MessageBoxTextbox msbname = new MessageBoxTextbox("Inserisci Nome della Sezione", (string s) => { if (s.Length > 0) { return true; } else { return false; } });
            if (msbname.ShowDialog() == DialogResult.OK)
            {
                string name = msbname.Data;
                Navigator.CurrentLocation.Items.Add(new DatabaseNode(name));
                Navigator.CurrentLocation.Items.Sort(CompareByType);
                UpdateListView();
                IODataHandler.UpdateDatabase(Navigator.Root);
            }
        }

        private void tsb_rename_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                MessageBoxTextbox msbname = new MessageBoxTextbox("Inserisci nuovo Nome", (string s) => { if (s.Length > 0) { return true; } else { return false; } });
                if (msbname.ShowDialog() == DialogResult.OK)
                {
                    string name = msbname.Data;
                    if (Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]].GetType() == typeof(Product))
                    {
                        Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]] = new Product(name, ((Product)Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]]).Code, ((Product)Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]]).Cost);
                    }
                    else if (Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]].GetType() == typeof(DatabaseNode))
                    {
                        Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]] = new DatabaseNode(name);
                    }
                    Navigator.CurrentLocation.Items.Sort(CompareByType);
                    UpdateListView();
                    IODataHandler.UpdateDatabase(Navigator.Root);
                }
            }
        }

        private void tsb_delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                string name = Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]].Name;
                if (MessageBox.Show($"Confermi di eliminare \"{name.Substring(2, name.Length - 2)}\"", "Conferma di eliminazione", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    Navigator.CurrentLocation.Items.RemoveAt(listView1.SelectedIndices[0]);
                    Navigator.CurrentLocation.Items.Sort(CompareByType);
                    UpdateListView();
                    IODataHandler.UpdateDatabase(Navigator.Root);
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]].GetType() == typeof(DatabaseNode))
            {
                Navigator.NavigateInChild((DatabaseNode)Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]]);
            }
            else if (Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]].GetType() == typeof(Product) && IsForSelection)
            {
                SelectedProduct.Invoke(this, (Product)Navigator.CurrentLocation.Items[listView1.SelectedIndices[0]]);
            }
            UpdateListView();
        }

        private void UpdateListView()
        {
            listView1.Clear();
            foreach (var item in Navigator.CurrentLocation.Items)
            {
                listView1.Items.Add("  " + item.Name + "  ");
                if (item.GetType() == typeof(DatabaseNode))
                {
                    listView1.Items[listView1.Items.Count - 1].BackColor = Color.FromArgb(200, 255, 215, 103);
                }
                else
                {
                    listView1.Items[listView1.Items.Count - 1].BackColor = Color.FromArgb(200, 204, 232, 255);
                    listView1.Items[listView1.Items.Count - 1].ToolTipText = "Codice: \n" + ((Product)item).Code + "\nCosto:\n" + ((Product)item).Cost.ToString("0.00")+"€";
                }
                SetListViewItemHeight(listView1, 40);
            }
            lbl_address.Text = "Path: " + Navigator.GetCurrentPathString();
        }

        private void SetListViewItemHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private int CompareByType(Object x, Object y)
        {
            if (x.GetType() == typeof(DatabaseNode))
            {
                if (y.GetType() == typeof(DatabaseNode))
                    return 0;
                else if (y.GetType() == typeof(Product))
                    return -1;
            }
            else if (x.GetType() == typeof(Product))
            {
                if (y.GetType() == typeof(DatabaseNode))
                    return 1;
                else if (y.GetType() == typeof(Product))
                    return 0;
            }
            return 0;
        }
    }
}
