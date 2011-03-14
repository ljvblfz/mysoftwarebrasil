using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Taxa_Tarifa")]
	public sealed class OnpTaxaTarifa : PersistClass<OnpTaxaTarifa> {
		#region Faixa para calculo da tarifa
		public class FaixaTarifa {
			private int valLimiteConsumo;
			private double valValorTarifa;
			public int ValLimiteConsumo { get { return valLimiteConsumo; } set { valLimiteConsumo = value; } }
			public double ValValorTarifa { get { return valValorTarifa; } set { valValorTarifa = value; } }
		}
		#endregion

		#region Tipo de calculo da tarifa
		public enum TipoTaxa {
			Fixo = 'F',
			Calculado = 'C',
			Percentual = 'P'
		}
		public static TipoTaxa[] TiposTaxa = { TipoTaxa.Fixo, TipoTaxa.Calculado, TipoTaxa.Percentual };
		#endregion

		#region Atributos
		private int? seqCategoria;
		private int? seqTaxaTarifa;
		private int? seqTaxa;
		private int? seqTaxaBase;
		private DateTime? datInicio;
		private string indTipoTaxa;
		private string indEscalonada;
		private string indDiasConsumo;
		private string indMinimo;
		private string indProporcional;
		private double? valValorTarifa;
		private double? valPercentual;

		private Collection<OnpTaxaTarifaFaixa> faixas;
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
        [Column(ColumnName = "seq_Taxa_Base")]
		public int? SeqTaxaBase {
			get { return seqTaxaBase; }
			set { seqTaxaBase = value; }
		}
        [Column(ColumnName = "dat_Inicio")]
		public DateTime? DatInicio {
			get { return datInicio; }
			set { datInicio = value; }
		}
        [Column(ColumnName = "ind_Tipo_Taxa")]
		public string IndTipoTaxa {
			get { return indTipoTaxa; }
			set { indTipoTaxa = value; }
		}
        [Column(ColumnName = "ind_Escalonada")]
		public string IndEscalonada {
			get { return indEscalonada; }
			set { indEscalonada = value; }
		}
        [Column(ColumnName = "ind_Dias_Consumo")]
		public string IndDiasConsumo {
			get { return indDiasConsumo; }
			set { indDiasConsumo = value; }
		}
        [Column(ColumnName = "ind_Minimo")]
		public string IndMinimo {
			get { return indMinimo; }
			set { indMinimo = value; }
		}
        [Column(ColumnName = "ind_Proporcional")]
		public string IndProporcional {
			get { return indProporcional; }
			set { indProporcional = value; }
		}
        [Column(ColumnName = "val_Valor_Tarifa")]
		public double? ValValorTarifa {
			get { return valValorTarifa; }
			set { valValorTarifa = value; }
		}
        [Column(ColumnName = "val_Percentual")]
		public double? ValPercentual {
			get { return valPercentual; }
			set { valPercentual = value; }
		}

		public Collection<OnpTaxaTarifaFaixa> Faixas {
			get {
				if ( faixas == null ) {
					OnpTaxaTarifaFaixa aux = new OnpTaxaTarifaFaixa();
					aux.SeqTaxa = this.SeqTaxa;
					aux.SeqCategoria = this.SeqCategoria;
					aux.SeqTaxaTarifa = this.SeqTaxaTarifa;
					faixas = aux.SelectCollection();
				}

				return faixas;
			}
		}

		public TipoTaxa Tipo {
			get { return (TipoTaxa)IndTipoTaxa[ 0 ]; }
			set { IndTipoTaxa = ( (char)value ).ToString(); }
		}
		#endregion

		public OnpTaxaTarifa(int seqCategoria, int seqTaxaTarifa, int seqTaxa) {
			this.seqCategoria = seqCategoria;
			this.seqTaxaTarifa = seqTaxaTarifa;
			this.seqTaxa = seqTaxa;
			this.Materialize();
		}
		public OnpTaxaTarifa() { }

		/// <summary>
		/// Consumo minimo da tarifa
		/// </summary>
		/// <returns>Retorna o valor do consumo minimo</returns>
		public int ConsumoMinimo() {
			int result = 0;
			
			// Caso tenha consumo minimo
			if (IndMinimo.Equals("S")) {
				OnpTaxaTarifaFaixa faixaMinimo = null;
				
				foreach (OnpTaxaTarifaFaixa faixa in Faixas) {
					if (faixaMinimo == null || faixaMinimo.ValLimiteConsumo.Value > faixa.ValLimiteConsumo.Value) {
						faixaMinimo = faixa;
						result = faixaMinimo.ValLimiteConsumo.Value;
					}
				}
			}
			
			return result;
		}

		/// <summary>
		/// Valor minimo da tarifa
		/// </summary>
		/// <returns>Retorna o valor minimo a ser cobrado para esta tarifa</returns>
		public double ValorMinimo() {
			double result = 0;
			
			// Caso tenha consumo minimo
			if (IndMinimo.Equals("S")) {
				OnpTaxaTarifaFaixa faixaMinimo = null;
				
				foreach (OnpTaxaTarifaFaixa faixa in Faixas) {
					if (faixaMinimo == null || faixaMinimo.ValLimiteConsumo.Value > faixa.ValLimiteConsumo.Value) {
						faixaMinimo = faixa;
						result = faixaMinimo.ValValorTarifa.Value;
					}
				}
			}
			
			return result;
		}

		public Collection<FaixaTarifa> CopyFaixas() {
			// Monta a lista ordenada
			SortedList<int, FaixaTarifa> faixasOrdenado = new SortedList<int, FaixaTarifa>();
			
			// Monta o array
			foreach ( OnpTaxaTarifaFaixa faixa in Faixas ) {
				FaixaTarifa item = new FaixaTarifa();
				item.ValLimiteConsumo = faixa.ValLimiteConsumo.Value;
				item.ValValorTarifa = faixa.ValValorTarifa.Value;
				faixasOrdenado.Add( item.ValLimiteConsumo, item );
			}
			
			return new Collection<FaixaTarifa>( faixasOrdenado.Values );
		}

	}
}
