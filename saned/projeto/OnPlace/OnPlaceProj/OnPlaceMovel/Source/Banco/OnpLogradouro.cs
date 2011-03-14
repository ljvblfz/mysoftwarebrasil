using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Logradouro")]
    public sealed class OnpLogradouro : PersistClass<OnpLogradouro> {
        #region Atributos
        private int? seqLogradouro;
        private string desLogradouro;
        #endregion

        #region Getters ans Setters (Fields)

        [Column( ColumnName = "seq_Logradouro", Pk = true)]
        public int? SeqLogradouro {
            get { return seqLogradouro; }
            set { seqLogradouro = value; }
        }
        [Column(ColumnName = "des_Logradouro")]
        public string DesLogradouro {
            get { return desLogradouro; }
            set { desLogradouro = value; }
        }
        #endregion

        public OnpLogradouro(int? seqLogradouro) {
            this.seqLogradouro = seqLogradouro;
            this.Materialize();
        }
        public OnpLogradouro() { }

        /// <summary>
        /// Pega a descrição do logradouro
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() {
            return this.DesLogradouro;
        }
        
        /// <summary>
        /// Verifica se Logradouro passado é igual ao Logradouro em questão
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj) {
            if (this.SeqLogradouro.Equals(((OnpLogradouro)obj).SeqLogradouro.Value))
                return true;
            return false;
        }

        /// <summary>
        /// Retorna o hashCode do objeto em questão
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
