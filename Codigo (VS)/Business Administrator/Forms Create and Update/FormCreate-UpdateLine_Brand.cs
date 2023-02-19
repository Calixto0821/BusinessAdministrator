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
    public partial class FormCreate_UpdateLine_Brand : Form
    {
        public FormCreate_UpdateLine_Brand()
        {
            InitializeComponent();
        }

        ownFunctions Functions = new ownFunctions();
        ConnectionDB connection = new ConnectionDB();
        public bool insertMood = false;
        public bool updateMood = false;
        public bool lines = false;
        public bool brands = false;

        private void insertMoodActions()
        {
            buttonInsert_Update.Text = "REGISTRAR";
            DataTable query = new DataTable();
            if (lines)
            {
                query = connection.execProcedure("searchLastIDLines");
                labelID.Text = (Convert.ToInt32(query.Rows[0]["LAST"].ToString().Trim()) + 1).ToString();
            }
            else if (brands)
            {
                query = connection.execProcedure("searchLastIDBrands");
                labelID.Text = (Convert.ToInt32(query.Rows[0]["LAST"].ToString().Trim()) + 1).ToString();
            }
            else MessageBox.Show("Error slecting Tables (InsertAcctions)");
        }

        private void FormCreate_UpdateLine_Load(object sender, EventArgs e)
        {
            if (insertMood) insertMoodActions();
            else if (updateMood) buttonInsert_Update.Text = "ACTUALIZAR";
            else Console.WriteLine("Error mood Line/Brand");

            if(lines) titleLabel.Text = "LINEA";
            else if(brands)titleLabel.Text = "MARCA";
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (lines)
            {
                Line LINE = new Line(textBoxName.Text);
                if (Functions.checkLenghtTexBox(textBoxName, 2))
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
                            if (dialogResultValidation == DialogResult.OK) LINE.update(labelID.Text);
                        }
                    }
                    else Console.WriteLine("Both moods are false");
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();

                }
                else MessageBox.Show("LLENA EL CAMPO CON MINIMO 2 CARACTERES");
            }
            else if (brands)
            {
                Brand BRAND = new Brand(textBoxName.Text);
                if (Functions.checkLenghtTexBox(textBoxName, 2))
                {
                    if (insertMood)
                    {
                        DialogResult messageQuestionInsert = MessageBox.Show("Desea registrar una nueva Marca?", "Registrar Marca Nueva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionInsert == DialogResult.Yes)
                        {
                            DialogResult dialogResultValidation = new DialogResult();
                            FormUserValidation formUserValidation = new FormUserValidation();
                            dialogResultValidation = formUserValidation.ShowDialog();
                            if (dialogResultValidation == DialogResult.OK) BRAND.insert();
                        }

                    }
                    else if (updateMood)
                    {
                        DialogResult messageQuestionUpdate = MessageBox.Show("Desea actualizar el nombre de la Marca?", "Editar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageQuestionUpdate == DialogResult.Yes)
                        {
                            DialogResult dialogResultValidation = new DialogResult();
                            FormUserValidation formUserValidation = new FormUserValidation();
                            dialogResultValidation = formUserValidation.ShowDialog();
                            if (dialogResultValidation == DialogResult.OK) BRAND.update(labelID.Text);
                        }
                    }
                    else Console.WriteLine("Both moods are false");
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();

                }
                else MessageBox.Show("LLENA EL CAMPO CON MINIMO 2 CARACTERES");
            }
            else { MessageBox.Show("Error selecting table","No table selected",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
    }
}
