using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Tabelas_Carga")]
	public sealed class OnpTabelasCarga : PersistClass<OnpTabelasCarga> {
		#region Atributos
		private string nomTabela;
		private string indCarga;
		private string indDescarga;
		#endregion

		#region Getters and Setters (Fields) 
        [Column(ColumnName = "nom_Tabela", Pk = true)]
		public string NomTabela {
			get { return nomTabela; }
			set { nomTabela = value; }
		}

        [Column(ColumnName = "ind_Carga")]
		public string IndCarga {
			get { return indCarga; }
			set { indCarga = value; }
		}

        [Column(ColumnName = "ind_Descarga")]
		public string IndDescarga {
			get { return indDescarga; }
			set { indDescarga = value; }
		}
		#endregion

		public OnpTabelasCarga() {
		}

		public OnpTabelasCarga(string nomTabela) {
			this.nomTabela = nomTabela;
			this.Materialize();
		}
	}
}
