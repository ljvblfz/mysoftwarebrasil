using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lms.API.Infrastructure.MVC.Extensions;
using PontoEncontro.Domain;
using PontoEncontro.Application;

namespace PontoEncontro.Adapter
{
    /// <summary>
    ///  Classe adaptadora de endereço
    /// </summary>
    public class AddressAdapter
    {
        /// <summary>
        ///  Retorna um select item de cidades
        /// </summary>
        /// <param name="idState">codigo do estado</param>
        /// <returns>select item de ciadades</returns>
        public static IEnumerable<SelectListItem> GetListCity(int idState, int selectValue = 0)
        {
            return EnumerableExtensions.CreateSelectListItem<Cidade>(
                    AddressApplication.GetListCity(idState),
                    t => t.nameCidade,
                    v => v.idCidade,
                    selectValue);
        }

        /// <summary>
        ///  Retorna um select item com todos os estados do brasil
        /// </summary>
        /// <returns>select item de estados</returns>
        public static IEnumerable<SelectListItem> GetListState(int selectValue = 0)
        {
            return EnumerableExtensions.CreateSelectListItem<Estado>(
                    AddressApplication.GetListState(), 
                    t => t.nameEstado, 
                    v => v.idEstado,
                    selectValue);
                
        }
    }
}