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
    public partial class FormTableLinesAndBrands : Form
    {
        public FormTableLinesAndBrands()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        private void FormTableLinesAndBrands_Load(object sender, EventArgs e)
        {
            string commandLines = "EXEC displayDataLines";
            connection.displayData(dataGridViewLines,commandLines);
            string commandBrands = "EXEC displayDataBrands";
            connection.displayData(dataGridViewBrands, commandBrands);
        }
    }
}
