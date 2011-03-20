using System;
using GDA;
using System.Runtime.Serialization;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MATRICULA.
    /// </summary>
    [PersistenceClass("ONP_MATRICULA")]
    [Serializable]
    public class MatriculaONP : Persistent
    {
        private int     _seq_matricula;
        private int     _seq_rota;
        private int     _seq_leitura;
        private int     _seq_logradouro;
        private int     _seq_utilizacao_ligacao;
        private int     _seq_zona_abastecimento;
        private int     _val_numero_imovel;
        private string  _des_inscricao;
        private string  _des_complemento;
        private string  _nom_cliente;
        private string _ind_processado;
        private string _ind_impresso;

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("seq_rota")]
        public int seq_rota { get; set; }

        [PersistenceProperty("seq_leitura")]
        public int seq_leitura { get; set; }

        [PersistenceProperty("seq_logradouro")]
        public int seq_logradouro { get; set; }

        [PersistenceProperty("val_numero_imovel")]
        public int val_numero_imovel { get; set; }

        [PersistenceProperty("seq_utilizacao_ligacao")]
        public int seq_utilizacao_ligacao { get; set; }

        [PersistenceProperty("seq_zona_abastecimento")]
        public int seq_zona_abastecimento { get; set; }

        [PersistenceProperty("des_inscricao")]
        public string des_inscricao { get; set; }

        [PersistenceProperty("des_complemento")]
        public string des_complemento { get; set; }

        [PersistenceProperty("nom_cliente")]
        public string nom_cliente { get; set; }

        [PersistenceProperty("ind_processado")]
        public string ind_processado { get; set; }

        [PersistenceProperty("ind_impresso")]
        public string ind_impresso { get; set; }

    }
}

