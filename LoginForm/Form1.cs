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

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\Test1.mdf\";Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Login where Username ='"+User_textBox.Text+ "' and Password ='"+ Password_textBox.Text+"'", connect);
            Console.WriteLine("Select Count(*) from Login where Username ='" + User_textBox.Text + "' and Password ='" + Password_textBox.Text + "'");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Homepage home = new Homepage();
                home.Show();
            }
            else
            {
                MessageBox.Show("Please enter correct email and password");
            }

            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void password_Click(object sender, EventArgs e)
        {
            // Set to no text.
            Password_textBox.Text = "";
            // The password character is an asterisk.
            Password_textBox.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            Password_textBox.MaxLength = 14;
        }
    }
}
