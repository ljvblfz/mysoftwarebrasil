using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;
using Strategos.Api.Log4CS;
using Strategos.Api.Database.Impl;

namespace OnPlaceMovel.Source.Forms {
	public class Emissao {
		#region Propriedades e Atributos
		private NavegacaoController _navegacao;
		private IImpressaoController _impressao;
		private AlteracaoCadastralController _alteracaoCadastral;
		#endregion // Propriedades e Atributos

		public Emissao() {
			_navegacao = new NavegacaoController(false, true);
			if (_navegacao.LeuTodasMatriculas)
				MessageBox.Show("Fim de Roteiro", "Aviso");
			IniciaProcessoEmissao();
		}

		#region Metodos Publicos
		public void IniciaProcessoEmissao() {
			ILeitura leitura;
			OnpMatricula matricula = null;

			do {
				matricula = _navegacao.Selecionar(matricula);
				if (matricula == null)
					break;

				leitura = ConfigXML.GetClasseLeitura();

				if (leitura.IniciaLeitura(matricula)) {
					DialogResult resultado = MessageBox.Show("Deseja fazer alteração cadastral?", "OnPlaceMovel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
					if (resultado == DialogResult.Yes)
						_alteracaoCadastral = new AlteracaoCadastralController(matricula);

					if ((matricula.Aviso != null && matricula.Aviso.FaturasAviso.Count > 0) || //SE TEM AVISO
					   matricula.Movimento.Fatura != null || //SE TEM FATURA
					   ConfigXML.GetClasseAnaliseConta().RetemParaAnalise(matricula.Movimento) ||  //SE RETEM PARA ANALISE
					   matricula.Movimento.SegundasVias.Count > 0) { //SE TEM SEGUNDAS VIAS
						_impressao = ConfigXML.GetImpressaoController();
						_impressao.MostrarImpressao(matricula);
						_impressao.Dispose();
					}
				}

				_navegacao.AtualizarMatricula(matricula);

				matricula.Persist();
			} while (true);
		}
		#endregion // Metodos Publicos
	}
}
