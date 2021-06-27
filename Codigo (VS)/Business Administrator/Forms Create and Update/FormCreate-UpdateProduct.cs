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
        Validate validate = new Validate();

        private void FormCreateProduct_Load(object sender, EventArgs e)
        {
            connection.fillComboBox(comboBoxDealer,"DEALERS","name");
            connection.fillComboBox(comboBoxBrand,"BRANDS","name");
            connection.fillComboBox(comboBoxLine,"LINES","name");
        }

        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { textBoxReference, textBoxName, textBoxBarcode, textBoxPrice, textBoxStock, textBoxMinimumStock };
            ComboBox[] comboBoxes = {comboBoxDealer,comboBoxBrand,comboBoxLine };
            if (Functions.checkFields(textBoxes) && Functions.checkCombos(comboBoxes))
            {
                if (0 != Convert.ToDouble(textBoxPrice.Text))
                {                 
                    int id_dealer = connection.searchId("dealers", "name", comboBoxDealer.Text);
                    int id_brand = connection.searchId("brands", "name", comboBoxBrand.Text); ;
                    int id_line = connection.searchId("lines", "name", comboBoxLine.Text);
                    Product product = new Product(textBoxReference.Text, textBoxName.Text, textBoxBarcode.Text, double.Parse(textBoxPrice.Text),
                        id_dealer, id_brand, id_line,
                        int.Parse(textBoxStock.Text), int.Parse(textBoxMinimumStock.Text), textBoxDescription.Text);
                    product.insert();
                } else MessageBox.Show("Ingresa un precio Valido por favor");     
            }else MessageBox.Show("Completa todos los campos por favor");          
        }
    }
}
