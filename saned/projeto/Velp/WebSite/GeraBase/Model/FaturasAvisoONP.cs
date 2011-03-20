using System;
using GDA;
using System.Runtime.Serialization;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela onp_faturas_aviso.
    /// </summary>
    [PersistenceClass("ONP_FATURAS_AVISO")]
    [Serializable]
    public class FaturasAvisoONP : Persistent
    {
		#region Local Variables
		   
		private string _cod_referencia;
		   
		private DateTime? _dat_vencimento;
		   
		private decimal? _val_valor_fatura;
		   
		private int _seq_matricula;
				
		private int _seq_fatura;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("cod_referencia")]
		public string cod_referencia { get; set; }
					
		[PersistenceProperty("dat_vencimento")]
		public DateTime? dat_vencimento { get; set; }
					
		[PersistenceProperty("val_valor_fatura")]
        public decimal? val_valor_fatura { get; set; }
					
		[PersistenceProperty("seq_matricula")]
		public int seq_matricula { get; set; }
					
		[PersistenceProperty("seq_fatura")]
		public int seq_fatura { get; set; }
					
		#endregion

    }
}

