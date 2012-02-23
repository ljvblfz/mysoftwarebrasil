﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections;
using PontoEncontro.Infrastructure.Linq;

namespace PontoEncontro.Models
{
    public class MemberModel
    {
        [UIHint("DropDown")]
        [Display(Name = "Estado")]
        public IEnumerable<SelectListItem> Idestado { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Cidade")]
        public IEnumerable<SelectListItem> Idcidade { get; set; }

        [UIHint("ListMembros")]
        public Dynamic membros { get; set; }

        public MemberModel()
        {
        }
    }
}