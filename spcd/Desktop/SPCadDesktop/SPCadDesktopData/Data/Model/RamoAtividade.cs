using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadDesktopData.Data.Model
{
    [PersistenceClass("TB_RAMO_ATIVIDADE")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class RamoAtividade : AuditoriaSuper
    {
        [PersistenceProperty("COD_RAMO_ATIVD", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("DES_RAMO_ATIVD")]
        public string Descricao { get; set; }

        [PersistenceProperty("TIP_RAMO_ATIVD")]
        public string Tipo { get; set; }
    }
}
