using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_TIPO_ENTREGA.
    /// </summary>
    [PersistenceClass("IDA_TIPO_ENTREGA")]
    [Serializable]
    public class TipoEntregaONP : Persistent
    {
		#region Local Variables
		   
		private string _des_tipo_entrega;

        private Decimal _seq_tipo_entrega;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("des_tipo_entrega")]
        public string des_tipo_entrega
        {
            get
            {
                return _des_tipo_entrega;
            }
            set
            {
                _des_tipo_entrega = value;
            }
        }

        [PersistenceProperty("seq_tipo_entrega")]
        public Decimal seq_tipo_entrega
        {
            get
            {
                return _seq_tipo_entrega;
            }
            set
            {
                _seq_tipo_entrega = value;
            }
        }
					
		#endregion

    }
}

