using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewHelper
{
    /// <summary>
    ///  Classe responsavel por gerar a tela de pesquisa
    /// </summary>
    /// <typeparam name="Model">Model principal da pesquisa</typeparam>
    public class Find<Model> where Model : new()
    {
        /// <summary>
        ///  
        /// </summary>
        public string find;

        /// <summary>
        ///  XHTML dos filtros (tabela com os filtros escolhidos)
        /// </summary>
        public string filter;

        /// <summary>
        ///  XHTML dos campos (tabela com os dados dos campos escolhidos)
        /// </summary>
        public string field;

        public int pageRegistry{ get; set; }

        public int totalRegistry { get; set; }

        public List<Model> list;

        /// <summary>
        ///  Helper de pesquisa
        /// </summary>
        /// <param name="listModel">lista de dados</param>
        /// <param name="filters">filtros de pesquisa</param>
        /// <param name="fields">campos a serem retornados</param>
        /// <param name="links">links de redirecionamento</param>
        public void Set(List<Model> listModel, Dictionary<string, Dictionary<string, object>> filters, Dictionary<string, Dictionary<string, object>> fields, Dictionary<string, object> links)
        {
            list = listModel;
            filter = SearchFilter(filters);
            field = SearchField(fields);
            return;
        }

        /// <summary>
        ///  Metodo responsavel por o grid com os dados da pesquisa
        /// </summary>
        /// <param name="listModel">lista com os dados</param>
        /// <param name="fields">campos a serem retornados da pesquisa</param>
        /// <returns>html com o grid</returns>
        public string SearchField( Dictionary<string, Dictionary<string, object>> fields)
        {
            // html geral
            string xhtml = "";

            // html do cabeçalho
            string heder = "";

            // html do conteudo
            string content = "";

            // contador de linhas
            int contador = 0;

            // Percorre todos os dados
            foreach (Model itemModel in list)
            {  
                // intercala as cores de fundo
                string cor = contador % 2 == 0?"#FFFFFF":"#F4F4F4";

                // tag inicial da linha
                content += "<tr bgcolor=" + cor + "  onclick=\"location.href='{$link}'\" onMouseOver=\"this.style.background = '#CCC'\" onMouseOut=\"this.style.background = '" + cor + "'\">\n";

                // percorre todas as colunas
                foreach (KeyValuePair<string, Dictionary<string, object>> itemField in fields)
                {
                    // cria o cabeçalho (LOOP UNICO)
                    if (contador == 0)
                    {
                        heder += "<th  class=\"header\">\n";
                        heder += itemField.Value["name"].ToString();
                        heder += "</th>\n";
                    }

                    // valor da coluna
                    object value = itemModel.GetType().GetProperty(itemField.Key).GetValue(itemModel,null);
                    content += "<td>\n";
                    content += XForm<Model>.Label(itemField.Key, value, null);
                    content += "</td>\n";
                }
                // fecha a linha e incrementa o contador
                content += "</tr>\n";
                contador++;
            }
            
            // funde o html

            // Script da paginação
            xhtml += "<script type=\"text/javascript\"> \n";
            xhtml += "$(document).ready(function() { \n";
            xhtml += "$(\"#myTable\") \n";
            xhtml += "      .tablesorter({widthFixed: true, widgets: ['zebra']}) \n";
            xhtml += "      .tablesorterPager({container: $(\"#pager\")}); \n";
            xhtml += "}); \n";
            xhtml += "</script> \n";

            // Tabela
            xhtml += "\n<table id=\"myTable\" cellspacing=\"1\" cellpadding=\"0\" border=\"0\" class=\"tablesorter\" width=\"97%\">\n";
            xhtml += "<thead>\n";
            xhtml += "<tr>\n";
            xhtml += heder; // Cabeçalho
            xhtml += "</tr>\n";
            xhtml += "</thead>\n";
            xhtml += "</tbody>\n";
            xhtml += content; // Conteudo
            xhtml += "</table>\n";

            // Paginação da pesquisa
            xhtml += "<div id=\"pager\" class=\"pager\" style=\"position: inherit;\">";
            xhtml += "<form>";
            xhtml += "<img src=\"../../image/icons/first.png\" class=\"first\"/>";
            xhtml += "<img src=\"../../image/icons/prev.png\" class=\"prev\"/>";
            xhtml += "<input type=\"text\" class=\"pagedisplay\"/>";
            xhtml += "<img src=\"../../image/icons/next.png\" class=\"next\"/>";
            xhtml += "<img src=\"../../image/icons/last.png\" class=\"last\"/>";
            xhtml += "Nº de registros por página:";
            xhtml += "<select class=\"pagesize\">";
            xhtml += "<option selected=\"selected\"  value=\"10\">10</option>";
            xhtml += "<option value=\"20\">20</option>";
            xhtml += "<option value=\"30\">30</option>";
            xhtml += "<option  value=\"40\">40</option>";
            xhtml += "</select>";
            xhtml += "</form>";
            xhtml += "</div>";
            return xhtml;
        }

        /// <summary>
        ///  Cria os filtros de pesquisa
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public string SearchFilter(Dictionary<string, Dictionary<string, object>> filters)
        {
            string xhtml = "";           
            Dictionary<string, Dictionary<string, string>> logicOperatorsGroup = new Dictionary<string, Dictionary<string, string>>();
            logicOperatorsGroup = GetLogicOperatorsGroup();

            xhtml = "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
            xhtml += "<tbody>\n";
            int contador = 0;
            foreach (KeyValuePair<string, Dictionary<string, object>> itemFilter in filters)
            {
                string cor = contador%2==0?"#FFFFFF":"#F4F4F4";
                contador++;
                xhtml += "<tr bgcolor=\"" + cor + "\">\n";
                xhtml += "<td style=\"width:25%\">\n";
                xhtml += XForm<Model>.Label(itemFilter.Key, itemFilter.Value["descricao"],null);
                xhtml += "</td>\n";

                xhtml += GetOperaitor(itemFilter);
                xhtml += "<td style=\"width:30%\">";
                switch (itemFilter.Value["tipo_campo"].ToString().ToUpper())
                {
                    case "OPTION":
                        xhtml += XForm<Model>.Texbox(itemFilter.Key, null, new string[] { "style=\"width:95%\"" });
                    break;

                    case "RADIO":
                        xhtml += XForm<Model>.Texbox(itemFilter.Key, null, new string[] { "style=\"width:95%\"" });
                    break;

                    case "DATE":
                        xhtml += XForm<Model>.Texbox(itemFilter.Key, null, new string[] { "style=\"width:95%\"" });
                    break;

                    default: 
                        xhtml += XForm<Model>.Texbox(itemFilter.Key, null, new string[] { "style=\"width:95%\"" });
                    break;
                }
                xhtml += "</td>\n";
                xhtml += GetSensitiveCase(itemFilter);

                // fecha a linha da tabela
                xhtml += "</tr>\n";
            }
            xhtml += "</tbody>\n";
            xhtml += "</table>\n"; 

            // Tabela para submeter o formulário
            xhtml += "<table  cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
                xhtml += "<tbody>\n"; 
                    xhtml += "<tr>\n";
                        xhtml += "<td>\n";
                        xhtml += "<input type=\"submit\" value=\"Pesquisar\" />";
                        xhtml += "</td>\n"; 
                    xhtml += "</tr>\n";
                xhtml += "</tbody>\n";
            xhtml += "</table>\n";

            return xhtml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemFilter"></param>
        /// <returns></returns>
        public string GetSensitiveCase(KeyValuePair<string, Dictionary<string, object>> itemFilter)
        {
            string xhtml = "";
            if (itemFilter.Value["tipo_dado"].ToString() != "numerico")
            {
                xhtml += "<td style=\"width:20%\">";
                xhtml += XForm<Model>.Checkbox("ignoraCAb[" + itemFilter.Key + "]", false, new string[] { "class=\"radio\"" }) + "Ignorar CAb";
                xhtml += "</td>\n";
            }
            else
            {
                xhtml += "<td style=\"width:20%\">\n";
                xhtml += "</td>\n";
            }
            return xhtml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemFilter"></param>
        /// <returns></returns>
        public string GetOperaitor(KeyValuePair<string, Dictionary<string, object>> itemFilter)
        {
            Dictionary<string, Dictionary<string, string>> logicOperatorsGroup = new Dictionary<string, Dictionary<string, string>>();
            logicOperatorsGroup = GetLogicOperatorsGroup();
            string xhtml = "";

            xhtml += "<td style=\"width:25%\">\n";
            if (itemFilter.Value["tipo_dado"] != null)
            {
                switch (itemFilter.Value["tipo_dado"].ToString())
                {
                    case "string":
                        xhtml += XForm<Model>.Selectbox("operadorLogico[" + itemFilter.Key + "]", logicOperatorsGroup["string"], null, null);
                        break;

                    case "numerico":
                        xhtml += XForm<Model>.Selectbox("operadorLogico[" + itemFilter.Key + "]", logicOperatorsGroup["numerico"], null, null);
                        break;

                    case "option":
                        xhtml += XForm<Model>.Selectbox("operadorLogico[" + itemFilter.Key + "]", logicOperatorsGroup["option"], null, null);
                        break;

                    case "date":
                        xhtml += XForm<Model>.Selectbox("operadorLogico[" + itemFilter.Key + "]", logicOperatorsGroup["date"], null, null);
                        break;
                }
            }
            xhtml += "</td>\n";
            return xhtml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public string SearchPage(Dictionary<string, Dictionary<string, object>> fields)
        {
            string xhtml = "";
            object page = 0;
            object numPaginas = Math.Abs(list.Count / 10);
            object numTotalRegistros = list.Count;
            string pagination = "";
            /**
            * Inicio da paginação
            */
            pagination = "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
            pagination += "<tbody>\n";
            pagination += "<tr>\n";
            pagination += "<td height=\"24\">\n";

            //Número total de registros
            pagination += "<strong> N&deg; total de registros: </strong>" + numTotalRegistros;
            pagination += "</td>\n";

            //insere o conteúdo de pagination a variavel content
            pagination += "<td>\n";
            pagination += "<div class='pagination'>";

            pagination += "<span class='pagImg'>";
            pagination += "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/1'>";
            pagination += "<img border=\"0\" alt=\"Primeira p&aacute;gina\" title=\"Primeira p&aacute;gina\" src=\"{$this->view->baseUrl}/public/images/pag_primeira.gif\">\n";
            pagination += "</a>\n";
            pagination += "</span>\n";

            pagination += "<span class='pagImg'>";
            pagination += "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/{$anterior}'>";
            pagination += "<img border=\"0\" alt=\"P&aacute;gina anterior\" title=\"P&aacute;gina anterior\" src=\"{$this->view->baseUrl}/public/images/pag_anterior.gif\">\n";
            pagination += "</a>\n";
            pagination += "</span>\n";

            return xhtml;
        }

        /// <summary>
        ///  Metodo que recupera os filtros para a pesquisa
        /// </summary>
        /// <returns>um dicionary de dados com os filtros</returns>
        private Dictionary<string, Dictionary<string, string>> GetLogicOperatorsGroup()
        {
            Dictionary<string, string> logicOperators = new Dictionary<string, string>();
            logicOperators.Add("OPL_IGUAL", "igual a");
            logicOperators.Add("OPL_DIFERENTE", "diferente de");
            logicOperators.Add("OPL_MAIOR", "maior que");
            logicOperators.Add("OPL_MENOR", "menor que");
            logicOperators.Add("OPL_MAIOR_IGUAL", "maior ou igual a");
            logicOperators.Add("OPL_MENOR_IGUAL", "menor ou igual a");
            logicOperators.Add("OPL_ENTRE", "com valores entre");
            logicOperators.Add("OPL_VAZIO", "está vazio");
            logicOperators.Add("OPL_NAO_VAZIO", "não está vazio");
            logicOperators.Add("OPL_VALOR_LISTA", "valores da lista");
            logicOperators.Add("OPL_COMECANDO", "começando com");
            logicOperators.Add("OPL_TERMINANDO", "terminando com");
            logicOperators.Add("OPL_QUALQUER_LUGAR", "em qualquer lugar");

            Dictionary<string, string> numericoD = new Dictionary<string, string>();
            numericoD.Add("OPL_IGUAL", "igual a");
            numericoD.Add("OPL_DIFERENTE", "diferente de");
            numericoD.Add("OPL_MAIOR", "maior que");
            numericoD.Add("OPL_MENOR", "menor que");
            numericoD.Add("OPL_MAIOR_IGUAL", "maior ou igual a");
            numericoD.Add("OPL_MENOR_IGUAL", "menor ou igual a");
            numericoD.Add("OPL_ENTRE", "com valores entre");
            numericoD.Add("OPL_VAZIO", "está vazio");
            numericoD.Add("OPL_NAO_VAZIO", "não está vazio");
            numericoD.Add("OPL_VALOR_LISTA", "valores da lista");

            Dictionary<string, string> stringD = new Dictionary<string, string>();
            stringD.Add("OPL_IGUAL", "igual a");
            stringD.Add("OPL_DIFERENTE", "diferente de");
            stringD.Add("OPL_VAZIO", "está vazio");
            stringD.Add("OPL_NAO_VAZIO", "não está vazio");
            stringD.Add("OPL_COMECANDO", "começando com");
            stringD.Add("OPL_TERMINANDO", "terminando com");
            stringD.Add("OPL_QUALQUER_LUGAR", "em qualquer lugar");

            Dictionary<string, string> optionD = new Dictionary<string, string>();
            optionD.Add("OPL_DIFERENTE", "diferente de");
            optionD.Add("OPL_VAZIO", "está vazio");
            optionD.Add("OPL_NAO_VAZIO", "não está vazio");

            Dictionary<string, string> dateD = new Dictionary<string, string>();
            dateD.Add("OPL_IGUAL", "igual a");
            dateD.Add("OPL_MAIOR", "maior que");
            dateD.Add("OPL_MENOR", "menor que");
            dateD.Add("OPL_MAIOR_IGUAL", "maior ou igual a");
            dateD.Add("OPL_MENOR_IGUAL", "menor ou igual a");
            dateD.Add("OPL_ENTRE", "com valores entre");

            Dictionary<string, Dictionary<string, string>> logicOperatorsGroup = new Dictionary<string, Dictionary<string, string>>();
            logicOperatorsGroup.Add("date", dateD);
            logicOperatorsGroup.Add("string", stringD);
            logicOperatorsGroup.Add("option", optionD);
            logicOperatorsGroup.Add("numerico", numericoD);

            return logicOperatorsGroup;
        }

    }
}
