//
//  Copyright (c) 2011, WebAula S/A 
//  All rights reserved.
//
//  Authors: 
//               
//           * Alexis Moura (alexismoura@gmail.com)
//           Blog: http://alexisti.blogspot.com          
//           Messenger: alexismoura@hotmail.com 
//
				
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.Mvc;
using Axis.Infrastructure.Enum;

namespace Axis.Infrastructure.Filter
{
    /// <summary>
    ///  Classe responsavel por trabalhar com os filtros da API Telerik
    /// </summary>
    public class FilterTelerik
    {
        /// <summary>
        ///  Carrega o objeto de filtros atraves do grid de pesquisa
        /// </summary>
        /// <param name="command">grid de pesquisa do telerik</param>
        /// <returns>Lista comos filtros da Aplicação</returns>
        public static IList<FilterBy> ChangeFilter(GridCommand command)
        {
            List<FilterBy> filter = new List<FilterBy>();
            foreach (Telerik.Web.Mvc.FilterDescriptor item in GetFilters(command.FilterDescriptors))
            {
                filter.Add(
                    new FilterBy()
                    {
                        Member = item.Member,
                        Operator = ConvertFrom(item.Operator).ToString(),
                        Value = item.ConvertedValue
                    });
            }

            return filter;
        }

        /// <summary>
        ///  Recupera uma lista de filtros
        /// </summary>
        /// <param name="gridFilters">lista de objeto IFilterDescriptor</param>
        /// <returns>lista de objetos IFilterDescriptor</returns>
        public static IList<IFilterDescriptor> GetFilters(IList<IFilterDescriptor> gridFilters)
        {
            List<IFilterDescriptor> filters = new List<IFilterDescriptor>();

            foreach (var item in gridFilters)
            {
                var compItem = item as CompositeFilterDescriptor;
                if (compItem != null)
                    filters.AddRange(GetFilters(compItem.FilterDescriptors));

                var simpleItem = item as FilterDescriptor;
                if (simpleItem != null)
                    filters.Add(simpleItem);
            }

            return filters;
        }

        /// <summary>
        ///  Conveter o operador logico do telerik para operador logico da aplicação
        /// </summary>
        /// <param name="op">objeto operador do telerik</param>
        /// <returns>objeto contendo o operador logico da aplicação</returns>
        public static LogicalOperator ConvertFrom(FilterOperator op)
        {
            switch (op)
            {
                case FilterOperator.Contains:
                    return LogicalOperator.Contains;
                case FilterOperator.EndsWith:
                    return LogicalOperator.EndsWith;
                case FilterOperator.IsContainedIn:
                    return LogicalOperator.IsContainedIn;
                case FilterOperator.IsEqualTo:
                    return LogicalOperator.IsEqualTo;
                case FilterOperator.IsGreaterThan:
                    return LogicalOperator.IsGreaterThan;
                case FilterOperator.IsGreaterThanOrEqualTo:
                    return LogicalOperator.IsGreaterThanOrEqualTo;
                case FilterOperator.IsLessThan:
                    return LogicalOperator.IsLessThan;
                case FilterOperator.IsLessThanOrEqualTo:
                    return LogicalOperator.IsLessThanOrEqualTo;
                case FilterOperator.IsNotEqualTo:
                    return LogicalOperator.IsNotEqualTo;
                case FilterOperator.StartsWith:
                    return LogicalOperator.StartsWith;
                default:
                    return LogicalOperator.IsEqualTo;
            }
        }

    }
}
