namespace OnPlaceMovel.Source.Forms
{
    partial class FormMenu
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
			this.btnServicos = new System.Windows.Forms.Button();
			this.btnBD = new System.Windows.Forms.Button();
			this.btnColeta = new System.Windows.Forms.Button();
			this.btnEmissao = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnServicos
			// 
			this.btnServicos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.btnServicos.Location = new System.Drawing.Point(35, 114);
			this.btnServicos.Name = "btnServicos";
			this.btnServicos.Size = new System.Drawing.Size(170, 31);
			this.btnServicos.TabIndex = 3;
			this.btnServicos.Text = "&Serviços";
			this.btnServicos.Click += new System.EventHandler(this.btnServicos_Click);
			// 
			// btnBD
			// 
			this.btnBD.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.btnBD.Location = new System.Drawing.Point(35, 77);
			this.btnBD.Name = "btnBD";
			this.btnBD.Size = new System.Drawing.Size(170, 31);
			this.btnBD.TabIndex = 2;
			this.btnBD.Text = "&BD";
			this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
			// 
			// btnColeta
			// 
			this.btnColeta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.btnColeta.Location = new System.Drawing.Point(35, 40);
			this.btnColeta.Name = "btnColeta";
			this.btnColeta.Size = new System.Drawing.Size(170, 31);
			this.btnColeta.TabIndex = 1;
			this.btnColeta.Text = "&Coleta";
			this.btnColeta.Click += new System.EventHandler(this.btnColeta_Click);
			// 
			// btnEmissao
			// 
			this.btnEmissao.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.btnEmissao.Location = new System.Drawing.Point(34, 3);
			this.btnEmissao.Name = "btnEmissao";
			this.btnEmissao.Size = new System.Drawing.Size(170, 31);
			this.btnEmissao.TabIndex = 0;
			this.btnEmissao.Text = "&Emissão";
			this.btnEmissao.Click += new System.EventHandler(this.btnEmissao_Click);
			// 
			// FormMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.btnServicos);
			this.Controls.Add(this.btnBD);
			this.Controls.Add(this.btnColeta);
			this.Controls.Add(this.btnEmissao);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FormMenu";
			this.Text = "OnPlace";
			this.Activated += new System.EventHandler(this.MenuPrincipal_Activated);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMenu_KeyDown_1);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServicos;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.Button btnColeta;
		private System.Windows.Forms.Button btnEmissao;
    }
}