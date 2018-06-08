using System;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace EBTestGUI
{
    public partial class Login : Form
    {
        String XMLFilePath = "D:\\Easybook Test System\\ETAS.xml";
        XmlDocument xml = new XmlDocument();

        string passKey = "eb123";
        string ETASemail, ETASpass;
        string emailEN, passEN;

        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        //Encrypt

        public Login()
        {
            InitializeComponent();
        }

        private void emailTextBox_Click(object sender, EventArgs e)
        {
            emailTextBox.Text = "";
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.MaxLength = 14;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            xml.Load(XMLFilePath);
            XmlNodeList xnMenu1 = xml.SelectNodes("/ETAS/Login/EB");
            foreach (XmlNode xnode in xnMenu1)
            {
                emailEN = xnode["Email"].InnerText.Trim();
                passEN = xnode["Password"].InnerText.Trim();
            }
            Login decryp = new Login();
            ETASemail = decryp.DecryptStringEmail(emailEN);
            ETASpass = decryp.DecryptStringPW(passEN);
            if (!emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Please enter the correct email format", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (emailTextBox.Text != ETASemail && passwordTextBox.Text == ETASpass)
            {
                MessageBox.Show("Email not found", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (emailTextBox.Text == ETASemail && passwordTextBox.Text != ETASpass)
            {
                MessageBox.Show("Password incorrect", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (emailTextBox.Text == ETASemail && passwordTextBox.Text == ETASpass)
            {
                this.Hide();
                Form1 home = new Form1();
                home.Show();
            }
            else
            {
                MessageBox.Show("Please enter correct email and password", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonBypass_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public string DecryptStringEmail(string emailEN)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(emailEN);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passKey, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public string DecryptStringPW(string passEN)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(passEN);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passKey, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
