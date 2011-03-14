using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_DISTRIBUICAO.
    /// </summary>
    [PersistenceClass("IDA_DISTRIBUICAO")]
    [PersistenceBaseDAO(typeof(DistribuicaoDAO))]
    [Serializable]
    public class Distribuicao : Persistent
    {
        #region Local Variables

        private int? _Codigo_Agente;

        /// <summary>
        ///  Campo que define a situação da distribuição
        ///     - L (liberada)
        ///     - C (carregada)
        ///     - D (descarregada)
        ///     - B (bloqueada)
        /// </summary>
        private string _Situacao;

        private DateTime? _Referencia;
        private int _Grupo;
        private int _Rota;
        private DateTime? _Data_Carga;
        private DateTime? _Data_Descarga;
        
        #endregion

        #region Metodos 

        [PersistenceProperty("Codigo_Agente")]
        public int? Codigo_Agente { get; set; }

        /// <summary>
        ///  Campo que define a situação da distribuição
        ///     - L (liberada)
        ///     - C (carregada)
        ///     - D (descarregada)
        ///     - B (bloqueada)
        /// </summary>
        [PersistenceProperty("Situacao")]
        public string Situacao { get; set; }

        [PersistenceProperty("Referencia")]
        public DateTime? Referencia { get; set; }
        
        [PersistenceProperty("Grupo")]
        public int Grupo { get; set; }

        [PersistenceProperty("Rota")]
        public int Rota { get; set; }
        
        [PersistenceProperty("Data_Carga")]
        public DateTime? Data_Carga { get; set; }
        
        [PersistenceProperty("Data_Descarga")]
        public DateTime? Data_Descarga { get; set; }

        #endregion
    }
}
