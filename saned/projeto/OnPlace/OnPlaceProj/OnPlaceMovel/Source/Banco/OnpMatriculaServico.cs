using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Matricula_Servico")]
	public sealed class OnpMatriculaServico : PersistClass<OnpMatriculaServico> {
		#region Atributos
		private int? seqMatricula;
		private int? seqItem;
		private string indSolicitante;
		private int? seqServico;
		#endregion

		#region Getters ans Setters (Fields)
		[Column( ColumnName = "seq_Matricula", Pk = true )]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

        [Column(ColumnName = "seq_Item", Pk = true)]
		public int? SeqItem {
			get { return seqItem; }
			set { seqItem = value; }
		}
        [Column(ColumnName = "ind_Solicitante")]
		public string IndSolicitante {
			get { return indSolicitante; }
			set { indSolicitante = value; }
		}
        [Column(ColumnName = "seq_Servico")]
		public int? SeqServico {
			get { return seqServico; }
			set { seqServico = value; }
		}
		#endregion

		public OnpMatriculaServico(int seqMatricula, int seqItem) {
			this.seqMatricula = seqMatricula;
			this.seqItem = seqItem;
			this.Materialize();
		}
		public OnpMatriculaServico() { }
	}
}