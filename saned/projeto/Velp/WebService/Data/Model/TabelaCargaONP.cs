using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TABELAS_CARGA.
    /// </summary>
    [PersistenceClass("ONP_TABELAS_CARGA")]
    [PersistenceBaseDAO(typeof(TabelaCargaONPDAO))]
    [Serializable]
    public class TabelaCargaONP : Persistent
    {
        #region Local Variables
        private string _nom_tabela;
        private string _ind_carga;
        private string _ind_descarga;

        #endregion

        #region Metodos
        [PersistenceProperty("nom_tabela", PersistenceParameterType.Key)]
        public string nom_tabela
        {
            get
            {
                return _nom_tabela;
            }
            set
            {
                _nom_tabela = value;
            }

        }
        [PersistenceProperty("ind_carga")]
        public string ind_carga
        {
            get
            {
                return _ind_carga;
            }
            set
            {
                _ind_carga = value;
            }

        }
        [PersistenceProperty("ind_descarga")]
        public string ind_descarga
        {
            get
            {
                return _ind_descarga;
            }
            set
            {
                _ind_descarga = value;
            }

        }

        #endregion
    }
}