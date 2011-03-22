using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileDataWeb.Data.Model
{
    [PersistenceClass("TB_LOCALIZACAO_PADRAO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class LocalizacaoPadrao : AuditoriaSuper
    {
        [PersistenceProperty("LOCLZ_PADRAO", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("DES_LOCLZ_PADRAO")]
        public string Descricao { get; set; }
    }
}
