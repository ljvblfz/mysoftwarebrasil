using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela VOLTA_ALTERACAO.
    /// </summary>
    [PersistenceClass("VOLTA_ALTERACAO")]
    [PersistenceBaseDAO(typeof(VoltaAlteracaoDAO))]
    [Serializable]
    public class VoltaAlteracao : Persistent
    {
        #region Local Variables
        private int _Grupo;
        private int _CDC;
        private int? _Numero_Imovel;
        private string _Complemento;
        private string _Medidor;
        private string _Nome_Consumidor;
        private string _observacao;
        private DateTime _referencia;

        #endregion

        #region Metodos
        [PersistenceProperty("Grupo", PersistenceParameterType.Key)]
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
        [PersistenceProperty("Numero_Imovel")]
        public int? Numero_Imovel
        {
            get
            {
                return _Numero_Imovel;
            }
            set
            {
                _Numero_Imovel = value;
            }

        }
        [PersistenceProperty("Complemento")]
        public string Complemento
        {
            get
            {
                return _Complemento;
            }
            set
            {
                _Complemento = value;
            }

        }
        [PersistenceProperty("Medidor")]
        public string Medidor
        {
            get
            {
                return _Medidor;
            }
            set
            {
                _Medidor = value;
            }

        }
        [PersistenceProperty("Nome_Consumidor")]
        public string Nome_Consumidor
        {
            get
            {
                return _Nome_Consumidor;
            }
            set
            {
                _Nome_Consumidor = value;
            }

        }
        [PersistenceProperty("observacao")]
        public string observacao
        {
            get
            {
                return _observacao;
            }
            set
            {
                _observacao = value;
            }

        }
        [PersistenceProperty("referencia", PersistenceParameterType.Key)]
        public DateTime referencia
        {
            get
            {
                return _referencia;
            }
            set
            {
                _referencia = value;
            }

        }

        #endregion
    }
}