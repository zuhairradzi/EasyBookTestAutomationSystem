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

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void emailTextbox_Click(object sender, EventArgs e)
        {
            emailTextbox.Text = "";
        }

        private void passwordTextbox_Click(object sender, EventArgs e)
        {
            passwordTextbox.UseSystemPasswordChar = true;
            passwordTextbox.Text = "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\testlogin.mdf\";Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login where email ='" + emailTextbox.Text + "' and password='" + passwordTextbox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Menu home = new Menu();
                home.Show();
            }
            else
            {
                MessageBox.Show("please enter correct email and password", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void emailTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
