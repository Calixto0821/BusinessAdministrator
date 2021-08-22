using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Administrator.Forms_Create
{
    public partial class FormCreate_UpdateProduct : Form
    {

        public FormCreate_UpdateProduct()
        {
            InitializeComponent();
        }

        ownFunctions Functions = new ownFunctions();
        ConnectionDB connection = new ConnectionDB();
        public bool insertMood = false;
        public bool updateMood = false;
        public int productID;
        public int dealerID;

        private void FormCreateProduct_Load(object sender, EventArgs e)
        {
            if (insertMood)
            {
                connection.fillComboBox(comboBoxDealer, "DEALERS", "name");
                connection.fillComboBox(comboBoxBrand, "BRANDS", "name");
                connection.fillComboBox(comboBoxLine, "LINES", "name");
            }
        }

        #region ValidateData
        Validate validate = new Validate();
        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);
        private void validateChars_KeyPress(object sender, KeyPressEventArgs chars) => validate.onlyChars(chars);
        #endregion

        private void buttonInsert_Update_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { textBoxReference, textBoxName, textBoxBarcode, textBoxPrice, textBoxStock, textBoxMinimumStock };
            ComboBox[] comboBoxes = { comboBoxDealer, comboBoxBrand, comboBoxLine };
            if (Functions.checkFields(textBoxes) && Functions.checkCombos(comboBoxes))
            {
                if (0 != Convert.ToDouble(textBoxPrice.Text))
                {
                    int id_dealer = connection.searchId("DEALERS", "name", comboBoxDealer.Text);
                    int id_brand = connection.searchId("BRANDS", "name", comboBoxBrand.Text); ;
                    int id_line = connection.searchId("LINES", "name", comboBoxLine.Text);
                    Product PRODUCT = new Product(textBoxReference.Text, textBoxName.Text, textBoxBarcode.Text, double.Parse(textBoxPrice.Text),
                        id_dealer, id_brand, id_line,
                        int.Parse(textBoxStock.Text), int.Parse(textBoxMinimumStock.Text), textBoxDescription.Text);
                    if (insertMood)
                    {
                        DialogResult messageQuestionInsert = MessageBox.Show("Desea registrar un nuevo producto?", "Registrar Producto Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionInsert == DialogResult.Yes)
                        {
                            DialogResult dialogResultValidation = new DialogResult();
                            FormUserValidation formUserValidation = new FormUserValidation();
                            dialogResultValidation = formUserValidation.ShowDialog();
                            if (dialogResultValidation == DialogResult.OK) PRODUCT.insert();
                        }
                    }
                    else if (updateMood)
                    {
                        DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar los datos del producto?", "Editar Proveedor " + productID, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionUpdate == DialogResult.Yes)
                        {
                            DialogResult dialogResultValidation = new DialogResult();
                            FormUserValidation formUserValidation = new FormUserValidation();
                            dialogResultValidation = formUserValidation.ShowDialog();
                            if (dialogResultValidation == DialogResult.OK) PRODUCT.update(productID);
                        }

                    }
                    else Console.WriteLine("Both moods are flase");
                    
                    this.DialogResult = DialogResult.OK;
                }
                else MessageBox.Show("Ingresa un precio Valido por favor");
            }
            else MessageBox.Show("Completa todos los campos por favor");
        }
    }
}
