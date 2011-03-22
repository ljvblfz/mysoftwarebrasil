namespace SPCadMobile.View
{
    partial class frmExecucaoPesquisa : CustomForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnInfoAdicional = new System.Windows.Forms.Button();
            this.btnImovel = new System.Windows.Forms.Button();
            this.btnHidrometro = new System.Windows.Forms.Button();
            this.btnConsumo = new System.Windows.Forms.Button();
            this.tbxEndereco = new System.Windows.Forms.TextBox();
            this.bindingSourceCadastro = new System.Windows.Forms.BindingSource(this.components);
            this.lblEndereco = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbxMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.tbxMed = new System.Windows.Forms.TextBox();
            this.lblHidrometro = new System.Windows.Forms.Label();
            this.chxInfoAdicional = new System.Windows.Forms.CheckBox();
            this.chxConsumo = new System.Windows.Forms.CheckBox();
            this.chxHidrometro = new System.Windows.Forms.CheckBox();
            this.chxImovel = new System.Windows.Forms.CheckBox();
            this.lblSituacaoValue = new System.Windows.Forms.Label();
            this.tbxQtdPS = new System.Windows.Forms.TextBox();
            this.lblQtdPS = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title1.Text = "Execução Pesquisa";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Concluir";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // chkConfirmado
            // 
            this.chkConfirmado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // lblAlterado
            // 
            this.lblAlterado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tbxQtdPS);
            this.panel.Controls.Add(this.lblQtdPS);
            this.panel.Controls.Add(this.chxInfoAdicional);
            this.panel.Controls.Add(this.btnInfoAdicional);
            this.panel.Controls.Add(this.chxConsumo);
            this.panel.Controls.Add(this.chxHidrometro);
            this.panel.Controls.Add(this.btnImovel);
            this.panel.Controls.Add(this.btnHidrometro);
            this.panel.Controls.Add(this.chxImovel);
            this.panel.Controls.Add(this.btnConsumo);
            this.panel.Controls.Add(this.tbxEndereco);
            this.panel.Controls.Add(this.lblEndereco);
            this.panel.Controls.Add(this.tbxCliente);
            this.panel.Controls.Add(this.lblCliente);
            this.panel.Controls.Add(this.tbxMatricula);
            this.panel.Controls.Add(this.lblMatricula);
            this.panel.Controls.Add(this.tbxMed);
            this.panel.Controls.Add(this.lblHidrometro);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Execução Pesquisa";
            // 
            // btnInfoAdicional
            // 
            this.btnInfoAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfoAdicional.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInfoAdicional.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnInfoAdicional.Location = new System.Drawing.Point(3, 232);
            this.btnInfoAdicional.Name = "btnInfoAdicional";
            this.btnInfoAdicional.Size = new System.Drawing.Size(207, 20);
            this.btnInfoAdicional.TabIndex = 12;
            this.btnInfoAdicional.Text = "Informação Adicional";
            this.btnInfoAdicional.Click += new System.EventHandler(this.btnInfoAdicional_Click);
            // 
            // btnImovel
            // 
            this.btnImovel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImovel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnImovel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnImovel.Location = new System.Drawing.Point(3, 163);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(207, 20);
            this.btnImovel.TabIndex = 6;
            this.btnImovel.Text = "Imóvel";
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // btnHidrometro
            // 
            this.btnHidrometro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHidrometro.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHidrometro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnHidrometro.Location = new System.Drawing.Point(3, 186);
            this.btnHidrometro.Name = "btnHidrometro";
            this.btnHidrometro.Size = new System.Drawing.Size(207, 20);
            this.btnHidrometro.TabIndex = 8;
            this.btnHidrometro.Text = "Ponto de Serviço / Hidrômetro";
            this.btnHidrometro.Click += new System.EventHandler(this.btnHidrometro_Click);
            // 
            // btnConsumo
            // 
            this.btnConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsumo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConsumo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnConsumo.Location = new System.Drawing.Point(3, 209);
            this.btnConsumo.Name = "btnConsumo";
            this.btnConsumo.Size = new System.Drawing.Size(207, 20);
            this.btnConsumo.TabIndex = 10;
            this.btnConsumo.Text = "Consumo";
            this.btnConsumo.Click += new System.EventHandler(this.btnConsumo_Click);
            // 
            // tbxEndereco
            // 
            this.tbxEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "enderecoImovel", true));
            this.tbxEndereco.Location = new System.Drawing.Point(3, 96);
            this.tbxEndereco.Multiline = true;
            this.tbxEndereco.Name = "tbxEndereco";
            this.tbxEndereco.ReadOnly = true;
            this.tbxEndereco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxEndereco.Size = new System.Drawing.Size(232, 61);
            this.tbxEndereco.TabIndex = 5;
            // 
            // bindingSourceCadastro
            // 
            this.bindingSourceCadastro.DataSource = typeof(SPCadMobileData.Data.Model.CadastroAuxiliar);
            // 
            // lblEndereco
            // 
            this.lblEndereco.Location = new System.Drawing.Point(3, 81);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(100, 15);
            this.lblEndereco.Text = "Endereço:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NomeCliente", true));
            this.tbxCliente.Location = new System.Drawing.Point(50, 57);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.ReadOnly = true;
            this.tbxCliente.Size = new System.Drawing.Size(185, 21);
            this.tbxCliente.TabIndex = 4;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(3, 58);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 20);
            this.lblCliente.Text = "Cliente:";
            // 
            // tbxMatricula
            // 
            this.tbxMatricula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Matricula", true));
            this.tbxMatricula.Location = new System.Drawing.Point(40, 30);
            this.tbxMatricula.Name = "tbxMatricula";
            this.tbxMatricula.ReadOnly = true;
            this.tbxMatricula.Size = new System.Drawing.Size(89, 21);
            this.tbxMatricula.TabIndex = 3;
            // 
            // lblMatricula
            // 
            this.lblMatricula.Location = new System.Drawing.Point(3, 31);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(34, 20);
            this.lblMatricula.Text = "Mat:";
            this.lblMatricula.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxMed
            // 
            this.tbxMed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NumeroMedidor", true));
            this.tbxMed.Location = new System.Drawing.Point(40, 3);
            this.tbxMed.Name = "tbxMed";
            this.tbxMed.ReadOnly = true;
            this.tbxMed.Size = new System.Drawing.Size(89, 21);
            this.tbxMed.TabIndex = 1;
            // 
            // lblHidrometro
            // 
            this.lblHidrometro.Location = new System.Drawing.Point(3, 4);
            this.lblHidrometro.Name = "lblHidrometro";
            this.lblHidrometro.Size = new System.Drawing.Size(34, 20);
            this.lblHidrometro.Text = "Med:";
            this.lblHidrometro.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chxInfoAdicional
            // 
            this.chxInfoAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chxInfoAdicional.Enabled = false;
            this.chxInfoAdicional.Location = new System.Drawing.Point(216, 232);
            this.chxInfoAdicional.Name = "chxInfoAdicional";
            this.chxInfoAdicional.Size = new System.Drawing.Size(19, 19);
            this.chxInfoAdicional.TabIndex = 13;
            // 
            // chxConsumo
            // 
            this.chxConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chxConsumo.Enabled = false;
            this.chxConsumo.Location = new System.Drawing.Point(216, 209);
            this.chxConsumo.Name = "chxConsumo";
            this.chxConsumo.Size = new System.Drawing.Size(19, 19);
            this.chxConsumo.TabIndex = 11;
            // 
            // chxHidrometro
            // 
            this.chxHidrometro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chxHidrometro.Enabled = false;
            this.chxHidrometro.Location = new System.Drawing.Point(216, 186);
            this.chxHidrometro.Name = "chxHidrometro";
            this.chxHidrometro.Size = new System.Drawing.Size(19, 19);
            this.chxHidrometro.TabIndex = 9;
            // 
            // chxImovel
            // 
            this.chxImovel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chxImovel.AutoCheck = false;
            this.chxImovel.Enabled = false;
            this.chxImovel.Location = new System.Drawing.Point(216, 163);
            this.chxImovel.Name = "chxImovel";
            this.chxImovel.Size = new System.Drawing.Size(19, 19);
            this.chxImovel.TabIndex = 7;
            // 
            // lblSituacaoValue
            // 
            this.lblSituacaoValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSituacaoValue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSituacaoValue.ForeColor = System.Drawing.Color.Red;
            this.lblSituacaoValue.Location = new System.Drawing.Point(135, 3);
            this.lblSituacaoValue.Name = "lblSituacaoValue";
            this.lblSituacaoValue.Size = new System.Drawing.Size(100, 12);
            // 
            // tbxQtdPS
            // 
            this.tbxQtdPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxQtdPS.Location = new System.Drawing.Point(213, 4);
            this.tbxQtdPS.Name = "tbxQtdPS";
            this.tbxQtdPS.ReadOnly = true;
            this.tbxQtdPS.Size = new System.Drawing.Size(22, 21);
            this.tbxQtdPS.TabIndex = 2;
            // 
            // lblQtdPS
            // 
            this.lblQtdPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdPS.Location = new System.Drawing.Point(141, 5);
            this.lblQtdPS.Name = "lblQtdPS";
            this.lblQtdPS.Size = new System.Drawing.Size(67, 20);
            this.lblQtdPS.Text = "Qtde. P.S.:";
            this.lblQtdPS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmExecucaoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lblSituacaoValue);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmExecucaoPesquisa";
            this.Text = "Execução Pesquisa";
            this.Title = "Execução Pesquisa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.title1, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.chkConfirmado, 0);
            this.Controls.SetChildIndex(this.lblAlterado, 0);
            this.Controls.SetChildIndex(this.lblSituacaoValue, 0);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInfoAdicional;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.Button btnHidrometro;
        private System.Windows.Forms.Button btnConsumo;
        private System.Windows.Forms.TextBox tbxEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbxMatricula;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox tbxMed;
        private System.Windows.Forms.Label lblHidrometro;
        private System.Windows.Forms.CheckBox chxInfoAdicional;
        private System.Windows.Forms.CheckBox chxConsumo;
        private System.Windows.Forms.CheckBox chxHidrometro;
        private System.Windows.Forms.CheckBox chxImovel;
        private System.Windows.Forms.Label lblSituacaoValue;
        private System.Windows.Forms.TextBox tbxQtdPS;
        private System.Windows.Forms.Label lblQtdPS;
        private System.Windows.Forms.BindingSource bindingSourceCadastro;
        private System.ComponentModel.IContainer components;

    }
}