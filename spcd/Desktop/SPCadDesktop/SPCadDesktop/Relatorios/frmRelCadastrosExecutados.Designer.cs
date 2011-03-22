﻿namespace SPCadDesktop.Relatorios
{
    partial class frmRelCadastrosExecutados
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbxFuncionario = new System.Windows.Forms.GroupBox();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.gbxFuncionario.SuspendLayout();
            this.gbxRota.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::SPCadDesktop.Properties.Resources.print_16x16;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(12, 222);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnImprimir.Size = new System.Drawing.Size(87, 25);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "     &Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbxFuncionario
            // 
            this.gbxFuncionario.Controls.Add(this.cboFuncionario);
            this.gbxFuncionario.Controls.Add(this.label3);
            this.gbxFuncionario.Location = new System.Drawing.Point(12, 169);
            this.gbxFuncionario.Name = "gbxFuncionario";
            this.gbxFuncionario.Size = new System.Drawing.Size(328, 47);
            this.gbxFuncionario.TabIndex = 15;
            this.gbxFuncionario.TabStop = false;
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.DisplayMember = "Description";
            this.cboFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Location = new System.Drawing.Point(113, 16);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(201, 21);
            this.cboFuncionario.TabIndex = 1;
            this.cboFuncionario.ValueMember = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cadastrador:";
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
            this.cboDistrito.Location = new System.Drawing.Point(49, 19);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(83, 21);
            this.cboDistrito.TabIndex = 7;
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
            this.tbxSetor.Location = new System.Drawing.Point(173, 19);
            this.tbxSetor.MaxLength = 2;
            this.tbxSetor.Name = "tbxSetor";
            this.tbxSetor.Size = new System.Drawing.Size(51, 20);
            this.tbxSetor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(137, 22);
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
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(241, 222);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(99, 25);
            this.button1.TabIndex = 18;
            this.button1.Text = "&Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.btnExcel.Location = new System.Drawing.Point(105, 222);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExcel.Size = new System.Drawing.Size(87, 25);
            this.btnExcel.TabIndex = 20;
            this.btnExcel.Text = "     &Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRelCadastrosExecutados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 257);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.gbxFuncionario);
            this.Controls.Add(this.gbxRota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelCadastrosExecutados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Cadastros Executados";
            this.gbxFuncionario.ResumeLayout(false);
            this.gbxFuncionario.PerformLayout();
            this.gbxRota.ResumeLayout(false);
            this.gbxRota.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox gbxFuncionario;
        private System.Windows.Forms.ComboBox cboFuncionario;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox mtbxDataIni;
        private System.Windows.Forms.MaskedTextBox mtbxDataFim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cboDistrito;
    }
}