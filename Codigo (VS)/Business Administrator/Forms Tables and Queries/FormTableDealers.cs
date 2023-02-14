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
            connection.displayData(dataGridViewDealers, "EXEC displayDataDealers");
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
            if (dataGridViewDealers.SelectedRows.Count == 1)
            {
                string nameDealer = dataGridViewDealers.CurrentRow.Cells["NAME"].Value.ToString().Trim();
                int idDealer = Convert.ToInt32(dataGridViewDealers.CurrentRow.Cells["ID"].Value.ToString().Trim());
                DialogResult warningMessage = MessageBox.Show("Proveedor: "+nameDealer+
                    "\nID: "+idDealer+
                    "\nDesea eliminar de forma definitiva?", "Eliminar CLiente",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK)
                    {
                        Dealer dealer= new Dealer(idDealer);
                        dealer.delete();
                    }
                    dataUpload();
                }
            } else MessageBox.Show("Selecciona solamente un registro, por favor");
        }
    }
}
