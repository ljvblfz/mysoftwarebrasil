using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_DESCONTO_DIADEMA.
    /// </summary>
    [PersistenceClass("IDA_DESCONTO_DIADEMA")]
    [Serializable]
    public class DescontoDiademaONP : Persistent
    {
		#region Local Variables
		   
		private string _ind_tipo_desconto;

        private Decimal _val_limite_inicial;

        private Decimal _val_valor_desconto;

        private Decimal _seq_desconto;
					
		#endregion
		
		#region Local Metodos

        [PersistenceProperty("seq_desconto", PersistenceParameterType.IdentityKey)]
        public Decimal seq_desconto
        {
            get
            {
                return _seq_desconto;
            }
            set
            {
                _seq_desconto = value;
            }
        }

        [PersistenceProperty("ind_tipo_desconto")]
        public string ind_tipo_desconto
        {
            get
            {
                return _ind_tipo_desconto;
            }
            set
            {
                _ind_tipo_desconto = value;
            }
        }
					
		[PersistenceProperty("val_limite_inicial")]
        public Decimal val_limite_inicial
        {
            get
            {
                return _val_limite_inicial;
            }
            set
            {
                _val_limite_inicial = value;
            }
        }
					
		[PersistenceProperty("val_valor_desconto")]
        public Decimal val_valor_desconto
        {
            get
            {
                return _val_valor_desconto;
            }
            set
            {
                _val_valor_desconto = value;
            }
        }
					
		#endregion

    }
}

