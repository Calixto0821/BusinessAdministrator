namespace Business_Administrator
{
    partial class FormCreate_UpdateClient
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxCellphone = new System.Windows.Forms.TextBox();
            this.labelCellphone = new System.Windows.Forms.Label();
            this.textBoxDocument = new System.Windows.Forms.TextBox();
            this.labelDocument = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonInsert_Update = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxDebt = new System.Windows.Forms.TextBox();
            this.labelDebt = new System.Windows.Forms.Label();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.labelBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(26, 44);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(58, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Nombre(s):";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(90, 41);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstName.TabIndex = 3;
            this.textBoxFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateChars_KeyPress);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(90, 67);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.textBoxLastName.TabIndex = 5;
            this.textBoxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateChars_KeyPress);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(32, 70);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(52, 13);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "Apellidos:";
            // 
            // textBoxCellphone
            // 
            this.textBoxCellphone.Location = new System.Drawing.Point(90, 93);
            this.textBoxCellphone.Name = "textBoxCellphone";
            this.textBoxCellphone.Size = new System.Drawing.Size(100, 20);
            this.textBoxCellphone.TabIndex = 7;
            this.textBoxCellphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelCellphone
            // 
            this.labelCellphone.AutoSize = true;
            this.labelCellphone.Location = new System.Drawing.Point(42, 96);
            this.labelCellphone.Name = "labelCellphone";
            this.labelCellphone.Size = new System.Drawing.Size(42, 13);
            this.labelCellphone.TabIndex = 6;
            this.labelCellphone.Text = "Celular:";
            // 
            // textBoxDocument
            // 
            this.textBoxDocument.Location = new System.Drawing.Point(90, 119);
            this.textBoxDocument.Name = "textBoxDocument";
            this.textBoxDocument.Size = new System.Drawing.Size(100, 20);
            this.textBoxDocument.TabIndex = 9;
            this.textBoxDocument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Location = new System.Drawing.Point(19, 122);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(65, 13);
            this.labelDocument.TabIndex = 8;
            this.labelDocument.Text = "Documento:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(90, 145);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmail.TabIndex = 11;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(49, 148);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 10;
            this.labelEmail.Text = "Email:";
            // 
            // buttonInsert_Update
            // 
            this.buttonInsert_Update.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonInsert_Update.FlatAppearance.BorderSize = 0;
            this.buttonInsert_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert_Update.Location = new System.Drawing.Point(90, 223);
            this.buttonInsert_Update.Name = "buttonInsert_Update";
            this.buttonInsert_Update.Size = new System.Drawing.Size(100, 23);
            this.buttonInsert_Update.TabIndex = 12;
            this.buttonInsert_Update.Text = "Agregar/Edit";
            this.buttonInsert_Update.UseVisualStyleBackColor = false;
            this.buttonInsert_Update.Click += new System.EventHandler(this.buttonInsert_Update_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(40, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(150, 20);
            this.labelTitle.TabIndex = 13;
            this.labelTitle.Text = "CLIENTE";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDebt
            // 
            this.textBoxDebt.Location = new System.Drawing.Point(90, 197);
            this.textBoxDebt.Name = "textBoxDebt";
            this.textBoxDebt.Size = new System.Drawing.Size(100, 20);
            this.textBoxDebt.TabIndex = 17;
            this.textBoxDebt.Text = "0";
            this.textBoxDebt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelDebt
            // 
            this.labelDebt.AutoSize = true;
            this.labelDebt.Location = new System.Drawing.Point(42, 200);
            this.labelDebt.Name = "labelDebt";
            this.labelDebt.Size = new System.Drawing.Size(42, 13);
            this.labelDebt.TabIndex = 16;
            this.labelDebt.Text = "Deuda:";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Location = new System.Drawing.Point(90, 171);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(100, 20);
            this.textBoxBalance.TabIndex = 15;
            this.textBoxBalance.Text = "0";
            this.textBoxBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(47, 174);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(37, 13);
            this.labelBalance.TabIndex = 14;
            this.labelBalance.Text = "Saldo:";
            // 
            // FormCreate_UpdateClient
            // 
            this.AcceptButton = this.buttonInsert_Update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 256);
            this.Controls.Add(this.textBoxDebt);
            this.Controls.Add(this.labelDebt);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonInsert_Update);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxDocument);
            this.Controls.Add(this.labelDocument);
            this.Controls.Add(this.textBoxCellphone);
            this.Controls.Add(this.labelCellphone);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreate_UpdateClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCreateClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelCellphone;
        private System.Windows.Forms.Label labelDocument;
        private System.Windows.Forms.Label labelEmail;
        public System.Windows.Forms.Button buttonInsert_Update;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDebt;
        private System.Windows.Forms.Label labelBalance;
        public System.Windows.Forms.TextBox textBoxFirstName;
        public System.Windows.Forms.TextBox textBoxLastName;
        public System.Windows.Forms.TextBox textBoxCellphone;
        public System.Windows.Forms.TextBox textBoxDocument;
        public System.Windows.Forms.TextBox textBoxEmail;
        public System.Windows.Forms.TextBox textBoxDebt;
        public System.Windows.Forms.TextBox textBoxBalance;
    }
}

