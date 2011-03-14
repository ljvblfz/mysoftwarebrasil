using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Historico")]
    public sealed class OnpHistorico : PersistClass<OnpHistorico> {
        #region Atributos
        private int? seqMatricula;
        private string codReferencia;
        private int? valConsumo;
		private string codOcorrencia;
        #endregion

        #region Getters ans Setters (Fields)

        [Column( ColumnName = "seq_Matricula", Pk = true)]
        public int? SeqMatricula {
            get { return seqMatricula; }
            set { seqMatricula = value; }
        }

        [Column( ColumnName = "cod_Referencia", Pk = true)]
        public string CodReferencia {
            get { return codReferencia; }
            set { codReferencia = value; }
        }
		[Column(ColumnName = "val_Consumo")]
		public int? ValConsumo {
			get { return valConsumo; }
			set { valConsumo = value; }
		}
		[Column(ColumnName = "cod_ocorrencia")]
		public string CodOcorrencia {
			get { return codOcorrencia; }
			set { codOcorrencia = value; }
		}
		#endregion

        public OnpHistorico(int seqMatricula, string codReferencia) {
            this.seqMatricula = seqMatricula;
            this.codReferencia = codReferencia;
            this.Materialize();
        }

        public OnpHistorico() { }

        public override string ToString() {
            string mes, ano;
            getMesAno(codReferencia, out mes, out ano);
            return mes + "/" + ano + "   -   " + valConsumo.ToString() + "   -   " + codOcorrencia;
        }

        /// <summary>
        /// Extrai o mes e o ano do código de refêrencia passado
        /// </summary>
        /// <param name="codReferencia"></param>
        /// <param name="mes"></param>
        /// <param name="ano"></param>
        private static void getMesAno(string codReferencia, out string mes, out string ano) {
            ano = string.Empty;
            mes = string.Empty;
            if (!string.IsNullOrEmpty(codReferencia)) {
                ano = codReferencia.Substring(0, 4);
                if (codReferencia.Substring(4, 1).Equals("."))
                    mes = codReferencia.Substring(5).Trim();
                else
                    mes = codReferencia.Substring(4).Trim();
            }
        }

    }
}
