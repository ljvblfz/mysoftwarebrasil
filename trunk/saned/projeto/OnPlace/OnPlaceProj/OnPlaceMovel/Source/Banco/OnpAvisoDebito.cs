using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_aviso_debito")]
	public sealed class OnpAvisoDebito: PersistClass<OnpAvisoDebito> {
		#region Atributos e Propriedades 
        private int? seqMatricula;
        [Column(ColumnName = "seq_Matricula", Pk = true)]
		public int? SeqMatricula {
			get { return seqMatricula; }
			set { seqMatricula = value; }
		}

        private DateTime? datEmissao;
        [Column(ColumnName = "dat_Emissao")]
		public DateTime? DatEmissao {
			get { return datEmissao; }
			set { datEmissao = value; }
		}

        private string indDocumento;
        [Column(ColumnName = "ind_Documento")]
		public string IndDocumento {
			get { return indDocumento; }
			set { indDocumento = value; }
		}

        private string indPagavel;
        [Column(ColumnName = "ind_Pagavel")]
		public string IndPagavel {
			get { return indPagavel; }
			set { indPagavel = value; }
		}

        private int? valQuantidadeDebito;
        [Column(ColumnName = "val_Quantidade_Debito")]
		public int? ValQuantidadeDebito {
			get { return valQuantidadeDebito; }
			set { valQuantidadeDebito = value; }
		}

        private int? valImpressoes;
        [Column(ColumnName = "val_Impressoes")]
		public int? ValImpressoes {
			get { return valImpressoes; }
			set { valImpressoes = value; }
		}

        private string indProtocolado;
        [Column(ColumnName = "ind_Protocolado")]
		public string IndProtocolado {
			get { return indProtocolado; }
			set { indProtocolado = value; }
		}

        private int? seqFatura;
        [Column(ColumnName = "seq_fatura")]
        public int? SeqFatura {
            get { return seqFatura; }
            set { seqFatura = value; }
        }

        private Collection<OnpFaturasAviso> faturasAviso;
        public Collection<OnpFaturasAviso> FaturasAviso {
            get {
                if (faturasAviso == null) {
                    OnpFaturasAviso aux = new OnpFaturasAviso();
                    aux.SeqMatricula = this.SeqMatricula.Value;
                    faturasAviso = aux.SelectCollection();
                }
                
                return faturasAviso;
            }
        }

        private OnpFatura fatura;
        public OnpFatura Fatura {
            get {
                if (fatura == null) {
                    fatura = new OnpFatura();
                    fatura.SeqFatura = seqFatura;
                    fatura.Select();
                }
                
                return fatura;
            }
        }
        #endregion // Atributos e Propriedades

        public OnpAvisoDebito() {
        }

		public OnpAvisoDebito(int seqMatricula) {
			this.seqMatricula = seqMatricula;
			this.Materialize();
		}
	}
}
