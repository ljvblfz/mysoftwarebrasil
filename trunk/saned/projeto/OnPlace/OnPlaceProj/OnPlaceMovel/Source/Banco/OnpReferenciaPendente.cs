using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Referencia_Pendente")]
	public sealed class OnpReferenciaPendente : PersistClass<OnpReferenciaPendente> {
		#region Atributos
		private int? seqMatricula;
		private int? seqFatura;
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
        [Column(ColumnName = "dat_Vencimento")]
		public DateTime? DatVencimento {
			get { return datVencimento; }
			set { datVencimento = value; }
		}
		#endregion

		public OnpReferenciaPendente(int? seqMatricula, int? seqFatura) {
			this.seqMatricula = seqMatricula;
			this.seqFatura = seqFatura;
			this.Materialize();
		}
		public OnpReferenciaPendente() { }
	}
}
