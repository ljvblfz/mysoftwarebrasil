using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
	/// <summary>
	/// Tabela de parametro do onplace
	/// </summary>
	[Table(TableName = "onp_parametro")]
	public class OnpParametro: PersistClass<OnpParametro> {
		#region Atributos e Propriedades
		private string desNome;
		[Column(ColumnName = "des_nome", Pk = true)]
		public string DesNome {
			get { return desNome; }
			set { desNome = value; }
		}

		private string desValor;
		[Column(ColumnName = "des_valor")]
		public string DesValor {
			get { return desValor; }
			set { desValor = value; }
		}
		#endregion // Atributos e Propriedades

		#region Construtores
		public OnpParametro() {
		}

		public OnpParametro(string desNome) {
			this.desNome = desNome;
			if (!Materialize())
				this.desNome = null;
		}
		#endregion // Construtores
	}
}
