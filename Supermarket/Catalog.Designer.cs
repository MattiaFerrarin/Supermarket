namespace Supermarket
{
    partial class Catalog
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_back = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_addProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_addSection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_rename = new System.Windows.Forms.ToolStripButton();
            this.tsb_delete = new System.Windows.Forms.ToolStripButton();
            this.lbl_address = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 45);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(776, 393);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_back,
            this.toolStripDropDownButton1,
            this.tsb_rename,
            this.tsb_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_back
            // 
            this.tsb_back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_back.Image = global::Supermarket.Properties.Resources.GoToPrevious;
            this.tsb_back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_back.Name = "tsb_back";
            this.tsb_back.Size = new System.Drawing.Size(23, 22);
            this.tsb_back.Text = "Indietro";
            this.tsb_back.Click += new System.EventHandler(this.tsb_back_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_addProduct,
            this.tsmi_addSection});
            this.toolStripDropDownButton1.Image = global::Supermarket.Properties.Resources.Add;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "Aggiungi";
            // 
            // tsmi_addProduct
            // 
            this.tsmi_addProduct.Image = global::Supermarket.Properties.Resources.AddItem;
            this.tsmi_addProduct.Name = "tsmi_addProduct";
            this.tsmi_addProduct.Size = new System.Drawing.Size(121, 22);
            this.tsmi_addProduct.Text = "Prodotto";
            this.tsmi_addProduct.Click += new System.EventHandler(this.tsmi_addProduct_Click);
            // 
            // tsmi_addSection
            // 
            this.tsmi_addSection.Image = global::Supermarket.Properties.Resources.AddFolder;
            this.tsmi_addSection.Name = "tsmi_addSection";
            this.tsmi_addSection.Size = new System.Drawing.Size(121, 22);
            this.tsmi_addSection.Text = "Sezione";
            this.tsmi_addSection.Click += new System.EventHandler(this.tsmi_addSection_Click);
            // 
            // tsb_rename
            // 
            this.tsb_rename.Image = global::Supermarket.Properties.Resources.EditLabel;
            this.tsb_rename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_rename.Name = "tsb_rename";
            this.tsb_rename.Size = new System.Drawing.Size(78, 22);
            this.tsb_rename.Text = "Rinomina";
            this.tsb_rename.Click += new System.EventHandler(this.tsb_rename_Click);
            // 
            // tsb_delete
            // 
            this.tsb_delete.Image = global::Supermarket.Properties.Resources.Cancel;
            this.tsb_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_delete.Name = "tsb_delete";
            this.tsb_delete.Size = new System.Drawing.Size(66, 22);
            this.tsb_delete.Text = "Elimina";
            this.tsb_delete.Click += new System.EventHandler(this.tsb_delete_Click);
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Location = new System.Drawing.Point(12, 29);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(35, 13);
            this.lbl_address.TabIndex = 2;
            this.lbl_address.Text = "Path: ";
            // 
            // Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.Name = "Catalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_delete;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_addProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmi_addSection;
        private System.Windows.Forms.ToolStripButton tsb_rename;
        private System.Windows.Forms.ToolStripButton tsb_back;
        private System.Windows.Forms.Label lbl_address;
    }
}

