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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            connection.tryConnection(this);
        }

        ConnectionDB connection = new ConnectionDB();

        private void FormLogin_Load(object sender, EventArgs e)
        {    
            try
            {
                connection.openConnectionDB();
                SqlCommand command_Select = new SqlCommand("EXEC checkAdministratorUser", connection.connectionSQL);
                SqlDataAdapter da = new SqlDataAdapter(command_Select);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    buttonCreateAdministrator.Visible = true;
                    buttonLogin.Enabled = false;
                    textBoxUser.Enabled = false;
                    textBoxPassword.Enabled = false;
                    this.AcceptButton = buttonCreateAdministrator;
                }
                else
                {
                    buttonLogin.Enabled = true;
                    textBoxUser.Enabled = true;
                    textBoxPassword.Enabled = true;
                    //Fill fields automatically (Temporary to do tests)
                    textBoxUser.Text = "Admin";
                    textBoxPassword.Text = "administrator";
                }
                    
            }
            catch (SqlException Error)
            {
                Console.WriteLine(Error.ToString());
                MessageBox.Show("ERROR/n" + Error.Message);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

        public void Loger(string user, string password)
        {
            try
            {
                connection.openConnectionDB();

                SqlCommand command_Select = new SqlCommand ("EXEC User_Login @User  = '"+user+"', @Password = '"+password+"';",connection.connectionSQL);
                SqlDataAdapter da = new SqlDataAdapter(command_Select);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Console.WriteLine("NEW LOGIN =>"+
                        " User: "+dt.Rows[0]["Full name"].ToString().Trim() +
                        "| Document: "+dt.Rows[0]["document"].ToString().Trim()+
                        "| Nickname: "+dt.Rows[0]["nickname"].ToString().Trim() +
                        "| Password: "+dt.Rows[0]["password"].ToString().Trim());

                    FormMainMenu next_Form = new FormMainMenu();
                    next_Form.user_Document = dt.Rows[0]["document"].ToString().Trim();
                    next_Form.user_Name = dt.Rows[0]["Full name"].ToString().Trim();
                    next_Form.Show();
                    this.Hide();
                    Globals.documentCurrentUser = dt.Rows[0]["document"].ToString().Trim();
                    Console.WriteLine(Globals.documentCurrentUser + " have acceded to the system");
                }
                else
                {
                    Console.WriteLine("FAILED LOGIN => There are no rows");
                    MessageBox.Show("Usuario y/o Contraseña incorrecta");
                    //CajaInicial.intpass = CajaInicial.intpass + 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Loger(textBoxUser.Text,textBoxPassword.Text);
        }

        private void buttonCreateAdministrator_Click(object sender, EventArgs e)
        {
            FormCreate_UpdateEmployee create_Admin = new FormCreate_UpdateEmployee();
            create_Admin.user_type = 1;
            create_Admin.administratorMood = true;
            create_Admin.Activate();
            create_Admin.Show();
            this.Close();
        }

        private void buttonCloseApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
