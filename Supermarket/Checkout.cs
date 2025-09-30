using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class Checkout : Form
    {
        public List<(Product, int)> Cart;
        private SelectProduct selector;
        public Checkout()
        {
            InitializeComponent();
            Cart = new List<(Product, int)>();
            UpdateListView();
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {

            selector = new SelectProduct();
            if (selector.ShowDialog() == DialogResult.OK)
            {
                if (CartContainsProduct(selector.CurrentlySelectedProduct))
                {
                    Cart[CartIndexOfProduct(selector.CurrentlySelectedProduct)] = (selector.CurrentlySelectedProduct, Cart[CartIndexOfProduct(selector.CurrentlySelectedProduct)].Item2 + selector.SelectedProductQuantity);

                }
                else
                {
                    Cart.Add((selector.CurrentlySelectedProduct, selector.SelectedProductQuantity));
                }
                selector.Close();
                UpdateListView();
            }
        }

        private void UpdateListView()
        {
            listView1.Items.Clear();
            foreach (var item in Cart)
            {
                var lstItem = new System.Windows.Forms.ListViewItem();
                lstItem.Text = item.Item1.Name;
                lstItem.SubItems.Add(item.Item1.Code);
                lstItem.SubItems.Add(item.Item2.ToString());
                lstItem.SubItems.Add(item.Item1.Cost.ToString("0.00")+"€");
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
            for (int i = 0; i < Cart.Count; i++)
            {
                if (Cart[i].Item1 == product)
                    return i;
            }
            return -1;
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            // Imposta alcune proprietà del documento che boh ci stanno
            doc.DocumentName = "Ricevuta";
            doc.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 280, 800);
            doc.DefaultPageSettings.Margins = new Margins(10,10,10,10);
            doc.DefaultPageSettings.Color = false;
            // Rimanda a un'altra function per pulizia
            doc.PrintPage += PrintReceipt;
            printPreviewDialog1.Document = doc;
            printPreviewDialog1.Width = 400;
            printPreviewDialog1.Height = 600;

            printDialog1.Document = doc;
            // Manipola printPreview per stampare direttamente da lì premendo l'icona di stampa
            ToolStripButton b = new ToolStripButton();
            b.Image = Properties.Resources.Print;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += printPreview_PrintClick;
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
            printPreviewDialog1.ShowDialog();
        }

        // Function for sending the actual printing
        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDialog1.Document.Print();
            }
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            // Data dello scontrino
            string headerData = $"{SupermarketData.Name}\n{SupermarketData.CompanyName}\n{SupermarketData.Street}, {SupermarketData.City} ({SupermarketData.CityCode})\nP.I. {SupermarketData.PI}\nTEL.{SupermarketData.Phone}\n";
            string mainData = "".PadRight(32)+"EURO\n";
            float totalCost = 0;
            foreach(var item in Cart)
            {
                mainData += ($"{item.Item1.Name}" + (item.Item2>1 ? $" X {item.Item2}" : "")).PadRight(32)+$"{item.Item1.Cost.ToString("0.00")}\n";
                totalCost += item.Item1.Cost;
            }
            if (chb_fidelity.Checked)
            {
                mainData += "\n-".PadRight(37, '-')+ "\nCARTA FEDELTÀ".PadRight(32)+$"-{(totalCost*0.03f).ToString("0.00")}";
                totalCost = totalCost * 0.97f;
            }
            mainData += "\n-".PadRight(37,'-');
            totalCost = (float)Math.Round(totalCost,2);
            string totalCostData = $"TOTALE EURO".PadRight(25)+$"{totalCost.ToString("0.00")}";

            string footerData = $"\n\n{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}\nDOCUMENTO N. {  "0000-0000"  }"; // Document number not specified from the system
            footerData += "\n\nCon il programma fedeltà risparmi il 3% su ogni acquisto!\nPartecipa ora!";

            // Font e brush
            Font fontHeader = new Font("Consolas", 10);
            Font fontMain = new Font("Consolas", 9);
            Font fontTotalCost = new Font("Consolas", 11);
            Font fontFooter = new Font("Consolas", 8);
            Brush brush = Brushes.Black;

            // Area totale di stampa
            RectangleF totalPrintableArea = e.MarginBounds;
            
            // Area per l'Header
            float y = e.MarginBounds.Top;
            RectangleF printableAreaHeader = new RectangleF(new PointF(e.MarginBounds.X, y), new SizeF(totalPrintableArea.Width, e.Graphics.MeasureString(headerData, fontHeader, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height));
            // Area per il testo principale
            y += e.Graphics.MeasureString(headerData, fontHeader, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height;
            RectangleF printableAreaMain = new RectangleF(new PointF(e.MarginBounds.X, y), new SizeF(totalPrintableArea.Width, e.Graphics.MeasureString(mainData, fontMain, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height));
            // Area per il testo del costo totale
            y += e.Graphics.MeasureString(mainData, fontMain, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height;
            RectangleF printableAreaTotalCost = new RectangleF(new PointF(e.MarginBounds.X, y), new SizeF(totalPrintableArea.Width, e.Graphics.MeasureString(totalCostData, fontTotalCost, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height));
            // Area per il footer
            y += e.Graphics.MeasureString(totalCostData, fontTotalCost, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height;
            RectangleF printableAreaFooter = new RectangleF(new PointF(e.MarginBounds.X, y), new SizeF(totalPrintableArea.Width, e.Graphics.MeasureString(footerData, fontFooter, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height));
            // Aggiunge ancora perchè servirà dopo per il qr code
            y += e.Graphics.MeasureString(footerData, fontFooter, new SizeF(totalPrintableArea.Width, totalPrintableArea.Height)).Height;

            // Setting del format generico
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.Word;
            format.FormatFlags = StringFormatFlags.LineLimit;

            // Setting dei format
            StringFormat headerFormat = (StringFormat)format.Clone();
            headerFormat.Alignment = StringAlignment.Center;
            StringFormat mainFormat = (StringFormat)format.Clone();
            mainFormat.Alignment = StringAlignment.Near;
            StringFormat footerFormat = (StringFormat)format.Clone();
            footerFormat.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(
                headerData,
                fontHeader,
                brush,
                printableAreaHeader,
                headerFormat
            );
            e.Graphics.DrawString(
                mainData,
                fontMain,
                brush,
                printableAreaMain,
                mainFormat
            );
            e.Graphics.DrawString(
                totalCostData,
                fontTotalCost,
                brush,
                printableAreaTotalCost,
                mainFormat
            );
            e.Graphics.DrawString(
                footerData,
                fontFooter,
                brush,
                printableAreaFooter,
                footerFormat
            );


            // Prints a QR code to the website
            using (QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(SupermarketData.Website, QRCoder.QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCoder.QRCode(qrCodeData))
            using (Bitmap qrCodeImage = qrCode.GetGraphic(5))
            {
                float qrSize = 100f;
                float qrX = e.MarginBounds.Left + (e.MarginBounds.Width - qrSize) / 2; // to center the image
                float qrY = y + 10; // Below the footer
                // Draws it
                e.Graphics.DrawImage(qrCodeImage, new RectangleF(qrX, qrY, qrSize, qrSize));
            }

        }
    }
}
