namespace SPCadMobile.View
{
    partial class frmDadosImovel : CustomFormAba
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDadosImovel));
            this.tabImovel = new System.Windows.Forms.TabPage();
            this.tbxNumero = new System.Windows.Forms.TextBox();
            this.bindingSourceCadastro = new System.Windows.Forms.BindingSource(this.components);
            this.dtpDataTermino = new System.Windows.Forms.DateTimePicker();
            this.lblPrevisaoTermino = new System.Windows.Forms.Label();
            this.cbxCondicao = new System.Windows.Forms.ComboBox();
            this.lblCondicao = new System.Windows.Forms.Label();
            this.tbxTipoLgrd = new System.Windows.Forms.TextBox();
            this.tbxBairro = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.tbxComplemento = new System.Windows.Forms.TextBox();
            this.cbxComplemento = new System.Windows.Forms.ComboBox();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.tbxLogrd = new System.Windows.Forms.TextBox();
            this.lblLogrd = new System.Windows.Forms.Label();
            this.lblTipoLgrd = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tabEconomias = new System.Windows.Forms.TabPage();
            this.ubtnRemove4 = new MobileTools.Controls.UltraButton();
            this.ubtnRemove3 = new MobileTools.Controls.UltraButton();
            this.ubtnRemove2 = new MobileTools.Controls.UltraButton();
            this.ubtnRemove1 = new MobileTools.Controls.UltraButton();
            this.title2 = new MobileTools.Controls.Title();
            this.ubtnRamoAtiv4 = new MobileTools.Controls.UltraButton();
            this.tbxRamoAtiv4 = new System.Windows.Forms.TextBox();
            this.ubtnRamoAtiv3 = new MobileTools.Controls.UltraButton();
            this.tbxRamoAtiv3 = new System.Windows.Forms.TextBox();
            this.tbxQtdPublica = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ubtnRamoAtiv2 = new MobileTools.Controls.UltraButton();
            this.tbxRamoAtiv2 = new System.Windows.Forms.TextBox();
            this.tbxQtdIndustrial = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ubtnRamoAtiv1 = new MobileTools.Controls.UltraButton();
            this.tbxRamoAtiv1 = new System.Windows.Forms.TextBox();
            this.tbxQtdComercial = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxQtdResidencial = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabCaracteristicas = new System.Windows.Forms.TabPage();
            this.cbxSitImovel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdPossuiPiscina = new MobileTools.Controls.RadioButtonGroup();
            this.rdPiscinaNao = new MobileTools.Controls.RadioButtonEx();
            this.rdPiscinaSim = new MobileTools.Controls.RadioButtonEx();
            this.cbxIncompativel = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxObservacaoTS = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ckbTarfSocial = new System.Windows.Forms.CheckBox();
            this.cbxFontealter = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.rdPossuiReservatorio = new MobileTools.Controls.RadioButtonGroup();
            this.rdReservatorioNao = new MobileTools.Controls.RadioButtonEx();
            this.rbReservatorioSim = new MobileTools.Controls.RadioButtonEx();
            this.tabInfAdicional = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOcorrencias = new System.Windows.Forms.Button();
            this.tbxInfComplementar = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabImovel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).BeginInit();
            this.tabEconomias.SuspendLayout();
            this.tabCaracteristicas.SuspendLayout();
            this.rdPossuiPiscina.SuspendLayout();
            this.rdPossuiReservatorio.SuspendLayout();
            this.tabInfAdicional.SuspendLayout();
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
            this.chkConfirmado.Click += new System.EventHandler(this.chkConfirmado_Click);
            // 
            // lblAlterado
            // 
            this.lblAlterado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabImovel);
            this.tabControl1.Controls.Add(this.tabEconomias);
            this.tabControl1.Controls.Add(this.tabCaracteristicas);
            this.tabControl1.Controls.Add(this.tabInfAdicional);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Size = new System.Drawing.Size(239, 259);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabImovel
            // 
            this.tabImovel.Controls.Add(this.tbxNumero);
            this.tabImovel.Controls.Add(this.dtpDataTermino);
            this.tabImovel.Controls.Add(this.lblPrevisaoTermino);
            this.tabImovel.Controls.Add(this.cbxCondicao);
            this.tabImovel.Controls.Add(this.lblCondicao);
            this.tabImovel.Controls.Add(this.tbxTipoLgrd);
            this.tabImovel.Controls.Add(this.tbxBairro);
            this.tabImovel.Controls.Add(this.lblBairro);
            this.tabImovel.Controls.Add(this.tbxComplemento);
            this.tabImovel.Controls.Add(this.cbxComplemento);
            this.tabImovel.Controls.Add(this.lblComplemento);
            this.tabImovel.Controls.Add(this.lblNumero);
            this.tabImovel.Controls.Add(this.tbxLogrd);
            this.tabImovel.Controls.Add(this.lblLogrd);
            this.tabImovel.Controls.Add(this.lblTipoLgrd);
            this.tabImovel.Controls.Add(this.tbxCliente);
            this.tabImovel.Controls.Add(this.lblCliente);
            this.tabImovel.Location = new System.Drawing.Point(0, 0);
            this.tabImovel.Name = "tabImovel";
            this.tabImovel.Size = new System.Drawing.Size(239, 236);
            this.tabImovel.Text = "Imóvel";
            // 
            // tbxNumero
            // 
            this.tbxNumero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NumeroImovelAlter", true));
            this.tbxNumero.Location = new System.Drawing.Point(39, 91);
            this.tbxNumero.MaxLength = 5;
            this.tbxNumero.Name = "tbxNumero";
            this.tbxNumero.Size = new System.Drawing.Size(62, 21);
            this.tbxNumero.TabIndex = 18;
            this.tbxNumero.TextChanged += new System.EventHandler(this.tbxNumero_TextChanged);
            this.tbxNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumero_KeyPress);
            // 
            // bindingSourceCadastro
            // 
            this.bindingSourceCadastro.DataSource = typeof(SPCadMobileData.Data.Model.Cadastro);
            this.bindingSourceCadastro.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.bindingSourceCadastro_BindingComplete);
            // 
            // dtpDataTermino
            // 
            this.dtpDataTermino.CustomFormat = "dd/MM/yyyy";
            this.dtpDataTermino.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "PrevisaoFimObra", true));
            this.dtpDataTermino.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCadastro, "PrevisaoFimObra", true));
            this.dtpDataTermino.Enabled = false;
            this.dtpDataTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataTermino.Location = new System.Drawing.Point(132, 212);
            this.dtpDataTermino.Name = "dtpDataTermino";
            this.dtpDataTermino.Size = new System.Drawing.Size(104, 22);
            this.dtpDataTermino.TabIndex = 9;
            this.dtpDataTermino.Value = new System.DateTime(2010, 9, 2, 9, 31, 26, 0);
            this.dtpDataTermino.Visible = false;
            // 
            // lblPrevisaoTermino
            // 
            this.lblPrevisaoTermino.Location = new System.Drawing.Point(3, 215);
            this.lblPrevisaoTermino.Name = "lblPrevisaoTermino";
            this.lblPrevisaoTermino.Size = new System.Drawing.Size(134, 20);
            this.lblPrevisaoTermino.Text = "Previsão de Término:";
            this.lblPrevisaoTermino.Visible = false;
            // 
            // cbxCondicao
            // 
            this.cbxCondicao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCondicao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "CondicaoImovelAlter", true));
            this.cbxCondicao.DisplayMember = "Description";
            this.cbxCondicao.Location = new System.Drawing.Point(67, 188);
            this.cbxCondicao.Name = "cbxCondicao";
            this.cbxCondicao.Size = new System.Drawing.Size(169, 22);
            this.cbxCondicao.TabIndex = 8;
            this.cbxCondicao.ValueMember = "Value";
            this.cbxCondicao.SelectedValueChanged += new System.EventHandler(this.cbxCondicao_SelectedValueChanged);
            // 
            // lblCondicao
            // 
            this.lblCondicao.Location = new System.Drawing.Point(3, 189);
            this.lblCondicao.Name = "lblCondicao";
            this.lblCondicao.Size = new System.Drawing.Size(58, 20);
            this.lblCondicao.Text = "Condição:";
            // 
            // tbxTipoLgrd
            // 
            this.tbxTipoLgrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "DescTipoLogradouro", true));
            this.tbxTipoLgrd.Location = new System.Drawing.Point(100, 27);
            this.tbxTipoLgrd.Name = "tbxTipoLgrd";
            this.tbxTipoLgrd.ReadOnly = true;
            this.tbxTipoLgrd.Size = new System.Drawing.Size(118, 21);
            this.tbxTipoLgrd.TabIndex = 2;
            // 
            // tbxBairro
            // 
            this.tbxBairro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxBairro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NomeBairro", true));
            this.tbxBairro.Location = new System.Drawing.Point(67, 163);
            this.tbxBairro.Name = "tbxBairro";
            this.tbxBairro.ReadOnly = true;
            this.tbxBairro.Size = new System.Drawing.Size(169, 21);
            this.tbxBairro.TabIndex = 7;
            // 
            // lblBairro
            // 
            this.lblBairro.Location = new System.Drawing.Point(3, 164);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(46, 20);
            this.lblBairro.Text = "Bairro:";
            // 
            // tbxComplemento
            // 
            this.tbxComplemento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxComplemento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "InformacaoComplementarAlter", true));
            this.tbxComplemento.Location = new System.Drawing.Point(109, 138);
            this.tbxComplemento.MaxLength = 12;
            this.tbxComplemento.Name = "tbxComplemento";
            this.tbxComplemento.Size = new System.Drawing.Size(126, 21);
            this.tbxComplemento.TabIndex = 6;
            // 
            // cbxComplemento
            // 
            this.cbxComplemento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "TipoComplementoAlter", true));
            this.cbxComplemento.DisplayMember = "Description";
            this.cbxComplemento.Location = new System.Drawing.Point(4, 138);
            this.cbxComplemento.Name = "cbxComplemento";
            this.cbxComplemento.Size = new System.Drawing.Size(102, 22);
            this.cbxComplemento.TabIndex = 5;
            this.cbxComplemento.ValueMember = "Value";
            // 
            // lblComplemento
            // 
            this.lblComplemento.Location = new System.Drawing.Point(8, 120);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(93, 15);
            this.lblComplemento.Text = "Complemento:";
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(8, 91);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(25, 20);
            this.lblNumero.Text = "N.:";
            // 
            // tbxLogrd
            // 
            this.tbxLogrd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLogrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NomeLogradouro", true));
            this.tbxLogrd.Location = new System.Drawing.Point(50, 58);
            this.tbxLogrd.Name = "tbxLogrd";
            this.tbxLogrd.ReadOnly = true;
            this.tbxLogrd.Size = new System.Drawing.Size(186, 21);
            this.tbxLogrd.TabIndex = 3;
            // 
            // lblLogrd
            // 
            this.lblLogrd.Location = new System.Drawing.Point(8, 59);
            this.lblLogrd.Name = "lblLogrd";
            this.lblLogrd.Size = new System.Drawing.Size(41, 20);
            this.lblLogrd.Text = "Logr:";
            // 
            // lblTipoLgrd
            // 
            this.lblTipoLgrd.Location = new System.Drawing.Point(3, 30);
            this.lblTipoLgrd.Name = "lblTipoLgrd";
            this.lblTipoLgrd.Size = new System.Drawing.Size(100, 15);
            this.lblTipoLgrd.Text = "Tipo logradouro:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NomeCliente", true));
            this.tbxCliente.Location = new System.Drawing.Point(50, 0);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.ReadOnly = true;
            this.tbxCliente.Size = new System.Drawing.Size(186, 21);
            this.tbxCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(3, 1);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 20);
            this.lblCliente.Text = "Cliente:";
            // 
            // tabEconomias
            // 
            this.tabEconomias.Controls.Add(this.ubtnRemove4);
            this.tabEconomias.Controls.Add(this.ubtnRemove3);
            this.tabEconomias.Controls.Add(this.ubtnRemove2);
            this.tabEconomias.Controls.Add(this.ubtnRemove1);
            this.tabEconomias.Controls.Add(this.title2);
            this.tabEconomias.Controls.Add(this.ubtnRamoAtiv4);
            this.tabEconomias.Controls.Add(this.tbxRamoAtiv4);
            this.tabEconomias.Controls.Add(this.ubtnRamoAtiv3);
            this.tabEconomias.Controls.Add(this.tbxRamoAtiv3);
            this.tabEconomias.Controls.Add(this.tbxQtdPublica);
            this.tabEconomias.Controls.Add(this.label9);
            this.tabEconomias.Controls.Add(this.label10);
            this.tabEconomias.Controls.Add(this.ubtnRamoAtiv2);
            this.tabEconomias.Controls.Add(this.tbxRamoAtiv2);
            this.tabEconomias.Controls.Add(this.tbxQtdIndustrial);
            this.tabEconomias.Controls.Add(this.label11);
            this.tabEconomias.Controls.Add(this.label12);
            this.tabEconomias.Controls.Add(this.ubtnRamoAtiv1);
            this.tabEconomias.Controls.Add(this.tbxRamoAtiv1);
            this.tabEconomias.Controls.Add(this.tbxQtdComercial);
            this.tabEconomias.Controls.Add(this.label13);
            this.tabEconomias.Controls.Add(this.label14);
            this.tabEconomias.Controls.Add(this.tbxQtdResidencial);
            this.tabEconomias.Controls.Add(this.label15);
            this.tabEconomias.Controls.Add(this.label16);
            this.tabEconomias.Location = new System.Drawing.Point(0, 0);
            this.tabEconomias.Name = "tabEconomias";
            this.tabEconomias.Size = new System.Drawing.Size(232, 233);
            this.tabEconomias.Text = "Economias";
            // 
            // ubtnRemove4
            // 
            this.ubtnRemove4.BorderColor = System.Drawing.Color.LightGray;
            this.ubtnRemove4.ButtonColor = System.Drawing.Color.White;
            this.ubtnRemove4.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRemove4.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRemove4.ImageButton")));
            this.ubtnRemove4.ImageButtonView = true;
            this.ubtnRemove4.Location = new System.Drawing.Point(217, 209);
            this.ubtnRemove4.Name = "ubtnRemove4";
            this.ubtnRemove4.Radius = 8;
            this.ubtnRemove4.Size = new System.Drawing.Size(17, 19);
            this.ubtnRemove4.TabIndex = 218;
            this.ubtnRemove4.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRemove4.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRemove4.TextColorClick = System.Drawing.Color.White;
            this.ubtnRemove4.Click += new System.EventHandler(this.ubtnRemove4_Click);
            // 
            // ubtnRemove3
            // 
            this.ubtnRemove3.BorderColor = System.Drawing.Color.LightGray;
            this.ubtnRemove3.ButtonColor = System.Drawing.Color.White;
            this.ubtnRemove3.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRemove3.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRemove3.ImageButton")));
            this.ubtnRemove3.ImageButtonView = true;
            this.ubtnRemove3.Location = new System.Drawing.Point(217, 182);
            this.ubtnRemove3.Name = "ubtnRemove3";
            this.ubtnRemove3.Radius = 8;
            this.ubtnRemove3.Size = new System.Drawing.Size(17, 19);
            this.ubtnRemove3.TabIndex = 217;
            this.ubtnRemove3.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRemove3.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRemove3.TextColorClick = System.Drawing.Color.White;
            this.ubtnRemove3.Click += new System.EventHandler(this.ubtnRemove3_Click);
            // 
            // ubtnRemove2
            // 
            this.ubtnRemove2.BorderColor = System.Drawing.Color.LightGray;
            this.ubtnRemove2.ButtonColor = System.Drawing.Color.White;
            this.ubtnRemove2.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRemove2.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRemove2.ImageButton")));
            this.ubtnRemove2.ImageButtonView = true;
            this.ubtnRemove2.Location = new System.Drawing.Point(217, 157);
            this.ubtnRemove2.Name = "ubtnRemove2";
            this.ubtnRemove2.Radius = 8;
            this.ubtnRemove2.Size = new System.Drawing.Size(17, 19);
            this.ubtnRemove2.TabIndex = 216;
            this.ubtnRemove2.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRemove2.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRemove2.TextColorClick = System.Drawing.Color.White;
            this.ubtnRemove2.Click += new System.EventHandler(this.ubtnRemove2_Click);
            // 
            // ubtnRemove1
            // 
            this.ubtnRemove1.BorderColor = System.Drawing.Color.LightGray;
            this.ubtnRemove1.ButtonColor = System.Drawing.Color.White;
            this.ubtnRemove1.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRemove1.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRemove1.ImageButton")));
            this.ubtnRemove1.ImageButtonView = true;
            this.ubtnRemove1.Location = new System.Drawing.Point(217, 128);
            this.ubtnRemove1.Name = "ubtnRemove1";
            this.ubtnRemove1.Radius = 8;
            this.ubtnRemove1.Size = new System.Drawing.Size(17, 19);
            this.ubtnRemove1.TabIndex = 215;
            this.ubtnRemove1.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRemove1.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRemove1.TextColorClick = System.Drawing.Color.White;
            this.ubtnRemove1.Click += new System.EventHandler(this.ubtnRemove1_Click);
            // 
            // title2
            // 
            this.title2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title2.ColorLine = System.Drawing.Color.OliveDrab;
            this.title2.DistanceWordLine = 2;
            this.title2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title2.HeightLine = 5;
            this.title2.Location = new System.Drawing.Point(6, 99);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(223, 23);
            this.title2.TabIndex = 206;
            this.title2.Text = "Ramo de Atividade";
            this.title2.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title2.TextColor = System.Drawing.SystemColors.WindowText;
            this.title2.WidthInclination = 10;
            // 
            // ubtnRamoAtiv4
            // 
            this.ubtnRamoAtiv4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubtnRamoAtiv4.BorderColor = System.Drawing.Color.Transparent;
            this.ubtnRamoAtiv4.ButtonColor = System.Drawing.Color.White;
            this.ubtnRamoAtiv4.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRamoAtiv4.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRamoAtiv4.ImageButton")));
            this.ubtnRamoAtiv4.ImageButtonView = true;
            this.ubtnRamoAtiv4.Location = new System.Drawing.Point(187, 209);
            this.ubtnRamoAtiv4.Name = "ubtnRamoAtiv4";
            this.ubtnRamoAtiv4.Radius = 8;
            this.ubtnRamoAtiv4.Size = new System.Drawing.Size(19, 19);
            this.ubtnRamoAtiv4.TabIndex = 21;
            this.ubtnRamoAtiv4.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRamoAtiv4.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRamoAtiv4.TextColorClick = System.Drawing.Color.White;
            this.ubtnRamoAtiv4.Click += new System.EventHandler(this.ubtnRamoAtiv4_Click);
            // 
            // tbxRamoAtiv4
            // 
            this.tbxRamoAtiv4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRamoAtiv4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "RamoAtivDesc4", true));
            this.tbxRamoAtiv4.Location = new System.Drawing.Point(3, 209);
            this.tbxRamoAtiv4.Name = "tbxRamoAtiv4";
            this.tbxRamoAtiv4.ReadOnly = true;
            this.tbxRamoAtiv4.Size = new System.Drawing.Size(181, 21);
            this.tbxRamoAtiv4.TabIndex = 20;
            // 
            // ubtnRamoAtiv3
            // 
            this.ubtnRamoAtiv3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubtnRamoAtiv3.BorderColor = System.Drawing.Color.Transparent;
            this.ubtnRamoAtiv3.ButtonColor = System.Drawing.Color.White;
            this.ubtnRamoAtiv3.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRamoAtiv3.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRamoAtiv3.ImageButton")));
            this.ubtnRamoAtiv3.ImageButtonView = true;
            this.ubtnRamoAtiv3.Location = new System.Drawing.Point(187, 182);
            this.ubtnRamoAtiv3.Name = "ubtnRamoAtiv3";
            this.ubtnRamoAtiv3.Radius = 8;
            this.ubtnRamoAtiv3.Size = new System.Drawing.Size(19, 19);
            this.ubtnRamoAtiv3.TabIndex = 19;
            this.ubtnRamoAtiv3.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRamoAtiv3.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRamoAtiv3.TextColorClick = System.Drawing.Color.White;
            this.ubtnRamoAtiv3.Click += new System.EventHandler(this.ubtnRamoAtiv3_Click);
            // 
            // tbxRamoAtiv3
            // 
            this.tbxRamoAtiv3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRamoAtiv3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "RamoAtivDesc3", true));
            this.tbxRamoAtiv3.Location = new System.Drawing.Point(3, 182);
            this.tbxRamoAtiv3.Name = "tbxRamoAtiv3";
            this.tbxRamoAtiv3.ReadOnly = true;
            this.tbxRamoAtiv3.Size = new System.Drawing.Size(181, 21);
            this.tbxRamoAtiv3.TabIndex = 18;
            // 
            // tbxQtdPublica
            // 
            this.tbxQtdPublica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxQtdPublica.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "QtdeEconomiasPublicaAlter", true));
            this.tbxQtdPublica.Location = new System.Drawing.Point(177, 72);
            this.tbxQtdPublica.MaxLength = 5;
            this.tbxQtdPublica.Name = "tbxQtdPublica";
            this.tbxQtdPublica.Size = new System.Drawing.Size(50, 21);
            this.tbxQtdPublica.TabIndex = 13;
            this.tbxQtdPublica.TextChanged += new System.EventHandler(this.tbxQtdPublica_TextChanged);
            this.tbxQtdPublica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumero_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(138, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.Text = "Qtde:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(3, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 15);
            this.label10.Text = "PÚBLICA ->";
            // 
            // ubtnRamoAtiv2
            // 
            this.ubtnRamoAtiv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubtnRamoAtiv2.BorderColor = System.Drawing.Color.Transparent;
            this.ubtnRamoAtiv2.ButtonColor = System.Drawing.Color.White;
            this.ubtnRamoAtiv2.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRamoAtiv2.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRamoAtiv2.ImageButton")));
            this.ubtnRamoAtiv2.ImageButtonView = true;
            this.ubtnRamoAtiv2.Location = new System.Drawing.Point(187, 157);
            this.ubtnRamoAtiv2.Name = "ubtnRamoAtiv2";
            this.ubtnRamoAtiv2.Radius = 8;
            this.ubtnRamoAtiv2.Size = new System.Drawing.Size(19, 19);
            this.ubtnRamoAtiv2.TabIndex = 17;
            this.ubtnRamoAtiv2.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRamoAtiv2.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRamoAtiv2.TextColorClick = System.Drawing.Color.White;
            this.ubtnRamoAtiv2.Click += new System.EventHandler(this.ubtnRamoAtiv2_Click);
            // 
            // tbxRamoAtiv2
            // 
            this.tbxRamoAtiv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRamoAtiv2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "RamoAtivDesc2", true));
            this.tbxRamoAtiv2.Location = new System.Drawing.Point(3, 155);
            this.tbxRamoAtiv2.Name = "tbxRamoAtiv2";
            this.tbxRamoAtiv2.ReadOnly = true;
            this.tbxRamoAtiv2.Size = new System.Drawing.Size(181, 21);
            this.tbxRamoAtiv2.TabIndex = 16;
            // 
            // tbxQtdIndustrial
            // 
            this.tbxQtdIndustrial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxQtdIndustrial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "QtdeEconomiasIndustrialAlter", true));
            this.tbxQtdIndustrial.Location = new System.Drawing.Point(177, 48);
            this.tbxQtdIndustrial.MaxLength = 5;
            this.tbxQtdIndustrial.Name = "tbxQtdIndustrial";
            this.tbxQtdIndustrial.Size = new System.Drawing.Size(50, 21);
            this.tbxQtdIndustrial.TabIndex = 12;
            this.tbxQtdIndustrial.TextChanged += new System.EventHandler(this.tbxQtdIndustrial_TextChanged);
            this.tbxQtdIndustrial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumero_KeyPress);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(138, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.Text = "Qtde:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(3, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 15);
            this.label12.Text = "INDUSTRIAL ->";
            // 
            // ubtnRamoAtiv1
            // 
            this.ubtnRamoAtiv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ubtnRamoAtiv1.BorderColor = System.Drawing.Color.Transparent;
            this.ubtnRamoAtiv1.ButtonColor = System.Drawing.Color.White;
            this.ubtnRamoAtiv1.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.ubtnRamoAtiv1.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("ubtnRamoAtiv1.ImageButton")));
            this.ubtnRamoAtiv1.ImageButtonView = true;
            this.ubtnRamoAtiv1.Location = new System.Drawing.Point(187, 128);
            this.ubtnRamoAtiv1.Name = "ubtnRamoAtiv1";
            this.ubtnRamoAtiv1.Radius = 8;
            this.ubtnRamoAtiv1.Size = new System.Drawing.Size(17, 19);
            this.ubtnRamoAtiv1.TabIndex = 15;
            this.ubtnRamoAtiv1.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.ubtnRamoAtiv1.TextColor = System.Drawing.SystemColors.WindowText;
            this.ubtnRamoAtiv1.TextColorClick = System.Drawing.Color.White;
            this.ubtnRamoAtiv1.Click += new System.EventHandler(this.ubtnRamoAtiv1_Click);
            // 
            // tbxRamoAtiv1
            // 
            this.tbxRamoAtiv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRamoAtiv1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "RamoAtivDesc1", true));
            this.tbxRamoAtiv1.Location = new System.Drawing.Point(3, 128);
            this.tbxRamoAtiv1.Name = "tbxRamoAtiv1";
            this.tbxRamoAtiv1.ReadOnly = true;
            this.tbxRamoAtiv1.Size = new System.Drawing.Size(181, 21);
            this.tbxRamoAtiv1.TabIndex = 14;
            // 
            // tbxQtdComercial
            // 
            this.tbxQtdComercial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxQtdComercial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "QtdeEconomiasComercialAlter", true));
            this.tbxQtdComercial.Location = new System.Drawing.Point(177, 24);
            this.tbxQtdComercial.MaxLength = 5;
            this.tbxQtdComercial.Name = "tbxQtdComercial";
            this.tbxQtdComercial.Size = new System.Drawing.Size(50, 21);
            this.tbxQtdComercial.TabIndex = 11;
            this.tbxQtdComercial.TextChanged += new System.EventHandler(this.tbxQtdComercial_TextChanged);
            this.tbxQtdComercial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumero_KeyPress);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(138, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 15);
            this.label13.Text = "Qtde:";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(3, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 15);
            this.label14.Text = "COMERCIAL ->";
            // 
            // tbxQtdResidencial
            // 
            this.tbxQtdResidencial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxQtdResidencial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "QtdeEconomiasResidencialAlter", true));
            this.tbxQtdResidencial.Location = new System.Drawing.Point(177, 0);
            this.tbxQtdResidencial.MaxLength = 5;
            this.tbxQtdResidencial.Name = "tbxQtdResidencial";
            this.tbxQtdResidencial.Size = new System.Drawing.Size(50, 21);
            this.tbxQtdResidencial.TabIndex = 10;
            this.tbxQtdResidencial.TextChanged += new System.EventHandler(this.tbxQtdResidencial_TextChanged);
            this.tbxQtdResidencial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumero_KeyPress);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(138, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 15);
            this.label15.Text = "Qtde:";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(3, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 15);
            this.label16.Text = "RESIDENCIAL ->";
            // 
            // tabCaracteristicas
            // 
            this.tabCaracteristicas.Controls.Add(this.cbxSitImovel);
            this.tabCaracteristicas.Controls.Add(this.label6);
            this.tabCaracteristicas.Controls.Add(this.rdPossuiPiscina);
            this.tabCaracteristicas.Controls.Add(this.cbxIncompativel);
            this.tabCaracteristicas.Controls.Add(this.label18);
            this.tabCaracteristicas.Controls.Add(this.label19);
            this.tabCaracteristicas.Controls.Add(this.tbxObservacaoTS);
            this.tabCaracteristicas.Controls.Add(this.label20);
            this.tabCaracteristicas.Controls.Add(this.ckbTarfSocial);
            this.tabCaracteristicas.Controls.Add(this.cbxFontealter);
            this.tabCaracteristicas.Controls.Add(this.label21);
            this.tabCaracteristicas.Controls.Add(this.label22);
            this.tabCaracteristicas.Controls.Add(this.label23);
            this.tabCaracteristicas.Controls.Add(this.rdPossuiReservatorio);
            this.tabCaracteristicas.Location = new System.Drawing.Point(0, 0);
            this.tabCaracteristicas.Name = "tabCaracteristicas";
            this.tabCaracteristicas.Size = new System.Drawing.Size(239, 236);
            this.tabCaracteristicas.Text = "Características";
            // 
            // cbxSitImovel
            // 
            this.cbxSitImovel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSitImovel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "SituacaoImovelAlter", true));
            this.cbxSitImovel.DisplayMember = "Description";
            this.cbxSitImovel.Location = new System.Drawing.Point(83, 169);
            this.cbxSitImovel.Name = "cbxSitImovel";
            this.cbxSitImovel.Size = new System.Drawing.Size(139, 22);
            this.cbxSitImovel.TabIndex = 9;
            this.cbxSitImovel.ValueMember = "Value";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.Text = "Sit. Imóvel:";
            // 
            // rdPossuiPiscina
            // 
            this.rdPossuiPiscina.Controls.Add(this.rdPiscinaNao);
            this.rdPossuiPiscina.Controls.Add(this.rdPiscinaSim);
            this.rdPossuiPiscina.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "PiscinaAlter", true));
            this.rdPossuiPiscina.Location = new System.Drawing.Point(125, 141);
            this.rdPossuiPiscina.Name = "rdPossuiPiscina";
            this.rdPossuiPiscina.SelectedValue = null;
            this.rdPossuiPiscina.Size = new System.Drawing.Size(104, 23);
            this.rdPossuiPiscina.Tag = "2";
            // 
            // rdPiscinaNao
            // 
            this.rdPiscinaNao.Location = new System.Drawing.Point(52, 4);
            this.rdPiscinaNao.Name = "rdPiscinaNao";
            this.rdPiscinaNao.Size = new System.Drawing.Size(43, 18);
            this.rdPiscinaNao.TabIndex = 8;
            this.rdPiscinaNao.Tag = "2";
            this.rdPiscinaNao.Text = "Não";
            this.rdPiscinaNao.Value = null;
            // 
            // rdPiscinaSim
            // 
            this.rdPiscinaSim.Location = new System.Drawing.Point(6, 4);
            this.rdPiscinaSim.Name = "rdPiscinaSim";
            this.rdPiscinaSim.Size = new System.Drawing.Size(43, 18);
            this.rdPiscinaSim.TabIndex = 7;
            this.rdPiscinaSim.TabStop = false;
            this.rdPiscinaSim.Tag = "1";
            this.rdPiscinaSim.Text = "Sim";
            this.rdPiscinaSim.Value = null;
            // 
            // cbxIncompativel
            // 
            this.cbxIncompativel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxIncompativel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "TarifaSocialIncompativel", true));
            this.cbxIncompativel.DisplayMember = "Description";
            this.cbxIncompativel.Enabled = false;
            this.cbxIncompativel.Location = new System.Drawing.Point(172, 3);
            this.cbxIncompativel.Name = "cbxIncompativel";
            this.cbxIncompativel.Size = new System.Drawing.Size(50, 22);
            this.cbxIncompativel.TabIndex = 2;
            this.cbxIncompativel.ValueMember = "Value";
            this.cbxIncompativel.SelectedValueChanged += new System.EventHandler(this.cbxIncompativel_SelectedValueChanged);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(3, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 15);
            this.label18.Text = "Possui piscina:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(3, 120);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 15);
            this.label19.Text = "Possui Reservatório:";
            // 
            // tbxObservacaoTS
            // 
            this.tbxObservacaoTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxObservacaoTS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "TarifaSocialIncompativelObs", true));
            this.tbxObservacaoTS.Location = new System.Drawing.Point(3, 47);
            this.tbxObservacaoTS.MaxLength = 40;
            this.tbxObservacaoTS.Multiline = true;
            this.tbxObservacaoTS.Name = "tbxObservacaoTS";
            this.tbxObservacaoTS.ReadOnly = true;
            this.tbxObservacaoTS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxObservacaoTS.Size = new System.Drawing.Size(219, 37);
            this.tbxObservacaoTS.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(3, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 15);
            this.label20.Text = "Observação T.S.:";
            // 
            // ckbTarfSocial
            // 
            this.ckbTarfSocial.BackColor = System.Drawing.Color.White;
            this.ckbTarfSocial.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceCadastro, "StatusTarifaSocial", true));
            this.ckbTarfSocial.Enabled = false;
            this.ckbTarfSocial.Location = new System.Drawing.Point(61, 4);
            this.ckbTarfSocial.Name = "ckbTarfSocial";
            this.ckbTarfSocial.Size = new System.Drawing.Size(25, 20);
            this.ckbTarfSocial.TabIndex = 1;
            // 
            // cbxFontealter
            // 
            this.cbxFontealter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFontealter.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "FonteAlternativaAlter", true));
            this.cbxFontealter.DisplayMember = "Description";
            this.cbxFontealter.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbxFontealter.Location = new System.Drawing.Point(61, 90);
            this.cbxFontealter.Name = "cbxFontealter";
            this.cbxFontealter.Size = new System.Drawing.Size(172, 20);
            this.cbxFontealter.TabIndex = 4;
            this.cbxFontealter.ValueMember = "Value";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(3, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 18);
            this.label21.Text = "Fonte Alt:";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(89, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.Text = "Incompatível:";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(3, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 15);
            this.label23.Text = "T. Social:";
            // 
            // rdPossuiReservatorio
            // 
            this.rdPossuiReservatorio.Controls.Add(this.rdReservatorioNao);
            this.rdPossuiReservatorio.Controls.Add(this.rbReservatorioSim);
            this.rdPossuiReservatorio.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastro, "ReservatorioAlter", true));
            this.rdPossuiReservatorio.Location = new System.Drawing.Point(125, 115);
            this.rdPossuiReservatorio.Name = "rdPossuiReservatorio";
            this.rdPossuiReservatorio.SelectedValue = null;
            this.rdPossuiReservatorio.Size = new System.Drawing.Size(104, 23);
            this.rdPossuiReservatorio.Tag = "";
            // 
            // rdReservatorioNao
            // 
            this.rdReservatorioNao.Location = new System.Drawing.Point(52, 4);
            this.rdReservatorioNao.Name = "rdReservatorioNao";
            this.rdReservatorioNao.Size = new System.Drawing.Size(43, 18);
            this.rdReservatorioNao.TabIndex = 6;
            this.rdReservatorioNao.Tag = "2";
            this.rdReservatorioNao.Text = "Não";
            this.rdReservatorioNao.Value = null;
            // 
            // rbReservatorioSim
            // 
            this.rbReservatorioSim.Location = new System.Drawing.Point(6, 4);
            this.rbReservatorioSim.Name = "rbReservatorioSim";
            this.rbReservatorioSim.Size = new System.Drawing.Size(43, 18);
            this.rbReservatorioSim.TabIndex = 5;
            this.rbReservatorioSim.TabStop = false;
            this.rbReservatorioSim.Tag = "1";
            this.rbReservatorioSim.Text = "Sim";
            this.rbReservatorioSim.Value = null;
            // 
            // tabInfAdicional
            // 
            this.tabInfAdicional.Controls.Add(this.button1);
            this.tabInfAdicional.Controls.Add(this.btnOcorrencias);
            this.tabInfAdicional.Controls.Add(this.tbxInfComplementar);
            this.tabInfAdicional.Controls.Add(this.label24);
            this.tabInfAdicional.Location = new System.Drawing.Point(0, 0);
            this.tabInfAdicional.Name = "tabInfAdicional";
            this.tabInfAdicional.Size = new System.Drawing.Size(232, 233);
            this.tabInfAdicional.Text = "Inf. Adicional";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(118, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 20);
            this.button1.TabIndex = 198;
            this.button1.Text = "Fotos";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOcorrencias
            // 
            this.btnOcorrencias.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOcorrencias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOcorrencias.Location = new System.Drawing.Point(17, 114);
            this.btnOcorrencias.Name = "btnOcorrencias";
            this.btnOcorrencias.Size = new System.Drawing.Size(95, 20);
            this.btnOcorrencias.TabIndex = 197;
            this.btnOcorrencias.Text = "Ocorrências";
            this.btnOcorrencias.Click += new System.EventHandler(this.btnOcorrencias_Click);
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
            this.tbxInfComplementar.TabIndex = 29;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(7, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(162, 15);
            this.label24.Text = "Informação Adicional:";
            // 
            // frmDadosImovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDadosImovel";
            this.Text = "Dados Imóvel";
            this.Title = "Dados Imóvel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabImovel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).EndInit();
            this.tabEconomias.ResumeLayout(false);
            this.tabCaracteristicas.ResumeLayout(false);
            this.rdPossuiPiscina.ResumeLayout(false);
            this.rdPossuiReservatorio.ResumeLayout(false);
            this.tabInfAdicional.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabImovel;
        private System.Windows.Forms.ComboBox cbxCondicao;
        private System.Windows.Forms.Label lblCondicao;
        private System.Windows.Forms.TextBox tbxTipoLgrd;
        private System.Windows.Forms.TextBox tbxBairro;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox tbxComplemento;
        private System.Windows.Forms.ComboBox cbxComplemento;
        private System.Windows.Forms.Label lblComplemento;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox tbxLogrd;
        private System.Windows.Forms.Label lblLogrd;
        private System.Windows.Forms.Label lblTipoLgrd;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TabPage tabEconomias;
        private System.Windows.Forms.TabPage tabCaracteristicas;
        private System.Windows.Forms.TabPage tabInfAdicional;
        private MobileTools.Controls.Title title2;
        private MobileTools.Controls.UltraButton ubtnRamoAtiv4;
        private System.Windows.Forms.TextBox tbxRamoAtiv4;
        private MobileTools.Controls.UltraButton ubtnRamoAtiv3;
        private System.Windows.Forms.TextBox tbxRamoAtiv3;
        private System.Windows.Forms.TextBox tbxQtdPublica;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private MobileTools.Controls.UltraButton ubtnRamoAtiv2;
        private System.Windows.Forms.TextBox tbxRamoAtiv2;
        private System.Windows.Forms.TextBox tbxQtdIndustrial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private MobileTools.Controls.UltraButton ubtnRamoAtiv1;
        private System.Windows.Forms.TextBox tbxRamoAtiv1;
        private System.Windows.Forms.TextBox tbxQtdComercial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbxQtdResidencial;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private MobileTools.Controls.RadioButtonGroup rdPossuiPiscina;
        private MobileTools.Controls.RadioButtonEx rdPiscinaNao;
        private MobileTools.Controls.RadioButtonEx rdPiscinaSim;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxObservacaoTS;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ckbTarfSocial;
        private System.Windows.Forms.ComboBox cbxFontealter;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private MobileTools.Controls.RadioButtonGroup rdPossuiReservatorio;
        private MobileTools.Controls.RadioButtonEx rdReservatorioNao;
        private MobileTools.Controls.RadioButtonEx rbReservatorioSim;
        private System.Windows.Forms.TextBox tbxInfComplementar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOcorrencias;
        private System.Windows.Forms.DateTimePicker dtpDataTermino;
        private System.Windows.Forms.Label lblPrevisaoTermino;
        private System.Windows.Forms.ComboBox cbxSitImovel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSourceCadastro;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox cbxIncompativel;
        private System.Windows.Forms.TextBox tbxNumero;
        private MobileTools.Controls.UltraButton ubtnRemove4;
        private MobileTools.Controls.UltraButton ubtnRemove3;
        private MobileTools.Controls.UltraButton ubtnRemove2;
        private MobileTools.Controls.UltraButton ubtnRemove1;


    }
}