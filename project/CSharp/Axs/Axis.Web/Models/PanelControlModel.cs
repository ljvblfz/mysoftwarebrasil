using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections;
using Axis.Infrastructure.Linq;
using Axis.Domain;
using AutoMapper;
using Axis.Adapter;
using Lms.API.Infrastructure.MVC.Extensions;

namespace Axis.Models
{
    public class PanelControlModel
    {
        public int idPerfil { get; set; }
        public int idEndereco { get; set; }

        [Display(Name = "Nome")]
        public string loginMembro { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Seu nome")]
        public string nomePessoa { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string e_MailPessoa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public DateTime nascimentoPessoa { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Estado")]
        public IEnumerable<SelectListItem> Idestado { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Cidade")]
        public IEnumerable<SelectListItem> Idcidade { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Sexo")]
        public IEnumerable<SelectListItem> idSexo { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Olhos")]
        public IEnumerable<SelectListItem> idOlho { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Cabelo")]
        public IEnumerable<SelectListItem> idCabelo { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Etnia")]
        public IEnumerable<SelectListItem> idEtinia { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Estado civil")]
        public IEnumerable<SelectListItem> idEstadoCivil { get; set; }

       
        public PanelControlModel()
        {
        }

        public PanelControlModel(Membro membro)
        {
            Mapper.CreateMap<Membro, PanelControlModel>()
                  .ForMember(dest => dest.nomePessoa, org => org.MapFrom(x => x.pessoa.nomePessoa))
                  .ForMember(dest => dest.e_MailPessoa, org => org.MapFrom(x => x.pessoa.e_MailPessoa))
                  .ForMember(dest => dest.nascimentoPessoa, org => org.MapFrom(x => x.pessoa.nascimentoPessoa))
                  ;
            Mapper.Map(membro, this, typeof(Membro), typeof(PanelControlModel));

            this.Idestado = AddressAdapter.GetListState(membro.pessoa.perfil.endereco.cidade.idEstado);
            this.Idcidade = AddressAdapter.GetListCity(membro.pessoa.perfil.endereco.cidade.idEstado,
                                                        membro.pessoa.perfil.endereco.idCidade);
            this.idPerfil = membro.pessoa.perfil.idPerfil;
            this.idEndereco = membro.pessoa.perfil.idEndereco;
            this.idSexo = EnumerableExtensions.CreateSelectListItem<Sexo>(
                                new SexoRepository().ListAll(),
                                t => t.nameSexo,
                                v => v.idSexo,
                                membro.pessoa.perfil.idSexo);
            this.idOlho = EnumerableExtensions.CreateSelectListItem<Olho>(
                                new OlhoRepository().ListAll(),
                                t => t.nameOlho,
                                v => v.idOlho,
                                membro.pessoa.perfil.idOlho);
            this.idEtinia = EnumerableExtensions.CreateSelectListItem<Etinia>(
                                new EtiniaRepository().ListAll(),
                                t => t.nameEtinia,
                                v => v.idEtinia,
                                membro.pessoa.perfil.idEtinia);
            this.idEstadoCivil = EnumerableExtensions.CreateSelectListItem<EstadoCivil>(
                                new EstadocivilRepository().ListAll(),
                                t => t.nameEstadoCivil,
                                v => v.idEstadoCivil,
                                membro.pessoa.perfil.idEstadoCivil);
            this.idCabelo = EnumerableExtensions.CreateSelectListItem<Cabelo>(
                                new CabeloRepository().ListAll(),
                                t => t.nameCabelo,
                                v => v.idCabelo,
                                membro.pessoa.perfil.idCabelo); 
        }
    }
}