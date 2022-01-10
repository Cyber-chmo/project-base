using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using System.IO;
using System.Net;

namespace WindowsFormsApp1
{

    public partial class Form4 : Form
    {   // сюда переместить
        CheckBox[] chBoxes = new CheckBox[20];
        int chBoxCount = 0;
        int chBoxCountCars = 0;
        int Kol_fild = 0;
        TextBox[] chText = new TextBox[20];//текстовые поля
        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {


            string db = "mybd";
            string host = "localhost";
            string user = "root";
            string pass = "";
            string myConnectionString = "Database=" + db + ";Data Source=" + host + ";User Id=" + user + ";Password=" + pass;

            MySqlConnection myConnection = new MySqlConnection(myConnectionString);
            myConnection.Open();

            string sql = "SHOW COLUMNS FROM `mybd`.`cars`";

            MySqlCommand command = new MySqlCommand(sql, myConnection);
            MySqlDataReader reader = command.ExecuteReader();



            //********** переместить вверх ***
            // CheckBox[] chBoxes = new CheckBox[10];
            // int chBoxCount = 0;
            //*********
            //label1.Visible = true;
            while (reader.Read())
            {

                if (reader[0].ToString() != "ID")
                {
                    chBoxes[chBoxCount] = new CheckBox(); // инициализируем чек бокс.
                    chBoxes[chBoxCount].AutoSize = true;
                    //задаем имя чекбоксу
                    chBoxes[chBoxCount].Text = reader[0].ToString();
                    //его положение в окне
                    chBoxes[chBoxCount].Location = new Point(50, 50 + chBoxCount * 30);
                    this.Controls.Add(chBoxes[chBoxCount]);

                    chText[chBoxCount] = new TextBox(); // инициализируем текстовое поле
                    chText[chBoxCount].Width = 150;
                    chText[chBoxCount].Text = "";
                    //его положение в окне
                    chText[chBoxCount].Location = new Point(120, 50 + chBoxCount * 30);
                    this.Controls.Add(chText[chBoxCount]);


                    chBoxCount++;
                }
            }
            chBoxCountCars = chBoxCount;
            reader.Close();


            sql = "SHOW COLUMNS FROM `mybd`.`cars_owners`";

            command = new MySqlCommand(sql, myConnection);
            reader = command.ExecuteReader();



            //********** переместить вверх ***
            // CheckBox[] chBoxes = new CheckBox[10];
            // int chBoxCount = 0;
            //*********
            int label2_y = 50 + chBoxCount * 30 + 20;
            while (reader.Read())
            {
                //label2.Visible = true;
                //label2.Location = new Point(50, label2_y);

                if (reader[0].ToString() != "id")
                {
                    chBoxes[chBoxCount] = new CheckBox(); // инициализируем чек бокс.
                    chBoxes[chBoxCount].AutoSize = true;
                    //задаем имя чекбоксу
                    chBoxes[chBoxCount].Text = reader[0].ToString();
                    //его положение в окне
                    chBoxes[chBoxCount].Location = new Point(50, 100 + chBoxCount * 30);
                    this.Controls.Add(chBoxes[chBoxCount]);

                    chText[chBoxCount] = new TextBox(); // инициализируем текстовое поле
                    chText[chBoxCount].Width = 150;
                    chText[chBoxCount].Text = "";
                    //его положение в окне
                    chText[chBoxCount].Location = new Point(120, 100 + chBoxCount * 30);
                    this.Controls.Add(chText[chBoxCount]);


                    chBoxCount++;
                }
            }

            reader.Close();

            myConnection.Close();
            // не подайдет pictureBox1.Image = Image.FromFile("http://localhost/IMG_20210129.jpg");

            string strUrl = "http://localhost/pic1.jpg";

            WebRequest webreq = WebRequest.Create(strUrl);
            WebResponse webres = webreq.GetResponse();
            Stream stream = webres.GetResponseStream();

            Image image = Image.FromStream(stream);

            stream.Close();
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;//Коректируем изображение,соблюдая пропорции
            pictureBox1.Size = new Size(300, 250);//Задаем размер картинки
        }
        //DataGridView1.SelectedRows[0].Index;
        /* 
         * 
         * private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)

           { 
               string s = dataGridView1[Kol_fild, indexCurrent].Value.ToString();  
               MessageBox.Show(s);                                                
           }
        
         
         */
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string s = dataGridView1.CurrentCell.RowIndex.ToString();
            int indexCurrent = dataGridView1.CurrentCell.RowIndex;
           // string s = dataGridView1[0, indexCurrent].Value.ToString();
            MessageBox.Show(s);

            string sql = "SELECT `pic` FROM `mybd`.`cars` WHERE `id`= '";
            sql = sql + s + "'";
            MessageBox.Show(sql);
            string db = "mybd";
            string host = "localhost";
            string user = "root";
            string pass = "";
            string myConnectionString = "Database=" + db + ";Data Source=" + host + ";User Id=" + user + ";Password=" + pass;

            MySqlConnection myConnection = new MySqlConnection(myConnectionString);
            myConnection.Open();

            MySqlCommand command = new MySqlCommand(sql, myConnection);
            MySqlDataReader reader = command.ExecuteReader();
            //reader.Read();
            //MessageBox.Show(reader[0].ToString());


            string strUrl = "http://localhost/pic1.jpg";

            if (reader.Read())
                strUrl = "http://localhost/" + reader[0].ToString();

            WebRequest webreq = WebRequest.Create(strUrl);
            WebResponse webres = webreq.GetResponse();
            Stream stream = webres.GetResponseStream();
            Image image;

            image = Image.FromStream(stream);

            pictureBox1.Image = image;
            stream.Close();




        }
        private void button1_Click(object sender, EventArgs e)
        {
            string db = "mybd";
            string host = "localhost";
            string user = "root";
            string pass = "";
            Kol_fild = 0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns.RemoveAt(0);

            //MessageBox.Show("dataGridView1.Columns.Count.ToString");
            try
            {
                string myConnectionString = "Database=" + db + ";Data Source=" + host + ";User Id=" + user + ";Password=" + pass;

                MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                myConnection.Open();



                int k = 0;

                //массив для имен чекбоксов
                string[] dataGridFild = new string[20];
                bool where = false;
                bool firsttable = false;
                //`cars`.`id`
                string sql = "SELECT  ";
               // k++;
                for (int i = 0; i < chBoxCountCars; i++)  // изменено
                    if (chBoxes[i].Checked == true)
                    {
                        firsttable = true;
                        if (chText[i].Text != "") where = true;
                        if (k > 0) sql = sql + ", `cars`.`" + chBoxes[i].Text + "` ";
                        else sql = sql + " `cars`.`" + chBoxes[i].Text + "` ";
                        //добавляем значение в массив для имен чекбоксов
                        dataGridFild[k] = chBoxes[i].Text;
                        k++;
                    }
                bool secondtable = false;
                for (int i = chBoxCountCars; i < chBoxCount; i++)
                    if (chBoxes[i].Checked == true)
                    {
                        secondtable = true;
                        if (chText[i].Text != "") where = true;
                        if (k > 0) sql = sql + ", `cars_owners`.`" + chBoxes[i].Text + "` ";
                        else sql = sql + " `cars_owners`.`" + chBoxes[i].Text + "` ";
                        //добавляем значение в массив для имен чекбоксов
                        dataGridFild[k] = chBoxes[i].Text;
                        k++;
                    }
                Kol_fild = k;
                sql = sql + "  FROM ";
                if (firsttable) sql = sql + "`mybd`.`cars`";
                if (secondtable && firsttable) sql = sql + " ,  ";
                if (secondtable) sql = sql + "`mybd`.`cars_owners` ";




                int k_where = 0;
                if (secondtable && firsttable)
                {
                    sql = sql + "  WHERE `cars`.`cars_owner`=`cars_owners`.`id`";
                    k_where = 1;
                }

                if (where)
                {
                    if (k_where != 0) sql = sql + "  WHERE ";
                    for (int i = 0; i < chBoxCountCars; i++)
                        if (chBoxes[i].Checked == true)
                        {
                            if (chText[i].Text != "")
                                if (k_where > 0) sql = sql + " and `" + chBoxes[i].Text + "` = '" + chText[i].Text + "'  ";
                                else { sql = sql + "`" + chBoxes[i].Text + "` = '" + chText[i].Text + "'  "; k_where++; }
                            //добавляем значение в массив для имен чекбоксов


                        }
                }
                MessageBox.Show(sql);





                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader reader = command.ExecuteReader();
                // добавляем в датагридвью столбцы
                for (int i = 0; i < k; i++)
                    dataGridView1.Columns.Add(dataGridFild[i], dataGridFild[i]);

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[k]);
                    for (int i = 0; i < k; i++)
                        data[data.Count - 1][i] = reader[i].ToString();
                    // data[data.Count - 1][1] = reader[1].ToString();
                    //data[data.Count - 1][2] = reader[2].ToString();
                }
                reader.Close();
                myConnection.Close();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex);

            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[1];
            ifrm.Show();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

































