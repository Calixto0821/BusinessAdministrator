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
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();
        ownFunctions Functions = new ownFunctions();
        public bool insertMood = false;
        public bool updateMood = false;
        public string serviceID;

        #region validateData
        Validate validate = new Validate();
        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);
        #endregion

        private void FormCreate_UpdateService_Load(object sender, EventArgs e)
        {
            if (insertMood) buttonInsert_Update.Text = "REGRISTRAR";
            else if (updateMood) buttonInsert_Update.Text = "ACTUALIZAR";
            else Console.WriteLine("Error mood Service");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox[] fieldsForm = { textBoxReference, textBoxName, textBoxBarcode, textBoxPrice};
            if (Functions.checkFields(fieldsForm))
            {
                if (0 != Convert.ToDouble(textBoxPrice.Text))
                {
                    Service SERVICE;
                    if (textBoxDescription.Text == "")
                    {
                        SERVICE = new Service(textBoxReference.Text,textBoxName.Text,textBoxBarcode.Text,Convert.ToDouble(textBoxPrice.Text));
                    }
                    else
                    {
                        SERVICE = new Service(textBoxReference.Text, textBoxName.Text, textBoxBarcode.Text, Convert.ToDouble(textBoxPrice.Text),textBoxDescription.Text);
                    }

                    if (insertMood)
                    {
                        DialogResult messageQuestionInsert = MessageBox.Show("Desea registrar un nuevo servicio?", "Registrar Servicio Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionInsert == DialogResult.Yes)
                        {
                            DialogResult dialogResultValidation = new DialogResult();
                            FormUserValidation formUserValidation = new FormUserValidation();
                            dialogResultValidation = formUserValidation.ShowDialog();
                            if (dialogResultValidation == DialogResult.OK) SERVICE.insert();
                        }
                    }
                    else if (updateMood)
                    {
                        DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar los datos del servicio?", "Editar Servicio" + serviceID, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionUpdate == DialogResult.Yes)
                        {
                            DialogResult dialogResultValidation = new DialogResult();
                            FormUserValidation formUserValidation = new FormUserValidation();
                            dialogResultValidation = formUserValidation.ShowDialog();
                            if (dialogResultValidation == DialogResult.OK) SERVICE.update(serviceID);
                        }
                    }
                    else Console.WriteLine("Both moods are false");

                    Functions.emptyFields(fieldsForm);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else MessageBox.Show("Ingresa un precio Valido por favor");
            }
            else MessageBox.Show("Completa todos los campos por favor");
        }

        
    }
}
