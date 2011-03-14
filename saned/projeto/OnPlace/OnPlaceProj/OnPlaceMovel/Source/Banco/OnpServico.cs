using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Servico")]
	public sealed class OnpServico : PersistClass<OnpServico> {
		#region Atributos
		private int? seqServico;
		private string desServico;
		private double? valServico;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Servico", Pk = true)]
		public int? SeqServico {
			get { return seqServico; }
			set { seqServico = value; }
		}
        [Column(ColumnName = "des_Servico")]
		public string DesServico {
			get { return desServico; }
			set { desServico = value; }
		}
        [Column(ColumnName = "val_Servico")]
		public double? ValServico {
			get { return valServico; }
			set { valServico = value; }
		}
		#endregion

		public OnpServico(int seqServico) {
			this.seqServico = seqServico;
			this.Materialize();
		}
		public OnpServico() { }
	}
}
