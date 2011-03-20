using System;
using GDA;
using System.Runtime.Serialization;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_LOGRADOURO.
    /// </summary>
    [PersistenceClass("ONP_LOGRADOURO")]
    [Serializable]
    public class LogradouroONP : Persistent
    {
        private int      _seq_logradouro;
        private string   _des_logradouro;

        [PersistenceProperty("seq_logradouro")]
        public int seq_logradouro { get; set; }

        [PersistenceProperty("des_logradouro")]
        public string des_logradouro { get; set; }
    }
}


