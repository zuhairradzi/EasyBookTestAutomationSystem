using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operationPerform = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonClick(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0")
            {
                textBox_Result.Clear();
            }
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerform = button.Text;
            result = Double.Parse(textBox_Result.Text);
        }

        private void buttonClearE_click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void buttonClear_click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            result = 0;
        }

        private void operationEqual_click(object sender, EventArgs e)
        {

        }
        
    }
    
    
}
