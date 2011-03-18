using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Correio Eletronico
    /// </summary>
    [PersistenceClass("TB_CORREIOELETRONICO")]
    [PersistenceBaseDAO(typeof(CorreioEletronicoDAO))]
    public class CorreioEletronico
    {
        [PersistenceProperty("COD_EMPRT")]
        public int COD_EMPRT { get; set; }
        
        [PersistenceProperty("MATRIC_FUNC")]
        public int MATRIC_FUNC { get; set; }

        [PersistenceProperty("ID_MSG")]
        public int ID_MSG { get; set; }

        [PersistenceProperty("ASSUNTO")]
        public string ASSUNTO { get; set; }

        [PersistenceProperty("DT_MSG")]
        public DateTime DT_MSG { get; set; }

        [PersistenceProperty("STATUS_MSG")]
        public string STATUS_MSG { get; set; }

        [PersistenceProperty("DESC_MSG")]
        public string DESC_MSG { get; set; }

        [PersistenceProperty("TIPO_MSG")]
        public string TIPO_MSG { get; set; }

        [PersistenceProperty("STATUS_REG")]
        public string STATUS_REG { get; set; }

        public string Status
        {
            get { 
                if (STATUS_MSG == "0") 
                {
                    return "Aguardando";
                }
                else if (STATUS_MSG == "1")
                {
                    return "Enviado";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
