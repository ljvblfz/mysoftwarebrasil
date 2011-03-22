namespace SPCadMobile.View
{
    partial class frmPontoServHidrometro : CustomFormAba
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPontoServHidrometro));
            this.tabPadrao = new System.Windows.Forms.TabPage();
            this.cbxTorneiraPadrao = new System.Windows.Forms.ComboBox();
            this.bindingSourceCadastro = new System.Windows.Forms.BindingSource(this.components);
            this.cbxEliminadorAr = new System.Windows.Forms.ComboBox();
            this.cbxPadraoLacrado = new System.Windows.Forms.ComboBox();
            this.lblTorneiraPadrao = new System.Windows.Forms.Label();
            this.lblEliminadorAr = new System.Windows.Forms.Label();
            this.lblPadraoLacrado = new System.Windows.Forms.Label();
            this.cbxTipoPadrao = new System.Windows.Forms.ComboBox();
            this.lblTipoPadrao = new System.Windows.Forms.Label();
            this.cbxLocalPadrao = new System.Windows.Forms.ComboBox();
            this.lblLocalPadrao = new System.Windows.Forms.Label();
            this.cbxSitPontoServico = new System.Windows.Forms.ComboBox();
            this.tbxPontoServico = new System.Windows.Forms.TextBox();
            this.lblPontoServico = new System.Windows.Forms.Label();
            this.lblSitPontoServico = new System.Windows.Forms.Label();
            this.tabMedidor = new System.Windows.Forms.TabPage();
            this.cbxPossuiMedidorSN = new System.Windows.Forms.ComboBox();
            this.tbxNumMedidor = new System.Windows.Forms.TextBox();
            this.lblNumMedidor = new System.Windows.Forms.Label();
            this.cbxPSegLigacao = new System.Windows.Forms.ComboBox();
            this.lblPSegLigacao = new System.Windows.Forms.Label();
            this.panelLeitura = new System.Windows.Forms.Panel();
            this.cbxQuantidade = new System.Windows.Forms.ComboBox();
            this.tbxCapacidade = new System.Windows.Forms.TextBox();
            this.lblCapacidade = new System.Windows.Forms.Label();
            this.tbxFabricante = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.cbxHidrometroLacrado = new System.Windows.Forms.ComboBox();
            this.lblHidrometroLacrado = new System.Windows.Forms.Label();
            this.lupa = new MobileTools.Controls.UltraButton();
            this.tbxLeitura = new System.Windows.Forms.TextBox();
            this.lblLeitura = new System.Windows.Forms.Label();
            this.lblDigitos = new System.Windows.Forms.Label();
            this.cbxClasseMetrologica = new System.Windows.Forms.ComboBox();
            this.lblClasseMetrologica = new System.Windows.Forms.Label();
            this.lblPSMedidor = new System.Windows.Forms.Label();
            this.tabInfAdicional = new System.Windows.Forms.TabPage();
            this.btnFotos = new System.Windows.Forms.Button();
            this.btnOcorrencia = new System.Windows.Forms.Button();
            this.tbxInfComplementar = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tabMedidor2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxQuantidade2 = new System.Windows.Forms.ComboBox();
            this.tbxCapacidade2 = new System.Windows.Forms.TextBox();
            this.lblCapacidade2 = new System.Windows.Forms.Label();
            this.tbxFabricante2 = new System.Windows.Forms.TextBox();
            this.lblFabricante2 = new System.Windows.Forms.Label();
            this.cbxHidrometroLacrado2 = new System.Windows.Forms.ComboBox();
            this.lblHidrometroLacrado2 = new System.Windows.Forms.Label();
            this.lupa2 = new MobileTools.Controls.UltraButton();
            this.tbxLeitura2 = new System.Windows.Forms.TextBox();
            this.lblLeitura2 = new System.Windows.Forms.Label();
            this.lblDigitos2 = new System.Windows.Forms.Label();
            this.cbxClasseMetrologica2 = new System.Windows.Forms.ComboBox();
            this.lblClasseMetrologica2 = new System.Windows.Forms.Label();
            this.tbxNumMedidor2 = new System.Windows.Forms.TextBox();
            this.lblNumMedidor2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).BeginInit();
            this.tabMedidor.SuspendLayout();
            this.panelLeitura.SuspendLayout();
            this.tabInfAdicional.SuspendLayout();
            this.tabMedidor2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPadrao);
            this.tabControl1.Controls.Add(this.tabMedidor);
            this.tabControl1.Controls.Add(this.tabMedidor2);
            this.tabControl1.Controls.Add(this.tabInfAdicional);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Size = new System.Drawing.Size(239, 259);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPadrao
            // 
            this.tabPadrao.Controls.Add(this.cbxTorneiraPadrao);
            this.tabPadrao.Controls.Add(this.cbxEliminadorAr);
            this.tabPadrao.Controls.Add(this.cbxPadraoLacrado);
            this.tabPadrao.Controls.Add(this.lblTorneiraPadrao);
            this.tabPadrao.Controls.Add(this.lblEliminadorAr);
            this.tabPadrao.Controls.Add(this.lblPadraoLacrado);
            this.tabPadrao.Controls.Add(this.cbxTipoPadrao);
            this.tabPadrao.Controls.Add(this.lblTipoPadrao);
            this.tabPadrao.Controls.Add(this.cbxLocalPadrao);
            this.tabPadrao.Controls.Add(this.lblLocalPadrao);
            this.tabPadrao.Controls.Add(this.cbxSitPontoServico);
            this.tabPadrao.Controls.Add(this.tbxPontoServico);
            this.tabPadrao.Controls.Add(this.lblPontoServico);
            this.tabPadrao.Controls.Add(this.lblSitPontoServico);
            this.tabPadrao.Location = new System.Drawing.Point(0, 0);
            this.tabPadrao.Name = "tabPadrao";
            this.tabPadrao.Size = new System.Drawing.Size(239, 236);
            this.tabPadrao.Text = "Padrão";
            // 
            // cbxTorneiraPadrao
            // 
            this.cbxTorneiraPadrao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "PossuiTorneiraPadrao", true));
            this.cbxTorneiraPadrao.DisplayMember = "Description";
            this.cbxTorneiraPadrao.Location = new System.Drawing.Point(161, 174);
            this.cbxTorneiraPadrao.Name = "cbxTorneiraPadrao";
            this.cbxTorneiraPadrao.Size = new System.Drawing.Size(74, 22);
            this.cbxTorneiraPadrao.TabIndex = 200;
            this.cbxTorneiraPadrao.ValueMember = "Value";
            // 
            // bindingSourceCadastro
            // 
            this.bindingSourceCadastro.DataSource = typeof(SPCadMobileData.Data.Model.Cadastro);
            // 
            // cbxEliminadorAr
            // 
            this.cbxEliminadorAr.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "EliminadorAr", true));
            this.cbxEliminadorAr.DisplayMember = "Description";
            this.cbxEliminadorAr.Location = new System.Drawing.Point(159, 146);
            this.cbxEliminadorAr.Name = "cbxEliminadorAr";
            this.cbxEliminadorAr.Size = new System.Drawing.Size(76, 22);
            this.cbxEliminadorAr.TabIndex = 199;
            this.cbxEliminadorAr.ValueMember = "Value";
            // 
            // cbxPadraoLacrado
            // 
            this.cbxPadraoLacrado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "PadraoLacrado", true));
            this.cbxPadraoLacrado.DisplayMember = "Description";
            this.cbxPadraoLacrado.Location = new System.Drawing.Point(159, 118);
            this.cbxPadraoLacrado.Name = "cbxPadraoLacrado";
            this.cbxPadraoLacrado.Size = new System.Drawing.Size(76, 22);
            this.cbxPadraoLacrado.TabIndex = 198;
            this.cbxPadraoLacrado.ValueMember = "Value";
            // 
            // lblTorneiraPadrao
            // 
            this.lblTorneiraPadrao.Location = new System.Drawing.Point(7, 177);
            this.lblTorneiraPadrao.Name = "lblTorneiraPadrao";
            this.lblTorneiraPadrao.Size = new System.Drawing.Size(150, 19);
            this.lblTorneiraPadrao.Text = "Possui torneira no Padrão:";
            // 
            // lblEliminadorAr
            // 
            this.lblEliminadorAr.Location = new System.Drawing.Point(7, 148);
            this.lblEliminadorAr.Name = "lblEliminadorAr";
            this.lblEliminadorAr.Size = new System.Drawing.Size(146, 20);
            this.lblEliminadorAr.Text = "Possui Eliminador de ar:";
            // 
            // lblPadraoLacrado
            // 
            this.lblPadraoLacrado.Location = new System.Drawing.Point(53, 118);
            this.lblPadraoLacrado.Name = "lblPadraoLacrado";
            this.lblPadraoLacrado.Size = new System.Drawing.Size(100, 20);
            this.lblPadraoLacrado.Text = "Padrão Lacrado:";
            // 
            // cbxTipoPadrao
            // 
            this.cbxTipoPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTipoPadrao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "TipoPadraoAlter", true));
            this.cbxTipoPadrao.DisplayMember = "Description";
            this.cbxTipoPadrao.Location = new System.Drawing.Point(76, 90);
            this.cbxTipoPadrao.Name = "cbxTipoPadrao";
            this.cbxTipoPadrao.Size = new System.Drawing.Size(159, 22);
            this.cbxTipoPadrao.TabIndex = 175;
            this.cbxTipoPadrao.ValueMember = "Value";
            // 
            // lblTipoPadrao
            // 
            this.lblTipoPadrao.Location = new System.Drawing.Point(3, 94);
            this.lblTipoPadrao.Name = "lblTipoPadrao";
            this.lblTipoPadrao.Size = new System.Drawing.Size(74, 15);
            this.lblTipoPadrao.Text = "Tipo Padrão:";
            // 
            // cbxLocalPadrao
            // 
            this.cbxLocalPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLocalPadrao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "LocalizacaoPadraoAlter", true));
            this.cbxLocalPadrao.DisplayMember = "Description";
            this.cbxLocalPadrao.Location = new System.Drawing.Point(85, 62);
            this.cbxLocalPadrao.Name = "cbxLocalPadrao";
            this.cbxLocalPadrao.Size = new System.Drawing.Size(150, 22);
            this.cbxLocalPadrao.TabIndex = 168;
            this.cbxLocalPadrao.ValueMember = "Value";
            // 
            // lblLocalPadrao
            // 
            this.lblLocalPadrao.Location = new System.Drawing.Point(3, 66);
            this.lblLocalPadrao.Name = "lblLocalPadrao";
            this.lblLocalPadrao.Size = new System.Drawing.Size(78, 15);
            this.lblLocalPadrao.Text = "Local Padrão:";
            // 
            // cbxSitPontoServico
            // 
            this.cbxSitPontoServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSitPontoServico.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "SituacaoPontoServicoAlter", true));
            this.cbxSitPontoServico.DisplayMember = "Description";
            this.cbxSitPontoServico.Location = new System.Drawing.Point(94, 34);
            this.cbxSitPontoServico.Name = "cbxSitPontoServico";
            this.cbxSitPontoServico.Size = new System.Drawing.Size(141, 22);
            this.cbxSitPontoServico.TabIndex = 167;
            this.cbxSitPontoServico.ValueMember = "Value";
            // 
            // tbxPontoServico
            // 
            this.tbxPontoServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NumeroPontoServico", true));
            this.tbxPontoServico.Location = new System.Drawing.Point(94, 7);
            this.tbxPontoServico.Name = "tbxPontoServico";
            this.tbxPontoServico.ReadOnly = true;
            this.tbxPontoServico.Size = new System.Drawing.Size(59, 21);
            this.tbxPontoServico.TabIndex = 166;
            // 
            // lblPontoServico
            // 
            this.lblPontoServico.Location = new System.Drawing.Point(6, 9);
            this.lblPontoServico.Name = "lblPontoServico";
            this.lblPontoServico.Size = new System.Drawing.Size(85, 15);
            this.lblPontoServico.Text = "Nº Pto. Serv.:";
            // 
            // lblSitPontoServico
            // 
            this.lblSitPontoServico.Location = new System.Drawing.Point(5, 37);
            this.lblSitPontoServico.Name = "lblSitPontoServico";
            this.lblSitPontoServico.Size = new System.Drawing.Size(85, 15);
            this.lblSitPontoServico.Text = "Sit. Pto. Serv.:";
            // 
            // tabMedidor
            // 
            this.tabMedidor.Controls.Add(this.cbxPossuiMedidorSN);
            this.tabMedidor.Controls.Add(this.tbxNumMedidor);
            this.tabMedidor.Controls.Add(this.lblNumMedidor);
            this.tabMedidor.Controls.Add(this.cbxPSegLigacao);
            this.tabMedidor.Controls.Add(this.lblPSegLigacao);
            this.tabMedidor.Controls.Add(this.panelLeitura);
            this.tabMedidor.Controls.Add(this.lblPSMedidor);
            this.tabMedidor.Location = new System.Drawing.Point(0, 0);
            this.tabMedidor.Name = "tabMedidor";
            this.tabMedidor.Size = new System.Drawing.Size(232, 233);
            this.tabMedidor.Text = "Medidor";
            // 
            // cbxPossuiMedidorSN
            // 
            this.cbxPossuiMedidorSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPossuiMedidorSN.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "ExisteMedidor", true));
            this.cbxPossuiMedidorSN.DisplayMember = "Description";
            this.cbxPossuiMedidorSN.Location = new System.Drawing.Point(121, 3);
            this.cbxPossuiMedidorSN.Name = "cbxPossuiMedidorSN";
            this.cbxPossuiMedidorSN.Size = new System.Drawing.Size(75, 22);
            this.cbxPossuiMedidorSN.TabIndex = 238;
            this.cbxPossuiMedidorSN.ValueMember = "Value";
            this.cbxPossuiMedidorSN.SelectedValueChanged += new System.EventHandler(this.rbNao_CheckedChanged);
            // 
            // tbxNumMedidor
            // 
            this.tbxNumMedidor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNumMedidor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NumeroMedidorAlter", true));
            this.tbxNumMedidor.Location = new System.Drawing.Point(128, 28);
            this.tbxNumMedidor.MaxLength = 13;
            this.tbxNumMedidor.Name = "tbxNumMedidor";
            this.tbxNumMedidor.Size = new System.Drawing.Size(95, 21);
            this.tbxNumMedidor.TabIndex = 233;
            this.tbxNumMedidor.TextChanged += new System.EventHandler(this.tbxNumMedidor_TextChanged);
            this.tbxNumMedidor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxNumMedidor_KeyUp);
            // 
            // lblNumMedidor
            // 
            this.lblNumMedidor.Location = new System.Drawing.Point(7, 29);
            this.lblNumMedidor.Name = "lblNumMedidor";
            this.lblNumMedidor.Size = new System.Drawing.Size(114, 15);
            this.lblNumMedidor.Text = "Nº Medidor:";
            // 
            // cbxPSegLigacao
            // 
            this.cbxPSegLigacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPSegLigacao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "SegundaLigacao", true));
            this.cbxPSegLigacao.DisplayMember = "Description";
            this.cbxPSegLigacao.Location = new System.Drawing.Point(177, 211);
            this.cbxPSegLigacao.Name = "cbxPSegLigacao";
            this.cbxPSegLigacao.Size = new System.Drawing.Size(46, 22);
            this.cbxPSegLigacao.TabIndex = 228;
            this.cbxPSegLigacao.ValueMember = "Value";
            // 
            // lblPSegLigacao
            // 
            this.lblPSegLigacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPSegLigacao.Location = new System.Drawing.Point(0, 215);
            this.lblPSegLigacao.Name = "lblPSegLigacao";
            this.lblPSegLigacao.Size = new System.Drawing.Size(160, 15);
            this.lblPSegLigacao.Text = "Possui segunda Ligação:";
            this.lblPSegLigacao.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelLeitura
            // 
            this.panelLeitura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeitura.Controls.Add(this.cbxQuantidade);
            this.panelLeitura.Controls.Add(this.tbxCapacidade);
            this.panelLeitura.Controls.Add(this.lblCapacidade);
            this.panelLeitura.Controls.Add(this.tbxFabricante);
            this.panelLeitura.Controls.Add(this.lblFabricante);
            this.panelLeitura.Controls.Add(this.cbxHidrometroLacrado);
            this.panelLeitura.Controls.Add(this.lblHidrometroLacrado);
            this.panelLeitura.Controls.Add(this.lupa);
            this.panelLeitura.Controls.Add(this.tbxLeitura);
            this.panelLeitura.Controls.Add(this.lblLeitura);
            this.panelLeitura.Controls.Add(this.lblDigitos);
            this.panelLeitura.Controls.Add(this.cbxClasseMetrologica);
            this.panelLeitura.Controls.Add(this.lblClasseMetrologica);
            this.panelLeitura.Location = new System.Drawing.Point(0, 52);
            this.panelLeitura.Name = "panelLeitura";
            this.panelLeitura.Size = new System.Drawing.Size(232, 157);
            // 
            // cbxQuantidade
            // 
            this.cbxQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxQuantidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "QtdeDigitosMedidorAlter", true));
            this.cbxQuantidade.Items.Add("");
            this.cbxQuantidade.Items.Add("4");
            this.cbxQuantidade.Items.Add("5");
            this.cbxQuantidade.Items.Add("6");
            this.cbxQuantidade.Items.Add("7");
            this.cbxQuantidade.Items.Add("8");
            this.cbxQuantidade.Items.Add("9");
            this.cbxQuantidade.Location = new System.Drawing.Point(184, 75);
            this.cbxQuantidade.Name = "cbxQuantidade";
            this.cbxQuantidade.Size = new System.Drawing.Size(46, 22);
            this.cbxQuantidade.TabIndex = 242;
            this.cbxQuantidade.SelectedIndexChanged += new System.EventHandler(this.tbxLeitura_TextChanged);
            // 
            // tbxCapacidade
            // 
            this.tbxCapacidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCapacidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Capacidade1", true));
            this.tbxCapacidade.Location = new System.Drawing.Point(184, 49);
            this.tbxCapacidade.MaxLength = 2;
            this.tbxCapacidade.Name = "tbxCapacidade";
            this.tbxCapacidade.ReadOnly = true;
            this.tbxCapacidade.Size = new System.Drawing.Size(46, 21);
            this.tbxCapacidade.TabIndex = 235;
            // 
            // lblCapacidade
            // 
            this.lblCapacidade.Location = new System.Drawing.Point(95, 50);
            this.lblCapacidade.Name = "lblCapacidade";
            this.lblCapacidade.Size = new System.Drawing.Size(72, 15);
            this.lblCapacidade.Text = "Capacidade:";
            this.lblCapacidade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxFabricante
            // 
            this.tbxFabricante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFabricante.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Fabricante1", true));
            this.tbxFabricante.Location = new System.Drawing.Point(41, 26);
            this.tbxFabricante.MaxLength = 2;
            this.tbxFabricante.Name = "tbxFabricante";
            this.tbxFabricante.ReadOnly = true;
            this.tbxFabricante.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFabricante.Size = new System.Drawing.Size(189, 21);
            this.tbxFabricante.TabIndex = 232;
            // 
            // lblFabricante
            // 
            this.lblFabricante.Location = new System.Drawing.Point(6, 27);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(32, 15);
            this.lblFabricante.Text = "Fab.:";
            // 
            // cbxHidrometroLacrado
            // 
            this.cbxHidrometroLacrado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxHidrometroLacrado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "MedidorLacrado", true));
            this.cbxHidrometroLacrado.DisplayMember = "Description";
            this.cbxHidrometroLacrado.Location = new System.Drawing.Point(177, 131);
            this.cbxHidrometroLacrado.Name = "cbxHidrometroLacrado";
            this.cbxHidrometroLacrado.Size = new System.Drawing.Size(46, 22);
            this.cbxHidrometroLacrado.TabIndex = 226;
            this.cbxHidrometroLacrado.ValueMember = "Value";
            // 
            // lblHidrometroLacrado
            // 
            this.lblHidrometroLacrado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHidrometroLacrado.Location = new System.Drawing.Point(41, 135);
            this.lblHidrometroLacrado.Name = "lblHidrometroLacrado";
            this.lblHidrometroLacrado.Size = new System.Drawing.Size(119, 15);
            this.lblHidrometroLacrado.Text = "Hidrômetro Lacrado:";
            this.lblHidrometroLacrado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lupa
            // 
            this.lupa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lupa.BorderColor = System.Drawing.Color.Transparent;
            this.lupa.ButtonColor = System.Drawing.Color.White;
            this.lupa.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.lupa.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("lupa.ImageButton")));
            this.lupa.ImageButtonView = true;
            this.lupa.Location = new System.Drawing.Point(208, 3);
            this.lupa.Name = "lupa";
            this.lupa.Radius = 8;
            this.lupa.Size = new System.Drawing.Size(18, 21);
            this.lupa.TabIndex = 221;
            this.lupa.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.lupa.TextColor = System.Drawing.SystemColors.WindowText;
            this.lupa.TextColorClick = System.Drawing.Color.White;
            this.lupa.Click += new System.EventHandler(this.lupa_Click);
            // 
            // tbxLeitura
            // 
            this.tbxLeitura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLeitura.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Leitura", true));
            this.tbxLeitura.Location = new System.Drawing.Point(127, 2);
            this.tbxLeitura.MaxLength = 2;
            this.tbxLeitura.Name = "tbxLeitura";
            this.tbxLeitura.ReadOnly = true;
            this.tbxLeitura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLeitura.Size = new System.Drawing.Size(76, 21);
            this.tbxLeitura.TabIndex = 220;
            this.tbxLeitura.TextChanged += new System.EventHandler(this.tbxLeitura_TextChanged);
            // 
            // lblLeitura
            // 
            this.lblLeitura.Location = new System.Drawing.Point(6, 3);
            this.lblLeitura.Name = "lblLeitura";
            this.lblLeitura.Size = new System.Drawing.Size(115, 15);
            this.lblLeitura.Text = "Leitura:";
            // 
            // lblDigitos
            // 
            this.lblDigitos.Location = new System.Drawing.Point(48, 77);
            this.lblDigitos.Name = "lblDigitos";
            this.lblDigitos.Size = new System.Drawing.Size(119, 15);
            this.lblDigitos.Text = "Quantidade Dígitos:";
            this.lblDigitos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxClasseMetrologica
            // 
            this.cbxClasseMetrologica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxClasseMetrologica.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "ClasseMetrologicaAlter", true));
            this.cbxClasseMetrologica.DisplayMember = "Description";
            this.cbxClasseMetrologica.Location = new System.Drawing.Point(177, 103);
            this.cbxClasseMetrologica.Name = "cbxClasseMetrologica";
            this.cbxClasseMetrologica.Size = new System.Drawing.Size(46, 22);
            this.cbxClasseMetrologica.TabIndex = 217;
            this.cbxClasseMetrologica.ValueMember = "Value";
            // 
            // lblClasseMetrologica
            // 
            this.lblClasseMetrologica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClasseMetrologica.Location = new System.Drawing.Point(41, 107);
            this.lblClasseMetrologica.Name = "lblClasseMetrologica";
            this.lblClasseMetrologica.Size = new System.Drawing.Size(119, 15);
            this.lblClasseMetrologica.Text = "Classe Metrológica:";
            this.lblClasseMetrologica.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPSMedidor
            // 
            this.lblPSMedidor.Location = new System.Drawing.Point(7, 4);
            this.lblPSMedidor.Name = "lblPSMedidor";
            this.lblPSMedidor.Size = new System.Drawing.Size(114, 15);
            this.lblPSMedidor.Text = "P.S. com Medidor:";
            // 
            // tabInfAdicional
            // 
            this.tabInfAdicional.Controls.Add(this.btnFotos);
            this.tabInfAdicional.Controls.Add(this.btnOcorrencia);
            this.tabInfAdicional.Controls.Add(this.tbxInfComplementar);
            this.tabInfAdicional.Controls.Add(this.label24);
            this.tabInfAdicional.Location = new System.Drawing.Point(0, 0);
            this.tabInfAdicional.Name = "tabInfAdicional";
            this.tabInfAdicional.Size = new System.Drawing.Size(232, 233);
            this.tabInfAdicional.Text = "Inf. Adicional";
            // 
            // btnFotos
            // 
            this.btnFotos.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFotos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnFotos.Location = new System.Drawing.Point(118, 114);
            this.btnFotos.Name = "btnFotos";
            this.btnFotos.Size = new System.Drawing.Size(95, 20);
            this.btnFotos.TabIndex = 202;
            this.btnFotos.Text = "Fotos";
            this.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);
            // 
            // btnOcorrencia
            // 
            this.btnOcorrencia.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOcorrencia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOcorrencia.Location = new System.Drawing.Point(17, 114);
            this.btnOcorrencia.Name = "btnOcorrencia";
            this.btnOcorrencia.Size = new System.Drawing.Size(95, 20);
            this.btnOcorrencia.TabIndex = 201;
            this.btnOcorrencia.Text = "Ocorrências";
            this.btnOcorrencia.Click += new System.EventHandler(this.btnOcorrencia_Click);
            // 
            // tbxInfComplementar
            // 
            this.tbxInfComplementar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfComplementar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "ObservacaoVisita", true));
            this.tbxInfComplementar.Location = new System.Drawing.Point(3, 22);
            this.tbxInfComplementar.MaxLength = 300;
            this.tbxInfComplementar.Multiline = true;
            this.tbxInfComplementar.Name = "tbxInfComplementar";
            this.tbxInfComplementar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfComplementar.Size = new System.Drawing.Size(226, 86);
            this.tbxInfComplementar.TabIndex = 200;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(7, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(162, 15);
            this.label24.Text = "Informação Adicional:";
            // 
            // tabMedidor2
            // 
            this.tabMedidor2.Controls.Add(this.panel2);
            this.tabMedidor2.Controls.Add(this.tbxNumMedidor2);
            this.tabMedidor2.Controls.Add(this.lblNumMedidor2);
            this.tabMedidor2.Location = new System.Drawing.Point(0, 0);
            this.tabMedidor2.Name = "tabMedidor2";
            this.tabMedidor2.Size = new System.Drawing.Size(232, 233);
            this.tabMedidor2.Text = "2ª Ligação";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cbxQuantidade2);
            this.panel2.Controls.Add(this.tbxCapacidade2);
            this.panel2.Controls.Add(this.lblCapacidade2);
            this.panel2.Controls.Add(this.tbxFabricante2);
            this.panel2.Controls.Add(this.lblFabricante2);
            this.panel2.Controls.Add(this.cbxHidrometroLacrado2);
            this.panel2.Controls.Add(this.lblHidrometroLacrado2);
            this.panel2.Controls.Add(this.lupa2);
            this.panel2.Controls.Add(this.tbxLeitura2);
            this.panel2.Controls.Add(this.lblLeitura2);
            this.panel2.Controls.Add(this.lblDigitos2);
            this.panel2.Controls.Add(this.cbxClasseMetrologica2);
            this.panel2.Controls.Add(this.lblClasseMetrologica2);
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 157);
            // 
            // cbxQuantidade2
            // 
            this.cbxQuantidade2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxQuantidade2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "QtdeDigitosMedidor2", true));
            this.cbxQuantidade2.Items.Add("");
            this.cbxQuantidade2.Items.Add("4");
            this.cbxQuantidade2.Items.Add("5");
            this.cbxQuantidade2.Items.Add("6");
            this.cbxQuantidade2.Items.Add("7");
            this.cbxQuantidade2.Items.Add("8");
            this.cbxQuantidade2.Items.Add("9");
            this.cbxQuantidade2.Location = new System.Drawing.Point(177, 76);
            this.cbxQuantidade2.Name = "cbxQuantidade2";
            this.cbxQuantidade2.Size = new System.Drawing.Size(46, 22);
            this.cbxQuantidade2.TabIndex = 242;
            this.cbxQuantidade2.SelectedIndexChanged += new System.EventHandler(this.tbxLeitura2_TextChanged);
            // 
            // tbxCapacidade2
            // 
            this.tbxCapacidade2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCapacidade2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Capacidade2", true));
            this.tbxCapacidade2.Location = new System.Drawing.Point(177, 49);
            this.tbxCapacidade2.MaxLength = 2;
            this.tbxCapacidade2.Name = "tbxCapacidade2";
            this.tbxCapacidade2.ReadOnly = true;
            this.tbxCapacidade2.Size = new System.Drawing.Size(46, 21);
            this.tbxCapacidade2.TabIndex = 235;
            // 
            // lblCapacidade2
            // 
            this.lblCapacidade2.Location = new System.Drawing.Point(95, 50);
            this.lblCapacidade2.Name = "lblCapacidade2";
            this.lblCapacidade2.Size = new System.Drawing.Size(72, 15);
            this.lblCapacidade2.Text = "Capacidade:";
            this.lblCapacidade2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxFabricante2
            // 
            this.tbxFabricante2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFabricante2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Fabricante2", true));
            this.tbxFabricante2.Location = new System.Drawing.Point(41, 26);
            this.tbxFabricante2.MaxLength = 2;
            this.tbxFabricante2.Name = "tbxFabricante2";
            this.tbxFabricante2.ReadOnly = true;
            this.tbxFabricante2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFabricante2.Size = new System.Drawing.Size(182, 21);
            this.tbxFabricante2.TabIndex = 232;
            // 
            // lblFabricante2
            // 
            this.lblFabricante2.Location = new System.Drawing.Point(6, 27);
            this.lblFabricante2.Name = "lblFabricante2";
            this.lblFabricante2.Size = new System.Drawing.Size(32, 15);
            this.lblFabricante2.Text = "Fab.:";
            // 
            // cbxHidrometroLacrado2
            // 
            this.cbxHidrometroLacrado2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxHidrometroLacrado2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "MedidorLacrado2", true));
            this.cbxHidrometroLacrado2.DisplayMember = "Description";
            this.cbxHidrometroLacrado2.Items.Add("Sim");
            this.cbxHidrometroLacrado2.Items.Add("Não");
            this.cbxHidrometroLacrado2.Location = new System.Drawing.Point(177, 131);
            this.cbxHidrometroLacrado2.Name = "cbxHidrometroLacrado2";
            this.cbxHidrometroLacrado2.Size = new System.Drawing.Size(46, 22);
            this.cbxHidrometroLacrado2.TabIndex = 226;
            this.cbxHidrometroLacrado2.ValueMember = "Value";
            // 
            // lblHidrometroLacrado2
            // 
            this.lblHidrometroLacrado2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHidrometroLacrado2.Location = new System.Drawing.Point(41, 135);
            this.lblHidrometroLacrado2.Name = "lblHidrometroLacrado2";
            this.lblHidrometroLacrado2.Size = new System.Drawing.Size(119, 15);
            this.lblHidrometroLacrado2.Text = "Hidrômetro Lacrado:";
            this.lblHidrometroLacrado2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lupa2
            // 
            this.lupa2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lupa2.BorderColor = System.Drawing.Color.Transparent;
            this.lupa2.ButtonColor = System.Drawing.Color.White;
            this.lupa2.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.lupa2.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("lupa2.ImageButton")));
            this.lupa2.ImageButtonView = true;
            this.lupa2.Location = new System.Drawing.Point(202, 3);
            this.lupa2.Name = "lupa2";
            this.lupa2.Radius = 8;
            this.lupa2.Size = new System.Drawing.Size(23, 21);
            this.lupa2.TabIndex = 221;
            this.lupa2.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.lupa2.TextColor = System.Drawing.SystemColors.WindowText;
            this.lupa2.TextColorClick = System.Drawing.Color.White;
            this.lupa2.Click += new System.EventHandler(this.lupa2_Click);
            // 
            // tbxLeitura2
            // 
            this.tbxLeitura2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLeitura2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Leitura2", true));
            this.tbxLeitura2.Location = new System.Drawing.Point(120, 2);
            this.tbxLeitura2.MaxLength = 2;
            this.tbxLeitura2.Name = "tbxLeitura2";
            this.tbxLeitura2.ReadOnly = true;
            this.tbxLeitura2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLeitura2.Size = new System.Drawing.Size(76, 21);
            this.tbxLeitura2.TabIndex = 220;
            this.tbxLeitura2.TextChanged += new System.EventHandler(this.tbxLeitura2_TextChanged);
            // 
            // lblLeitura2
            // 
            this.lblLeitura2.Location = new System.Drawing.Point(6, 3);
            this.lblLeitura2.Name = "lblLeitura2";
            this.lblLeitura2.Size = new System.Drawing.Size(115, 15);
            this.lblLeitura2.Text = "Leitura:";
            // 
            // lblDigitos2
            // 
            this.lblDigitos2.Location = new System.Drawing.Point(48, 77);
            this.lblDigitos2.Name = "lblDigitos2";
            this.lblDigitos2.Size = new System.Drawing.Size(119, 15);
            this.lblDigitos2.Text = "Quantidade Dígitos:";
            this.lblDigitos2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxClasseMetrologica2
            // 
            this.cbxClasseMetrologica2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxClasseMetrologica2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "ClasseMetrologica2", true));
            this.cbxClasseMetrologica2.DisplayMember = "Description";
            this.cbxClasseMetrologica2.Location = new System.Drawing.Point(177, 103);
            this.cbxClasseMetrologica2.Name = "cbxClasseMetrologica2";
            this.cbxClasseMetrologica2.Size = new System.Drawing.Size(46, 22);
            this.cbxClasseMetrologica2.TabIndex = 217;
            this.cbxClasseMetrologica2.ValueMember = "Value";
            // 
            // lblClasseMetrologica2
            // 
            this.lblClasseMetrologica2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClasseMetrologica2.Location = new System.Drawing.Point(41, 107);
            this.lblClasseMetrologica2.Name = "lblClasseMetrologica2";
            this.lblClasseMetrologica2.Size = new System.Drawing.Size(119, 15);
            this.lblClasseMetrologica2.Text = "Classe Metrológica:";
            this.lblClasseMetrologica2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxNumMedidor2
            // 
            this.tbxNumMedidor2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNumMedidor2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NumeroMedidor2", true));
            this.tbxNumMedidor2.Location = new System.Drawing.Point(121, 3);
            this.tbxNumMedidor2.MaxLength = 13;
            this.tbxNumMedidor2.Name = "tbxNumMedidor2";
            this.tbxNumMedidor2.Size = new System.Drawing.Size(103, 21);
            this.tbxNumMedidor2.TabIndex = 176;
            this.tbxNumMedidor2.TextChanged += new System.EventHandler(this.tbxNumMedidor2_TextChanged);
            this.tbxNumMedidor2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxNumMedidor2_KeyUp);
            // 
            // lblNumMedidor2
            // 
            this.lblNumMedidor2.Location = new System.Drawing.Point(7, 4);
            this.lblNumMedidor2.Name = "lblNumMedidor2";
            this.lblNumMedidor2.Size = new System.Drawing.Size(91, 15);
            this.lblNumMedidor2.Text = "Nº Medidor:";
            // 
            // frmPontoServHidrometro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPontoServHidrometro";
            this.Title = "P.S. Hidrômetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).EndInit();
            this.tabMedidor.ResumeLayout(false);
            this.panelLeitura.ResumeLayout(false);
            this.tabInfAdicional.ResumeLayout(false);
            this.tabMedidor2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPadrao;
        private System.Windows.Forms.TabPage tabMedidor;
        private System.Windows.Forms.TabPage tabInfAdicional;
        private System.Windows.Forms.ComboBox cbxLocalPadrao;
        private System.Windows.Forms.Label lblLocalPadrao;
        private System.Windows.Forms.ComboBox cbxSitPontoServico;
        private System.Windows.Forms.TextBox tbxPontoServico;
        private System.Windows.Forms.Label lblPontoServico;
        private System.Windows.Forms.Label lblSitPontoServico;
        private System.Windows.Forms.Label lblPSMedidor;
        private System.Windows.Forms.ComboBox cbxTipoPadrao;
        private System.Windows.Forms.Label lblTipoPadrao;
        private System.Windows.Forms.Panel panelLeitura;
        private MobileTools.Controls.UltraButton lupa;
        private System.Windows.Forms.TextBox tbxLeitura;
        private System.Windows.Forms.Label lblLeitura;
        private System.Windows.Forms.Label lblDigitos;
        private System.Windows.Forms.ComboBox cbxClasseMetrologica;
        private System.Windows.Forms.Label lblClasseMetrologica;
        private System.Windows.Forms.ComboBox cbxHidrometroLacrado;
        private System.Windows.Forms.Label lblHidrometroLacrado;
        private System.Windows.Forms.TabPage tabMedidor2;
        private System.Windows.Forms.ComboBox cbxPSegLigacao;
        private System.Windows.Forms.Label lblPSegLigacao;
        private System.Windows.Forms.TextBox tbxNumMedidor2;
        private System.Windows.Forms.Label lblNumMedidor2;
        private System.Windows.Forms.Button btnFotos;
        private System.Windows.Forms.Button btnOcorrencia;
        private System.Windows.Forms.TextBox tbxInfComplementar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbxNumMedidor;
        private System.Windows.Forms.Label lblNumMedidor;
        private System.Windows.Forms.TextBox tbxFabricante;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.TextBox tbxCapacidade;
        private System.Windows.Forms.Label lblCapacidade;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxCapacidade2;
        private System.Windows.Forms.Label lblCapacidade2;
        private System.Windows.Forms.TextBox tbxFabricante2;
        private System.Windows.Forms.Label lblFabricante2;
        private System.Windows.Forms.ComboBox cbxHidrometroLacrado2;
        private System.Windows.Forms.Label lblHidrometroLacrado2;
        private MobileTools.Controls.UltraButton lupa2;
        private System.Windows.Forms.TextBox tbxLeitura2;
        private System.Windows.Forms.Label lblLeitura2;
        private System.Windows.Forms.Label lblDigitos2;
        private System.Windows.Forms.ComboBox cbxClasseMetrologica2;
        private System.Windows.Forms.Label lblClasseMetrologica2;
        private System.Windows.Forms.ComboBox cbxTorneiraPadrao;
        private System.Windows.Forms.ComboBox cbxEliminadorAr;
        private System.Windows.Forms.ComboBox cbxPadraoLacrado;
        private System.Windows.Forms.Label lblTorneiraPadrao;
        private System.Windows.Forms.Label lblEliminadorAr;
        private System.Windows.Forms.Label lblPadraoLacrado;
        private System.Windows.Forms.BindingSource bindingSourceCadastro;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox cbxQuantidade;
        private System.Windows.Forms.ComboBox cbxQuantidade2;
        private System.Windows.Forms.ComboBox cbxPossuiMedidorSN;
    }
}
