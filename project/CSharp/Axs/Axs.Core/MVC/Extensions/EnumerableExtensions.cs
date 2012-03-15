using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using Axis.Infrastructure.Linq;

namespace Lms.API.Infrastructure.MVC.Extensions
{
    /// <summary>
    ///  Classe de extensão a enumerações
    /// </summary>
    public class EnumerableExtensions
    {

        /// <summary> 
        ///  Cria um SelectListItem
        /// </summary> 
        /// <param name="text">nome da propriedade a ser o texto</param> 
        /// <param name="value">nome da propriedade a ser valor</param> 
        /// <param name="entity">entidade (modelView)</param> 
        /// <returns>lista de selectItens do ASP.NET MVC</returns> 
        public static IEnumerable<SelectListItem> CreateSelectListItem<TSouce>(IList<TSouce> list, Func<TSouce, object> text, Func<TSouce, object> value, int selectValue = 0)
        {
            // Utiliza linq para criar o objeto (dispendando o uso de um forreach) 
            return list.Select(
                                s => new SelectListItem()
                                {
                                    // Seta o text propriedade do objeto que e o text do <select> 
                                    Text = LambdaExpressionBase.GetValue(s, text).ToString(),

                                    // Seta o value propriedade do objeto que e o value do <select> 
                                    Value = LambdaExpressionBase.GetValue(s, value).ToString(),

                                    // verifica se o objeto e o que foi selecionado <select> 
                                    Selected = (LambdaExpressionBase.GetValue(s, value).ToString() == selectValue.ToString())

                                }).AsEnumerable<SelectListItem>();
         }
    }
}
