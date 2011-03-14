using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;
using System.Globalization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_IMPOSTO_DIADEMA.
    /// </summary>
    [PersistenceClass("IDA_IMPOSTO_DIADEMA")]
    [Serializable]
    public class ImpostoDiademaONP : Persistent
    {
		#region Local Variables

        private Decimal _val_porcentagem;
				
		private string _cod_imposto;
					
		#endregion
		
		#region Local Metodos

        [PersistenceProperty("val_porcentagem")]
        public Decimal val_porcentagem
        {
            get
            {
                return _val_porcentagem;
            }
            set
            {
                _val_porcentagem = value;
            }
        }

        [PersistenceProperty("cod_imposto")]
        public string cod_imposto
        {
            get
            {
                return _cod_imposto;
            }
            set
            {
                _cod_imposto = value;
            }
        }
					
		#endregion

    }
}

