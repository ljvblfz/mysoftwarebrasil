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
using Telerik.Web.Mvc;

namespace Axis.Models
{
    public class MemberModel
    {
        [Display(Name = "Nome")]
        public string loginMembro { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Estado")]
        public IEnumerable<SelectListItem> Idestado { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Cidade")]
        public IEnumerable<SelectListItem> Idcidade { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Idade entre")]
        public IEnumerable<SelectListItem> Age { get; set; }

        [Display(Name = "Ultima atualização")]
        public bool LastUpdate { get; set; }

        [Display(Name = "Ultimo acesso")]
        public bool LastAccessed { get; set; }

        [UIHint("ListMembros")]
        public GridModel<Axis.Domain.Membro> Membros { get; set; }

        public MemberModel()
        {
        }

        public MemberModel(Membro membro)
        {
            Mapper.CreateMap<Membro, MemberModel>();
            Mapper.Map(membro, this, typeof(Membro), typeof(MemberModel));
        }
    }
}