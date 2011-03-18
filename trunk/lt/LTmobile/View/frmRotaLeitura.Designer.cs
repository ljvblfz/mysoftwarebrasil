namespace LTmobile.View
{
    partial class frmRotaLeitura
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnExecutar = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnPesqUC = new System.Windows.Forms.MenuItem();
            this.mnEstatistica = new System.Windows.Forms.MenuItem();
            this.mnUcProvisoria = new System.Windows.Forms.MenuItem();
            this.mnMensagemUc = new System.Windows.Forms.MenuItem();
            this.mnInverterRoteiro = new System.Windows.Forms.MenuItem();
            this.mnExibir = new System.Windows.Forms.MenuItem();
            this.mnExibirRepasse = new System.Windows.Forms.MenuItem();
            this.mnExibirNaoExecutados = new System.Windows.Forms.MenuItem();
            this.mnExibirPrimExec = new System.Windows.Forms.MenuItem();
            this.mnExibirTodas = new System.Windows.Forms.MenuItem();
            this.mnMensagem = new System.Windows.Forms.MenuItem();
            this.mnMsgCaixaEntrada = new System.Windows.Forms.MenuItem();
            this.mnMsgCaixaSaida = new System.Windows.Forms.MenuItem();
            this.mnMsgEnviarMsg = new System.Windows.Forms.MenuItem();
            this.mnModoInd = new System.Windows.Forms.MenuItem();
            this.mnFotos = new System.Windows.Forms.MenuItem();
            this.mnFechar = new System.Windows.Forms.MenuItem();
            this.tlRotaLeitura = new MobileTools.Controls.Title();
            this.bsRotaLeitura = new System.Windows.Forms.BindingSource(this.components);
            this.grdRotaLeitura = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.txbEndereco = new System.Windows.Forms.TextBox();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.txbUc = new System.Windows.Forms.TextBox();
            this.lblUc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaLeitura)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnExecutar);
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // btnExecutar
            // 
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.mnPesqUC);
            this.menuItem1.MenuItems.Add(this.mnEstatistica);
            this.menuItem1.MenuItems.Add(this.mnUcProvisoria);
            this.menuItem1.MenuItems.Add(this.mnMensagemUc);
            this.menuItem1.MenuItems.Add(this.mnInverterRoteiro);
            this.menuItem1.MenuItems.Add(this.mnExibir);
            this.menuItem1.MenuItems.Add(this.mnMensagem);
            this.menuItem1.MenuItems.Add(this.mnModoInd);
            this.menuItem1.MenuItems.Add(this.mnFotos);
            this.menuItem1.MenuItems.Add(this.mnFechar);
            this.menuItem1.Text = "Menu";
            // 
            // mnPesqUC
            // 
            this.mnPesqUC.Text = "Pesquisar UC";
            this.mnPesqUC.Click += new System.EventHandler(this.mnPesqUC_Click);
            // 
            // mnEstatistica
            // 
            this.mnEstatistica.Text = "Estatística";
            this.mnEstatistica.Click += new System.EventHandler(this.mnEstatistica_Click);
            // 
            // mnUcProvisoria
            // 
            this.mnUcProvisoria.Text = "UC Provisória";
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
            this.mnExibir.MenuItems.Add(this.mnExibirNaoExecutados);
            this.mnExibir.MenuItems.Add(this.mnExibirPrimExec);
            this.mnExibir.MenuItems.Add(this.mnExibirTodas);
            this.mnExibir.Text = "Exibir";
            // 
            // mnExibirRepasse
            // 
            this.mnExibirRepasse.Text = "Repasse";
            this.mnExibirRepasse.Click += new System.EventHandler(this.mnExibirRepasse_Click);
            // 
            // mnExibirNaoExecutados
            // 
            this.mnExibirNaoExecutados.Text = "Não Executados";
            this.mnExibirNaoExecutados.Click += new System.EventHandler(this.mnExibirNaoExecutados_Click);
            // 
            // mnExibirPrimExec
            // 
            this.mnExibirPrimExec.Text = "Primeira Execução";
            this.mnExibirPrimExec.Click += new System.EventHandler(this.mnExibirPrimExec_Click);
            // 
            // mnExibirTodas
            // 
            this.mnExibirTodas.Text = "Todas";
            this.mnExibirTodas.Click += new System.EventHandler(this.mnExibirTodas_Click);
            // 
            // mnMensagem
            // 
            this.mnMensagem.MenuItems.Add(this.mnMsgCaixaEntrada);
            this.mnMensagem.MenuItems.Add(this.mnMsgCaixaSaida);
            this.mnMensagem.MenuItems.Add(this.mnMsgEnviarMsg);
            this.mnMensagem.Text = "Mensagem";
            // 
            // mnMsgCaixaEntrada
            // 
            this.mnMsgCaixaEntrada.Text = "Caixa de Entrada";
            this.mnMsgCaixaEntrada.Click += new System.EventHandler(this.mnMsgCaixaEntrada_Click);
            // 
            // mnMsgCaixaSaida
            // 
            this.mnMsgCaixaSaida.Text = "Caixa de Saída";
            this.mnMsgCaixaSaida.Click += new System.EventHandler(this.mnMsgCaixaSaida_Click);
            // 
            // mnMsgEnviarMsg
            // 
            this.mnMsgEnviarMsg.Text = "Enviar Mensagem";
            this.mnMsgEnviarMsg.Click += new System.EventHandler(this.mnMsgEnviarMsg_Click);
            // 
            // mnModoInd
            // 
            this.mnModoInd.Text = "Modo Individual";
            this.mnModoInd.Click += new System.EventHandler(this.mnModoInd_Click);
            // 
            // mnFotos
            // 
            this.mnFotos.Text = "Fotos";
            this.mnFotos.Click += new System.EventHandler(this.mnFotos_Click);
            // 
            // mnFechar
            // 
            this.mnFechar.Text = "Sair";
            this.mnFechar.Click += new System.EventHandler(this.mnFechar_Click);
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
            this.tlRotaLeitura.TabIndex = 13;
            this.tlRotaLeitura.Text = "Rota de Leitura - Lista";
            this.tlRotaLeitura.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlRotaLeitura.WidthInclination = 10;
            // 
            // bsRotaLeitura
            // 
            this.bsRotaLeitura.DataSource = typeof(LTmobileData.Data.Model.Leitura);
            // 
            // grdRotaLeitura
            // 
            this.grdRotaLeitura.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdRotaLeitura.DataSource = this.bsRotaLeitura;
            this.grdRotaLeitura.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.grdRotaLeitura.Location = new System.Drawing.Point(0, 28);
            this.grdRotaLeitura.Name = "grdRotaLeitura";
            this.grdRotaLeitura.SelectionForeColor = System.Drawing.SystemColors.Info;
            this.grdRotaLeitura.Size = new System.Drawing.Size(231, 74);
            this.grdRotaLeitura.TabIndex = 14;
            this.grdRotaLeitura.TableStyles.Add(this.dataGridTableStyle1);
            this.grdRotaLeitura.CurrentCellChanged += new System.EventHandler(this.grdRotaLeitura_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn10);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.MappingName = "Leitura";
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Livro";
            this.dataGridTextBoxColumn10.MappingName = "NUM_LIVRO";
            this.dataGridTextBoxColumn10.Width = 35;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Seq.";
            this.dataGridTextBoxColumn1.MappingName = "SEQ_ROTR_OPER";
            this.dataGridTextBoxColumn1.NullText = "Seq.";
            this.dataGridTextBoxColumn1.Width = 27;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "End.";
            this.dataGridTextBoxColumn2.MappingName = "ENDER_UC";
            this.dataGridTextBoxColumn2.NullText = "End.";
            this.dataGridTextBoxColumn2.Width = 55;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Compl.";
            this.dataGridTextBoxColumn3.MappingName = "COMPL_ENDER";
            this.dataGridTextBoxColumn3.NullText = "Compl.";
            this.dataGridTextBoxColumn3.Width = 37;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Status";
            this.dataGridTextBoxColumn6.MappingName = "status";
            this.dataGridTextBoxColumn6.NullText = "Status";
            this.dataGridTextBoxColumn6.Width = 32;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Sit.";
            this.dataGridTextBoxColumn4.MappingName = "SITUAC_UC";
            this.dataGridTextBoxColumn4.NullText = "Sit.";
            this.dataGridTextBoxColumn4.Width = 20;
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(3, 105);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(35, 21);
            this.lblEndereco.Text = "End.:";
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(3, 136);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(51, 14);
            this.lblMedidor.Text = "Medidor:";
            // 
            // txbEndereco
            // 
            this.txbEndereco.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbEndereco.Location = new System.Drawing.Point(32, 105);
            this.txbEndereco.Multiline = true;
            this.txbEndereco.Name = "txbEndereco";
            this.txbEndereco.Size = new System.Drawing.Size(202, 29);
            this.txbEndereco.TabIndex = 15;
            this.txbEndereco.TabStop = false;
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(57, 136);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(72, 19);
            this.txbMedidorUc.TabIndex = 19;
            this.txbMedidorUc.TabStop = false;
            // 
            // txbUc
            // 
            this.txbUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbUc.Location = new System.Drawing.Point(167, 137);
            this.txbUc.Name = "txbUc";
            this.txbUc.Size = new System.Drawing.Size(64, 19);
            this.txbUc.TabIndex = 23;
            this.txbUc.TabStop = false;
            // 
            // lblUc
            // 
            this.lblUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblUc.Location = new System.Drawing.Point(142, 137);
            this.lblUc.Name = "lblUc";
            this.lblUc.Size = new System.Drawing.Size(22, 14);
            this.lblUc.Text = "Uc:";
            // 
            // frmRotaLeitura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbUc);
            this.Controls.Add(this.lblUc);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.txbEndereco);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.grdRotaLeitura);
            this.Controls.Add(this.tlRotaLeitura);
            this.Menu = this.mainMenu1;
            this.Name = "frmRotaLeitura";
            this.Text = "frmRotaLeitura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRotaLeitura_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRotaLeitura_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaLeitura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlRotaLeitura;
        private System.Windows.Forms.DataGrid grdRotaLeitura;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.TextBox txbEndereco;
        private System.Windows.Forms.BindingSource bsRotaLeitura;
        private System.Windows.Forms.MenuItem btnExecutar;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnPesqUC;
        private System.Windows.Forms.MenuItem mnEstatistica;
        private System.Windows.Forms.MenuItem mnUcProvisoria;
        private System.Windows.Forms.MenuItem mnMensagemUc;
        private System.Windows.Forms.MenuItem mnInverterRoteiro;
        private System.Windows.Forms.MenuItem mnExibir;
        private System.Windows.Forms.MenuItem mnExibirRepasse;
        private System.Windows.Forms.MenuItem mnExibirNaoExecutados;
        private System.Windows.Forms.MenuItem mnExibirPrimExec;
        private System.Windows.Forms.MenuItem mnExibirTodas;
        private System.Windows.Forms.MenuItem mnMensagem;
        private System.Windows.Forms.MenuItem mnMsgCaixaEntrada;
        private System.Windows.Forms.MenuItem mnMsgCaixaSaida;
        private System.Windows.Forms.MenuItem mnMsgEnviarMsg;
        private System.Windows.Forms.MenuItem mnModoInd;
        private System.Windows.Forms.MenuItem mnFotos;
        private System.Windows.Forms.MenuItem mnFechar;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.TextBox txbUc;
        private System.Windows.Forms.Label lblUc;
    }
}