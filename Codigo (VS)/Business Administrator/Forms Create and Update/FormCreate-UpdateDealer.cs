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
        ConnectionDB connection = new ConnectionDB();
        public bool insertMood = false;
        public bool updateMood = false;
        public string dealerID;

        public FormCreate_UpdateDealer()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        #region validateData
        Validate validate = new Validate();
        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);
        #endregion

        private void FormCreate_UpdateDealer_Load(object sender, EventArgs e)
        {
            if (insertMood) labelTitle.Text = "REGRISTRAR PROVEEDOR";
            else if (updateMood) labelTitle.Text = "ACTUALIZAR PROVEEDOR";
            else Console.WriteLine("Error mood Dealer");
        }
        private void buttonInsert_Update_Click(object sender, EventArgs e)
        {
            TextBox[] fieldsForm = { textBoxName, textBoxCellphone, textBoxPhone, textBoxAddress, textBoxWeb, textBoxEmail };
            if (Functions.checkFields(fieldsForm))
            {
                if (Functions.checkLenghtTexBox(textBoxName, 2))
                {
                    if (Functions.checkValidEmail(textBoxEmail.Text) || textBoxEmail.Text == "NO TIENE")
                    {
                        Dealer DEALER = new Dealer(textBoxName.Text, textBoxCellphone.Text, textBoxPhone.Text, textBoxAddress.Text, textBoxWeb.Text, textBoxEmail.Text);
                        if (insertMood)
                        {
                            DialogResult messageQuestionInsert = MessageBox.Show("Desea registrar un nuevo proveedor?", "Registrar Proveedor Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (messageQuestionInsert == DialogResult.Yes)
                            {
                                DialogResult dialogResultValidation = new DialogResult();
                                FormUserValidation formUserValidation = new FormUserValidation();
                                dialogResultValidation = formUserValidation.ShowDialog();
                                if (dialogResultValidation == DialogResult.OK) DEALER.insert();
                            }
                        }
                        else if (updateMood)
                        {
                            DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar los datos del proveedor?", "Editar Proveedor " + dealerID , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (messageQuestionUpdate == DialogResult.Yes)
                            {
                                DialogResult dialogResultValidation = new DialogResult();
                                FormUserValidation formUserValidation = new FormUserValidation();
                                dialogResultValidation = formUserValidation.ShowDialog();
                                if (dialogResultValidation == DialogResult.OK) DEALER.update(dealerID);
                            }
                            
                        }
                        else Console.WriteLine("Both moods are false");

                        Functions.emptyFields(fieldsForm);
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                    }
                    else MessageBox.Show("Ingresa un correo electronico valido, por favor");
                }
                else MessageBox.Show("El campo Nombre debe tener 2 caracteres minimo");
            }
            else MessageBox.Show("POR FAVOR, LLENA TODOS LOS CAMPOS OBLIGATORIOS");
        }

    }
}

