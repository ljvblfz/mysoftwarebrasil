using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_AGENTE.
    /// </summary>
    [PersistenceClass("ONP_FATURA_TAXA")]
    [PersistenceBaseDAO(typeof(FaturaTaxaONP))]
    [Serializable]
    public class FaturaTaxaONP : Persistent
    {
        #region Local Variables

        private int _seq_taxa;
        private int _seq_categoria;
        private int _seq_fatura;
        private string _cod_referencia;
        private int _seq_roteiro;
        private int _seq_matricula;
        private int _val_numero_economia;
        private int _val_consumo_faturado;
        private int _val_valor_calculado;
        private int _val_valor_faturado;
        private int _ind_situacao;
        private string _ind_tipo_consumo;
        
        #endregion

        #region Metodos 

        [PersistenceProperty("seq_taxa")]
        public int seq_taxa { get; set; }

        [PersistenceProperty("seq_categoria")]
        public int seq_categoria { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("seq_fatura")]
        public int seq_fatura { get; set; }

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia { get; set; }

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("val_numero_economia")]
        public int val_numero_economia { get; set; }

        [PersistenceProperty("val_consumo_faturado")]
        public int val_consumo_faturado { get; set; }

        [PersistenceProperty("val_valor_calculado")]
        public int val_valor_calculado { get; set; }

        [PersistenceProperty("val_valor_faturado")]
        public int val_valor_faturado { get; set; }

        [PersistenceProperty("ind_situacao")]
        public int ind_situacao { get; set; }

        [PersistenceProperty("ind_tipo_consumo")]
        public string ind_tipo_consumo { get; set; }

        #endregion
    }
}

