using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Ocorrencia")]
    public sealed class OnpOcorrencia : PersistClass<OnpOcorrencia> {
		#region Formas de calculo (indConsumo)
		public enum CalculoConsumo {
			LeituraInformada = 0,
			LeituraAnteriorMaisMedia = 1,
			LeituraAnteriorMaisMinimo = 2,
			RepeteLeituraCobraMinimo = 3,
			RepeteLeituraCobraMedia = 4,
			LeituraInformadaCobraMedia = 5,
			LeituraInformadaCobraMinimo = 6,
			SeMediaZeroCobraMinimoSenaoRetem = 7,
			NaoGeraFatura = 8,
			NaoTemLeituraCobraMinimo = 9,
			NaoTemLeituraCobraMedia = 10
		}
		#endregion

		#region Atributos
		private int? codOcorrencia;
        [Column(ColumnName = "cod_Ocorrencia", Pk = true)]
		public int? CodOcorrencia {
			get { return codOcorrencia; }
			set { codOcorrencia = value; }
		}
		
		private string desOcorrencia;
		[Column(ColumnName = "des_Ocorrencia")]
		public string DesOcorrencia {
			get { return desOcorrencia; }
			set { desOcorrencia = value; }
		}
		
		private string desMensagem;
		[Column(ColumnName = "des_Mensagem")]
		public string DesMensagem {
			get { return desMensagem; }
			set { desMensagem = value; }
		}
		
		private string indGrupo;
		[Column(ColumnName = "ind_Grupo")]
		public string IndGrupo {
			get { return indGrupo; }
			set { indGrupo = value; }
		}
		
		private string indLeitura;
		[Column(ColumnName = "ind_Leitura")]
		public string IndLeitura {
			get { return indLeitura; }
			set { indLeitura = value; }
		}
		
		private string indConsumo;
		[Column(ColumnName = "ind_Consumo")]
		public string IndConsumo {
			get { return indConsumo; }
			set { indConsumo = value; }
		}
		
		private string indEmite;
        [Column(ColumnName = "ind_Emite")]
		public string IndEmite {
			get { return indEmite; }
			set { indEmite = value; }
		}

		public CalculoConsumo TipoCalculoConsumo {
			get { return (CalculoConsumo)int.Parse(IndConsumo); }
		}
		#endregion

		public OnpOcorrencia() { }

		public OnpOcorrencia(int codOcorrencia) {
			this.codOcorrencia = codOcorrencia;
			this.Materialize();
		}

		#region Metodos Publicos
		public override string ToString() {
			return codOcorrencia + " - " + desOcorrencia;
		}

		public override bool Equals(object obj) {
			OnpOcorrencia o = obj as OnpOcorrencia;
			if (o != null)
				return this.codOcorrencia.Value == o.codOcorrencia.Value;
			else
				return false;
		}

		public override int GetHashCode() {
			return codOcorrencia.Value;
		}
		#endregion // Metodos Publicos
	}
}
