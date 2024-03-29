﻿using Business_Administrator.Forms_Create;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_Administrator.Forms_Tables_and_Queries
{
    public partial class FormTableLinesAndBrands : Form
    {
        public FormTableLinesAndBrands()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        private void dataUploadLine()
        {
            connection.displayData(dataGridViewLines, "EXEC displayDataLines");
        }
        private void dataUploadBrand()
        {
            connection.displayData(dataGridViewBrands, "EXEC displayDataBrands");
        }

        private void FormTableLinesAndBrands_Load(object sender, EventArgs e)
        {
            dataUploadLine();
            dataUploadBrand();
        }

        private void buttonLineEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateLine_Brand FormLine = new FormCreate_UpdateLine_Brand();
            if(dataGridViewLines.SelectedRows.Count == 1)
            {
                try
                {
                    string idLine = dataGridViewLines.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryLine = { "*", "LINES", "id=" + idLine + "AND status=1" };
                    DataTable dataTableLines = connection.querySelect(parametersQueryLine);
                    FormLine.textBoxName.Text = dataTableLines.Rows[0]["name"].ToString().Trim();
                    FormLine.labelID.Text = dataTableLines.Rows[0]["id"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormLine.updateMood = true;
                    FormLine.insertMood = false;
                    FormLine.lines = true;
                    FormLine.brands = false;
                    FormLine.ShowDialog();
                    dataUploadLine();
                }
                catch(Exception Error)
                {
                    Console.WriteLine("Process: Error when completing the assignment => " + Error);
                    MessageBox.Show("Sucedio un error");
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonBrandEdit_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateLine_Brand FormBrand = new FormCreate_UpdateLine_Brand();
            if (dataGridViewLines.SelectedRows.Count == 1)
            {
                try
                {
                    string idBrand = dataGridViewBrands.CurrentRow.Cells["ID"].Value.ToString().Trim();
                    string[] parametersQueryBrand = { "*", "BRANDS", "id=" + idBrand + "AND status=1" };
                    DataTable dataTableBrand = connection.querySelect(parametersQueryBrand);
                    FormBrand.textBoxName.Text = dataTableBrand.Rows[0]["name"].ToString().Trim();
                    FormBrand.labelID.Text = dataTableBrand.Rows[0]["id"].ToString().Trim();
                    Console.WriteLine("Assignment successfully completed");

                    FormBrand.updateMood = true;
                    FormBrand.insertMood = false;
                    FormBrand.brands = true;
                    FormBrand.lines = false;
                    FormBrand.ShowDialog();
                    dataUploadBrand();
                }
                catch (Exception Error)
                {
                    Console.WriteLine("Process: Error when completing the assignment => " + Error);
                    MessageBox.Show("Sucedio un error");
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonLineDelete_Click(object sender, EventArgs e)
        {

            if (dataGridViewLines.SelectedRows.Count == 1)
            {
                string nameLine = dataGridViewLines.CurrentRow.Cells["NAME"].Value.ToString().Trim();
                int idLine= Convert.ToInt32(dataGridViewLines.CurrentRow.Cells["ID"].Value.ToString().Trim());
                DialogResult warningMessage = MessageBox.Show("Linea: " + nameLine+
                    "\n"+nameLine+" ID: " + idLine +
                    "\nDesea eliminar de forma definitiva?", "Eliminar Linea", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK)
                    {
                        Line line = new Line(idLine);
                        line.delete();
                    }
                    dataUploadLine();
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }

        private void buttonBrandDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewLines.SelectedRows.Count == 1)
            {
                string nameBrand = dataGridViewBrands.CurrentRow.Cells["NAME"].Value.ToString().Trim();
                int idBrand = Convert.ToInt32(dataGridViewBrands.CurrentRow.Cells["ID"].Value.ToString().Trim());
                DialogResult warningMessage = MessageBox.Show("Marca: " + nameBrand +
                    "\n" + nameBrand + " ID: " + idBrand +
                    "\nDesea eliminar de forma definitiva?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warningMessage == DialogResult.Yes)
                {
                    DialogResult dialogResultValidation = new DialogResult();
                    FormUserValidation formUserValidation = new FormUserValidation();
                    dialogResultValidation = formUserValidation.ShowDialog();
                    if (dialogResultValidation == DialogResult.OK)
                    {
                        Brand brand = new Brand(idBrand);
                        brand.delete();
                    }
                    dataUploadBrand();
                }
            }
            else MessageBox.Show("Selecciona solamente un registro, por favor");
        }
    }
}
