using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.Mvc;
using System.Collections;

namespace Axis.Infrastructure.MVC.Helper.Grid
{
    /// <summary>
    ///  Classe responsavel pelo grid do telerik
    /// </summary>
    public class GridTelerik<TSource> where TSource : class 
    {
        /// <summary>
        ///  Metodo que carrega o grid do telerik
        /// </summary>
        /// <typeparam name="T">Entidade da lista</typeparam>
        /// <param name="listObject">lista de dados</param>
        /// <param name="total">total de dados de todas as paginas</param>
        /// <returns>objeto de grid utilizado pela API telerik</returns>
        public static GridModel<TSource> MountGrid(TSource[] listObject, int total)
        {
            return new GridModel<TSource>
            {
                Data = listObject.ToArray(),
                Total = total
            };
        }
    }
}
