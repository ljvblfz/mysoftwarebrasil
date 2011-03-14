using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Matricula_Alteracao")]
	public sealed class OnpMatriculaAlteracao : PersistClass<OnpMatriculaAlteracao> {
		#region Atributos
		private int? seqMatricula;
		private string indDadoAlterado;
		private int? seqItem;
		private string desConteudoAnterior;
		private string desConteudoNovo;
		#endregion

		#region Getters ans Setters (Fields)
		[Column( ColumnName = "seq_Matricula", Pk = true )]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}
		[Column( ColumnName = "ind_Dado_Alterado", Pk = true )]
		public string IndDadoAlterado {
			get { return indDadoAlterado; }
			set { indDadoAlterado = value; }
		}
        [Column(ColumnName = "seq_Item", Pk = true)]
		public int? SeqItem {
			get { return seqItem; }
			set { seqItem = value; }
		}
        [Column(ColumnName = "des_Conteudo_Anterior")]
		public string DesConteudoAnterior {
			get { return desConteudoAnterior; }
			set { desConteudoAnterior = value; }
		}
        [Column(ColumnName = "des_Conteudo_Novo")]
		public string DesConteudoNovo {
			get { return desConteudoNovo; }
			set { desConteudoNovo = value; }
		}
		#endregion

		public OnpMatriculaAlteracao() { }
		
		public OnpMatriculaAlteracao(int seqMatricula, string indDadoAlterado, int seqItem) {
			this.indDadoAlterado = indDadoAlterado;
			this.seqMatricula = seqMatricula;
			this.seqItem = seqItem;
			this.Materialize();
		}
	}
}
