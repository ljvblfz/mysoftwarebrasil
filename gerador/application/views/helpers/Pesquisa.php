<?php

class Zend_View_Helper_Pesquisa{

     public $filtro;


     public $campos;


     public $view;


     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function Pesquisa($filtrosPesquisa, $camposPesquisa, $linkRegistros)
    {
         $this -> filtroPesquisa($filtrosPesquisa);
         $this -> campoPesquisa($camposPesquisa, $linkRegistros);
         return;
         }


     public function filtroPesquisa($filtroPesquisa)
    {

         $_operadoresLogico = array('OPL_IGUAL' => 'igual a',
             'OPL_DIFERENTE' => 'diferente de',
             'OPL_MAIOR' => 'maior que',
             'OPL_MENOR' => 'menor que',
             'OPL_MAIOR_IGUAL' => 'maior ou igual a',
             'OPL_MENOR_IGUAL' => 'menor ou igual a',
             'OPL_ENTRE' => 'com valores entre',
             'OPL_VAZIO' => 'está vazio',
             'OPL_NAO_VAZIO' => 'não está vazio',
             'OPL_VALOR_LISTA' => 'valores da lista',
             'OPL_COMECANDO' => 'começando com',
             'OPL_TERMINANDO' => 'terminando com',
             'OPL_QUALQUER_LUGAR' => 'em qualquer lugar'
            );
         $_grupoOperadoresLogico = array('string' => array('OPL_IGUAL' => 'igual a',
                 'OPL_DIFERENTE' => 'diferente de',
                 'OPL_VAZIO' => 'está vazio',
                 'OPL_NAO_VAZIO' => 'não está vazio',
                 'OPL_COMECANDO' => 'começando com',
                 'OPL_TERMINANDO' => 'terminando com',
                 'OPL_QUALQUER_LUGAR' => 'em qualquer lugar'
                ),
             'numerico' => array('OPL_IGUAL' => 'igual a',
                 'OPL_DIFERENTE' => 'diferente de',
                 'OPL_MAIOR' => 'maior que',
                 'OPL_MENOR' => 'menor que',
                 'OPL_MAIOR_IGUAL' => 'maior ou igual a',
                 'OPL_MENOR_IGUAL' => 'menor ou igual a',
                 'OPL_ENTRE' => 'com valores entre',
                 'OPL_VAZIO' => 'está vazio',
                 'OPL_NAO_VAZIO' => 'não está vazio',
                 'OPL_VALOR_LISTA' => 'valores da lista'
                ),
             'options' => array('OPL_IGUAL' => 'igual a',
                 'OPL_DIFERENTE' => 'diferente de',
                 'OPL_VAZIO' => 'está vazio',
                 'OPL_NAO_VAZIO' => 'não está vazio'
                )
            );
         $content = "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
         $content .= "<tbody>\n";
         $contador = 0;
         foreach($filtroPesquisa as $nome_do_campo => & $atributos_do_campo){
             $cor = $contador % 2 == 0?'#FFFFFF':'#F4F4F4';
             $contador++;
             $content .= "<tr bgcolor={$cor}>\n";
             $content .= "<td style=\"width:25%\">\n";
             $content .= $this -> view -> formLabel($nome_do_campo, $atributos_do_campo['descricao']);
             $content .= "</td>\n";
             switch (strtoupper($atributos_do_campo['tipo_campo'])){
             case 'TEXT':
                 $content .= "<td style=\"width:25%\">\n";

                 if ($atributos_do_campo['tipo_dado'] == 'string'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['string']);
                     }else if ($atributos_do_campo['tipo_dado'] == 'numerico'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['numerico']);
                     }
                 $content .= "</td>\n";
                 $content .= "<td style=\"width:30%\">";
                 $content .= $this -> view -> formText('campo[' . $nome_do_campo . ']', $this -> view -> campos[$nome_do_campo], array('id' => $nome_do_campo, 'style' => 'width:95%'));
                 $content .= "</td>\n";
                 if ($atributos_do_campo['tipo_dado'] != 'numerico'){
                     $content .= "<td style=\"width:20%\">";
                     $content .= $this -> view -> formCheckbox('ignoraCAb[' . $nome_do_campo . ']', $this -> view -> ignoraCAb[$nome_do_campo], array('class' => 'radio'), array('S', 'N')) . 'Ignorar CAb';
                     $content .= "</td>\n";
                     }else{
                     $content .= "<td style=\"width:20%\">\n";
                     $content .= "</td>\n";
                     }
                 break;
             case 'RADIO':
                 $content .= "<td style=\"width:25%\">\n";
                 if ($atributos_do_campo['tipo_dado'] == 'options'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['options']);
                     }
                 $content .= "</td>\n";
                 $content .= "<td colspan=2 style=\"width:50%\">\n";
                 if ($atributos_do_campo['tipo_dado'] == 'options'){
                     $content .= $this -> view -> formRadio('campo[' . $nome_do_campo . ']', $this -> view -> campos[$nome_do_campo], array('class' => 'radio', 'id' => $nome_do_campo), $atributos_do_campo['opcoes']);
                     }
                 $content .= "</td>\n";
                 break;
             case 'CHECKBOX':
                 break;
             case 'DATE':
                 $content .= "<td style=\"width:25%\">\n";
                 if ($atributos_do_campo['tipo_dado'] == 'string'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['string']);
                     }
                 $content .= "</td>\n";
                 $content .= "<td colspan='2' style=\"width:50%\">\n";
                 $content .= $this -> view -> formText('campo[' . $nome_do_campo . ']', $this -> view -> campos[$nome_do_campo], array('class' => 'dataTxtArea', 'id' => $nome_do_campo));
                 $content .= "<img id='escolhe_{$nome_do_campo}' title='Selecione a data' src='{$this->view->baseUrl}/public/images/calendar.png' alt='Calendário' class='imgTb'/>";
                 $content .= "<script type=\"text/javascript\">";
                 $content .= "Calendar.setup({\"inputField\":\"{$nome_do_campo}\",\"button\":\"escolhe_{$nome_do_campo}\",\"singleClick\":true});";
                 $content .= "</script>";
                 $content .= "</td>\n";
                 break;
             case 'SELECT':
                 $content .= "<td style=\"width:25%\">\n";
                 if ($atributos_do_campo['tipo_dado'] == 'options'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['options']);
                     }
                 $content .= "</td>\n";
                 $content .= "<td colspan=2 style=\"width:50%\">\n";
                 if ($atributos_do_campo['tipo_dado'] == 'options'){
                     if (!isset($atributos_do_campo['escolhaObrigatorio']) || $atributos_do_campo['escolhaObrigatorio'] != true){
                         $atributos_do_campo['opcoes'] = array('' => 'Selecione') + $atributos_do_campo['opcoes'];
                         }
                     $content .= $this -> view -> formSelect('campo[' . $nome_do_campo . ']', $this -> view -> campos[$nome_do_campo], array('id' => $nome_do_campo, 'style' => 'width:95%'), $atributos_do_campo['opcoes']);
                     }
                 $content .= "</td>\n";
                 break;
             default:
                 $content .= "<td style=\"width:25%\">\n";

                 if ($atributos_do_campo['tipo_dado'] == 'string'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['string']);
                     }else if ($atributos_do_campo['tipo_dado'] == 'numerico'){
                     $content .= $this -> view -> formSelect('operadorLogico[' . $nome_do_campo . ']', $this -> view -> operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['numerico']);
                     }
                 $content .= "</td>\n";
                 $content .= "<td style=\"width:30%\">";
                 $content .= $this -> view -> formText('campo[' . $nome_do_campo . ']', $this -> view -> campos[$nome_do_campo], array('id' => $nome_do_campo));
                 $content .= "</td>\n";
                 if ($atributos_do_campo['tipo_dado'] != 'numerico'){
                     $content .= "<td style=\"width:20%\">";
                     $content .= $this -> view -> formCheckbox('ignoraCAb[' . $nome_do_campo . ']', null, array('class' => 'radio')) . 'Ignorar CAb';
                     $content .= "</td>\n";
                     }else{
                     $content .= "<td style=\"width:20%\">\n";
                     $content .= "</td>\n";
                     }
                 break;
                 }

             $content .= "</tr>\n";
             }
         $content .= "</tbody>\n";
         $content .= "</table>\n";
         $content .= "<table  cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
         $content .= "<tbody>\n";
         $content .= "<tr>\n";
         $content .= "<td width='160px'>\n";
         $content .= "Nº de registros por página:\n";
         $content .= "</td>\n";

         $content .= "<td width='70px'>\n";
         $content .= $this -> view -> formText('numRegistrosPagina', $this -> view -> numRegistrosPagina, array('id' => 'numRegistrosPagina', 'class' => 'dataTxtArea'));
         $content .= "</td>\n";

         $content .= "<td>\n";
         $content .= $this -> view -> formSubmit('operacao', 'Pesquisar', array('id' => 'operacao', 'class' => 'btn'));
         $content .= "</td>\n";
         $content .= "</tr>\n";
         $content .= "</tbody>\n";
         $content .= "</table>\n";

         $html = $this -> view -> form('teste', array('method' => 'post', 'action' => $this -> view -> baseUrl . '/' . $this -> view -> controller . '/' . $this -> view -> action), $content);
         $this -> filtro = $html;
         }


     public function campoPesquisa($camposPesquisa, $linkRegistros){

         $page = $this -> view -> page;
         $numPaginas = $this -> view -> numPaginas;
         $numTotalRegistros = $this -> view -> numTotalRegistros;


         $pagination = "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
         $pagination .= "<tbody>\n";
         $pagination .= "<tr>\n";
         $pagination .= "<td height=\"24\">\n";

         $pagination .= "<strong> N&deg; total de registros: </strong>" . $numTotalRegistros;
         $pagination .= "</td>\n";
         $pagination .= "<td>\n";
         $pagination .= "<div class='pagination'>";

         $pagination .= "<span class='pagImg'>";
         $pagination .= "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/1'>";
         $pagination .= "<img border=\"0\" alt=\"Primeira p&aacute;gina\" title=\"Primeira p&aacute;gina\" src=\"{$this->view->baseUrl}/public/images/pag_primeira.gif\">\n";
         $pagination .= "</a>\n";
         $pagination .= "</span>\n";

         $anterior = $page == 1?1:$page-1;
         $pagination .= "<span class='pagImg'>";
         $pagination .= "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/{$anterior}'>";
         $pagination .= "<img border=\"0\" alt=\"P&aacute;gina anterior\" title=\"P&aacute;gina anterior\" src=\"{$this->view->baseUrl}/public/images/pag_anterior.gif\">\n";
         $pagination .= "</a>\n";
         $pagination .= "</span>\n";

         $numeroPaginações = 5;
         $meio = floor($numeroPaginações / 2);

         if($page - $meio < 1){
             $inicio = 1;
             $restanteInicio = ($inicio - ($page - $meio));
             }else{
             $inicio = $page - $meio;
             $restanteInicio = 0;
             }

         if($page + $meio > $numPaginas){
             $fim = $numPaginas;
             $restanteFim = ($numPaginas - ($page + $meio));
             }else{
             $fim = $page + $meio;
             $restanteFim = 0;
             }

         if($numPaginas > $numeroPaginações){
             if($restanteInicio){
                 $fim += $restanteInicio;
                 }

             if ($restanteFim){
                 $inicio += $restanteFim;
                 }
             }


         $link = $inicio;
         while($link >= $inicio && $link <= $fim){
             $pagination .= "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/{$link}'>";
             $pagination .= $link == $page ? "<span class=\"pagActive\">{$link}</span>" : "<span class=\"pagLink\">{$link}</span>";
             $pagination .= "</a></> ";
             $link++;
             }


         $posterior = $page == $numPaginas?$numPaginas:$page + 1;
         $pagination .= "<span class='pagImg'>";
         $pagination .= "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/{$posterior}'>";
         $pagination .= "<img border=\"0\" alt=\"Pr&oacute;xima p&aacute;gina\" title=\"Pr&oacute;xima p&aacute;gina\" src=\"{$this->view->baseUrl}/public/images/pag_proxima.gif\">\n";
         $pagination .= "</a>\n";
         $pagination .= "</span>\n";
         $pagination .= "<span class='pagImg'>";
         $pagination .= "<a href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/page/{$numPaginas}'>";
         $pagination .= "<img border=\"0\" alt=\"&Uacute;ltima p&aacute;gina\" title=\"&Uacute;ltima p&aacute;gina\" src=\"{$this->view->baseUrl}/public/images/pag_ultima.gif\">\n";
         $pagination .= "</a>\n";
         $pagination .= "</span>\n";
         $pagination .= "</div>\n";
         $pagination .= "</td>\n";
         $pagination .= "</tr>\n";
         $pagination .= "</tbody>\n";
         $pagination .= "</table>\n";

         $content = $pagination;


         $content .= "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tblPesquisa\" width=\"97%\">\n";
         $content .= "<thead>\n";

         $content .= "<tr>\n";

         foreach($camposPesquisa as $cabecalho => $corpo){
             $content .= "<th>\n";
             $content .= $cabecalho;
             $content .= "</th>\n";
             $content .= "<th width=\"8\">\n";
             $content .= "<img onclick=\"location.href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/order_by/{$corpo[0]} asc'\" src=\"{$this->view->baseUrl}/public/images/up.gif\" alt='Ordem crescente' title='Ordem crescente'>";
             $content .= "<img onclick=\"location.href='{$this->view->baseUrl}/{$this->view->controller}/{$this->view->action}/order_by/{$corpo[0]} desc'\" src=\"{$this->view->baseUrl}/public/images/dw.gif\" alt=\"Ordem decrescente\" title=\"Ordem decrescente\">";
             $content .= "</th>\n";
             }
         $content .= "</tr>\n";
         $content .= "</thead>\n";

         $content .= "<tbody class=\"trLink\">\n";
         $contador = 0;
         foreach(@$this -> view -> lista as $lista){
             $cor = $contador % 2 == 0?'#FFFFFF':'#F4F4F4';
             $contador++;


             $link = $this -> view -> baseUrl . '/' . $linkRegistros['controle'] . '/' . $linkRegistros['action'];

             foreach($linkRegistros['params'] as $key => $value){
                 $link .= "/" . $value . "/" . $lista -> $value;
                 }

             $content .= "<tr bgcolor={$cor}  onclick=\"location.href='{$link}'\" onMouseOver=\"this.style.background = '#CCC'\" onMouseOut=\"this.style.background = '{$cor}'\">\n";
             foreach($camposPesquisa as $cabecalho => $corpo){
                 if(isset($corpo[1]) && strtolower($corpo[1]) == 'monetario'){
                     $align = 'right';
                     $content .= "<td style='text-align:{$align}' colspan='2'>\n";
                     $content .= $this -> view -> escapeFloat($lista -> $corpo[0]);
                     $content .= "</td>\n";
                     }else{
                     $align = empty($corpo[1])?'left':$corpo[1];
                     $content .= "<td style='text-align:{$align}' colspan='2'>\n";
                     $content .= $this -> view -> escape($lista -> $corpo[0]);
                     $content .= "</td>\n";
                     }

                 }
             $content .= "</tr>\n";

             }
         $content .= "</tbody>\n";
         $content .= "</table>\n";
         $content .= $pagination;
         $this -> tabela = $content;
         }
    }
