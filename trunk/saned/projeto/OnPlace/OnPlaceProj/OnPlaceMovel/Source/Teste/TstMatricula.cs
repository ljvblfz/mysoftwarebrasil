using System;
using System.Text;
using System.Collections.Generic;

namespace OnPlaceMovel.Source.Teste {
	/// <summary>
	/// Classe que representa uma matricula a ser testada com leitura e ocorrencias
	/// </summary>
	public class TstMatricula {
		#region Atributos e Propriedades
		private int? seqMatricula;
		/// <summary>
		/// Sequencial da matricula
		/// </summary>
		/// <remarks>
		/// <para>get: retorna seqMatricula</para>
		/// <para>set: Atribui para seqMatricula o value recebido</para>
		/// </remarks>
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

		private int? valLeitura;
		/// <summary>
		/// Valor de leitura a ser usado para teste
		/// </summary>
		/// <remarks>
		/// <para>get: retorna valLeitura</para>
		/// <para>set: Atribui para valLeitura o value recebido</para>
		/// </remarks>
		public int? ValLeitura {
			get { return valLeitura; }
			set { valLeitura = value; }
		}

		private TstMatriculaOcorrencia[] ocorrencias;
		/// <summary>
		/// Lista de ocorrencias a serem usadas, caso existam
		/// </summary>
		/// <remarks>
		/// <para>get: retorna ocorrencias</para>
		/// <para>set: Atribui para ocorrencias o value recebido</para>
		/// </remarks>
		public TstMatriculaOcorrencia[] Ocorrencias {
			get { return ocorrencias; }
			set { ocorrencias = value; }
		}
		#endregion // Atributos e Propriedades

		/// <summary>
		/// Construtor padrão
		/// </summary>
		/// <remarks>
		/// Atribui null para ocorrencias
		/// </remarks>
		public TstMatricula() {
			ocorrencias = null;
		}

		#region Metodos publicos
		/// <summary>
		/// Compara este objeto com outro
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Faz um cast de <paramref name="obj"/> para TstMatricula</description></item>
		/// <item><description>Caso objeto nao seja um TstMatricula, retorna false</description></item>
		/// <item><description>Caso contrario compara os sequencias da matricula deste objeto e do objeto recebido, retorna true se forem iguais ou false caso nao sejam.</description></item>
		/// </list>
		/// </remarks>
		/// <param name="obj">Objeto de comparação</param>
		/// <returns>Retorna true se this e obj representam o mesmo objeto em instâncias diferentes, caso contrário retorna false.</returns>
		public override bool Equals(object obj) {
			TstMatricula m = obj as TstMatricula;

			if (obj == null)
				return false;

			return this.SeqMatricula.HasValue && m.SeqMatricula.HasValue && this.SeqMatricula.Value == m.SeqMatricula.Value;
		}

		/// <summary>
		/// Calcula o hashcode do objeto
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Retorna o valor do sequencial da matricula</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o hashcode calculado</returns>
		public override int GetHashCode() {
			return seqMatricula.Value;
		}

		/// <summary>
		/// Representacao em string deste objeto
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso seqMatricula tenha valor, retorna ele convertido para string</description></item>
		/// <item><description>Caso contrario retorna uma string vazia</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna a string que representa este objeto</returns>
		public override string ToString() {
			if (seqMatricula.HasValue)
				return seqMatricula.ToString();
			else
				return null;
		}
		#endregion // Metodos publicos
	}
}
