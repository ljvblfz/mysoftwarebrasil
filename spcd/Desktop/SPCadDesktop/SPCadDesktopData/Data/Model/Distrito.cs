using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadDesktopData.Data.Model
{
    [PersistenceClass("TB_DISTRITO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class Distrito : AuditoriaSuper
    {
        [PersistenceProperty("COD_DISTRT", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("NOM_DISTRT")]
        public string NomeDistrito { get; set; }
    }
}
