using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_PARAMETRO_RETENCAO.
    /// </summary>
    [PersistenceClass("IDA_PARAMETRO_RETENCAO")]
    [Serializable]
    public class ParametroRentencaoONP : Persistent
    {
		#region Local Variables

        private Decimal _val_media_inicial;

        private Decimal _val_media_final;

        private Decimal? _val_variacao_aviso;

        private Decimal? _val_variacao_retencao;
		   
		private string _ind_unidade_variacao;
		   
		private string _ind_retencao;

        private Decimal _seq_faixa;
					
		#endregion
		
		#region Local Metodos
				
		[PersistenceProperty("val_media_inicial")]
        public Decimal val_media_inicial
        {
            get
            {
                return _val_media_inicial;
            }
            set
            {
                _val_media_inicial = value;
            }
        }
					
		[PersistenceProperty("val_media_final")]
        public Decimal val_media_final
        {
            get
            {
                return _val_media_final;
            }
            set
            {
                _val_media_final = value;
            }
        }
					
		[PersistenceProperty("val_variacao_aviso")]
        public Decimal? val_variacao_aviso
        {
            get
            {
                return _val_variacao_aviso;
            }
            set
            {
                _val_variacao_aviso = value;
            }
        }
					
		[PersistenceProperty("val_variacao_retencao")]
        public Decimal? val_variacao_retencao
        {
            get
            {
                return _val_variacao_retencao;
            }
            set
            {
                _val_variacao_retencao = value;
            }
        }

        [PersistenceProperty("ind_unidade_variacao")]
        public string ind_unidade_variacao
        {
            get
            {
                return _ind_unidade_variacao;
            }
            set
            {
                _ind_unidade_variacao = value;
            }
        }

        [PersistenceProperty("ind_retencao")]
        public string ind_retencao
        {
            get
            {
                return _ind_retencao;
            }
            set
            {
                _ind_retencao = value;
            }
        }

        [PersistenceProperty("seq_faixa")]
        public Decimal seq_faixa
        {
            get
            {
                return _seq_faixa;
            }
            set
            {
                _seq_faixa = value;
            }
        }
					
		#endregion

    }
}

