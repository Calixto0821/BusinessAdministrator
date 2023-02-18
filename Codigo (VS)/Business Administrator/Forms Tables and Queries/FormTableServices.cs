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
    public partial class FormTableServices : Form
    {
        public FormTableServices()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        private void dataUpload()
        {
            connection.displayData(dataGridViewServices, "EXEC displayDataServices");
        }

        private void FormTableServices_Load(object sender, EventArgs e)
        {
            dataUpload();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Forms_Create.FormCreate_UpdateService FormService = new Forms_Create.FormCreate_UpdateService();
            if (dataGridViewServices.SelectedRows.Count == 1)
            {
                try
                {
                    string serviceID = dataGridViewServices.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryServices = { "*", "SERVICES", "id=" + serviceID + " AND status = 1" };
                    DataTable dataTableServices = connection.querySelect(parametersQueryServices);
                    FormService.serviceID = serviceID;
                    FormService.textBoxName.Text = dataTableServices.Rows[0]["name"].ToString().Trim();
                    FormService.textBoxReference.Text = dataTableServices.Rows[0]["reference"].ToString().Trim();
                    FormService.textBoxBarcode.Text = dataTableServices.Rows[0]["barcode"].ToString().Trim();
                    FormService.textBoxPrice.Text = dataTableServices.Rows[0]["price"].ToString().Trim();
                    FormService.textBoxDescription.Text = dataTableServices.Rows[0]["description"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormService.insertMood = false;
                    FormService.updateMood = true;
                    FormService.buttonInsert_Update.Text = "Actualizar";
                    FormService.ShowDialog();
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
            if (dataGridViewServices.SelectedRows.Count == 1)
            {
                string nameService= dataGridViewServices.CurrentRow.Cells["NAME"].Value.ToString().Trim();
                int serviceID = Convert.ToInt32(dataGridViewServices.CurrentRow.Cells["ID"].Value.ToString().Trim());
                DialogResult warningMessage = MessageBox.Show("Servicio: " + nameService +
                    "\nID: " + serviceID +
                    "\nDesea eliminar de forma definitiva?", "Eliminar Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK)
                    {
                        Service service = new Service(serviceID);
                        service.delete();
                    }
                    dataUpload();
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }
    }
}
