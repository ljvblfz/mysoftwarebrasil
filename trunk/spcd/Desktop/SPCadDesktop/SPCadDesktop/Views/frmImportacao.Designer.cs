namespace SPCadDesktop.Views
{
    partial class frmImportacao
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
            this.btnImportar = new System.Windows.Forms.Button();
            this.gbxBairro = new System.Windows.Forms.GroupBox();
            this.btnBuscaDistribuicao = new System.Windows.Forms.Button();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.gbxBairro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Location = new System.Drawing.Point(294, 50);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnImportar.Size = new System.Drawing.Size(99, 21);
            this.btnImportar.TabIndex = 14;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnBuscaDistribuicao_Click);
            // 
            // gbxBairro
            // 
            this.gbxBairro.Controls.Add(this.btnBuscaDistribuicao);
            this.gbxBairro.Controls.Add(this.tbxPath);
            this.gbxBairro.Controls.Add(this.lblDescrição);
            this.gbxBairro.Location = new System.Drawing.Point(12, 2);
            this.gbxBairro.Name = "gbxBairro";
            this.gbxBairro.Size = new System.Drawing.Size(381, 42);
            this.gbxBairro.TabIndex = 15;
            this.gbxBairro.TabStop = false;
            // 
            // btnBuscaDistribuicao
            // 
            this.btnBuscaDistribuicao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaDistribuicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaDistribuicao.Location = new System.Drawing.Point(348, 14);
            this.btnBuscaDistribuicao.Name = "btnBuscaDistribuicao";
            this.btnBuscaDistribuicao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscaDistribuicao.Size = new System.Drawing.Size(27, 21);
            this.btnBuscaDistribuicao.TabIndex = 15;
            this.btnBuscaDistribuicao.Text = "...";
            this.btnBuscaDistribuicao.UseVisualStyleBackColor = true;
            this.btnBuscaDistribuicao.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxPath
            // 
            this.tbxPath.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPath.Location = new System.Drawing.Point(63, 14);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.ReadOnly = true;
            this.tbxPath.Size = new System.Drawing.Size(279, 20);
            this.tbxPath.TabIndex = 0;
            // 
            // lblDescrição
            // 
            this.lblDescrição.AutoSize = true;
            this.lblDescrição.ForeColor = System.Drawing.Color.Navy;
            this.lblDescrição.Location = new System.Drawing.Point(6, 16);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(51, 13);
            this.lblDescrição.TabIndex = 0;
            this.lblDescrição.Text = "Caminho:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 51);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 20);
            this.progressBar1.TabIndex = 16;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            // 
            // frmImportacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 79);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.gbxBairro);
            this.Controls.Add(this.btnImportar);
            this.Name = "frmImportacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImportacao";
            this.gbxBairro.ResumeLayout(false);
            this.gbxBairro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.GroupBox gbxBairro;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label lblDescrição;
        private System.Windows.Forms.Button btnBuscaDistribuicao;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgWorker;

    }
}