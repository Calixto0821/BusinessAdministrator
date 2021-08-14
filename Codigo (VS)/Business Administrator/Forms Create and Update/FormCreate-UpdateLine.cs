using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Administrator.Forms_Create
{
    public partial class FormCreate_UpdateLine : Form
    {
        public FormCreate_UpdateLine()
        {
            InitializeComponent();
        }

        ownFunctions Functions = new ownFunctions();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Functions.checkLenghtTexBox(textBoxName,2))
            {
                Line line = new Line(textBoxName.Text);
                line.insert();
                this.DialogResult = DialogResult.OK;
                this.Hide();

            } else MessageBox.Show("LLENA EL CAMPO CON MINIMO 2 CARACTERES");
        }
    }
}
