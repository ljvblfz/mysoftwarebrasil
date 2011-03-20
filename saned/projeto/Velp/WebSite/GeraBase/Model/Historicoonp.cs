using System;
using GDA;
using System.Runtime.Serialization;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela onp_historico.
    /// </summary>
    [PersistenceClass("ONP_HISTORICO")]
    [Serializable]
    public class HistoricoONP : Persistent
    {
		#region Local Variables
		   
		private string _val_consumo;
		   
		private string _cod_ocorrencia;
		   
		private string _seq_matricula;
				
		private string _cod_referencia;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("val_consumo")]
		public string val_consumo { get; set; }
					
		[PersistenceProperty("cod_ocorrencia")]
		public string cod_ocorrencia { get; set; }
					
		[PersistenceProperty("seq_matricula")]
		public string seq_matricula { get; set; }
					
		[PersistenceProperty("cod_referencia")]
		public string cod_referencia { get; set; }
					
		#endregion

    }
}

