using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ida_categoria.
    /// </summary>
    [PersistenceClass("ida_categoria")]
    [Serializable]
    public class CategoriaONP : Persistent
    {
		#region Local Variables
		   
		private string _des_categoria;

        private int _seq_categoria;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("des_categoria")]
        public string des_categoria
        {
            get
            {
                return _des_categoria;
            }
            set
            {
                _des_categoria = value;
            }
        }

        [PersistenceProperty("seq_categoria", PersistenceParameterType.Key)]
        public int seq_categoria
        {
            get
            {
                return _seq_categoria;
            }
            set
            {
                _seq_categoria = value;
            }
        }
					
		#endregion

    }
}

