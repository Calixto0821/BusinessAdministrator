using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows;

namespace Business_Administrator
{
    public class ConnectionDB
    {
        public SqlConnection connectionSQL = new SqlConnection("Data Source=PC-JUAN\\SQLEXPRESS;Initial Catalog=BUSINESS_ADMINISTRATOR;Integrated Security=True");

        /// <summary>
        /// Open SQL database connection
        /// </summary>
        public void openConnectionDB()
        {
            try{connectionSQL.Open();}
            catch (SqlException Error){Console.WriteLine("Error! Could not open connection with the database\n"+Error.Message);}            
        }

        /// <summary>
        /// Close SQL database connection
        /// </summary>
        public void closeConnectionDB()
        {
            try{connectionSQL.Close();}
            catch (SqlException Error){Console.WriteLine("Error! Could not close connection with the database\n" + Error.Message);}
        }


        /// <summary>
        /// Check if the connection is stable
        /// </summary>
        /// <param name="form"></param>
        public void tryConnection(Form form)
        {
            try
            {
                openConnectionDB();
                Console.WriteLine("CONNECTION SUCCESSFUL " + "Form(" + form.Name + ")");
                closeConnectionDB();
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR\nAn error was ocurred while the system was trying connect with the database");
                Console.WriteLine("ERROR\nAn error was ocurred while the system was trying connect with the database" + Convert.ToString(Error));
            }

        }


        /// <summary>
        /// Fill out a ComboBox with colum values and order specific
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="order"></param>
        public void fillComboBox(ComboBox comboBox, string table, string column, string order = "id")
        {
            try
            {
                connectionSQL.Open();
                SqlCommand commandQuery = new SqlCommand("SELECT * FROM "+table+" ORDER BY "+order, connectionSQL);
                SqlDataReader sqlDR = commandQuery.ExecuteReader();

                while (sqlDR.Read())
                {
                    comboBox.Items.Add(sqlDR[column].ToString());
                }
                sqlDR.Close();
                Console.WriteLine(comboBox.Name + " fill successfully with " + comboBox.Items.Count + " items");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            finally
            {
                connectionSQL.Close();
            }
        }

        /// <summary>
        /// Fill out a ComboBox with colum values and order specific, according a parameter
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="order"></param>
        public void fillComboBoxAccordingToParameter(ComboBox comboBox, string table, string column, string parameterColumn, string parameter, string order = "id")
        {
            int indexComboBox = 0;
            try
            {
                connectionSQL.Open();
                SqlCommand commandQuery = new SqlCommand("SELECT * FROM " + table + " ORDER BY " + order, connectionSQL);
                commandQuery.Parameters.AddWithValue("Parameter", parameter);
                SqlDataReader sqlDR = commandQuery.ExecuteReader();

                while (sqlDR.Read())
                {
                    if (sqlDR[parameterColumn].ToString() == parameter) indexComboBox = comboBox.Items.Count;
                    comboBox.Items.Add(sqlDR[column].ToString());
                }
                sqlDR.Close();
                Console.WriteLine(comboBox.Name+" fill successfully with "+comboBox.Items.Count+" items");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            finally
            {
                comboBox.SelectedIndex = indexComboBox;
                connectionSQL.Close();
            }
        }



        /// <summary>
        /// Search one ID according the parameters
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns><term>int</term>ID</returns>
        public int searchId(string table, string column, string value)
        {
            int ID = 0;
            table = table.ToUpper();
            try
            {
                Console.WriteLine("Starting process to find ID in the " + table + " table");
                string query = "SELECT [id] FROM " + table + " WHERE ["+column+"] = @Value";
                SqlCommand commandQuery = new SqlCommand(query,connectionSQL);
                commandQuery.Parameters.AddWithValue("Value", value);
                openConnectionDB();
                SqlDataAdapter da = new SqlDataAdapter(commandQuery);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    ID = Convert.ToInt32(dt.Rows[0]["id"]);
                    Console.WriteLine(table + " ID found and assigned");
                    return ID;
                }
                else
                {
                    Console.WriteLine("ERROR\ncouldn't find the " + table + " ID");
                    return 0;
                }
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                MessageBox.Show("ERROR/n" + Error.Message);
                return 0;
            }
            finally
            {
                closeConnectionDB();
            }

        }

        /// <summary>
        /// Performs a query with the parameter that is given, to know if the document corresponds with a Adminnistrator user
        /// </summary>
        /// <param name="documentUser"></param>
        /// <returns><term>bool</term> Confirmation if the user is admin</returns>
        public bool checkAdmin(string documentUser)
        {
            try
            {
                openConnectionDB();
                string command = "SELECT user_type FROM USERS WHERE document = @Document";
                SqlCommand select = new SqlCommand(command, connectionSQL);
                select.Parameters.AddWithValue("Document",documentUser);
                SqlDataAdapter query = new SqlDataAdapter(select);
                DataTable dataTable = new DataTable();
                query.Fill(dataTable);
                int user_type = Convert.ToInt32(dataTable.Rows[0][0]);
                if (user_type == 1)
                {
                    Console.WriteLine("The user is Administrator");
                    return true;
                }
                else
                {
                    Console.WriteLine("The user isn't Administrator");
                    return false;
                }
            }
            catch(SqlException Error)
            {
                Console.Write("Error in method checkAdmin => "+Error);
                return false;
            }
            finally
            {
                closeConnectionDB();
            }
        }


        public DialogResult ValidateUser(string password)
        {
            try
            {
                openConnectionDB();

                SqlCommand command_Select = new SqlCommand("EXEC User_Login @User  = '" + Globals.documentCurrentUser + "', @Password = '" + password + "';",connectionSQL);
                SqlDataAdapter da = new SqlDataAdapter(command_Select);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Console.WriteLine("USER VALIDATED =>" +
                        " User: " + dt.Rows[0]["Full name"].ToString().Trim() +
                        "| Document: " + dt.Rows[0]["document"].ToString().Trim() +
                        "| Nickname: " + dt.Rows[0]["nickname"].ToString().Trim() +
                        "| Password: " + dt.Rows[0]["password"].ToString().Trim());
                    return DialogResult.OK;
                }
                else
                {
                    Console.WriteLine("FAILED VALIDATION => The password was wrong");
                    MessageBox.Show( "Contraseña incorrecta","Error en validacion", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return DialogResult.None;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return DialogResult.None;
            }
            finally
            {
                closeConnectionDB();
            }
        }


        /// <summary>
        /// Fill out a dataGridView with the query that is given like a parameter
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="commandSelect"></param>
        public void displayData(DataGridView dataGridView, string commandSelect)
        {
            try
            {
                openConnectionDB();
                SqlDataAdapter command = new SqlDataAdapter(commandSelect, connectionSQL);
                DataTable dataTable = new DataTable();
                command.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la DataGrid");
                Console.WriteLine("No se pudo llenar el Datagridview: \n ERROR: \n" + ex.ToString());
            }
            finally
            {
                closeConnectionDB();
            }
        }




        /// <summary>
        ///<para>This method performs a query and return the DataTable</para>
        ///<para>Recives as parameter string[]</para>
        /// <list type="table">
        /// <item><term>string[0]</term>
        /// <description>Query values</description></item>
        /// <item><term>string[1]</term>
        /// <description>Table</description></item>
        /// <item><term>string[2]</term>
        /// <description>judgment WHERE</description></item>
        /// </list>
        /// </summary>
        /// <param name="parametersQuery"></param>
        /// <returns></returns>
        public DataTable querySelect(string[] parametersQuery)
        {
            string commandSelect = "SELECT 'No Query'";
            //Parameters Query {values to search, table, where}
            if (parametersQuery[2]== null)
            {
             commandSelect = "SELECT " + parametersQuery[0] + " FROM " + parametersQuery[1];
            }
            else
            {
             commandSelect = "SELECT " + parametersQuery[0] + " FROM " + parametersQuery[1] + " WHERE " + parametersQuery[2];

            }
            try
            {
                openConnectionDB();
                SqlDataAdapter command = new SqlDataAdapter(commandSelect, connectionSQL);
                DataTable dataTable = new DataTable();
                command.Fill(dataTable);
                Console.WriteLine("Method querySelect execute successfully");
                return dataTable;
            }
            catch(SqlException ErrorSQL)
            {
                
                MessageBox.Show("Error en el metodo querySelect");
                Console.Write("Method querySelect no execute successfully => Error: " + ErrorSQL);
                return null;
            }
            finally
            {
                closeConnectionDB();
            }
            
        }

        /// <summary>
        ///<para>This method return as a DataTable the procedure data</para>
        ///<para>Recives as parameter a string</para>
        /// </summary>
        /// <param name="nameProcedure"></param>
        /// <returns></returns>
        public DataTable execProcedure(string nameProcedure)
        {
            try
            {
                openConnectionDB();
                SqlDataAdapter command = new SqlDataAdapter("EXEC "+nameProcedure, connectionSQL);
                DataTable dataTable = new DataTable();
                command.Fill(dataTable);
                Console.WriteLine("Method querySelect execute successfully");
                return dataTable;
            }
            catch (SqlException ErrorSQL)
            {

                MessageBox.Show("Error en el metodo querySelect");
                Console.Write("Method querySelect no execute successfully => Error: " + ErrorSQL);
                return null;
            }
            finally
            {
                closeConnectionDB();
            }
        }

    }

    public class Sesion
    {
        int id_employee;
        //string date_login, date_logout;
        //double initial_cashregiste, final_cashregister;
        //int pass_tries;

        public Sesion(int id_employee)
        {
            this.id_employee = id_employee;
        }

        public void registerLogin(string date_login, double initial_cashregister)
        {
            //INSERT
        }
        public void registrLogout(string date_logout, double final_cashregister)
        {
            //UPDATE
        }
    }

    public class Clients
    {
        string first_name, last_name, cellphone_number, document, email;
        double balance, debt;
        int user_type;

        public Clients(string document)
        {
            this.document = document;
        }

        public Clients(string first_name, string last_name, string cellphone_number, string document, string email, double balance, double debt )
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.cellphone_number = cellphone_number;
            this.document = document;
            this.email = email;
            this.balance = balance;
            this.debt = debt;
            this.user_type = 2;
        }



        ConnectionDB connection = new ConnectionDB();

        public void insert()
        {
            try
            {
                connection.openConnectionDB();
                string commandInsertUser = "INSERT INTO USERS([first_name],[last_name],[cellphone_number],[document],[email],[user_type])" +
                "VALUES (@FirstName,@LastName,@Cellphone,@Document,@Email,@UserType)";
                SqlCommand commandUser = new SqlCommand(commandInsertUser, connection.connectionSQL);
                commandUser.Parameters.AddWithValue("FirstName", first_name);
                commandUser.Parameters.AddWithValue("LastName", last_name);
                commandUser.Parameters.AddWithValue("Cellphone", cellphone_number);
                commandUser.Parameters.AddWithValue("Document", document);
                commandUser.Parameters.AddWithValue("Email", email);
                commandUser.Parameters.AddWithValue("UserType", user_type);
                commandUser.ExecuteNonQuery();
                MessageBox.Show("Row added successful (USER)");
                Console.WriteLine("Row added successful (USER)");
                string commandInsertClient = "INSERT INTO CLIENTS([document_user],[balance],[debt])" +
                "VALUES (@Document,@Balance,@Debt)";
                SqlCommand commandClient = new SqlCommand(commandInsertClient, connection.connectionSQL);
                commandClient.Parameters.AddWithValue("Document",document);
                commandClient.Parameters.AddWithValue("Balance",balance);
                commandClient.Parameters.AddWithValue("Debt",debt);
                commandClient.ExecuteNonQuery();
                MessageBox.Show("Row added successful (CLIENT)");
                Console.WriteLine("Row added successful (CLIENT)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row from USERS and CLIENTS\n" + Error);                
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

        public void update(string documentUserToUpdate)
        {
            try
            {
                connection.openConnectionDB();

                string commandUpdateUser = "UPDATE USERS " +
                    "SET [first_name]=@FirstName,[last_name]=@LastName,[cellphone_number]=@Cellphone,[email]=@Email " +
                    "WHERE document= @Document";
                SqlCommand commandUser = new SqlCommand(commandUpdateUser,connection.connectionSQL);
                commandUser.Parameters.AddWithValue("FirstName", first_name);
                commandUser.Parameters.AddWithValue("LastName", last_name);
                commandUser.Parameters.AddWithValue("Cellphone", cellphone_number);
                commandUser.Parameters.AddWithValue("Email", email);
                commandUser.Parameters.AddWithValue("Document", documentUserToUpdate);
                commandUser.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (USER)");
                Console.WriteLine("Row updated successful (USER)");

                string comandUpdateClient = "UPDATE CLIENTS " +
                    "SET [balance]=@Balance,[debt]=@Debt " +
                    "WHERE document_user =@DocumentUser";
                SqlCommand commandClient = new SqlCommand(comandUpdateClient,connection.connectionSQL);      
                commandClient.Parameters.AddWithValue("Balance", balance);
                commandClient.Parameters.AddWithValue("Debt", debt);
                commandClient.Parameters.AddWithValue("DocumentUser", documentUserToUpdate);
                commandClient.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (CLIENT)");
                Console.WriteLine("Row updated successful (CLIENT)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying update a row from USERS and CLIENTS\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }           
        }

        public void delete()
        {
            try
            {
                connection.openConnectionDB();
                string commandDeleteUser = "EXEC deleteClient @Document = '" + document + "'";
                SqlCommand command = new SqlCommand(commandDeleteUser,connection.connectionSQL);
                command.ExecuteNonQuery();
                MessageBox.Show("Cliente " + this.document + " eliminado");
                Console.WriteLine("Client deleted successfully");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying delete client ("+document+")\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }           
        }
    }

    public class Employee
    {

        string first_name, last_name, cellphone_number, document, email, nickname, password;
        int user_type;

        public Employee(string document)
        {
            this.document = document;
        }

        public Employee(string first_name, string last_name, string cellphone_number, string document, string email, string nickname, string password, int user_type)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.cellphone_number = cellphone_number;
            this.document = document;
            this.email = email;
            this.nickname = nickname;
            this.password = password;
            this.user_type = user_type;
        }

        ConnectionDB connection = new ConnectionDB();

        public void insert()
        {
            try
            {
                connection.openConnectionDB();
                string commandInsertUser = "INSERT INTO USERS([first_name],[last_name],[cellphone_number],[document],[email],[user_type])" +
                "VALUES (@FirstName,@LastName,@Cellphone,@Document,@Email,@UserType)";
                SqlCommand command1 = new SqlCommand(commandInsertUser, connection.connectionSQL);
                command1.Parameters.AddWithValue("FirstName",first_name);
                command1.Parameters.AddWithValue("LastName",last_name);
                command1.Parameters.AddWithValue("Cellphone",cellphone_number);
                command1.Parameters.AddWithValue("Document",document);
                command1.Parameters.AddWithValue("Email",email);
                command1.Parameters.AddWithValue("UserType",user_type);
                command1.ExecuteNonQuery();
                Console.WriteLine("Row added successful (USER)");
                MessageBox.Show("Row added successful (USER)");
                string commandInsertEmployee = "INSERT INTO EMPLOYEES([document_user],[nickname],[password])" +
                "VALUES (@Document,@Nickname,@Password)";
                SqlCommand command2 = new SqlCommand(commandInsertEmployee, connection.connectionSQL);
                command2.Parameters.AddWithValue("Document",document);
                command2.Parameters.AddWithValue("Nickname",nickname);
                command2.Parameters.AddWithValue("Password",password);
                command2.ExecuteNonQuery();
                Console.WriteLine("Row added successful (EMPLOYEE)");
                MessageBox.Show("Row added successful (EMPLOYEE)");                
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row\n" + Error);       
            }
            finally
            {
                connection.closeConnectionDB();
            }

        }

        public void update(string documentUserToUpdate)
        {
            try
            {
                connection.openConnectionDB();

                string commandUpdateUser = "UPDATE USERS " +
                    "SET [first_name]=@FirstName,[last_name]=@LastName,[cellphone_number]=@Cellphone,[email]=@Email " +
                    "WHERE document= @Document";
                SqlCommand commandUser = new SqlCommand(commandUpdateUser, connection.connectionSQL);
                commandUser.Parameters.AddWithValue("FirstName", first_name);
                commandUser.Parameters.AddWithValue("LastName", last_name);
                commandUser.Parameters.AddWithValue("Cellphone", cellphone_number);
                commandUser.Parameters.AddWithValue("Email", email);
                commandUser.Parameters.AddWithValue("Document", documentUserToUpdate);
                commandUser.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (USER)");
                Console.WriteLine("Row updated successful (USER)");

                string comandUpdateClient = "UPDATE EMPLOYEES " +
                    "SET [nickname]=@Nickname, [password]=@Password " +
                    "WHERE document_user =@DocumentUser";
                SqlCommand commandClient = new SqlCommand(comandUpdateClient, connection.connectionSQL);
                commandClient.Parameters.AddWithValue("Nickname", nickname);
                commandClient.Parameters.AddWithValue("Password", password);
                commandClient.Parameters.AddWithValue("DocumentUser", documentUserToUpdate);
                commandClient.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (EMPLOYEE)");
                Console.WriteLine("Row updated successful (EMPLOYEE)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying update a row from USERS and EMPLOYEES\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

        public void delete()
        {
            try
            {
                connection.openConnectionDB();
                string commandDeleteUser = "EXEC deleteEmployee @Document = '"+document+"'";
                SqlCommand command = new SqlCommand(commandDeleteUser, connection.connectionSQL);
                command.ExecuteNonQuery();
                MessageBox.Show("Empleado " + this.document + " eliminado");
                Console.WriteLine("Employee deleted successfully");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying delete employee (" + document + ")\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

    }

    public class Dealer
    {
        string name, cellphone, phone, address, web, contact_email;

        public Dealer(string name, string cellphone, string phone, string address, string web, string contact_email)
        {
            this.name = name;
            this.cellphone = cellphone;
            this.phone = phone;
            this.address = address;
            this.web = web;
            this.contact_email = contact_email;
        }

        ConnectionDB connection = new ConnectionDB();

        public void insert()
        {
            try
            {
                connection.openConnectionDB();

                string commandInsertDealer = "INSERT INTO DEALERS ([name],[number_cellphone],[number_phone],[address],[web],[contact_email]) " +
                "VALUES(@Name,@Cellphone,@Phone,@Address,@Web,@Email)";
                SqlCommand command = new SqlCommand(commandInsertDealer, connection.connectionSQL);
                command.Parameters.AddWithValue("Name",name);
                command.Parameters.AddWithValue("Cellphone",cellphone);
                command.Parameters.AddWithValue("Phone",phone);
                command.Parameters.AddWithValue("Address",address);
                command.Parameters.AddWithValue("Web",web);
                command.Parameters.AddWithValue("Email",contact_email);
                command.ExecuteNonQuery();
                Console.WriteLine("Row added successful (DEALER)");
                MessageBox.Show("Row added successful (DEALER)");
                
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
            

        }

        public void update(string dealerIDToUpdate)
        {
            try
            {
                connection.openConnectionDB();

                string commandUpdateDealer = "UPDATE DEALERS " +
                    "SET [name]=@Name,[number_phone]=@Phone,[number_cellphone]=@Cellphone,[address]=@Address,[contact_email]=@Email " +
                    "WHERE [id] = @dealerID";
                SqlCommand commandDealer = new SqlCommand(commandUpdateDealer, connection.connectionSQL);
                commandDealer.Parameters.AddWithValue("Name", name);
                commandDealer.Parameters.AddWithValue("Phone", phone);
                commandDealer.Parameters.AddWithValue("Cellphone", cellphone);
                commandDealer.Parameters.AddWithValue("Address", address);
                commandDealer.Parameters.AddWithValue("Web", web);
                commandDealer.Parameters.AddWithValue("Email", contact_email);
                commandDealer.Parameters.AddWithValue("dealerID", dealerIDToUpdate);
                commandDealer.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (DEALER)");
                Console.WriteLine("Row updated successful (DEALER)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying update a row from DEALERS\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

    }

    public class Line
    {
        string name;

        public Line(string name)
        {
            this.name = name;
        }

        ConnectionDB connection = new ConnectionDB();

        

        public void insert()
        {
            try
            {
                connection.openConnectionDB();
                string commandInsertLine= "INSERT INTO LINES ([name]) " +
                "VALUES (@Name)";
                SqlCommand command = new SqlCommand(commandInsertLine, connection.connectionSQL);
                command.Parameters.AddWithValue("Name",name);
                command.ExecuteNonQuery();
                Console.WriteLine("Row added successful (LINE)");
                MessageBox.Show("Row added successful (LINE)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }
    }

    public class Brand
    {
        string name;

        public Brand(string name)
        {
            this.name = name;
        }

        ConnectionDB connection = new ConnectionDB();

        public void insert()
        {
            try
            {
                connection.openConnectionDB();
                string commandInsertBrand = "INSERT INTO BRANDS ([name]) " +
                "VALUES (@Name)";
                SqlCommand command = new SqlCommand(commandInsertBrand, connection.connectionSQL);
                command.Parameters.AddWithValue("Name", name);
                command.ExecuteNonQuery();
                Console.WriteLine("Row added successful (BRAND)");
                MessageBox.Show("Row added successful (BRAND)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }
    }

    public class Product
    {
        string reference, name, barcode, description;
        double price;
        int stock, minimum_stock;
        int id_dealer, id_brand, id_line;

        ConnectionDB connection = new ConnectionDB();

        public Product(string reference, string name, string barcode,double price,int id_dealer,int id_brand,int  id_line,
            int stock = 0, int minimum_stock = 0, string description = "")
        {
            this.reference = reference;
            this.name = name;
            this.barcode = barcode;
            this.price = price;
            this.stock = stock;
            this.minimum_stock = minimum_stock;
            this.description = description;
            this.id_dealer = id_dealer;
            this.id_brand = id_brand;
            this.id_line = id_line;
        }

        public void insert()
        {
            try
            {
                connection.openConnectionDB();
                string commandInsert = "INSERT INTO PRODUCTS ([reference],[name],[barcode],[price],[stock],[minimum_stock],[description],[id_dealer],[id_brand],[id_line]) " +
                    "VALUES (@Reference,@Name,@Barcode,@Price,@Stock,@MinimumStock,@Description,@IDDealer,@IDBrand,@IDLine)";
                SqlCommand command = new SqlCommand(commandInsert, connection.connectionSQL);
                command.Parameters.AddWithValue("Reference",reference);
                command.Parameters.AddWithValue("Name",name);
                command.Parameters.AddWithValue("Barcode",barcode);
                command.Parameters.AddWithValue("Price",price);
                command.Parameters.AddWithValue("Stock",stock);
                command.Parameters.AddWithValue("MinimumStock",minimum_stock);
                command.Parameters.AddWithValue("Description",description);
                command.Parameters.AddWithValue("IDDealer",id_dealer);
                command.Parameters.AddWithValue("IDBrand",id_brand);
                command.Parameters.AddWithValue("IDLine",id_line);
                command.ExecuteNonQuery();
                Console.WriteLine("Row added successful (PRODUCT)");
                MessageBox.Show("Row added successful (PRODUCT)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();

            }
        }

        public void update(int productIDToUpdate)
        {
            try
            {
                connection.openConnectionDB();

                string commandUpdateProduct = "UPDATE PRODUCTS " +
                    "SET [reference]=@Reference,[name]=@Name,[barcode]=@Barcode,[price]=@Price,[stock]=@Stock,[minimum_stock]=@MinimumStock,[description]=@Description,[id_dealer]=@DealerID,[id_brand]=@BrandID,[id_line]=@LineID " +
                    "WHERE id=@ProductID";
                SqlCommand commandProduct = new SqlCommand(commandUpdateProduct, connection.connectionSQL);
                commandProduct.Parameters.AddWithValue("Reference", reference);
                commandProduct.Parameters.AddWithValue("Name", name);
                commandProduct.Parameters.AddWithValue("Price", price);
                commandProduct.Parameters.AddWithValue("Barcode", barcode);
                commandProduct.Parameters.AddWithValue("Stock", stock);
                commandProduct.Parameters.AddWithValue("MinimumStock", minimum_stock);
                commandProduct.Parameters.AddWithValue("Description", description);
                commandProduct.Parameters.AddWithValue("DealerID", id_dealer);
                commandProduct.Parameters.AddWithValue("BrandID", id_brand);
                commandProduct.Parameters.AddWithValue("LineID", id_line);
                commandProduct.Parameters.AddWithValue("ProductID", productIDToUpdate);
                commandProduct.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (PRODUCT)");
                Console.WriteLine("Row updated successful (PRODUCT)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying update a row from PRODUCTS\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }


    }

    public class Service
    {
        string reference, name, barcode, description;
        double price;

        public Service(string reference , string name, string barcode, double price, string description = "None")
        {
            this.reference = reference;
            this.name = name;
            this.barcode = barcode;
            this.price = price;
            this.description = description;
        }

        ConnectionDB connection = new ConnectionDB();

        public void insert()
        {
            try
            {
                connection.openConnectionDB();
                string commandInsert = "INSERT INTO SERVICES ([name],[reference],[barcode],[price],[description]) " +
                    "VALUES (@Name, @Reference, @Barcode, @Price, @Description)";
                SqlCommand command = new SqlCommand(commandInsert,connection.connectionSQL);
                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Reference",reference);
                command.Parameters.AddWithValue("Barcode",barcode);
                command.Parameters.AddWithValue("Price",price);
                command.Parameters.AddWithValue("Description",description);
                command.ExecuteNonQuery();
                Console.WriteLine("Row added successful (SERVICE)");
                MessageBox.Show("Row added successful (SERVICE)");

            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying insert a new row\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }

        public void update(string serviceIDToUpdate)
        {
            try
            {
                connection.openConnectionDB();

                string commandUpdateDealer = "UPDATE SERVICES " +
                    "SET [name] = @Name,[reference] = @Reference,[barcode] = @Barcode,[price] = @Price,[description] = @Description " +
                    "WHERE [id] = @serviceID";
                SqlCommand commandDealer = new SqlCommand(commandUpdateDealer, connection.connectionSQL);
                commandDealer.Parameters.AddWithValue("Name", name);
                commandDealer.Parameters.AddWithValue("Reference", reference);
                commandDealer.Parameters.AddWithValue("Barcode", barcode);
                commandDealer.Parameters.AddWithValue("Price", price);
                commandDealer.Parameters.AddWithValue("Description", description);;
                commandDealer.Parameters.AddWithValue("serviceID", serviceIDToUpdate);
                commandDealer.ExecuteNonQuery();
                MessageBox.Show("Row updated successful (SERVICE)");
                Console.WriteLine("Row updated successful (SERVICE)");
            }
            catch (SqlException Error)
            {
                MessageBox.Show("ERROR");
                Console.WriteLine("Error! An error ocurred while the system was trying update a row from SERVICES\n" + Error);
            }
            finally
            {
                connection.closeConnectionDB();
            }
        }
    }
}
