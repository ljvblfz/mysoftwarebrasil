using System;
using System;
using GDA;
using System.Runtime.Serialization;
using Data.DAL;

namespace Data.Model
{
    public class FaturaServicoONP
    {
        #region Local Variables

        //private int _Grupo;
        private int _seq_fatura;
        private int _seq_item_servico;
        private string _cod_referencia;
        private int _seq_roteiro;
        private int _seq_matricula;
        private string _des_servico;
        private int _val_parcela;
        private string _ind_credito;

        #endregion

        #region Metodos

        [PersistenceProperty("seq_fatura")]
        public int seq_fatura { get; set; }

        [PersistenceProperty("seq_item_servico")]
        public int seq_item_servico { get; set; }

        [PersistenceProperty("cod_referencia")]
        public string cod_referencia { get; set; }

        [PersistenceProperty("seq_roteiro")]
        public int seq_roteiro { get; set; }

        [PersistenceProperty("seq_matricula")]
        public int seq_matricula { get; set; }

        [PersistenceProperty("des_servico")]
        public string des_servico { get; set; }

        [PersistenceProperty("val_parcela")]
        public int val_parcela { get; set; }

        [PersistenceProperty("ind_credito")]
        public string ind_credito { get; set; }

        #endregion
    }
}
