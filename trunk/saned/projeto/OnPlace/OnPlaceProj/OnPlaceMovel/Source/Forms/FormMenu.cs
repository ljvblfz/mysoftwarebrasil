using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Controladores;
using System.Collections.ObjectModel;


namespace OnPlaceMovel.Source.Forms {
	public partial class FormMenu : Form {
		private MenuController mControl;
		private Controlador Control;

		public FormMenu(MenuController mControl, Controlador Control) {
			InitializeComponent();
			
			this.mControl = mControl;
			this.Control = Control;
		}

		private void btnEmissao_Click(object sender, EventArgs e) {
			mControl.Emissao();
		}

		private void btnColeta_Click(object sender, EventArgs e) {
			mControl.Coleta();
		}

		private void btnBD_Click(object sender, EventArgs e) {
			mControl.MostraBD();
		}

		private void btnServicos_Click(object sender, EventArgs e) {
			mControl.Servicos();
		}

		private void MenuPrincipal_Activated(object sender, EventArgs e) {
			Controlador.ActiveForm = this;
		}

        #region Eventos do Form
        /// <summary>
        /// Evento para pode fechar a janela com "Enter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMenu_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.E:
                    btnEmissao_Click(sender, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.C:
                    btnColeta_Click(sender, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.B:
                    btnBD_Click(sender, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.S:
                    btnServicos_Click(sender, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Escape:
                    Close();
                    break;

            }

        }
        #endregion // Eventos de form

    }
}