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
    public class EtiniaAdapter
    {
        /// <summary>
        ///  Atualiza os dados de mebro
        /// </summary>
        /// <param name="model">modelo</param>
        public static void UpdateEtinia(Membro model)
        {
            new EtiniaRepository().Update(model.pessoa.perfil.etinia);
        }
    }
}