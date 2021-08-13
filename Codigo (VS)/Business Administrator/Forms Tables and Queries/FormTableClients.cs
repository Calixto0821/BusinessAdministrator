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

        public void dataUpload()
        {
            string command = "EXEC displayDataClients";
            connection.displayData(dataGridViewClients, command);
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
                string process = null;
                try
                {
                    string documentUser = dataGridViewClients.CurrentRow.Cells["DOCUMENT"].Value.ToString().Trim();
                    string[] parametersQueryUsers = {"*", "USERS", "document='" + documentUser + "' AND user_type = 2" };
                    DataTable dataTableUsers = connection.querySelect(parametersQueryUsers);
                    string[] parametersQueryClients = {"*", "CLIENTS", "document_user='" + documentUser + "'" };
                    DataTable dataTableClients = connection.querySelect(parametersQueryClients);
                    FormClient.textBoxFirstName.Text = dataTableUsers.Rows[0]["first_Name"].ToString().Trim();
                    FormClient.textBoxLastName.Text = dataTableUsers.Rows[0]["last_Name"].ToString().Trim();
                    FormClient.textBoxDocument.Text = dataTableUsers.Rows[0]["document"].ToString().Trim();
                    FormClient.textBoxEmail.Text = dataTableUsers.Rows[0]["email"].ToString().Trim();
                    FormClient.textBoxCellphone.Text = dataTableUsers.Rows[0]["cellphone_Number"].ToString().Trim();
                    FormClient.textBoxBalance.Text = dataTableClients.Rows[0]["balance"].ToString().Trim();
                    FormClient.textBoxDebt.Text = dataTableClients.Rows[0]["debt"].ToString().Trim();
                    process = "Assignment successfully completed";
                    FormClient.updateMood = true;
                    FormClient.insertMood = false;
                    FormClient.textBoxDocument.Enabled = false;
                    FormClient.buttonInsert_Update.Text = "Actualizar";
                    FormClient.ShowDialog();
                    dataUpload();
                }
                catch(SqlException Error)
                {
                    process = "Error when completing the assignment => " + Error;
                    MessageBox.Show("Sucedio un error");
                }
                finally
                {
                    Console.WriteLine("Process: "+process);
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
                    Clients clients = new Clients(documentClient);
                    clients.delete();
                    dataUpload();
                }             
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonCloseApplication_Click(object sender, EventArgs e)
        {
            
        }
    }
}
