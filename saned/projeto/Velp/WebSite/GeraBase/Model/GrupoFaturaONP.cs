using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_GRUPO_FATURA.
    /// </summary>
    [PersistenceClass("ONP_GRUPO_FATURA")]
    [PersistenceBaseDAO(typeof(GrupoFaturaDAO))]
    [Serializable]
    public class GrupoFaturaONP : Persistent
    {
        #region Local Variables

        private int _seq_grupo_fatura;
        private string _ind_tipo_vencimento;
        private int _num_dias;
        private string _des_dias_vencimento;
        
        #endregion

        [PersistenceProperty("seq_grupo_fatura", PersistenceParameterType.Key)]
        public int seq_grupo_fatura { get; set; }

        [PersistenceProperty("ind_tipo_vencimento")]
        public string ind_tipo_vencimento { get; set; }

        [PersistenceProperty("num_dias")]
        public int num_dias { get; set; }

        [PersistenceProperty("des_dias_vencimento")]
        public string des_dias_vencimento { get; set; }

    }
}