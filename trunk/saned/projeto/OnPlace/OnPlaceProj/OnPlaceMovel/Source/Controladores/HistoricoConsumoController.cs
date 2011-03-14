using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {

    public class HistoricoConsumoController {
		#region Atributos e Propriedades
		private FormHistoricoConsumo formHistConsumo;

		private OnpMatricula _matricula;
		public OnpMatricula Matricula {
            get { return _matricula; }
        }

		private ICollection<OnpHistorico> _historico;
		public ICollection<OnpHistorico> Historico {
            get { return _historico; }
		}
		#endregion // Atributos e Propriedades

		public HistoricoConsumoController() {
			formHistConsumo = new FormHistoricoConsumo(this);
		}

		#region Metodos Publicos
		public void MostrarHistorico(OnpMatricula pMatricula) {
			_matricula = pMatricula;
			HistoricoConsumo();
			formHistConsumo.PreencheCamposTela();
			formHistConsumo.ShowDialog();
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
        /// Preeche a lista de historico de consumo
        /// </summary>
        private void HistoricoConsumo() {
            // Preenche uma fatura com os valores da matricula em questão
            OnpFatura fatura = new OnpFatura();
            fatura.SeqMatricula = _matricula.SeqMatricula;
            fatura.CodReferencia = _matricula.Movimento.CodReferencia;
            
			// Busca ultimas referencias a partir da fatura em questão
            _historico = fatura.BuscaHistoricoConsumo(0);
		}
		#endregion // Metodos Privados
	}
}
