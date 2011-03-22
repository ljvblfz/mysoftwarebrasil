namespace SPCadDesktop.Relatorios
{
    partial class frmRelIrregularidade
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
            this.gbxFuncionario = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rbSelecionar = new System.Windows.Forms.RadioButton();
            this.rbSubstituicao = new System.Windows.Forms.RadioButton();
            this.rbSancao = new System.Windows.Forms.RadioButton();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.gbxRota = new System.Windows.Forms.GroupBox();
            this.mtbxDataFim = new System.Windows.Forms.MaskedTextBox();
            this.mtbxDataIni = new System.Windows.Forms.MaskedTextBox();
            this.lblSetor = new System.Windows.Forms.Label();
            this.lblDistrito = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.tbxRota = new System.Windows.Forms.TextBox();
            this.lblRota = new System.Windows.Forms.Label();
            this.tbxSetor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbxFuncionario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbxRota.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxFuncionario
            // 
            this.gbxFuncionario.Controls.Add(this.pictureBox1);
            this.gbxFuncionario.Controls.Add(this.textBox1);
            this.gbxFuncionario.Controls.Add(this.rbSelecionar);
            this.gbxFuncionario.Controls.Add(this.rbSubstituicao);
            this.gbxFuncionario.Controls.Add(this.rbSancao);
            this.gbxFuncionario.Controls.Add(this.rbTodas);
            this.gbxFuncionario.Controls.Add(this.label3);
            this.gbxFuncionario.Location = new System.Drawing.Point(12, 169);
            this.gbxFuncionario.Name = "gbxFuncionario";
            this.gbxFuncionario.Size = new System.Drawing.Size(328, 132);
            this.gbxFuncionario.TabIndex = 15;
            this.gbxFuncionario.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SPCadDesktop.Properties.Resources.lupa21x21;
            this.pictureBox1.Location = new System.Drawing.Point(294, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(98, 106);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 5;
            // 
            // rbSelecionar
            // 
            this.rbSelecionar.AutoSize = true;
            this.rbSelecionar.ForeColor = System.Drawing.Color.Navy;
            this.rbSelecionar.Location = new System.Drawing.Point(17, 106);
            this.rbSelecionar.Name = "rbSelecionar";
            this.rbSelecionar.Size = new System.Drawing.Size(75, 17);
            this.rbSelecionar.TabIndex = 4;
            this.rbSelecionar.Text = "Selecionar";
            this.rbSelecionar.UseVisualStyleBackColor = true;
            // 
            // rbSubstituicao
            // 
            this.rbSubstituicao.AutoSize = true;
            this.rbSubstituicao.ForeColor = System.Drawing.Color.Navy;
            this.rbSubstituicao.Location = new System.Drawing.Point(17, 83);
            this.rbSubstituicao.Name = "rbSubstituicao";
            this.rbSubstituicao.Size = new System.Drawing.Size(152, 17);
            this.rbSubstituicao.TabIndex = 3;
            this.rbSubstituicao.Text = "Substituição de Hidrômetro";
            this.rbSubstituicao.UseVisualStyleBackColor = true;
            // 
            // rbSancao
            // 
            this.rbSancao.AutoSize = true;
            this.rbSancao.ForeColor = System.Drawing.Color.Navy;
            this.rbSancao.Location = new System.Drawing.Point(17, 60);
            this.rbSancao.Name = "rbSancao";
            this.rbSancao.Size = new System.Drawing.Size(119, 17);
            this.rbSancao.TabIndex = 2;
            this.rbSancao.Text = "Passível de sanção";
            this.rbSancao.UseVisualStyleBackColor = true;
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Checked = true;
            this.rbTodas.ForeColor = System.Drawing.Color.Navy;
            this.rbTodas.Location = new System.Drawing.Point(17, 37);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(55, 17);
            this.rbTodas.TabIndex = 1;
            this.rbTodas.TabStop = true;
            this.rbTodas.Text = "Todas";
            this.rbTodas.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Irregularidade:";
            // 
            // gbxRota
            // 
            this.gbxRota.Controls.Add(this.mtbxDataFim);
            this.gbxRota.Controls.Add(this.mtbxDataIni);
            this.gbxRota.Controls.Add(this.lblSetor);
            this.gbxRota.Controls.Add(this.lblDistrito);
            this.gbxRota.Location = new System.Drawing.Point(12, 2);
            this.gbxRota.Name = "gbxRota";
            this.gbxRota.Size = new System.Drawing.Size(328, 51);
            this.gbxRota.TabIndex = 14;
            this.gbxRota.TabStop = false;
            // 
            // mtbxDataFim
            // 
            this.mtbxDataFim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbxDataFim.Location = new System.Drawing.Point(227, 19);
            this.mtbxDataFim.Mask = "00/00/0000";
            this.mtbxDataFim.Name = "mtbxDataFim";
            this.mtbxDataFim.Size = new System.Drawing.Size(87, 20);
            this.mtbxDataFim.TabIndex = 11;
            // 
            // mtbxDataIni
            // 
            this.mtbxDataIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbxDataIni.Location = new System.Drawing.Point(75, 19);
            this.mtbxDataIni.Mask = "00/00/0000";
            this.mtbxDataIni.Name = "mtbxDataIni";
            this.mtbxDataIni.Size = new System.Drawing.Size(87, 20);
            this.mtbxDataIni.TabIndex = 9;
            this.mtbxDataIni.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbxDataIni_KeyUp);
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.ForeColor = System.Drawing.Color.Navy;
            this.lblSetor.Location = new System.Drawing.Point(166, 22);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(55, 13);
            this.lblSetor.TabIndex = 2;
            this.lblSetor.Text = "DataFinal:";
            // 
            // lblDistrito
            // 
            this.lblDistrito.AutoSize = true;
            this.lblDistrito.ForeColor = System.Drawing.Color.Navy;
            this.lblDistrito.Location = new System.Drawing.Point(6, 22);
            this.lblDistrito.Name = "lblDistrito";
            this.lblDistrito.Size = new System.Drawing.Size(63, 13);
            this.lblDistrito.TabIndex = 0;
            this.lblDistrito.Text = "Data Inicial:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDistrito);
            this.groupBox1.Controls.Add(this.tbxRota);
            this.groupBox1.Controls.Add(this.lblRota);
            this.groupBox1.Controls.Add(this.tbxSetor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 51);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DisplayMember = "Description";
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(49, 18);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(83, 21);
            this.cboDistrito.TabIndex = 6;
            this.cboDistrito.ValueMember = "Value";
            // 
            // tbxRota
            // 
            this.tbxRota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRota.Location = new System.Drawing.Point(263, 19);
            this.tbxRota.MaxLength = 4;
            this.tbxRota.Name = "tbxRota";
            this.tbxRota.Size = new System.Drawing.Size(51, 20);
            this.tbxRota.TabIndex = 5;
            // 
            // lblRota
            // 
            this.lblRota.AutoSize = true;
            this.lblRota.ForeColor = System.Drawing.Color.Navy;
            this.lblRota.Location = new System.Drawing.Point(227, 22);
            this.lblRota.Name = "lblRota";
            this.lblRota.Size = new System.Drawing.Size(33, 13);
            this.lblRota.TabIndex = 4;
            this.lblRota.Text = "Rota:";
            // 
            // tbxSetor
            // 
            this.tbxSetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSetor.Location = new System.Drawing.Point(172, 19);
            this.tbxSetor.MaxLength = 2;
            this.tbxSetor.Name = "tbxSetor";
            this.tbxSetor.Size = new System.Drawing.Size(51, 20);
            this.tbxSetor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(136, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Setor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Distrito:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboSituacao);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 47);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // cboSituacao
            // 
            this.cboSituacao.DisplayMember = "Description";
            this.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(113, 16);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(201, 21);
            this.cboSituacao.TabIndex = 1;
            this.cboSituacao.ValueMember = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Situacao:";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::SPCadDesktop.Properties.Resources.excel_16x16;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(105, 307);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExcel.Size = new System.Drawing.Size(87, 25);
            this.btnExcel.TabIndex = 23;
            this.btnExcel.Text = "     &Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(241, 307);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(99, 25);
            this.button1.TabIndex = 22;
            this.button1.Text = "&Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnImprimir
            // 
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::SPCadDesktop.Properties.Resources.print_16x16;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(12, 307);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnImprimir.Size = new System.Drawing.Size(87, 25);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "     &Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRelIrregularidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 342);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxFuncionario);
            this.Controls.Add(this.gbxRota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelIrregularidade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Irregularidade";
            this.gbxFuncionario.ResumeLayout(false);
            this.gbxFuncionario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbxRota.ResumeLayout(false);
            this.gbxRota.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFuncionario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbxRota;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.Label lblDistrito;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxRota;
        private System.Windows.Forms.Label lblRota;
        private System.Windows.Forms.TextBox tbxSetor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbxDataIni;
        private System.Windows.Forms.MaskedTextBox mtbxDataFim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.RadioButton rbSelecionar;
        private System.Windows.Forms.RadioButton rbSubstituicao;
        private System.Windows.Forms.RadioButton rbSancao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cboDistrito;
    }
}