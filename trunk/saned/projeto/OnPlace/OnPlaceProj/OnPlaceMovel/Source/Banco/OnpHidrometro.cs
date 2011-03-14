using System;
using System.Text;
using System.Collections.Generic;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Hidrometro")]
	public sealed class OnpHidrometro : PersistClass<OnpHidrometro> {
		#region Atributos
		private string codHidrometro;
		private int? seqMatricula;
		private int? seqLocal;
		private string codMarca;
		private int? seqTamanhoHidrometro;
		private int? valNumeroDigitos;
		private int? seqDiametroLigacao;
		private DateTime? datFabricacao;
		private DateTime? datAquisicao;
		private string desClasse;

		private OnpLocalizacaoHidrometro localHidrometro;
		#endregion

		#region Getters ans Setters (Fields)
		[Column(ColumnName = "cod_Hidrometro", Pk = true )]
		public string CodHidrometro {
			get { return codHidrometro; }
			set { codHidrometro = value; }
		}
        [Column( ColumnName = "seq_Matricula", Pk = true )]
        public int? SeqMatricula {
            get { return seqMatricula; }
            set { seqMatricula = value; }
        }
        [Column(ColumnName = "seq_Local")]
		public int? SeqLocal {
			get { return seqLocal; }
			set { seqLocal = value; }
		}
        [Column(ColumnName = "cod_Marca")]
		public string CodMarca {
			get { return codMarca; }
			set { codMarca = value; }
		}
        [Column(ColumnName = "seq_Tamanho_Hidrometro")]
		public int? SeqTamanhoHidrometro {
			get { return seqTamanhoHidrometro; }
			set { seqTamanhoHidrometro = value; }
		}
        [Column(ColumnName = "val_Numero_Digitos")]
		public int? ValNumeroDigitos {
			get { return valNumeroDigitos; }
			set { valNumeroDigitos = value; }
		}
        [Column(ColumnName = "seq_Diametro_Ligacao")]
		public int? SeqDiametroLigacao {
			get { return seqDiametroLigacao; }
			set { seqDiametroLigacao = value; }
		}
        [Column(ColumnName = "dat_Fabricacao")]
		public DateTime? DatFabricacao {
			get { return datFabricacao; }
			set { datFabricacao = value; }
		}
        [Column(ColumnName = "dat_Aquisicao")]
		public DateTime? DatAquisicao {
			get { return datAquisicao; }
			set { datAquisicao = value; }
		}
        [Column(ColumnName = "des_Classe")]
		public string DesClasse {
			get { return desClasse; }
			set { desClasse = value; }
		}

		public OnpLocalizacaoHidrometro LocalHidrometro {
			get {
				if ( localHidrometro == null ) {
					if ( seqLocal.HasValue )
						localHidrometro = new OnpLocalizacaoHidrometro( seqLocal.Value );
					else
						localHidrometro = new OnpLocalizacaoHidrometro();
				}
				return localHidrometro;
			}
			set { localHidrometro = value; }
		}
		#endregion

		public OnpHidrometro(string codHidrometro, int seqMatricula) {
			this.codHidrometro = codHidrometro;
			this.seqMatricula = seqMatricula;
			this.Materialize();
		}
		
		public OnpHidrometro() { }
	}
}
