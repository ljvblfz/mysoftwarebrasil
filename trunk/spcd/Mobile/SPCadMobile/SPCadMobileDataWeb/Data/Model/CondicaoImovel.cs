using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileDataWeb.Data.Model
{
    [PersistenceClass("TB_CONDICAO_IMOVEL")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class CondicaoImovel: AuditoriaSuper
    {
        [PersistenceProperty("COND_IMOV", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("DES_SIT_IMOV")]
        public string Descricao { get; set; }
    }
}
