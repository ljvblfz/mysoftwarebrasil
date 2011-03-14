using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Forms {
	public partial class FormNavegacao: Form {
		#region Atributos e Propriedades
		private bool _emissao;
		private bool _fechando;
		private NavegacaoController _navControl;
		#endregion // Atributos e Propriedades

		public FormNavegacao(NavegacaoController navControl, bool emissao) {
			InitializeComponent();

			_navControl = navControl;
			_emissao = emissao;
			_fechando = false;

			lblDataHoraColeta.Text = string.Empty;

			LimpaCampos();
		}

		#region Eventos de controles
		/// <summary>
		/// Click no botão para navegar para o primeiro registro do caminhamento
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrimeiro_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			IrPara(IrParaMatricula.Primeira);

			if (!_emissao)
				btnSelecionar.Enabled = !chkProcessado.Checked;
		}

        /// <summary>
        /// Click para navegar para o registro anterior não lido do registro atual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnteriorNaoLido() {
            if (_fechando)
                return;

            IrPara(IrParaMatricula.AnteriorNaoLida);

            if (!_emissao)
                btnSelecionar.Enabled = !chkProcessado.Checked;
        }

        /// <summary>
        /// Click para navegar para o registro anterior não lido do registro atual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProximaNaoLido() {
            if (_fechando)
                return;

            IrPara(IrParaMatricula.ProximaNaoLida);

            if (!_emissao)
                btnSelecionar.Enabled = !chkProcessado.Checked;
        }

		/// <summary>
		/// Click no botão para navegar para o registro anterior do registro atual
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnterior_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			IrPara(IrParaMatricula.Anterior);

			if (!_emissao)
				btnSelecionar.Enabled = !chkProcessado.Checked;
		}

		/// <summary>
		/// Click no botão para navegar para o registro proximo do registro atual
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnProximo_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			IrPara(IrParaMatricula.Proxima);

			if (!_emissao)
				btnSelecionar.Enabled = !chkProcessado.Checked;
		}

		/// <summary>
		/// Click no botão para navegar para o ultimo registro do caminhamento
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUltimo_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			IrPara(IrParaMatricula.Ultima);

			if (!_emissao)
				btnSelecionar.Enabled = !chkProcessado.Checked;
		}

		/// <summary>
		/// Mostra tela de Pesquisa e opcoes de navegação
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pboxOpcoes_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			_navControl.Pesquisar();
		}

		/// <summary>
		/// Mostra mensagem com estatisticas de leitura
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pboxEstatisticas_Click(object sender, EventArgs e) {
			if (_fechando)
				return;

			string[] msgEstatistica = NavegacaoController.Estatisticas();

			StringBuilder sb = new StringBuilder();

			sb.Append("Roteiro ");
			sb.Append(msgEstatistica[0]);

			sb.Append("\nContas Processadas: ");
			sb.Append(msgEstatistica[1]);

			sb.Append("\nContas Emitidas: ");
			sb.Append(msgEstatistica[2]);

			sb.Append("\nContas Retidas: ");
			sb.Append(msgEstatistica[3]);

			sb.Append("\nContas restantes: ");
			sb.Append(int.Parse(msgEstatistica[4]) - int.Parse(msgEstatistica[1]));

			sb.Append("\nTotal de Contas: ");
			sb.Append(msgEstatistica[4]);

			MessageBox.Show(sb.ToString(), "Estatísticas de Leituras");
		}

		private void btnHistorico_Click(object sender, EventArgs e) {
			_navControl.HistoricoConsumo();
		}
		#endregion // Eventos de controles

		#region Eventos do Form
		/// <summary>
		/// Evento para pode fechar a janela com "Enter"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormNavegacao_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case System.Windows.Forms.Keys.Enter:
					if (!btnHistorico.Focused && !btnSair.Focused) {
						_fechando = true;
						DialogResult = DialogResult.OK;
						Close();
					}
					e.Handled = true;
					break;

                case System.Windows.Forms.Keys.Up:
                    AnteriorNaoLido();
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Down:
                    ProximaNaoLido();
                    e.Handled = true;
                    break;

				case System.Windows.Forms.Keys.I:
					btnPrimeiro_Click(sender, null);
					e.Handled = true;
					break;

                case System.Windows.Forms.Keys.Left:
                    btnAnterior_Click(sender, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.A:
					btnAnterior_Click(sender, null);
					e.Handled = true;
					break;

                case System.Windows.Forms.Keys.Right:
                    btnProximo_Click(sender, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.P:
					btnProximo_Click(sender, null);
					e.Handled = true;
					break;

				case System.Windows.Forms.Keys.U:
					btnUltimo_Click(sender, null);
					e.Handled = true;
					break;

				case System.Windows.Forms.Keys.E:
					pboxEstatisticas_Click(sender, null);
					e.Handled = true;
					break;

				case System.Windows.Forms.Keys.B:
					pboxOpcoes_Click(sender, null);
					e.Handled = true;
					break;

				case System.Windows.Forms.Keys.H:
					btnHistorico_Click(sender, null);
					e.Handled = true;
					break;

				case System.Windows.Forms.Keys.Escape:
					_fechando = true;
					DialogResult = DialogResult.Cancel;
					e.Handled = true;
					break;

			}
		}

		/// <summary>
		/// Evento para indicar descarga de matriculas em background
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Navegacao_Activated(object sender, EventArgs e) {
			Controlador.ActiveForm = this;
			_fechando = false;
		}
		#endregion // Eventos do Form

		#region Metodos publicos
		/// <summary>
		/// Atualiza a tela com as informações de uma matricula
		/// </summary>
		/// <param name="matricula">Matricula com as informações a serem mostradas</param>
		public void AtualizaTela(OnpMatricula matricula) {
			// Para de desenhar a tela
			SuspendLayout();

			// Limpa os campos para valores em branco
			LimpaCampos();

			lblNome.Text = matricula.NomCliente;

			if (matricula.Movimento.Hidrometro != null)
				lblNrHidrometro.Text = matricula.Movimento.Hidrometro.CodHidrometro + "(" + matricula.SeqLeitura + ")";
			else
				lblNrHidrometro.Text = "<SEM HD> (" + matricula.SeqLeitura + ")";

			lblNrMatricula.Text = matricula.SeqMatricula.Value.ToString();

			lblLogradouro.Text = matricula.Logradouro.DesLogradouro + ", " +
								 matricula.ValNumeroImovel.Value.ToString() + "\n" +
								 matricula.DesComplemento;

			if (matricula.Movimento.DatLeitura.HasValue)
				lblDataHoraColeta.Text = matricula.Movimento.DatLeitura.Value.ToString("dd/MM/yyyy hh:mm");

			lblInfoMedia.Visible = matricula.Movimento.ValConsumoMedio.HasValue;
			if (lblMedia.Visible)
				lblMedia.Text = matricula.Movimento.ValConsumoMedio.Value.ToString();

			// Aviso 1
			if (matricula.Movimento.IndEntregaEspecial.Equals("1"))
				lblAviso1.Text = "Débito automático";

			if (matricula.Movimento.IndEntregaEspecial.Equals("2"))
				lblAviso1.Text = "End. alternativo";

			if (matricula.Movimento.IndEntregaEspecial.Equals("4"))
				lblAviso1.Text = "Poder Público";

			// Aviso 2 / Categoria 1 e 2
			Label[] labels = new Label[] { lblCategoria1, lblCategoria2 };
			Label[] labelsInfo = new Label[] { lblInfoCategoria1, lblInfoCategoria2 };
			int taxasCortadas = 0, taxasTotal = 0, catCont = 0;
			foreach (OnpMovimentoCategoria mc in matricula.Movimento.MovimentosCategoria) {

				if (catCont < labels.Length) {
					labels[catCont].Text = mc.Categoria.DesCategoria + " / " + mc.ValNumeroEconomia.GetValueOrDefault(-1);
					labelsInfo[catCont].Visible = !string.IsNullOrEmpty(labels[catCont].Text);
					catCont++;
				}

				foreach (OnpMovimentoTaxa mt in mc.Taxas) {
					taxasTotal++;

					if (!string.IsNullOrEmpty(mt.IndSituacao) && mt.IndSituacao.Equals("3"))
						taxasCortadas++;
				}
			}

			if (taxasCortadas > 0)
				lblAviso2.Text = "Lig. cortada";

			// Ocorrencias
			OnpMovimentoOcorrencia filtro = new OnpMovimentoOcorrencia();
			filtro.SeqMatricula = matricula.Movimento.SeqMatricula;
			filtro.SeqRoteiro = matricula.Movimento.SeqRoteiro;
			filtro.CodReferencia = matricula.Movimento.CodReferencia;
			Collection<OnpMovimentoOcorrencia> ocorrencias = filtro.SelectCollection();
			StringBuilder sb = new StringBuilder();
			foreach (OnpMovimentoOcorrencia o in ocorrencias) {
				sb.Append(o.CodOcorrencia);
				sb.Append(" / ");
			}
			lblOcorrencias.Text = sb.ToString();
			lblInfoOcorrencias.Visible = !string.IsNullOrEmpty(lblOcorrencias.Text);

			// Leitura
			if (matricula.Movimento.ValLeituraReal.HasValue)
				lblLeitura.Text = matricula.Movimento.ValLeituraReal.Value.ToString();
			else if (matricula.Movimento.ValLeituraAtribuida.HasValue)
				lblLeitura.Text = matricula.Movimento.ValLeituraAtribuida.Value.ToString();

			lblInfoLeitura.Visible = !string.IsNullOrEmpty(lblLeitura.Text);

			// Checkboxes
			chkProcessado.Checked = matricula.IndProcessado.Equals("S");
			chkImpresso.Checked = matricula.IndImpresso.Equals("S");

			ResumeLayout(true);
		}
		#endregion // Metodos publicos

		#region Metodos privados
		private void LimpaCampos() {
			lblAviso1.Text = string.Empty;
			lblAviso2.Text = string.Empty;
			lblCategoria1.Text = string.Empty;
			lblCategoria2.Text = string.Empty;
			lblDataHoraColeta.Text = string.Empty;
			lblLogradouro.Text = string.Empty;
			lblMedia.Text = string.Empty;
			lblLeitura.Text = string.Empty;
			lblNome.Text = string.Empty;
			lblNrHidrometro.Text = string.Empty;
			lblNrMatricula.Text = string.Empty;
			lblOcorrencias.Text = string.Empty;

			chkImpresso.Checked = chkProcessado.Checked = false;

			lblInfoMedia.Visible = lblInfoOcorrencias.Visible = lblInfoLeitura.Visible =
				lblInfoCategoria1.Visible = lblInfoCategoria2.Visible = false;
		}

		private void IrPara(IrParaMatricula irParaMatricula) {
			PosicaoNavegacao posicao = _navControl.IrPara(irParaMatricula);
			if (posicao == PosicaoNavegacao.Primeiro)
				MessageBox.Show("Primeiro registro");

			if (posicao == PosicaoNavegacao.Ultimo)
				MessageBox.Show("Último registro");

            if (posicao == PosicaoNavegacao.PrimeiroNaoLido)
                MessageBox.Show("Não há registro não lido anteriormente.");
            
            if (posicao == PosicaoNavegacao.UltimoNaoLido)
                MessageBox.Show("Não há registro não lido posteriormente.");
        }
		#endregion // Metodos privados

	}
}