using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
using System.Text.RegularExpressions;//Valid Email
using System.Data.SqlClient;

namespace Business_Administrator
{
    class ownFunctions
    {

        public void emptyFields(TextBox[] field)
        {
            Console.WriteLine("Empty Fields =>");
            for (int i = 0; i < field.Length; i++)
            {
                field[i].Text = "";
                Console.WriteLine(field[i].Name + " = empty");
            }
        }
        public bool checkCombos(ComboBox[] fields)
        {
            bool status = false;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].SelectedItem != null)
                {
                    status = true;
                    Console.WriteLine(fields[i].Name + " = true");
                }
                else
                {
                    status = false;
                    Console.WriteLine(fields[i].Name + " = false\nEND TRY");
                    break;
                }
            }
            return status;
        }

        public bool checkFields(TextBox[] fields)
        {
            bool status = false;
            for (int i=0; i<fields.Length;i++)
            {
                if (fields[i].TextLength != 0)
                {
                    status = true;
                    Console.WriteLine(fields[i].Name+" = true");
                }
                else
                {
                    status = false;
                    Console.WriteLine(fields[i].Name + " = false\nEND TRY");
                    break;
                }
            }
            return status;
        }

        public bool checkLenghtTexBox(TextBox textBox,int lenght)
        {
            if (textBox.TextLength >= lenght) return true;
            else return false;
        }

        public bool checkLenghtEspecificTexBox(TextBox textBox, int lenght)
        {
            if (textBox.TextLength == lenght) return true;
            else return false;
        }

        public bool checkValidEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
