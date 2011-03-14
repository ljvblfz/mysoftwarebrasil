using System;
using System.Text;
using System.Collections.Generic;

namespace OnPlaceMovel.Source.Teste {
	/// <summary>
	/// Classe para associar uma ocorrencia a uma matricula
	/// </summary>
	public class TstMatriculaOcorrencia {
		#region Atributos e Propriedades
		private int? seqMatricula;
		/// <summary>
		/// Sequencial da matricula
		/// </summary>
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

		private int? seqOcorrencia;
		/// <summary>
		/// Sequencial da ocorrencia
		/// </summary>
		public int? SeqOcorrencia {
			get { return seqOcorrencia; }
			set { seqOcorrencia = value; }
		}
		#endregion
	}
}
