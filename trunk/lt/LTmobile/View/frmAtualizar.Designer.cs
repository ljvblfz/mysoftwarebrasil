namespace LTmobile
{
    partial class frmAtualizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.lblHeder = new System.Windows.Forms.Label();
            this.tlLogin = new MobileTools.Controls.Title();
            this.tmHoraAtual = new System.Windows.Forms.Timer();
            this.labelProgresso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Iniciar";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Sair";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // lblHeder
            // 
            this.lblHeder.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeder.Location = new System.Drawing.Point(15, 31);
            this.lblHeder.Name = "lblHeder";
            this.lblHeder.Size = new System.Drawing.Size(149, 31);
            this.lblHeder.Text = "Deseja iniciar atualização?";
            // 
            // tlLogin
            // 
            this.tlLogin.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlLogin.DistanceWordLine = 2;
            this.tlLogin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlLogin.HeightLine = 10;
            this.tlLogin.Location = new System.Drawing.Point(0, 0);
            this.tlLogin.Name = "tlLogin";
            this.tlLogin.Size = new System.Drawing.Size(224, 28);
            this.tlLogin.TabIndex = 11;
            this.tlLogin.Text = "Atualizar";
            this.tlLogin.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlLogin.WidthInclination = 10;
            // 
            // labelProgresso
            // 
            this.labelProgresso.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelProgresso.Location = new System.Drawing.Point(15, 71);
            this.labelProgresso.Name = "labelProgresso";
            this.labelProgresso.Size = new System.Drawing.Size(149, 81);
            // 
            // frmAtualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.labelProgresso);
            this.Controls.Add(this.lblHeder);
            this.Controls.Add(this.tlLogin);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmAtualizar";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlLogin;
        private System.Windows.Forms.Label lblHeder;
        private System.Windows.Forms.Timer tmHoraAtual;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label labelProgresso;

    }
}

