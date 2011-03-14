using System;
using System.Collections.Generic;
using System.Text;
using Strategos.Api.Database.Impl;
using Strategos.Api.Database.Attributes;

namespace OnPlaceMovel.Source.Banco {
    [Table(TableName = "onp_Categoria")]
    public sealed class OnpCategoria : PersistClass<OnpCategoria> {
        #region Atributos
        private int? seqCategoria;
        private string desCategoria;
        #endregion

        #region Getters ans Setters (Fields)

        [Column(ColumnName = "seq_Categoria", Pk = true)]
        public int? SeqCategoria {
            get { return seqCategoria; }
            set { seqCategoria = value; }
        }
        [Column(ColumnName = "des_Categoria")]
        public string DesCategoria {
            get { return desCategoria; }
            set { desCategoria = value; }
        }
        #endregion

        public OnpCategoria(int seqCategoria) {
            this.seqCategoria = seqCategoria;
            this.Materialize();
        }
        public OnpCategoria() { }

        /// <summary>
        /// Pega a descrição da categoria
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() {
            return this.DesCategoria;
        }

        /// <summary>
        /// Verifica se Categoria passada é igual a Categoria em questão
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj) {
            if (this.SeqCategoria.Equals(((OnpCategoria)obj).SeqCategoria.Value))
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

    }
}
