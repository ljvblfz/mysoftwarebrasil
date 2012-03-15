using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.Mvc;

namespace Axis.Infrastructure.Order
{
    /// <summary>
    ///  Classe responsavel por manipular os objetos order do telerik
    /// </summary>
    public class OrderTelerik
    {
        /// <summary>
        ///  Carrega uma lista de objetos order da aplicação apartir de um objeto grid de pesquisa do telerik
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static IList<OrderBy> ChangeOrder(GridCommand command)
        {
            IList<OrderBy> orderBy = new List<OrderBy>();
            foreach (var item in command.SortDescriptors)
            {
                orderBy.Add(
                    new OrderBy()
                    {
                        Member = item.Member,
                        SortDirection = item.SortDirection
                    });
            }
            return orderBy;
        }
    }
}
