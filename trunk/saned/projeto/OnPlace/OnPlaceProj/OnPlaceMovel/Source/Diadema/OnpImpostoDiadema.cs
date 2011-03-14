using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Diadema {
    [Table(TableName = "onp_Imposto_Diadema")]
	public class OnpImpostoDiadema: PersistClass<OnpImpostoDiadema> {
		#region Atributos e Propriedades
		private string codImposto;
        [Column(ColumnName = "cod_Imposto", Pk = true)]
		public string CodImposto {
			get { return codImposto; }
			set { codImposto = value; }
		}

		private double? valPorcentagem;
        [Column(ColumnName = "val_Porcentagem")]
		public double? ValPorcentagem {
			get { return valPorcentagem; }
			set { valPorcentagem = value; }
		}
		#endregion

		public OnpImpostoDiadema() { }

		public OnpImpostoDiadema(string codImposto) {
			this.codImposto = codImposto;
			if (!Materialize())
				this.codImposto = null;
		}
	}
}
