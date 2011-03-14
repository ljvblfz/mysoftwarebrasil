using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Mensagem_Movimento")]
	public sealed class OnpMensagemMovimento : PersistClass<OnpMensagemMovimento> {
		#region Atributos
		private int? seqMensagemMovimento;
		private string desMensagemMovimento;
		private DateTime? datInicio;
		private DateTime? datFinal;
		private int? seqTipoDocumento;
		private int? seqMatricula;
		private int? seqRoteiro;
		private int? seqGrupoFatura;
		#endregion

		#region Getters ans Setters (Fields)

		[Column( ColumnName = "seq_Mensagem_Movimento",  Pk = true )]
		public int? SeqMensagemMovimento {
			get { return seqMensagemMovimento; }
			set { seqMensagemMovimento = value; }
		}
        [Column(ColumnName = "des_Mensagem_Movimento")]
		public string DesMensagemMovimento {
			get { return desMensagemMovimento; }
			set { desMensagemMovimento = value; }
		}
        [Column(ColumnName = "dat_Inicio")]
		public DateTime? DatInicio {
			get { return datInicio; }
			set { datInicio = value; }
		}
        [Column(ColumnName = "dat_Final")]
		public DateTime? DatFinal {
			get { return datFinal; }
			set { datFinal = value; }
		}
        [Column(ColumnName = "seq_Tipo_Documento")]
		public int? SeqTipoDocumento {
			get { return seqTipoDocumento; }
			set { seqTipoDocumento = value; }
		}
        [Column(ColumnName = "seq_Matricula")]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}
        [Column(ColumnName = "seq_Roteiro")]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}
        [Column(ColumnName = "seq_Grupo_Fatura")]
		public int? SeqGrupoFatura {
			get { return seqGrupoFatura; }
			set { seqGrupoFatura = value; }
		}
		#endregion

		public OnpMensagemMovimento(int seqMensagemMovimento) {
			this.seqMensagemMovimento = seqMensagemMovimento;
			this.Materialize();
		}
		public OnpMensagemMovimento() { }
	}
}
