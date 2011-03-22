using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadDesktopData.Data.Model
{
    [PersistenceClass("TB_TIPO_PADRAO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class TipoPadrao : AuditoriaSuper
    {
        [PersistenceProperty("TIP_PADRAO", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("DES_TIP_PADRAO")]
        public string Descricao { get; set; }
    }
}
