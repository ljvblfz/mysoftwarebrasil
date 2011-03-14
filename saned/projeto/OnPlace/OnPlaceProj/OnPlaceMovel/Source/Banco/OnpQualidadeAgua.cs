using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Qualidade_Agua")]
	public sealed class OnpQualidadeAgua : PersistClass<OnpQualidadeAgua> {
		#region Atributos
		private int? seqZonaAbastecimento;
		private DateTime? datReferencia;
		private int? seqParametro;
		private string desParametro;
		private int? valPrevistas;
		private int? valRealizadas;
		private int? valForaLimite;
		private double? valMedia;
		#endregion

		#region Getters ans Setters (Fields)
        [Column(ColumnName = "seq_Zona_Abastecimento", Pk = true)]
		public int? SeqZonaAbastecimento {
			get { return seqZonaAbastecimento; }
			set { seqZonaAbastecimento = value; }
		}

        [Column(ColumnName = "dat_Referencia", Pk = true)]
		public DateTime? DatReferencia {
			get { return datReferencia; }
			set { datReferencia = value; }
		}

        [Column(ColumnName = "seq_Parametro", Pk = true)]
		public int? SeqParametro {
			get { return seqParametro; }
			set { seqParametro = value; }
		}

        [Column(ColumnName = "des_Parametro")]
		public string DesParametro {
			get { return desParametro; }
			set { desParametro = value; }
		}

        [Column(ColumnName = "val_Previstas")]
		public int? ValPrevistas {
			get { return valPrevistas; }
			set { valPrevistas = value; }
		}

        [Column(ColumnName = "val_Realizadas")]
		public int? ValRealizadas {
			get { return valRealizadas; }
			set { valRealizadas = value; }
		}

        [Column(ColumnName = "val_Fora_Limite")]
		public int? ValForaLimite {
			get { return valForaLimite; }
			set { valForaLimite = value; }
		}

        [Column(ColumnName = "val_Media")]
		public double? ValMedia {
			get { return valMedia; }
			set { valMedia = value; }
		}
		#endregion

		public OnpQualidadeAgua() { }

		public OnpQualidadeAgua(int seqZonaAbastecimento, DateTime datReferencia, int seqParametro) {
			this.seqZonaAbastecimento = seqZonaAbastecimento;
			this.datReferencia = datReferencia;
			this.seqParametro = seqParametro;
			Materialize();
		}
	}
}
