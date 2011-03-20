using System;
using GDA;
using System.Runtime.Serialization;
using GeraBase.DAL;

namespace GeraBase.Model
{
    /// <summary>
    /// Classe que representa a tabela IDA_DISTRIBUICAO.
    /// </summary>
    [PersistenceClass("IDA_DISTRIBUICAO")]
    [PersistenceBaseDAO(typeof(DistribuicaoGridDAO))]
    [Serializable]
    public class DistribuicaoGrid : Persistent
    {
        #region Local Variables

        private int _Quantidade_Roteiro;
        private int _Quantidade_Descarga;
        private int _Quantidade_Distribuido;
        private int _Grupo;
        private string _Situacao;

        #endregion

        #region Metodos

        [PersistenceProperty("Quantidade_Roteiro")]
        public int Quantidade_Roteiro { get; set; }

        [PersistenceProperty("Quantidade_Descarga")]
        public int Quantidade_Descarga { get; set; }

        [PersistenceProperty("Quantidade_Distribuido")]
        public int Quantidade_Distribuido { get; set; }

        [PersistenceProperty("Grupo")]
        public int Grupo { get; set; }

        [PersistenceProperty("Situacao")]
        public string Situacao { get; set; }

        #endregion

        //#region Propriedades Extended

        //[PersistenceProperty("Situacao", DirectionParameter.InputOptional)]
        //public string LabelSituacao
        //{
        //    get { return _Situacao == "L" ? "Liberada" : "Bloqueada"; }
        //    set { _Situacao = value; }
        //}

        //#endregion
    }
}
