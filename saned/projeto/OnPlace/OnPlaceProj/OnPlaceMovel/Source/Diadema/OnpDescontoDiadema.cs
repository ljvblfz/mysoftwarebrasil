using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Diadema {
    [Table(TableName = "onp_Desconto_Diadema")]
    public class OnpDescontoDiadema : PersistClass<OnpDescontoDiadema> {
		#region Atributos
		private int? seqDesconto;
		private string indTipoDesconto;
		private int? valLimiteInicial;
		private double? valValorDesconto;
		#endregion

		#region Getters ans Setters (Fields)
        [Column(ColumnName = "seq_Desconto", Pk = true)]
		public int? SeqDesconto {
			get { return seqDesconto; }
			set { seqDesconto = value; }
		}

        [Column(ColumnName = "ind_Tipo_Desconto")]
		public string IndTipoDesconto {
			get { return indTipoDesconto; }
			set { indTipoDesconto = value; }
		}
        [Column(ColumnName = "val_Limite_Inicial")]
		public int? ValLimiteInicial {
			get { return valLimiteInicial; }
			set { valLimiteInicial = value; }
		}
        [Column(ColumnName = "val_Valor_Desconto")]
		public double? ValValorDesconto {
			get { return valValorDesconto; }
			set { valValorDesconto = value; }
		}
		#endregion

		public OnpDescontoDiadema() {}

		public OnpDescontoDiadema(int seqDesconto) {
			this.seqDesconto = seqDesconto;
			if (!this.Materialize())
				this.seqDesconto = null;
		}
	}
}
