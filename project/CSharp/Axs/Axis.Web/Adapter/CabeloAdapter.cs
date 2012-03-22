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
    ///  Adaptador de cabelo
    /// </summary>
    public class CabeloAdapter
    {
        /// <summary>
        ///  Atualiza os dados de cabelo
        /// </summary>
        /// <param name="model">modelo</param>
        public static void UpdateCabelo(Membro model)
        {
            new CabeloRepository().Update(model.pessoa.perfil.cabelo);
        }
    }
}