namespace LTmobile.View
{
    partial class frmRotaLeituraIndividual
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRotaLeituraIndividual));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnLeitura = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnFormatoLeitura = new System.Windows.Forms.MenuItem();
            this.mnDir_Esq = new System.Windows.Forms.MenuItem();
            this.mnEsq_Dir = new System.Windows.Forms.MenuItem();
            this.mnPesquisarUc = new System.Windows.Forms.MenuItem();
            this.mnEstatistica = new System.Windows.Forms.MenuItem();
            this.mnUcProvisoria = new System.Windows.Forms.MenuItem();
            this.mnMensagemUc = new System.Windows.Forms.MenuItem();
            this.mnInverterRoteiro = new System.Windows.Forms.MenuItem();
            this.mnExibir = new System.Windows.Forms.MenuItem();
            this.mnExibirRepasse = new System.Windows.Forms.MenuItem();
            this.mnNaoExecutados = new System.Windows.Forms.MenuItem();
            this.mnExibirPExecucao = new System.Windows.Forms.MenuItem();
            this.mnExibirTodas = new System.Windows.Forms.MenuItem();
            this.mnMensagem = new System.Windows.Forms.MenuItem();
            this.mnCaixaEntrada = new System.Windows.Forms.MenuItem();
            this.mnCaixaSaida = new System.Windows.Forms.MenuItem();
            this.mnEnviarMsg = new System.Windows.Forms.MenuItem();
            this.mnFotos = new System.Windows.Forms.MenuItem();
            this.mnOcorrencia = new System.Windows.Forms.MenuItem();
            this.mnObservacao = new System.Windows.Forms.MenuItem();
            this.mnSincronizar = new System.Windows.Forms.MenuItem();
            this.mnNomeCliente = new System.Windows.Forms.MenuItem();
            this.mnFechar = new System.Windows.Forms.MenuItem();
            this.txbEndereco = new System.Windows.Forms.TextBox();
            this.bsRotaLeituraIndividual = new System.Windows.Forms.BindingSource(this.components);
            this.lblEndereco = new System.Windows.Forms.Label();
            this.imgCarta = new System.Windows.Forms.PictureBox();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.txbC = new System.Windows.Forms.TextBox();
            this.txbLeitura = new System.Windows.Forms.TextBox();
            this.lblLeitura = new System.Windows.Forms.Label();
            this.txbIrreg1 = new System.Windows.Forms.TextBox();
            this.lblIrreg1 = new System.Windows.Forms.Label();
            this.txbIrreg2 = new System.Windows.Forms.TextBox();
            this.lblIrreg2 = new System.Windows.Forms.Label();
            this.txbIrreg3 = new System.Windows.Forms.TextBox();
            this.lblIrreg3 = new System.Windows.Forms.Label();
            this.txbSit = new System.Windows.Forms.TextBox();
            this.lblSit = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.txbMe = new System.Windows.Forms.TextBox();
            this.lblMe = new System.Windows.Forms.Label();
            this.txbFoco = new System.Windows.Forms.TextBox();
            this.tlRotaLeitura = new MobileTools.Controls.Title();
            this.txbsequencia = new System.Windows.Forms.TextBox();
            this.lblSeq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaLeituraIndividual)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnLeitura);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnLeitura
            // 
            this.btnLeitura.Text = "Leitura";
            this.btnLeitura.Click += new System.EventHandler(this.btnLeitura_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnFormatoLeitura);
            this.mnMenu.MenuItems.Add(this.mnPesquisarUc);
            this.mnMenu.MenuItems.Add(this.mnEstatistica);
            this.mnMenu.MenuItems.Add(this.mnUcProvisoria);
            this.mnMenu.MenuItems.Add(this.mnMensagemUc);
            this.mnMenu.MenuItems.Add(this.mnInverterRoteiro);
            this.mnMenu.MenuItems.Add(this.mnExibir);
            this.mnMenu.MenuItems.Add(this.mnMensagem);
            this.mnMenu.MenuItems.Add(this.mnFotos);
            this.mnMenu.MenuItems.Add(this.mnOcorrencia);
            this.mnMenu.MenuItems.Add(this.mnObservacao);
            this.mnMenu.MenuItems.Add(this.mnSincronizar);
            this.mnMenu.MenuItems.Add(this.mnNomeCliente);
            this.mnMenu.MenuItems.Add(this.mnFechar);
            this.mnMenu.Text = "Menu";
            // 
            // mnFormatoLeitura
            // 
            this.mnFormatoLeitura.MenuItems.Add(this.mnDir_Esq);
            this.mnFormatoLeitura.MenuItems.Add(this.mnEsq_Dir);
            this.mnFormatoLeitura.Text = "Formato da Leitura";
            // 
            // mnDir_Esq
            // 
            this.mnDir_Esq.Text = "Direita/Esquerda";
            this.mnDir_Esq.Click += new System.EventHandler(this.mnDir_Esq_Click);
            // 
            // mnEsq_Dir
            // 
            this.mnEsq_Dir.Text = "Esquerda/Direita";
            this.mnEsq_Dir.Click += new System.EventHandler(this.mnEsq_Dir_Click);
            // 
            // mnPesquisarUc
            // 
            this.mnPesquisarUc.Text = "Pesquisar UC";
            this.mnPesquisarUc.Click += new System.EventHandler(this.mnPesquisarUc_Click);
            // 
            // mnEstatistica
            // 
            this.mnEstatistica.Text = "Estatística";
            this.mnEstatistica.Click += new System.EventHandler(this.mnEstatistica_Click);
            // 
            // mnUcProvisoria
            // 
            this.mnUcProvisoria.Text = "Uc Provisória";
            this.mnUcProvisoria.Click += new System.EventHandler(this.mnUcProvisoria_Click);
            // 
            // mnMensagemUc
            // 
            this.mnMensagemUc.Text = "Mensagem da Uc";
            this.mnMensagemUc.Click += new System.EventHandler(this.mnMensagemUc_Click);
            // 
            // mnInverterRoteiro
            // 
            this.mnInverterRoteiro.Text = "Inverter Roteiro";
            this.mnInverterRoteiro.Click += new System.EventHandler(this.mnInverterRoteiro_Click);
            // 
            // mnExibir
            // 
            this.mnExibir.MenuItems.Add(this.mnExibirRepasse);
            this.mnExibir.MenuItems.Add(this.mnNaoExecutados);
            this.mnExibir.MenuItems.Add(this.mnExibirPExecucao);
            this.mnExibir.MenuItems.Add(this.mnExibirTodas);
            this.mnExibir.Text = "Exibir";
            // 
            // mnExibirRepasse
            // 
            this.mnExibirRepasse.Text = "Repasse";
            this.mnExibirRepasse.Click += new System.EventHandler(this.mnExibirRepasse_Click);
            // 
            // mnNaoExecutados
            // 
            this.mnNaoExecutados.Text = "Não Executados";
            this.mnNaoExecutados.Click += new System.EventHandler(this.mnNaoExecutados_Click);
            // 
            // mnExibirPExecucao
            // 
            this.mnExibirPExecucao.Text = "Primeira Execução";
            this.mnExibirPExecucao.Click += new System.EventHandler(this.mnExibirPExecucao_Click);
            // 
            // mnExibirTodas
            // 
            this.mnExibirTodas.Text = "Todas";
            this.mnExibirTodas.Click += new System.EventHandler(this.mnExibirTodas_Click);
            // 
            // mnMensagem
            // 
            this.mnMensagem.MenuItems.Add(this.mnCaixaEntrada);
            this.mnMensagem.MenuItems.Add(this.mnCaixaSaida);
            this.mnMensagem.MenuItems.Add(this.mnEnviarMsg);
            this.mnMensagem.Text = "Correio";
            // 
            // mnCaixaEntrada
            // 
            this.mnCaixaEntrada.Text = "Caixa de Entrada";
            this.mnCaixaEntrada.Click += new System.EventHandler(this.mnCaixaEntrada_Click);
            // 
            // mnCaixaSaida
            // 
            this.mnCaixaSaida.Text = "Caixa de Saída";
            this.mnCaixaSaida.Click += new System.EventHandler(this.mnCaixaSaida_Click);
            // 
            // mnEnviarMsg
            // 
            this.mnEnviarMsg.Text = "Enviar Mensagem";
            this.mnEnviarMsg.Click += new System.EventHandler(this.mnEnviarMsg_Click);
            // 
            // mnFotos
            // 
            this.mnFotos.Text = "Fotos";
            this.mnFotos.Click += new System.EventHandler(this.mnFotos_Click);
            // 
            // mnOcorrencia
            // 
            this.mnOcorrencia.Text = "Pesq. Irregularidade";
            this.mnOcorrencia.Click += new System.EventHandler(this.mnOcorrencia_Click);
            // 
            // mnObservacao
            // 
            this.mnObservacao.Text = "Observação p/ UC";
            this.mnObservacao.Click += new System.EventHandler(this.mnObservacao_Click);
            // 
            // mnSincronizar
            // 
            this.mnSincronizar.Text = "Sincronizar";
            this.mnSincronizar.Click += new System.EventHandler(this.mnSincronizar_Click);
            // 
            // mnNomeCliente
            // 
            this.mnNomeCliente.Text = "Nome Cliente";
            this.mnNomeCliente.Click += new System.EventHandler(this.mnNomeCliente_Click);
            // 
            // mnFechar
            // 
            this.mnFechar.Text = "Sair";
            this.mnFechar.Click += new System.EventHandler(this.mnFechar_Click);
            // 
            // txbEndereco
            // 
            this.txbEndereco.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "EnderecoComplemento", true));
            this.txbEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbEndereco.Location = new System.Drawing.Point(50, 30);
            this.txbEndereco.Multiline = true;
            this.txbEndereco.Name = "txbEndereco";
            this.txbEndereco.Size = new System.Drawing.Size(158, 35);
            this.txbEndereco.TabIndex = 22;
            this.txbEndereco.TabStop = false;
            // 
            // bsRotaLeituraIndividual
            // 
            this.bsRotaLeituraIndividual.DataSource = typeof(LTmobileData.Data.Model.Leitura);
            this.bsRotaLeituraIndividual.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.bsRotaLeituraIndividual_BindingComplete);
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(4, 30);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(35, 21);
            this.lblEndereco.Text = "End.:";
            // 
            // imgCarta
            // 
            this.imgCarta.Image = ((System.Drawing.Image)(resources.GetObject("imgCarta.Image")));
            this.imgCarta.Location = new System.Drawing.Point(212, 34);
            this.imgCarta.Name = "imgCarta";
            this.imgCarta.Size = new System.Drawing.Size(17, 16);
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "MedidorTipoMed", true));
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(49, 68);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(74, 19);
            this.txbMedidorUc.TabIndex = 38;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(4, 74);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(51, 14);
            this.lblMedidor.Text = "Medidor:";
            // 
            // lblC
            // 
            this.lblC.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblC.Location = new System.Drawing.Point(182, 75);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(16, 12);
            this.lblC.Text = "C:";
            // 
            // txbC
            // 
            this.txbC.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "FATOR_MULTIP", true));
            this.txbC.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbC.Location = new System.Drawing.Point(197, 68);
            this.txbC.Name = "txbC";
            this.txbC.Size = new System.Drawing.Size(23, 19);
            this.txbC.TabIndex = 48;
            this.txbC.TabStop = false;
            // 
            // txbLeitura
            // 
            this.txbLeitura.BackColor = System.Drawing.SystemColors.Info;
            this.txbLeitura.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "LEITUR_VISITA", true));
            this.txbLeitura.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.txbLeitura.Location = new System.Drawing.Point(50, 91);
            this.txbLeitura.MaxLength = 6;
            this.txbLeitura.Name = "txbLeitura";
            this.txbLeitura.Size = new System.Drawing.Size(170, 23);
            this.txbLeitura.TabIndex = 0;
            this.txbLeitura.TabStop = false;
            this.txbLeitura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblLeitura
            // 
            this.lblLeitura.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeitura.Location = new System.Drawing.Point(4, 95);
            this.lblLeitura.Name = "lblLeitura";
            this.lblLeitura.Size = new System.Drawing.Size(46, 21);
            this.lblLeitura.Text = "Leitura:";
            // 
            // txbIrreg1
            // 
            this.txbIrreg1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txbIrreg1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "IRREGL_ATUAL1", true));
            this.txbIrreg1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbIrreg1.Location = new System.Drawing.Point(50, 117);
            this.txbIrreg1.MaxLength = 3;
            this.txbIrreg1.Name = "txbIrreg1";
            this.txbIrreg1.Size = new System.Drawing.Size(22, 19);
            this.txbIrreg1.TabIndex = 1;
            this.txbIrreg1.TabStop = false;
            this.txbIrreg1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbIrreg1_KeyDown);
            this.txbIrreg1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbIrreg1_KeyUp);
            this.txbIrreg1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressComun);
            // 
            // lblIrreg1
            // 
            this.lblIrreg1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblIrreg1.Location = new System.Drawing.Point(5, 120);
            this.lblIrreg1.Name = "lblIrreg1";
            this.lblIrreg1.Size = new System.Drawing.Size(41, 14);
            this.lblIrreg1.Text = "Irreg.1:";
            // 
            // txbIrreg2
            // 
            this.txbIrreg2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txbIrreg2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "IRREGL_ATUAL2", true));
            this.txbIrreg2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbIrreg2.Location = new System.Drawing.Point(123, 117);
            this.txbIrreg2.MaxLength = 3;
            this.txbIrreg2.Name = "txbIrreg2";
            this.txbIrreg2.Size = new System.Drawing.Size(22, 19);
            this.txbIrreg2.TabIndex = 2;
            this.txbIrreg2.TabStop = false;
            this.txbIrreg2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbIrreg2_KeyDown);
            this.txbIrreg2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbIrreg2_KeyUp);
            this.txbIrreg2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressComun);
            // 
            // lblIrreg2
            // 
            this.lblIrreg2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblIrreg2.Location = new System.Drawing.Point(80, 122);
            this.lblIrreg2.Name = "lblIrreg2";
            this.lblIrreg2.Size = new System.Drawing.Size(41, 14);
            this.lblIrreg2.Text = "Irreg.2:";
            // 
            // txbIrreg3
            // 
            this.txbIrreg3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txbIrreg3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "IRREGL_ATUAL3", true));
            this.txbIrreg3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbIrreg3.Location = new System.Drawing.Point(198, 117);
            this.txbIrreg3.MaxLength = 3;
            this.txbIrreg3.Name = "txbIrreg3";
            this.txbIrreg3.Size = new System.Drawing.Size(22, 19);
            this.txbIrreg3.TabIndex = 3;
            this.txbIrreg3.TabStop = false;
            this.txbIrreg3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressComun);
            // 
            // lblIrreg3
            // 
            this.lblIrreg3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblIrreg3.Location = new System.Drawing.Point(154, 122);
            this.lblIrreg3.Name = "lblIrreg3";
            this.lblIrreg3.Size = new System.Drawing.Size(41, 14);
            this.lblIrreg3.Text = "Irreg.3:";
            // 
            // txbSit
            // 
            this.txbSit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbSit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "SITUAC_UC", true));
            this.txbSit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbSit.Location = new System.Drawing.Point(49, 137);
            this.txbSit.Name = "txbSit";
            this.txbSit.Size = new System.Drawing.Size(23, 19);
            this.txbSit.TabIndex = 62;
            this.txbSit.TabStop = false;
            // 
            // lblSit
            // 
            this.lblSit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblSit.Location = new System.Drawing.Point(24, 143);
            this.lblSit.Name = "lblSit";
            this.lblSit.Size = new System.Drawing.Size(25, 13);
            this.lblSit.Text = "Sit.:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "CLASSE_CONSUMO", true));
            this.textBox1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(123, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(22, 19);
            this.textBox1.TabIndex = 65;
            this.textBox1.TabStop = false;
            // 
            // lblCI
            // 
            this.lblCI.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblCI.Location = new System.Drawing.Point(101, 143);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(22, 13);
            this.lblCI.Text = "Cl.:";
            // 
            // txbMe
            // 
            this.txbMe.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbMe.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "QTDE_LEITUR_ESTIMD", true));
            this.txbMe.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMe.Location = new System.Drawing.Point(198, 137);
            this.txbMe.Name = "txbMe";
            this.txbMe.Size = new System.Drawing.Size(22, 19);
            this.txbMe.TabIndex = 68;
            this.txbMe.TabStop = false;
            // 
            // lblMe
            // 
            this.lblMe.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMe.Location = new System.Drawing.Point(173, 143);
            this.lblMe.Name = "lblMe";
            this.lblMe.Size = new System.Drawing.Size(25, 13);
            this.lblMe.Text = "ME:";
            // 
            // txbFoco
            // 
            this.txbFoco.Location = new System.Drawing.Point(5, 143);
            this.txbFoco.Name = "txbFoco";
            this.txbFoco.Size = new System.Drawing.Size(7, 22);
            this.txbFoco.TabIndex = 84;
            this.txbFoco.TabStop = false;
            this.txbFoco.Visible = false;
            // 
            // tlRotaLeitura
            // 
            this.tlRotaLeitura.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlRotaLeitura.DistanceWordLine = 2;
            this.tlRotaLeitura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlRotaLeitura.HeightLine = 10;
            this.tlRotaLeitura.Location = new System.Drawing.Point(0, 0);
            this.tlRotaLeitura.Name = "tlRotaLeitura";
            this.tlRotaLeitura.Size = new System.Drawing.Size(224, 28);
            this.tlRotaLeitura.TabIndex = 14;
            this.tlRotaLeitura.Text = "Execução de Leitura";
            this.tlRotaLeitura.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlRotaLeitura.WidthInclination = 10;
            // 
            // txbsequencia
            // 
            this.txbsequencia.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbsequencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRotaLeituraIndividual, "SEQ_ROTR_OPER", true));
            this.txbsequencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbsequencia.Location = new System.Drawing.Point(156, 68);
            this.txbsequencia.Name = "txbsequencia";
            this.txbsequencia.Size = new System.Drawing.Size(20, 19);
            this.txbsequencia.TabIndex = 97;
            this.txbsequencia.TabStop = false;
            // 
            // lblSeq
            // 
            this.lblSeq.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblSeq.Location = new System.Drawing.Point(125, 72);
            this.lblSeq.Name = "lblSeq";
            this.lblSeq.Size = new System.Drawing.Size(31, 13);
            this.lblSeq.Text = "Seq.:";
            // 
            // frmRotaLeituraIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbsequencia);
            this.Controls.Add(this.lblSeq);
            this.Controls.Add(this.txbFoco);
            this.Controls.Add(this.txbMe);
            this.Controls.Add(this.lblMe);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCI);
            this.Controls.Add(this.txbSit);
            this.Controls.Add(this.lblSit);
            this.Controls.Add(this.txbIrreg3);
            this.Controls.Add(this.lblIrreg3);
            this.Controls.Add(this.txbIrreg2);
            this.Controls.Add(this.lblIrreg2);
            this.Controls.Add(this.txbIrreg1);
            this.Controls.Add(this.lblIrreg1);
            this.Controls.Add(this.txbLeitura);
            this.Controls.Add(this.lblLeitura);
            this.Controls.Add(this.txbC);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.imgCarta);
            this.Controls.Add(this.txbEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.tlRotaLeitura);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmRotaLeituraIndividual";
            this.Text = "frmRotaLeituraIndividual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRotaLeituraIndividual_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRotaLeituraIndividual_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRotaLeituraIndividual_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaLeituraIndividual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlRotaLeitura;
        private System.Windows.Forms.TextBox txbEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.MenuItem btnLeitura;
        private System.Windows.Forms.PictureBox imgCarta;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnEstatistica;
        private System.Windows.Forms.MenuItem mnUcProvisoria;
        private System.Windows.Forms.MenuItem mnMensagemUc;
        private System.Windows.Forms.MenuItem mnInverterRoteiro;
        private System.Windows.Forms.MenuItem mnExibir;
        private System.Windows.Forms.MenuItem mnExibirRepasse;
        private System.Windows.Forms.MenuItem mnNaoExecutados;
        private System.Windows.Forms.MenuItem mnExibirPExecucao;
        private System.Windows.Forms.MenuItem mnExibirTodas;
        private System.Windows.Forms.MenuItem mnMensagem;
        private System.Windows.Forms.MenuItem mnCaixaEntrada;
        private System.Windows.Forms.MenuItem mnCaixaSaida;
        private System.Windows.Forms.MenuItem mnEnviarMsg;
        private System.Windows.Forms.MenuItem mnFotos;
        private System.Windows.Forms.MenuItem mnFechar;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.TextBox txbC;
        private System.Windows.Forms.TextBox txbLeitura;
        private System.Windows.Forms.Label lblLeitura;
        private System.Windows.Forms.TextBox txbIrreg1;
        private System.Windows.Forms.Label lblIrreg1;
        private System.Windows.Forms.TextBox txbIrreg2;
        private System.Windows.Forms.Label lblIrreg2;
        private System.Windows.Forms.TextBox txbIrreg3;
        private System.Windows.Forms.Label lblIrreg3;
        private System.Windows.Forms.TextBox txbSit;
        private System.Windows.Forms.Label lblSit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCI;
        private System.Windows.Forms.TextBox txbMe;
        private System.Windows.Forms.Label lblMe;
        public System.Windows.Forms.MenuItem mnPesquisarUc;
        private System.Windows.Forms.MenuItem mnOcorrencia;
        private System.Windows.Forms.TextBox txbFoco;
        private System.Windows.Forms.BindingSource bsRotaLeituraIndividual;
        private System.Windows.Forms.MenuItem mnObservacao;
        private System.Windows.Forms.MenuItem mnSincronizar;
        private System.Windows.Forms.MenuItem mnFormatoLeitura;
        private System.Windows.Forms.MenuItem mnDir_Esq;
        private System.Windows.Forms.MenuItem mnEsq_Dir;
        private System.Windows.Forms.TextBox txbsequencia;
        private System.Windows.Forms.Label lblSeq;
        private System.Windows.Forms.MenuItem mnNomeCliente;
    }
}