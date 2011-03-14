using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Movimento_Categoria")]
	public sealed class OnpMovimentoCategoria : PersistClass<OnpMovimentoCategoria> {
		#region Atributos
		private int? seqCategoria;
		private string codReferencia;
		private int? seqMatricula;
		private int? seqRoteiro;
		private int? valNumeroEconomia;
		private double? valValorFaturado;

		private OnpCategoria categoria;
		private Collection<OnpMovimentoTaxa> taxas;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Categoria", Pk = true)]
		public int? SeqCategoria {
			get { return seqCategoria; }
			set { seqCategoria = value; }
		}

        [Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}

        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
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
		[Column(ColumnName = "val_Valor_Faturado" )]
		public double? ValValorFaturado {
			get { return valValorFaturado; }
			set { valValorFaturado = value; }
		}
		
		public OnpCategoria Categoria {
			get {
				if ( categoria == null ) {
					categoria = new OnpCategoria( this.SeqCategoria.Value );
				}
				return categoria;
			}
			set { categoria = value; }
		}
		
		public Collection<OnpMovimentoTaxa> Taxas {
			get {
				if (taxas == null) {
					OnpMovimentoTaxa filtroTaxa = new OnpMovimentoTaxa();
					filtroTaxa.CodReferencia = this.CodReferencia;
					filtroTaxa.SeqCategoria = this.SeqCategoria;
					filtroTaxa.SeqRoteiro = this.SeqRoteiro;
					filtroTaxa.SeqMatricula = this.SeqMatricula;
					taxas = filtroTaxa.SelectCollection();
				}
				
				return taxas;
			}
		}
		#endregion

		public OnpMovimentoCategoria(int seqCategoria, string codReferencia, int seqMatricula, int seqRoteiro) {
			this.seqCategoria = seqCategoria;
			this.codReferencia = codReferencia;
			this.seqMatricula = seqMatricula;
			this.seqRoteiro = seqRoteiro;
			this.Materialize();
		}
		public OnpMovimentoCategoria() { }
	}
}
