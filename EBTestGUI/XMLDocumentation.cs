using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml;
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
        string path, xpathNew;
        List<Panel> newList = new List<Panel>();
        XmlDocument xml = new XmlDocument();
        private bool buttonEditwasClicked = false;
        private bool buttonGetXMLwasClicked = false; 
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
          
            newList.Add(panelXML1Display);
            newList.Add(panelXML1Edit);
            newList.Add(PanelXMLInstruction);

            List<SiteCombo> listSite = new List<SiteCombo>();
            listSite.Add(new SiteCombo() { ID = "Test", site = "Test" });
            listSite.Add(new SiteCombo() { ID = "Live", site = "Live" });
            SiteComboBox.DataSource = listSite;
            SiteComboBox.ValueMember = "ID";
            SiteComboBox.DisplayMember = "site";

         
            List<ProductCombo> listProduct = new List<ProductCombo>();
            listProduct.Add(new ProductCombo() { ID = "Bus", product = "Bus" });
            listProduct.Add(new ProductCombo() { ID = "Ferry", product = "Ferry" });
            listProduct.Add(new ProductCombo() { ID = "Train", product = "Train" });
            listProduct.Add(new ProductCombo() { ID = "Car", product = "Car" });
            ProductComboBox.DataSource = listProduct;
            ProductComboBox.ValueMember = "ID";
            ProductComboBox.DisplayMember = "product";

            List<CurrencyCombo> listCurrency = new List<CurrencyCombo>();
            listCurrency.Add(new CurrencyCombo() { ID = "MYR", currency = "MYR" });
            listCurrency.Add(new CurrencyCombo() { ID = "SGD", currency = "SGD" });
            CurrencyComboBox.DataSource = listCurrency;
            CurrencyComboBox.ValueMember = "ID";
            CurrencyComboBox.DisplayMember = "currency";

        }

         public void xmlPath (string xmlfilePath)
        {
            path = xmlfilePath;
        }

        private void GetXMLButton_Click(object sender, EventArgs e)
        {
            buttonGetXMLwasClicked = true;
           //IndexInputCallXML ind = new IndexInputCallXML();
           //int key = ind.ReadElement(path, ProductComboBox.SelectedValue.ToString(), SiteComboBox.SelectedValue.ToString(), CurrencyComboBox.SelectedValue.ToString());
            //newList[key-1].BringToFront();
            //MessageBox.Show("GET XML ===> product : " + ProductComboBox.SelectedValue.ToString() + " - site : " + SiteComboBox.SelectedValue.ToString() + " - currency : " + CurrencyComboBox.SelectedValue.ToString());
            xml.Load(path);

            if (ProductComboBox.SelectedValue.ToString().ToLower().Contains("car"))
            {
                XmlNodeList xnMenu5 = xml.SelectNodes("ETAS/Product");
                foreach (XmlNode xnode in xnMenu5)
                {
                    RoutesFromContent.Text = xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL1"].InnerText.Trim();
                    toLabelDisplay.Text = "";
                    RoutesToContent.Text = "area";
                }
            }

            else
            {
                XmlNodeList xnMenu4 = xml.SelectNodes("ETAS/Product");
                foreach (XmlNode xnode in xnMenu4)
                {
                    RoutesFromContent.Text = xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL1"].InnerText.Trim();
                    toLabelDisplay.Text = "to";
                    RoutesToContent.Text = xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL2"].InnerText.Trim();

                }
            }

            XmlNodeList xnMenu1 = xml.SelectNodes("ETAS/Date");
            foreach (XmlNode xnode in xnMenu1)
            {
                DateContent1.Text = xnode[ProductComboBox.SelectedValue.ToString()]["DateValue"]["OneWay"][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()].InnerText.Trim();
            }
            
            XmlNodeList xnMenu2 = xml.SelectNodes("ETAS/SelectTrip");
            foreach (XmlNode xnode in xnMenu2)
            {
                TripContent1.Text = xnode[ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["XPath"].InnerText.Trim();
            }
            
           
            XmlNodeList xnMenu3 = xml.SelectNodes("ETAS/Seat");
            foreach (XmlNode xnode in xnMenu3)
            {
                ContinueContent1.Text = xnode[ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["ContinueButton"]["XPath"].InnerText.Trim();
            }
            
          
            newList[0].BringToFront();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (buttonGetXMLwasClicked == false)
            {
                MessageBox.Show("Get intended XML documentation before edit");
                return;
            }
            buttonEditwasClicked = true;

            //MessageBox.Show("EDIT ===> product : " + ProductComboBox.SelectedValue.ToString() + " - site : " + SiteComboBox.SelectedValue.ToString() + " - currency : " + CurrencyComboBox.SelectedValue.ToString());
            xml.Load(path);

            if ((ProductComboBox.SelectedValue.ToString().ToLower().Contains("car")))
            {
                XmlNodeList xnMenu4 = xml.SelectNodes("ETAS/Product");
                foreach (XmlNode xnode in xnMenu4)
                {
                    RoutesFromTextBox.Text = xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL1"].InnerText.Trim();
                    RoutesToTextBox.Text = "area";
                    RoutesToTextBox.ReadOnly = true;
                    toLabel.Text = "";
                }
            }
            else
            {
                XmlNodeList xnMenu4 = xml.SelectNodes("ETAS/Product");
                foreach (XmlNode xnode in xnMenu4)
                {
                    RoutesFromTextBox.Text = xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL1"].InnerText.Trim();
                    RoutesToTextBox.Text = xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL2"].InnerText.Trim();
                    toLabelDisplay.Text = "to";
                }
            }

            XmlNodeList xnMenu1 = xml.SelectNodes("ETAS/Date");
            foreach (XmlNode xnode in xnMenu1)
            {
                dateTimePickerUpdateXML.Value = DateTime.Parse(xnode[ProductComboBox.SelectedValue.ToString()]["DateValue"]["OneWay"][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()].InnerText.Trim());
                //dateContent1TextBox.Text = xnode[ProductComboBox.SelectedValue.ToString()]["DateValue"]["OneWay"][SiteComboBox.SelectedValue.ToString()].InnerText.Trim();
            }
            XmlNodeList xnMenu2 = xml.SelectNodes("ETAS/SelectTrip");
            foreach (XmlNode xnode in xnMenu2)
            {
                tripContent1TextBox.Text = xnode[ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["XPath"].InnerText.Trim();
            }
            
            XmlNodeList xnMenu3 = xml.SelectNodes("ETAS/Seat");
            foreach (XmlNode xnode in xnMenu3)
            {
                ContContent1TextBox.Text = xnode[ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["ContinueButton"]["XPath"].InnerText.Trim();
            }
            
            
            newList[1].BringToFront();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login logOut = new Login();
            logOut.Show();
        }

        private void EditXMLButton_Click(object sender, EventArgs e)
        {
            newList[2].BringToFront();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (buttonEditwasClicked == false)
            {
                MessageBox.Show("Edit first before update");
                return;
            }

            if (RoutesFromTextBox.Text == RoutesToTextBox.Text)
            {
                MessageBox.Show("From and to place cannot be the same");
                return;
            }
            //MessageBox.Show("UPDATE ===> product : " + ProductComboBox.SelectedValue.ToString() + " - site : " + SiteComboBox.SelectedValue.ToString() + " - currency : " + CurrencyComboBox.SelectedValue.ToString());
            DialogResult dialogResult = MessageBox.Show("Are you sure want to edit the XML data?", "Confirmation Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                xpathNew = RoutesFromTextBox.Text;
                RoutesFromContent.Text = xpathNew;
                



                //xpathNew = dateContent1TextBox.Text;
                xpathNew = dateTimePickerUpdateXML.Value.ToString("yyyy-MM-dd");
                DateContent1.Text = xpathNew;

                xpathNew = tripContent1TextBox.Text;
                TripContent1.Text = xpathNew;

                xpathNew = ContContent1TextBox.Text;
                ContinueContent1.Text = xpathNew;


                newList[0].BringToFront();
                xml.Load(path);

                if ((ProductComboBox.SelectedValue.ToString().ToLower().Contains("car")))
                {
                    XmlNodeList xnMenu4 = xml.SelectNodes("ETAS/Product");
                    foreach (XmlNode xnode in xnMenu4)
                    {
                        xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL1"].InnerText = RoutesFromContent.Text;
                        //xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()]["URL2"].InnerText = RoutesToContent.Text;
                    }
                }
                else
                {
                    xpathNew = RoutesToTextBox.Text;
                    RoutesToContent.Text = xpathNew;

                    XmlNodeList xnMenu4 = xml.SelectNodes("ETAS/Product");
                    foreach (XmlNode xnode in xnMenu4)
                    {
                        xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL1"].InnerText = RoutesFromContent.Text;
                        xnode["ProductName"][ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["URL2"].InnerText = RoutesToContent.Text;
                    }
                }

                XmlNodeList xnMenu1 = xml.SelectNodes("ETAS/Date");
                foreach (XmlNode xnode in xnMenu1)
                {
                    xnode[ProductComboBox.SelectedValue.ToString()]["DateValue"]["OneWay"][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()].InnerText = DateContent1.Text;
                }

                XmlNodeList xnMenu2 = xml.SelectNodes("ETAS/SelectTrip");
                foreach (XmlNode xnode in xnMenu2)
                {
                    xnode[ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["XPath"].InnerText = TripContent1.Text;
                }

                XmlNodeList xnMenu3 = xml.SelectNodes("ETAS/Seat");
                foreach (XmlNode xnode in xnMenu3)
                {
                    xnode[ProductComboBox.SelectedValue.ToString()][SiteComboBox.SelectedValue.ToString()][CurrencyComboBox.SelectedValue.ToString()]["ContinueButton"]["XPath"].InnerText = ContinueContent1.Text;
                }

                MessageBox.Show("Update for [" + ProductComboBox.SelectedValue.ToString() + " <=> " + SiteComboBox.SelectedValue.ToString() + " <=> " + CurrencyComboBox.SelectedValue.ToString()+"] successful");
                buttonEditwasClicked = false;
                xml.Save(path);
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Update cancelled");
                return;
            }
        }
    }
}
