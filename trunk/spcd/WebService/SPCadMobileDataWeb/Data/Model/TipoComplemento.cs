using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileDataWeb.Data.Model
{
    [PersistenceClass("TB_TIPO_COMPLEMENTO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class TipoComplemento: AuditoriaSuper
    {
        [PersistenceProperty("TIP_COMPL", PersistenceParameterType.Key)]
        public string Tipo { get; set; }

        [PersistenceProperty("DES_TIP_COMPL")]
        public string Descricao { get; set; }
    }
}
