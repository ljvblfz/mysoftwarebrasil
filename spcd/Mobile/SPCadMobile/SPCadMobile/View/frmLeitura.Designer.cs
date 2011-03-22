namespace SPCadMobile.View
{
    partial class frmLeitura : CustomForm
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxDisplay = new System.Windows.Forms.TextBox();
            this.btnN7 = new System.Windows.Forms.Button();
            this.btnN8 = new System.Windows.Forms.Button();
            this.btnN9 = new System.Windows.Forms.Button();
            this.btnN6 = new System.Windows.Forms.Button();
            this.btnN5 = new System.Windows.Forms.Button();
            this.btnN4 = new System.Windows.Forms.Button();
            this.btnN3 = new System.Windows.Forms.Button();
            this.btnN2 = new System.Windows.Forms.Button();
            this.btnN1 = new System.Windows.Forms.Button();
            this.btnBackSpace = new System.Windows.Forms.Button();
            this.btnN0 = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Ok";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // chkConfirmado
            // 
            this.chkConfirmado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // lblAlterado
            // 
            this.lblAlterado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnBackSpace);
            this.panel.Controls.Add(this.btnN0);
            this.panel.Controls.Add(this.btnLimpar);
            this.panel.Controls.Add(this.btnN3);
            this.panel.Controls.Add(this.btnN2);
            this.panel.Controls.Add(this.btnN1);
            this.panel.Controls.Add(this.btnN6);
            this.panel.Controls.Add(this.btnN5);
            this.panel.Controls.Add(this.btnN4);
            this.panel.Controls.Add(this.btnN9);
            this.panel.Controls.Add(this.btnN8);
            this.panel.Controls.Add(this.btnN7);
            this.panel.Controls.Add(this.tbxDisplay);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Leitura";
            // 
            // tbxDisplay
            // 
            this.tbxDisplay.Font = new System.Drawing.Font("Tahoma", 23F, System.Drawing.FontStyle.Bold);
            this.tbxDisplay.Location = new System.Drawing.Point(13, 3);
            this.tbxDisplay.MaxLength = 9;
            this.tbxDisplay.Name = "tbxDisplay";
            this.tbxDisplay.Size = new System.Drawing.Size(216, 44);
            this.tbxDisplay.TabIndex = 0;
            this.tbxDisplay.TextChanged += new System.EventHandler(this.tbxDisplay_TextChanged);
            // 
            // btnN7
            // 
            this.btnN7.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN7.Location = new System.Drawing.Point(13, 67);
            this.btnN7.Name = "btnN7";
            this.btnN7.Size = new System.Drawing.Size(56, 38);
            this.btnN7.TabIndex = 1;
            this.btnN7.Text = "7";
            this.btnN7.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN8
            // 
            this.btnN8.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN8.Location = new System.Drawing.Point(93, 67);
            this.btnN8.Name = "btnN8";
            this.btnN8.Size = new System.Drawing.Size(56, 38);
            this.btnN8.TabIndex = 2;
            this.btnN8.Text = "8";
            this.btnN8.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN9
            // 
            this.btnN9.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN9.Location = new System.Drawing.Point(173, 67);
            this.btnN9.Name = "btnN9";
            this.btnN9.Size = new System.Drawing.Size(56, 38);
            this.btnN9.TabIndex = 3;
            this.btnN9.Text = "9";
            this.btnN9.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN6
            // 
            this.btnN6.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN6.Location = new System.Drawing.Point(173, 111);
            this.btnN6.Name = "btnN6";
            this.btnN6.Size = new System.Drawing.Size(56, 38);
            this.btnN6.TabIndex = 6;
            this.btnN6.Text = "6";
            this.btnN6.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN5
            // 
            this.btnN5.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN5.Location = new System.Drawing.Point(93, 111);
            this.btnN5.Name = "btnN5";
            this.btnN5.Size = new System.Drawing.Size(56, 38);
            this.btnN5.TabIndex = 5;
            this.btnN5.Text = "5";
            this.btnN5.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN4
            // 
            this.btnN4.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN4.Location = new System.Drawing.Point(13, 111);
            this.btnN4.Name = "btnN4";
            this.btnN4.Size = new System.Drawing.Size(56, 38);
            this.btnN4.TabIndex = 4;
            this.btnN4.Text = "4";
            this.btnN4.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN3
            // 
            this.btnN3.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN3.Location = new System.Drawing.Point(173, 155);
            this.btnN3.Name = "btnN3";
            this.btnN3.Size = new System.Drawing.Size(56, 38);
            this.btnN3.TabIndex = 9;
            this.btnN3.Text = "3";
            this.btnN3.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN2
            // 
            this.btnN2.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN2.Location = new System.Drawing.Point(93, 155);
            this.btnN2.Name = "btnN2";
            this.btnN2.Size = new System.Drawing.Size(56, 38);
            this.btnN2.TabIndex = 8;
            this.btnN2.Text = "2";
            this.btnN2.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnN1
            // 
            this.btnN1.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN1.Location = new System.Drawing.Point(13, 155);
            this.btnN1.Name = "btnN1";
            this.btnN1.Size = new System.Drawing.Size(56, 38);
            this.btnN1.TabIndex = 7;
            this.btnN1.Text = "1";
            this.btnN1.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btnBackSpace.Location = new System.Drawing.Point(173, 199);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(56, 38);
            this.btnBackSpace.TabIndex = 12;
            this.btnBackSpace.Text = "<#";
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
            // 
            // btnN0
            // 
            this.btnN0.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnN0.Location = new System.Drawing.Point(93, 199);
            this.btnN0.Name = "btnN0";
            this.btnN0.Size = new System.Drawing.Size(56, 38);
            this.btnN0.TabIndex = 11;
            this.btnN0.Text = "0";
            this.btnN0.Click += new System.EventHandler(this.btnN0_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.Location = new System.Drawing.Point(13, 199);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(56, 38);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "L";
            this.btnLimpar.Click += new System.EventHandler(this.button12_Click);
            // 
            // frmLeitura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLeitura";
            this.Text = "Leitura";
            this.Title = "Leitura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDisplay;
        private System.Windows.Forms.Button btnBackSpace;
        private System.Windows.Forms.Button btnN0;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnN3;
        private System.Windows.Forms.Button btnN2;
        private System.Windows.Forms.Button btnN1;
        private System.Windows.Forms.Button btnN6;
        private System.Windows.Forms.Button btnN5;
        private System.Windows.Forms.Button btnN4;
        private System.Windows.Forms.Button btnN9;
        private System.Windows.Forms.Button btnN8;
        private System.Windows.Forms.Button btnN7;
    }
}
