namespace OnPlaceMovel.Source.Forms {
	partial class FormNavegacao {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNavegacao));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.btnAnterior = new System.Windows.Forms.Button();
			this.btnSelecionar = new System.Windows.Forms.Button();
			this.btnProximo = new System.Windows.Forms.Button();
			this.lblInfoNome = new System.Windows.Forms.Label();
			this.lblInfoNrMatricula = new System.Windows.Forms.Label();
			this.lblInfoDataHoraColeta = new System.Windows.Forms.Label();
			this.chkProcessado = new System.Windows.Forms.CheckBox();
			this.lblNome = new System.Windows.Forms.Label();
			this.lblNrMatricula = new System.Windows.Forms.Label();
			this.lblDataHoraColeta = new System.Windows.Forms.Label();
			this.btnSair = new System.Windows.Forms.Button();
			this.lblLogradouro = new System.Windows.Forms.Label();
			this.lblAviso1 = new System.Windows.Forms.Label();
			this.pboxOpcoes = new System.Windows.Forms.PictureBox();
			this.lblInfoNrHidrometro = new System.Windows.Forms.Label();
			this.lblNrHidrometro = new System.Windows.Forms.Label();
			this.pboxEstatisticas = new System.Windows.Forms.PictureBox();
			this.btnUltimo = new System.Windows.Forms.Button();
			this.btnPrimeiro = new System.Windows.Forms.Button();
			this.btnHistorico = new System.Windows.Forms.Button();
			this.chkImpresso = new System.Windows.Forms.CheckBox();
			this.lblCategoria1 = new System.Windows.Forms.Label();
			this.lblInfoCategoria1 = new System.Windows.Forms.Label();
			this.lblOcorrencias = new System.Windows.Forms.Label();
			this.lblInfoOcorrencias = new System.Windows.Forms.Label();
			this.lblMedia = new System.Windows.Forms.Label();
			this.lblInfoMedia = new System.Windows.Forms.Label();
			this.lblAviso2 = new System.Windows.Forms.Label();
			this.lblCategoria2 = new System.Windows.Forms.Label();
			this.lblInfoCategoria2 = new System.Windows.Forms.Label();
			this.lblLeitura = new System.Windows.Forms.Label();
			this.lblInfoLeitura = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAnterior
			// 
			this.btnAnterior.Location = new System.Drawing.Point(51, 3);
			this.btnAnterior.Name = "btnAnterior";
			this.btnAnterior.Size = new System.Drawing.Size(31, 24);
			this.btnAnterior.TabIndex = 1;
			this.btnAnterior.Text = " <<";
			this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
			// 
			// btnSelecionar
			// 
			this.btnSelecionar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelecionar.Location = new System.Drawing.Point(87, 241);
			this.btnSelecionar.Name = "btnSelecionar";
			this.btnSelecionar.Size = new System.Drawing.Size(70, 24);
			this.btnSelecionar.TabIndex = 6;
			this.btnSelecionar.Text = "Selecionar";
			// 
			// btnProximo
			// 
			this.btnProximo.Location = new System.Drawing.Point(157, 3);
			this.btnProximo.Name = "btnProximo";
			this.btnProximo.Size = new System.Drawing.Size(31, 24);
			this.btnProximo.TabIndex = 2;
			this.btnProximo.Text = " >>";
			this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
			// 
			// lblInfoNome
			// 
			this.lblInfoNome.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoNome.Location = new System.Drawing.Point(10, 30);
			this.lblInfoNome.Name = "lblInfoNome";
			this.lblInfoNome.Size = new System.Drawing.Size(45, 16);
			this.lblInfoNome.Text = "Nome:";
			// 
			// lblInfoNrMatricula
			// 
			this.lblInfoNrMatricula.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoNrMatricula.Location = new System.Drawing.Point(10, 63);
			this.lblInfoNrMatricula.Name = "lblInfoNrMatricula";
			this.lblInfoNrMatricula.Size = new System.Drawing.Size(82, 15);
			this.lblInfoNrMatricula.Text = "Nº Conta: ";
			// 
			// lblInfoDataHoraColeta
			// 
			this.lblInfoDataHoraColeta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoDataHoraColeta.Location = new System.Drawing.Point(11, 120);
			this.lblInfoDataHoraColeta.Name = "lblInfoDataHoraColeta";
			this.lblInfoDataHoraColeta.Size = new System.Drawing.Size(118, 14);
			this.lblInfoDataHoraColeta.Text = "Data/Hora Coleta: ";
			// 
			// chkProcessado
			// 
			this.chkProcessado.Enabled = false;
			this.chkProcessado.Location = new System.Drawing.Point(10, 202);
			this.chkProcessado.Name = "chkProcessado";
			this.chkProcessado.Size = new System.Drawing.Size(89, 15);
			this.chkProcessado.TabIndex = 4;
			this.chkProcessado.Text = "Processado";
			// 
			// lblNome
			// 
			this.lblNome.Location = new System.Drawing.Point(51, 30);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(186, 16);
			this.lblNome.Text = "NOME DO CLIENTE";
			// 
			// lblNrMatricula
			// 
			this.lblNrMatricula.Location = new System.Drawing.Point(92, 63);
			this.lblNrMatricula.Name = "lblNrMatricula";
			this.lblNrMatricula.Size = new System.Drawing.Size(145, 15);
			this.lblNrMatricula.Text = "91919191 (919191)";
			// 
			// lblDataHoraColeta
			// 
			this.lblDataHoraColeta.Location = new System.Drawing.Point(123, 120);
			this.lblDataHoraColeta.Name = "lblDataHoraColeta";
			this.lblDataHoraColeta.Size = new System.Drawing.Size(114, 14);
			this.lblDataHoraColeta.Text = "91/91/9191 91:91";
			// 
			// btnSair
			// 
			this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSair.Location = new System.Drawing.Point(11, 241);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(70, 24);
			this.btnSair.TabIndex = 5;
			this.btnSair.Text = "Sair";
			// 
			// lblLogradouro
			// 
			this.lblLogradouro.Location = new System.Drawing.Point(10, 78);
			this.lblLogradouro.Name = "lblLogradouro";
			this.lblLogradouro.Size = new System.Drawing.Size(227, 42);
			this.lblLogradouro.Text = "LOGRADOURO\r\nCOMPLEMENTO\r\n";
			// 
			// lblAviso1
			// 
			this.lblAviso1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.lblAviso1.ForeColor = System.Drawing.Color.Red;
			this.lblAviso1.Location = new System.Drawing.Point(98, 202);
			this.lblAviso1.Name = "lblAviso1";
			this.lblAviso1.Size = new System.Drawing.Size(139, 15);
			this.lblAviso1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pboxOpcoes
			// 
			this.pboxOpcoes.Image = ((System.Drawing.Image)(resources.GetObject("pboxOpcoes.Image")));
			this.pboxOpcoes.Location = new System.Drawing.Point(91, 3);
			this.pboxOpcoes.Name = "pboxOpcoes";
			this.pboxOpcoes.Size = new System.Drawing.Size(24, 24);
			this.pboxOpcoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pboxOpcoes.Click += new System.EventHandler(this.pboxOpcoes_Click);
			// 
			// lblInfoNrHidrometro
			// 
			this.lblInfoNrHidrometro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoNrHidrometro.Location = new System.Drawing.Point(10, 46);
			this.lblInfoNrHidrometro.Name = "lblInfoNrHidrometro";
			this.lblInfoNrHidrometro.Size = new System.Drawing.Size(82, 16);
			this.lblInfoNrHidrometro.Text = "Hidrometro:";
			// 
			// lblNrHidrometro
			// 
			this.lblNrHidrometro.Location = new System.Drawing.Point(92, 46);
			this.lblNrHidrometro.Name = "lblNrHidrometro";
			this.lblNrHidrometro.Size = new System.Drawing.Size(115, 16);
			this.lblNrHidrometro.Text = "0123456789AB";
			// 
			// pboxEstatisticas
			// 
			this.pboxEstatisticas.Image = ((System.Drawing.Image)(resources.GetObject("pboxEstatisticas.Image")));
			this.pboxEstatisticas.Location = new System.Drawing.Point(124, 3);
			this.pboxEstatisticas.Name = "pboxEstatisticas";
			this.pboxEstatisticas.Size = new System.Drawing.Size(24, 24);
			this.pboxEstatisticas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pboxEstatisticas.Click += new System.EventHandler(this.pboxEstatisticas_Click);
			// 
			// btnUltimo
			// 
			this.btnUltimo.Location = new System.Drawing.Point(197, 3);
			this.btnUltimo.Name = "btnUltimo";
			this.btnUltimo.Size = new System.Drawing.Size(31, 24);
			this.btnUltimo.TabIndex = 3;
			this.btnUltimo.Text = " >|";
			this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
			// 
			// btnPrimeiro
			// 
			this.btnPrimeiro.Location = new System.Drawing.Point(11, 3);
			this.btnPrimeiro.Name = "btnPrimeiro";
			this.btnPrimeiro.Size = new System.Drawing.Size(31, 24);
			this.btnPrimeiro.TabIndex = 0;
			this.btnPrimeiro.Text = "|<";
			this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click);
			// 
			// btnHistorico
			// 
			this.btnHistorico.Location = new System.Drawing.Point(163, 241);
			this.btnHistorico.Name = "btnHistorico";
			this.btnHistorico.Size = new System.Drawing.Size(66, 24);
			this.btnHistorico.TabIndex = 7;
			this.btnHistorico.Text = "Histórico";
			this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
			// 
			// chkImpresso
			// 
			this.chkImpresso.Enabled = false;
			this.chkImpresso.Location = new System.Drawing.Point(10, 220);
			this.chkImpresso.Name = "chkImpresso";
			this.chkImpresso.Size = new System.Drawing.Size(89, 15);
			this.chkImpresso.TabIndex = 20;
			this.chkImpresso.Text = "Impresso";
			// 
			// lblCategoria1
			// 
			this.lblCategoria1.Location = new System.Drawing.Point(88, 134);
			this.lblCategoria1.Name = "lblCategoria1";
			this.lblCategoria1.Size = new System.Drawing.Size(149, 16);
			this.lblCategoria1.Text = "CATEGORIA / 91";
			// 
			// lblInfoCategoria1
			// 
			this.lblInfoCategoria1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoCategoria1.Location = new System.Drawing.Point(11, 134);
			this.lblInfoCategoria1.Name = "lblInfoCategoria1";
			this.lblInfoCategoria1.Size = new System.Drawing.Size(81, 16);
			this.lblInfoCategoria1.Text = "Categoria 1:";
			// 
			// lblOcorrencias
			// 
			this.lblOcorrencias.Location = new System.Drawing.Point(98, 166);
			this.lblOcorrencias.Name = "lblOcorrencias";
			this.lblOcorrencias.Size = new System.Drawing.Size(139, 16);
			this.lblOcorrencias.Text = "XX / YY / ZZ";
			// 
			// lblInfoOcorrencias
			// 
			this.lblInfoOcorrencias.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoOcorrencias.Location = new System.Drawing.Point(10, 166);
			this.lblInfoOcorrencias.Name = "lblInfoOcorrencias";
			this.lblInfoOcorrencias.Size = new System.Drawing.Size(94, 16);
			this.lblInfoOcorrencias.Text = "Ocorrencia(s):";
			// 
			// lblMedia
			// 
			this.lblMedia.Location = new System.Drawing.Point(55, 182);
			this.lblMedia.Name = "lblMedia";
			this.lblMedia.Size = new System.Drawing.Size(49, 16);
			this.lblMedia.Text = "919191";
			// 
			// lblInfoMedia
			// 
			this.lblInfoMedia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoMedia.Location = new System.Drawing.Point(10, 182);
			this.lblInfoMedia.Name = "lblInfoMedia";
			this.lblInfoMedia.Size = new System.Drawing.Size(46, 16);
			this.lblInfoMedia.Text = "Média:";
			// 
			// lblAviso2
			// 
			this.lblAviso2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.lblAviso2.ForeColor = System.Drawing.Color.Red;
			this.lblAviso2.Location = new System.Drawing.Point(98, 220);
			this.lblAviso2.Name = "lblAviso2";
			this.lblAviso2.Size = new System.Drawing.Size(139, 15);
			this.lblAviso2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblCategoria2
			// 
			this.lblCategoria2.Location = new System.Drawing.Point(87, 150);
			this.lblCategoria2.Name = "lblCategoria2";
			this.lblCategoria2.Size = new System.Drawing.Size(150, 16);
			this.lblCategoria2.Text = "CATEGORIA / 91";
			// 
			// lblInfoCategoria2
			// 
			this.lblInfoCategoria2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoCategoria2.Location = new System.Drawing.Point(10, 150);
			this.lblInfoCategoria2.Name = "lblInfoCategoria2";
			this.lblInfoCategoria2.Size = new System.Drawing.Size(81, 16);
			this.lblInfoCategoria2.Text = "Categoria 2:";
			// 
			// lblLeitura
			// 
			this.lblLeitura.Location = new System.Drawing.Point(184, 182);
			this.lblLeitura.Name = "lblLeitura";
			this.lblLeitura.Size = new System.Drawing.Size(53, 16);
			this.lblLeitura.Text = "919191";
			// 
			// lblInfoLeitura
			// 
			this.lblInfoLeitura.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfoLeitura.Location = new System.Drawing.Point(132, 182);
			this.lblInfoLeitura.Name = "lblInfoLeitura";
			this.lblInfoLeitura.Size = new System.Drawing.Size(53, 16);
			this.lblInfoLeitura.Text = "Leitura:";
			// 
			// FormNavegacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.lblLeitura);
			this.Controls.Add(this.lblInfoLeitura);
			this.Controls.Add(this.lblCategoria2);
			this.Controls.Add(this.lblInfoCategoria2);
			this.Controls.Add(this.lblAviso2);
			this.Controls.Add(this.lblMedia);
			this.Controls.Add(this.lblInfoMedia);
			this.Controls.Add(this.lblOcorrencias);
			this.Controls.Add(this.lblInfoOcorrencias);
			this.Controls.Add(this.lblCategoria1);
			this.Controls.Add(this.lblInfoCategoria1);
			this.Controls.Add(this.chkImpresso);
			this.Controls.Add(this.btnHistorico);
			this.Controls.Add(this.btnPrimeiro);
			this.Controls.Add(this.btnUltimo);
			this.Controls.Add(this.pboxEstatisticas);
			this.Controls.Add(this.lblNrHidrometro);
			this.Controls.Add(this.lblInfoNrHidrometro);
			this.Controls.Add(this.pboxOpcoes);
			this.Controls.Add(this.lblAviso1);
			this.Controls.Add(this.lblLogradouro);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.lblDataHoraColeta);
			this.Controls.Add(this.lblNrMatricula);
			this.Controls.Add(this.lblNome);
			this.Controls.Add(this.chkProcessado);
			this.Controls.Add(this.lblInfoDataHoraColeta);
			this.Controls.Add(this.lblInfoNrMatricula);
			this.Controls.Add(this.lblInfoNome);
			this.Controls.Add(this.btnProximo);
			this.Controls.Add(this.btnSelecionar);
			this.Controls.Add(this.btnAnterior);
			this.KeyPreview = true;
			this.Menu = this.mainMenu;
			this.MinimizeBox = false;
			this.Name = "FormNavegacao";
			this.Text = "OnPlaceMovel - Navegacao";
			this.Activated += new System.EventHandler(this.Navegacao_Activated);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormNavegacao_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAnterior;
		private System.Windows.Forms.Button btnSelecionar;
		private System.Windows.Forms.Button btnProximo;
		private System.Windows.Forms.Label lblInfoNome;
		private System.Windows.Forms.Label lblInfoNrMatricula;
		private System.Windows.Forms.Label lblInfoDataHoraColeta;
		private System.Windows.Forms.CheckBox chkProcessado;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.Label lblNrMatricula;
		private System.Windows.Forms.Label lblDataHoraColeta;
		private System.Windows.Forms.Button btnSair;
		private System.Windows.Forms.Label lblLogradouro;
		private System.Windows.Forms.Label lblAviso1;
		private System.Windows.Forms.PictureBox pboxOpcoes;
		private System.Windows.Forms.Label lblInfoNrHidrometro;
		private System.Windows.Forms.Label lblNrHidrometro;
		private System.Windows.Forms.PictureBox pboxEstatisticas;
		private System.Windows.Forms.Button btnUltimo;
		private System.Windows.Forms.Button btnPrimeiro;
		private System.Windows.Forms.Button btnHistorico;
		private System.Windows.Forms.CheckBox chkImpresso;
		private System.Windows.Forms.Label lblCategoria1;
		private System.Windows.Forms.Label lblInfoCategoria1;
		private System.Windows.Forms.Label lblOcorrencias;
		private System.Windows.Forms.Label lblInfoOcorrencias;
		private System.Windows.Forms.Label lblMedia;
		private System.Windows.Forms.Label lblInfoMedia;
		private System.Windows.Forms.Label lblAviso2;
		private System.Windows.Forms.Label lblCategoria2;
		private System.Windows.Forms.Label lblInfoCategoria2;
		private System.Windows.Forms.Label lblLeitura;
		private System.Windows.Forms.Label lblInfoLeitura;
	}
}