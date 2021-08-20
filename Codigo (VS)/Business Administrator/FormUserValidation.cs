using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Administrator
{
    public partial class FormUserValidation : Form
    {
        public FormUserValidation()
        {
            InitializeComponent();
        }

        ConnectionDB connection = new ConnectionDB();

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            this.DialogResult = connection.ValidateUser(textBoxPassword.Text);
        }
    }
}
