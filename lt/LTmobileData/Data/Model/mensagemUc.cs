using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Mensagem específica da Uc
    /// </summary>
    [PersistenceClass("TB_MENSAGEM")]
    [PersistenceBaseDAO(typeof(MensagemUcDAO))]
    public class mensagemUc
    {
        [PersistenceProperty("ID_MSG", PersistenceParameterType.Key)]
        public int ID_MSG { get; set; }

        [PersistenceProperty("DESC_MSG")]
        public string DESC_MSG { get; set; }

        [PersistenceProperty("NUM_UC")]
        public int NUM_UC { get; set; }

        [PersistenceProperty("MES_ANO_FATUR")]
        public int MES_ANO_FATUR { get; set; }

        [PersistenceProperty("COD_LOCAL")]
        public int COD_LOCAL { get; set; }

        [PersistenceProperty("COD_EMPRT")]
        public int COD_EMPRT { get; set; }

        [PersistenceProperty("STATUS_REG")]
        public string STATUS_REG { get; set; }

        [PersistenceProperty("NUM_RAZAO")]
        public int NUM_RAZAO { get; set; }

        [PersistenceProperty("FLAG_SENTIDO")]
        public string FLAG_SENTIDO { get; set; }

        [PersistenceProperty("TIPO_MEDIC")]
        public string TIPO_MEDIC { get; set; }

        [PersistenceProperty("DT_MSG")]
        public DateTime DT_MSG { get; set; }
    }
}
