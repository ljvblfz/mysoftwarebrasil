using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace SPCadMobileData.Data.Model
{
    [PersistenceClass("TB_DISTRIBUICAO")]
    //[PersistenceBaseDAO(typeof(DistribuicaoDAO))]
    public class Distribuicao : AuditoriaSuper
    {
        [PersistenceProperty("COD_DISTRB", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("COD_ROTA")]
        [PersistenceForeignKey(typeof(Rota), "CodigoRota")]
        public int CodigoRota { get; set; }

        [PersistenceProperty("COD_DISTRT")]
        [PersistenceForeignKey(typeof(Rota), "CodigoDistrito")]
        public int CodigoDistrito { get; set; }

        [PersistenceProperty("NUM_SETOR")]
        [PersistenceForeignKey(typeof(Rota), "Setor")]
        public int Setor { get; set; }

        [PersistenceProperty("COD_FUNCN")]
        [PersistenceForeignKey(typeof(Funcionario), "Id")]
        public int CodigoFuncionario { get; set; }
    }
}
