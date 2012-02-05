using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PontoEncontro.Domain;

namespace PontoEncontro.Application
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
