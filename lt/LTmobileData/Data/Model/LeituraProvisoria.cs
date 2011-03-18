using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Leitura Provisória
    /// </summary>
    [PersistenceClass("TB_LEITURA_PROVISORIA")]
    [PersistenceBaseDAO(typeof(LeituraProvisoriaDAO))]
    public class LeituraProvisoria
    {
        [PersistenceProperty("MES_ANO_FATUR", PersistenceParameterType.Key)]
        public int MES_ANO_FATUR { get; set; }

        [PersistenceProperty("COD_LOCAL", PersistenceParameterType.Key)]
        public int COD_LOCAL { get; set; }

        [PersistenceProperty("COD_EMPRT", PersistenceParameterType.Key)]
        public int COD_EMPRT { get; set; }

        [PersistenceProperty("TIPO_MEDIC", PersistenceParameterType.Key)]
        public string TIPO_MEDIC { get; set; }

        [PersistenceProperty("NUM_MEDIDR", PersistenceParameterType.Key)]
        public string NUM_MEDIDR { get; set; }

        [PersistenceProperty("MATRIC_FUNC")]
        public int MATRIC_FUNC { get; set; }

        [PersistenceProperty("NUM_UC_REF", PersistenceParameterType.Key)]
        public int NUM_UC_REF { get; set; }

        [PersistenceProperty("NUM_RAZAO", PersistenceParameterType.Key)]
        public int NUM_RAZAO { get; set; }

        [PersistenceProperty("IRREGL_ATUAL1")]
        public int IRREGL_ATUAL1 { get; set; }

        [PersistenceProperty("IRREGL_ATUAL2")]
        public int IRREGL_ATUAL2 { get; set; }

        [PersistenceProperty("IRREGL_ATUAL3")]
        public int IRREGL_ATUAL3 { get; set; }

        [PersistenceProperty("DATA_VISITA")]
        public DateTime DATA_VISITA { get; set; }

        [PersistenceProperty("HORA_VISITA")]
        public string HORA_VISITA { get; set; }

        [PersistenceProperty("LEITUR_VISITA")]
        public int LEITUR_VISITA { get; set; }

        [PersistenceProperty("COORD_X")]
        public string COORD_X { get; set; }

        [PersistenceProperty("COORD_Y")]
        public string COORD_Y { get; set; }

        [PersistenceProperty("STATUS_REG")]
        public string STATUS_REG { get; set; }

        [PersistenceProperty("COMPL_ATUAL1")]
        public string COMPL_ATUAL1 { get; set; }

        [PersistenceProperty("COMPL_ATUAL2")]
        public string COMPL_ATUAL2 { get; set; }

        [PersistenceProperty("COMPL_ATUAL3")]
        public string COMPL_ATUAL3 { get; set; }

        [PersistenceProperty("OBSERVACAO")]
        public string OBSERVACAO { get; set; }

    }
}
