using System;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Taxa_Tarifa_Faixa")]
	public class OnpTaxaTarifaFaixa : PersistClass<OnpTaxaTarifaFaixa> {
		#region Atributos
		private int? seqCategoria;
		private int? seqTaxaTarifa;
		private int? seqTaxa;
		private int? seqTaxaTarifaFaixa;
		private int? valLimiteConsumo;
		private double? valValorTarifa;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Categoria", Pk = true)]
		public int? SeqCategoria {
			get { return seqCategoria; }
			set { seqCategoria = value; }
		}

        [Column(ColumnName = "seq_Taxa_Tarifa", Pk = true)]
		public int? SeqTaxaTarifa {
			get { return seqTaxaTarifa; }
			set { seqTaxaTarifa = value; }
		}

        [Column(ColumnName = "seq_Taxa", Pk = true)]
		public int? SeqTaxa {
			get { return seqTaxa; }
			set { seqTaxa = value; }
		}

        [Column(ColumnName = "seq_Taxa_Tarifa_Faixa", Pk = true)]
		public int? SeqTaxaTarifaFaixa {
			get { return seqTaxaTarifaFaixa; }
			set { seqTaxaTarifaFaixa = value; }
		}
        [Column(ColumnName = "val_Limite_Consumo")]
		public int? ValLimiteConsumo {
			get { return valLimiteConsumo; }
			set { valLimiteConsumo = value; }
		}
        [Column(ColumnName = "val_Valor_Tarifa")]
		public double? ValValorTarifa {
			get { return valValorTarifa; }
			set { valValorTarifa = value; }
		}
		#endregion

		public OnpTaxaTarifaFaixa(int seqCategoria, int seqTaxaTarifa, int seqTaxa, int seqTaxaTarifaFaixa) {
			this.seqCategoria = seqCategoria;
			this.seqTaxaTarifa = seqTaxaTarifa;
			this.seqTaxa = seqTaxa;
			this.seqTaxaTarifaFaixa = seqTaxaTarifaFaixa;
			this.Materialize();
		}
		public OnpTaxaTarifaFaixa() { }
	}
}
