using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_PARAMETRO.
    /// </summary>
    [PersistenceClass("IDA_PARAMETRO")]
    [Serializable]
    public class ParametroONP : Persistent
    {
		#region Local Variables
		   
		private string _des_valor;
				
		private string _des_nome;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("des_valor")]
        public string des_valor
        {
            get
            {
                return _des_valor;
            }
            set
            {
                _des_valor = value;
            }
        }

        [PersistenceProperty("des_nome")]
        public string des_nome
        {
            get
            {
                return _des_nome;
            }
            set
            {
                _des_nome = value;
            }
        }
					
		#endregion

    }
}

