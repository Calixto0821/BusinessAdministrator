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
    public partial class FormClientBalance : Form
    {
        public FormClientBalance()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        public double balance, debt;
        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonUpdateBalance_Click(object sender, EventArgs e)
        {

        }

        private void FormClientBalance_Load(object sender, EventArgs e)
        {
            double total;
            total = this.balance - this.debt;
            if (total > 0) textTotal.ForeColor = Color.Green;
            else if (total < 0) textTotal.ForeColor = Color.Red;
            else if (total == 0) textTotal.ForeColor = Color.FromArgb(66, 133, 244);
            textTotal.Text = Convert.ToString(total);

        }
    }
}
