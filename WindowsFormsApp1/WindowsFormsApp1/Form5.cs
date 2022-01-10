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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string db = "mybd";
            string host = "localhost";
            string user = "root";
            string pass = "";
            string myConnectionString = "Database=" + db + ";Data Source=" + host + ";User Id=" + user + ";Password=" + pass;

            MySqlConnection myConnection = new MySqlConnection(myConnectionString);
            myConnection.Open();

            string s;
            string s2;
            string s3;
            DataGridViewRow row;
            MessageBox.Show(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                row = dataGridView1.Rows[i];
                s = row.Cells[0].Value.ToString();
                s2 = row.Cells[1].Value.ToString();
                s3 = row.Cells[2].Value.ToString();
                string sql = " INSERT INTO `mybd`.`users` ( `login`,  `password`, `role`) VALUES('" + s + "','" + s2 + "','"+ s3 +"');";
                MessageBox.Show(sql);
                MySqlCommand com = new MySqlCommand(sql, myConnection);

                com.ExecuteNonQuery();
                MessageBox.Show(s);



            }

        }
    }
}
