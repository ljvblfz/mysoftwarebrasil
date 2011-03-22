using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileData.Data.Model
{
    [PersistenceClass("TB_OCORRENCIA")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class Ocorrencia : AuditoriaSuper
    {
        [PersistenceProperty("COD_OCORRC", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("DES_OCORRC")]
        public string Descricao { get; set; }

        [PersistenceProperty("FLG_IMPEDM")]
        public bool ImpedimentoBool { get; set; }

        [PersistenceProperty("FLG_DANIFC")]
        public bool DanificBool { get; set; }

        [PersistenceProperty("FLG_LEITUR")]
        public string FlagLeitura { get; set; }
        
    }
}
