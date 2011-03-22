namespace CopasaMobile.View
{
    partial class frmInformacaoAdicional
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
            this.btnFotos = new System.Windows.Forms.Button();
            this.tbxInfComplementar = new System.Windows.Forms.TextBox();
            this.bindingSourceCadastroAux = new System.Windows.Forms.BindingSource(this.components);
            this.btnOcorrencias = new System.Windows.Forms.Button();
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
            this.panel.Controls.Add(this.btnFotos);
            this.panel.Controls.Add(this.btnOcorrencias);
            this.panel.Controls.Add(this.tbxInfComplementar);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Informação Adicional";
            // 
            // btnFotos
            // 
            this.btnFotos.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFotos.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnFotos.Location = new System.Drawing.Point(119, 96);
            this.btnFotos.Name = "btnFotos";
            this.btnFotos.Size = new System.Drawing.Size(95, 20);
            this.btnFotos.TabIndex = 202;
            this.btnFotos.Text = "Fotos";
            this.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);
            // 
            // tbxInfComplementar
            // 
            this.tbxInfComplementar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfComplementar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCadastroAux, "ObservacaoVisita", true));
            this.tbxInfComplementar.Location = new System.Drawing.Point(4, 4);
            this.tbxInfComplementar.MaxLength = 300;
            this.tbxInfComplementar.Multiline = true;
            this.tbxInfComplementar.Name = "tbxInfComplementar";
            this.tbxInfComplementar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInfComplementar.Size = new System.Drawing.Size(233, 86);
            this.tbxInfComplementar.TabIndex = 200;
            // 
            // bindingSourceCadastroAux
            // 
            this.bindingSourceCadastroAux.DataSource = typeof(SPCadMobileData.Data.Model.CadastroAuxiliar);
            // 
            // btnOcorrencias
            // 
            this.btnOcorrencias.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOcorrencias.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOcorrencias.Location = new System.Drawing.Point(18, 96);
            this.btnOcorrencias.Name = "btnOcorrencias";
            this.btnOcorrencias.Size = new System.Drawing.Size(95, 20);
            this.btnOcorrencias.TabIndex = 201;
            this.btnOcorrencias.Text = "Ocorrências";
            this.btnOcorrencias.Click += new System.EventHandler(this.btnOcorrencias_Click);
            // 
            // frmInformacaoAdicional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmInformacaoAdicional";
            this.Title = "Informação Adicional";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCadastroAux)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFotos;
        private System.Windows.Forms.Button btnOcorrencias;
        private System.Windows.Forms.TextBox tbxInfComplementar;
        private System.Windows.Forms.BindingSource bindingSourceCadastroAux;
    }
}
