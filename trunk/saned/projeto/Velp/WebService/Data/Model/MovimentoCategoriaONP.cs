using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_MOVIMENTO_CATEGORIA.
    /// </summary>
    [PersistenceClass("ONP_MOVIMENTO_CATEGORIA")]
    [PersistenceBaseDAO(typeof(MovimentoCategoriaDAO))]
    [Serializable]
    public class MovimentoCategoriaONP : Persistent
    {
        #region Local Variables

        //private int _Grupo;
        private string _cod_referencia;
        private int _seq_roteiro;
        private int _seq_matricula;
        private int _seq_categoria;
        private int _val_numero_economia;
        private int? _val_valor_faturado;
        
        #endregion

        #region Metodos 

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia { get; set; }

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("seq_categoria")]
        public int seq_categoria { get; set; }

        [PersistenceProperty("val_numero_economia")]
        public int val_numero_economia { get; set; }

        [PersistenceProperty("val_valor_faturado")]
        public int? val_valor_faturado { get; set; }

        #endregion
    }
}

