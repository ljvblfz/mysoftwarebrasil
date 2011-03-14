using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Grupo_Fatura")]
	public sealed class OnpGrupoFatura : PersistClass<OnpGrupoFatura> {
		#region Atributos
		private int? seqGrupoFatura;
		private string indTipoVencimento;
		private int? numDias;
		private string desDiasVencimento;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Grupo_Fatura", Pk = true)]
		public int? SeqGrupoFatura {
			get { return seqGrupoFatura; }
			set { seqGrupoFatura = value; }
		}
        [Column(ColumnName = "ind_Tipo_Vencimento")]
		public string IndTipoVencimento {
			get { return indTipoVencimento; }
			set { indTipoVencimento = value; }
		}
		[Column(ColumnName = "num_Dias")]
		public int? NumDias {
			get { return numDias; }
			set { numDias = value; }
		}
        [Column(ColumnName = "des_Dias_Vencimento")]
		public string DesDiasVencimento {
			get { return desDiasVencimento; }
			set { desDiasVencimento = value; }
		}
		#endregion

		public OnpGrupoFatura(int seqGrupoFatura) {
			this.seqGrupoFatura = seqGrupoFatura;
			this.Materialize();
		}
		public OnpGrupoFatura() { }
	}
}
