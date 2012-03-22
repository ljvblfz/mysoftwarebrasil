using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axis.Domain;
using Axis.Infrastructure;
using System.Web.Mvc;

namespace Axis.Adapter
{
    /// <summary>
    ///  Adaptador de segurança
    /// </summary>
    public class OlhoAdapter
    {
        /// <summary>
        ///  Atualiza os dados de mebro
        /// </summary>
        /// <param name="model">modelo</param>
        public static void UpdateOlho(Membro model)
        {
            new OlhoRepository().Update(model.pessoa.perfil.olho);
        }
    }
}