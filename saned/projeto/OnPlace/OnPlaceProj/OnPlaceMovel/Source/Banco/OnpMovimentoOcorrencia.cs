using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Movimento_Ocorrencia")]
	public sealed class OnpMovimentoOcorrencia : PersistClass<OnpMovimentoOcorrencia> {
		#region Atributos
		private string codReferencia;
		private int? seqMatricula;
		private int? codOcorrencia;
		private int? seqRoteiro;
		private int? seqSequencial;

		private OnpOcorrencia ocorrencia;
		#endregion

		#region Getters ans Setters (Fields)

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

        [Column(ColumnName = "cod_Ocorrencia", Pk = true)]
		public int? CodOcorrencia {
			get { return codOcorrencia; }
			set { codOcorrencia = value; }
		}

        [Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}

        [Column(ColumnName = "seq_Sequencial", Pk = true)]
		public int? SeqSequencial {
			get { return seqSequencial; }
			set { seqSequencial = value; }
		}

		public OnpOcorrencia Ocorrencia {
			get {
				if (ocorrencia == null) {
					ocorrencia = new OnpOcorrencia();
					ocorrencia.CodOcorrencia = this.CodOcorrencia;
					if (!ocorrencia.Select())
						ocorrencia = null;
				}

				return ocorrencia;
			}
		}
		#endregion

		public OnpMovimentoOcorrencia() { }
	}
}