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
            this.labelBalance = new System.Windows.Forms.Label();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.labelDebt = new System.Windows.Forms.Label();
            this.textBoxDebt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelName.Location = new System.Drawing.Point(16, 58);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(81, 19);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Nombre(s):";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFirstName.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxFirstName.Location = new System.Drawing.Point(103, 58);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(172, 20);
            this.textBoxFirstName.TabIndex = 1;
            this.textBoxFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateChars_KeyPress);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastName.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxLastName.Location = new System.Drawing.Point(103, 84);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(172, 20);
            this.textBoxLastName.TabIndex = 2;
            this.textBoxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateChars_KeyPress);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelLastName.Location = new System.Drawing.Point(24, 84);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(73, 19);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "Apellidos:";
            // 
            // textBoxCellphone
            // 
            this.textBoxCellphone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxCellphone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCellphone.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxCellphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxCellphone.Location = new System.Drawing.Point(103, 110);
            this.textBoxCellphone.Name = "textBoxCellphone";
            this.textBoxCellphone.Size = new System.Drawing.Size(172, 20);
            this.textBoxCellphone.TabIndex = 3;
            this.textBoxCellphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelCellphone
            // 
            this.labelCellphone.AutoSize = true;
            this.labelCellphone.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelCellphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelCellphone.Location = new System.Drawing.Point(38, 110);
            this.labelCellphone.Name = "labelCellphone";
            this.labelCellphone.Size = new System.Drawing.Size(59, 19);
            this.labelCellphone.TabIndex = 6;
            this.labelCellphone.Text = "Celular:";
            // 
            // textBoxDocument
            // 
            this.textBoxDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxDocument.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDocument.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxDocument.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxDocument.Location = new System.Drawing.Point(103, 136);
            this.textBoxDocument.Name = "textBoxDocument";
            this.textBoxDocument.Size = new System.Drawing.Size(172, 20);
            this.textBoxDocument.TabIndex = 4;
            this.textBoxDocument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelDocument
            // 
            this.labelDocument.AutoSize = true;
            this.labelDocument.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelDocument.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelDocument.Location = new System.Drawing.Point(11, 136);
            this.labelDocument.Name = "labelDocument";
            this.labelDocument.Size = new System.Drawing.Size(86, 19);
            this.labelDocument.TabIndex = 8;
            this.labelDocument.Text = "Documento:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxEmail.Location = new System.Drawing.Point(103, 162);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(172, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelEmail.Location = new System.Drawing.Point(48, 162);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(49, 19);
            this.labelEmail.TabIndex = 10;
            this.labelEmail.Text = "Email:";
            // 
            // buttonInsert_Update
            // 
            this.buttonInsert_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonInsert_Update.FlatAppearance.BorderSize = 0;
            this.buttonInsert_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.buttonInsert_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert_Update.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.buttonInsert_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.buttonInsert_Update.Location = new System.Drawing.Point(104, 240);
            this.buttonInsert_Update.Name = "buttonInsert_Update";
            this.buttonInsert_Update.Size = new System.Drawing.Size(172, 33);
            this.buttonInsert_Update.TabIndex = 8;
            this.buttonInsert_Update.Text = "Agregar/Editar";
            this.buttonInsert_Update.UseVisualStyleBackColor = false;
            this.buttonInsert_Update.Click += new System.EventHandler(this.buttonInsert_Update_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Roboto Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(263, 35);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "CLIENTE";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelBalance.Location = new System.Drawing.Point(48, 188);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(49, 19);
            this.labelBalance.TabIndex = 14;
            this.labelBalance.Text = "Saldo:";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBalance.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxBalance.Location = new System.Drawing.Point(103, 188);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(172, 20);
            this.textBoxBalance.TabIndex = 6;
            this.textBoxBalance.Text = "0";
            this.textBoxBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // labelDebt
            // 
            this.labelDebt.AutoSize = true;
            this.labelDebt.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.labelDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelDebt.Location = new System.Drawing.Point(43, 214);
            this.labelDebt.Name = "labelDebt";
            this.labelDebt.Size = new System.Drawing.Size(54, 19);
            this.labelDebt.TabIndex = 16;
            this.labelDebt.Text = "Deuda:";
            // 
            // textBoxDebt
            // 
            this.textBoxDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxDebt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDebt.Font = new System.Drawing.Font("Roboto Condensed", 12F);
            this.textBoxDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxDebt.Location = new System.Drawing.Point(103, 214);
            this.textBoxDebt.Name = "textBoxDebt";
            this.textBoxDebt.Size = new System.Drawing.Size(172, 20);
            this.textBoxDebt.TabIndex = 7;
            this.textBoxDebt.Text = "0";
            this.textBoxDebt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateNumbers_KeyPress);
            // 
            // FormCreate_UpdateClient
            // 
            this.AcceptButton = this.buttonInsert_Update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(287, 285);
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
        public System.Windows.Forms.TextBox textBoxFirstName;
        public System.Windows.Forms.TextBox textBoxLastName;
        public System.Windows.Forms.TextBox textBoxCellphone;
        public System.Windows.Forms.TextBox textBoxDocument;
        public System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelBalance;
        public System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.Label labelDebt;
        public System.Windows.Forms.TextBox textBoxDebt;
    }
}

