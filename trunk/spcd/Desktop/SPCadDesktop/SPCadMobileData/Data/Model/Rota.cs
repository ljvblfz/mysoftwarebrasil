using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileData.Data.Model
{
    [PersistenceClass("TB_ROTA")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class Rota : AuditoriaSuper
    {
        [PersistenceProperty("COD_ROTA", PersistenceParameterType.Key)]
        public int CodigoRota { get; set; }

        [PersistenceProperty("COD_DISTRT", PersistenceParameterType.Key)]
        [PersistenceForeignKey(typeof(Distrito), "Id")]
        public int CodigoDistrito { get; set; }

        [PersistenceProperty("NUM_SETOR", PersistenceParameterType.Key)]
        public int Setor { get; set; }

        [PersistenceProperty("DAT_DISTRB")]
        public DateTime? DataDistribuicao { get; set; }

        [PersistenceProperty("DAT_PREV")]
        public DateTime? DataPrevisao { get; set; }

        [PersistenceProperty("DAT_EXPORT")]
        public DateTime? DataExportacao { get; set; }

        [PersistenceProperty("QtdCad", DirectionParameter.InputOptional)]
        public int QtdCad { get; set; }
    }
}
