namespace EBTestGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonCar = new System.Windows.Forms.RadioButton();
            this.radioButtonTrain = new System.Windows.Forms.RadioButton();
            this.radioButtonFerry = new System.Windows.Forms.RadioButton();
            this.radioButtonBus = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonTest = new System.Windows.Forms.RadioButton();
            this.radioButtonLive = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButtonPPSGD = new System.Windows.Forms.RadioButton();
            this.radioButtonPPMYR = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.EBTestTitle = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButtonBHTest = new System.Windows.Forms.RadioButton();
            this.radioButtonBHLive = new System.Windows.Forms.RadioButton();
            this.IPServerButton = new System.Windows.Forms.Button();
            this.panelTestBuy = new System.Windows.Forms.Panel();
            this.panelCheckBH = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.InstructionButton = new System.Windows.Forms.Button();
            this.EditXMLButton = new System.Windows.Forms.Button();
            this.GenOSButton = new System.Windows.Forms.Button();
            this.CheckBHButton = new System.Windows.Forms.Button();
            this.TestBuyButton = new System.Windows.Forms.Button();
            this.panelInstruction = new System.Windows.Forms.Panel();
            this.InstrucTextBox = new System.Windows.Forms.RichTextBox();
            this.panelXMLDoc = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelTestBuy.SuspendLayout();
            this.panelCheckBH.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelInstruction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButtonCar);
            this.panel1.Controls.Add(this.radioButtonTrain);
            this.panel1.Controls.Add(this.radioButtonFerry);
            this.panel1.Controls.Add(this.radioButtonBus);
            this.panel1.Location = new System.Drawing.Point(31, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(87, 131);
            this.panel1.TabIndex = 0;
            // 
            // radioButtonCar
            // 
            this.radioButtonCar.AutoSize = true;
            this.radioButtonCar.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCar.Location = new System.Drawing.Point(19, 89);
            this.radioButtonCar.Name = "radioButtonCar";
            this.radioButtonCar.Size = new System.Drawing.Size(42, 19);
            this.radioButtonCar.TabIndex = 3;
            this.radioButtonCar.Text = "Car";
            this.radioButtonCar.UseVisualStyleBackColor = true;
            this.radioButtonCar.CheckedChanged += new System.EventHandler(this.productType);
            // 
            // radioButtonTrain
            // 
            this.radioButtonTrain.AutoSize = true;
            this.radioButtonTrain.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTrain.Location = new System.Drawing.Point(19, 66);
            this.radioButtonTrain.Name = "radioButtonTrain";
            this.radioButtonTrain.Size = new System.Drawing.Size(50, 19);
            this.radioButtonTrain.TabIndex = 2;
            this.radioButtonTrain.Text = "Train";
            this.radioButtonTrain.UseVisualStyleBackColor = true;
            this.radioButtonTrain.CheckedChanged += new System.EventHandler(this.productType);
            // 
            // radioButtonFerry
            // 
            this.radioButtonFerry.AutoSize = true;
            this.radioButtonFerry.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFerry.Location = new System.Drawing.Point(19, 43);
            this.radioButtonFerry.Name = "radioButtonFerry";
            this.radioButtonFerry.Size = new System.Drawing.Size(51, 19);
            this.radioButtonFerry.TabIndex = 1;
            this.radioButtonFerry.Text = "Ferry";
            this.radioButtonFerry.UseVisualStyleBackColor = true;
            this.radioButtonFerry.CheckedChanged += new System.EventHandler(this.productType);
            // 
            // radioButtonBus
            // 
            this.radioButtonBus.AutoSize = true;
            this.radioButtonBus.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBus.Location = new System.Drawing.Point(19, 20);
            this.radioButtonBus.Name = "radioButtonBus";
            this.radioButtonBus.Size = new System.Drawing.Size(44, 19);
            this.radioButtonBus.TabIndex = 0;
            this.radioButtonBus.Text = "Bus";
            this.radioButtonBus.UseVisualStyleBackColor = true;
            this.radioButtonBus.CheckedChanged += new System.EventHandler(this.productType);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButtonTest);
            this.panel2.Controls.Add(this.radioButtonLive);
            this.panel2.Location = new System.Drawing.Point(145, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(89, 83);
            this.panel2.TabIndex = 1;
            // 
            // radioButtonTest
            // 
            this.radioButtonTest.AutoSize = true;
            this.radioButtonTest.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTest.Location = new System.Drawing.Point(22, 43);
            this.radioButtonTest.Name = "radioButtonTest";
            this.radioButtonTest.Size = new System.Drawing.Size(45, 19);
            this.radioButtonTest.TabIndex = 1;
            this.radioButtonTest.Text = "Test";
            this.radioButtonTest.UseVisualStyleBackColor = true;
            this.radioButtonTest.CheckedChanged += new System.EventHandler(this.siteType);
            // 
            // radioButtonLive
            // 
            this.radioButtonLive.AutoSize = true;
            this.radioButtonLive.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLive.Location = new System.Drawing.Point(22, 18);
            this.radioButtonLive.Name = "radioButtonLive";
            this.radioButtonLive.Size = new System.Drawing.Size(46, 19);
            this.radioButtonLive.TabIndex = 0;
            this.radioButtonLive.Text = "Live";
            this.radioButtonLive.UseVisualStyleBackColor = true;
            this.radioButtonLive.CheckedChanged += new System.EventHandler(this.siteType);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.radioButtonPPSGD);
            this.panel4.Controls.Add(this.radioButtonPPMYR);
            this.panel4.Location = new System.Drawing.Point(261, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(89, 83);
            this.panel4.TabIndex = 5;
            // 
            // radioButtonPPSGD
            // 
            this.radioButtonPPSGD.AutoSize = true;
            this.radioButtonPPSGD.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPPSGD.Location = new System.Drawing.Point(19, 43);
            this.radioButtonPPSGD.Name = "radioButtonPPSGD";
            this.radioButtonPPSGD.Size = new System.Drawing.Size(47, 19);
            this.radioButtonPPSGD.TabIndex = 1;
            this.radioButtonPPSGD.Text = "SGD";
            this.radioButtonPPSGD.UseVisualStyleBackColor = true;
            this.radioButtonPPSGD.CheckedChanged += new System.EventHandler(this.paypalType);
            // 
            // radioButtonPPMYR
            // 
            this.radioButtonPPMYR.AutoSize = true;
            this.radioButtonPPMYR.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPPMYR.Location = new System.Drawing.Point(19, 20);
            this.radioButtonPPMYR.Name = "radioButtonPPMYR";
            this.radioButtonPPMYR.Size = new System.Drawing.Size(49, 19);
            this.radioButtonPPMYR.TabIndex = 0;
            this.radioButtonPPMYR.Text = "MYR";
            this.radioButtonPPMYR.UseVisualStyleBackColor = true;
            this.radioButtonPPMYR.CheckedChanged += new System.EventHandler(this.paypalType);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(145, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Run_Click);
            // 
            // EBTestTitle
            // 
            this.EBTestTitle.AutoSize = true;
            this.EBTestTitle.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EBTestTitle.Location = new System.Drawing.Point(246, 20);
            this.EBTestTitle.Name = "EBTestTitle";
            this.EBTestTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EBTestTitle.Size = new System.Drawing.Size(292, 34);
            this.EBTestTitle.TabIndex = 7;
            this.EBTestTitle.Text = "EasyBook Test Buy Automation";
            this.EBTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.radioButtonBHTest);
            this.panel5.Controls.Add(this.radioButtonBHLive);
            this.panel5.Location = new System.Drawing.Point(137, 75);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(96, 79);
            this.panel5.TabIndex = 2;
            // 
            // radioButtonBHTest
            // 
            this.radioButtonBHTest.AutoSize = true;
            this.radioButtonBHTest.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBHTest.Location = new System.Drawing.Point(22, 43);
            this.radioButtonBHTest.Name = "radioButtonBHTest";
            this.radioButtonBHTest.Size = new System.Drawing.Size(45, 19);
            this.radioButtonBHTest.TabIndex = 1;
            this.radioButtonBHTest.Text = "Test";
            this.radioButtonBHTest.UseVisualStyleBackColor = true;
            this.radioButtonBHTest.CheckedChanged += new System.EventHandler(this.siteName);
            // 
            // radioButtonBHLive
            // 
            this.radioButtonBHLive.AutoSize = true;
            this.radioButtonBHLive.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBHLive.Location = new System.Drawing.Point(21, 18);
            this.radioButtonBHLive.Name = "radioButtonBHLive";
            this.radioButtonBHLive.Size = new System.Drawing.Size(46, 19);
            this.radioButtonBHLive.TabIndex = 0;
            this.radioButtonBHLive.Text = "Live";
            this.radioButtonBHLive.UseVisualStyleBackColor = true;
            this.radioButtonBHLive.CheckedChanged += new System.EventHandler(this.siteName);
            // 
            // IPServerButton
            // 
            this.IPServerButton.BackColor = System.Drawing.Color.SkyBlue;
            this.IPServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IPServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPServerButton.Location = new System.Drawing.Point(124, 187);
            this.IPServerButton.Name = "IPServerButton";
            this.IPServerButton.Size = new System.Drawing.Size(124, 53);
            this.IPServerButton.TabIndex = 1;
            this.IPServerButton.Text = "Check Booking History";
            this.IPServerButton.UseVisualStyleBackColor = false;
            this.IPServerButton.Click += new System.EventHandler(this.IPServer_Click);
            // 
            // panelTestBuy
            // 
            this.panelTestBuy.Controls.Add(this.button1);
            this.panelTestBuy.Controls.Add(this.panel4);
            this.panelTestBuy.Controls.Add(this.panel2);
            this.panelTestBuy.Controls.Add(this.panel1);
            this.panelTestBuy.Location = new System.Drawing.Point(201, 85);
            this.panelTestBuy.Name = "panelTestBuy";
            this.panelTestBuy.Size = new System.Drawing.Size(371, 324);
            this.panelTestBuy.TabIndex = 8;
            // 
            // panelCheckBH
            // 
            this.panelCheckBH.Controls.Add(this.panel5);
            this.panelCheckBH.Controls.Add(this.IPServerButton);
            this.panelCheckBH.Controls.Add(this.panelXMLDoc);
            this.panelCheckBH.Location = new System.Drawing.Point(201, 82);
            this.panelCheckBH.Name = "panelCheckBH";
            this.panelCheckBH.Size = new System.Drawing.Size(371, 324);
            this.panelCheckBH.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkMagenta;
            this.panel3.Controls.Add(this.InstructionButton);
            this.panel3.Controls.Add(this.EditXMLButton);
            this.panel3.Controls.Add(this.GenOSButton);
            this.panel3.Controls.Add(this.CheckBHButton);
            this.panel3.Controls.Add(this.TestBuyButton);
            this.panel3.Location = new System.Drawing.Point(-3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 470);
            this.panel3.TabIndex = 3;
            // 
            // InstructionButton
            // 
            this.InstructionButton.Location = new System.Drawing.Point(25, 368);
            this.InstructionButton.Name = "InstructionButton";
            this.InstructionButton.Size = new System.Drawing.Size(137, 36);
            this.InstructionButton.TabIndex = 4;
            this.InstructionButton.Text = "Instruction";
            this.InstructionButton.UseVisualStyleBackColor = true;
            this.InstructionButton.Click += new System.EventHandler(this.InstructionButton_Click);
            // 
            // EditXMLButton
            // 
            this.EditXMLButton.Location = new System.Drawing.Point(25, 281);
            this.EditXMLButton.Name = "EditXMLButton";
            this.EditXMLButton.Size = new System.Drawing.Size(138, 36);
            this.EditXMLButton.TabIndex = 3;
            this.EditXMLButton.Text = "XML Documentation";
            this.EditXMLButton.UseVisualStyleBackColor = true;
            this.EditXMLButton.Click += new System.EventHandler(this.XMLDocButton_Click);
            // 
            // GenOSButton
            // 
            this.GenOSButton.Location = new System.Drawing.Point(25, 194);
            this.GenOSButton.Name = "GenOSButton";
            this.GenOSButton.Size = new System.Drawing.Size(138, 36);
            this.GenOSButton.TabIndex = 2;
            this.GenOSButton.Text = "Generate OS";
            this.GenOSButton.UseVisualStyleBackColor = true;
            // 
            // CheckBHButton
            // 
            this.CheckBHButton.Location = new System.Drawing.Point(25, 107);
            this.CheckBHButton.Name = "CheckBHButton";
            this.CheckBHButton.Size = new System.Drawing.Size(138, 36);
            this.CheckBHButton.TabIndex = 1;
            this.CheckBHButton.Text = "Check Booking History";
            this.CheckBHButton.UseVisualStyleBackColor = true;
            this.CheckBHButton.Click += new System.EventHandler(this.CheckBHButton_Click);
            // 
            // TestBuyButton
            // 
            this.TestBuyButton.Location = new System.Drawing.Point(24, 20);
            this.TestBuyButton.Name = "TestBuyButton";
            this.TestBuyButton.Size = new System.Drawing.Size(138, 36);
            this.TestBuyButton.TabIndex = 0;
            this.TestBuyButton.Text = "Test Buy";
            this.TestBuyButton.UseVisualStyleBackColor = true;
            this.TestBuyButton.Click += new System.EventHandler(this.TestBuyButton_Click);
            // 
            // panelInstruction
            // 
            this.panelInstruction.Controls.Add(this.InstrucTextBox);
            this.panelInstruction.Location = new System.Drawing.Point(204, 82);
            this.panelInstruction.Name = "panelInstruction";
            this.panelInstruction.Size = new System.Drawing.Size(379, 327);
            this.panelInstruction.TabIndex = 10;
            // 
            // InstrucTextBox
            // 
            this.InstrucTextBox.Location = new System.Drawing.Point(28, 25);
            this.InstrucTextBox.Name = "InstrucTextBox";
            this.InstrucTextBox.Size = new System.Drawing.Size(306, 289);
            this.InstrucTextBox.TabIndex = 1;
            this.InstrucTextBox.Text = "This is the guide to use the software.\n";
            // 
            // panelXMLDoc
            // 
            this.panelXMLDoc.Location = new System.Drawing.Point(0, 0);
            this.panelXMLDoc.Name = "panelXMLDoc";
            this.panelXMLDoc.Size = new System.Drawing.Size(379, 327);
            this.panelXMLDoc.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelCheckBH);
            this.Controls.Add(this.panelTestBuy);
            this.Controls.Add(this.EBTestTitle);
            this.Controls.Add(this.panelInstruction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelTestBuy.ResumeLayout(false);
            this.panelCheckBH.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelInstruction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonCar;
        private System.Windows.Forms.RadioButton radioButtonTrain;
        private System.Windows.Forms.RadioButton radioButtonFerry;
        private System.Windows.Forms.RadioButton radioButtonBus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonTest;
        private System.Windows.Forms.RadioButton radioButtonLive;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButtonPPSGD;
        private System.Windows.Forms.RadioButton radioButtonPPMYR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label EBTestTitle;
        private System.Windows.Forms.Button IPServerButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButtonBHTest;
        private System.Windows.Forms.RadioButton radioButtonBHLive;
        private System.Windows.Forms.Panel panelTestBuy;
        private System.Windows.Forms.Panel panelCheckBH;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button GenOSButton;
        private System.Windows.Forms.Button CheckBHButton;
        private System.Windows.Forms.Button TestBuyButton;
        private System.Windows.Forms.Button InstructionButton;
        private System.Windows.Forms.Button EditXMLButton;
        private System.Windows.Forms.Panel panelInstruction;
        private System.Windows.Forms.RichTextBox InstrucTextBox;
        private System.Windows.Forms.Panel panelXMLDoc;
    }
}

