﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Axis.Domain;

namespace Axis.Application
{
    /// <summary>
    ///  Serviço de endereço
    /// </summary>
    public class AddressApplication
    {
        /// <summary>
        ///  Lista todos os estados
        /// </summary>
        /// <returns></returns>
        public static IList<Estado> GetListState()
        {
            //new EstadoRepository().Save(Estado.List());
            //new CidadeRepository().Save(Cidade.List());
            return new EstadoRepository().ListAll();
        }

        /// <summary>
        ///  Lista todas as cidades do estaodo
        /// </summary>
        /// <param name="idState"></param>
        /// <returns></returns>
        public static IList<Cidade> GetListCity(int idState)
        {
            return new CidadeRepository().GetListCity(idState);
        }
    }
}
