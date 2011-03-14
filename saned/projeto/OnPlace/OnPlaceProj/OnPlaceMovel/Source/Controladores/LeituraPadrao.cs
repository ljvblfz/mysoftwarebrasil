using System;
using System.Text;
using System.Collections.Generic;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class LeituraPadrao: OnPlaceMovel.Source.Controladores.ILeitura {
		#region Atributos e Propriedades
		protected OcorrenciaController _ocorrencia;
		protected ILeituraHDController _leitura;
		#endregion // Atributos e Propriedades

		public LeituraPadrao() { }

		#region Metodos Publicos
		public virtual bool IniciaLeitura(OnpMatricula matricula) {
			//Valida a data atual e a data da ultima leitura
			ValidaData(matricula);

			//Le as ocorrencias
			_ocorrencia = new OcorrenciaController(matricula);

			// Caso processo de leitura seja cancelado pelo leiturista
			if (_ocorrencia.Cancelar)
				return false;

			_ocorrencia.Dispose();

			// TRATAR AKI TODOS OS CASOS EM QUE SE PODE OU NAO FAZER A LEITURA DO HIDROMETRO
			bool podeLer = true;
			if (matricula.Movimento.MovimentosOcorrencia.Count > 0)
				if (matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.IndLeitura.Equals("N"))
					podeLer = false;

			if (podeLer) {
				_leitura = ConfigXML.GetLeituraHD();
				_leitura.FazerLeitura(matricula, TipoLeitura.Precisa);

				// Caso processo de leitura seja cancelado pelo leiturista
				if (_leitura.Cancelar)
					return false;

				_leitura.Dispose();
			} else
				matricula.Movimento.Processa();

			return true;
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
		/// Valida a data atual do sistema e a data da ultima leitura da matricula
		/// </summary>
		/// <param name="matricula">Matricula a validar</param>
		protected void ValidaData(OnpMatricula matricula) {
            return;//MARRETA TESTE ALEXIS DATA 4/10/2010
            if (matricula.Movimento.DatLeituraAnterior.HasValue && matricula.Movimento.DatProximaLeitura.HasValue) {
				if (DateTime.Now < matricula.Movimento.DatLeituraAnterior.Value.Date ||
					DateTime.Now < OnpRoteiro.Roteiro.DatServidor.Value.Date ||
					DateTime.Now > matricula.Movimento.DatProximaLeitura.Value.Date
				) {
					string mensagem = "Data e hora do sistema inválidos!\nCorrija a data e hora do sistema e retorne ao OnPlace.";
					System.Windows.Forms.MessageBox.Show(mensagem);
					throw new Exception(mensagem);
				}
			}
		}
		#endregion // Metodos Privados
	}
}														  