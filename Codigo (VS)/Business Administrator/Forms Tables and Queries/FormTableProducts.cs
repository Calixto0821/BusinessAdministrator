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
    public partial class FormTableProducts : Form
    {
        public FormTableProducts()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();


        private void dataUpload()
        {
            connection.displayData(dataGridViewProducts, "EXEC displayDataProducts");
        }

        private void FormTableProducts_Load(object sender, EventArgs e)
        {
            dataUpload();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                string nameProduct = dataGridViewProducts.CurrentRow.Cells["NAME"].Value.ToString().Trim();
                int productID = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells["ID"].Value.ToString().Trim());
                DialogResult warningMessage = MessageBox.Show("Producto: " + nameProduct +
                    "\nID: " + productID +
                    "\nDesea eliminar de forma definitiva?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK)
                    {
                        Product product= new Product(productID);
                        product.delete();
                    }
                    dataUpload();
                }
            } else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Forms_Create.FormCreate_UpdateProduct FormProduct = new Forms_Create.FormCreate_UpdateProduct();
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                try
                {
                    string productID = dataGridViewProducts.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryProducts = { "*", "PRODUCTS", "id= " + productID + " AND status = 1" };
                    DataTable dataTableProducts = connection.querySelect(parametersQueryProducts);
                    FormProduct.productID = Convert.ToInt32(productID);
                    FormProduct.textBoxReference.Text = dataTableProducts.Rows[0]["reference"].ToString().Trim();
                    FormProduct.textBoxName.Text = dataTableProducts.Rows[0]["name"].ToString().Trim();
                    FormProduct.textBoxBarcode.Text = dataTableProducts.Rows[0]["barcode"].ToString().Trim();
                    FormProduct.textBoxPrice.Text = dataTableProducts.Rows[0]["price"].ToString().Trim();
                    FormProduct.textBoxStock.Text = dataTableProducts.Rows[0]["stock"].ToString().Trim();
                    FormProduct.textBoxMinimumStock.Text = dataTableProducts.Rows[0]["minimum_stock"].ToString().Trim();
                    FormProduct.textBoxDescription.Text = dataTableProducts.Rows[0]["description"].ToString().Trim();
                    string dealerID = dataTableProducts.Rows[0]["id_dealer"].ToString().Trim();
                    connection.fillComboBoxAccordingToParameter(FormProduct.comboBoxDealer,"DEALERS","name","id", dealerID);
                    string brandID = dataTableProducts.Rows[0]["id_brand"].ToString().Trim();
                    connection.fillComboBoxAccordingToParameter(FormProduct.comboBoxBrand,"BRANDS","name","id",brandID);
                    string lineID = dataTableProducts.Rows[0]["id_line"].ToString().Trim();
                    connection.fillComboBoxAccordingToParameter(FormProduct.comboBoxLine, "LINES", "name", "id",lineID);
                    Console.WriteLine("Assignment successfully completed");

                    FormProduct.insertMood = false;
                    FormProduct.updateMood = true;
                    FormProduct.buttonInsert_Update.Text = "Actualizar";
                    FormProduct.ShowDialog();
                    dataUpload();
                }
                catch (SqlException Error)
                {
                    Console.WriteLine("Process: Error when completing the assignment => " + Error);
                    MessageBox.Show("Sucedio un error");
                }
            } else MessageBox.Show("Selecciona solamente un registro, por favor"); 
        }
    }
}
