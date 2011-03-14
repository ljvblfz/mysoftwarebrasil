using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_GRUPOS.
    /// </summary>
    [PersistenceClass("IDA_GRUPOS")]
    [PersistenceBaseDAO(typeof(GrupoDAO))]
    [Serializable]
    public class GrupoONP : Persistent
    {
        #region Local Variables

        private DateTime _Referencia;
        private DateTime _Data_Envio;
        private DateTime _Data_Processamento;
        private DateTime _Data_Retorno;
        private DateTime _Data_Leitura;
        private DateTime _Data_Proxima_Leitura;
        private int _Grupo;
        private int _Qtde_Registros;

        #endregion

        [PersistenceProperty("Referencia", PersistenceParameterType.Key)]
        public DateTime Referencia { get; set; }

        [PersistenceProperty("Data_Envio")]
        public DateTime Data_Envio { get; set; }

        [PersistenceProperty("Data_Processamento")]
        public DateTime Data_Processamento { get; set; }

        [PersistenceProperty("Data_Retorno")]
        public DateTime Data_Retorno { get; set; }

        [PersistenceProperty("Data_Leitura")]
        public DateTime Data_Leitura { get; set; }

        [PersistenceProperty("Data_Proxima_Leitura")]
        public DateTime Data_Proxima_Leitura { get; set; }

        [PersistenceProperty("Qtde_Registros")]
        public int Qtde_Registros { get; set; }

        [PersistenceProperty("Grupo")]
        public int Grupo { get; set; }
    }
}