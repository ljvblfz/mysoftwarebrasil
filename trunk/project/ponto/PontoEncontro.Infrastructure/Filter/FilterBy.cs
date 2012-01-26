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

using PontoEncontro.Infrastructure.Enum;

namespace PontoEncontro.Infrastructure.Filter
{
    /// <summary>
    ///  Classe responsavel por amarzenar os filtros de pesquisa
    /// </summary>
    public class FilterBy 
    {
        /// <summary>
        ///  Campo a ser filtrado
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        ///  Valor a ser utilizado no filtro
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        ///  Operador de comparação
        /// </summary>
        public string Operator { get; set; }

        #region Contrutors

        public FilterBy()
        {

        }

        public FilterBy(string member, LogicalOperator op, string value)
        {
            this.Member = member;
            this.Value = value;
            this.Operator =  op.ToString();
        }

        #endregion
    }
}
