using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string log1;
        string pass1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bd = "mybd";
            string host = "localhost";
            string user = "root";
            string pass = "";
            string role;

            try
            {

                string myConnectionString = "Database=" + bd + ";Data Source=" + host + ";User Id=" + user + ";Password=" + pass + "";
                MySqlConnection myConnection = new MySqlConnection(myConnectionString);

                myConnection.Open();
                log1 = textBox1.Text;
                pass1 = textBox2.Text;
                role = "user";

                MessageBox.Show("Success");
                string sql = "SELECT `users`.`role` FROM `mybd`.`users` WHERE `login` = '" + log1 + "'AND `password` = '" + pass1 + "' ";
                MySqlCommand com = new MySqlCommand(sql, myConnection);
                MessageBox.Show(role);
                MySqlDataReader reader = com.ExecuteReader();

                reader.Read();

               // if (reader.Read())
                    role = reader[0].ToString();

                MessageBox.Show(role);

                //role = bd.role(textBox1.Text, textBox2.Text);

                //if (role == "admin")
                
                    Form form2 = new Form2(role);
                    form2.Show();
                    this.Hide();
                      reader.Close();
                    myConnection.Close();





                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
