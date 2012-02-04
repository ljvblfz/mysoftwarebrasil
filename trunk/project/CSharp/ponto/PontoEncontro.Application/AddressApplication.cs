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
        public static IList<Estado> GetListState()
        {
            return new PontoEncontro.Domain.EstadoRepository().ListAll();
        }

        public static IList<Cidade> GetListCity()
        {
            return new PontoEncontro.Domain.CidadeRepository().ListAll();
        }
    }
}
