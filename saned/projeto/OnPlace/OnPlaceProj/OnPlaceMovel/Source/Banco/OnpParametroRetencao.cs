using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Parametro_Retencao")]
	public sealed class OnpParametroRetencao : PersistClass<OnpParametroRetencao> {
		#region Atributos
		private string indRetencao;
		private int? seqFaixa;
		private int? valMediaInicial;
		private int? valMediaFinal;
		private double? valVariacaoAviso;
		private double? valVariacaoRetencao;
		private string indUnidadeVariacao;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "ind_Retencao", Pk = true)]
		public string IndRetencao {
			get { return indRetencao; }
			set { indRetencao = value; }
		}

        [Column(ColumnName = "seq_Faixa", Pk = true)]
		public int? SeqFaixa {
			get { return seqFaixa; }
			set { seqFaixa = value; }
		}
        [Column(ColumnName = "val_Media_Inicial")]
		public int? ValMediaInicial {
			get { return valMediaInicial; }
			set { valMediaInicial = value; }
		}
        [Column(ColumnName = "val_Media_Final")]
		public int? ValMediaFinal {
			get { return valMediaFinal; }
			set { valMediaFinal = value; }
		}
        [Column(ColumnName = "val_Variacao_Aviso")]
		public double? ValVariacaoAviso {
			get { return valVariacaoAviso; }
			set { valVariacaoAviso = value; }
		}
        [Column(ColumnName = "val_Variacao_Retencao")]
		public double? ValVariacaoRetencao {
			get { return valVariacaoRetencao; }
			set { valVariacaoRetencao = value; }
		}
        [Column(ColumnName = "ind_Unidade_Variacao")]
		public string IndUnidadeVariacao {
			get { return indUnidadeVariacao; }
			set { indUnidadeVariacao = value; }
		}
		#endregion

		public OnpParametroRetencao(string indRetencao, int seqFaixa) {
			this.indRetencao = indRetencao;
			this.seqFaixa = seqFaixa;
			this.Materialize();
		}
		public OnpParametroRetencao() { }

		/// <summary>
		/// Calcula a variacao para aviso
		/// </summary>
		/// <param name="consumo"></param>
		/// <returns></returns>
		public int CalculaVariacaoAviso(int consumo) {
			int result = 0;
			
			// Variacao em consumo
			if ( IndUnidadeVariacao.Equals( "C" ) ) {
				result = (int)ValVariacaoAviso.Value;
			} else { // Variacao em percentual
				result = (int)( ValVariacaoAviso.Value * consumo / 100 );
			}
			
			return result;
		}

		/// <summary>
		/// Calcula a variacao para retencao
		/// </summary>
		/// <param name="consumo"></param>
		/// <returns></returns>
		public int CalculaVariacaoRetencao(int consumo) {
			int result = 0;
			
			// Variacao em consumo
			if ( IndUnidadeVariacao.Equals( "C" ) ) {
				result = (int)ValVariacaoRetencao.Value;
			} else { // Variacao em percentual
				result = (int)( ValVariacaoRetencao.Value * consumo / 100 );
			}
			
			return result;
		}  
	}
}
