namespace OnPlaceMovel.Source.Forms
{
    partial class FormServicos
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
			this.tbMatricula = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbServicos = new System.Windows.Forms.ListBox();
			this.lbServicosCadastrados = new System.Windows.Forms.ListBox();
			this.btnGravar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.lblNome = new System.Windows.Forms.Label();
			this.lblEndereco = new System.Windows.Forms.Label();
			this.lblHidrometro = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.SuspendLayout();
			// 
			// tbMatricula
			// 
			this.tbMatricula.Location = new System.Drawing.Point(93, 3);
			this.tbMatricula.Name = "tbMatricula";
			this.tbMatricula.Size = new System.Drawing.Size(103, 21);
			this.tbMatricula.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 14);
			this.label1.Text = "N° da Matrícula";
			// 
			// lbServicos
			// 
			this.lbServicos.Enabled = false;
			this.lbServicos.Location = new System.Drawing.Point(3, 105);
			this.lbServicos.Name = "lbServicos";
			this.lbServicos.Size = new System.Drawing.Size(222, 72);
			this.lbServicos.TabIndex = 2;
			this.lbServicos.SelectedIndexChanged += new System.EventHandler(this.lbServicos_SelectedIndexChanged);
			// 
			// lbServicosCadastrados
			// 
			this.lbServicosCadastrados.Enabled = false;
			this.lbServicosCadastrados.Location = new System.Drawing.Point(3, 183);
			this.lbServicosCadastrados.Name = "lbServicosCadastrados";
			this.lbServicosCadastrados.Size = new System.Drawing.Size(222, 44);
			this.lbServicosCadastrados.TabIndex = 3;
			this.lbServicosCadastrados.SelectedIndexChanged += new System.EventHandler(this.lbServicosCadastrados_SelectedIndexChanged);
			// 
			// btnGravar
			// 
			this.btnGravar.Location = new System.Drawing.Point(72, 233);
			this.btnGravar.Name = "btnGravar";
			this.btnGravar.Size = new System.Drawing.Size(72, 19);
			this.btnGravar.TabIndex = 4;
			this.btnGravar.Text = "Gravar";
			this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(153, 233);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(72, 19);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "Sair";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(202, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = " ...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblNome
			// 
			this.lblNome.Location = new System.Drawing.Point(3, 27);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(222, 28);
			this.lblNome.Text = "Nome: ";
			// 
			// lblEndereco
			// 
			this.lblEndereco.Location = new System.Drawing.Point(3, 56);
			this.lblEndereco.Name = "lblEndereco";
			this.lblEndereco.Size = new System.Drawing.Size(222, 31);
			this.lblEndereco.Text = "Endereço: ";
			// 
			// lblHidrometro
			// 
			this.lblHidrometro.Location = new System.Drawing.Point(3, 88);
			this.lblHidrometro.Name = "lblHidrometro";
			this.lblHidrometro.Size = new System.Drawing.Size(222, 14);
			this.lblHidrometro.Text = "N° hidrômetro: ";
			// 
			// FormServicos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.lblHidrometro);
			this.Controls.Add(this.lblEndereco);
			this.Controls.Add(this.lblNome);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGravar);
			this.Controls.Add(this.lbServicosCadastrados);
			this.Controls.Add(this.lbServicos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbMatricula);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FormServicos";
			this.Text = "OnPlaceMovel - Serviços";
			this.Activated += new System.EventHandler(this.Servicos_Activated);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbServicos;
        private System.Windows.Forms.ListBox lbServicosCadastrados;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblHidrometro;
		private System.Windows.Forms.MainMenu mainMenu1;
    }
}