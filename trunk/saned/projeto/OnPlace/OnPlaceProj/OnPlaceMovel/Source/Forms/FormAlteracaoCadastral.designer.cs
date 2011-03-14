namespace OnPlaceMovel.Source.Forms {
    partial class FormAlteracaoCadastral {
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
            this.btnGravar = new System.Windows.Forms.Button();
            this.lblInfoNrHD = new System.Windows.Forms.Label();
            this.txtNHD = new System.Windows.Forms.TextBox();
            this.lblInfoNrImovel = new System.Windows.Forms.Label();
            this.txtNImovel = new System.Windows.Forms.TextBox();
            this.lblInfoCategoria = new System.Windows.Forms.Label();
            this.cboxListaCategorias = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblInfoSituacao = new System.Windows.Forms.Label();
            this.lstLigacaoCategoria = new System.Windows.Forms.ListView();
            this.colCategorias = new System.Windows.Forms.ColumnHeader();
            this.colTaxas = new System.Windows.Forms.ColumnHeader();
            this.colSituacao = new System.Windows.Forms.ColumnHeader();
            this.colNEcon = new System.Windows.Forms.ColumnHeader();
            this.btnInclui = new System.Windows.Forms.Button();
            this.lblInfoEconomias = new System.Windows.Forms.Label();
            this.txtEconomias = new System.Windows.Forms.TextBox();
            this.cboxListaSituacao = new System.Windows.Forms.ComboBox();
            this.cboxListaTaxas = new System.Windows.Forms.ComboBox();
            this.lblInfoTaxa = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.lblInfoLocalizacao = new System.Windows.Forms.Label();
            this.cboxLocalizacao = new System.Windows.Forms.ComboBox();
            this.lblInfoDigitos = new System.Windows.Forms.Label();
            this.txtDigitos = new System.Windows.Forms.TextBox();
            this.tabMatricula = new System.Windows.Forms.TabPage();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblInfoObservacao = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.lblInfoComplemento = new System.Windows.Forms.Label();
            this.cboxLogradouro = new System.Windows.Forms.ComboBox();
            this.lblInfoLogradouro = new System.Windows.Forms.Label();
            this.lblInfoNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.tabMatricula.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnGravar.Location = new System.Drawing.Point(129, 272);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(50, 20);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblInfoNrHD
            // 
            this.lblInfoNrHD.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoNrHD.Location = new System.Drawing.Point(5, 4);
            this.lblInfoNrHD.Name = "lblInfoNrHD";
            this.lblInfoNrHD.Size = new System.Drawing.Size(70, 11);
            this.lblInfoNrHD.Text = "N° HD";
            // 
            // txtNHD
            // 
            this.txtNHD.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtNHD.Location = new System.Drawing.Point(5, 17);
            this.txtNHD.Name = "txtNHD";
            this.txtNHD.Size = new System.Drawing.Size(81, 19);
            this.txtNHD.TabIndex = 2;
            this.txtNHD.LostFocus += new System.EventHandler(this.tbNHD_LostFocus);
            // 
            // lblInfoNrImovel
            // 
            this.lblInfoNrImovel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoNrImovel.Location = new System.Drawing.Point(156, 107);
            this.lblInfoNrImovel.Name = "lblInfoNrImovel";
            this.lblInfoNrImovel.Size = new System.Drawing.Size(67, 13);
            this.lblInfoNrImovel.Text = "N° do imóvel";
            // 
            // txtNImovel
            // 
            this.txtNImovel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtNImovel.Location = new System.Drawing.Point(156, 122);
            this.txtNImovel.Name = "txtNImovel";
            this.txtNImovel.Size = new System.Drawing.Size(77, 19);
            this.txtNImovel.TabIndex = 4;
            this.txtNImovel.TextChanged += new System.EventHandler(this.tbNImovel_TextChanged);
            // 
            // lblInfoCategoria
            // 
            this.lblInfoCategoria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoCategoria.Location = new System.Drawing.Point(5, 36);
            this.lblInfoCategoria.Name = "lblInfoCategoria";
            this.lblInfoCategoria.Size = new System.Drawing.Size(62, 13);
            this.lblInfoCategoria.Text = "Categorias";
            // 
            // cboxListaCategorias
            // 
            this.cboxListaCategorias.DisplayMember = "1";
            this.cboxListaCategorias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboxListaCategorias.Location = new System.Drawing.Point(5, 49);
            this.cboxListaCategorias.Name = "cboxListaCategorias";
            this.cboxListaCategorias.Size = new System.Drawing.Size(121, 20);
            this.cboxListaCategorias.TabIndex = 8;
            this.cboxListaCategorias.SelectedIndexChanged += new System.EventHandler(this.cbListaCategorias_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnCancelar.Location = new System.Drawing.Point(187, 272);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(52, 20);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Sair";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblInfoSituacao
            // 
            this.lblInfoSituacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoSituacao.Location = new System.Drawing.Point(5, 72);
            this.lblInfoSituacao.Name = "lblInfoSituacao";
            this.lblInfoSituacao.Size = new System.Drawing.Size(51, 14);
            this.lblInfoSituacao.Text = "Situação";
            // 
            // lstLigacaoCategoria
            // 
            this.lstLigacaoCategoria.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstLigacaoCategoria.CheckBoxes = true;
            this.lstLigacaoCategoria.Columns.Add(this.colCategorias);
            this.lstLigacaoCategoria.Columns.Add(this.colTaxas);
            this.lstLigacaoCategoria.Columns.Add(this.colSituacao);
            this.lstLigacaoCategoria.Columns.Add(this.colNEcon);
            this.lstLigacaoCategoria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lstLigacaoCategoria.FullRowSelect = true;
            this.lstLigacaoCategoria.Location = new System.Drawing.Point(5, 111);
            this.lstLigacaoCategoria.Name = "lstLigacaoCategoria";
            this.lstLigacaoCategoria.Size = new System.Drawing.Size(228, 108);
            this.lstLigacaoCategoria.TabIndex = 24;
            this.lstLigacaoCategoria.View = System.Windows.Forms.View.Details;
            this.lstLigacaoCategoria.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvLigacaoCategoria_ItemCheck);
            // 
            // colCategorias
            // 
            this.colCategorias.Text = "Categoria";
            this.colCategorias.Width = 82;
            // 
            // colTaxas
            // 
            this.colTaxas.Text = "Taxa";
            this.colTaxas.Width = 50;
            // 
            // colSituacao
            // 
            this.colSituacao.Text = "Situação";
            this.colSituacao.Width = 53;
            // 
            // colNEcon
            // 
            this.colNEcon.Text = "Eco";
            this.colNEcon.Width = 25;
            // 
            // btnInclui
            // 
            this.btnInclui.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnInclui.Location = new System.Drawing.Point(142, 225);
            this.btnInclui.Name = "btnInclui";
            this.btnInclui.Size = new System.Drawing.Size(44, 15);
            this.btnInclui.TabIndex = 25;
            this.btnInclui.Text = "OK";
            this.btnInclui.Click += new System.EventHandler(this.btnInclui_Click);
            // 
            // lblInfoEconomias
            // 
            this.lblInfoEconomias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoEconomias.Location = new System.Drawing.Point(132, 72);
            this.lblInfoEconomias.Name = "lblInfoEconomias";
            this.lblInfoEconomias.Size = new System.Drawing.Size(101, 11);
            this.lblInfoEconomias.Text = "Economias";
            // 
            // txtEconomias
            // 
            this.txtEconomias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEconomias.Location = new System.Drawing.Point(132, 85);
            this.txtEconomias.Name = "txtEconomias";
            this.txtEconomias.Size = new System.Drawing.Size(101, 19);
            this.txtEconomias.TabIndex = 32;
            this.txtEconomias.TextChanged += new System.EventHandler(this.tbEconomias_TextChanged);
            // 
            // cboxListaSituacao
            // 
            this.cboxListaSituacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboxListaSituacao.Items.Add("Ligado");
            this.cboxListaSituacao.Items.Add("Desligado");
            this.cboxListaSituacao.Location = new System.Drawing.Point(5, 85);
            this.cboxListaSituacao.Name = "cboxListaSituacao";
            this.cboxListaSituacao.Size = new System.Drawing.Size(124, 20);
            this.cboxListaSituacao.TabIndex = 38;
            this.cboxListaSituacao.SelectedIndexChanged += new System.EventHandler(this.cbListaSituacao_SelectedIndexChanged);
            // 
            // cboxListaTaxas
            // 
            this.cboxListaTaxas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboxListaTaxas.Location = new System.Drawing.Point(132, 49);
            this.cboxListaTaxas.Name = "cboxListaTaxas";
            this.cboxListaTaxas.Size = new System.Drawing.Size(101, 20);
            this.cboxListaTaxas.TabIndex = 44;
            this.cboxListaTaxas.SelectedIndexChanged += new System.EventHandler(this.cbListaTaxas_SelectedIndexChanged);
            // 
            // lblInfoTaxa
            // 
            this.lblInfoTaxa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoTaxa.Location = new System.Drawing.Point(132, 36);
            this.lblInfoTaxa.Name = "lblInfoTaxa";
            this.lblInfoTaxa.Size = new System.Drawing.Size(36, 13);
            this.lblInfoTaxa.Text = "Taxa";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnLimpar.Location = new System.Drawing.Point(192, 225);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(44, 15);
            this.btnLimpar.TabIndex = 50;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGeral);
            this.tabControl.Controls.Add(this.tabMatricula);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 266);
            this.tabControl.TabIndex = 57;
            // 
            // tabGeral
            // 
            this.tabGeral.Controls.Add(this.lblInfoLocalizacao);
            this.tabGeral.Controls.Add(this.cboxLocalizacao);
            this.tabGeral.Controls.Add(this.lblInfoDigitos);
            this.tabGeral.Controls.Add(this.txtDigitos);
            this.tabGeral.Controls.Add(this.txtNHD);
            this.tabGeral.Controls.Add(this.btnLimpar);
            this.tabGeral.Controls.Add(this.lblInfoNrHD);
            this.tabGeral.Controls.Add(this.btnInclui);
            this.tabGeral.Controls.Add(this.lblInfoTaxa);
            this.tabGeral.Controls.Add(this.lstLigacaoCategoria);
            this.tabGeral.Controls.Add(this.cboxListaTaxas);
            this.tabGeral.Controls.Add(this.lblInfoCategoria);
            this.tabGeral.Controls.Add(this.cboxListaSituacao);
            this.tabGeral.Controls.Add(this.cboxListaCategorias);
            this.tabGeral.Controls.Add(this.lblInfoEconomias);
            this.tabGeral.Controls.Add(this.lblInfoSituacao);
            this.tabGeral.Controls.Add(this.txtEconomias);
            this.tabGeral.Location = new System.Drawing.Point(0, 0);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Size = new System.Drawing.Size(240, 243);
            this.tabGeral.Text = "Geral";
            // 
            // lblInfoLocalizacao
            // 
            this.lblInfoLocalizacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoLocalizacao.Location = new System.Drawing.Point(129, 4);
            this.lblInfoLocalizacao.Name = "lblInfoLocalizacao";
            this.lblInfoLocalizacao.Size = new System.Drawing.Size(72, 11);
            this.lblInfoLocalizacao.Text = "Localização";
            // 
            // cboxLocalizacao
            // 
            this.cboxLocalizacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboxLocalizacao.Location = new System.Drawing.Point(132, 16);
            this.cboxLocalizacao.Name = "cboxLocalizacao";
            this.cboxLocalizacao.Size = new System.Drawing.Size(101, 20);
            this.cboxLocalizacao.TabIndex = 63;
            // 
            // lblInfoDigitos
            // 
            this.lblInfoDigitos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoDigitos.Location = new System.Drawing.Point(89, 4);
            this.lblInfoDigitos.Name = "lblInfoDigitos";
            this.lblInfoDigitos.Size = new System.Drawing.Size(37, 13);
            this.lblInfoDigitos.Text = "Dígitos";
            // 
            // txtDigitos
            // 
            this.txtDigitos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDigitos.Location = new System.Drawing.Point(89, 17);
            this.txtDigitos.Name = "txtDigitos";
            this.txtDigitos.Size = new System.Drawing.Size(40, 19);
            this.txtDigitos.TabIndex = 57;
            this.txtDigitos.TextChanged += new System.EventHandler(this.tbDigitos_TextChanged);
            // 
            // tabMatricula
            // 
            this.tabMatricula.Controls.Add(this.txtObservacao);
            this.tabMatricula.Controls.Add(this.lblInfoObservacao);
            this.tabMatricula.Controls.Add(this.txtComplemento);
            this.tabMatricula.Controls.Add(this.lblInfoComplemento);
            this.tabMatricula.Controls.Add(this.cboxLogradouro);
            this.tabMatricula.Controls.Add(this.lblInfoLogradouro);
            this.tabMatricula.Controls.Add(this.lblInfoNome);
            this.tabMatricula.Controls.Add(this.txtNome);
            this.tabMatricula.Controls.Add(this.txtNImovel);
            this.tabMatricula.Controls.Add(this.lblInfoNrImovel);
            this.tabMatricula.Location = new System.Drawing.Point(0, 0);
            this.tabMatricula.Name = "tabMatricula";
            this.tabMatricula.Size = new System.Drawing.Size(240, 243);
            this.tabMatricula.Text = "Dados Matrícula";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtObservacao.Location = new System.Drawing.Point(7, 159);
            this.txtObservacao.MaxLength = 40;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(226, 57);
            this.txtObservacao.TabIndex = 17;
            // 
            // lblInfoObservacao
            // 
            this.lblInfoObservacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoObservacao.Location = new System.Drawing.Point(7, 144);
            this.lblInfoObservacao.Name = "lblInfoObservacao";
            this.lblInfoObservacao.Size = new System.Drawing.Size(100, 15);
            this.lblInfoObservacao.Text = "Observação:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtComplemento.Location = new System.Drawing.Point(7, 122);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(143, 19);
            this.txtComplemento.TabIndex = 11;
            // 
            // lblInfoComplemento
            // 
            this.lblInfoComplemento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoComplemento.Location = new System.Drawing.Point(7, 107);
            this.lblInfoComplemento.Name = "lblInfoComplemento";
            this.lblInfoComplemento.Size = new System.Drawing.Size(100, 15);
            this.lblInfoComplemento.Text = "Complemento";
            // 
            // cboxLogradouro
            // 
            this.cboxLogradouro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboxLogradouro.Location = new System.Drawing.Point(7, 71);
            this.cboxLogradouro.Name = "cboxLogradouro";
            this.cboxLogradouro.Size = new System.Drawing.Size(226, 20);
            this.cboxLogradouro.TabIndex = 9;
            // 
            // lblInfoLogradouro
            // 
            this.lblInfoLogradouro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoLogradouro.Location = new System.Drawing.Point(7, 55);
            this.lblInfoLogradouro.Name = "lblInfoLogradouro";
            this.lblInfoLogradouro.Size = new System.Drawing.Size(65, 13);
            this.lblInfoLogradouro.Text = "Logradouro";
            // 
            // lblInfoNome
            // 
            this.lblInfoNome.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoNome.Location = new System.Drawing.Point(7, 8);
            this.lblInfoNome.Name = "lblInfoNome";
            this.lblInfoNome.Size = new System.Drawing.Size(100, 12);
            this.lblInfoNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtNome.Location = new System.Drawing.Point(7, 23);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(226, 19);
            this.txtNome.TabIndex = 6;
            // 
            // FormAlteracaoCadastral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FormAlteracaoCadastral";
            this.Text = "OnPlaceMovel - Alteração Cadastral";
            this.Activated += new System.EventHandler(this.AlteracaoCadastral_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormAlteracaoCadastral_KeyUp);
            this.tabControl.ResumeLayout(false);
            this.tabGeral.ResumeLayout(false);
            this.tabMatricula.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label lblInfoNrHD;
        private System.Windows.Forms.TextBox txtNHD;
        private System.Windows.Forms.Label lblInfoNrImovel;
        private System.Windows.Forms.TextBox txtNImovel;
        private System.Windows.Forms.Label lblInfoCategoria;
        private System.Windows.Forms.ComboBox cboxListaCategorias;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblInfoSituacao;
        private System.Windows.Forms.ListView lstLigacaoCategoria;
        private System.Windows.Forms.Button btnInclui;
        private System.Windows.Forms.ColumnHeader colCategorias;
        private System.Windows.Forms.ColumnHeader colSituacao;
        private System.Windows.Forms.ColumnHeader colNEcon;
        private System.Windows.Forms.Label lblInfoEconomias;
        private System.Windows.Forms.TextBox txtEconomias;
        private System.Windows.Forms.ComboBox cboxListaSituacao;
        private System.Windows.Forms.ColumnHeader colTaxas;
        private System.Windows.Forms.ComboBox cboxListaTaxas;
        private System.Windows.Forms.Label lblInfoTaxa;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGeral;
        private System.Windows.Forms.TabPage tabMatricula;
        private System.Windows.Forms.Label lblInfoDigitos;
        private System.Windows.Forms.TextBox txtDigitos;
        private System.Windows.Forms.ComboBox cboxLogradouro;
        private System.Windows.Forms.Label lblInfoLogradouro;
        private System.Windows.Forms.Label lblInfoNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label lblInfoComplemento;
        private System.Windows.Forms.Label lblInfoLocalizacao;
        private System.Windows.Forms.ComboBox cboxLocalizacao;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblInfoObservacao;
    }
}