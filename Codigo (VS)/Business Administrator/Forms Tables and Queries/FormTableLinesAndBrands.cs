using Business_Administrator.Forms_Create;
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

        private void dataUpload(DataGridView dataGridShow,string command)
        {
            connection.displayData(dataGridShow, command);
        }

        private void FormTableLinesAndBrands_Load(object sender, EventArgs e)
        {
            string commandLines = "EXEC displayDataLines";
            connection.displayData(dataGridViewLines,commandLines);
            string commandBrands = "EXEC displayDataBrands";
            connection.displayData(dataGridViewBrands, commandBrands);
        }

        private void buttonLineEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateLine FormLine = new FormCreate_UpdateLine();
            if(dataGridViewLines.SelectedRows.Count == 1)
            {
                try
                {
                    string idLine = dataGridViewLines.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryLine = { "*", "LINES", "id=" + idLine + "AND status=1" };
                    DataTable dataTableLines = connection.querySelect(parametersQueryLine);
                    FormLine.textBoxName.Text = dataTableLines.Rows[0]["name"].ToString().Trim();
                    FormLine.labelIDLine.Text = dataTableLines.Rows[0]["id"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormLine.updateMood = true;
                    FormLine.insertMood = false;
                    FormLine.ShowDialog();
                    dataUpload(dataGridViewLines,"EXEC displayDataLines");
                }
                catch(Exception Error)
                {
                    Console.WriteLine("Process: Error when completing the assignment => " + Error);
                    MessageBox.Show("Sucedio un error");
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonBrandEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateBrand FormBrand = new FormCreate_UpdateBrand();
            if (dataGridViewLines.SelectedRows.Count == 1)
            {
                try
                {
                    string idBrand = dataGridViewBrands.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryBrand = { "*", "BRANDS", "id=" + idBrand + "AND status=1" };
                    DataTable dataTableBrand = connection.querySelect(parametersQueryBrand);
                    FormBrand.textBoxName.Text = dataTableBrand.Rows[0]["name"].ToString().Trim();
                    FormBrand.labelIDBrand.Text = dataTableBrand.Rows[0]["id"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormBrand.updateMood = true;
                    FormBrand.insertMood = false;
                    FormBrand.ShowDialog();
                    dataUpload(dataGridViewBrands,"EXEC displayDataBrands");
                }
                catch (Exception Error)
                {
                    Console.WriteLine("Process: Error when completing the assignment => " + Error);
                    MessageBox.Show("Sucedio un error");
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }
    }
}
