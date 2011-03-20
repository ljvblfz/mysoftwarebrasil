using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_UTILIZACAO_LIGACAO.
    /// </summary>
    [PersistenceClass("ONP_UTILIZACAO_LIGACAO")]
    [PersistenceBaseDAO(typeof(UtilizacaoLigacaoDAO))]
    [Serializable]
    public class UtilizacaoLigacaoONP : Persistent
    {
    	#region Local Variables

        private double  _seq_utilizacao_ligacao;
        private string  _des_utilizacao_ligacao;

		#endregion

		#region Metodos

        /// <summary>
        ///  
        /// </summary>
		[PersistenceProperty("seq_utilizacao_ligacao", PersistenceParameterType.Key)]
        public double seq_utilizacao_ligacao 
		{
			get
			{
				return _seq_utilizacao_ligacao;
			}
			set
			{
				_seq_utilizacao_ligacao = value;
			}
        }

        /// <summary>
        /// 
        /// </summary>
        [PersistenceProperty("des_utilizacao_ligacao")]
        public string des_utilizacao_ligacao
        {
            get
            {
                return _des_utilizacao_ligacao;
            }
            set
            {
                _des_utilizacao_ligacao = value;
            }
        }

		#endregion
    }
}