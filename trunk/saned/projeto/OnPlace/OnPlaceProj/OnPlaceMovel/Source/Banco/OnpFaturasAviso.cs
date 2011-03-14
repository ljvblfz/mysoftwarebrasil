using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table( TableName = "onp_Faturas_Aviso")]
	public sealed class OnpFaturasAviso : PersistClass<OnpFaturasAviso> {
		#region Atributos
		private int? seqMatricula;
		private int? seqFatura;
		private double? valValorFatura;
		private string codReferencia;
		private DateTime? datVencimento;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}
        [Column(ColumnName = "seq_Fatura", Pk = true)]
		public int? SeqFatura {
			get { return seqFatura; }
			set { seqFatura = value; }
		}
        [Column(ColumnName = "val_Valor_Fatura")]
		public double? ValValorFatura {
			get { return valValorFatura; }
			set { valValorFatura = value; }
		}
        [Column(ColumnName = "cod_Referencia")]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}
        [Column(ColumnName = "dat_Vencimento")]
		public DateTime? DatVencimento {
			get { return datVencimento; }
			set { datVencimento = value; }
		}
		#endregion

		public OnpFaturasAviso(int? seqMatricula, int? seqFatura) {
			this.seqMatricula = seqMatricula;
			this.seqFatura = seqFatura;
			this.Materialize();
		}

		public OnpFaturasAviso() { }
	}
}
