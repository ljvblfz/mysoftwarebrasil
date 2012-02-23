using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using PontoEncontro.Domain;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.Linq;

namespace PontoEncontro.Adapter
{
    public class MemberAdapter
    {
        public static Dynamic ListMember(FormCollection form)
        {
            var idCidade = 0;
            var idEstado = 0;
            int.TryParse(form["Idcidade"], out idCidade);
            int.TryParse(form["Idestado"], out idEstado);
            return new MembroRepository().ListMember(idEstado, idCidade);
        }
    }
}