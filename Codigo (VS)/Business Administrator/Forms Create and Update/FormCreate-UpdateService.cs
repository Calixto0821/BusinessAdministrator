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
    public partial class FormCreate_UpdateService : Form
    {
        public FormCreate_UpdateService()
        {
            InitializeComponent();
        }

        ownFunctions Functions = new ownFunctions();
        Validate validate = new Validate();

        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { textBoxReference, textBoxName, textBoxBarcode, textBoxPrice};
            if (Functions.checkFields(textBoxes))
            {
                if (0 != Convert.ToDouble(textBoxPrice.Text))
                {
                    Service service;
                    if (textBoxDescription.Text == "")
                    {
                        service = new Service(textBoxReference.Text,textBoxName.Text,textBoxBarcode.Text,Convert.ToDouble(textBoxPrice.Text));
                    }
                    else
                    {
                        service = new Service(textBoxReference.Text, textBoxName.Text, textBoxBarcode.Text, Convert.ToDouble(textBoxPrice.Text),textBoxDescription.Text);
                    }     
                    service.insert();
                }
                else MessageBox.Show("Ingresa un precio Valido por favor");
            }
            else MessageBox.Show("Completa todos los campos por favor");
        }
    }
}
