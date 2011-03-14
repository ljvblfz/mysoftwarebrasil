using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Agente")]
	public sealed class OnpAgente : PersistClass<OnpAgente> {
		#region Atributos
		private int? codAgente;
		private string nomAgente;
		private string desSenha;
		#endregion

		#region Getters ans Setters (Fields)

		[Column(ColumnName="cod_agente", Pk=true )]
		public int? CodAgente {
			get { return codAgente; }
			set { codAgente = value; }
		}
		[Column(ColumnName="nom_agente")]
		public string NomAgente {
			get { return nomAgente; }
			set { nomAgente = value; }
		}
		[Column(ColumnName="des_senha")]
		public string DesSenha {
			get { return desSenha; }
			set { desSenha = value; }
		}
		#endregion

		public OnpAgente(int? codAgente) {
			this.codAgente = codAgente;
			this.Materialize();
		}
		public OnpAgente() { }
	}
}
