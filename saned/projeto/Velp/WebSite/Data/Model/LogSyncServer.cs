using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace Data.Model
{
    [PersistenceClass("LOGSYNCSERVER")]        
    public class LogSyncServer
    {
        [PersistenceProperty("COLETOR", PersistenceParameterType.Key)]
        public string Coletor { get; set; }

        [PersistenceProperty("DATASYNC")]
        public DateTime DataSync { get; set; }

        [PersistenceProperty("FUNCIONARIO")]
        public long Funcionario { get; set; }

        [PersistenceProperty("TABELA")]
        public string Tabela { get; set; }

        [PersistenceProperty("TIPOTRANFER")]
        public string TipoTranfer { get; set; }

        [PersistenceProperty("OBS")]
        public string Obs { get; set; }
    }

}
