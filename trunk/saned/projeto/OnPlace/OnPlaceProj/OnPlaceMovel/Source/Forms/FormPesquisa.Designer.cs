namespace OnPlaceMovel.Source.Forms {
	partial class FormPesquisa {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBusca = new System.Windows.Forms.TabPage();
            this.btnBuscaLeitura = new System.Windows.Forms.Button();
            this.lblLeiNaoEncontrado = new System.Windows.Forms.Label();
            this.txtLeitura = new System.Windows.Forms.TextBox();
            this.lblBuscaLeitura = new System.Windows.Forms.Label();
            this.btnBuscaCancelar = new System.Windows.Forms.Button();
            this.lblMatNaoEcontrada = new System.Windows.Forms.Label();
            this.txtHidrometro = new System.Windows.Forms.TextBox();
            this.lblBuscaHidrometro = new System.Windows.Forms.Label();
            this.btnBuscaHidrometro = new System.Windows.Forms.Button();
            this.lblHidNaoEncontrado = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblBuscaMatricula = new System.Windows.Forms.Label();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.tabResultado = new System.Windows.Forms.TabPage();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnResultadoCancelar = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblLogradouro = new System.Windows.Forms.Label();
            this.lblDtHrColeta = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.chkProcessado = new System.Windows.Forms.CheckBox();
            this.lblDtHrColetaFixo = new System.Windows.Forms.Label();
            this.lnlMatriculaFixo = new System.Windows.Forms.Label();
            this.lblNomeFixo = new System.Windows.Forms.Label();
            this.timerEsconder = new System.Windows.Forms.Timer();
            this.tabControl.SuspendLayout();
            this.tabBusca.SuspendLayout();
            this.tabResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBusca);
            this.tabControl.Controls.Add(this.tabResultado);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 268);
            this.tabControl.TabIndex = 0;
            // 
            // tabBusca
            // 
            this.tabBusca.Controls.Add(this.btnBuscaLeitura);
            this.tabBusca.Controls.Add(this.lblLeiNaoEncontrado);
            this.tabBusca.Controls.Add(this.txtLeitura);
            this.tabBusca.Controls.Add(this.lblBuscaLeitura);
            this.tabBusca.Controls.Add(this.btnBuscaCancelar);
            this.tabBusca.Controls.Add(this.lblMatNaoEcontrada);
            this.tabBusca.Controls.Add(this.txtHidrometro);
            this.tabBusca.Controls.Add(this.lblBuscaHidrometro);
            this.tabBusca.Controls.Add(this.btnBuscaHidrometro);
            this.tabBusca.Controls.Add(this.lblHidNaoEncontrado);
            this.tabBusca.Controls.Add(this.txtMatricula);
            this.tabBusca.Controls.Add(this.lblBuscaMatricula);
            this.tabBusca.Controls.Add(this.btnBuscarMatricula);
            this.tabBusca.Location = new System.Drawing.Point(0, 0);
            this.tabBusca.Name = "tabBusca";
            this.tabBusca.Size = new System.Drawing.Size(240, 245);
            this.tabBusca.Text = "Busca";
            // 
            // btnBuscaLeitura
            // 
            this.btnBuscaLeitura.Location = new System.Drawing.Point(152, 164);
            this.btnBuscaLeitura.Name = "btnBuscaLeitura";
            this.btnBuscaLeitura.Size = new System.Drawing.Size(84, 20);
            this.btnBuscaLeitura.TabIndex = 5;
            this.btnBuscaLeitura.Text = "Buscar";
            this.btnBuscaLeitura.Click += new System.EventHandler(this.btnBuscaLeitura_Click);
            // 
            // lblLeiNaoEncontrado
            // 
            this.lblLeiNaoEncontrado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblLeiNaoEncontrado.ForeColor = System.Drawing.Color.Red;
            this.lblLeiNaoEncontrado.Location = new System.Drawing.Point(25, 164);
            this.lblLeiNaoEncontrado.Name = "lblLeiNaoEncontrado";
            this.lblLeiNaoEncontrado.Size = new System.Drawing.Size(121, 20);
            this.lblLeiNaoEncontrado.Text = "Não encontrado";
            this.lblLeiNaoEncontrado.Visible = false;
            // 
            // txtLeitura
            // 
            this.txtLeitura.Location = new System.Drawing.Point(82, 140);
            this.txtLeitura.MaxLength = 7;
            this.txtLeitura.Name = "txtLeitura";
            this.txtLeitura.Size = new System.Drawing.Size(154, 21);
            this.txtLeitura.TabIndex = 4;
            this.txtLeitura.TextChanged += new System.EventHandler(this.txtLeitura_TextChanged);
            // 
            // lblBuscaLeitura
            // 
            this.lblBuscaLeitura.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaLeitura.Location = new System.Drawing.Point(4, 140);
            this.lblBuscaLeitura.Name = "lblBuscaLeitura";
            this.lblBuscaLeitura.Size = new System.Drawing.Size(80, 20);
            this.lblBuscaLeitura.Text = "Sequência:";
            this.lblBuscaLeitura.ParentChanged += new System.EventHandler(this.lblBuscaLeitura_ParentChanged);
            // 
            // btnBuscaCancelar
            // 
            this.btnBuscaCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBuscaCancelar.Location = new System.Drawing.Point(149, 222);
            this.btnBuscaCancelar.Name = "btnBuscaCancelar";
            this.btnBuscaCancelar.Size = new System.Drawing.Size(84, 20);
            this.btnBuscaCancelar.TabIndex = 6;
            this.btnBuscaCancelar.Text = "Cancelar";
            // 
            // lblMatNaoEcontrada
            // 
            this.lblMatNaoEcontrada.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblMatNaoEcontrada.ForeColor = System.Drawing.Color.Red;
            this.lblMatNaoEcontrada.Location = new System.Drawing.Point(26, 32);
            this.lblMatNaoEcontrada.Name = "lblMatNaoEcontrada";
            this.lblMatNaoEcontrada.Size = new System.Drawing.Size(121, 20);
            this.lblMatNaoEcontrada.Text = "Não encontrado";
            this.lblMatNaoEcontrada.Visible = false;
            // 
            // txtHidrometro
            // 
            this.txtHidrometro.Location = new System.Drawing.Point(82, 73);
            this.txtHidrometro.MaxLength = 12;
            this.txtHidrometro.Name = "txtHidrometro";
            this.txtHidrometro.Size = new System.Drawing.Size(154, 21);
            this.txtHidrometro.TabIndex = 2;
            this.txtHidrometro.TextChanged += new System.EventHandler(this.txtHidrometro_TextChanged);
            // 
            // lblBuscaHidrometro
            // 
            this.lblBuscaHidrometro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaHidrometro.Location = new System.Drawing.Point(4, 75);
            this.lblBuscaHidrometro.Name = "lblBuscaHidrometro";
            this.lblBuscaHidrometro.Size = new System.Drawing.Size(84, 20);
            this.lblBuscaHidrometro.Text = "Hidrometro:";
            // 
            // btnBuscaHidrometro
            // 
            this.btnBuscaHidrometro.Location = new System.Drawing.Point(152, 99);
            this.btnBuscaHidrometro.Name = "btnBuscaHidrometro";
            this.btnBuscaHidrometro.Size = new System.Drawing.Size(84, 20);
            this.btnBuscaHidrometro.TabIndex = 3;
            this.btnBuscaHidrometro.Text = "Buscar";
            this.btnBuscaHidrometro.Click += new System.EventHandler(this.btnBuscaHidrometro_Click);
            // 
            // lblHidNaoEncontrado
            // 
            this.lblHidNaoEncontrado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblHidNaoEncontrado.ForeColor = System.Drawing.Color.Red;
            this.lblHidNaoEncontrado.Location = new System.Drawing.Point(25, 99);
            this.lblHidNaoEncontrado.Name = "lblHidNaoEncontrado";
            this.lblHidNaoEncontrado.Size = new System.Drawing.Size(121, 20);
            this.lblHidNaoEncontrado.Text = "Não encontrado";
            this.lblHidNaoEncontrado.Visible = false;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(82, 7);
            this.txtMatricula.MaxLength = 9;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(154, 21);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
            // 
            // lblBuscaMatricula
            // 
            this.lblBuscaMatricula.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaMatricula.Location = new System.Drawing.Point(4, 8);
            this.lblBuscaMatricula.Name = "lblBuscaMatricula";
            this.lblBuscaMatricula.Size = new System.Drawing.Size(84, 20);
            this.lblBuscaMatricula.Text = "N. Conta:";
            // 
            // btnBuscarMatricula
            // 
            this.btnBuscarMatricula.Location = new System.Drawing.Point(152, 32);
            this.btnBuscarMatricula.Name = "btnBuscarMatricula";
            this.btnBuscarMatricula.Size = new System.Drawing.Size(84, 20);
            this.btnBuscarMatricula.TabIndex = 1;
            this.btnBuscarMatricula.Text = "Buscar";
            this.btnBuscarMatricula.Click += new System.EventHandler(this.btnBuscarMatricula_Click);
            // 
            // tabResultado
            // 
            this.tabResultado.Controls.Add(this.btnSelecionar);
            this.tabResultado.Controls.Add(this.btnResultadoCancelar);
            this.tabResultado.Controls.Add(this.lblMsg);
            this.tabResultado.Controls.Add(this.lblLogradouro);
            this.tabResultado.Controls.Add(this.lblDtHrColeta);
            this.tabResultado.Controls.Add(this.lblMatricula);
            this.tabResultado.Controls.Add(this.lblNome);
            this.tabResultado.Controls.Add(this.chkProcessado);
            this.tabResultado.Controls.Add(this.lblDtHrColetaFixo);
            this.tabResultado.Controls.Add(this.lnlMatriculaFixo);
            this.tabResultado.Controls.Add(this.lblNomeFixo);
            this.tabResultado.Location = new System.Drawing.Point(0, 0);
            this.tabResultado.Name = "tabResultado";
            this.tabResultado.Size = new System.Drawing.Size(240, 245);
            this.tabResultado.Text = "Resultado";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelecionar.Location = new System.Drawing.Point(63, 222);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(84, 20);
            this.btnSelecionar.TabIndex = 1;
            this.btnSelecionar.Text = "Selecionar";
            // 
            // btnResultadoCancelar
            // 
            this.btnResultadoCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnResultadoCancelar.Location = new System.Drawing.Point(153, 222);
            this.btnResultadoCancelar.Name = "btnResultadoCancelar";
            this.btnResultadoCancelar.Size = new System.Drawing.Size(84, 20);
            this.btnResultadoCancelar.TabIndex = 2;
            this.btnResultadoCancelar.Text = "Cancelar";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(109, 118);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(128, 16);
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMsg.Visible = false;
            // 
            // lblLogradouro
            // 
            this.lblLogradouro.Location = new System.Drawing.Point(3, 49);
            this.lblLogradouro.Name = "lblLogradouro";
            this.lblLogradouro.Size = new System.Drawing.Size(234, 55);
            this.lblLogradouro.Text = "Logradouro";
            // 
            // lblDtHrColeta
            // 
            this.lblDtHrColeta.Location = new System.Drawing.Point(115, 104);
            this.lblDtHrColeta.Name = "lblDtHrColeta";
            this.lblDtHrColeta.Size = new System.Drawing.Size(122, 14);
            this.lblDtHrColeta.Text = "DataColeta";
            // 
            // lblMatricula
            // 
            this.lblMatricula.Location = new System.Drawing.Point(86, 34);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(151, 15);
            this.lblMatricula.Text = "Número da matrícula";
            // 
            // lblNome
            // 
            this.lblNome.Location = new System.Drawing.Point(44, 4);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(193, 29);
            this.lblNome.Text = "Nome do cliente";
            // 
            // chkProcessado
            // 
            this.chkProcessado.Enabled = false;
            this.chkProcessado.Location = new System.Drawing.Point(3, 121);
            this.chkProcessado.Name = "chkProcessado";
            this.chkProcessado.Size = new System.Drawing.Size(100, 15);
            this.chkProcessado.TabIndex = 0;
            this.chkProcessado.Text = "Processado";
            // 
            // lblDtHrColetaFixo
            // 
            this.lblDtHrColetaFixo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtHrColetaFixo.Location = new System.Drawing.Point(3, 104);
            this.lblDtHrColetaFixo.Name = "lblDtHrColetaFixo";
            this.lblDtHrColetaFixo.Size = new System.Drawing.Size(118, 14);
            this.lblDtHrColetaFixo.Text = "Data/Hora Coleta: ";
            // 
            // lnlMatriculaFixo
            // 
            this.lnlMatriculaFixo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lnlMatriculaFixo.Location = new System.Drawing.Point(3, 34);
            this.lnlMatriculaFixo.Name = "lnlMatriculaFixo";
            this.lnlMatriculaFixo.Size = new System.Drawing.Size(100, 15);
            this.lnlMatriculaFixo.Text = "N° Matrícula: ";
            // 
            // lblNomeFixo
            // 
            this.lblNomeFixo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblNomeFixo.Location = new System.Drawing.Point(3, 4);
            this.lblNomeFixo.Name = "lblNomeFixo";
            this.lblNomeFixo.Size = new System.Drawing.Size(52, 16);
            this.lblNomeFixo.Text = "Nome:";
            // 
            // timerEsconder
            // 
            this.timerEsconder.Enabled = true;
            this.timerEsconder.Interval = 2000;
            this.timerEsconder.Tick += new System.EventHandler(this.timerEsconder_Tick);
            // 
            // FormPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "FormPesquisa";
            this.Text = "OnPlaceMovel - Pesquisa";
            this.Activated += new System.EventHandler(this.Pesquisa_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Pesquisa_Closing);
            this.tabControl.ResumeLayout(false);
            this.tabBusca.ResumeLayout(false);
            this.tabResultado.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabBusca;
		private System.Windows.Forms.Label lblHidNaoEncontrado;
		private System.Windows.Forms.TextBox txtMatricula;
		private System.Windows.Forms.Label lblBuscaMatricula;
		private System.Windows.Forms.Button btnBuscarMatricula;
		private System.Windows.Forms.TabPage tabResultado;
		private System.Windows.Forms.Label lblMatNaoEcontrada;
        private System.Windows.Forms.TextBox txtHidrometro;
		private System.Windows.Forms.Button btnBuscaHidrometro;
		private System.Windows.Forms.Label lblMsg;
		private System.Windows.Forms.Label lblLogradouro;
		private System.Windows.Forms.Label lblDtHrColeta;
		private System.Windows.Forms.Label lblMatricula;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.CheckBox chkProcessado;
		private System.Windows.Forms.Label lblDtHrColetaFixo;
		private System.Windows.Forms.Label lnlMatriculaFixo;
		private System.Windows.Forms.Label lblNomeFixo;
		private System.Windows.Forms.Button btnBuscaCancelar;
		private System.Windows.Forms.Button btnResultadoCancelar;
		private System.Windows.Forms.Button btnSelecionar;
		private System.Windows.Forms.Timer timerEsconder;
        private System.Windows.Forms.TextBox txtLeitura;
        private System.Windows.Forms.Label lblBuscaLeitura;
        private System.Windows.Forms.Label lblBuscaHidrometro;
        private System.Windows.Forms.Button btnBuscaLeitura;
        private System.Windows.Forms.Label lblLeiNaoEncontrado;
	}
}