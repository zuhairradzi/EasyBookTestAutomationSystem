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
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.radioButtonCar);
            this.panel1.Controls.Add(this.radioButtonTrain);
            this.panel1.Controls.Add(this.radioButtonFerry);
            this.panel1.Controls.Add(this.radioButtonBus);
            this.panel1.Location = new System.Drawing.Point(24, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 118);
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
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.radioButtonTest);
            this.panel2.Controls.Add(this.radioButtonLive);
            this.panel2.Location = new System.Drawing.Point(196, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 118);
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
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel4.Controls.Add(this.radioButtonPPSGD);
            this.panel4.Controls.Add(this.radioButtonPPMYR);
            this.panel4.Location = new System.Drawing.Point(369, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(129, 118);
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
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(196, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Run_Click);
            // 
            // EBTestTitle
            // 
            this.EBTestTitle.AutoSize = true;
            this.EBTestTitle.Font = new System.Drawing.Font("Myanmar Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EBTestTitle.Location = new System.Drawing.Point(111, 11);
            this.EBTestTitle.Name = "EBTestTitle";
            this.EBTestTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EBTestTitle.Size = new System.Drawing.Size(292, 34);
            this.EBTestTitle.TabIndex = 7;
            this.EBTestTitle.Text = "EasyBook Test Buy Automation";
            this.EBTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(520, 264);
            this.Controls.Add(this.EBTestTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
    }
}

