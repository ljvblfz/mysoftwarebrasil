namespace OnPlaceMovel.Source.Forms
{
    partial class FormImpressao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

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
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.lstSegVias = new System.Windows.Forms.ListView();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkFatura = new System.Windows.Forms.CheckBox();
            this.chkAviso = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnEmitir
            // 
            this.btnEmitir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEmitir.Location = new System.Drawing.Point(61, 245);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(72, 20);
            this.btnEmitir.TabIndex = 3;
            this.btnEmitir.Text = "&Emitir";
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // lstSegVias
            // 
            this.lstSegVias.CheckBoxes = true;
            this.lstSegVias.Columns.Add(this.columnHeader);
            this.lstSegVias.Location = new System.Drawing.Point(28, 24);
            this.lstSegVias.Name = "lstSegVias";
            this.lstSegVias.Size = new System.Drawing.Size(183, 215);
            this.lstSegVias.TabIndex = 2;
            this.lstSegVias.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "Segundas Vias";
            this.columnHeader.Width = 180;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(139, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 20);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Sair";
            // 
            // chkFatura
            // 
            this.chkFatura.Location = new System.Drawing.Point(28, 3);
            this.chkFatura.Name = "chkFatura";
            this.chkFatura.Size = new System.Drawing.Size(65, 15);
            this.chkFatura.TabIndex = 0;
            this.chkFatura.Text = "&Fatura";
            // 
            // chkAviso
            // 
            this.chkAviso.Checked = true;
            this.chkAviso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAviso.Location = new System.Drawing.Point(99, 3);
            this.chkAviso.Name = "chkAviso";
            this.chkAviso.Size = new System.Drawing.Size(112, 15);
            this.chkAviso.TabIndex = 1;
            this.chkAviso.Text = "&Aviso de débito";
            // 
            // FormImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.chkAviso);
            this.Controls.Add(this.chkFatura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lstSegVias);
            this.Controls.Add(this.btnEmitir);
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "FormImpressao";
            this.Text = "OnPlace - Emissao";
            this.Activated += new System.EventHandler(this.Impressao_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormImpressao_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.ListView lstSegVias;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkFatura;
        private System.Windows.Forms.CheckBox chkAviso;
        private System.Windows.Forms.ColumnHeader columnHeader;
    }
}