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
namespace PontoEncontro.Infrastructure.Enum
{
    /// <summary>
    ///  Enumerador de operadores logicos
    /// </summary>
    public enum LogicalOperator
    {
        /// <summary>
        ///  Igual a 
        /// </summary>
        IsEqualTo,

        /// <summary>
        ///  Contem parte (equivalente a um like %item%)
        /// </summary>
        Contains,

        /// <summary>
        ///  Contem inicio (equivalente a um Like %item)
        /// </summary>
        StartsWith,

        /// <summary>
        ///  Contem fim (equivalente a um Like item%)
        /// </summary>
        EndsWith,

        /// <summary>
        ///  Maior o igual que
        /// </summary>
        IsGreaterThanOrEqualTo,

        /// <summary>
        ///  Maior que
        /// </summary>
        IsGreaterThan,

        /// <summary>
        ///  Menor o igual que
        /// </summary>
        IsLessThanOrEqualTo,

        /// <summary>
        ///  Menor que
        /// </summary>
        IsLessThan,

        /// <summary>
        ///  Não e igual a 
        /// </summary>
        IsNotEqualTo,

        /// <summary>
        ///  Contem um item (equivalente a um in(,,,,))
        /// </summary>
        IsContainedIn
    }
}
