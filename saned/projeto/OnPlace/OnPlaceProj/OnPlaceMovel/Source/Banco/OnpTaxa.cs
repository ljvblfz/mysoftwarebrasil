using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Taxa")]
	public sealed class OnpTaxa : PersistClass<OnpTaxa> {
		#region Atributos e Propriedades
		private int? seqTaxa;
		[Column(ColumnName = "seq_Taxa", Pk = true)]
		public int? SeqTaxa {
			get { return seqTaxa; }
			set { seqTaxa = value; }
		}

		private string desTaxa;
		[Column(ColumnName = "des_Taxa")]
		public string DesTaxa {
			get { return desTaxa; }
			set { desTaxa = value; }
		}
		
		private Collection<OnpTaxaTarifa> tarifas;
		public Collection<OnpTaxaTarifa> Tarifas {
			get {
				if ( tarifas == null ) {
					OnpTaxaTarifa aux = new OnpTaxaTarifa();
					aux.SeqTaxa = this.SeqTaxa;
					tarifas = aux.SelectCollection();
				}
				
				return tarifas;
			}
		}
		#endregion // Atributos e Propriedades

		public OnpTaxa(int seqTaxa) {
			this.seqTaxa = seqTaxa;
			this.Materialize();
		}

		public OnpTaxa() {

		}

		/// <summary>
		/// Tarifa para a categoria em questao
		/// </summary>
		/// <param name="seqCategoria"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public OnpTaxaTarifa GetTarifa(int seqCategoria, DateTime data) {
			OnpTaxaTarifa result = null;
			
			foreach ( OnpTaxaTarifa tarifa in Tarifas )
				if ( tarifa.SeqCategoria.Value == seqCategoria && tarifa.DatInicio.Value <= data )
					if ( result == null || result.DatInicio.Value < tarifa.DatInicio.Value )
						result = tarifa;

			return result;
		}
	}
}
