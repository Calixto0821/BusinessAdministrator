using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Administrator.Forms_Tables_and_Queries
{
    public partial class FormTableServices : Form
    {
        public FormTableServices()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        private void FormTableServices_Load(object sender, EventArgs e)
        {
            string command = "EXEC displayDataServices";
            connection.displayData(dataGridViewServices, command);
        }
    }
}
