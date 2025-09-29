namespace Supermarket
{
    partial class SelectProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_loadCatalog = new System.Windows.Forms.Button();
            this.lbl_selectedProduct = new System.Windows.Forms.Label();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nmu_quantity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txb_code);
            this.splitContainer1.Panel1.Controls.Add(this.btn_loadCatalog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.nmu_quantity);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_selectedProduct);
            this.splitContainer1.Panel2.Controls.Add(this.btn_confirm);
            this.splitContainer1.Size = new System.Drawing.Size(350, 301);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.Location = new System.Drawing.Point(218, 38);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(108, 40);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "Conferma";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_loadCatalog
            // 
            this.btn_loadCatalog.Location = new System.Drawing.Point(218, 60);
            this.btn_loadCatalog.Name = "btn_loadCatalog";
            this.btn_loadCatalog.Size = new System.Drawing.Size(108, 50);
            this.btn_loadCatalog.TabIndex = 0;
            this.btn_loadCatalog.Text = "Seleziona dal Catalogo";
            this.btn_loadCatalog.UseVisualStyleBackColor = true;
            this.btn_loadCatalog.Click += new System.EventHandler(this.btn_loadCatalog_Click);
            // 
            // lbl_selectedProduct
            // 
            this.lbl_selectedProduct.AutoSize = true;
            this.lbl_selectedProduct.Location = new System.Drawing.Point(12, 35);
            this.lbl_selectedProduct.Name = "lbl_selectedProduct";
            this.lbl_selectedProduct.Size = new System.Drawing.Size(142, 13);
            this.lbl_selectedProduct.TabIndex = 1;
            this.lbl_selectedProduct.Text = "Nessun Prodotto selezionato";
            // 
            // txb_code
            // 
            this.txb_code.Location = new System.Drawing.Point(15, 76);
            this.txb_code.MaxLength = 12;
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(139, 20);
            this.txb_code.TabIndex = 1;
            this.txb_code.TextChanged += new System.EventHandler(this.txb_code_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inserisci Codice Prodotto";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(177, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 150);
            this.panel1.TabIndex = 3;
            // 
            // nmu_quantity
            // 
            this.nmu_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmu_quantity.Location = new System.Drawing.Point(68, 56);
            this.nmu_quantity.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmu_quantity.Name = "nmu_quantity";
            this.nmu_quantity.Size = new System.Drawing.Size(35, 21);
            this.nmu_quantity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantità:";
            // 
            // SelectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 301);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SelectProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectProduct";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmu_quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_loadCatalog;
        private System.Windows.Forms.Label lbl_selectedProduct;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmu_quantity;
    }
}