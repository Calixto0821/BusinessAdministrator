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
    public partial class FormTableClients : Form
    {
        public FormTableClients()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        private void dataUpload()
        {
            connection.displayData(dataGridViewClients, "EXEC displayDataDealers");
        }

        private void FormTableClients_Load(object sender, EventArgs e)
        {
            dataUpload();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateClient FormClient = new FormCreate_UpdateClient();
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                try
                {
                    string userDocument = dataGridViewClients.CurrentRow.Cells["DOCUMENT"].Value.ToString().Trim();
                    string[] parametersQueryUsers = {"*", "USERS", "document='" + userDocument + "' AND user_type = 2" };
                    DataTable dataTableUsers = connection.querySelect(parametersQueryUsers);
                    string[] parametersQueryClients = {"*", "CLIENTS", "document_user='" + userDocument + "'" };
                    DataTable dataTableClients = connection.querySelect(parametersQueryClients);
                    FormClient.textBoxFirstName.Text = dataTableUsers.Rows[0]["first_Name"].ToString().Trim();
                    FormClient.textBoxLastName.Text = dataTableUsers.Rows[0]["last_Name"].ToString().Trim();
                    FormClient.textBoxDocument.Text = dataTableUsers.Rows[0]["document"].ToString().Trim();
                    FormClient.textBoxEmail.Text = dataTableUsers.Rows[0]["email"].ToString().Trim();
                    FormClient.textBoxCellphone.Text = dataTableUsers.Rows[0]["cellphone_Number"].ToString().Trim();
                    FormClient.textBoxBalance.Text = dataTableClients.Rows[0]["balance"].ToString().Trim();
                    FormClient.textBoxDebt.Text = dataTableClients.Rows[0]["debt"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormClient.updateMood = true;
                    FormClient.insertMood = false;
                    FormClient.textBoxDocument.Enabled = false;
                    FormClient.buttonInsert_Update.Text = "Actualizar";
                    FormClient.ShowDialog();
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
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                string nameClient = dataGridViewClients.CurrentRow.Cells["FULL NAME"].Value.ToString().Trim();
                string documentClient = dataGridViewClients.CurrentRow.Cells["DOCUMENT"].Value.ToString().Trim();
                DialogResult warningMessage = MessageBox.Show("Cliente: "+nameClient+
                    "\nDocumento: "+documentClient+
                    "\nDesea eliminar de forma definitiva?", "Eliminar Cliente", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK){
                        Client clients = new Client(documentClient);
                        clients.delete();
                    }
                    dataUpload();
                }             
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonCloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBalance_Click(object sender, EventArgs e)
        {
            FormClientBalance formClientBalance = new FormClientBalance();
            string currentUserID = dataGridViewClients.CurrentRow.Cells["ID USER"].Value.ToString().Trim();
            string procedure = "getDataClientBalance @UserID = "+currentUserID;
            DataTable dataTable = connection.execProcedure(procedure);
            formClientBalance.balance = Convert.ToDouble(dataTable.Rows[0]["BALANCE"].ToString().Trim());
            formClientBalance.debt = Convert.ToDouble(dataTable.Rows[0]["DEBT"].ToString().Trim());
            formClientBalance.ShowDialog();
        }
    }
}
