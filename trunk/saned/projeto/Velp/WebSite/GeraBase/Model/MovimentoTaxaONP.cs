using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO_TAXA.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO_TAXA")]
    [PersistenceBaseDAO(typeof(MovimentoTaxaDAO))]
    [Serializable]
    public class MovimentoTaxaONP : Persistent
    {
        #region Local Variables

        private int _seq_taxa;
        private int _seq_matricula;
        private int _seq_categoria;
        private int _seq_roteiro;
        private int _val_economias;
        private int? _val_consumo_fixo;
        private int? _val_consumo_estimado;
        private string _cod_referencia;
        private int _ind_situacao;

        #endregion

        [PersistenceProperty("seq_taxa")]
        public int seq_taxa { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("val_economias")]
        public int val_economias { get; set; }

        [PersistenceProperty("val_consumo_fixo")]
        public int? val_consumo_fixo { get; set; }

        [PersistenceProperty("val_consumo_estimado")]
        public int? val_consumo_estimado { get; set; }

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia{get;set;}

        [PersistenceProperty("ind_situacao")]
        public int ind_situacao { get; set; }

        [PersistenceProperty("seq_categoria")]
        public int seq_categoria { get; set; }
    }
}
