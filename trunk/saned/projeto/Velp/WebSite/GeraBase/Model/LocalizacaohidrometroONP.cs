using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_LOCALIZACAO_HIDROMETRO.
    /// </summary>
    [PersistenceClass("IDA_LOCALIZACAO_HIDROMETRO")]
    [Serializable]
    public class LocalizacaoHidrometroONP : Persistent
    {
		#region Local Variables
		   
		private string _des_local;

        private Decimal _seq_local;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("des_local")]
        public string des_local
        {
            get
            {
                return _des_local;
            }
            set
            {
                _des_local = value;
            }
        }

        [PersistenceProperty("seq_local")]
        public Decimal seq_local
        {
            get
            {
                return _seq_local;
            }
            set
            {
                _seq_local = value;
            }
        }
					
		#endregion

    }
}

