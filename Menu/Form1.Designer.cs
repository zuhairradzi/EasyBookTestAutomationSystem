namespace Menu
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.XMLDocTab = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDisplayXML = new System.Windows.Forms.Panel();
            this.TestXPLabel = new System.Windows.Forms.Label();
            this.XpathLabel = new System.Windows.Forms.Label();
            this.EditXML_Button = new System.Windows.Forms.Button();
            this.UpdateXMLButton = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panelEditXML = new System.Windows.Forms.Panel();
            this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.XMLEditTextbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panelDisplayXML.SuspendLayout();
            this.panelEditXML.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.XMLDocTab);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 462);
            this.panel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 290);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 89);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 89);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // XMLDocTab
            // 
            this.XMLDocTab.Location = new System.Drawing.Point(3, 100);
            this.XMLDocTab.Name = "XMLDocTab";
            this.XMLDocTab.Size = new System.Drawing.Size(168, 89);
            this.XMLDocTab.TabIndex = 1;
            this.XMLDocTab.Text = "XML Documentation";
            this.XMLDocTab.UseVisualStyleBackColor = true;
            this.XMLDocTab.Click += new System.EventHandler(this.XMLDocTab_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumOrchid;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(43, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 66);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelDisplayXML
            // 
            this.panelDisplayXML.AutoScroll = true;
            this.panelDisplayXML.BackColor = System.Drawing.Color.PapayaWhip;
            this.panelDisplayXML.Controls.Add(this.vScrollBar1);
            this.panelDisplayXML.Controls.Add(this.UpdateXMLButton);
            this.panelDisplayXML.Controls.Add(this.EditXML_Button);
            this.panelDisplayXML.Controls.Add(this.XpathLabel);
            this.panelDisplayXML.Controls.Add(this.TestXPLabel);
            this.panelDisplayXML.Location = new System.Drawing.Point(244, 58);
            this.panelDisplayXML.Name = "panelDisplayXML";
            this.panelDisplayXML.Size = new System.Drawing.Size(282, 306);
            this.panelDisplayXML.TabIndex = 1;
            // 
            // TestXPLabel
            // 
            this.TestXPLabel.AutoSize = true;
            this.TestXPLabel.Location = new System.Drawing.Point(47, 37);
            this.TestXPLabel.Name = "TestXPLabel";
            this.TestXPLabel.Size = new System.Drawing.Size(59, 13);
            this.TestXPLabel.TabIndex = 0;
            this.TestXPLabel.Text = "Test Xpath";
            // 
            // XpathLabel
            // 
            this.XpathLabel.AutoSize = true;
            this.XpathLabel.Location = new System.Drawing.Point(54, 59);
            this.XpathLabel.Name = "XpathLabel";
            this.XpathLabel.Size = new System.Drawing.Size(35, 13);
            this.XpathLabel.TabIndex = 1;
            this.XpathLabel.Text = "Xpath";
            // 
            // EditXML_Button
            // 
            this.EditXML_Button.Location = new System.Drawing.Point(38, 211);
            this.EditXML_Button.Name = "EditXML_Button";
            this.EditXML_Button.Size = new System.Drawing.Size(103, 58);
            this.EditXML_Button.TabIndex = 2;
            this.EditXML_Button.Text = "Edit";
            this.EditXML_Button.UseVisualStyleBackColor = true;
            this.EditXML_Button.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // UpdateXMLButton
            // 
            this.UpdateXMLButton.Location = new System.Drawing.Point(177, 211);
            this.UpdateXMLButton.Name = "UpdateXMLButton";
            this.UpdateXMLButton.Size = new System.Drawing.Size(95, 57);
            this.UpdateXMLButton.TabIndex = 3;
            this.UpdateXMLButton.Text = "Update";
            this.UpdateXMLButton.UseVisualStyleBackColor = true;
            this.UpdateXMLButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(263, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 208);
            this.vScrollBar1.TabIndex = 5;
            // 
            // panelEditXML
            // 
            this.panelEditXML.AutoScroll = true;
            this.panelEditXML.BackColor = System.Drawing.Color.PapayaWhip;
            this.panelEditXML.Controls.Add(this.XMLEditTextbox);
            this.panelEditXML.Controls.Add(this.vScrollBar3);
            this.panelEditXML.Controls.Add(this.UpdateButton);
            this.panelEditXML.Controls.Add(this.EditButton);
            this.panelEditXML.Controls.Add(this.label4);
            this.panelEditXML.Location = new System.Drawing.Point(244, 58);
            this.panelEditXML.Name = "panelEditXML";
            this.panelEditXML.Size = new System.Drawing.Size(282, 306);
            this.panelEditXML.TabIndex = 7;
            // 
            // vScrollBar3
            // 
            this.vScrollBar3.Location = new System.Drawing.Point(263, 0);
            this.vScrollBar3.Name = "vScrollBar3";
            this.vScrollBar3.Size = new System.Drawing.Size(19, 208);
            this.vScrollBar3.TabIndex = 5;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(177, 211);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(95, 57);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(38, 211);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(103, 58);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Test Xpath";
            // 
            // XMLEditTextbox
            // 
            this.XMLEditTextbox.Location = new System.Drawing.Point(53, 64);
            this.XMLEditTextbox.Name = "XMLEditTextbox";
            this.XMLEditTextbox.Size = new System.Drawing.Size(66, 20);
            this.XMLEditTextbox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(586, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDisplayXML);
            this.Controls.Add(this.panelEditXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panelDisplayXML.ResumeLayout(false);
            this.panelDisplayXML.PerformLayout();
            this.panelEditXML.ResumeLayout(false);
            this.panelEditXML.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button XMLDocTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelDisplayXML;
        private System.Windows.Forms.Button UpdateXMLButton;
        private System.Windows.Forms.Button EditXML_Button;
        private System.Windows.Forms.Label XpathLabel;
        private System.Windows.Forms.Label TestXPLabel;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panelEditXML;
        private System.Windows.Forms.TextBox XMLEditTextbox;
        private System.Windows.Forms.VScrollBar vScrollBar3;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label label4;
    }
}

