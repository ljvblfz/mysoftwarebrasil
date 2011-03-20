using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_REFERENCIA_PENDENTE.
    /// </summary>
    [PersistenceClass("ONP_REFERENCIA_PENDENTE")]
    [PersistenceBaseDAO(typeof(ReferenciaPendenteDAO))]
    [Serializable]
    public class ReferenciaPendenteONP : Persistent
    {
    	#region Local Variables
		private double  _seq_matricula;
        private double  _seq_fatura;
        private DateTime  _dat_vencimento;

		#endregion

		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
        public double seq_matricula
	        {
		        get
		        {
			        return _seq_matricula;
		        }
		        set
		        {
			        _seq_matricula = value;
		        }

	        }
        [PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
        public double seq_fatura
	        {
		        get
		        {
			        return _seq_fatura;
		        }
		        set
		        {
			        _seq_fatura = value;
		        }

	        }
        [PersistenceProperty("dat_vencimento")]
        public DateTime dat_vencimento
	        {
		        get
		        {
			        return _dat_vencimento;
		        }
		        set
		        {
			        _dat_vencimento = value;
		        }

	        }

		#endregion
    }
}