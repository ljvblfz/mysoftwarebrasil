namespace OnPlaceMovel.Source.Forms
{
    partial class FormDigitosHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDigitosHD));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxNumeroDigitos = new System.Windows.Forms.ComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// comboBoxNumeroDigitos
			// 
			this.comboBoxNumeroDigitos.DisplayMember = "_numeroDigitosHD";
			resources.ApplyResources(this.comboBoxNumeroDigitos, "comboBoxNumeroDigitos");
			this.comboBoxNumeroDigitos.Name = "comboBoxNumeroDigitos";
			this.comboBoxNumeroDigitos.ValueMember = "_numeroDigitosHD";
			// 
			// buttonOk
			// 
			resources.ApplyResources(this.buttonOk, "buttonOk");
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// FormDigitosHD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			resources.ApplyResources(this, "$this");
			this.ControlBox = false;
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.comboBoxNumeroDigitos);
			this.Controls.Add(this.label1);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FormDigitosHD";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDigitosHD_KeyDown);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNumeroDigitos;
        private System.Windows.Forms.Button buttonOk;
    }
}