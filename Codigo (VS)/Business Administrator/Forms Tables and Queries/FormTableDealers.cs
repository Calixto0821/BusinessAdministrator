using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Business_Administrator.Forms_Tables_and_Queries
{
    public partial class FormTableDealers : Form
    {
        public FormTableDealers()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();
        
        private void dataUpload()
        {
            string command = "EXEC displayDataDealers";
            connection.displayData(dataGridViewDealers, command);
        }
        
        private void FormTableDealers_Load(object sender, EventArgs e)
        {
            dataUpload();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateDealer FormDealer = new FormCreate_UpdateDealer();
            if (dataGridViewDealers.SelectedRows.Count == 1)
            {
                try
                {
                    string dealerID = dataGridViewDealers.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryDealers = { "*", "DEALERS", "id=" + dealerID + " AND status = 1" };
                    DataTable dataTableDealers = connection.querySelect(parametersQueryDealers);
                    FormDealer.dealerID = dealerID;
                    FormDealer.textBoxName.Text = dataTableDealers.Rows[0]["name"].ToString().Trim();
                    FormDealer.textBoxPhone.Text = dataTableDealers.Rows[0]["number_phone"].ToString().Trim();
                    FormDealer.textBoxCellphone.Text = dataTableDealers.Rows[0]["number_cellphone"].ToString().Trim();
                    FormDealer.textBoxAddress.Text = dataTableDealers.Rows[0]["address"].ToString().Trim();
                    FormDealer.textBoxWeb.Text = dataTableDealers.Rows[0]["web"].ToString().Trim();
                    FormDealer.textBoxEmail.Text = dataTableDealers.Rows[0]["contact_email"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormDealer.insertMood = false;
                    FormDealer.updateMood = true;
                    FormDealer.buttonInsert_Update.Text = "Actualizar";
                    FormDealer.ShowDialog();
                    dataUpload();

                }
                catch (SqlException Error)
                {
                    Console.WriteLine("Process: Error when completing the assignment => " + Error);
                    MessageBox.Show("Sucedio un error");
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
