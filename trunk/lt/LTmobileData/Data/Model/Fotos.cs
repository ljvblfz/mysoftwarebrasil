using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Fotos
    /// </summary>
    [PersistenceClass("LTMV_FOTO_LEITURA")]
    [PersistenceBaseDAO(typeof(FotosDAO))]
    public class Fotos
    {
        [PersistenceProperty("ID_FOTO")]
        public int ID_FOTO { get; set; }

        [PersistenceProperty("MES_ANO_FATUR", PersistenceParameterType.Key)]
        public int MES_ANO_FATUR { get; set; }

        [PersistenceProperty("TIPO_MEDIC", PersistenceParameterType.Key)]
        public string TIPO_MEDIC { get; set; }

        [PersistenceProperty("COD_LOCAL", PersistenceParameterType.Key)]
        public int COD_LOCAL { get; set; }

        [PersistenceProperty("NUM_UC", PersistenceParameterType.Key)]
        public int NUM_UC { get; set; }

        [PersistenceProperty("COD_EMPRT", PersistenceParameterType.Key)]
        public int COD_EMPRT { get; set; }

        [PersistenceProperty("NUM_RAZAO", PersistenceParameterType.Key)]
        public int NUM_RAZAO { get; set; }

        [PersistenceProperty("NUM_MEDIDR")]
        public string NUM_MEDIDR { get; set; }

        [PersistenceProperty("NUM_SEQ_FOTO", PersistenceParameterType.Key)]
        public int NUM_SEQ_FOTO { get; set; }

        [PersistenceProperty("DESC_FOTO")]
        public string DESC_FOTO { get; set; }

        [PersistenceProperty("USUAR_ATLZ")]
        public string USUAR_ATLZ { get; set; }

        [PersistenceProperty("DATA_ATLZ")]
        public DateTime DATA_ATLZ { get; set; }

        [PersistenceProperty("HORA_ATLZ")]
        public string HORA_ATLZ { get; set; }

        [PersistenceProperty("CORD_X")]
        public string CORD_X { get; set; }

        [PersistenceProperty("CORD_Y")]
        public string CORD_Y { get; set; }

        [PersistenceProperty("STATUS_REG")]
        public string STATUS_REG { get; set; }

        [PersistenceProperty("ORIG_INFORM")]
        public int ORIG_INFORM { get; set; }

    }
}
