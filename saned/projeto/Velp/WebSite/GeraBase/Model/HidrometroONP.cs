using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_HIDROMETRO.
    /// </summary>
    [PersistenceClass("ONP_HIDROMETRO")]
    [PersistenceBaseDAO(typeof(HidrometroDAO))]
    [Serializable]
    public class HidrometroONP : Persistent
    {
        private string      _cod_hidrometro;
        private int         _seq_matricula;
        private int         _seq_local;
        private int      _cod_marca;
        private int         _seq_tamanho_hidrometro;
        private int         _val_numero_digitos;
        private int         _seq_diametro_ligacao;
        private DateTime?    _dat_fabricacao;
        private DateTime?    _dat_aquisicao;
        private string      _des_classe;


        [PersistenceProperty("cod_hidrometro")]
        public string cod_hidrometro { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("seq_local")]
        public int seq_local { get; set; }

        [PersistenceProperty("cod_marca")]
        public int cod_marca { get; set; }

        [PersistenceProperty("seq_tamanho_hidrometro")]
        public int seq_tamanho_hidrometro { get; set; }

        [PersistenceProperty("val_numero_digitos")]
        public int val_numero_digitos { get; set; }

        [PersistenceProperty("seq_diametro_ligacao")]
        public int seq_diametro_ligacao { get; set; }

        [PersistenceProperty("dat_fabricacao")]
        public DateTime? dat_fabricacao { get; set; }

        [PersistenceProperty("dat_aquisicao")]
        public DateTime? dat_aquisicao { get; set; }

        [PersistenceProperty("des_classe")]
        public string des_classe { get; set; }

    }
}


