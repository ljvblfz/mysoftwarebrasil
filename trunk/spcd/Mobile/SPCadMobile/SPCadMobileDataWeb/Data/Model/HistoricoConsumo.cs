using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using CommonHelpMobile;

namespace SPCadMobileDataWeb.Data.Model
{
    [PersistenceClass("TB_HISTORICO_CONSUMO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class HistoricoConsumo : AuditoriaSuper
    {
        [PersistenceProperty("ID_HIST_CONSM", PersistenceParameterType.Key)]
        public long Id { get; set; }

        [PersistenceProperty("NUM_MATRIC")]        
        public long? Matricula { get; set; }

        [PersistenceProperty("ID_CADAST")]
        [PersistenceForeignKey(typeof(Cadastro), "Id")]
        public long? Cadastro { get; set; }

        [PersistenceProperty("MES_REFER")]
        public DateTime? MesReferencia { get; set; }

        [PersistenceProperty("COD_OCORRC1")]
        [PersistenceForeignKey(typeof(Ocorrencia), "Id")]
        public int? Ocorrencia1 { get; set; }

        [PersistenceProperty("COD_OCORRC2")]
        [PersistenceForeignKey(typeof(Ocorrencia), "Id")]
        public int? Ocorrencia2 { get; set; }

        [PersistenceProperty("CRITR")]
        public string Criterio { get; set; }
        
        [PersistenceProperty("VOL_MEDDO")]
        public int? VolumeMedido { get; set; }

        [PersistenceProperty("FLG_HISTCONSUMO", DirectionParameter.InputOptional)]
        public string FlgHistconsumo { get; set; }

        [PersistenceProperty("LEITURA_FAT")]
        public long? LeituraApuracao { get; set; }

        [PersistenceProperty("DAT_LEITURA_FAT")]
        public DateTime? DatLeituraFat { get; set; }
    }
}
