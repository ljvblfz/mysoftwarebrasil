using System;
using GDA;
using System.Runtime.Serialization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MENSAGEM_MOVIMENTO.
    /// </summary>
    [PersistenceClass("ONP_MENSAGEM_MOVIMENTO")]
    [Serializable]
    public class MensagemMovimentoONP : Persistent
    {
    	#region Local Variables

		    private int  _seq_mensagem_movimento;
            private int?  _seq_matricula;
            private int?  _seq_roteiro;
            private int?  _seq_grupo_fatura;
            private string  _des_mensagem_movimento;
            private DateTime?  _dat_inicio;
            private DateTime?  _dat_final;
            private int?  _seq_tipo_documento;

		#endregion

        #region Metodos
            [PersistenceProperty("seq_mensagem_movimento", PersistenceParameterType.Key)]
            public int seq_mensagem_movimento
            {
	            get
	            {
		            return _seq_mensagem_movimento;
	            }
	            set
	            {
		            _seq_mensagem_movimento = value;
	            }

            }

            [PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
            public int? seq_matricula
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

            [PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
            public int? seq_roteiro
            {
	            get
	            {
		            return _seq_roteiro;
	            }
	            set
	            {
		            _seq_roteiro = value;
	            }

            }

            [PersistenceProperty("seq_grupo_fatura", PersistenceParameterType.Key)]
            public int? seq_grupo_fatura
            {
	            get
	            {
		            return _seq_grupo_fatura;
	            }
	            set
	            {
		            _seq_grupo_fatura = value;
	            }

            }

            [PersistenceProperty("des_mensagem_movimento")]
            public string des_mensagem_movimento
            {
	            get
	            {
		            return _des_mensagem_movimento;
	            }
	            set
	            {
		            _des_mensagem_movimento = value;
	            }

            }

            [PersistenceProperty("dat_inicio")]
            public DateTime? dat_inicio
            {
	            get
	            {
		            return _dat_inicio;
	            }
	            set
	            {
		            _dat_inicio = value;
	            }

            }

            [PersistenceProperty("dat_final")]
            public DateTime? dat_final
            {
	            get
	            {
		            return _dat_final;
	            }
	            set
	            {
		            _dat_final = value;
	            }

            }

            [PersistenceProperty("seq_tipo_documento")]
            public int? seq_tipo_documento
            {
	            get
	            {
		            return _seq_tipo_documento;
	            }
	            set
	            {
		            _seq_tipo_documento = value;
	            }

            }

        #endregion
    }
}
