using System;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Fatura_Servico")]
	public sealed class OnpFaturaServico : PersistClass<OnpFaturaServico> {
		#region Atributos
		private int? seqFatura;
		private int? seqMatricula;
		private string codReferencia;
		private int? seqRoteiro;
		private int? seqItemServico;
		private string desServico;
		private int? seqParcela;
		private double? valParcela;
		private string indCredito;
		#endregion

		#region Getters ans Setters (Fields)
        [Column(ColumnName = "seq_Fatura", Pk = true)]
		public int? SeqFatura {
			get { return seqFatura; }
			set { seqFatura = value; }
		}
        [Column(ColumnName = "seq_Item_Servico", Pk = true)]
		public int? SeqItemServico {
			get { return seqItemServico; }
			set { seqItemServico = value; }
		}
        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}
        [Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}
        [Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}
        [Column(ColumnName = "des_Servico")]
		public string DesServico {
			get { return desServico; }
			set { desServico = value; }
		}
        [Column(ColumnName = "seq_Parcela")]
		public int? SeqParcela {
			get { return seqParcela; }
			set { seqParcela = value; }
		}
        [Column(ColumnName = "val_Parcela")]
		public double? ValParcela {
			get { return valParcela; }
			set { valParcela = value; }
		}
        [Column(ColumnName = "ind_Credito")]
		public string IndCredito {
			get { return indCredito; }
			set { indCredito = value; }
		}
		#endregion

		public OnpFaturaServico() { }

		public OnpFaturaServico(int? seqFatura, int? seqItemServico) {
			this.seqFatura = seqFatura;
			this.seqItemServico = seqItemServico;
			this.Materialize();
		}
	}
}
