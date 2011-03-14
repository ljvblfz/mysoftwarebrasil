using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_HISTORICOS_CONSUMO.
    /// </summary>
    [PersistenceClass("IDA_HISTORICOS_CONSUMO")]
    [PersistenceBaseDAO(typeof(HistoricoConsumoIDADAO))]
    [Serializable]
    public class HistoricoConsumoIDA : Persistent
    {
    	#region Local Variables
		private int  _Grupo;
        private int  _CDC;
        private DateTime  _Referencia;
        private int  _Leitura;
        private DateTime  _Data_Leitura;
        private int  _Consumo;
        private int  _Dias_Consumo;
        private int?  _Ocorrencia;
        private int?  _Leitura_Real;

		#endregion

		#region Metodos
		[PersistenceProperty("Grupo")]
        public int Grupo { get; set; }

        [PersistenceProperty("CDC", PersistenceParameterType.Key)]
        public int CDC { get; set; }

        [PersistenceProperty("Referencia", PersistenceParameterType.Key)]
        public DateTime Referencia { get; set; }

        [PersistenceProperty("Leitura")]
        public int Leitura { get; set; }

        [PersistenceProperty("Data_Leitura")]
        public DateTime Data_Leitura { get; set; }

        [PersistenceProperty("Consumo")]
        public int Consumo { get; set; }

        [PersistenceProperty("Dias_Consumo")]
        public int Dias_Consumo { get; set; }

        [PersistenceProperty("Ocorrencia")]
        public int? Ocorrencia { get; set; }

        [PersistenceProperty("Leitura_Real")]
        public int? Leitura_Real { get; set; }


		#endregion
    }
}