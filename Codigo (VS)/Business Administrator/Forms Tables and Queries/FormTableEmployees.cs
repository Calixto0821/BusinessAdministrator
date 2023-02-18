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
    public partial class FormTableEmployees : Form
    {
        public FormTableEmployees()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        public void dataUpload()
        {
            connection.displayData(dataGridViewEmployees, "EXEC displayDataEmployees");
        }

        private void checkUser(string docuUser)
        {
            FormCreate_UpdateEmployee FormEmployee = new FormCreate_UpdateEmployee();
            if (Globals.documentCurrentUser != docuUser)
            {
                Console.WriteLine("DISTINTC USER ([" + Globals.documentCurrentUser + "]!=[" + docuUser + "])");
                FormEmployee.textBoxPassword.Enabled = false;
                FormEmployee.textBoxPassword.UseSystemPasswordChar = true;
                FormEmployee.textBoxUser.Enabled = false;
            }
            else if (Globals.documentCurrentUser == docuUser)
            {
                Console.WriteLine("SAME USER ([" + Globals.documentCurrentUser + "]==[" + docuUser + "])");
                FormEmployee.textBoxPassword.Enabled = true;
                FormEmployee.textBoxPassword.UseSystemPasswordChar = false;
                FormEmployee.textBoxUser.Enabled = true;
            }
        }
        
        private void FormTableEmployees_Load(object sender, EventArgs e)
        {
            dataUpload();
            if (connection.checkAdmin(Globals.documentCurrentUser))
            {
                buttonDelete.Enabled = true;
            }
            else if (!connection.checkAdmin(Globals.documentCurrentUser))
            {
                buttonDelete.Enabled = false;
            }
            else Console.WriteLine("Error checking user Administrator");
            Console.WriteLine(Globals.documentCurrentUser + " have acceded to TableEmployee");
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateEmployee FormEmployee = new FormCreate_UpdateEmployee();
            if (dataGridViewEmployees.SelectedRows.Count == 1)
            {
                try 
                {
                    string documentUser = dataGridViewEmployees.CurrentRow.Cells["DOCUMENT"].Value.ToString().Trim();
                    string[] parametersQueryUsers = {"*","USERS","document='"+ documentUser + "'" };
                    DataTable dataTableUsers = connection.querySelect(parametersQueryUsers);
                    string[] parametersQueryEmployees = { "*", "EMPLOYEES", "document_user='" + documentUser + "'" };
                    DataTable dataTableEmployees = connection.querySelect(parametersQueryEmployees);
                    FormEmployee.textBoxFirstName.Text = dataTableUsers.Rows[0]["first_name"].ToString().Trim();
                    FormEmployee.textBoxLastName.Text = dataTableUsers.Rows[0]["last_Name"].ToString().Trim();
                    FormEmployee.textBoxDocument.Text = dataTableUsers.Rows[0]["document"].ToString().Trim();
                    FormEmployee.textBoxEmail.Text = dataTableUsers.Rows[0]["email"].ToString().Trim();
                    FormEmployee.textBoxCellphone.Text = dataTableUsers.Rows[0]["cellphone_Number"].ToString().Trim();
                    FormEmployee.textBoxUser.Text = dataTableEmployees.Rows[0]["nickname"].ToString().Trim();
                    FormEmployee.textBoxPassword.Text = dataTableEmployees.Rows[0]["password"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");
                    
                    FormEmployee.updateMood = true;
                    FormEmployee.insertMood = false;
                    FormEmployee.administratorMood = false;
                    FormEmployee.textBoxDocument.Enabled = false;
                    checkUser(documentUser);
                    FormEmployee.ShowDialog();
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
            if (dataGridViewEmployees.SelectedRows.Count == 1)
            {
                string nameEmployee = dataGridViewEmployees.CurrentRow.Cells["FULL NAME"].Value.ToString().Trim();
                string documentEmployee = dataGridViewEmployees.CurrentRow.Cells["DOCUMENT"].Value.ToString().Trim();
                DialogResult warningMessage = MessageBox.Show("Empleado: " + nameEmployee +
                    "\nDocumento: " + documentEmployee +
                    "\nDesea eliminar de forma definitiva?", "Eliminar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK)
                    {
                        Employee employee = new Employee(documentEmployee);
                        employee.delete();
                    }     
                    dataUpload();
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }
    }
}
