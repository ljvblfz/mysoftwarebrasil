using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileDataWeb.Data.Model
{
    [PersistenceClass("TB_FONTE_ALTERNATIVA")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class FonteAlternativa : AuditoriaSuper
    {
        [PersistenceProperty("COD_FONTE_ALTERN", PersistenceParameterType.Key)]
        public string Id { get; set; }

        [PersistenceProperty("DES_FONTE_ALTERN")]
        public string Descricao { get; set; }
    }
}
