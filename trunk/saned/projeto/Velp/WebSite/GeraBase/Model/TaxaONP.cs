using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_TAXA.
    /// </summary>
    [PersistenceClass("IDA_TAXA")]
    [Serializable]
    public class TaxaONP : Persistent
    {
		#region Local Variables
		   
		private string _des_taxa;

        private Decimal _seq_taxa;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("des_taxa")]
        public string des_taxa
        {
            get
            {
                return _des_taxa;
            }
            set
            {
                _des_taxa = value;
            }
        }

        [PersistenceProperty("seq_taxa")]
        public Decimal seq_taxa
        {
            get
            {
                return _seq_taxa;
            }
            set
            {
                _seq_taxa = value;
            }
        }
					
		#endregion

    }
}

