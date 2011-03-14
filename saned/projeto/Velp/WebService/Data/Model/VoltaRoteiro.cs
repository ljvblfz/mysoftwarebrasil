using System;
using GDA;
using System.Runtime.Serialization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela VOLTA_ROTEIRO.
    /// </summary>
    [PersistenceClass("VOLTA_ROTEIRO")]
    [Serializable]
    public class VoltaRoteiro : Persistent
    {
		#region Local Variables
		   
		private DateTime _Referencia;
		   
		private int _Grupo;
		   
		private int _Rota;
		   
		private DateTime _Data_Inicial;
		   
		private DateTime _Data_Final;
		   
		private DateTime _Data_Envio;
		   
		private DateTime? _Data_Processamento;
		   
		private int _Aparelho;
		   
		private DateTime? _Data_Problema;
				
		private string _Chuva;
					
		#endregion
		
		#region Local Metodos

        [PersistenceProperty("Referencia", PersistenceParameterType.Key)]
		public DateTime Referencia { get; set; }
					
		[PersistenceProperty("Grupo")]
		public int Grupo { get; set; }

        [PersistenceProperty("Rota", PersistenceParameterType.Key)]
		public int Rota { get; set; }
					
		[PersistenceProperty("Data_Inicial")]
		public DateTime Data_Inicial { get; set; }
					
		[PersistenceProperty("Data_Final")]
		public DateTime Data_Final { get; set; }
					
		[PersistenceProperty("Data_Envio")]
		public DateTime Data_Envio { get; set; }
					
		[PersistenceProperty("Data_Processamento")]
		public DateTime? Data_Processamento { get; set; }
					
		[PersistenceProperty("Aparelho")]
		public int Aparelho { get; set; }
					
		[PersistenceProperty("Data_Problema")]
		public DateTime? Data_Problema { get; set; }
					
		[PersistenceProperty("Chuva")]
		public string Chuva { get; set; }
					
		#endregion

    }
}

