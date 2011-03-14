using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA_DIADEMA.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA_DIADEMA")]
    [PersistenceBaseDAO(typeof(MatriculaDiademaONP))]
    [Serializable]
    public class MatriculaDiademaONP : Persistent
    {
        #region Local Variables

        private int _seq_matricula;
		private int? _seq_matricula_pai;
		private int _val_fraudes;
        private int _seq_desconto;
        private int _val_dias_bloqueio_anterior; 
		private int _val_dias_bloqueio_atual;
        private string _ind_cachorro;
        private string _ind_corta_ligacao;
        private string _ind_retencao_impostos;
        private string _ind_bloqueio;
        private int _ind_tipo_consumidor;
        private string _ind_calcula_fatura;
        private string _ind_emite_fatura; 
		private string _des_mensagem_1; 
		private string _des_mensagem_2;
        private DateTime? _dat_bloqueio;
        
        #endregion

        #region Metodos 

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("seq_matricula_pai")]
        public int? seq_matricula_pai { get; set; }

        [PersistenceProperty("val_fraudes")]
        public int val_fraudes { get; set; }

        [PersistenceProperty("seq_desconto")]
        public int seq_desconto { get; set; }

        [PersistenceProperty("val_dias_bloqueio_anterior")]
        public int val_dias_bloqueio_anterior { get; set; }

        [PersistenceProperty("val_dias_bloqueio_atual")]
        public int val_dias_bloqueio_atual { get; set; }

        [PersistenceProperty("ind_cachorro")]
        public string ind_cachorro { get; set; }

        [PersistenceProperty("ind_corta_ligacao")]
        public string ind_corta_ligacao { get; set; }

        [PersistenceProperty("ind_retencao_impostos")]
        public string ind_retencao_impostos { get; set; }

        [PersistenceProperty("ind_bloqueio")]
        public string ind_bloqueio { get; set; }

        [PersistenceProperty("ind_tipo_consumidor")]
        public int ind_tipo_consumidor { get; set; }

        [PersistenceProperty("ind_calcula_fatura")]
        public string ind_calcula_fatura { get; set; }

        [PersistenceProperty("ind_emite_fatura")]
        public string ind_emite_fatura { get; set; }

        [PersistenceProperty("des_mensagem_1")]
        public string des_mensagem_1 { get; set; }

        [PersistenceProperty("des_mensagem_2")]
        public string des_mensagem_2 { get; set; }

        [PersistenceProperty("dat_bloqueio")]
        public DateTime? dat_bloqueio { get; set; }

        #endregion
    }
}

