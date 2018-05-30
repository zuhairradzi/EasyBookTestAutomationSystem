using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBTestGUI
{
    public partial class HomePage : Form
    {
        string productComboInput, siteComboInput, currencyComboInput;
        List<Panel> newList = new List<Panel>();
        public HomePage()
        {
            InitializeComponent();
        }
      

        private void GenerateOSTab_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form3 = new Form1();
            form3.Show();
        }

        private void CheckBHButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form3 = new Form1();
            form3.Show();
        }

        private void TestBuyButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form3 = new Form1();
            form3.Show();
        }

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form3 = new Form1();
            form3.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            newList.Add(panelXML1);//0
            /*ComboboxItem item = new ComboboxItem();
            item.Text = "Item text1";
            item.Value = 12;

            Product.Items.Add(item);

            Product.SelectedIndex = 0;*/

            //MessageBox.Show((Product.SelectedItem as ComboboxItem).Value.ToString());
            Dictionary<string, string> productValue = new Dictionary<string, string>();
            productValue.Add("0", "Bus");
            productValue.Add("1", "Ferry");
            productValue.Add("3", "Train");
            productValue.Add("4", "Car");
            ProductComboBox.DataSource = new BindingSource(productValue, null);
            ProductComboBox.DisplayMember = "Value";
            ProductComboBox.ValueMember = "Key";

            Dictionary<string, string> siteValue = new Dictionary<string, string>();
            siteValue.Add("1", "Live");
            siteValue.Add("2", "Test");
            SiteComboBox.DataSource = new BindingSource(siteValue, null);
            SiteComboBox.DisplayMember = "Value";
            SiteComboBox.ValueMember = "Key";

            Dictionary<string, string> currencyValue = new Dictionary<string, string>();
            currencyValue.Add("1", "MYR");
            currencyValue.Add("2", "SGD");
            CurrencyComboBox.DataSource = new BindingSource(currencyValue, null);
            CurrencyComboBox.DisplayMember = "Value";
            CurrencyComboBox.ValueMember = "Key";
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void GetXMLButton_Click(object sender, EventArgs e)
        {
            productComboInput = ProductComboBox.SelectedItem.ToString();
            int productInt = Convert.ToInt32(productComboInput);
           // siteComboInput = SiteComboBox.ValueMember.ToString();
            //currencyComboInput = CurrencyComboBox.ValueMember.ToString();

            newList[productInt].BringToFront();
        }
    }
}
