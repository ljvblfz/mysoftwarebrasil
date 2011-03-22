﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using SPCadMobileData.Data.DAL;

namespace SPCadMobileData.Data.Model
{
    /// <summary>
    /// Classe foto
    /// </summary>
    [PersistenceClass("TB_FOTO")]
    public class Foto : AuditoriaSuper
    {
        [PersistenceProperty("ID_CADAST", PersistenceParameterType.Key)]
        [PersistenceForeignKey(typeof(Cadastro), "Id")]
        public long idCadast { get; set; }

        [PersistenceProperty("COD_OCORRC")]
        public int? codOcorrc { get; set; }

        [PersistenceProperty("DESC_FOTO")]
        public string descFoto { get; set; }

        [PersistenceProperty("NOM_FOTO")]
        public string nomFoto { get; set; }

        [PersistenceProperty("SEQUENCIA")]
        public int sequencia { get; set; }

        [PersistenceProperty("NUM_PONTO_SERVC")]
        public string numPontoServc { get; set; }

        [PersistenceProperty("DATA")]
        public DateTime Data { get; set; }

        [PersistenceProperty("COORD_X")]
        public string CoordenadaX { get; set; }

        [PersistenceProperty("COORD_Y")]
        public string CoordenadaY { get; set; }

        [PersistenceProperty("DATAGPS")]
        public DateTime? DataGPS { get; set; }
    }
}
