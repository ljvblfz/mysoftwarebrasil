using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Ocorrencia
    /// </summary>
    [PersistenceClass("LTTB_IRREGULARIDADES")]
    [PersistenceBaseDAO(typeof(OcorrenciaDAO))]
    public class Ocorrencia
    {
        [PersistenceProperty("COD_IRREGL", PersistenceParameterType.Key)]
        public int COD_IRREGL { get; set; }

        [PersistenceProperty("COD_EMPRT")]
        public int COD_EMPRT { get; set; }

        [PersistenceProperty("DESC_IRREGL")]
        public string DESC_IRREGL { get; set; }

        [PersistenceProperty("USUAR_ATLZ")]
        public string USUAR_ATLZ { get; set; }

        [PersistenceProperty("DATA_ATLZ")]
        public DateTime DATA_ATLZ { get; set; }

        [PersistenceProperty("HORA_ATLZ")]
        public string HORA_ATLZ { get; set; }

        [PersistenceProperty("NUM_PRIOR")]
        public int NUM_PRIOR { get; set; }

        [PersistenceProperty("FLAG_FOTO")]
        public string FLAG_FOTO { get; set; }

        [PersistenceProperty("OBS_PADRAO")]
        public string OBS_PADRAO { get; set; }

        private string flag_Impedimento;
        [PersistenceProperty("FLAG_IMPEDIMENTO")]
        public string FLAG_IMPEDIMENTO
        {
            get
            { return flag_Impedimento == "0" ? "N" : flag_Impedimento == "1" ? "S" : ""; }
            set 
            { 
                flag_Impedimento = value == "N" ? "0" : value == "S" ? "1" : value; 
            }
        }

        private string flag_complemento;
        [PersistenceProperty("FLAG_COMPLEMENTO")]
        public string FLAG_COMPLEMENTO 
        {
            get
            { return flag_complemento == "0" ? "N" : flag_complemento == "1" ? "S" : ""; }
            set
            {
                flag_complemento = value == "N" ? "0" : value == "S" ? "1" : value;
            }
        }

    }
}
