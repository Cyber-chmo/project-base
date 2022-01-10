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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bd = "mybd";
            string host = "localhost";
            string user = "root";
            string pass = "";

            try
            {
                string myConnectionString = "Database=" + bd + ";Data Source=" + host + ";User Id=" + user + ";Password=" + pass + "";
                MySqlConnection myConnection = new MySqlConnection(myConnectionString);

                myConnection.Open();

                MessageBox.Show("Success");

                string s;
                string s2;
                DataGridViewRow row;
                MessageBox.Show(dataGridView1.Rows.Count.ToString());
                for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
                {
                    row = dataGridView1.Rows[i];
                    s = row.Cells[0].Value.ToString();
                    s2 = row.Cells[1].Value.ToString();
                    string sql = " INSERT INTO `mybd`.`cars` ( `num`,  `model`) VALUES('"+ s2 +"','"+ s +"');";
                    MessageBox.Show(sql);
                    MySqlCommand com = new MySqlCommand(sql, myConnection);
                
                    com.ExecuteNonQuery();
                    MessageBox.Show(s);
                }


                //Console.WriteLine("Данные добавлены");
                MessageBox.Show("Данные добавлены");


                /*
                                               foreach(DataGridViewRow row in dataGridView1.Rows)
                                               {

                                                   s = row.Cells[1].Value.ToString();
                                                   MessageBox.Show(s);
                                               }

                                               */







            }
            catch (Exception ex)
            {
                MessageBox.Show("r" + ex );
      
            }
    }   }
    
}
