using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;

namespace SPCadMobileData.Data.Model
{
    public class AuditoriaSuper
    {
        [PersistenceProperty("VERSAO", DirectionParameter.InputOptionalOutput)]
        public long? Versao { get; set; }

        //referente ao login do usuario
        [PersistenceProperty("USU_MOVIMENTACAO", DirectionParameter.InputOptionalOutput)]
        public string UsuMovimentacao { get; set; }

        [PersistenceProperty("DT_MOVIMENTACAO", DirectionParameter.InputOptionalOutput)]
        public DateTime? DtMovimentacao { get; set; }

        [PersistenceProperty("IP_MOVIMENTACAO", DirectionParameter.InputOptionalOutput)]
        public string IpMovimentacao { get; set; }

        [PersistenceProperty("STATUS_REG", DirectionParameter.InputOptionalOutput)]
        public string StatusReg { get; set; }
    }
}
