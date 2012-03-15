//
//  Copyright (c) 2009, WebAula S/A 
//  All rights reserved.
//
//  Authors: 
//               
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/          
//           Messenger: ivanpaulovich@hotmail.com 
//

using System.ComponentModel;

namespace Axis.Infrastructure.Order
{
    /// <summary>
    ///  Classe que responsavel pela ordenação
    /// </summary>
    public class OrderBy
    {
        /// <summary>
        ///  Objeto de ordenação
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        ///  Direção da ordenação
        /// </summary>
        public ListSortDirection SortDirection { get; set; }

        #region Construtors

        public OrderBy()
        {

        }

        public OrderBy(string member, ListSortDirection sortDirection)
        {
            this.Member = member;
            this.SortDirection = sortDirection;

        }
        #endregion

    }
}
