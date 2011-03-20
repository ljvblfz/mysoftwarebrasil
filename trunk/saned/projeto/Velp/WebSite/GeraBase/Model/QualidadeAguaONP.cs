using System;
using GDA;
using System.Runtime.Serialization;
namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_QUALIDADE_AGUA.
    /// </summary>
    [PersistenceClass("ONP_QUALIDADE_AGUA")]
    [Serializable]
    public class QualidadeAguaONP : Persistent
    {
        #region Local Variables

		private	DateTime _dat_referencia; 
		private	int      _seq_zona_abastecimento; 
		private	int      _seq_parametro; 
		private	string	 _des_parametro; 
		private	int	     _val_previstas; 
		private	int	     _val_realizadas; 
		private	int	     _val_fora_limite;
        private decimal _val_media;

        #endregion

        #region Local metodos

        [PersistenceProperty("dat_referencia")]
        public DateTime dat_referencia { get; set; }

        [PersistenceProperty("seq_zona_abastecimento")]
        public int seq_zona_abastecimento { get; set; }

        [PersistenceProperty("seq_parametro")]
        public int seq_parametro { get; set; }

        [PersistenceProperty("des_parametro")]
        public string des_parametro { get; set; }

        [PersistenceProperty("val_previstas")]
        public int val_previstas { get; set; }

        [PersistenceProperty("val_realizadas")]
        public int val_realizadas { get; set; }

        [PersistenceProperty("val_fora_limite")]
        public int val_fora_limite { get; set; }

        [PersistenceProperty("val_media")]
        public decimal val_media { get; set; }

        #endregion

    }
}
