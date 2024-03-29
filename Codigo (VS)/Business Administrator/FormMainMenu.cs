﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using Business_Administrator.Forms_Create;
using Business_Administrator.Forms_Tables_and_Queries;


namespace Business_Administrator
{
    public partial class FormMainMenu : Form
    {
        ConnectionDB connection = new ConnectionDB();
        public string user_Document = null;
        public string user_Name = null;

        public FormMainMenu()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {

            labelNameEmployee.Text = user_Name;
            labelDocumentEmployee.Text = user_Document;
            try
            {
                connection.openConnectionDB();
                SqlCommand command_Select = new SqlCommand("SELECT user_type FROM USERS WHERE document=@UserDocument", connection.connectionSQL);
                command_Select.Parameters.AddWithValue("UserDocument", user_Document);
                SqlDataAdapter da = new SqlDataAdapter(command_Select);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int user_Type = Convert.ToInt32(dt.Rows[0]["user_type"].ToString());
                if (user_Type == 1) buttonCreateEmployee.Enabled = true;
            }
            catch(SqlException Error)
            {
                Console.WriteLine(Error.ToString());
                MessageBox.Show("ERROR/n"+Error.Message);
            }
            finally
            {
                connection.closeConnectionDB();
            }
            
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void buttonCreateEmployee_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateEmployee createEmployee = new FormCreate_UpdateEmployee();
            createEmployee.insertMood = true;
            createEmployee.updateMood = false;
            createEmployee.buttonInsert_Update.Text = "Agregar";
            createEmployee.Show();
        }

        private void buttonCreateClient_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateClient createClient = new FormCreate_UpdateClient();
            createClient.insertMood = true;
            createClient.updateMood = false;
            createClient.buttonInsert_Update.Text = "Agregar";
            createClient.Show();
        }

        private void buttonCreateDealer_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateDealer createDealer = new FormCreate_UpdateDealer();
            createDealer.insertMood = true;
            createDealer.updateMood = false;
            createDealer.buttonInsert_Update.Text = "Agregar";
            createDealer.Show();
        }

        private void buttonSeeDealers_Click(object sender, EventArgs e)
        {
            FormTableDealers formTableDealers = new FormTableDealers();
            formTableDealers.Show();
        }

        private void buttonCreateLine_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateLine_Brand createLine = new FormCreate_UpdateLine_Brand();
            createLine.insertMood = true;
            createLine.updateMood = false;
            createLine.lines = true;
            createLine.brands = false;
            createLine.Show();
        }

        private void buttonCreateBrand_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateLine_Brand createBrand = new FormCreate_UpdateLine_Brand();
            createBrand.insertMood = true;
            createBrand.updateMood = false;
            createBrand.lines = false;
            createBrand.brands = true;
            createBrand.Show();
        }

        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateProduct createProduct = new FormCreate_UpdateProduct();
            createProduct.insertMood = true;
            createProduct.updateMood = false;
            createProduct.buttonInsert_Update.Text = "Agregar";
            createProduct.Show();
        }

        private void buttonSeeProducts_Click(object sender, EventArgs e)
        {
            FormTableProducts formTableProducts = new FormTableProducts();
            formTableProducts.Show();
        }

        private void buttonCreateService_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateService createService = new FormCreate_UpdateService();
            createService.insertMood = true;
            createService.updateMood = false;
            createService.Show();
        }

        private void buttonSeeEmployees_Click(object sender, EventArgs e)
        {
            FormTableEmployees formTableEmployees = new FormTableEmployees();
            formTableEmployees.Show();
        }

        private void buttonSeeLinesAndBrands_Click(object sender, EventArgs e)
        {
            FormTableLinesAndBrands formTableLinesAndBrands = new FormTableLinesAndBrands();
            formTableLinesAndBrands.Show();
        }

        private void buttonSeeClients_Click(object sender, EventArgs e)
        {
            FormTableClients formTableClients = new FormTableClients();
            formTableClients.Show();
        }

        

        

        private void buttonSeeServices_Click(object sender, EventArgs e)
        {
            FormTableServices formTableServices = new FormTableServices();
            formTableServices.Show();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
