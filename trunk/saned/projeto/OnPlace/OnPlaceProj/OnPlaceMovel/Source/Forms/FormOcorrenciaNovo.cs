using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
	public partial class FormOcorrenciaNovo: Form {
		#region Atributos
		private OcorrenciaController _ocorrenciaControl;
		private bool _fechando;
		#endregion

		public FormOcorrenciaNovo(OcorrenciaController ocorrenciaControl) {
			InitializeComponent();

			btnAdicionar.Focus();

			_ocorrenciaControl = ocorrenciaControl;
			_fechando = false;
		}

		#region Eventos do Form
		private void FormOcorrencia_Activated(object sender, EventArgs e) {
			Controlador.ActiveForm = this;
			_fechando = false;
		}

		private void FormOcorrencia_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case System.Windows.Forms.Keys.Back:
                case System.Windows.Forms.Keys.Delete:
                    SetFieldValue(string.Empty);
                    break;

                case System.Windows.Forms.Keys.Escape:
                    btnCancelar_Click( sender, null);
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }    

        private void FormOcorrenciaNovo_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar >= 48 && e.KeyChar <= 58) {
                SetFieldValue(new string(e.KeyChar, 1));
                e.Handled = true;
				btnAdicionar.Focus();
			}
		}

		private void SetFieldValue(string p) {
			if (!string.IsNullOrEmpty(p)) {
				txtCodigoOcorrencia.Text += p;
			} else {
				txtCodigoOcorrencia.Text = string.Empty;
			}
		}
		#endregion

		#region Eventos de controles do form
		private void btnAdicionar_Click(object sender, EventArgs e) {
			if (_fechando || cboxOcorrencias.SelectedItem == null)
				return;

			if (!lstOcorrenciasCadastradas.Items.Contains(cboxOcorrencias.SelectedItem)) {
				lstOcorrenciasCadastradas.Items.Add(cboxOcorrencias.SelectedItem);

				txtCodigoOcorrencia.Text = string.Empty;
				cboxOcorrencias.SelectedItem = null;
			}

			btnOK.Focus();
		}

		private void txtCodigoOcorrencia_TextChanged(object sender, EventArgs e) {
			if (_fechando)
				return;

			OnpOcorrencia ocorrencia;
			foreach (object obj in cboxOcorrencias.Items) {
				ocorrencia = obj as OnpOcorrencia;
				if (ocorrencia.CodOcorrencia.ToString().Equals(txtCodigoOcorrencia.Text)) {
					cboxOcorrencias.SelectedItem = obj;
					return;
				}
			}

			cboxOcorrencias.SelectedItem = null;
		}

		private void btnOK_Click(object sender, EventArgs e) {
			// Removendo quaisquer ocorrencias ja registradas
			while (_ocorrenciaControl.Matricula.Movimento.MovimentosOcorrencia.Count > 0) {
				_ocorrenciaControl.Matricula.Movimento.MovimentosOcorrencia[0].Remove();
				_ocorrenciaControl.Matricula.Movimento.MovimentosOcorrencia.RemoveAt(0);
			}

			// Adiciona as novas ocorrencias
			Collection<OnpOcorrencia> lista = new Collection<OnpOcorrencia>();
			for (int i = 0; i < lstOcorrenciasCadastradas.Items.Count; i++)
				lista.Add(lstOcorrenciasCadastradas.Items[i] as OnpOcorrencia);

			_ocorrenciaControl.GravaOcorrencias(lista);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnRemover_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			if (lstOcorrenciasCadastradas.SelectedItem != null) {
				int currentIndex = lstOcorrenciasCadastradas.SelectedIndex;

				lstOcorrenciasCadastradas.Items.Remove(lstOcorrenciasCadastradas.SelectedItem);

				if (lstOcorrenciasCadastradas.Items.Count > 0 && currentIndex < lstOcorrenciasCadastradas.Items.Count)
					lstOcorrenciasCadastradas.SelectedIndex = currentIndex;
			}

			btnOK.Focus();
		}

		private void btnCancelar_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			_ocorrenciaControl.Cancelar = true;
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// Coloca na listbox as ocorrencias ja cadastradas para certa matricula
		/// </summary>
		/// <param name="ocorrencias"></param>
		public void CarregaOcorrencias(Collection<OnpMovimentoOcorrencia> ocorrencias) {
			lstOcorrenciasCadastradas.Items.Clear();
			foreach (OnpMovimentoOcorrencia mo in ocorrencias)
				if (!lstOcorrenciasCadastradas.Items.Contains(mo.Ocorrencia) && mo.Ocorrencia != null)
					lstOcorrenciasCadastradas.Items.Add(mo.Ocorrencia);
		}

		/// <summary>
		/// Coloca na combo box a lista de ocorrencias do sistema
		/// </summary>
		/// <param name="ocorrencias"></param>
		public void AddListBoxItens(Collection<OnpOcorrencia> ocorrencias) {
			cboxOcorrencias.Items.Clear();
			foreach (OnpOcorrencia ocorrencia in ocorrencias)
				cboxOcorrencias.Items.Add(ocorrencia);
		}

		/// <summary>
		/// Altera o texto da label de matricula
		/// </summary>
		/// <param name="value"></param>
		public void SetHidrometro(string value) {
			lblHidrometro.Text = value;
		}
		#endregion

		private void FormOcorrenciaNovo_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case System.Windows.Forms.Keys.Enter:
					if (txtCodigoOcorrencia.Text == string.Empty)
						btnOK_Click(sender, null);
					else
						btnAdicionar_Click(sender, null);
					break;

				case System.Windows.Forms.Keys.Back:
				case System.Windows.Forms.Keys.Delete:
					SetFieldValue(string.Empty);
					break;

				case System.Windows.Forms.Keys.Escape:
					btnCancelar_Click(sender, null);
					DialogResult = DialogResult.Cancel;
					break;
			}

		}

	}
}