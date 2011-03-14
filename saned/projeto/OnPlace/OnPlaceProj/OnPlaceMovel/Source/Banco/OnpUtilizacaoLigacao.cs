using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Utilizacao_Ligacao")]
	public class OnpUtilizacaoLigacao : PersistClass<OnpUtilizacaoLigacao> {
		#region Atributos e propriedades
		private int? seqUtilizacaoLigacao;
        [Column(ColumnName = "seq_Utilizacao_Ligacao", Pk = true)]
		public int? SeqUtilizacaoLigacao {
			get { return seqUtilizacaoLigacao; }
			set { seqUtilizacaoLigacao = value; }
		}

		private string desUtilizacaoLigacao;
        [Column(ColumnName = "des_Utilizacao_Ligacao")]
		public string DesUtilizacaoLigacao {
			get { return desUtilizacaoLigacao; }
			set { desUtilizacaoLigacao = value; }
		}
		#endregion

		public OnpUtilizacaoLigacao() {
		}

		public OnpUtilizacaoLigacao(int seqUtilizacaoLigacao) {
			this.seqUtilizacaoLigacao = seqUtilizacaoLigacao;
			
			if (!Select())
				this.seqUtilizacaoLigacao = null;
		}
	}
}
