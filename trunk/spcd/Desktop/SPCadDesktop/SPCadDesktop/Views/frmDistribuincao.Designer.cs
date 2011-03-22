namespace SPCadDesktop.Views
{
    partial class frmDistribuincao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxFuncionario = new System.Windows.Forms.GroupBox();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbxRota = new System.Windows.Forms.GroupBox();
            this.tbxRota = new System.Windows.Forms.TextBox();
            this.lblRota = new System.Windows.Forms.Label();
            this.tbxSetor = new System.Windows.Forms.TextBox();
            this.lblSetor = new System.Windows.Forms.Label();
            this.tbxDistrito = new System.Windows.Forms.TextBox();
            this.lblDistrito = new System.Windows.Forms.Label();
            this.gbxSituacao = new System.Windows.Forms.GroupBox();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdRoteiros = new System.Windows.Forms.DataGridView();
            this.distritoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtPontoServicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtExecutadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDistribuidos = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gbxAtribuicao = new System.Windows.Forms.GroupBox();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAtribuir = new System.Windows.Forms.Button();
            this.cboFuncionarioAdd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdDistribuicao = new System.Windows.Forms.DataGridView();
            this.nomeFuncionarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacaoCargaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDistribuicao = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscaDistribuicao = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGerarArquivo = new System.Windows.Forms.Button();
            this.gbxFuncionario.SuspendLayout();
            this.gbxRota.SuspendLayout();
            this.gbxSituacao.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoteiros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDistribuidos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.gbxAtribuicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistribuicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDistribuicao)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFuncionario
            // 
            this.gbxFuncionario.Controls.Add(this.cboFuncionario);
            this.gbxFuncionario.Controls.Add(this.label3);
            this.gbxFuncionario.Location = new System.Drawing.Point(203, 2);
            this.gbxFuncionario.Name = "gbxFuncionario";
            this.gbxFuncionario.Size = new System.Drawing.Size(216, 62);
            this.gbxFuncionario.TabIndex = 3;
            this.gbxFuncionario.TabStop = false;
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.DisplayMember = "Description";
            this.cboFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Location = new System.Drawing.Point(9, 31);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(201, 21);
            this.cboFuncionario.TabIndex = 1;
            this.cboFuncionario.ValueMember = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Funcionário";
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
            this.gbxRota.Size = new System.Drawing.Size(185, 62);
            this.gbxRota.TabIndex = 2;
            this.gbxRota.TabStop = false;
            // 
            // tbxRota
            // 
            this.tbxRota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRota.Location = new System.Drawing.Point(123, 32);
            this.tbxRota.Name = "tbxRota";
            this.tbxRota.Size = new System.Drawing.Size(51, 20);
            this.tbxRota.TabIndex = 5;
            // 
            // lblRota
            // 
            this.lblRota.AutoSize = true;
            this.lblRota.ForeColor = System.Drawing.Color.Navy;
            this.lblRota.Location = new System.Drawing.Point(120, 16);
            this.lblRota.Name = "lblRota";
            this.lblRota.Size = new System.Drawing.Size(30, 13);
            this.lblRota.TabIndex = 4;
            this.lblRota.Text = "Rota";
            // 
            // tbxSetor
            // 
            this.tbxSetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSetor.Location = new System.Drawing.Point(66, 32);
            this.tbxSetor.Name = "tbxSetor";
            this.tbxSetor.Size = new System.Drawing.Size(51, 20);
            this.tbxSetor.TabIndex = 3;
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.ForeColor = System.Drawing.Color.Navy;
            this.lblSetor.Location = new System.Drawing.Point(63, 16);
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
            this.tbxDistrito.Size = new System.Drawing.Size(51, 20);
            this.tbxDistrito.TabIndex = 1;
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
            this.gbxSituacao.Controls.Add(this.label1);
            this.gbxSituacao.Location = new System.Drawing.Point(425, 2);
            this.gbxSituacao.Name = "gbxSituacao";
            this.gbxSituacao.Size = new System.Drawing.Size(163, 62);
            this.gbxSituacao.TabIndex = 4;
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
            this.cboSituacao.Size = new System.Drawing.Size(146, 21);
            this.cboSituacao.TabIndex = 1;
            this.cboSituacao.ValueMember = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Situação";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grdRoteiros);
            this.groupBox4.Location = new System.Drawing.Point(12, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(379, 425);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // grdRoteiros
            // 
            this.grdRoteiros.AllowUserToAddRows = false;
            this.grdRoteiros.AllowUserToDeleteRows = false;
            this.grdRoteiros.AutoGenerateColumns = false;
            this.grdRoteiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoteiros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.distritoDataGridViewTextBoxColumn,
            this.setorDataGridViewTextBoxColumn,
            this.rotaDataGridViewTextBoxColumn,
            this.qtPontoServicoDataGridViewTextBoxColumn,
            this.qtExecutadoDataGridViewTextBoxColumn});
            this.grdRoteiros.DataSource = this.bsDistribuidos;
            this.grdRoteiros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdRoteiros.Location = new System.Drawing.Point(6, 12);
            this.grdRoteiros.Name = "grdRoteiros";
            this.grdRoteiros.RowHeadersWidth = 25;
            this.grdRoteiros.Size = new System.Drawing.Size(366, 406);
            this.grdRoteiros.TabIndex = 8;
            // 
            // distritoDataGridViewTextBoxColumn
            // 
            this.distritoDataGridViewTextBoxColumn.DataPropertyName = "Distrito";
            this.distritoDataGridViewTextBoxColumn.HeaderText = "Distrito";
            this.distritoDataGridViewTextBoxColumn.Name = "distritoDataGridViewTextBoxColumn";
            this.distritoDataGridViewTextBoxColumn.Width = 50;
            // 
            // setorDataGridViewTextBoxColumn
            // 
            this.setorDataGridViewTextBoxColumn.DataPropertyName = "Setor";
            this.setorDataGridViewTextBoxColumn.HeaderText = "Setor";
            this.setorDataGridViewTextBoxColumn.Name = "setorDataGridViewTextBoxColumn";
            this.setorDataGridViewTextBoxColumn.Width = 50;
            // 
            // rotaDataGridViewTextBoxColumn
            // 
            this.rotaDataGridViewTextBoxColumn.DataPropertyName = "Rota";
            this.rotaDataGridViewTextBoxColumn.HeaderText = "Rota";
            this.rotaDataGridViewTextBoxColumn.Name = "rotaDataGridViewTextBoxColumn";
            this.rotaDataGridViewTextBoxColumn.Width = 60;
            // 
            // qtPontoServicoDataGridViewTextBoxColumn
            // 
            this.qtPontoServicoDataGridViewTextBoxColumn.DataPropertyName = "QtPontoServico";
            this.qtPontoServicoDataGridViewTextBoxColumn.HeaderText = "Qt. P.S.";
            this.qtPontoServicoDataGridViewTextBoxColumn.Name = "qtPontoServicoDataGridViewTextBoxColumn";
            this.qtPontoServicoDataGridViewTextBoxColumn.Width = 80;
            // 
            // qtExecutadoDataGridViewTextBoxColumn
            // 
            this.qtExecutadoDataGridViewTextBoxColumn.DataPropertyName = "QtExecutado";
            this.qtExecutadoDataGridViewTextBoxColumn.HeaderText = "Qt. Exec.";
            this.qtExecutadoDataGridViewTextBoxColumn.Name = "qtExecutadoDataGridViewTextBoxColumn";
            this.qtExecutadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // bsDistribuidos
            // 
            this.bsDistribuidos.DataSource = typeof(SPCadDesktopData.Data.Model.Distribuido);
            this.bsDistribuidos.PositionChanged += new System.EventHandler(this.bsDistribuidos_PositionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "ROTEIROS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(403, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "DISTRIBUIÇÕES";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gbxAtribuicao);
            this.groupBox5.Controls.Add(this.grdDistribuicao);
            this.groupBox5.Location = new System.Drawing.Point(397, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(296, 425);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            // 
            // gbxAtribuicao
            // 
            this.gbxAtribuicao.Controls.Add(this.btnGerarArquivo);
            this.gbxAtribuicao.Controls.Add(this.btnDesfazer);
            this.gbxAtribuicao.Controls.Add(this.btnLiberar);
            this.gbxAtribuicao.Controls.Add(this.btnFinalizar);
            this.gbxAtribuicao.Controls.Add(this.btnRemover);
            this.gbxAtribuicao.Controls.Add(this.btnAtribuir);
            this.gbxAtribuicao.Controls.Add(this.cboFuncionarioAdd);
            this.gbxAtribuicao.Controls.Add(this.label6);
            this.gbxAtribuicao.Location = new System.Drawing.Point(6, 269);
            this.gbxAtribuicao.Name = "gbxAtribuicao";
            this.gbxAtribuicao.Size = new System.Drawing.Size(284, 149);
            this.gbxAtribuicao.TabIndex = 12;
            this.gbxAtribuicao.TabStop = false;
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDesfazer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesfazer.Location = new System.Drawing.Point(149, 85);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDesfazer.Size = new System.Drawing.Size(129, 21);
            this.btnDesfazer.TabIndex = 15;
            this.btnDesfazer.Text = "&Desfazer Liberação";
            this.btnDesfazer.UseVisualStyleBackColor = true;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLiberar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberar.Location = new System.Drawing.Point(149, 58);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLiberar.Size = new System.Drawing.Size(129, 21);
            this.btnLiberar.TabIndex = 14;
            this.btnLiberar.Text = "&Liberar p/ Carga";
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(9, 85);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFinalizar.Size = new System.Drawing.Size(70, 21);
            this.btnFinalizar.TabIndex = 13;
            this.btnFinalizar.Text = "Fi&nalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemover.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(9, 58);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRemover.Size = new System.Drawing.Size(70, 21);
            this.btnRemover.TabIndex = 12;
            this.btnRemover.Text = "&Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAtribuir
            // 
            this.btnAtribuir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtribuir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtribuir.Location = new System.Drawing.Point(219, 30);
            this.btnAtribuir.Name = "btnAtribuir";
            this.btnAtribuir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAtribuir.Size = new System.Drawing.Size(59, 21);
            this.btnAtribuir.TabIndex = 11;
            this.btnAtribuir.Text = "&Atribuir";
            this.btnAtribuir.UseVisualStyleBackColor = true;
            this.btnAtribuir.Click += new System.EventHandler(this.btnAtribuir_Click);
            // 
            // cboFuncionarioAdd
            // 
            this.cboFuncionarioAdd.BackColor = System.Drawing.SystemColors.Window;
            this.cboFuncionarioAdd.DisplayMember = "Description";
            this.cboFuncionarioAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncionarioAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFuncionarioAdd.FormattingEnabled = true;
            this.cboFuncionarioAdd.Location = new System.Drawing.Point(9, 31);
            this.cboFuncionarioAdd.Name = "cboFuncionarioAdd";
            this.cboFuncionarioAdd.Size = new System.Drawing.Size(204, 21);
            this.cboFuncionarioAdd.TabIndex = 1;
            this.cboFuncionarioAdd.ValueMember = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Funcionário";
            // 
            // grdDistribuicao
            // 
            this.grdDistribuicao.AllowUserToAddRows = false;
            this.grdDistribuicao.AllowUserToDeleteRows = false;
            this.grdDistribuicao.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDistribuicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDistribuicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDistribuicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeFuncionarioDataGridViewTextBoxColumn,
            this.situacaoCargaDataGridViewTextBoxColumn});
            this.grdDistribuicao.DataSource = this.bsDistribuicao;
            this.grdDistribuicao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdDistribuicao.Location = new System.Drawing.Point(6, 12);
            this.grdDistribuicao.Name = "grdDistribuicao";
            this.grdDistribuicao.RowHeadersVisible = false;
            this.grdDistribuicao.RowHeadersWidth = 25;
            this.grdDistribuicao.Size = new System.Drawing.Size(284, 251);
            this.grdDistribuicao.TabIndex = 8;
            // 
            // nomeFuncionarioDataGridViewTextBoxColumn
            // 
            this.nomeFuncionarioDataGridViewTextBoxColumn.DataPropertyName = "NomeFuncionario";
            this.nomeFuncionarioDataGridViewTextBoxColumn.HeaderText = "Nome Funcionário";
            this.nomeFuncionarioDataGridViewTextBoxColumn.Name = "nomeFuncionarioDataGridViewTextBoxColumn";
            this.nomeFuncionarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeFuncionarioDataGridViewTextBoxColumn.Width = 165;
            // 
            // situacaoCargaDataGridViewTextBoxColumn
            // 
            this.situacaoCargaDataGridViewTextBoxColumn.DataPropertyName = "SituacaoCargaString";
            this.situacaoCargaDataGridViewTextBoxColumn.HeaderText = "Situacao";
            this.situacaoCargaDataGridViewTextBoxColumn.Name = "situacaoCargaDataGridViewTextBoxColumn";
            this.situacaoCargaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsDistribuicao
            // 
            this.bsDistribuicao.DataSource = typeof(SPCadDesktopData.Data.Model.Distribuicao);
            this.bsDistribuicao.CurrentChanged += new System.EventHandler(this.bsDistribuicao_PositionChanged);
            this.bsDistribuicao.PositionChanged += new System.EventHandler(this.bsDistribuicao_PositionChanged);
            // 
            // btnBuscaDistribuicao
            // 
            this.btnBuscaDistribuicao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaDistribuicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaDistribuicao.Location = new System.Drawing.Point(594, 10);
            this.btnBuscaDistribuicao.Name = "btnBuscaDistribuicao";
            this.btnBuscaDistribuicao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscaDistribuicao.Size = new System.Drawing.Size(99, 21);
            this.btnBuscaDistribuicao.TabIndex = 13;
            this.btnBuscaDistribuicao.Text = "&Buscar";
            this.btnBuscaDistribuicao.UseVisualStyleBackColor = true;
            this.btnBuscaDistribuicao.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(611, 511);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(70, 21);
            this.button1.TabIndex = 15;
            this.button1.Text = "&Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGerarArquivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarArquivo.Location = new System.Drawing.Point(173, 112);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGerarArquivo.Size = new System.Drawing.Size(105, 23);
            this.btnGerarArquivo.TabIndex = 16;
            this.btnGerarArquivo.Text = "Gerar Arquivo";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            this.btnGerarArquivo.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmDistribuincao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBuscaDistribuicao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbxSituacao);
            this.Controls.Add(this.gbxFuncionario);
            this.Controls.Add(this.gbxRota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDistribuincao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDistribuincao";
            this.gbxFuncionario.ResumeLayout(false);
            this.gbxFuncionario.PerformLayout();
            this.gbxRota.ResumeLayout(false);
            this.gbxRota.PerformLayout();
            this.gbxSituacao.ResumeLayout(false);
            this.gbxSituacao.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRoteiros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDistribuidos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.gbxAtribuicao.ResumeLayout(false);
            this.gbxAtribuicao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistribuicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDistribuicao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFuncionario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbxRota;
        private System.Windows.Forms.TextBox tbxRota;
        private System.Windows.Forms.Label lblRota;
        private System.Windows.Forms.TextBox tbxSetor;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.TextBox tbxDistrito;
        private System.Windows.Forms.Label lblDistrito;
        private System.Windows.Forms.GroupBox gbxSituacao;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView grdRoteiros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView grdDistribuicao;
        private System.Windows.Forms.GroupBox gbxAtribuicao;
        private System.Windows.Forms.Button btnAtribuir;
        private System.Windows.Forms.ComboBox cboFuncionarioAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDesfazer;
        private System.Windows.Forms.Button btnLiberar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnBuscaDistribuicao;
        private System.Windows.Forms.BindingSource bsDistribuidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn distritoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtPontoServicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtExecutadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsDistribuicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeFuncionarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacaoCargaDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cboFuncionario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGerarArquivo;
    }
}