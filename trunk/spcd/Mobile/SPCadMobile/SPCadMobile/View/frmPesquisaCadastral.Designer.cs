namespace SPCadMobile.View
{
    partial class frmPesquisaCadastral : CustomForm
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.bindingSourceCadastro = new System.Windows.Forms.BindingSource(this.components);
            this.lblSituacao = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbxMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.tbxMedidor = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.dataGridListCadastral = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.cbxSit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxRota = new System.Windows.Forms.TextBox();
            this.tbxSetor = new System.Windows.Forms.TextBox();
            this.btnImpedimento = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Executar";
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
            // panel
            // 
            this.panel.Controls.Add(this.btnImpedimento);
            this.panel.Controls.Add(this.lblValorSituacao);
            this.panel.Controls.Add(this.lblSituacao);
            this.panel.Controls.Add(this.tbxCliente);
            this.panel.Controls.Add(this.lblCliente);
            this.panel.Controls.Add(this.tbxMatricula);
            this.panel.Controls.Add(this.lblMatricula);
            this.panel.Controls.Add(this.tbxMedidor);
            this.panel.Controls.Add(this.lblMedidor);
            this.panel.Controls.Add(this.dataGridListCadastral);
            this.panel.Controls.Add(this.cbxSit);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.tbxRota);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.tbxSetor);
            this.panel.Controls.Add(this.label1);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Pesquisa Cadastral";
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValorSituacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "DescricaoSituacao", true));
            this.lblValorSituacao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblValorSituacao.ForeColor = System.Drawing.Color.Red;
            this.lblValorSituacao.Location = new System.Drawing.Point(59, 236);
            this.lblValorSituacao.Name = "lblValorSituacao";
            this.lblValorSituacao.Size = new System.Drawing.Size(109, 20);
            // 
            // bindingSourceCadastro
            // 
            this.bindingSourceCadastro.DataSource = typeof(SPCadMobileData.Data.Model.CadastroAuxiliar);
            // 
            // lblSituacao
            // 
            this.lblSituacao.Location = new System.Drawing.Point(3, 237);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(55, 20);
            this.lblSituacao.Text = "Situação:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NomeCliente", true));
            this.tbxCliente.Location = new System.Drawing.Point(50, 211);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.ReadOnly = true;
            this.tbxCliente.Size = new System.Drawing.Size(187, 21);
            this.tbxCliente.TabIndex = 7;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(3, 212);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 20);
            this.lblCliente.Text = "Cliente:";
            // 
            // tbxMatricula
            // 
            this.tbxMatricula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "Matricula", true));
            this.tbxMatricula.Location = new System.Drawing.Point(50, 186);
            this.tbxMatricula.Name = "tbxMatricula";
            this.tbxMatricula.ReadOnly = true;
            this.tbxMatricula.Size = new System.Drawing.Size(89, 21);
            this.tbxMatricula.TabIndex = 6;
            // 
            // lblMatricula
            // 
            this.lblMatricula.Location = new System.Drawing.Point(3, 187);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(34, 20);
            this.lblMatricula.Text = "Mat:";
            // 
            // tbxMedidor
            // 
            this.tbxMedidor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastro, "NumeroMedidor", true));
            this.tbxMedidor.Location = new System.Drawing.Point(50, 163);
            this.tbxMedidor.Name = "tbxMedidor";
            this.tbxMedidor.ReadOnly = true;
            this.tbxMedidor.Size = new System.Drawing.Size(89, 21);
            this.tbxMedidor.TabIndex = 5;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Location = new System.Drawing.Point(3, 164);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(34, 20);
            this.lblMedidor.Text = "Med:";
            // 
            // dataGridListCadastral
            // 
            this.dataGridListCadastral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridListCadastral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridListCadastral.DataSource = this.bindingSourceCadastro;
            this.dataGridListCadastral.Location = new System.Drawing.Point(3, 24);
            this.dataGridListCadastral.Name = "dataGridListCadastral";
            this.dataGridListCadastral.Size = new System.Drawing.Size(234, 132);
            this.dataGridListCadastral.TabIndex = 4;
            this.dataGridListCadastral.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGridListCadastral.CurrentCellChanged += new System.EventHandler(this.dataGridListCadastral_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle1.MappingName = "CadastroAuxiliar";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Face";
            this.dataGridTextBoxColumn1.MappingName = "Face";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Seq";
            this.dataGridTextBoxColumn2.MappingName = "Sequencia";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 30;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Ender";
            this.dataGridTextBoxColumn3.MappingName = "NomeLogradouro";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 100;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Nº";
            this.dataGridTextBoxColumn4.MappingName = "NumeroImovel";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 30;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Comp";
            this.dataGridTextBoxColumn5.MappingName = "Complemento";
            this.dataGridTextBoxColumn5.NullText = "";
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Bairro";
            this.dataGridTextBoxColumn7.MappingName = "NomeBairro";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 100;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "S";
            this.dataGridTextBoxColumn6.MappingName = "StatusExecucao";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 15;
            // 
            // cbxSit
            // 
            this.cbxSit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSit.DisplayMember = "Description";
            this.cbxSit.Location = new System.Drawing.Point(153, 0);
            this.cbxSit.Name = "cbxSit";
            this.cbxSit.Size = new System.Drawing.Size(84, 22);
            this.cbxSit.TabIndex = 3;
            this.cbxSit.ValueMember = "Value";
            this.cbxSit.TextChanged += new System.EventHandler(this.cbxSit_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(131, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.Text = "Sit:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.Text = "Setor:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(70, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.Text = "Rota:";
            // 
            // tbxRota
            // 
            this.tbxRota.Location = new System.Drawing.Point(104, 0);
            this.tbxRota.Name = "tbxRota";
            this.tbxRota.ReadOnly = true;
            this.tbxRota.Size = new System.Drawing.Size(25, 21);
            this.tbxRota.TabIndex = 2;
            // 
            // tbxSetor
            // 
            this.tbxSetor.Location = new System.Drawing.Point(41, 0);
            this.tbxSetor.Name = "tbxSetor";
            this.tbxSetor.ReadOnly = true;
            this.tbxSetor.Size = new System.Drawing.Size(25, 21);
            this.tbxSetor.TabIndex = 1;
            // 
            // btnImpedimento
            // 
            this.btnImpedimento.Location = new System.Drawing.Point(173, 236);
            this.btnImpedimento.Name = "btnImpedimento";
            this.btnImpedimento.Size = new System.Drawing.Size(62, 20);
            this.btnImpedimento.TabIndex = 14;
            this.btnImpedimento.Text = "Liberar";
            this.btnImpedimento.Click += new System.EventHandler(this.btnImpedimento_Click);
            // 
            // frmPesquisaCadastral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPesquisaCadastral";
            this.Text = "Pesquisa Cadastral";
            this.Title = "Pesquisa Cadastral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPesquisaCadastral_Load);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbxMatricula;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox tbxMedidor;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.DataGrid dataGridListCadastral;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.ComboBox cbxSit;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.TextBox tbxRota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSetor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSourceCadastro;
        private System.Windows.Forms.Button btnImpedimento;

    }
}