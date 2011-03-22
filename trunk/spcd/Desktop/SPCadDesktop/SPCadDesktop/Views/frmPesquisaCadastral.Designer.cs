namespace SPCadDesktop.Views
{
    partial class frmPesquisaCadastral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.gbxRota = new System.Windows.Forms.GroupBox();
            this.tbxRota = new System.Windows.Forms.TextBox();
            this.lblRota = new System.Windows.Forms.Label();
            this.tbxSetor = new System.Windows.Forms.TextBox();
            this.lblSetor = new System.Windows.Forms.Label();
            this.tbxDistrito = new System.Windows.Forms.TextBox();
            this.lblDistrito = new System.Windows.Forms.Label();
            this.gbxSituacao = new System.Windows.Forms.GroupBox();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbxMatricula = new System.Windows.Forms.GroupBox();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.tbxMatricula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxDistrito = new System.Windows.Forms.GroupBox();
            this.cboCadastrador = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxLogradouro = new System.Windows.Forms.GroupBox();
            this.lbxDropLogradouro = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lbxLogradouro = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxLogradouro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxBairro = new System.Windows.Forms.GroupBox();
            this.tbxBairro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigoDistritoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoRotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matriculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroPontoServicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeBairroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusExecucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCadastro = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboConsultas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnBuscarGeral = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.sfdExportToxcel = new System.Windows.Forms.SaveFileDialog();
            this.gbxRota.SuspendLayout();
            this.gbxSituacao.SuspendLayout();
            this.gbxMatricula.SuspendLayout();
            this.gbxDistrito.SuspendLayout();
            this.gbxLogradouro.SuspendLayout();
            this.gbxBairro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadastro)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxRota
            // 
            this.gbxRota.Controls.Add(this.tbxRota);
            this.gbxRota.Controls.Add(this.lblRota);
            this.gbxRota.Controls.Add(this.tbxSetor);
            this.gbxRota.Controls.Add(this.lblSetor);
            this.gbxRota.Controls.Add(this.tbxDistrito);
            this.gbxRota.Controls.Add(this.lblDistrito);
            this.gbxRota.Location = new System.Drawing.Point(12, 2);
            this.gbxRota.Name = "gbxRota";
            this.gbxRota.Size = new System.Drawing.Size(186, 62);
            this.gbxRota.TabIndex = 0;
            this.gbxRota.TabStop = false;
            // 
            // tbxRota
            // 
            this.tbxRota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRota.Location = new System.Drawing.Point(95, 32);
            this.tbxRota.Name = "tbxRota";
            this.tbxRota.Size = new System.Drawing.Size(51, 20);
            this.tbxRota.TabIndex = 3;
            this.tbxRota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxMatricula_KeyPress);
            // 
            // lblRota
            // 
            this.lblRota.AutoSize = true;
            this.lblRota.ForeColor = System.Drawing.Color.Navy;
            this.lblRota.Location = new System.Drawing.Point(92, 16);
            this.lblRota.Name = "lblRota";
            this.lblRota.Size = new System.Drawing.Size(30, 13);
            this.lblRota.TabIndex = 4;
            this.lblRota.Text = "Rota";
            // 
            // tbxSetor
            // 
            this.tbxSetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSetor.Location = new System.Drawing.Point(52, 32);
            this.tbxSetor.Name = "tbxSetor";
            this.tbxSetor.Size = new System.Drawing.Size(37, 20);
            this.tbxSetor.TabIndex = 2;
            this.tbxSetor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxMatricula_KeyPress);
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.ForeColor = System.Drawing.Color.Navy;
            this.lblSetor.Location = new System.Drawing.Point(49, 16);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(32, 13);
            this.lblSetor.TabIndex = 2;
            this.lblSetor.Text = "Setor";
            // 
            // tbxDistrito
            // 
            this.tbxDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDistrito.Location = new System.Drawing.Point(9, 32);
            this.tbxDistrito.Name = "tbxDistrito";
            this.tbxDistrito.Size = new System.Drawing.Size(37, 20);
            this.tbxDistrito.TabIndex = 1;
            this.tbxDistrito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxMatricula_KeyPress);
            // 
            // lblDistrito
            // 
            this.lblDistrito.AutoSize = true;
            this.lblDistrito.ForeColor = System.Drawing.Color.Navy;
            this.lblDistrito.Location = new System.Drawing.Point(6, 16);
            this.lblDistrito.Name = "lblDistrito";
            this.lblDistrito.Size = new System.Drawing.Size(39, 13);
            this.lblDistrito.TabIndex = 0;
            this.lblDistrito.Text = "Distrito";
            // 
            // gbxSituacao
            // 
            this.gbxSituacao.Controls.Add(this.cboSituacao);
            this.gbxSituacao.Controls.Add(this.label3);
            this.gbxSituacao.Location = new System.Drawing.Point(202, 2);
            this.gbxSituacao.Name = "gbxSituacao";
            this.gbxSituacao.Size = new System.Drawing.Size(188, 62);
            this.gbxSituacao.TabIndex = 1;
            this.gbxSituacao.TabStop = false;
            // 
            // cboSituacao
            // 
            this.cboSituacao.BackColor = System.Drawing.SystemColors.Window;
            this.cboSituacao.DisplayMember = "Description";
            this.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(9, 31);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(170, 21);
            this.cboSituacao.TabIndex = 5;
            this.cboSituacao.ValueMember = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Situação";
            // 
            // gbxMatricula
            // 
            this.gbxMatricula.Controls.Add(this.btnBuscarMatricula);
            this.gbxMatricula.Controls.Add(this.tbxMatricula);
            this.gbxMatricula.Controls.Add(this.label4);
            this.gbxMatricula.Location = new System.Drawing.Point(12, 64);
            this.gbxMatricula.Name = "gbxMatricula";
            this.gbxMatricula.Size = new System.Drawing.Size(186, 62);
            this.gbxMatricula.TabIndex = 2;
            this.gbxMatricula.TabStop = false;
            // 
            // btnBuscarMatricula
            // 
            this.btnBuscarMatricula.Enabled = false;
            this.btnBuscarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarMatricula.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarMatricula.Location = new System.Drawing.Point(123, 31);
            this.btnBuscarMatricula.Name = "btnBuscarMatricula";
            this.btnBuscarMatricula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscarMatricula.Size = new System.Drawing.Size(55, 21);
            this.btnBuscarMatricula.TabIndex = 15;
            this.btnBuscarMatricula.Text = "&Buscar";
            this.btnBuscarMatricula.UseVisualStyleBackColor = true;
            this.btnBuscarMatricula.Click += new System.EventHandler(this.btnBuscarMatricula_Click_1);
            // 
            // tbxMatricula
            // 
            this.tbxMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxMatricula.Location = new System.Drawing.Point(9, 32);
            this.tbxMatricula.MaxLength = 11;
            this.tbxMatricula.Name = "tbxMatricula";
            this.tbxMatricula.Size = new System.Drawing.Size(108, 20);
            this.tbxMatricula.TabIndex = 4;
            this.tbxMatricula.TextChanged += new System.EventHandler(this.tbxMatricula_TextChanged);
            this.tbxMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxMatricula_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Matricula";
            // 
            // gbxDistrito
            // 
            this.gbxDistrito.Controls.Add(this.cboCadastrador);
            this.gbxDistrito.Controls.Add(this.label1);
            this.gbxDistrito.Location = new System.Drawing.Point(202, 64);
            this.gbxDistrito.Name = "gbxDistrito";
            this.gbxDistrito.Size = new System.Drawing.Size(188, 62);
            this.gbxDistrito.TabIndex = 3;
            this.gbxDistrito.TabStop = false;
            // 
            // cboCadastrador
            // 
            this.cboCadastrador.BackColor = System.Drawing.SystemColors.Window;
            this.cboCadastrador.DisplayMember = "Description";
            this.cboCadastrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCadastrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCadastrador.FormattingEnabled = true;
            this.cboCadastrador.Location = new System.Drawing.Point(9, 31);
            this.cboCadastrador.Name = "cboCadastrador";
            this.cboCadastrador.Size = new System.Drawing.Size(170, 21);
            this.cboCadastrador.TabIndex = 6;
            this.cboCadastrador.ValueMember = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastrador";
            // 
            // gbxLogradouro
            // 
            this.gbxLogradouro.Controls.Add(this.lbxDropLogradouro);
            this.gbxLogradouro.Controls.Add(this.button3);
            this.gbxLogradouro.Controls.Add(this.lbxLogradouro);
            this.gbxLogradouro.Controls.Add(this.button2);
            this.gbxLogradouro.Controls.Add(this.button1);
            this.gbxLogradouro.Controls.Add(this.tbxLogradouro);
            this.gbxLogradouro.Controls.Add(this.label2);
            this.gbxLogradouro.Location = new System.Drawing.Point(394, 2);
            this.gbxLogradouro.Name = "gbxLogradouro";
            this.gbxLogradouro.Size = new System.Drawing.Size(374, 85);
            this.gbxLogradouro.TabIndex = 4;
            this.gbxLogradouro.TabStop = false;
            // 
            // lbxDropLogradouro
            // 
            this.lbxDropLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxDropLogradouro.FormattingEnabled = true;
            this.lbxDropLogradouro.IntegralHeight = false;
            this.lbxDropLogradouro.Location = new System.Drawing.Point(73, 33);
            this.lbxDropLogradouro.Name = "lbxDropLogradouro";
            this.lbxDropLogradouro.ScrollAlwaysVisible = true;
            this.lbxDropLogradouro.Size = new System.Drawing.Size(208, 47);
            this.lbxDropLogradouro.TabIndex = 8;
            this.lbxDropLogradouro.TabStop = false;
            this.lbxDropLogradouro.UseTabStops = false;
            this.lbxDropLogradouro.Visible = false;
            this.lbxDropLogradouro.Leave += new System.EventHandler(this.tbxLogradouro_Leave);
            this.lbxDropLogradouro.Click += new System.EventHandler(this.lbxDropLogradouro_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::SPCadDesktop.Properties.Resources.Limpar;
            this.button3.Location = new System.Drawing.Point(340, 14);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(24, 21);
            this.button3.TabIndex = 11;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbxLogradouro
            // 
            this.lbxLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxLogradouro.FormattingEnabled = true;
            this.lbxLogradouro.Location = new System.Drawing.Point(73, 38);
            this.lbxLogradouro.Name = "lbxLogradouro";
            this.lbxLogradouro.ScrollAlwaysVisible = true;
            this.lbxLogradouro.Size = new System.Drawing.Size(292, 41);
            this.lbxLogradouro.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::SPCadDesktop.Properties.Resources.Remover;
            this.button2.Location = new System.Drawing.Point(313, 14);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(24, 21);
            this.button2.TabIndex = 10;
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::SPCadDesktop.Properties.Resources.Adicionar;
            this.button1.Location = new System.Drawing.Point(286, 14);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(24, 21);
            this.button1.TabIndex = 9;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxLogradouro
            // 
            this.tbxLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxLogradouro.Location = new System.Drawing.Point(73, 14);
            this.tbxLogradouro.Name = "tbxLogradouro";
            this.tbxLogradouro.Size = new System.Drawing.Size(208, 20);
            this.tbxLogradouro.TabIndex = 7;
            this.tbxLogradouro.TextChanged += new System.EventHandler(this.tbxLogradouro_TextChanged);
            this.tbxLogradouro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxLogradouro_KeyDown);
            this.tbxLogradouro.Leave += new System.EventHandler(this.tbxLogradouro_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Logradouro";
            // 
            // gbxBairro
            // 
            this.gbxBairro.Controls.Add(this.tbxBairro);
            this.gbxBairro.Controls.Add(this.label5);
            this.gbxBairro.Location = new System.Drawing.Point(394, 87);
            this.gbxBairro.Name = "gbxBairro";
            this.gbxBairro.Size = new System.Drawing.Size(374, 39);
            this.gbxBairro.TabIndex = 5;
            this.gbxBairro.TabStop = false;
            // 
            // tbxBairro
            // 
            this.tbxBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxBairro.Location = new System.Drawing.Point(73, 14);
            this.tbxBairro.Name = "tbxBairro";
            this.tbxBairro.Size = new System.Drawing.Size(292, 20);
            this.tbxBairro.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bairro";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDistritoDataGridViewTextBoxColumn,
            this.setorDataGridViewTextBoxColumn,
            this.codigoRotaDataGridViewTextBoxColumn,
            this.matriculaDataGridViewTextBoxColumn,
            this.numeroPontoServicoDataGridViewTextBoxColumn,
            this.nomeClienteDataGridViewTextBoxColumn,
            this.Endereco,
            this.nomeBairroDataGridViewTextBoxColumn,
            this.Nome,
            this.StatusExecucao});
            this.dataGridView1.DataSource = this.bsCadastro;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.Size = new System.Drawing.Size(889, 378);
            this.dataGridView1.TabIndex = 6;
            // 
            // codigoDistritoDataGridViewTextBoxColumn
            // 
            this.codigoDistritoDataGridViewTextBoxColumn.DataPropertyName = "CodigoDistrito";
            this.codigoDistritoDataGridViewTextBoxColumn.HeaderText = "Distrito";
            this.codigoDistritoDataGridViewTextBoxColumn.Name = "codigoDistritoDataGridViewTextBoxColumn";
            this.codigoDistritoDataGridViewTextBoxColumn.Width = 50;
            // 
            // setorDataGridViewTextBoxColumn
            // 
            this.setorDataGridViewTextBoxColumn.DataPropertyName = "Setor";
            this.setorDataGridViewTextBoxColumn.HeaderText = "Setor";
            this.setorDataGridViewTextBoxColumn.Name = "setorDataGridViewTextBoxColumn";
            this.setorDataGridViewTextBoxColumn.Width = 50;
            // 
            // codigoRotaDataGridViewTextBoxColumn
            // 
            this.codigoRotaDataGridViewTextBoxColumn.DataPropertyName = "CodigoRota";
            this.codigoRotaDataGridViewTextBoxColumn.HeaderText = "Rota";
            this.codigoRotaDataGridViewTextBoxColumn.Name = "codigoRotaDataGridViewTextBoxColumn";
            this.codigoRotaDataGridViewTextBoxColumn.Width = 60;
            // 
            // matriculaDataGridViewTextBoxColumn
            // 
            this.matriculaDataGridViewTextBoxColumn.DataPropertyName = "Matricula";
            this.matriculaDataGridViewTextBoxColumn.HeaderText = "Matrícula";
            this.matriculaDataGridViewTextBoxColumn.Name = "matriculaDataGridViewTextBoxColumn";
            this.matriculaDataGridViewTextBoxColumn.Width = 90;
            // 
            // numeroPontoServicoDataGridViewTextBoxColumn
            // 
            this.numeroPontoServicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroPontoServico";
            this.numeroPontoServicoDataGridViewTextBoxColumn.HeaderText = "Pto. Servico";
            this.numeroPontoServicoDataGridViewTextBoxColumn.Name = "numeroPontoServicoDataGridViewTextBoxColumn";
            this.numeroPontoServicoDataGridViewTextBoxColumn.Width = 90;
            // 
            // nomeClienteDataGridViewTextBoxColumn
            // 
            this.nomeClienteDataGridViewTextBoxColumn.DataPropertyName = "NomeCliente";
            this.nomeClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nomeClienteDataGridViewTextBoxColumn.Name = "nomeClienteDataGridViewTextBoxColumn";
            this.nomeClienteDataGridViewTextBoxColumn.Visible = false;
            this.nomeClienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // Endereco
            // 
            this.Endereco.DataPropertyName = "Endereco";
            this.Endereco.HeaderText = "Endereço";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            this.Endereco.Width = 200;
            // 
            // nomeBairroDataGridViewTextBoxColumn
            // 
            this.nomeBairroDataGridViewTextBoxColumn.DataPropertyName = "NomeBairro";
            this.nomeBairroDataGridViewTextBoxColumn.HeaderText = "Bairro";
            this.nomeBairroDataGridViewTextBoxColumn.Name = "nomeBairroDataGridViewTextBoxColumn";
            this.nomeBairroDataGridViewTextBoxColumn.Width = 140;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Cadastrador";
            this.Nome.Name = "Nome";
            // 
            // StatusExecucao
            // 
            this.StatusExecucao.DataPropertyName = "DescricaoSituacao";
            this.StatusExecucao.HeaderText = "Situação";
            this.StatusExecucao.Name = "StatusExecucao";
            this.StatusExecucao.ReadOnly = true;
            this.StatusExecucao.Width = 70;
            // 
            // bsCadastro
            // 
            this.bsCadastro.DataSource = typeof(SPCadDesktopData.Data.Model.Cadastro);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pictureBox1);
            this.groupBox7.Controls.Add(this.cboConsultas);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(12, 510);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(406, 39);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SPCadDesktop.Properties.Resources.play2;
            this.pictureBox1.Location = new System.Drawing.Point(376, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cboConsultas
            // 
            this.cboConsultas.BackColor = System.Drawing.SystemColors.Window;
            this.cboConsultas.DisplayMember = "Description";
            this.cboConsultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboConsultas.FormattingEnabled = true;
            this.cboConsultas.Location = new System.Drawing.Point(68, 13);
            this.cboConsultas.Name = "cboConsultas";
            this.cboConsultas.Size = new System.Drawing.Size(302, 21);
            this.cboConsultas.TabIndex = 2;
            this.cboConsultas.ValueMember = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Consultas:";
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalhes.Image = global::SPCadDesktop.Properties.Resources.book_open_16x16;
            this.btnDetalhes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalhes.Location = new System.Drawing.Point(526, 523);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(86, 23);
            this.btnDetalhes.TabIndex = 8;
            this.btnDetalhes.Text = "     &Detalhes";
            this.btnDetalhes.UseVisualStyleBackColor = true;
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Location = new System.Drawing.Point(826, 523);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnBuscarGeral
            // 
            this.btnBuscarGeral.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarGeral.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarGeral.Location = new System.Drawing.Point(774, 8);
            this.btnBuscarGeral.Name = "btnBuscarGeral";
            this.btnBuscarGeral.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscarGeral.Size = new System.Drawing.Size(127, 21);
            this.btnBuscarGeral.TabIndex = 14;
            this.btnBuscarGeral.Text = "&Buscar";
            this.btnBuscarGeral.UseVisualStyleBackColor = true;
            this.btnBuscarGeral.Click += new System.EventHandler(this.btnBuscarGeral_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Image = global::SPCadDesktop.Properties.Resources.excel_16x16;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(710, 523);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(86, 23);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "      &Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Image = global::SPCadDesktop.Properties.Resources.print_16x16;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(618, 523);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(86, 23);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "      &Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmPesquisaCadastral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 558);
            this.Controls.Add(this.btnBuscarGeral);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnDetalhes);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbxBairro);
            this.Controls.Add(this.gbxLogradouro);
            this.Controls.Add(this.gbxDistrito);
            this.Controls.Add(this.gbxMatricula);
            this.Controls.Add(this.gbxSituacao);
            this.Controls.Add(this.gbxRota);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaCadastral";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPesquisaCadastral";
            this.gbxRota.ResumeLayout(false);
            this.gbxRota.PerformLayout();
            this.gbxSituacao.ResumeLayout(false);
            this.gbxSituacao.PerformLayout();
            this.gbxMatricula.ResumeLayout(false);
            this.gbxMatricula.PerformLayout();
            this.gbxDistrito.ResumeLayout(false);
            this.gbxDistrito.PerformLayout();
            this.gbxLogradouro.ResumeLayout(false);
            this.gbxLogradouro.PerformLayout();
            this.gbxBairro.ResumeLayout(false);
            this.gbxBairro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadastro)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxRota;
        private System.Windows.Forms.TextBox tbxSetor;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.TextBox tbxDistrito;
        private System.Windows.Forms.Label lblDistrito;
        private System.Windows.Forms.TextBox tbxRota;
        private System.Windows.Forms.Label lblRota;
        private System.Windows.Forms.GroupBox gbxSituacao;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbxMatricula;
        private System.Windows.Forms.TextBox tbxMatricula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbxDistrito;
        private System.Windows.Forms.ComboBox cboCadastrador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxLogradouro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxLogradouro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbxBairro;
        private System.Windows.Forms.TextBox tbxBairro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cboConsultas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnBuscarMatricula;
        private System.Windows.Forms.ListBox lbxLogradouro;
        private System.Windows.Forms.Button btnBuscarGeral;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource bsCadastro;
        private System.Windows.Forms.ListBox lbxDropLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDistritoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoRotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroPontoServicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeBairroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusExecucao;
        private System.Windows.Forms.SaveFileDialog sfdExportToxcel;



    }
}