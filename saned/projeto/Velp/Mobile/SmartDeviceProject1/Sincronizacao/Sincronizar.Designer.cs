namespace DeviceProject.Sincronizacao
{
    partial class Sincronizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sincronizar));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.pbProgresso = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.ListBox();
            this.enviarBox = new System.Windows.Forms.RadioButton();
            this.ReceberBox = new System.Windows.Forms.RadioButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lusuario = new System.Windows.Forms.Label();
            this.ldVersao = new System.Windows.Forms.Label();
            this.ultraButton3 = new MobileTools.Controls.UltraButton();
            this.ultraButton2 = new MobileTools.Controls.UltraButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.Text = "Opções";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Sincronizar";
            this.menuItem2.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "OnPlace";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Sair";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // pbProgresso
            // 
            this.pbProgresso.Location = new System.Drawing.Point(12, 220);
            this.pbProgresso.Name = "pbProgresso";
            this.pbProgresso.Size = new System.Drawing.Size(215, 20);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(12, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 90);
            this.label1.TabIndex = 7;
            // 
            // enviarBox
            // 
            this.enviarBox.Location = new System.Drawing.Point(12, 52);
            this.enviarBox.Name = "enviarBox";
            this.enviarBox.Size = new System.Drawing.Size(100, 20);
            this.enviarBox.TabIndex = 20;
            this.enviarBox.Text = "Enviar Dados";
            this.enviarBox.Click += new System.EventHandler(this.enviarBox_CheckStateChanged);
            this.enviarBox.EnabledChanged += new System.EventHandler(this.enviarBox_CheckStateChanged);
            // 
            // ReceberBox
            // 
            this.ReceberBox.Location = new System.Drawing.Point(12, 76);
            this.ReceberBox.Name = "ReceberBox";
            this.ReceberBox.Size = new System.Drawing.Size(115, 20);
            this.ReceberBox.TabIndex = 21;
            this.ReceberBox.Text = "Receber Dados";
            this.ReceberBox.Click += new System.EventHandler(this.ReceberBox_CheckStateChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(12, 198);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(215, 20);
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lusuario
            // 
            this.lusuario.Location = new System.Drawing.Point(12, 8);
            this.lusuario.Name = "lusuario";
            this.lusuario.Size = new System.Drawing.Size(156, 28);
            this.lusuario.Text = "usuario";
            // 
            // ldVersao
            // 
            this.ldVersao.Location = new System.Drawing.Point(12, 247);
            this.ldVersao.Name = "ldVersao";
            this.ldVersao.Size = new System.Drawing.Size(215, 20);
            this.ldVersao.Text = "versão";
            this.ldVersao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ultraButton3
            // 
            this.ultraButton3.BorderColor = System.Drawing.Color.Transparent;
            this.ultraButton3.ButtonColor = System.Drawing.Color.White;
            this.ultraButton3.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ultraButton3.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ultraButton3.ImageButton")));
            this.ultraButton3.ImageButtonView = true;
            this.ultraButton3.Location = new System.Drawing.Point(133, 47);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Radius = 8;
            this.ultraButton3.Size = new System.Drawing.Size(50, 44);
            this.ultraButton3.TabIndex = 29;
            this.ultraButton3.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ultraButton3.TextColor = System.Drawing.SystemColors.WindowText;
            this.ultraButton3.TextColorClick = System.Drawing.Color.White;
            this.ultraButton3.Visible = false;
            // 
            // ultraButton2
            // 
            this.ultraButton2.BorderColor = System.Drawing.Color.Transparent;
            this.ultraButton2.ButtonColor = System.Drawing.Color.White;
            this.ultraButton2.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ultraButton2.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ultraButton2.ImageButton")));
            this.ultraButton2.ImageButtonView = true;
            this.ultraButton2.Location = new System.Drawing.Point(133, 51);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Radius = 8;
            this.ultraButton2.Size = new System.Drawing.Size(50, 44);
            this.ultraButton2.TabIndex = 25;
            this.ultraButton2.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ultraButton2.TextColor = System.Drawing.SystemColors.WindowText;
            this.ultraButton2.TextColorClick = System.Drawing.Color.White;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(189, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Sincronizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ldVersao);
            this.Controls.Add(this.ultraButton3);
            this.Controls.Add(this.lusuario);
            this.Controls.Add(this.ultraButton2);
            this.Controls.Add(this.ReceberBox);
            this.Controls.Add(this.enviarBox);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbProgresso);
            this.Menu = this.mainMenu1;
            this.Name = "Sincronizar";
            this.Text = "Sincronização";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgresso;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ListBox label1;
        private System.Windows.Forms.RadioButton enviarBox;
        private System.Windows.Forms.RadioButton ReceberBox;
        private System.Windows.Forms.Label lblMsg;
        private MobileTools.Controls.UltraButton ultraButton2;
        private System.Windows.Forms.Label lusuario;
        private MobileTools.Controls.UltraButton ultraButton3;
        private System.Windows.Forms.Label ldVersao;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

