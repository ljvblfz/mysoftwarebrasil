using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Fatura_Taxa")]
	public sealed class OnpFaturaTaxa : PersistClass<OnpFaturaTaxa> {
		#region Situação da taxa
		public enum SituacaoTaxa {
			Ligado = '1',
			Construcao = '2',
			DesligadoCortado = '3',
			Factivel = '4',
			Potencial = '5'
		}
		#endregion

		#region Tipo de consumo
		public enum TipoConsumo {
			Lido = 'L',
			Atribuido = 'A',
			Estimado = 'E',
			Fixo = 'F'
		}
		#endregion

		#region Atributos
		private int? seqTaxa;
		private int? seqCategoria;
		private int? seqFatura;
		private int? seqMatricula;
		private string codReferencia;
		private int? seqRoteiro;
		private int? valNumeroEconomia;
		private int? valConsumoFaturado;
		private double? valValorCalculado;
		private double? valValorFaturado;
		private string indSituacao;
		private string indTipoConsumo;

		private OnpTaxa taxa;
		private OnpFatura fatura;
		#endregion

		#region Getters ans Setters (Fields)
        [Column(ColumnName = "seq_Fatura", Pk = true)]
		public int? SeqFatura {
			get { return seqFatura; }
			set { seqFatura = value; }
		}
        [Column(ColumnName = "seq_Taxa", Pk = true)]
		public int? SeqTaxa {
			get { return seqTaxa; }
			set { seqTaxa = value; }
		}
        [Column(ColumnName = "seq_Categoria", Pk = true)]
		public int? SeqCategoria {
			get { return seqCategoria; }
			set { seqCategoria = value; }
		}
        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}
        [Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}
        [Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}

        [Column(ColumnName = "val_Numero_Economia")]
		public int? ValNumeroEconomia {
			get { return valNumeroEconomia; }
			set { valNumeroEconomia = value; }
		}
		[Column(ColumnName = "val_Consumo_Faturado")]
		public int? ValConsumoFaturado {
			get { return valConsumoFaturado; }
			set { valConsumoFaturado = value; }
		}
		[Column(ColumnName = "val_Valor_Calculado")]
		public double? ValValorCalculado {
			get { return valValorCalculado; }
			set { valValorCalculado = value; }
		}
		[Column(ColumnName = "val_Valor_Faturado")]
		public double? ValValorFaturado {
			get { return valValorFaturado; }
			set { valValorFaturado = value; }
		}
		[Column(ColumnName = "ind_Situacao")]
		public string IndSituacao {
			get { return indSituacao; }
			set { indSituacao = value; }
		}
		[Column(ColumnName = "ind_Tipo_Consumo")]
		public string IndTipoConsumo {
			get { return indTipoConsumo; }
			set { indTipoConsumo = value; }
		}

		public OnpTaxa Taxa {
			get {
				if (taxa == null)
					taxa = new OnpTaxa(this.seqTaxa.Value);
				return taxa;
			}
			set { taxa = value; }
		}
        
		public OnpFatura Fatura {
			get {
				if ( fatura == null )
					fatura = OnpFatura.Materialize(seqMatricula.Value, codReferencia, seqRoteiro.Value, seqFatura.Value);
				return fatura;
			}
			set { fatura = value; }
		}

		public TipoConsumo TipoDoConsumo {
			get {
				TipoConsumo result = TipoConsumo.Lido;
				if ( IndTipoConsumo != null ) {
					result = (TipoConsumo)IndTipoConsumo[ 0 ];
				}
				return result;
			}
			set { IndTipoConsumo = ( (char)value ).ToString(); }
		}

		public SituacaoTaxa Situacao {
			get { return (SituacaoTaxa)IndSituacao[ 0 ]; }
			set { IndSituacao = ( (char)value ).ToString(); }
		}
		#endregion

		public OnpFaturaTaxa() {
		}

		public static OnpFaturaTaxa Materialize(int seqTaxa, int seqCategoria, int seqFatura, int seqRoteiro, int seqMatricula, string codReferencia) {
			OnpFaturaTaxa retorno = new OnpFaturaTaxa();

			retorno.seqTaxa = seqTaxa;
			retorno.seqCategoria = seqCategoria;
			retorno.seqFatura = seqFatura;
			retorno.seqMatricula = seqMatricula;
			retorno.seqRoteiro = seqRoteiro;			
			retorno.codReferencia = codReferencia;

			if ( !retorno.Select() )
				return null;

			return retorno;
		}
		
		public OnpTaxaTarifa GetTarifa(DateTime data) {
			return this.Taxa.GetTarifa( this.SeqCategoria.Value, data );
		}
	}
}
