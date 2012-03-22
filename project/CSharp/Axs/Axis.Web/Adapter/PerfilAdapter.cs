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
    public class PerfilAdapter
    {
        /// <summary>
        ///  Atualiza os dados de Perfil
        /// </summary>
        /// <param name="model">modelo</param>
        public static void UpdatePerfil(Perfil perfil)
        {
            new PerfilRepository().Update(perfil);
        }
    }
}