using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;

namespace SPCadMobileData.Data.Model
{
    //Classe auxiliar de consumo por cadastro.
    [PersistenceClass("TB_CADASTRO")]
    public class AuxConsCadast : AuditoriaSuper
    {
        [PersistenceProperty("ID_CADAST")]
        [PersistenceForeignKey(typeof(Cadastro), "Id")]
        public long Cadastro { get; set; }

        [PersistenceProperty("NUM_MATRIC")]
        public long Matricula { get; set; }

        [PersistenceProperty("EXPCTV_CONSM")]
        public string ExpectativaConsu { get; set; }

        [PersistenceProperty("SUSPEI_FRAUDE")]
        public string Incompatibilidade { get; set; }

        [PersistenceProperty("OBS_SUSPEI_FRAUDE")]
        public string ObsNaoConf { get; set; }
    }
}
