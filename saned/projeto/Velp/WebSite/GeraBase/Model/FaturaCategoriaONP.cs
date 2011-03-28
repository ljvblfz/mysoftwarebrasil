using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_FATURA_CATEGORIA.
    /// </summary>
    [PersistenceClass("ONP_FATURA_CATEGORIA")]
    [PersistenceBaseDAO(typeof(FaturaCategoriaONP))]
    [Serializable]
    public class FaturaCategoriaONP : Persistent
    {
        #region Local Variables

        private int _seq_categoria;
        private int? _seq_fatura;
        private string _cod_referencia;
        private int _seq_roteiro;
        private int _seq_matricula;
        private int _val_numero_economia;
        private int? _val_valor_faturado;

        #endregion

        #region Metodos 

        [PersistenceProperty("seq_categoria")]
        public int seq_categoria { get; set; }

        [PersistenceProperty("seq_fatura")]
        public int seq_fatura { get; set; }

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia { get; set; }

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("val_numero_economia")]
        public int val_numero_economia { get; set; }

        [PersistenceProperty("val_valor_faturado")]
        public int? val_valor_faturado { get; set; }


        #endregion
    }
}

