
namespace Business_Administrator.Forms_Create
{
    partial class FormCreate_UpdateProduct
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
            this.textBoxMinimumStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonInsert_Update = new System.Windows.Forms.Button();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.comboBoxLine = new System.Windows.Forms.ComboBox();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxMinimumStock
            // 
            this.textBoxMinimumStock.AutoCompleteCustomSource.AddRange(new string[] {
            "NO TIENE"});
            this.textBoxMinimumStock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxMinimumStock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxMinimumStock.Location = new System.Drawing.Point(92, 206);
            this.textBoxMinimumStock.Name = "textBoxMinimumStock";
            this.textBoxMinimumStock.Size = new System.Drawing.Size(134, 20);
            this.textBoxMinimumStock.TabIndex = 6;
            this.textBoxMinimumStock.Tag = "";
            this.textBoxMinimumStock.Text = "0";
            this.textBoxMinimumStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "Descripcion:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(225, 20);
            this.labelTitle.TabIndex = 57;
            this.labelTitle.Text = "CREAR PRODUCTO";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonInsert_Update
            // 
            this.buttonInsert_Update.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonInsert_Update.FlatAppearance.BorderSize = 0;
            this.buttonInsert_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert_Update.Location = new System.Drawing.Point(92, 344);
            this.buttonInsert_Update.Name = "buttonInsert_Update";
            this.buttonInsert_Update.Size = new System.Drawing.Size(134, 23);
            this.buttonInsert_Update.TabIndex = 11;
            this.buttonInsert_Update.Tag = "";
            this.buttonInsert_Update.Text = "Agregar/Editar";
            this.buttonInsert_Update.UseVisualStyleBackColor = false;
            this.buttonInsert_Update.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxStock
            // 
            this.textBoxStock.AutoCompleteCustomSource.AddRange(new string[] {
            "NO TIENE"});
            this.textBoxStock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxStock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxStock.Location = new System.Drawing.Point(92, 170);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(134, 20);
            this.textBoxStock.TabIndex = 5;
            this.textBoxStock.Tag = "";
            this.textBoxStock.Text = "0";
            this.textBoxStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 40);
            this.label5.TabIndex = 56;
            this.label5.Text = "Stock Minimo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.AutoCompleteCustomSource.AddRange(new string[] {
            "0000000000"});
            this.textBoxBarcode.Location = new System.Drawing.Point(92, 100);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(134, 20);
            this.textBoxBarcode.TabIndex = 3;
            this.textBoxBarcode.Tag = "3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 40);
            this.label4.TabIndex = 55;
            this.label4.Text = "Codigo de Barras:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(92, 65);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(134, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Tag = "2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Stock:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.AutoCompleteCustomSource.AddRange(new string[] {
            "NO TIENE"});
            this.textBoxPrice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPrice.Location = new System.Drawing.Point(92, 144);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(134, 20);
            this.textBoxPrice.TabIndex = 4;
            this.textBoxPrice.Tag = "4";
            this.textBoxPrice.Text = "0";
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxReference
            // 
            this.textBoxReference.Location = new System.Drawing.Point(92, 39);
            this.textBoxReference.Name = "textBoxReference";
            this.textBoxReference.Size = new System.Drawing.Size(134, 20);
            this.textBoxReference.TabIndex = 1;
            this.textBoxReference.Tag = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Referencia:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "Precio:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 65;
            this.label8.Text = "Marca:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AutoCompleteCustomSource.AddRange(new string[] {
            "0000000000"});
            this.textBoxDescription.Location = new System.Drawing.Point(92, 237);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(134, 20);
            this.textBoxDescription.TabIndex = 7;
            this.textBoxDescription.Tag = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 64;
            this.label9.Text = "Proveedor:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 21);
            this.label10.TabIndex = 63;
            this.label10.Text = "Linea:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(92, 263);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(134, 21);
            this.comboBoxDealer.TabIndex = 8;
            this.comboBoxDealer.Tag = "";
            // 
            // comboBoxLine
            // 
            this.comboBoxLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLine.FormattingEnabled = true;
            this.comboBoxLine.Location = new System.Drawing.Point(92, 290);
            this.comboBoxLine.Name = "comboBoxLine";
            this.comboBoxLine.Size = new System.Drawing.Size(134, 21);
            this.comboBoxLine.TabIndex = 9;
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(92, 317);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(134, 21);
            this.comboBoxBrand.TabIndex = 10;
            // 
            // FormCreate_UpdateProduct
            // 
            this.AcceptButton = this.buttonInsert_Update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 381);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.comboBoxLine);
            this.Controls.Add(this.comboBoxDealer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxMinimumStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonInsert_Update);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBarcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxReference);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCreate_UpdateProduct";
            this.Text = "Create Product";
            this.Load += new System.EventHandler(this.FormCreateProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMinimumStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonInsert_Update;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxReference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.ComboBox comboBoxLine;
        private System.Windows.Forms.ComboBox comboBoxBrand;
    }
}