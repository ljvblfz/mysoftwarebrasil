namespace OnPlaceMovel.Source.Forms {
    partial class FormNavegacaoCadastroCliente {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lblNHD = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lblLogradouro = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lblSeqCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrimeiro = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNHD
            // 
            this.lblNHD.Location = new System.Drawing.Point(52, 81);
            this.lblNHD.Name = "lblNHD";
            this.lblNHD.Size = new System.Drawing.Size(177, 16);
            this.lblNHD.Text = "Numero do HD";
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label.Location = new System.Drawing.Point(11, 81);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(52, 16);
            this.label.Text = "Nº HD:";
            // 
            // lblLogradouro
            // 
            this.lblLogradouro.Location = new System.Drawing.Point(11, 102);
            this.lblLogradouro.Name = "lblLogradouro";
            this.lblLogradouro.Size = new System.Drawing.Size(218, 55);
            this.lblLogradouro.Text = "Logradouro";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Location = new System.Drawing.Point(159, 163);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(70, 24);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "Sair";
            // 
            // lblNome
            // 
            this.lblNome.Location = new System.Drawing.Point(52, 62);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(177, 16);
            this.lblNome.Text = "Nome do cliente";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.Text = "Nome:";
            // 
            // btnProximo
            // 
            this.btnProximo.Location = new System.Drawing.Point(143, 3);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(40, 24);
            this.btnProximo.TabIndex = 25;
            this.btnProximo.Text = " >>";
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(85, 163);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(68, 24);
            this.btnAlterar.TabIndex = 23;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(56, 3);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(40, 24);
            this.btnAnterior.TabIndex = 21;
            this.btnAnterior.Text = " <<";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(11, 163);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(68, 24);
            this.btnNovo.TabIndex = 37;
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // lblSeqCliente
            // 
            this.lblSeqCliente.Location = new System.Drawing.Point(52, 43);
            this.lblSeqCliente.Name = "lblSeqCliente";
            this.lblSeqCliente.Size = new System.Drawing.Size(177, 16);
            this.lblSeqCliente.Text = "Sequencial do cadastro";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.Text = "Cod:";
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.Location = new System.Drawing.Point(11, 3);
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(40, 24);
            this.btnPrimeiro.TabIndex = 43;
            this.btnPrimeiro.Text = " |<";
            this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(189, 3);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(40, 24);
            this.btnUltimo.TabIndex = 44;
            this.btnUltimo.Text = " >|";
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // FormNavegacaoCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnPrimeiro);
            this.Controls.Add(this.lblSeqCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblNHD);
            this.Controls.Add(this.label);
            this.Controls.Add(this.lblLogradouro);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnAnterior);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "FormNavegacaoCadastroCliente";
            this.Text = "OnPlaceMovel - Navegacao Cadastro de cliente";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormNavegacaoCadastroCliente_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNHD;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblLogradouro;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label lblSeqCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrimeiro;
        private System.Windows.Forms.Button btnUltimo;
    }
}