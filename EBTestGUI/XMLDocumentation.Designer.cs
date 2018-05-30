namespace EBTestGUI
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.panelSideTab = new System.Windows.Forms.Panel();
            this.InstructionButton = new System.Windows.Forms.Button();
            this.EditXMLButton = new System.Windows.Forms.Button();
            this.GenOSButton = new System.Windows.Forms.Button();
            this.CheckBHButton = new System.Windows.Forms.Button();
            this.TestBuyButton = new System.Windows.Forms.Button();
            this.EBTestTitle = new System.Windows.Forms.Label();
            this.panelClassifyBar = new System.Windows.Forms.Panel();
            this.ProductComboBox = new System.Windows.Forms.ComboBox();
            this.panelXML1 = new System.Windows.Forms.Panel();
            this.SiteComboBox = new System.Windows.Forms.ComboBox();
            this.panelComboSearch = new System.Windows.Forms.Panel();
            this.CurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.GetXMLButton = new System.Windows.Forms.Button();
            this.panelSideTab.SuspendLayout();
            this.panelComboSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideTab
            // 
            this.panelSideTab.BackColor = System.Drawing.Color.DarkMagenta;
            this.panelSideTab.Controls.Add(this.InstructionButton);
            this.panelSideTab.Controls.Add(this.EditXMLButton);
            this.panelSideTab.Controls.Add(this.GenOSButton);
            this.panelSideTab.Controls.Add(this.CheckBHButton);
            this.panelSideTab.Controls.Add(this.TestBuyButton);
            this.panelSideTab.Location = new System.Drawing.Point(-3, 0);
            this.panelSideTab.Name = "panelSideTab";
            this.panelSideTab.Size = new System.Drawing.Size(180, 470);
            this.panelSideTab.TabIndex = 4;
            // 
            // InstructionButton
            // 
            this.InstructionButton.Location = new System.Drawing.Point(24, 20);
            this.InstructionButton.Name = "InstructionButton";
            this.InstructionButton.Size = new System.Drawing.Size(137, 36);
            this.InstructionButton.TabIndex = 4;
            this.InstructionButton.Text = "Instruction";
            this.InstructionButton.UseVisualStyleBackColor = true;
            this.InstructionButton.Click += new System.EventHandler(this.InstructionButton_Click);
            // 
            // EditXMLButton
            // 
            this.EditXMLButton.Location = new System.Drawing.Point(24, 223);
            this.EditXMLButton.Name = "EditXMLButton";
            this.EditXMLButton.Size = new System.Drawing.Size(137, 36);
            this.EditXMLButton.TabIndex = 3;
            this.EditXMLButton.Text = "XML Documentation";
            this.EditXMLButton.UseVisualStyleBackColor = true;
            // 
            // GenOSButton
            // 
            this.GenOSButton.Location = new System.Drawing.Point(24, 120);
            this.GenOSButton.Name = "GenOSButton";
            this.GenOSButton.Size = new System.Drawing.Size(138, 36);
            this.GenOSButton.TabIndex = 2;
            this.GenOSButton.Text = "Generate OS";
            this.GenOSButton.UseVisualStyleBackColor = true;
            this.GenOSButton.Click += new System.EventHandler(this.GenerateOSTab_Click);
            // 
            // CheckBHButton
            // 
            this.CheckBHButton.Location = new System.Drawing.Point(24, 171);
            this.CheckBHButton.Name = "CheckBHButton";
            this.CheckBHButton.Size = new System.Drawing.Size(138, 36);
            this.CheckBHButton.TabIndex = 1;
            this.CheckBHButton.Text = "Check Booking History";
            this.CheckBHButton.UseVisualStyleBackColor = true;
            this.CheckBHButton.Click += new System.EventHandler(this.CheckBHButton_Click);
            // 
            // TestBuyButton
            // 
            this.TestBuyButton.Location = new System.Drawing.Point(24, 71);
            this.TestBuyButton.Name = "TestBuyButton";
            this.TestBuyButton.Size = new System.Drawing.Size(138, 36);
            this.TestBuyButton.TabIndex = 0;
            this.TestBuyButton.Text = "Test Buy";
            this.TestBuyButton.UseVisualStyleBackColor = true;
            this.TestBuyButton.Click += new System.EventHandler(this.TestBuyButton_Click);
            // 
            // EBTestTitle
            // 
            this.EBTestTitle.AutoSize = true;
            this.EBTestTitle.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EBTestTitle.Location = new System.Drawing.Point(275, 20);
            this.EBTestTitle.Name = "EBTestTitle";
            this.EBTestTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EBTestTitle.Size = new System.Drawing.Size(292, 34);
            this.EBTestTitle.TabIndex = 8;
            this.EBTestTitle.Text = "EasyBook Test Buy Automation";
            this.EBTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelClassifyBar
            // 
            this.panelClassifyBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelClassifyBar.Location = new System.Drawing.Point(230, 400);
            this.panelClassifyBar.Name = "panelClassifyBar";
            this.panelClassifyBar.Size = new System.Drawing.Size(510, 60);
            this.panelClassifyBar.TabIndex = 9;
            // 
            // ProductComboBox
            // 
            this.ProductComboBox.FormattingEnabled = true;
            this.ProductComboBox.Location = new System.Drawing.Point(7, 9);
            this.ProductComboBox.Name = "ProductComboBox";
            this.ProductComboBox.Size = new System.Drawing.Size(90, 21);
            this.ProductComboBox.TabIndex = 0;
            // 
            // panelXML1
            // 
            this.panelXML1.BackColor = System.Drawing.Color.LightGray;
            this.panelXML1.Location = new System.Drawing.Point(240, 60);
            this.panelXML1.Name = "panelXML1";
            this.panelXML1.Size = new System.Drawing.Size(380, 330);
            this.panelXML1.TabIndex = 10;
            // 
            // SiteComboBox
            // 
            this.SiteComboBox.FormattingEnabled = true;
            this.SiteComboBox.Location = new System.Drawing.Point(7, 56);
            this.SiteComboBox.Name = "SiteComboBox";
            this.SiteComboBox.Size = new System.Drawing.Size(89, 21);
            this.SiteComboBox.TabIndex = 11;
            // 
            // panelComboSearch
            // 
            this.panelComboSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelComboSearch.Controls.Add(this.GetXMLButton);
            this.panelComboSearch.Controls.Add(this.CurrencyComboBox);
            this.panelComboSearch.Controls.Add(this.SiteComboBox);
            this.panelComboSearch.Controls.Add(this.ProductComboBox);
            this.panelComboSearch.Location = new System.Drawing.Point(644, 60);
            this.panelComboSearch.Name = "panelComboSearch";
            this.panelComboSearch.Size = new System.Drawing.Size(110, 319);
            this.panelComboSearch.TabIndex = 12;
            // 
            // CurrencyComboBox
            // 
            this.CurrencyComboBox.FormattingEnabled = true;
            this.CurrencyComboBox.Location = new System.Drawing.Point(7, 104);
            this.CurrencyComboBox.Name = "CurrencyComboBox";
            this.CurrencyComboBox.Size = new System.Drawing.Size(90, 21);
            this.CurrencyComboBox.TabIndex = 12;
            // 
            // GetXMLButton
            // 
            this.GetXMLButton.Location = new System.Drawing.Point(15, 165);
            this.GetXMLButton.Name = "GetXMLButton";
            this.GetXMLButton.Size = new System.Drawing.Size(80, 56);
            this.GetXMLButton.TabIndex = 13;
            this.GetXMLButton.Text = "Get XML";
            this.GetXMLButton.UseVisualStyleBackColor = true;
            this.GetXMLButton.Click += new System.EventHandler(this.GetXMLButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panelComboSearch);
            this.Controls.Add(this.panelXML1);
            this.Controls.Add(this.panelClassifyBar);
            this.Controls.Add(this.EBTestTitle);
            this.Controls.Add(this.panelSideTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easybook Test Automation";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panelSideTab.ResumeLayout(false);
            this.panelComboSearch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSideTab;
        private System.Windows.Forms.Button InstructionButton;
        private System.Windows.Forms.Button EditXMLButton;
        private System.Windows.Forms.Button GenOSButton;
        private System.Windows.Forms.Button CheckBHButton;
        private System.Windows.Forms.Button TestBuyButton;
        private System.Windows.Forms.Label EBTestTitle;
        private System.Windows.Forms.Panel panelClassifyBar;
        private System.Windows.Forms.ComboBox ProductComboBox;
        private System.Windows.Forms.Panel panelXML1;
        private System.Windows.Forms.ComboBox SiteComboBox;
        private System.Windows.Forms.Panel panelComboSearch;
        private System.Windows.Forms.ComboBox CurrencyComboBox;
        private System.Windows.Forms.Button GetXMLButton;
    }
}