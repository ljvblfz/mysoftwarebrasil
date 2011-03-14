using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Fatura_Categoria")]
	public sealed class OnpFaturaCategoria : PersistClass<OnpFaturaCategoria> {
		#region Atributos
		private int? seqCategoria;
		private int? seqFatura;
		private int? seqMatricula;
		private string codReferencia;
		private int? seqRoteiro;
		private int? valNumeroEconomia;
		private double? valValorFaturado;

		private Collection<OnpFaturaTaxa> taxas;
		#endregion

		#region Getters ans Setters (Fields)
        [Column(ColumnName = "seq_Categoria", Pk = true)]
		public int? SeqCategoria {
			get { return seqCategoria; }
			set { seqCategoria = value; }
		}
        [Column(ColumnName = "seq_Fatura", Pk = true)]
		public int? SeqFatura {
			get { return seqFatura; }
			set { seqFatura = value; }
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
        [Column(ColumnName = "val_Valor_Faturado")]
		public double? ValValorFaturado {
			get { return valValorFaturado; }
			set { valValorFaturado = value; }
		}

		private OnpCategoria categoria;
		public OnpCategoria Categoria {
			get {
				if (categoria == null) {
					categoria = new OnpCategoria(seqCategoria.Value);
				}
				return categoria;
			}
		}

		public Collection<OnpFaturaTaxa> Taxas {
			get {
				if ( taxas == null ) {
					OnpFaturaTaxa taxa = new OnpFaturaTaxa();
					taxa.SeqCategoria = this.seqCategoria;
					taxa.SeqFatura = this.seqFatura;
					taxa.SeqRoteiro = this.seqRoteiro;
					taxa.SeqMatricula = this.seqMatricula;
					taxa.CodReferencia = this.codReferencia;

					taxas = taxa.SelectCollection();
				}
				return taxas;
			}
		}
		#endregion

		public OnpFaturaCategoria() {
		}

		public static OnpFaturaCategoria Materialize(int seqMatricula, string codReferencia, int seqRoteiro, int seqFatura, int seqCategoria) {
			OnpFaturaCategoria retorno = new OnpFaturaCategoria();
			retorno.seqCategoria = seqCategoria;
			retorno.seqFatura = seqFatura;
			retorno.seqMatricula = seqMatricula;
			retorno.seqRoteiro = seqRoteiro;
			retorno.codReferencia = codReferencia;
			if ( !retorno.Select() )
				return null;
			
			return retorno;
		}
	}
}
