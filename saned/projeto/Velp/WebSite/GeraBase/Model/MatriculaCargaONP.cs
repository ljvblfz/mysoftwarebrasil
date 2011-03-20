using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULAS_CARGA.
    /// </summary>
    [PersistenceClass("ONP_MATRICULAS_CARGA")]
    [PersistenceBaseDAO(typeof(MatriculaCargaDAO))]
    [Serializable]
    public class MatriculaCargaONP : Persistent
    {
        #region Local Variables

        private int _seq_matricula;
        private string _ind_carga;
        private string _ind_descarga;

        #endregion

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("ind_carga")]
        public string ind_carga { get; set; }

        [PersistenceProperty("ind_descarga")]
        public string ind_descarga { get; set; }
    }
}
