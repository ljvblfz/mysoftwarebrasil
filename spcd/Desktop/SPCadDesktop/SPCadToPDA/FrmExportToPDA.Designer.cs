namespace SPCadToPDA
{
    partial class FrmExportToPDA
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxEnderecoBase = new System.Windows.Forms.TextBox();
            this.btnGetEndereco = new System.Windows.Forms.Button();
            this.bwProcessExport = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGerarArq = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblDescPesquisador = new System.Windows.Forms.Label();
            this.lblPesquisador = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caminho:";
            // 
            // tbxEnderecoBase
            // 
            this.tbxEnderecoBase.BackColor = System.Drawing.SystemColors.Window;
            this.tbxEnderecoBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxEnderecoBase.Location = new System.Drawing.Point(66, 46);
            this.tbxEnderecoBase.Name = "tbxEnderecoBase";
            this.tbxEnderecoBase.Size = new System.Drawing.Size(593, 20);
            this.tbxEnderecoBase.TabIndex = 1;
            // 
            // btnGetEndereco
            // 
            this.btnGetEndereco.Location = new System.Drawing.Point(664, 44);
            this.btnGetEndereco.Name = "btnGetEndereco";
            this.btnGetEndereco.Size = new System.Drawing.Size(31, 22);
            this.btnGetEndereco.TabIndex = 2;
            this.btnGetEndereco.Text = "...";
            this.btnGetEndereco.UseVisualStyleBackColor = true;
            this.btnGetEndereco.Click += new System.EventHandler(this.btnGetEndereco_Click);
            // 
            // bwProcessExport
            // 
            this.bwProcessExport.WorkerReportsProgress = true;
            this.bwProcessExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProcessExport_DoWork);
            this.bwProcessExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProcessExport_RunWorkerCompleted);
            this.bwProcessExport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProcessExport_ProgressChanged);
            // 
            // btnGerarArq
            // 
            this.btnGerarArq.Location = new System.Drawing.Point(647, 107);
            this.btnGerarArq.Name = "btnGerarArq";
            this.btnGerarArq.Size = new System.Drawing.Size(96, 24);
            this.btnGerarArq.TabIndex = 3;
            this.btnGerarArq.Text = "Gerar Arquivo";
            this.btnGerarArq.UseVisualStyleBackColor = true;
            this.btnGerarArq.Click += new System.EventHandler(this.btnGerarArq_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 107);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(624, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // lblDescPesquisador
            // 
            this.lblDescPesquisador.AutoSize = true;
            this.lblDescPesquisador.Location = new System.Drawing.Point(12, 9);
            this.lblDescPesquisador.Name = "lblDescPesquisador";
            this.lblDescPesquisador.Size = new System.Drawing.Size(49, 13);
            this.lblDescPesquisador.TabIndex = 8;
            this.lblDescPesquisador.Text = "Usuário: ";
            // 
            // lblPesquisador
            // 
            this.lblPesquisador.AutoSize = true;
            this.lblPesquisador.Location = new System.Drawing.Point(63, 9);
            this.lblPesquisador.Name = "lblPesquisador";
            this.lblPesquisador.Size = new System.Drawing.Size(0, 13);
            this.lblPesquisador.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 86);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(73, 86);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(41, 13);
            this.lblDescricao.TabIndex = 11;
            this.lblDescricao.Text = "Parado";
            // 
            // FrmExportToPDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 141);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPesquisador);
            this.Controls.Add(this.lblDescPesquisador);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGerarArq);
            this.Controls.Add(this.btnGetEndereco);
            this.Controls.Add(this.tbxEnderecoBase);
            this.Controls.Add(this.label1);
            this.Name = "FrmExportToPDA";
            this.Text = "Exportar base para PDA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxEnderecoBase;
        private System.Windows.Forms.Button btnGetEndereco;
        private System.ComponentModel.BackgroundWorker bwProcessExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnGerarArq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblDescPesquisador;
        private System.Windows.Forms.Label lblPesquisador;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDescricao;
    }
}