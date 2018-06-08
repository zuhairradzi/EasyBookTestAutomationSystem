namespace EBTestGUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EBTestTitle = new System.Windows.Forms.Label();
            this.buttonBypass = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumVioletRed;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(311, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 250);
            this.panel1.TabIndex = 0;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Plum;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogin.Font = new System.Drawing.Font("Cambria", 10F);
            this.buttonLogin.Location = new System.Drawing.Point(32, 195);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(180, 35);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightYellow;
            this.panel4.Controls.Add(this.passwordTextBox);
            this.panel4.Location = new System.Drawing.Point(32, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(181, 55);
            this.panel4.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.passwordTextBox.Location = new System.Drawing.Point(13, 18);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(160, 24);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextBox_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightYellow;
            this.panel3.Controls.Add(this.emailTextBox);
            this.panel3.Location = new System.Drawing.Point(32, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 55);
            this.panel3.TabIndex = 0;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.ForeColor = System.Drawing.Color.Gray;
            this.emailTextBox.Location = new System.Drawing.Point(13, 14);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(160, 24);
            this.emailTextBox.TabIndex = 0;
            this.emailTextBox.Text = "Email";
            this.emailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.emailTextBox.Click += new System.EventHandler(this.emailTextBox_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkMagenta;
            this.panel2.Location = new System.Drawing.Point(0, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 470);
            this.panel2.TabIndex = 1;
            // 
            // EBTestTitle
            // 
            this.EBTestTitle.AutoSize = true;
            this.EBTestTitle.Font = new System.Drawing.Font("Bebas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EBTestTitle.Location = new System.Drawing.Point(306, 20);
            this.EBTestTitle.Name = "EBTestTitle";
            this.EBTestTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EBTestTitle.Size = new System.Drawing.Size(260, 28);
            this.EBTestTitle.TabIndex = 8;
            this.EBTestTitle.Text = "EasyBook Test Automation";
            this.EBTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBypass
            // 
            this.buttonBypass.Location = new System.Drawing.Point(379, 320);
            this.buttonBypass.Name = "buttonBypass";
            this.buttonBypass.Size = new System.Drawing.Size(102, 58);
            this.buttonBypass.TabIndex = 9;
            this.buttonBypass.Text = "Bypass Login";
            this.buttonBypass.UseVisualStyleBackColor = true;
            this.buttonBypass.Visible = false;
            this.buttonBypass.Click += new System.EventHandler(this.buttonBypass_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonBypass);
            this.Controls.Add(this.EBTestTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label EBTestTitle;
        private System.Windows.Forms.Button buttonBypass;
    }
}