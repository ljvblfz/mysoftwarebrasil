using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewHelper
{
    public class Find<Model> where Model : new()
    {
        public string find;

        public string filter;

        public string field;

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
                content += "<tr bgcolor="+cor+"  onclick=\"location.href='{$link}'\" onMouseOver=\"this.style.background = '#CCC'\" onMouseOut=\"this.style.background = '"+cor+"'\">\n";

                // percorre todas as colunas
                foreach (KeyValuePair<string, Dictionary<string, object>> itemField in fields)
                {
                    // cria o cabeçalho (LOOP UNICO)
                    if (contador == 0)
                    {
                        heder += "<th>\n";
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
            xhtml += "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tblPesquisa\" width=\"97%\">\n";
            xhtml += "<thead>\n";
            xhtml += heder;
            xhtml += "</thead>\n";
            xhtml += "<tbody class=\"trLink\">\n";
            xhtml += "</tbody>\n";
            xhtml += content;
            xhtml += "</table>\n";

            return xhtml;
        }

        /// <summary>
        /// 
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

                switch (itemFilter.Value["tipo_campo"].ToString().ToUpper())
                {
                    //case "TEXT":
                    default: 
                        xhtml += "<td style=\"width:25%\">\n";
                        if (itemFilter.Value["tipo_dado"] == "string") {
                            xhtml += XForm<Model>.Selectbox("operadorLogico[" + itemFilter.Key + "]", logicOperatorsGroup["string"], null, null);
                        } else if (itemFilter.Value["tipo_dado"] == "numerico") {
                            xhtml += XForm<Model>.Selectbox("operadorLogico[" + itemFilter.Key + "]", logicOperatorsGroup["string"], null, null);
                        }
                        xhtml += "</td>\n";
 
                        // campo que receberá o filtro
                        xhtml += "<td style=\"width:30%\">";
                        xhtml += XForm<Model>.Texbox("campo[" + itemFilter.Key + "]", null, new string[] { "style=\"width:95%\"" });
                        xhtml += "</td>\n"; 

                        // campo para verificar se o campo é Insensitive ou Sensitive Case
                        if (itemFilter.Value["tipo_dado"] != "numerico") {
                            xhtml += "<td style=\"width:20%\">";
                            xhtml += XForm<Model>.Checkbox("ignoraCAb[" + itemFilter.Key + "]", false, new string[] { "class=\"radio\"" }) + "Ignorar CAb";
                            xhtml += "</td>\n";
                        } else {
                            xhtml += "<td style=\"width:20%\">\n";
                            xhtml += "</td>\n";
                        } 
                    break;
                }

                // fecha a linha da tabela
                xhtml += "</tr>\n";
            }
 
            xhtml += "</tbody>\n";
            xhtml += "</table>\n"; 
            // Tabela para submeter o formulário
            xhtml += "<table  cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
            xhtml += "<tbody>\n"; 
            // inicio da linha
            xhtml += "<tr>\n";
            // Label do campo
            xhtml += "<td width='160px'>\n";
            xhtml += "Nº de registros por página:\n";
            xhtml += "</td>\n";

            xhtml += "<td width='70px'>\n";
            xhtml += XForm<Model>.Texbox("numRegistrosPagina", null, new string[] { "class=\"dataTxtArea\"" });
            xhtml += "</td>\n";

            xhtml += "<td>\n";
            //xhtml += $this->view->formSubmit('operacao', 'Pesquisar', array('id' => 'operacao', 'class' => 'btn'));
            xhtml += "</td>\n"; 
            // fim da linha
            xhtml += "</tr>\n";
            xhtml += "</tbody>\n";
            xhtml += "</table>\n";

            return xhtml;
        }

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

            Dictionary<string, Dictionary<string, string>> logicOperatorsGroup = new Dictionary<string, Dictionary<string, string>>();
            logicOperatorsGroup.Add("string", stringD);
            logicOperatorsGroup.Add("option", optionD);
            logicOperatorsGroup.Add("numerico", numericoD);

            return logicOperatorsGroup;
        }

    }
}
