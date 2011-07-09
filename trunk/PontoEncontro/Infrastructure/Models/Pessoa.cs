//

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
    public class Pessoa
    {
        #region properties

        [ScaffoldColumn(false)]
        public int pessoaId { get; set; }

        [DisplayName("Nome")]
        [Description("Digite seu nome")]
        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaNameStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaNameRequired")]
        public string pessoaName { get; set; }

        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaNascimentoRequired")]
        public DateTime pessoaNascimento { get; set; }

        [DisplayName("Profissão")]
        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaProfissaoStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaProfissaoRequired")]
        public string pessoaProfissao { get; set; }

        [DisplayName("Email")]
        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaEmailStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaEmailRequired")]
        public string pessoaEmail { get; set; }

        [DisplayName("MSN")]
        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "PessoapessoaMSNStringLength")]
        public string pessoaMSN { get; set; }

        [ScaffoldColumn(false)]
        public int sexoId { get; set; }

        [ScaffoldColumn(false)]
        public Sexo sexo { get; set; }

        [ScaffoldColumn(false)]
        public int olhosId { get; set; }

        [ScaffoldColumn(false)]
        public Olho olhos { get; set; }

        [ScaffoldColumn(false)]
        public int cabelosId { get; set; }

        [ScaffoldColumn(false)]
        public Cabelo cabelos { get; set; }

        [ScaffoldColumn(false)]
        public int etiniaId { get; set; }

        [ScaffoldColumn(false)]
        public Etinia etinia { get; set; }

        [ScaffoldColumn(false)]
        public int perfilId { get; set; }

        [ScaffoldColumn(false)]
        public Perfil perfil { get; set; }

        [ScaffoldColumn(false)]
        public int estadoCivilId { get; set; }

        [ScaffoldColumn(false)]
        public EstadoCivil estadoCivil { get; set; }

        [ScaffoldColumn(false)]
        public int enderecoId { get; set; }

        [ScaffoldColumn(false)]
        public Endereco endereco { get; set; }

        #endregion

        #region constructors

        public Pessoa()
        {
        }

        public Pessoa(dynamic entity)
        {
            this.sexoId = entity.sexoId;
            if (entity.sexo != null)
                this.sexo = new Sexo(entity.sexo);
            this.olhosId = entity.olhosId;
            if (entity.olhos != null)
                this.olhos = new Olho(entity.olhos);
            this.cabelosId = entity.cabelosId;
            if (entity.cabelos != null)
                this.cabelos = new Cabelo(entity.cabelos);
            this.etiniaId = entity.etiniaId;
            if (entity.etinia != null)
                this.etinia = new Etinia(entity.etinia);
            this.perfilId = entity.perfilId;
            if (entity.perfil != null)
                this.perfil = new Perfil(entity.perfil);
            this.estadoCivilId = entity.estadoCivilId;
            if (entity.estadoCivil != null)
                this.estadoCivil = new EstadoCivil(entity.estadoCivil);
            this.enderecoId = entity.enderecoId;
            if (entity.endereco != null)
                this.endereco = new Endereco(entity.endereco);
            this.pessoaId = entity.pessoaId;
            this.pessoaName = entity.pessoaName;
            this.pessoaNascimento = entity.pessoaNascimento;
            this.pessoaProfissao = entity.pessoaProfissao;
            this.pessoaEmail = entity.pessoaEmail;
            this.pessoaMSN = entity.pessoaMSN;
        }

        #endregion

    }
}

