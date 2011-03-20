using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_AGENTE.
    /// </summary>
    [PersistenceClass("ONP_AGENTE")]
    [PersistenceBaseDAO(typeof(AgenteDAO))]
    [Serializable]
    public class AgenteONP : Persistent
    {
        #region Local Variables

        //private int _Grupo;
        private int? _cod_agente;
        private string _nom_agente;
        private string _des_senha;
        
        #endregion

        #region Metodos 

        [PersistenceProperty("cod_agente", PersistenceParameterType.Key)]
        public int? cod_agente { get; set; }

        [PersistenceProperty("nom_agente")]
        public string nom_agente { get; set; }

        [PersistenceProperty("des_senha")]
        public string des_senha { get; set; }

        #endregion
    }
}
