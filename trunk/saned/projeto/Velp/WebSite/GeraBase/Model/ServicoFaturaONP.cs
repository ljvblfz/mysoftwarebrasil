using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela ONP_SERVICO_FATURA.
    /// </summary>
    [PersistenceClass("ONP_SERVICO_FATURA")]
    [PersistenceBaseDAO(typeof(ServicoFaturaDAO))]
    [Serializable]
    public class ServicoFaturaONP : Persistent
    {
        #region Local Variables
        private double _seq_matricula;
        private double _seq_item_servico;
        private string _cod_referencia;
        private double _seq_roteiro;
        private string _des_servico;
        private double? _seq_plano;
        private double? _seq_parcela;
        private double? _val_parcela;
        private string _ind_credito;
        private double? _val_diferenca_fatura;

        #endregion

        #region Metodos
        [PersistenceProperty("seq_matricula", PersistenceParameterType.Key)]
        public double seq_matricula { get; set; }

        [PersistenceProperty("seq_item_servico", PersistenceParameterType.Key)]
        public double seq_item_servico { get; set; }

        [PersistenceProperty("cod_referencia", PersistenceParameterType.Key)]
        public string cod_referencia { get; set; }

        [PersistenceProperty("seq_roteiro", PersistenceParameterType.Key)]
        public double seq_roteiro { get; set; }

        [PersistenceProperty("des_servico")]
        public string des_servico { get; set; }

        [PersistenceProperty("seq_plano")]
        public double? seq_plano { get; set; }

        [PersistenceProperty("seq_parcela")]
        public double? seq_parcela { get; set; }

        [PersistenceProperty("val_parcela")]
        public double? val_parcela { get; set; }

        [PersistenceProperty("ind_credito")]
        public string ind_credito { get; set; }

        [PersistenceProperty("val_diferenca_fatura")]
        public double? val_diferenca_fatura { get; set; }


        #endregion
    }
}