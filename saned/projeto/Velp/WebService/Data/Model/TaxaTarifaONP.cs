using System;
using GDA;
using System.Runtime.Serialization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TAXA_TARIFA.
    /// </summary>
    [PersistenceClass("ONP_TAXA_TARIFA")]
    [Serializable]
    public class TaxaTarifaONP : Persistent
    {
        private int         _seq_categoria;
        private int         _seq_taxa;
        private int         _seq_taxa_tarifa;
        private int?         _seq_taxa_base;
        private DateTime    _dat_inicio;
        private string      _ind_tipo_taxa;
        private string      _ind_escalonada;
        private string      _ind_dias_consumo;
        private string      _ind_minimo;
        private string      _ind_proporcional;
        private int?         _val_valor_tarifa;
        private int?         _val_percentual;

        [PersistenceProperty("seq_categoria")]
        public int seq_categoria { get; set; }

        [PersistenceProperty("seq_taxa")]
        public int seq_taxa { get; set; }

        [PersistenceProperty("seq_taxa_tarifa")]
        public int seq_taxa_tarifa { get; set; }

        [PersistenceProperty("seq_taxa_base")]
        public int? seq_taxa_base { get; set; }

        [PersistenceProperty("dat_inicio")]
        public DateTime dat_inicio { get; set; }

        [PersistenceProperty("ind_tipo_taxa")]
        public string ind_tipo_taxa { get; set; }

        [PersistenceProperty("ind_escalonada")]
        public string ind_escalonada { get; set; }

        [PersistenceProperty("ind_dias_consumo")]
        public string ind_dias_consumo { get; set; }

        [PersistenceProperty("ind_proporcional")]
        public string ind_proporcional { get; set; }

        [PersistenceProperty("ind_minimo")]
        public string ind_minimo { get; set; }

        [PersistenceProperty("val_valor_tarifa")]
        public int? val_valor_tarifa { get; set; }

        [PersistenceProperty("val_percentual")]
        public int? val_percentual { get; set; }
    }
}
