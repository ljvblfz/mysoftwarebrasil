namespace OnPlaceMovel.Source.Forms {
	partial class FormOpcoesNavegacao {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBusca = new System.Windows.Forms.TabPage();
            this.txtNumeroMovel = new System.Windows.Forms.TextBox();
            this.lblBuscaNumero = new System.Windows.Forms.Label();
            this.cboxLogradouroBusca = new System.Windows.Forms.ComboBox();
            this.btnBuscaEndereco = new System.Windows.Forms.Button();
            this.lblEndNaoEncontrado = new System.Windows.Forms.Label();
            this.lblBuscaEndereco = new System.Windows.Forms.Label();
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
            this.tabOpcoes = new System.Windows.Forms.TabPage();
            this.lblLogradouros = new System.Windows.Forms.Label();
            this.cboxLogradouros = new System.Windows.Forms.ComboBox();
            this.pnlClassificacao = new System.Windows.Forms.Panel();
            this.rbtnDecrescente = new System.Windows.Forms.RadioButton();
            this.rbtnCrescente = new System.Windows.Forms.RadioButton();
            this.pnlCaminhamento = new System.Windows.Forms.Panel();
            this.rbtnRoteiro = new System.Windows.Forms.RadioButton();
            this.rbtnLogradouro = new System.Windows.Forms.RadioButton();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.chkLidas = new System.Windows.Forms.CheckBox();
            this.chkNaoLidas = new System.Windows.Forms.CheckBox();
            this.lblIncluirMatriculas = new System.Windows.Forms.Label();
            this.lblCaminhamento = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabBusca.SuspendLayout();
            this.tabOpcoes.SuspendLayout();
            this.pnlClassificacao.SuspendLayout();
            this.pnlCaminhamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBusca);
            this.tabControl.Controls.Add(this.tabOpcoes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 268);
            this.tabControl.TabIndex = 0;
            // 
            // tabBusca
            // 
            this.tabBusca.Controls.Add(this.txtNumeroMovel);
            this.tabBusca.Controls.Add(this.lblBuscaNumero);
            this.tabBusca.Controls.Add(this.cboxLogradouroBusca);
            this.tabBusca.Controls.Add(this.btnBuscaEndereco);
            this.tabBusca.Controls.Add(this.lblEndNaoEncontrado);
            this.tabBusca.Controls.Add(this.lblBuscaEndereco);
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
            // txtNumeroMovel
            // 
            this.txtNumeroMovel.Location = new System.Drawing.Point(69, 185);
            this.txtNumeroMovel.Name = "txtNumeroMovel";
            this.txtNumeroMovel.Size = new System.Drawing.Size(78, 21);
			this.txtNumeroMovel.TabIndex = 7;
            this.txtNumeroMovel.TextChanged += new System.EventHandler(this.txtNumeroMovel_TextChanged);
            // 
            // lblBuscaNumero
            // 
            this.lblBuscaNumero.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaNumero.Location = new System.Drawing.Point(14, 187);
            this.lblBuscaNumero.Name = "lblBuscaNumero";
            this.lblBuscaNumero.Size = new System.Drawing.Size(59, 15);
			this.lblBuscaNumero.Text = "&Número: ";
            // 
            // cboxLogradouroBusca
            // 
            this.cboxLogradouroBusca.Location = new System.Drawing.Point(69, 160);
            this.cboxLogradouroBusca.Name = "cboxLogradouroBusca";
            this.cboxLogradouroBusca.Size = new System.Drawing.Size(167, 22);
			this.cboxLogradouroBusca.TabIndex = 6;
            this.cboxLogradouroBusca.SelectedIndexChanged += new System.EventHandler(this.cboxLogradouroBusca_SelectedIndexChanged);
            // 
            // btnBuscaEndereco
            // 
            this.btnBuscaEndereco.Location = new System.Drawing.Point(152, 186);
            this.btnBuscaEndereco.Name = "btnBuscaEndereco";
            this.btnBuscaEndereco.Size = new System.Drawing.Size(84, 20);
			this.btnBuscaEndereco.TabIndex = 8;
            this.btnBuscaEndereco.Text = "Buscar";
            this.btnBuscaEndereco.Click += new System.EventHandler(this.btnBuscaEndereco_Click);
            // 
            // lblEndNaoEncontrado
            // 
            this.lblEndNaoEncontrado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblEndNaoEncontrado.ForeColor = System.Drawing.Color.Red;
            this.lblEndNaoEncontrado.Location = new System.Drawing.Point(26, 209);
            this.lblEndNaoEncontrado.Name = "lblEndNaoEncontrado";
            this.lblEndNaoEncontrado.Size = new System.Drawing.Size(121, 20);
            this.lblEndNaoEncontrado.Text = "Não encontrado";
            this.lblEndNaoEncontrado.Visible = false;
            // 
            // lblBuscaEndereco
            // 
            this.lblBuscaEndereco.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaEndereco.Location = new System.Drawing.Point(4, 162);
            this.lblBuscaEndereco.Name = "lblBuscaEndereco";
            this.lblBuscaEndereco.Size = new System.Drawing.Size(66, 20);
			this.lblBuscaEndereco.Text = "&Endereço:";
            // 
            // btnBuscaLeitura
            // 
            this.btnBuscaLeitura.Location = new System.Drawing.Point(152, 134);
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
            this.lblLeiNaoEncontrado.Location = new System.Drawing.Point(25, 134);
            this.lblLeiNaoEncontrado.Name = "lblLeiNaoEncontrado";
            this.lblLeiNaoEncontrado.Size = new System.Drawing.Size(121, 20);
            this.lblLeiNaoEncontrado.Text = "Não encontrado";
            this.lblLeiNaoEncontrado.Visible = false;
            // 
            // txtLeitura
            // 
            this.txtLeitura.Location = new System.Drawing.Point(82, 110);
            this.txtLeitura.MaxLength = 7;
            this.txtLeitura.Name = "txtLeitura";
            this.txtLeitura.Size = new System.Drawing.Size(155, 21);
            this.txtLeitura.TabIndex = 4;
            this.txtLeitura.TextChanged += new System.EventHandler(this.txtLeitura_TextChanged);
            // 
            // lblBuscaLeitura
            // 
            this.lblBuscaLeitura.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaLeitura.Location = new System.Drawing.Point(4, 110);
            this.lblBuscaLeitura.Name = "lblBuscaLeitura";
            this.lblBuscaLeitura.Size = new System.Drawing.Size(80, 20);
			this.lblBuscaLeitura.Text = "&Sequência:";
            // 
            // btnBuscaCancelar
            // 
            this.btnBuscaCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBuscaCancelar.Location = new System.Drawing.Point(153, 222);
            this.btnBuscaCancelar.Name = "btnBuscaCancelar";
            this.btnBuscaCancelar.Size = new System.Drawing.Size(84, 20);
			this.btnBuscaCancelar.TabIndex = 9;
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
            this.txtHidrometro.Location = new System.Drawing.Point(82, 58);
            this.txtHidrometro.MaxLength = 12;
            this.txtHidrometro.Name = "txtHidrometro";
            this.txtHidrometro.Size = new System.Drawing.Size(155, 21);
            this.txtHidrometro.TabIndex = 2;
            this.txtHidrometro.TextChanged += new System.EventHandler(this.txtHidrometro_TextChanged);
            // 
            // lblBuscaHidrometro
            // 
            this.lblBuscaHidrometro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaHidrometro.Location = new System.Drawing.Point(4, 60);
            this.lblBuscaHidrometro.Name = "lblBuscaHidrometro";
            this.lblBuscaHidrometro.Size = new System.Drawing.Size(80, 20);
			this.lblBuscaHidrometro.Text = "&Hidrômetro:";
            // 
            // btnBuscaHidrometro
            // 
            this.btnBuscaHidrometro.Location = new System.Drawing.Point(152, 84);
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
            this.lblHidNaoEncontrado.Location = new System.Drawing.Point(25, 84);
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
            this.txtMatricula.Size = new System.Drawing.Size(155, 21);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
            // 
            // lblBuscaMatricula
            // 
            this.lblBuscaMatricula.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscaMatricula.Location = new System.Drawing.Point(4, 8);
            this.lblBuscaMatricula.Name = "lblBuscaMatricula";
            this.lblBuscaMatricula.Size = new System.Drawing.Size(68, 20);
			this.lblBuscaMatricula.Text = "Nº &Conta: ";
            // 
            // btnBuscarMatricula
            // 
            this.btnBuscarMatricula.Location = new System.Drawing.Point(153, 32);
            this.btnBuscarMatricula.Name = "btnBuscarMatricula";
            this.btnBuscarMatricula.Size = new System.Drawing.Size(84, 20);
            this.btnBuscarMatricula.TabIndex = 1;
            this.btnBuscarMatricula.Text = "Buscar";
            this.btnBuscarMatricula.Click += new System.EventHandler(this.btnBuscarMatricula_Click);
            // 
            // tabOpcoes
            // 
            this.tabOpcoes.Controls.Add(this.lblLogradouros);
            this.tabOpcoes.Controls.Add(this.cboxLogradouros);
            this.tabOpcoes.Controls.Add(this.pnlClassificacao);
            this.tabOpcoes.Controls.Add(this.pnlCaminhamento);
            this.tabOpcoes.Controls.Add(this.lblClassificacao);
            this.tabOpcoes.Controls.Add(this.chkLidas);
            this.tabOpcoes.Controls.Add(this.chkNaoLidas);
            this.tabOpcoes.Controls.Add(this.lblIncluirMatriculas);
            this.tabOpcoes.Controls.Add(this.lblCaminhamento);
            this.tabOpcoes.Location = new System.Drawing.Point(0, 0);
            this.tabOpcoes.Name = "tabOpcoes";
			this.tabOpcoes.Size = new System.Drawing.Size(240, 245);
            this.tabOpcoes.Text = "Opções";
            // 
            // lblLogradouros
            // 
            this.lblLogradouros.Location = new System.Drawing.Point(7, 51);
            this.lblLogradouros.Name = "lblLogradouros";
            this.lblLogradouros.Size = new System.Drawing.Size(78, 17);
            this.lblLogradouros.Text = "Logradouros:";
            // 
            // cboxLogradouros
            // 
            this.cboxLogradouros.Enabled = false;
            this.cboxLogradouros.Location = new System.Drawing.Point(91, 48);
            this.cboxLogradouros.Name = "cboxLogradouros";
            this.cboxLogradouros.Size = new System.Drawing.Size(145, 22);
            this.cboxLogradouros.TabIndex = 12;
            // 
            // pnlClassificacao
            // 
            this.pnlClassificacao.Controls.Add(this.rbtnDecrescente);
            this.pnlClassificacao.Controls.Add(this.rbtnCrescente);
            this.pnlClassificacao.Location = new System.Drawing.Point(0, 157);
            this.pnlClassificacao.Name = "pnlClassificacao";
            this.pnlClassificacao.Size = new System.Drawing.Size(237, 22);
            // 
            // rbtnDecrescente
            // 
            this.rbtnDecrescente.Location = new System.Drawing.Point(133, 1);
            this.rbtnDecrescente.Name = "rbtnDecrescente";
            this.rbtnDecrescente.Size = new System.Drawing.Size(107, 20);
            this.rbtnDecrescente.TabIndex = 14;
            this.rbtnDecrescente.TabStop = false;
            this.rbtnDecrescente.Text = "Decrescente";
            // 
            // rbtnCrescente
            // 
            this.rbtnCrescente.Checked = true;
            this.rbtnCrescente.Location = new System.Drawing.Point(2, 1);
            this.rbtnCrescente.Name = "rbtnCrescente";
            this.rbtnCrescente.Size = new System.Drawing.Size(100, 20);
            this.rbtnCrescente.TabIndex = 13;
            this.rbtnCrescente.Text = "Crescente";
            // 
            // pnlCaminhamento
            // 
            this.pnlCaminhamento.Controls.Add(this.rbtnRoteiro);
            this.pnlCaminhamento.Controls.Add(this.rbtnLogradouro);
            this.pnlCaminhamento.Location = new System.Drawing.Point(0, 20);
            this.pnlCaminhamento.Name = "pnlCaminhamento";
            this.pnlCaminhamento.Size = new System.Drawing.Size(240, 22);
            // 
            // rbtnRoteiro
            // 
            this.rbtnRoteiro.Checked = true;
            this.rbtnRoteiro.Location = new System.Drawing.Point(4, 1);
            this.rbtnRoteiro.Name = "rbtnRoteiro";
            this.rbtnRoteiro.Size = new System.Drawing.Size(100, 20);
            this.rbtnRoteiro.TabIndex = 4;
            this.rbtnRoteiro.Text = "Roteiro";
            // 
            // rbtnLogradouro
            // 
            this.rbtnLogradouro.Location = new System.Drawing.Point(130, 1);
            this.rbtnLogradouro.Name = "rbtnLogradouro";
            this.rbtnLogradouro.Size = new System.Drawing.Size(100, 20);
            this.rbtnLogradouro.TabIndex = 3;
            this.rbtnLogradouro.TabStop = false;
            this.rbtnLogradouro.Text = "Logradouro";
            this.rbtnLogradouro.CheckedChanged += new System.EventHandler(this.rbtnLogradouro_CheckedChanged);
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassificacao.Location = new System.Drawing.Point(7, 141);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(226, 14);
            this.lblClassificacao.Text = "Classificação:";
            // 
            // chkLidas
            // 
            this.chkLidas.Checked = true;
            this.chkLidas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLidas.Location = new System.Drawing.Point(133, 105);
            this.chkLidas.Name = "chkLidas";
            this.chkLidas.Size = new System.Drawing.Size(100, 20);
            this.chkLidas.TabIndex = 9;
            this.chkLidas.Text = "Lidas";
            // 
            // chkNaoLidas
            // 
            this.chkNaoLidas.Checked = true;
            this.chkNaoLidas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaoLidas.Location = new System.Drawing.Point(7, 105);
            this.chkNaoLidas.Name = "chkNaoLidas";
            this.chkNaoLidas.Size = new System.Drawing.Size(100, 20);
            this.chkNaoLidas.TabIndex = 8;
            this.chkNaoLidas.Text = "Não Lidas";
            // 
            // lblIncluirMatriculas
            // 
            this.lblIncluirMatriculas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblIncluirMatriculas.Location = new System.Drawing.Point(7, 90);
            this.lblIncluirMatriculas.Name = "lblIncluirMatriculas";
            this.lblIncluirMatriculas.Size = new System.Drawing.Size(226, 20);
            this.lblIncluirMatriculas.Text = "Incluir matriculas:";
            // 
            // lblCaminhamento
            // 
            this.lblCaminhamento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCaminhamento.Location = new System.Drawing.Point(7, 4);
            this.lblCaminhamento.Name = "lblCaminhamento";
            this.lblCaminhamento.Size = new System.Drawing.Size(226, 20);
            this.lblCaminhamento.Text = "Caminhamento:";
            // 
            // FormOpcoesNavegacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "FormOpcoesNavegacao";
            this.Text = "OnPlaceMovel - Pesquisa";
            this.Activated += new System.EventHandler(this.Pesquisa_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormOpcoesNavegacao_Closing);
            this.tabControl.ResumeLayout(false);
            this.tabBusca.ResumeLayout(false);
            this.tabOpcoes.ResumeLayout(false);
            this.pnlClassificacao.ResumeLayout(false);
            this.pnlCaminhamento.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabBusca;
		private System.Windows.Forms.Label lblHidNaoEncontrado;
		private System.Windows.Forms.TextBox txtMatricula;
		private System.Windows.Forms.Label lblBuscaMatricula;
		private System.Windows.Forms.Button btnBuscarMatricula;
		private System.Windows.Forms.Label lblMatNaoEcontrada;
		private System.Windows.Forms.TextBox txtHidrometro;
		private System.Windows.Forms.Button btnBuscaHidrometro;
		private System.Windows.Forms.Button btnBuscaCancelar;
		private System.Windows.Forms.TextBox txtLeitura;
		private System.Windows.Forms.Label lblBuscaLeitura;
		private System.Windows.Forms.Label lblBuscaHidrometro;
		private System.Windows.Forms.Button btnBuscaLeitura;
		private System.Windows.Forms.Label lblLeiNaoEncontrado;
		private System.Windows.Forms.TabPage tabOpcoes;
		private System.Windows.Forms.Panel pnlClassificacao;
		private System.Windows.Forms.RadioButton rbtnDecrescente;
		private System.Windows.Forms.RadioButton rbtnCrescente;
		private System.Windows.Forms.Panel pnlCaminhamento;
		private System.Windows.Forms.RadioButton rbtnRoteiro;
		private System.Windows.Forms.RadioButton rbtnLogradouro;
		private System.Windows.Forms.Label lblClassificacao;
		private System.Windows.Forms.CheckBox chkLidas;
		private System.Windows.Forms.CheckBox chkNaoLidas;
		private System.Windows.Forms.Label lblIncluirMatriculas;
		private System.Windows.Forms.Label lblCaminhamento;
		private System.Windows.Forms.Label lblLogradouros;
		private System.Windows.Forms.ComboBox cboxLogradouros;
		private System.Windows.Forms.TextBox txtNumeroMovel;
		private System.Windows.Forms.Label lblBuscaNumero;
		private System.Windows.Forms.ComboBox cboxLogradouroBusca;
		private System.Windows.Forms.Button btnBuscaEndereco;
		private System.Windows.Forms.Label lblEndNaoEncontrado;
		private System.Windows.Forms.Label lblBuscaEndereco;
	}
}