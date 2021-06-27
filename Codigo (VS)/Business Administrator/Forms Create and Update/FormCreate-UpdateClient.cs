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

namespace Business_Administrator
{
    public partial class FormCreate_UpdateClient : Form
    {       
        
        ownFunctions Functions = new ownFunctions();
        ConnectionDB connection = new ConnectionDB();
        public bool insertMood = false;
        public bool updateMood = false;

        public FormCreate_UpdateClient()
        {
            InitializeComponent();
            connection.tryConnection(this);
            
        }

        #region ValidateData
        Validate validate = new Validate();
        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);
        private void validateChars_KeyPress(object sender, KeyPressEventArgs chars) => validate.onlyChars(chars);
        #endregion

        private void FormCreateClient_Load(object sender, EventArgs e)
        {
            if (insertMood) labelTitle.Text = "REGISTRAR USUARIO";
            else if (updateMood) labelTitle.Text = "ACTUALIZAR USUARIO";
            else Console.WriteLine("Error mood Form");
            textBoxDebt.Text = "0";
            textBoxBalance.Text = "0";
        }

        private void buttonInsert_Update_Click(object sender, EventArgs e)
        {
            TextBox[] fieldsForm = { textBoxFirstName, textBoxLastName, textBoxDocument, textBoxCellphone, textBoxEmail, textBoxBalance, textBoxDebt };

            if (Functions.checkFields(fieldsForm))
            {
                if (Functions.checkValidEmail(textBoxEmail.Text))
                {
                    Clients CLIENT = new Clients(textBoxFirstName.Text, textBoxLastName.Text, textBoxCellphone.Text, textBoxDocument.Text, textBoxEmail.Text, Convert.ToDouble(textBoxBalance.Text), Convert.ToDouble(textBoxDebt.Text));
                    if (insertMood)
                    {
                        DialogResult messageQuestionInsert = MessageBox.Show("Desea registrar un nuevo usuario?", "Registrar Usuario Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionInsert == DialogResult.Yes) CLIENT.insert();
                    }
                    else if (updateMood)
                    {
                        DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar los datos del usuario?", "Editar Usuario " + textBoxDocument.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionUpdate == DialogResult.Yes) CLIENT.update(textBoxDocument.Text);
                    }else Console.WriteLine("Both moods are false");
                    Functions.emptyFields(fieldsForm);
                    this.Dispose();
                }else MessageBox.Show("Ingresa un correo electronico valido, por favor");
            } else MessageBox.Show("POR FAVOR, LLENA TODOS LOS CAMPOS OBLIGATORIOS");
        }
    }
}
