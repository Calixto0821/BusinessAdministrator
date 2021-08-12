using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Administrator
{
    public partial class FormCreate_UpdateDealer : Form
    {
        ownFunctions Functions = new ownFunctions();
        
        public FormCreate_UpdateDealer()
        {
            InitializeComponent();
        }

        #region validateData
        Validate validate = new Validate();
        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);
        #endregion

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox[] fieldsForm = {textBoxName,textBoxCellphone,textBoxPhone,textBoxAddress,textBoxWeb,textBoxEmail };
            if (Functions.checkFields(fieldsForm))
            {
                if (Functions.checkLenghtTexBox(textBoxName,2))
                {
                        if (Functions.checkValidEmail(textBoxEmail.Text)||textBoxEmail.Text == "NO TIENE")
                        {
                            Dealer DEALER = new Dealer(textBoxName.Text,textBoxCellphone.Text,textBoxPhone.Text,textBoxAddress.Text,textBoxWeb.Text,textBoxEmail.Text);
                            DEALER.insert();
                            this.Hide();
                        } else MessageBox.Show("Ingresa un correo electronico valido, por favor");
                } else MessageBox.Show("El campo Nombre debe tener 2 caracteres minimo");
            } else MessageBox.Show("POR FAVOR, LLENA TODOS LOS CAMPOS OBLIGATORIOS");
        }
    }
}
