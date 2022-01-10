using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string role1;
        public Form2(string role)
        {
            InitializeComponent();
            role1 = role;
            if(role1 == "user")
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
            }
           

        }

       /* private void button5_Click(object sender, EventArgs e)
        {
            Form form1 = Application.OpenForms[0];
            form1.Show();
            this.Close();     
        }*/

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form1 = Application.OpenForms[0];
            form1.Show();
            MessageBox.Show(role1);

            //this.Close();     если писать в button_Click()
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.Show();
           // this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form5 = new Form5();
            form5.Show();
        }
    }
}
