using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_AVISO_DEBITO.
    /// </summary>
    [PersistenceClass("ONP_AVISO_DEBITO")]
    [PersistenceBaseDAO(typeof(AvisoDebitoDAO))]
    [Serializable]
    public class AvisoDebito : Persistent
    {
    	#region Local Variables

		private int  _seq_matricula;
        private DateTime  _dat_emissao;
        private string  _ind_documento;
        private string  _ind_pagavel;
        private int? _val_quantidade_debito;
        private int?  _val_impressoes;
        private string  _ind_protocolado;
        private int? _seq_fatura;

		#endregion

		#region Metodos
		[PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
        public int seq_matricula
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
        [PersistenceProperty("dat_emissao")]
        public DateTime dat_emissao
	        {
		        get
		        {
			        return _dat_emissao;
		        }
		        set
		        {
			        _dat_emissao = value;
		        }

	        }
        [PersistenceProperty("ind_documento")]
        public string ind_documento
	        {
		        get
		        {
			        return _ind_documento;
		        }
		        set
		        {
			        _ind_documento = value;
		        }

	        }
        [PersistenceProperty("ind_pagavel")]
        public string ind_pagavel
	        {
		        get
		        {
			        return _ind_pagavel;
		        }
		        set
		        {
			        _ind_pagavel = value;
		        }

	        }
        [PersistenceProperty("val_quantidade_debito")]
        public int? val_quantidade_debito
	        {
		        get
		        {
			        return _val_quantidade_debito;
		        }
		        set
		        {
			        _val_quantidade_debito = value;
		        }

	        }
        [PersistenceProperty("val_impressoes")]
        public int? val_impressoes
	        {
		        get
		        {
			        return _val_impressoes;
		        }
		        set
		        {
			        _val_impressoes = value;
		        }

	        }
        [PersistenceProperty("ind_protocolado")]
        public string ind_protocolado
	        {
		        get
		        {
			        return _ind_protocolado;
		        }
		        set
		        {
			        _ind_protocolado = value;
		        }

	        }
        [PersistenceProperty("seq_fatura", PersistenceParameterType.Key)]
        public int? seq_fatura
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

		#endregion
    }
}