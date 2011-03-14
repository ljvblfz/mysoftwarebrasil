using System;
using System.Text;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Diadema {
	[Table(TableName = "onp_Matricula_Diadema")]
	public class OnpMatriculaDiadema: PersistClass<OnpMatriculaDiadema> {
		#region Tipos
		public static class TipoConsumidor {
			public const string Normal = "1";
			public const string HDComunitario = "2";
			public const string FaturaComposta3 = "3";
			public const string HDPoco = "4";
			public const string MedidorEsgoto = "5";
			public const string CaminhaoPipaNF = "6";
			public const string NormalEsgotamentoEspecial = "7";
			public const string FaturaComposta8 = "8";
			public const string HDApartamento = "9";
			public const string CaminhaoPipaHD = "10";
		};
		#endregion

		#region Atributos e Propriedades
		private int? seqMatricula;
		[Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

		private int? seqMatriculaPai;
		[Column(ColumnName = "seq_Matricula_Pai")]
		public int? SeqMatriculaPai {
			get { return seqMatriculaPai; }
			set { seqMatriculaPai = value; }
		}

		private int? seqDesconto;
		[Column(ColumnName = "seq_Desconto")]
		public int? SeqDesconto {
			get { return seqDesconto; }
			set { seqDesconto = value; }
		}

		private string indCortaLigacao;
		[Column(ColumnName = "ind_Corta_Ligacao")]
		public string IndCortaLigacao {
			get { return indCortaLigacao; }
			set { indCortaLigacao = value; }
		}

		private string indCortouLigacao;
		[Column(ColumnName = "ind_Cortou_Ligacao")]
		public string IndCortouLigacao {
			get { return indCortouLigacao; }
			set { indCortouLigacao = value; }
		}

		private string indRetencaoImpostos;
		[Column(ColumnName = "ind_Retencao_Impostos")]
		public string IndRetencaoImpostos {
			get { return indRetencaoImpostos; }
			set { indRetencaoImpostos = value; }
		}

		private string indBloqueio;
		[Column(ColumnName = "ind_Bloqueio")]
		public string IndBloqueio {
			get { return indBloqueio; }
			set { indBloqueio = value; }
		}

		private int? valDiasBloqueioAnterior;
		[Column(ColumnName = "val_Dias_Bloqueio_Anterior")]
		public int? ValDiasBloqueioAnterior {
			get { return valDiasBloqueioAnterior; }
			set { valDiasBloqueioAnterior = value; }
		}

		private int? valDiasBloqueioAtual;
		[Column(ColumnName = "val_Dias_Bloqueio_Atual")]
		public int? ValDiasBloqueioAtual {
			get { return valDiasBloqueioAtual; }
			set { valDiasBloqueioAtual = value; }
		}

		private string indCachorro;
		[Column(ColumnName = "ind_Cachorro")]
		public string IndCachorro {
			get { return indCachorro; }
			set { indCachorro = value; }
		}

		private int? valFraudes;
		[Column(ColumnName = "val_Fraudes")]
		public int? ValFraudes {
			get { return valFraudes; }
			set { valFraudes = value; }
		}

		private string indEmiteFatura;
		[Column(ColumnName = "ind_Emite_Fatura")]
		public string IndEmiteFatura {
			get { return indEmiteFatura; }
			set { indEmiteFatura = value; }
		}

		private string indCalculaFatura;
		[Column(ColumnName = "ind_Calcula_Fatura")]
		public string IndCalculaFatura {
			get { return indCalculaFatura; }
			set { indCalculaFatura = value; }
		}

		private string indTipoConsumidor;
		[Column(ColumnName = "ind_Tipo_Consumidor")]
		public string IndTipoConsumidor {
			get { return indTipoConsumidor; }
			set { indTipoConsumidor = value; }
		}

		private string desMensagem1;
		[Column(ColumnName = "des_Mensagem_1")]
		public string DesMensagem1 {
			get { return desMensagem1; }
			set { desMensagem1 = value; }
		}

		private string desMensagem2;
		[Column(ColumnName = "des_Mensagem_2")]
		public string DesMensagem2 {
			get { return desMensagem2; }
			set { desMensagem2 = value; }
		}

		private DateTime? datBloqueio;
		[Column(ColumnName = "dat_Bloqueio")]
        public DateTime? DatBloqueio {
			get { return datBloqueio; }
			set { datBloqueio = value; }
		}

		public bool isFilho {
			get {
				if (seqMatriculaPai.HasValue && seqMatricula.HasValue)
					return !seqMatriculaPai.Value.Equals(seqMatricula.Value);
				else
					return false;
			}
		}

		private string filhosLidos;
		public string FilhosLidos {
			get { return filhosLidos; }
			set { filhosLidos = value; }
		}

		#endregion

		#region Mapeamentos
		private OnpDescontoDiadema descontoDiadema;
		public OnpDescontoDiadema DescontoDiadema {
			get {
				if (descontoDiadema == null && seqDesconto.HasValue) {
					descontoDiadema = new OnpDescontoDiadema(seqDesconto.Value);
					if (!descontoDiadema.SeqDesconto.HasValue)
						descontoDiadema = null;
				}
				return descontoDiadema;
			}
		}

		private OnpMatricula matricula;
		public OnpMatricula Matricula {
			get {
				if (matricula == null) {
					matricula = new OnpMatricula(seqMatricula.Value);
					if (!matricula.SeqMatricula.HasValue)
						matricula = null;
				}
				return matricula;
			}
			set { matricula = value; }
		}

		private OnpMatriculaDiadema matriculaPai;
		public OnpMatriculaDiadema MatriculaPai {
			get {
				if (matriculaPai == null) {
					if (seqMatricula == seqMatriculaPai || !seqMatriculaPai.HasValue)
						matriculaPai = this;
					else {
						matriculaPai = new OnpMatriculaDiadema(seqMatriculaPai.Value);
						if (!matriculaPai.SeqMatricula.HasValue)
							matriculaPai = null;
					}
				}
				return matriculaPai;
			}
		}

		private Collection<OnpMatriculaDiadema> filhos;
		public Collection<OnpMatriculaDiadema> Filhos {
			get {
				if (filhos == null) {
					OnpMatriculaDiadema matFiltro = new OnpMatriculaDiadema();
					matFiltro.SeqMatriculaPai = SeqMatricula;
					filhos = matFiltro.SelectCollection();

					// Removendo o pai da colecao
					// nao usar foreach pois a colecao vai ser alterada durante o loop
					for (int i = 0; i < filhos.Count; i++)
						if (!filhos[i].isFilho) {
							filhos.RemoveAt(i);
							break;
						}
				}

				return filhos;
			}
		}
		#endregion

		public OnpMatriculaDiadema() { }

		public OnpMatriculaDiadema(int seqMatricula) {
			this.seqMatricula = seqMatricula;

			if (!Select())
				this.seqMatricula = null;
		}

		#region Metodos Publicos
		/// <summary>
		/// Verifica se a leitura já foi feita no pai, caso a propria matricula seja o pai ela verifica se ela mesma ja foi lida
		/// </summary>
		/// <returns>Retorna true se ja fez a leitura do pai, caso contrario retorna false se nao fez a leitura ou se esta matricula não é um filho.</returns>
		public bool LeuPai() {
			return this.MatriculaPai.Matricula.Lido();
		}

		/// <summary>
		/// Verifica se ja foram feita as leituras dos filhos, caso esta matricula seja filho o pai desta matricula é procurado e verifica se todos os filhos (irmãos desta matricula) foram lidos
		/// </summary>
		/// <returns>Retorna true se ja fez a leitura de todos os filhos, caso contrario retorna false se não fez a leitura ou se esta matricula é um filho.</returns>
		public bool LeuTodosFilhos() {
			return QueriesDiadema.getFilhosNaoProcessados(this) == 0;
		}

		/// <summary>
		/// Verifica se ja foram feita as leituras dos filhos, caso esta matricula seja filho o pai desta matricula é procurado e verifica se todos os filhos (irmãos desta matricula) foram lidos
		/// </summary>
		/// <returns>Retorna true se ja fez a leitura de todos os filhos, caso contrario retorna false se não fez a leitura ou se esta matricula é um filho.</returns>
		public int getFilhosNaoProcessados() {
			return QueriesDiadema.getFilhosNaoProcessados(this);
		}

		/// <summary>
		/// Vasculhas os filhos a procura de alguem que tenha ficado retido
		/// </summary>
		/// <returns>Retorna true se teve pelo menos um filho retido, caso contrario retorna false.</returns>
		public bool temFilhosRetido() {
			return QueriesDiadema.getFilhosRetidos(this) > 0;
		}

		/// <summary>
		/// Vasculhas os filhos a procura de alguem que tenha ficado retido
		/// </summary>
		/// <returns>Retorna true se teve pelo menos um filho retido, caso contrario retorna false.</returns>
		public bool SetTipoEntregaFilhos(int seqTipoEntrega) {
			return QueriesDiadema.SetTipoEntregaFilhos(this.seqMatriculaPai, seqTipoEntrega);
		}
		#endregion
	}
}
