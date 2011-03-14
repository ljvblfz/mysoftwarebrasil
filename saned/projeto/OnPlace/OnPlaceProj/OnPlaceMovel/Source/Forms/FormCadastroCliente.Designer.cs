namespace OnPlaceMovel.Source.Forms {
    partial class FormCadastroCliente {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.tabDadosCliente = new System.Windows.Forms.TabPage();
            this.tbObservacao = new System.Windows.Forms.TextBox();
            this.lbObservacao = new System.Windows.Forms.Label();
            this.tbLeituraAtual = new System.Windows.Forms.TextBox();
            this.lbLeituraAtual = new System.Windows.Forms.Label();
            this.tbNHD = new System.Windows.Forms.TextBox();
            this.lbNHD = new System.Windows.Forms.Label();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.tbComplemento = new System.Windows.Forms.TextBox();
            this.cbLogradouro = new System.Windows.Forms.ComboBox();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbNImovel = new System.Windows.Forms.TextBox();
            this.lbComplemento = new System.Windows.Forms.Label();
            this.lbLogradouro = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.lbNImovel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnInclui = new System.Windows.Forms.Button();
            this.lvLigacaoCategoria = new System.Windows.Forms.ListView();
            this.chCategorias = new System.Windows.Forms.ColumnHeader();
            this.chNEcon = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.cbListaCategorias = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEconomias = new System.Windows.Forms.TextBox();
            this.tabDadosCliente.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCategorias.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnCancelar.Location = new System.Drawing.Point(185, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(52, 20);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Sair";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnGravar.Location = new System.Drawing.Point(129, 193);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(50, 20);
            this.btnGravar.TabIndex = 19;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // tabDadosCliente
            // 
            this.tabDadosCliente.Controls.Add(this.tbObservacao);
            this.tabDadosCliente.Controls.Add(this.lbObservacao);
            this.tabDadosCliente.Controls.Add(this.tbLeituraAtual);
            this.tabDadosCliente.Controls.Add(this.lbLeituraAtual);
            this.tabDadosCliente.Controls.Add(this.tbNHD);
            this.tabDadosCliente.Controls.Add(this.lbNHD);
            this.tabDadosCliente.Location = new System.Drawing.Point(0, 0);
            this.tabDadosCliente.Name = "tabDadosCliente";
            this.tabDadosCliente.Size = new System.Drawing.Size(240, 164);
            this.tabDadosCliente.Text = "Geral";
            // 
            // tbObservacao
            // 
            this.tbObservacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbObservacao.Location = new System.Drawing.Point(7, 57);
            this.tbObservacao.MaxLength = 100;
            this.tbObservacao.Multiline = true;
            this.tbObservacao.Name = "tbObservacao";
            this.tbObservacao.Size = new System.Drawing.Size(226, 104);
            this.tbObservacao.TabIndex = 15;
            // 
            // lbObservacao
            // 
            this.lbObservacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbObservacao.Location = new System.Drawing.Point(7, 41);
            this.lbObservacao.Name = "lbObservacao";
            this.lbObservacao.Size = new System.Drawing.Size(70, 13);
            this.lbObservacao.Text = "Observação";
            // 
            // tbLeituraAtual
            // 
            this.tbLeituraAtual.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbLeituraAtual.Location = new System.Drawing.Point(83, 19);
            this.tbLeituraAtual.MaxLength = 7;
            this.tbLeituraAtual.Name = "tbLeituraAtual";
            this.tbLeituraAtual.Size = new System.Drawing.Size(87, 19);
            this.tbLeituraAtual.TabIndex = 7;
            this.tbLeituraAtual.TextChanged += new System.EventHandler(this.tbNumeros_TextChanged);
            // 
            // lbLeituraAtual
            // 
            this.lbLeituraAtual.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbLeituraAtual.Location = new System.Drawing.Point(83, 4);
            this.lbLeituraAtual.Name = "lbLeituraAtual";
            this.lbLeituraAtual.Size = new System.Drawing.Size(87, 11);
            this.lbLeituraAtual.Text = "Leitura Atual HD";
            // 
            // tbNHD
            // 
            this.tbNHD.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbNHD.Location = new System.Drawing.Point(7, 19);
            this.tbNHD.MaxLength = 12;
            this.tbNHD.Name = "tbNHD";
            this.tbNHD.Size = new System.Drawing.Size(70, 19);
            this.tbNHD.TabIndex = 4;
            // 
            // lbNHD
            // 
            this.lbNHD.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbNHD.Location = new System.Drawing.Point(7, 4);
            this.lbNHD.Name = "lbNHD";
            this.lbNHD.Size = new System.Drawing.Size(70, 11);
            this.lbNHD.Text = "N° HD";
            // 
            // tabGeral
            // 
            this.tabGeral.Controls.Add(this.tbComplemento);
            this.tabGeral.Controls.Add(this.cbLogradouro);
            this.tabGeral.Controls.Add(this.tbNome);
            this.tabGeral.Controls.Add(this.tbNImovel);
            this.tabGeral.Controls.Add(this.lbComplemento);
            this.tabGeral.Controls.Add(this.lbLogradouro);
            this.tabGeral.Controls.Add(this.lbNome);
            this.tabGeral.Controls.Add(this.lbNImovel);
            this.tabGeral.Location = new System.Drawing.Point(0, 0);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Size = new System.Drawing.Size(240, 164);
            this.tabGeral.Text = "Dados Cliente";
            // 
            // tbComplemento
            // 
            this.tbComplemento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbComplemento.Location = new System.Drawing.Point(7, 100);
            this.tbComplemento.MaxLength = 40;
            this.tbComplemento.Name = "tbComplemento";
            this.tbComplemento.Size = new System.Drawing.Size(143, 19);
            this.tbComplemento.TabIndex = 19;
            // 
            // cbLogradouro
            // 
            this.cbLogradouro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbLogradouro.Location = new System.Drawing.Point(7, 59);
            this.cbLogradouro.Name = "cbLogradouro";
            this.cbLogradouro.Size = new System.Drawing.Size(226, 20);
            this.cbLogradouro.TabIndex = 18;
            // 
            // tbNome
            // 
            this.tbNome.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbNome.Location = new System.Drawing.Point(7, 20);
            this.tbNome.MaxLength = 40;
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(226, 19);
            this.tbNome.TabIndex = 17;
            // 
            // tbNImovel
            // 
            this.tbNImovel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbNImovel.Location = new System.Drawing.Point(156, 100);
            this.tbNImovel.MaxLength = 5;
            this.tbNImovel.Name = "tbNImovel";
            this.tbNImovel.Size = new System.Drawing.Size(77, 19);
            this.tbNImovel.TabIndex = 16;
            this.tbNImovel.TextChanged += new System.EventHandler(this.tbNumeros_TextChanged);
            // 
            // lbComplemento
            // 
            this.lbComplemento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbComplemento.Location = new System.Drawing.Point(7, 83);
            this.lbComplemento.Name = "lbComplemento";
            this.lbComplemento.Size = new System.Drawing.Size(100, 15);
            this.lbComplemento.Text = "Complemento";
            // 
            // lbLogradouro
            // 
            this.lbLogradouro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbLogradouro.Location = new System.Drawing.Point(8, 42);
            this.lbLogradouro.Name = "lbLogradouro";
            this.lbLogradouro.Size = new System.Drawing.Size(100, 13);
            this.lbLogradouro.Text = "Logradouro";
            // 
            // lbNome
            // 
            this.lbNome.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbNome.Location = new System.Drawing.Point(7, 4);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(100, 12);
            this.lbNome.Text = "Nome";
            // 
            // lbNImovel
            // 
            this.lbNImovel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbNImovel.Location = new System.Drawing.Point(156, 85);
            this.lbNImovel.Name = "lbNImovel";
            this.lbNImovel.Size = new System.Drawing.Size(67, 13);
            this.lbNImovel.Text = "N° do imóvel";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDadosCliente);
            this.tabControl1.Controls.Add(this.tabGeral);
            this.tabControl1.Controls.Add(this.tabCategorias);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 187);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabCategorias
            // 
            this.tabCategorias.Controls.Add(this.btnLimpar);
            this.tabCategorias.Controls.Add(this.btnInclui);
            this.tabCategorias.Controls.Add(this.lvLigacaoCategoria);
            this.tabCategorias.Controls.Add(this.label4);
            this.tabCategorias.Controls.Add(this.cbListaCategorias);
            this.tabCategorias.Controls.Add(this.label6);
            this.tabCategorias.Controls.Add(this.tbEconomias);
            this.tabCategorias.Location = new System.Drawing.Point(0, 0);
            this.tabCategorias.Name = "tabCategorias";
            this.tabCategorias.Size = new System.Drawing.Size(240, 164);
            this.tabCategorias.Text = "Categorias";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnLimpar.Location = new System.Drawing.Point(57, 113);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(44, 15);
            this.btnLimpar.TabIndex = 61;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnInclui
            // 
            this.btnInclui.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnInclui.Location = new System.Drawing.Point(7, 113);
            this.btnInclui.Name = "btnInclui";
            this.btnInclui.Size = new System.Drawing.Size(44, 15);
            this.btnInclui.TabIndex = 57;
            this.btnInclui.Text = "OK";
            this.btnInclui.Click += new System.EventHandler(this.btnInclui_Click);
            // 
            // lvLigacaoCategoria
            // 
            this.lvLigacaoCategoria.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvLigacaoCategoria.CheckBoxes = true;
            this.lvLigacaoCategoria.Columns.Add(this.chCategorias);
            this.lvLigacaoCategoria.Columns.Add(this.chNEcon);
            this.lvLigacaoCategoria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lvLigacaoCategoria.FullRowSelect = true;
            this.lvLigacaoCategoria.Location = new System.Drawing.Point(7, 42);
            this.lvLigacaoCategoria.Name = "lvLigacaoCategoria";
            this.lvLigacaoCategoria.Size = new System.Drawing.Size(226, 69);
            this.lvLigacaoCategoria.TabIndex = 56;
            this.lvLigacaoCategoria.View = System.Windows.Forms.View.Details;
            // 
            // chCategorias
            // 
            this.chCategorias.Text = "Categoria";
            this.chCategorias.Width = 82;
            // 
            // chNEcon
            // 
            this.chNEcon.Text = "Eco";
            this.chNEcon.Width = 38;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(7, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.Text = "Categorias";
            // 
            // cbListaCategorias
            // 
            this.cbListaCategorias.DisplayMember = "1";
            this.cbListaCategorias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbListaCategorias.Location = new System.Drawing.Point(7, 17);
            this.cbListaCategorias.Name = "cbListaCategorias";
            this.cbListaCategorias.Size = new System.Drawing.Size(153, 20);
            this.cbListaCategorias.TabIndex = 55;
            this.cbListaCategorias.SelectedIndexChanged += new System.EventHandler(this.cbListaCategorias_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(166, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 11);
            this.label6.Text = "Eco";
            // 
            // tbEconomias
            // 
            this.tbEconomias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbEconomias.Location = new System.Drawing.Point(166, 17);
            this.tbEconomias.MaxLength = 3;
            this.tbEconomias.Name = "tbEconomias";
            this.tbEconomias.Size = new System.Drawing.Size(67, 19);
            this.tbEconomias.TabIndex = 58;
            this.tbEconomias.TextChanged += new System.EventHandler(this.tbEconomias_TextChanged);
            // 
            // FormCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "FormCadastroCliente";
            this.Text = "OnPlaceMovel - Cadastro de Cliente";
            this.tabDadosCliente.ResumeLayout(false);
            this.tabGeral.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCategorias.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TabPage tabDadosCliente;
        private System.Windows.Forms.TabPage tabGeral;
        private System.Windows.Forms.TextBox tbComplemento;
        private System.Windows.Forms.ComboBox cbLogradouro;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbNImovel;
        private System.Windows.Forms.Label lbComplemento;
        private System.Windows.Forms.Label lbLogradouro;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Label lbNImovel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbLeituraAtual;
        private System.Windows.Forms.Label lbLeituraAtual;
        private System.Windows.Forms.TextBox tbNHD;
        private System.Windows.Forms.Label lbNHD;
        private System.Windows.Forms.TextBox tbObservacao;
        private System.Windows.Forms.Label lbObservacao;
        private System.Windows.Forms.TabPage tabCategorias;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnInclui;
        private System.Windows.Forms.ListView lvLigacaoCategoria;
        private System.Windows.Forms.ColumnHeader chCategorias;
        private System.Windows.Forms.ColumnHeader chNEcon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbListaCategorias;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEconomias;



    }
}