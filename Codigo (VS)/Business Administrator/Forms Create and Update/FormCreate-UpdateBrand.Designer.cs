
namespace Business_Administrator.Forms_Create
{
    partial class FormCreate_UpdateBrand
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonInsert_Update = new System.Windows.Forms.Button();
            this.labelIDBrand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.textBoxName.Location = new System.Drawing.Point(112, 102);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(229, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 43);
            this.label2.TabIndex = 46;
            this.label2.Text = "MARCA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelName.Location = new System.Drawing.Point(19, 102);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(87, 25);
            this.labelName.TabIndex = 47;
            this.labelName.Text = "Nombre:";
            // 
            // buttonInsert_Update
            // 
            this.buttonInsert_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonInsert_Update.FlatAppearance.BorderSize = 0;
            this.buttonInsert_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.buttonInsert_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonInsert_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.buttonInsert_Update.Location = new System.Drawing.Point(112, 134);
            this.buttonInsert_Update.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInsert_Update.Name = "buttonInsert_Update";
            this.buttonInsert_Update.Size = new System.Drawing.Size(229, 41);
            this.buttonInsert_Update.TabIndex = 48;
            this.buttonInsert_Update.Text = "Agregar/Editar";
            this.buttonInsert_Update.UseVisualStyleBackColor = false;
            this.buttonInsert_Update.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelIDBrand
            // 
            this.labelIDBrand.AutoSize = true;
            this.labelIDBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelIDBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.labelIDBrand.Location = new System.Drawing.Point(114, 67);
            this.labelIDBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIDBrand.Name = "labelIDBrand";
            this.labelIDBrand.Size = new System.Drawing.Size(88, 25);
            this.labelIDBrand.TabIndex = 56;
            this.labelIDBrand.Text = "ID Brand";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.label1.Location = new System.Drawing.Point(69, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 55;
            this.label1.Text = "ID:";
            // 
            // FormCreate_UpdateBrand
            // 
            this.AcceptButton = this.buttonInsert_Update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(376, 188);
            this.Controls.Add(this.labelIDBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInsert_Update);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreate_UpdateBrand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCreate_UpdateBrand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Button buttonInsert_Update;
        public System.Windows.Forms.Label labelIDBrand;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxName;
    }
}