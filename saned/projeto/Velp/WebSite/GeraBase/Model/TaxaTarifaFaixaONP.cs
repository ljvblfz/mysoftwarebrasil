using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_TAXA_TARIFA_FAIXA.
    /// </summary>
    [PersistenceClass("ONP_TAXA_TARIFA_FAIXA")]
    [PersistenceBaseDAO(typeof(TaxaTarifaFaixaONP))]
    [Serializable]
    public class TaxaTarifaFaixaONP : Persistent
    {
        
        private int _seq_categoria;
        private int _seq_taxa;
        private int _seq_taxa_tarifa_faixa;
        private int _seq_taxa_tarifa;
        private int _val_limite_consumo;
        private decimal _val_valor_tarifa;

        [PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
        public int seq_categoria { get; set; }

        [PersistenceProperty("seq_taxa", PersistenceParameterType.Key)]
        public int seq_taxa { get; set; }

        [PersistenceProperty("seq_taxa_tarifa_faixa", PersistenceParameterType.Key)]
        public int seq_taxa_tarifa_faixa { get; set; }

        [PersistenceProperty("seq_taxa_tarifa", PersistenceParameterType.Key)]
        public int seq_taxa_tarifa { get; set; }

        [PersistenceProperty("val_limite_consumo")]
        public int val_limite_consumo { get; set; }

        [PersistenceProperty("val_valor_tarifa")]
        public decimal val_valor_tarifa { get; set; }
    }
}
