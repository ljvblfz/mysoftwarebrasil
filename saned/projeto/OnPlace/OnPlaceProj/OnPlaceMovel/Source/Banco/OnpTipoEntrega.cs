using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
	[Table(TableName = "onp_Tipo_Entrega")]
	public sealed class OnpTipoEntrega: PersistClass<OnpTipoEntrega> {
		#region Atributos e Propriedades
		private int? seqTipoEntrega;
		[Column(ColumnName = "seq_Tipo_Entrega", Pk = true)]
		public int? SeqTipoEntrega {
			get { return seqTipoEntrega; }
			set { seqTipoEntrega = value; }
		}

		private string desTipoEntrega;
		[Column(ColumnName = "des_Tipo_Entrega")]
		public string DesTipoEntrega {
			get { return desTipoEntrega; }
			set { desTipoEntrega = value; }
		}
		#endregion // Atributos e Propriedades

		public OnpTipoEntrega() { }

		public OnpTipoEntrega(int seqTipoEntrega) {
			this.seqTipoEntrega = seqTipoEntrega;
			this.Materialize();
		}

		public override string ToString() {
			return seqTipoEntrega.ToString() + " - " + desTipoEntrega;
		}
	}
}
