using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;
using System.ComponentModel;

namespace Infrastructure.Models
{
    public class Perfil
    {
        #region properties

        [ScaffoldColumn(false)]
        public int perfilId { get; set; }

        [DisplayName("Altura")]
        public int perfilAltura { get; set; }

        [DisplayName("Peso")]
        public int perfilPeso { get; set; }

        [DisplayName("Fuma")]
        public bool perfilFumante { get; set; }

        [DisplayName("Bebe")]
        public bool perfilBebe { get; set; }

        [DisplayName("Interesse em conhecer")]
        [DataType(DataType.MultilineText)]
		public string pessoaInteresseConhecer { get; set; }

        [DisplayName("Fantasias")]
        [DataType(DataType.MultilineText)]
		public string pessoaFantasiasSexuais { get; set; }

        [DisplayName("Outros Interesses")]
        [DataType(DataType.MultilineText)]
        public string pessoaOutrosInteresses { get; set; }

        #endregion

        #region constructors

        public Perfil()
        {
        }

        public Perfil(dynamic entity)
        {
            this.perfilId = entity.perfilId;
            this.perfilAltura = entity.perfilAltura;
            this.perfilPeso = entity.perfilPeso;
            this.perfilFumante = entity.perfilFumante;
            this.perfilBebe = entity.perfilBebe;
            this.pessoaInteresseConhecer = entity.pessoaInteresseConhecer;
            this.pessoaFantasiasSexuais = entity.pessoaFantasiasSexuais;
            this.pessoaOutrosInteresses = entity.pessoaOutrosInteresses;
        }

        #endregion
    }
}
