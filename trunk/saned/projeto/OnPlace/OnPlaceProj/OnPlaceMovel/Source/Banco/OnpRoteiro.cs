using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Roteiro")]
	public sealed class OnpRoteiro : PersistClass<OnpRoteiro> {
		#region Atributos
		private int? seqRoteiro;
		private int? seqGrupoFatura;
		private string indFatura;
		private DateTime? datBase;
		private string codReferencia;
		private DateTime? datServidor;

		private static OnpRoteiro roteiro;
		#endregion

		#region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Roteiro", Pk = true)]
		public int? SeqRoteiro {
			get { return seqRoteiro; }
			set { seqRoteiro = value; }
		}
        [Column(ColumnName = "seq_Grupo_Fatura")]
		public int? SeqGrupoFatura {
			get { return seqGrupoFatura; }
			set { seqGrupoFatura = value; }
		}
        [Column(ColumnName = "ind_Fatura")]
		public string IndFatura {
			get { return indFatura; }
			set { indFatura = value; }
		}
        [Column(ColumnName = "dat_Base")]
		public DateTime? DatBase {
			get { return datBase; }
			set { datBase = value; }
		}
        [Column(ColumnName = "cod_Referencia")]
		public string CodReferencia {
			get { return codReferencia; }
			set { codReferencia = value; }
		}
        [Column(ColumnName = "dat_Servidor")]
		public DateTime? DatServidor {
			get { return datServidor; }
			set { datServidor = value; }
		}

		public static OnpRoteiro Roteiro {
			get {
				if (roteiro == null)
					roteiro = new OnpRoteiro().SelectCollection()[0];
				return roteiro;
			}
		}
		#endregion

		public OnpRoteiro(int? seqRoteiro) {
			this.seqRoteiro = seqRoteiro;
			this.Materialize();
		}
		
        public OnpRoteiro() { }

        public static string GrupoRoteiroCarregado() {
            OnPlaceMovel.Source.Banco.OnpRoteiro roteiro = new OnPlaceMovel.Source.Banco.OnpRoteiro();
            Collection<OnPlaceMovel.Source.Banco.OnpRoteiro> roteiros = roteiro.SelectCollection();
            string rot = "SEM ROTEIRO";
            if (roteiros.Count > 0) {
                rot = roteiros[0].SeqRoteiro.ToString().Substring(1, 3);
                rot += "-";
                rot += roteiros[0].SeqRoteiro.ToString().Substring(4);
            }
            return rot;
        }

	}
}
