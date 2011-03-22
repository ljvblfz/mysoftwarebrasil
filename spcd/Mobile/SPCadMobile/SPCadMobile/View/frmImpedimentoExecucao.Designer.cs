namespace CopasaMobile.View
{
    partial class frmImpedimentoExecucao
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
            this.lblMed = new System.Windows.Forms.Label();
            this.lblMat = new System.Windows.Forms.Label();
            this.tbxMed = new System.Windows.Forms.TextBox();
            this.bindingSourceCadastroAux = new System.Windows.Forms.BindingSource(this.components);
            this.tbxMat = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.tbxEndereco = new System.Windows.Forms.TextBox();
            this.tbxObservacaoImp = new System.Windows.Forms.TextBox();
            this.cbxMotivoImpedimento = new System.Windows.Forms.ComboBox();
            this.lblMotioImpedimento = new System.Windows.Forms.Label();
            this.btnFotos = new System.Windows.Forms.Button();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.ckbFotos = new System.Windows.Forms.CheckBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastroAux)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
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
            this.panel.Controls.Add(this.ckbFotos);
            this.panel.Controls.Add(this.btnDesfazer);
            this.panel.Controls.Add(this.btnFotos);
            this.panel.Controls.Add(this.lblMotioImpedimento);
            this.panel.Controls.Add(this.cbxMotivoImpedimento);
            this.panel.Controls.Add(this.tbxObservacaoImp);
            this.panel.Controls.Add(this.tbxEndereco);
            this.panel.Controls.Add(this.lblEndereco);
            this.panel.Controls.Add(this.tbxCliente);
            this.panel.Controls.Add(this.lblCliente);
            this.panel.Controls.Add(this.tbxMat);
            this.panel.Controls.Add(this.tbxMed);
            this.panel.Controls.Add(this.lblMat);
            this.panel.Controls.Add(this.lblMed);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Impedimento Execução";
            // 
            // lblMed
            // 
            this.lblMed.Location = new System.Drawing.Point(4, 4);
            this.lblMed.Name = "lblMed";
            this.lblMed.Size = new System.Drawing.Size(36, 15);
            this.lblMed.Text = "Méd:";
            // 
            // lblMat
            // 
            this.lblMat.Location = new System.Drawing.Point(116, 4);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(30, 15);
            this.lblMat.Text = "Mat:";
            // 
            // tbxMed
            // 
            this.tbxMed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastroAux, "NumeroMedidor", true));
            this.tbxMed.Location = new System.Drawing.Point(35, 4);
            this.tbxMed.Name = "tbxMed";
            this.tbxMed.ReadOnly = true;
            this.tbxMed.Size = new System.Drawing.Size(79, 21);
            this.tbxMed.TabIndex = 3;
            // 
            // bindingSourceCadastroAux
            // 
            this.bindingSourceCadastroAux.DataSource = typeof(SPCadMobileData.Data.Model.CadastroAuxiliar);
            // 
            // tbxMat
            // 
            this.tbxMat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastroAux, "Matricula", true));
            this.tbxMat.Location = new System.Drawing.Point(145, 4);
            this.tbxMat.Name = "tbxMat";
            this.tbxMat.ReadOnly = true;
            this.tbxMat.Size = new System.Drawing.Size(89, 21);
            this.tbxMat.TabIndex = 4;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(4, 31);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(56, 15);
            this.lblCliente.Text = "Cliente:";
            // 
            // tbxCliente
            // 
            this.tbxCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastroAux, "NomeCliente", true));
            this.tbxCliente.Location = new System.Drawing.Point(66, 29);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.ReadOnly = true;
            this.tbxCliente.Size = new System.Drawing.Size(168, 21);
            this.tbxCliente.TabIndex = 7;
            // 
            // lblEndereco
            // 
            this.lblEndereco.Location = new System.Drawing.Point(4, 51);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(63, 15);
            this.lblEndereco.Text = "Endereço:";
            // 
            // tbxEndereco
            // 
            this.tbxEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastroAux, "enderecoImovel", true));
            this.tbxEndereco.Location = new System.Drawing.Point(4, 66);
            this.tbxEndereco.Multiline = true;
            this.tbxEndereco.Name = "tbxEndereco";
            this.tbxEndereco.ReadOnly = true;
            this.tbxEndereco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxEndereco.Size = new System.Drawing.Size(230, 47);
            this.tbxEndereco.TabIndex = 10;
            // 
            // tbxObservacaoImp
            // 
            this.tbxObservacaoImp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastroAux, "ObservacaoImpedimento", true));
            this.tbxObservacaoImp.Location = new System.Drawing.Point(4, 162);
            this.tbxObservacaoImp.Multiline = true;
            this.tbxObservacaoImp.Name = "tbxObservacaoImp";
            this.tbxObservacaoImp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxObservacaoImp.Size = new System.Drawing.Size(230, 66);
            this.tbxObservacaoImp.TabIndex = 13;
            // 
            // cbxMotivoImpedimento
            // 
            this.cbxMotivoImpedimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceCadastroAux, "VetorOcorrencia", true));
            this.cbxMotivoImpedimento.DisplayMember = "Description";
            this.cbxMotivoImpedimento.Location = new System.Drawing.Point(3, 136);
            this.cbxMotivoImpedimento.Name = "cbxMotivoImpedimento";
            this.cbxMotivoImpedimento.Size = new System.Drawing.Size(230, 22);
            this.cbxMotivoImpedimento.TabIndex = 14;
            this.cbxMotivoImpedimento.ValueMember = "Value";
            // 
            // lblMotioImpedimento
            // 
            this.lblMotioImpedimento.Location = new System.Drawing.Point(4, 119);
            this.lblMotioImpedimento.Name = "lblMotioImpedimento";
            this.lblMotioImpedimento.Size = new System.Drawing.Size(127, 15);
            this.lblMotioImpedimento.Text = "Motivo Impedimento";
            // 
            // btnFotos
            // 
            this.btnFotos.Location = new System.Drawing.Point(134, 234);
            this.btnFotos.Name = "btnFotos";
            this.btnFotos.Size = new System.Drawing.Size(72, 20);
            this.btnFotos.TabIndex = 17;
            this.btnFotos.Text = "Fotos";
            this.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.Location = new System.Drawing.Point(4, 234);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(72, 20);
            this.btnDesfazer.TabIndex = 18;
            this.btnDesfazer.Text = "Desfazer";
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // ckbFotos
            // 
            this.ckbFotos.Enabled = false;
            this.ckbFotos.Location = new System.Drawing.Point(207, 235);
            this.ckbFotos.Name = "ckbFotos";
            this.ckbFotos.Size = new System.Drawing.Size(23, 20);
            this.ckbFotos.TabIndex = 19;
            this.ckbFotos.CheckStateChanged += new System.EventHandler(this.ckbFotos_CheckStateChanged);
            // 
            // frmImpedimentoExecucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmImpedimentoExecucao";
            this.Title = "Impedimento Execução";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastroAux)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMat;
        private System.Windows.Forms.Label lblMed;
        private System.Windows.Forms.TextBox tbxEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbxMat;
        private System.Windows.Forms.TextBox tbxMed;
        private System.Windows.Forms.Label lblMotioImpedimento;
        private System.Windows.Forms.ComboBox cbxMotivoImpedimento;
        private System.Windows.Forms.TextBox tbxObservacaoImp;
        private System.Windows.Forms.Button btnDesfazer;
        private System.Windows.Forms.Button btnFotos;
        private System.Windows.Forms.BindingSource bindingSourceCadastroAux;
        private System.Windows.Forms.CheckBox ckbFotos;
    }
}
