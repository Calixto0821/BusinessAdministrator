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
    public partial class FormCreate_UpdateLine : Form
    {
        public FormCreate_UpdateLine()
        {
            InitializeComponent();
        }

        ownFunctions Functions = new ownFunctions();
        public bool insertMood = false;
        public bool updateMood = false;


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Line LINE = new Line(textBoxName.Text);
            if (Functions.checkLenghtTexBox(textBoxName,2))
            {
                if (insertMood)
                {
                    DialogResult messageQuestionInsert = MessageBox.Show("Desea registrar una nueva Linea?", "Registrar Linea Nueva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (messageQuestionInsert == DialogResult.Yes)
                    {
                        DialogResult dialogResultValidation = new DialogResult();
                        FormUserValidation formUserValidation = new FormUserValidation();
                        dialogResultValidation = formUserValidation.ShowDialog();
                        if (dialogResultValidation == DialogResult.OK) LINE.insert();
                    }

                }
                else if (updateMood)
                {
                    DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar el nombre de la Linea?", "Editar Linea", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (messageQuestionUpdate == DialogResult.Yes)
                    {
                        DialogResult dialogResultValidation = new DialogResult();
                        FormUserValidation formUserValidation = new FormUserValidation();
                        dialogResultValidation = formUserValidation.ShowDialog();
                        if (dialogResultValidation == DialogResult.OK) LINE.update(labelIDLine.Text);
                    }
                }
                else Console.WriteLine("Both moods are false");
                this.DialogResult = DialogResult.OK;
                this.Dispose();

            } else MessageBox.Show("LLENA EL CAMPO CON MINIMO 2 CARACTERES");
        }

        private void FormCreate_UpdateLine_Load(object sender, EventArgs e)
        {
            if (insertMood) buttonInsert_Update.Text = "REGISTRAR";
            else if (updateMood) buttonInsert_Update.Text = "ACTUALIZAR";
            else Console.WriteLine("Error mood Line");
        }
    }
}
