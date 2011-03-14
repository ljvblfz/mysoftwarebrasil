using System;
using GDA;
using System.Runtime.Serialization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela VOLTA_NOVO_REGISTRO.
    /// </summary>
    [PersistenceClass("VOLTA_NOVO_REGISTRO")]
    [Serializable]
    public class VoltaNovoRegistro : Persistent
    {
		#region Local Variables
		   
		private int? _Grupo;
		   
		private int? _Rota;
		   
		private string _Complemento;
		   
		private string _Medidor;
		   
		private string _Nome;
		   
		private string _OBS;
		   
		private DateTime? _referencia;
		   
		private string _logradouro;
				
		private int? _numero;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("Grupo")]
		public int? Grupo { get; set; }
					
		[PersistenceProperty("Rota")]
		public int? Rota { get; set; }
					
		[PersistenceProperty("Complemento")]
		public string Complemento { get; set; }
					
		[PersistenceProperty("Medidor")]
		public string Medidor { get; set; }
					
		[PersistenceProperty("Nome")]
		public string Nome { get; set; }
					
		[PersistenceProperty("OBS")]
		public string OBS { get; set; }
					
		[PersistenceProperty("referencia")]
		public DateTime? referencia { get; set; }
					
		[PersistenceProperty("logradouro")]
		public string logradouro { get; set; }
					
		[PersistenceProperty("numero")]
		public int? numero { get; set; }
					
		#endregion

    }
}

