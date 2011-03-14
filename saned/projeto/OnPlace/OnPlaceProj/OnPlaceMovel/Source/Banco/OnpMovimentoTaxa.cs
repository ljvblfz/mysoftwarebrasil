using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Movimento_Taxa")]
	public sealed class OnpMovimentoTaxa : PersistClass<OnpMovimentoTaxa> {
		#region Atributos
		private int? seqTaxa;
		private int? seqCategoria;
		private string codReferencia;
		private int? seqMatricula;
		private int? seqRoteiro;
		private int? valEconomias;
		private int? valConsumoFixo;
		private int? valConsumoEstimado;
		private string indSituacao;

		private OnpTaxa taxa;
		#endregion

		#region Getters ans Setters (Fields)

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
        [Column(ColumnName = "val_Economias")]
		public int? ValEconomias {
			get { return valEconomias; }
			set { valEconomias = value; }
		}
        [Column(ColumnName = "val_Consumo_Fixo")]
		public int? ValConsumoFixo {
			get { return valConsumoFixo; }
			set { valConsumoFixo = value; }
		}
        [Column(ColumnName = "val_Consumo_Estimado")]
		public int? ValConsumoEstimado {
			get { return valConsumoEstimado; }
			set { valConsumoEstimado = value; }
		}
        [Column(ColumnName = "ind_Situacao")]
		public string IndSituacao {
			get { return indSituacao; }
			set { indSituacao = value; }
		}

		public OnpTaxa Taxa {
			get {
				if ( taxa == null ) 
					taxa = new OnpTaxa( this.seqTaxa.Value );
				return taxa;
			}
			set { taxa = value; }
		}
		#endregion

		public OnpMovimentoTaxa(int seqTaxa, int seqCategoria, string codReferencia, int seqMatricula, int seqRoteiro) {
			this.seqTaxa = seqTaxa;
			this.seqCategoria = seqCategoria;
			this.codReferencia = codReferencia;
			this.seqMatricula = seqMatricula;
			this.seqRoteiro = seqRoteiro;
			this.Materialize();
		}
		public OnpMovimentoTaxa() { }

		public OnpTaxaTarifa GetTarifa(DateTime data) {
			return Taxa.GetTarifa( SeqCategoria.Value, data );
		}
	}
}
