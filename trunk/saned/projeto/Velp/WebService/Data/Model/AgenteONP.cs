using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
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

        #region Query Importacao

        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO ONP_AGENTE
                                            cod_agente
                                            ,nom_agente
                                            ,des_senha
                                        VALUES
                                            {0}
                                            ,'{1}'
                                            ,'{2}'"
                                    , this.cod_agente
                                    , this.nom_agente
                                    , this.des_senha);
            }
        }

        #endregion
    }
}
