using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Localizacao_Hidrometro")]
	public sealed class OnpLocalizacaoHidrometro : PersistClass<OnpLocalizacaoHidrometro> {
		#region Atributos
		private int? seqLocal;
		private string desLocal;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Local", Pk = true)]
		public int? SeqLocal {
			get { return seqLocal; }
			set { seqLocal = value; }
		}
        [Column(ColumnName = "des_Local" )]
		public string DesLocal {
			get { return desLocal; }
			set { desLocal = value; }
		}
		#endregion

		public OnpLocalizacaoHidrometro(int codLocal) {
			this.seqLocal = codLocal;
			this.Materialize();
		}
		public OnpLocalizacaoHidrometro() { }
	}
}
