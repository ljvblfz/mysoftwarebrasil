using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_OCORRENCIA.
    /// </summary>
    [PersistenceClass("IDA_OCORRENCIA")]
    [Serializable]
    public class OcorrenciaTONP : Persistent
    {
		#region Local Variables

        private int _cod_ocorrencia;
        private string _des_ocorrencia;
        private string _des_mensagem;
        private string _ind_grupo;
        private string _ind_leitura;
        private string _ind_consumo;
        private string _ind_emite;
					
		#endregion
		
		#region Local Metodos

        [PersistenceProperty("cod_ocorrencia")]
        public int cod_ocorrencia
        {
            get
            {
                return _cod_ocorrencia;
            }
            set
            {
                _cod_ocorrencia = value;
            }
        }

        [PersistenceProperty("des_ocorrencia")]
        public string des_ocorrencia
        {
            get
            {
                return _des_ocorrencia;
            }
            set
            {
                _des_ocorrencia = value;
            }
        }

        [PersistenceProperty("des_mensagem")]
        public string des_mensagem
        {
            get
            {
                return _des_mensagem;
            }
            set
            {
                _des_mensagem = value;
            }
        }

        [PersistenceProperty("ind_grupo")]
        public string ind_grupo
        {
            get
            {
                return _ind_grupo;
            }
            set
            {
                _ind_grupo = value;
            }
        }

        [PersistenceProperty("ind_leitura")]
        public string ind_leitura
        {
            get
            {
                return _ind_leitura;
            }
            set
            {
                _ind_leitura = value;
            }
        }

        [PersistenceProperty("ind_consumo")]
        public string ind_consumo
        {
            get
            {
                return _ind_consumo;
            }
            set
            {
                _ind_consumo = value;
            }
        }

        [PersistenceProperty("ind_emite")]
        public string ind_emite
        {
            get
            {
                return _ind_emite;
            }
            set
            {
                _ind_emite = value;
            }
        }
					
		#endregion

    }
}

