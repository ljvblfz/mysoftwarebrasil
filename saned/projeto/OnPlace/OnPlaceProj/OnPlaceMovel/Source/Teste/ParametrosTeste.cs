using System;
using System.Collections.Generic;
using System.Text;

namespace OnPlaceMovel.Source.Teste {
	/// <summary>
	/// Representa um teste completo com matriculas e data de leitura
	/// </summary>
	public class ParametrosTeste {
		#region Atributos e Propriedades
		private DateTime _datLeitura;
		/// <summary>
		/// Data de leitura a ser usada no sistema
		/// </summary>
		/// <remarks>
		/// <para>get: retorna _datLeitura</para>
		/// <para>set: Atribui para _datLeitura o value recebido</para>
		/// </remarks>
		public DateTime DatLeitura {
			get { return _datLeitura; }
			set { _datLeitura = value; }
		}

		private TstMatricula[] _matriculas;
		/// <summary>
		/// Matriculas a serem testadas
		/// </summary>
		/// <remarks>
		/// <para>get: retorna _matriculas</para>
		/// <para>set: Atribui para _matriculas o value recebido</para>
		/// </remarks>
		public TstMatricula[] Matriculas {
			get { return _matriculas; }
			set { _matriculas = value; }
		}
		#endregion // Atributos e Propriedades

		/// <summary>
		/// Construtor padrão, necessaria pra fazer serialização
		/// </summary>
		public ParametrosTeste() { }
	}
}
