using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_LOGRADOUROS.
    /// </summary>
    [PersistenceClass("IDA_LOGRADOUROS")]
    [PersistenceBaseDAO(typeof(LogradouroIDADAO))]
    [Serializable]
    public class LogradouroIDA : Persistent
    {
    	#region Local Variables
		private int  _Grupo;
        private int  _Codigo;
        private string  _Nome;

		#endregion

		#region Metodos
		[PersistenceProperty("Grupo")]
        public int Grupo { get; set; }

        [PersistenceProperty("Codigo")]
        public int Codigo { get; set; }

        [PersistenceProperty("Nome")]
        public string Nome { get; set; }


		#endregion
    }
}