using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Diadema {
    [Table(TableName = "onp_Fatura_Imposto_Diadema")]
	public class OnpFaturaImpostoDiadema: PersistClass<OnpFaturaImpostoDiadema> {
		#region Atributos e Propriedades
		private int? seqFatura;
        [Column(ColumnName = "seq_Fatura", Pk = true)]
		public int? SeqFatura {
			get { return seqFatura; }
			set { seqFatura = value; }
		}

		private int? seqMatricula;
        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

		private string codReferencia;
        [Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}

		private int? seqRoteiro;
        [Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}

		private string codImposto;
        [Column(ColumnName = "cod_Imposto", Pk = true)]
        public string CodImposto {
			get { return codImposto; }
			set { codImposto = value; }
		}

		private double? valValorCalculado;
        [Column(ColumnName = "val_Valor_Calculado")]
		public double? ValValorCalculado {
			get { return valValorCalculado; }
			set { valValorCalculado = value; }
		}
		#endregion

		public OnpFaturaImpostoDiadema() { }

		public OnpFaturaImpostoDiadema(int seqFatura, int seqMatricula, string codReferencia, int seqRoteiro, string codImposto) {
			this.SeqFatura = seqFatura;
			this.SeqMatricula = seqMatricula;
			this.CodReferencia = codReferencia;
			this.SeqRoteiro = seqRoteiro;
			this.CodImposto = codImposto;

			if (!Materialize()) {
				this.SeqFatura = null;
				this.SeqMatricula = null;
				this.CodReferencia = null;
				this.SeqRoteiro = null;
				this.CodImposto = null;
			}
		}

		public static OnpFaturaImpostoDiadema Materialize(int seqFatura, int seqMatricula, string codReferencia, int seqRoteiro, string codImposto) {
			OnpFaturaImpostoDiadema retorno = new OnpFaturaImpostoDiadema();

			retorno.SeqFatura = seqFatura;
			retorno.SeqMatricula = seqMatricula;
			retorno.CodReferencia = codReferencia;
			retorno.SeqRoteiro = seqRoteiro;
			retorno.CodImposto = codImposto;

			if (!retorno.Materialize())
				return null;

			return retorno;
		}
	}
}
