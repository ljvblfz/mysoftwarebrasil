using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ida_ocorrencia.
    /// </summary>
    [PersistenceClass("IDA_OCORRENCIA")]
    [Serializable]
    public class OcorrenciaONP : Persistent
    {
		#region Local Variables
		   
		private string _des_ocorrencia;
		   
		private string _des_mensagem;
		   
		private string _ind_grupo;
		   
		private string _ind_leitura;
		   
		private string _ind_consumo;
		   
		private string _ind_emite;

        private Decimal _cod_ocorrencia;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("des_ocorrencia")]
		public string des_ocorrencia { get; set; }
					
		[PersistenceProperty("des_mensagem")]
		public string des_mensagem { get; set; }
					
		[PersistenceProperty("ind_grupo")]
		public string ind_grupo { get; set; }
					
		[PersistenceProperty("ind_leitura")]
		public string ind_leitura { get; set; }
					
		[PersistenceProperty("ind_consumo")]
		public string ind_consumo { get; set; }
					
		[PersistenceProperty("ind_emite")]
		public string ind_emite { get; set; }

        [PersistenceProperty("cod_ocorrencia", PersistenceParameterType.Key)]
        public Decimal cod_ocorrencia { get; set; }
					
		#endregion

    }
}

