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

using System.Web.Mvc;

namespace PontoEncontro.Infrastructure.MVC.Extensions
{

    /// <summary>
    /// Extensão HTML
    /// </summary>
    public static class LabelExtensions
    {

        /// <summary>
        /// Localiza um texto para o idioma em execução da aplicação
        /// </summary>
        /// <param name="html">Referência ao próprio objeto</param>
        /// <param name="text">ID da mensagem a ser globalizada</param>
        /// <returns>String com o texto globalizado</returns>
        public static MvcHtmlString Localize(this HtmlHelper html, string text)
        {

            string expression = PontoEncontro.Infrastructure.Globalizator.Localize(text);

            return MvcHtmlString.Create(expression);

        }
    }
}