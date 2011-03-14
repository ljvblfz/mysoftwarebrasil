using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Servico_Fatura")]
	public sealed class OnpServicoFatura : PersistClass<OnpServicoFatura> {
		#region Atributos
		private int? seqItemServico;
		private string codReferencia;
		private int? seqMatricula;
		private int? seqRoteiro;
		private string desServico;
		private int? seqPlano;
		private int? seqParcela;
		private double? valParcela;
		private string indCredito;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Item_Servico", Pk = true)]
		public int? SeqItemServico {
			get { return seqItemServico; }
			set { seqItemServico = value; }
		}

        [Column(ColumnName = "cod_Referencia", Pk = true)]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}

        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
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
        [Column(ColumnName = "seq_Plano")]
		public int? SeqPlano {
			get { return seqPlano; }
			set { seqPlano = value; }
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

		public OnpServicoFatura(int seqItemServico, string codReferencia, int seqMatricula, int seqRoteiro) {
			this.seqItemServico = seqItemServico;
			this.codReferencia = codReferencia;
			this.seqMatricula = seqMatricula;
			this.seqRoteiro = seqRoteiro;
			this.Materialize();
		}
		public OnpServicoFatura() { }
	}
}
