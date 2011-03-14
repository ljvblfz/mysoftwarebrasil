using System;
using GDA;
using System.Runtime.Serialization;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela VOLTA_LOG_ATENDIMENTO.
    /// </summary>
    [PersistenceClass("VOLTA_LOG_ATENDIMENTO")]
    [Serializable]
    public class VoltaLogAtendimento : Persistent
    {
        #region Local Variables
        private int _Grupo;
        private int _CDC;
        private string _Tipo;
        private DateTime? _Referencia;
        private DateTime _Data_Emissao;
        private int? _Operador;

        #endregion

        #region Metodos
        [PersistenceProperty("Grupo")]
        public int Grupo
        {
            get
            {
                return _Grupo;
            }
            set
            {
                _Grupo = value;
            }

        }
        [PersistenceProperty("CDC", PersistenceParameterType.Key)]
        public int CDC
        {
            get
            {
                return _CDC;
            }
            set
            {
                _CDC = value;
            }

        }
        [PersistenceProperty("Tipo")]
        public string Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                _Tipo = value;
            }

        }
        [PersistenceProperty("Referencia", PersistenceParameterType.Key)]
        public DateTime? Referencia
        {
            get
            {
                return _Referencia;
            }
            set
            {
                _Referencia = value;
            }

        }
        [PersistenceProperty("Data_Emissao")]
        public DateTime Data_Emissao
        {
            get
            {
                return _Data_Emissao;
            }
            set
            {
                _Data_Emissao = value;
            }

        }
        [PersistenceProperty("Operador")]
        public int? Operador
        {
            get
            {
                return _Operador;
            }
            set
            {
                _Operador = value;
            }

        }

        #endregion
    }
}

