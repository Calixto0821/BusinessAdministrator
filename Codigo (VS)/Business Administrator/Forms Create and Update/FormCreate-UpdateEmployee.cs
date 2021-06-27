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
    public partial class FormCreate_UpdateEmployee : Form
    {
        
        ownFunctions Functions = new ownFunctions();
        ConnectionDB connection = new ConnectionDB();
        public bool insertMood = false;
        public bool updateMood = false;
        public bool administratorMood = false;
        public int user_type = 3;

        public FormCreate_UpdateEmployee()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        #region ValidateData
        Validate validate = new Validate();
        private void validateNumbers_KeyPress(object sender, KeyPressEventArgs Num) => validate.onlyNumbers(Num);
        private void validateChars_KeyPress(object sender, KeyPressEventArgs chars) => validate.onlyChars(chars);
        #endregion

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox[] fieldsForm= {textBoxFirstName,textBoxLastName,textBoxDocument,textBoxCellphone, textBoxEmail,textBoxUser, textBoxPassword};

            if (Functions.checkFields(fieldsForm))
            {
                if (Functions.checkValidEmail(textBoxEmail.Text))
                {
                    Employee EMPLOYEE = new Employee(textBoxFirstName.Text, textBoxLastName.Text, textBoxCellphone.Text, textBoxDocument.Text, textBoxEmail.Text, textBoxUser.Text, textBoxPassword.Text, user_type);
                    if (insertMood)
                    {
                        DialogResult messageQuestionInsertEmployee = MessageBox.Show("Desea registrar un nuevo empleado?", "Registrar Empleado Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionInsertEmployee == DialogResult.Yes) EMPLOYEE.insert();
                    }
                    else if (updateMood)
                    {
                        DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar los datos del empleado?", "Editar Empleado " + textBoxDocument.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionUpdate == DialogResult.Yes) EMPLOYEE.update(textBoxDocument.Text);
                    }
                    else if (administratorMood)
                    {
                        DialogResult messageQuestionInsertAdmin = MessageBox.Show("Desea registrar un Administrador?", "Registrar Administrador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionInsertAdmin == DialogResult.Yes) EMPLOYEE.insert();
                        FormLogin login = new FormLogin();
                        login.Show();
                    }
                    else Console.WriteLine("Both moods are false");
                    Functions.emptyFields(fieldsForm);
                    this.Dispose();
                }
                else MessageBox.Show("Ingresa un correo electronico valido, por favor");
            }
            else MessageBox.Show("POR FAVOR, LLENA TODOS LOS CAMPOS OBLIGATORIOS");
        }

        private void FormCreateEmployee_Load(object sender, EventArgs e)
        {

            if (insertMood)
            {
                buttonInsert_Update.Text = "Crear";
                if (user_type == 1) labelTitle.Text = "CREAR ADMINISTRADOR";
                else if (user_type == 3) labelTitle.Text = "CREAR EMPLEADO";
            }
            else if (updateMood)
            {
                buttonInsert_Update.Text = "Actualizar";
                if (user_type == 1) labelTitle.Text = "ACTUALIZAR ADMINISTRADOR";
                else if (user_type == 3) labelTitle.Text = "ACTUALIZAR EMPLEADO";
            }
            else if(administratorMood)
            {
                buttonInsert_Update.Text = "Crear Administrador";
                labelTitle.Text = "CREAR ADMINISTRADOR";
            }
            else
            {
                labelTitle.Text = "ERROR (user_type)";
                buttonInsert_Update.Enabled = false;
            }
        }
    }
}
