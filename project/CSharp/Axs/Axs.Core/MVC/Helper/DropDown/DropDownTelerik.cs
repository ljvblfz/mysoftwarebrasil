using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Telerik.Web.Mvc.UI;
using System.Collections;
using Telerik.Web.Mvc.UI.Fluent;
using Axis.Infrastructure.MVC.DataAnnotations;

namespace Axis.Infrastructure.MVC.Helper.DropDown
{
    /// <summary>
    ///  Classe Helper que cria um DropDown Defaut configurado
    /// </summary>
    public static class DropDownTemplate
    {
        /// <summary>
        ///  Metodo que cria um DropDown
        ///     Forma de executar-lo pela view:
        ///     
        /// @(Html.Telerik().ComboBox()
        ///    .Name(ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(""))
        ///    .AutoFill(true)
        ///    .BindTo(new SelectList(Lms.Adapter.Security.ActionAdapter.ListAll(),
        ///        "ActionId", "Name", Model))
        /// 
        /// </summary>
        /// <typeparam name="TModel">model da view correspondente</typeparam>
        /// <param name="htmlHelper">objeto http do MVC</param>
        /// <param name="Model">Array de itens a carregar</param>
        /// <returns>objeto bilder do telerick</returns>
        public static ComboBoxBuilder CreateDropDown<TModel>(this HtmlHelper<TModel> htmlHelper,TModel itensModel)
        {

            // Objeto telerick 
            var dropDown = HtmlHelperExtension.Telerik<TModel>(htmlHelper).ComboBox();
            
            // Recupera o nome da propriedade para setar o name no HTML
            var dropDownAttribute = (DropDownAttribute)htmlHelper.ViewData.ModelMetadata.AdditionalValues["DropDownAttribute"];
            dropDown.Name(dropDownAttribute.NameProperty);
            dropDown.AutoFill(true);

            if (itensModel != null)
                dropDown.BindTo((IEnumerable<SelectListItem>)itensModel);

            return dropDown;
        }
    }
}
