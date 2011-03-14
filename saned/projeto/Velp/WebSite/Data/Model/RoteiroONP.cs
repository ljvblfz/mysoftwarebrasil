using System;
using GDA;
using System.Runtime.Serialization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela VOLTA_ROTEIRO.
    /// </summary>
    [PersistenceClass("ONP_ROTEIRO")]
    [Serializable]
    public class RoteiroONP : Persistent
    {
        private int _seq_roteiro;
        private int _seq_grupo_fatura;
        private string _ind_fatura;
        private DateTime _dat_base;
        private DateTime _dat_servidor;
        private string _cod_referencia;

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("seq_grupo_fatura")]
        public int seq_grupo_fatura { get; set; }

        [PersistenceProperty("ind_fatura")]
        public string ind_fatura { get; set; }

        [PersistenceProperty("dat_base")]
        public DateTime dat_base { get; set; }

        [PersistenceProperty("dat_servidor")]
        public DateTime dat_servidor { get; set; }

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia { get; set; }
    }
}
