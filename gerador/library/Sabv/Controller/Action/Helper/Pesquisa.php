<?php

require_once 'Zend/Controller/Action/Helper/Abstract.php';


class Sabv_Controller_Action_Helper_Pesquisa extends Zend_Controller_Action_Helper_Abstract{

     protected $modelos;


     protected $filtros;


     protected $campos;


     protected $linkRegistros;


     protected $filtroPadrao;


     protected $orderPadrao;


     protected $groupBy;


     protected $having;


     public function Pesquisa($modelos, $filtros, $campos, $linkRegistros, $filtroPadrao = null, $mostraFiltro = false, $orderPadrao = array(), $groupBy = null, $having = null)
    {
         $this -> modelos = $modelos; //modelos
         $this -> filtros = $filtros; //filtros
         $this -> campos = $campos; //campos
         $this -> linkRegistros = $linkRegistros; //linkRegistros
         $this -> filtroPadrao = $filtroPadrao; //filtroPadrao
         $this -> orderPadrao = $orderPadrao; //orderPadrao
         $this -> groupBy = $groupBy; //group by
         $this -> having = $having; //having


         $this -> _actionController -> view -> controller = $this -> _actionController -> getRequest() -> getControllerName();
         $this -> _actionController -> view -> action = $this -> _actionController -> getRequest() -> getActionName();
         if($mostraFiltro == false){
             $this -> _actionController -> view -> mostraFiltro = 'none';
             }else{
             $this -> _actionController -> view -> mostraFiltro = 'block';
             }

         $this -> realizaConsulta();
         $link = $this -> ajustaLinkRegistro();
         $this -> _actionController -> view -> Pesquisa($this -> filtros, $this -> campos, $link);
         }


     protected function realizaConsulta()
    {
         $modelos = $this -> modelos;
         $tipoJoin = array('join' => 'join',
             'left' => 'joinLeft',
             'right' => 'joinRight',
             'full' => 'joinFull',
             'cross' => 'joinCross',
             'natural' => 'joinNatural'
            );
         $db = Zend_Registry :: get('db');
         $select = $db -> select();
         if(is_string($modelos['from'])){
             $select -> from($modelos['from'], '*');
             }else if(is_array($modelos['from'])){
             list($tabela, $campos) = each($modelos['from']);
             $select -> from($tabela, $campos);
             }
         if(isset($modelos['join'])){
             foreach($modelos['join'] as $tabela => $atributos){
                 if(!isset($atributos['campo'])){
                     $select -> $tipoJoin[$atributos['tipo']]($tabela, $atributos['relacionamento'], '*');
                     }else{
                     $select -> $tipoJoin[$atributos['tipo']]($tabela, $atributos['relacionamento'], $atributos['campo']);
                     }

                 }
             }
         if (isset($modelos['distinct']) && $modelos['distinct']){
             $select -> distinct();
             }
         $ns = Zend_Registry :: get('ns');
         $controller = $this -> _actionController -> getRequest() -> getControllerName();
         $numRegistrosPagina = is_null($this -> _actionController -> getRequest() -> getParam('numRegistrosPagina')) ? 20 : $this -> _actionController -> getRequest() -> getParam('numRegistrosPagina');

         $page = $this -> _actionController -> getRequest() -> getParam('page');

         $orderBy = $this -> _actionController -> getRequest() -> getParam('order_by');


         if (!$page && empty($orderBy)){
             $ns -> pesquisa[$controller]['campos'] = $campos = $this -> _actionController -> getRequest() -> getParam('campo');
             $ns -> pesquisa[$controller]['operadorLogico'] = $operadorLogico = $this -> _actionController -> getRequest() -> getParam('operadorLogico');
             $ns -> pesquisa[$controller]['operadorBooleano'] = $operadorBooleano = $this -> _actionController -> getRequest() -> getParam('operadorBooleano');
             $ns -> pesquisa[$controller]['ignoraCAb'] = $ignoraCAb = $this -> _actionController -> getRequest() -> getParam('ignoraCAb');
             $ns -> pesquisa[$controller]['numRegistrosPagina'] = $numRegistrosPagina;
             $page = 1;
             }else{
             $campos = $ns -> pesquisa[$controller]['campos'];
             $operadorLogico = $ns -> pesquisa[$controller]['operadorLogico'];
             $operadorBooleano = $ns -> pesquisa[$controller]['operadorBooleano'];
             $ignoraCAb = $ns -> pesquisa[$controller]['ignoraCAb'];
             $numRegistrosPagina = empty($ns -> pesquisa[$controller]['numRegistrosPagina'])?$numRegistrosPagina:$ns -> pesquisa[$controller]['numRegistrosPagina'];
             $page = empty($page)?1:$page;
             }
         if($orderBy){
             $ns -> pesquisa[$controller]['order'] = $orderBy;
             }else if(isset($ns -> pesquisa[$controller]['order'])){
             $orderBy = $ns -> pesquisa[$controller]['order'];
             }
         if($orderBy == null){
             $orderBy = $this -> orderPadrao;
             }else{
             $orderBy = array($orderBy);
             }
         $select -> order($orderBy);

         if(!is_null($this -> groupBy)){
             $select -> group($this -> groupBy);
             if(!is_null($this -> having)){
                 $select -> having($this -> having);
                 }
             }

         if (!empty($campos)){

             foreach($campos as $nome_campo => $value_campo){
                 if (!empty($value_campo) || $value_campo == '0' || $value_campo === 0){
                     $nome_campo_aux = $nome_campo;

                     $operadorBooleano[$nome_campo] = !empty($operadorBooleano[$nome_campo])?$operadorBooleano[$nome_campo]:'where';
                     switch ($operadorLogico[$nome_campo_aux]){
                     case 'OPL_IGUAL':
                         if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S'){
                             $select -> where("upper({$nome_campo}) = upper('{$value_campo}')");
                             }else{
                             $select -> where("{$nome_campo} = '{$value_campo}'");
                             }
                         break;
                     case 'OPL_DIFERENTE':
                         if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S'){
                             $select -> where("upper({$nome_campo}) != upper('{$value_campo}')");
                             }else{
                             $select -> where("{$nome_campo} != '{$value_campo}'");
                             }
                         break;
                     case 'OPL_MAIOR':
                         $select -> where("{$nome_campo} > '{$value_campo}'");
                         break;
                     case 'OPL_MENOR':
                         $select -> where("{$nome_campo} < '{$value_campo}'");
                         break;
                     case 'OPL_MAIOR_IGUAL':
                         $select -> where("{$nome_campo} >= '{$value_campo}'");
                         break;
                     case 'OPL_MENOR_IGUAL':
                         $select -> where("{$nome_campo} <= '{$value_campo}'");
                         break;
                     case 'OPL_ENTRE':
                         $value_campo = split("[ ;-]", $value_campo);
                         $select -> where("{$nome_campo} >= {$value_campo[0]} AND {$nome_campo} <= {$value_campo[1]}");
                         break;
                     case 'OPL_VAZIO':
                         $select -> where("{$nome_campo} is null");
                         break;
                     case 'OPL_NAO_VAZIO':
                         $select -> where("{$nome_campo} is not null");
                         break;
                     case 'OPL_VALOR_LISTA':
                         $select -> where("{$nome_campo} in ({$value_campo})");
                         break;
                     case 'OPL_COMECANDO':
                         if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S'){
                             $select -> where("upper({$nome_campo}) like upper('{$value_campo}%')");
                             }else{
                             $select -> where("{$nome_campo} like '{$value_campo}%'");
                             }
                         break;
                     case 'OPL_TERMINANDO':
                         if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S'){
                             $select -> where("upper({$nome_campo}) like upper('%{$value_campo}')");
                             }else{
                             $select -> where("{$nome_campo} like '%{$value_campo}'");
                             }
                         break;
                     case 'OPL_QUALQUER_LUGAR':
                         if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S'){
                             $select -> where("upper({$nome_campo}) like upper('%{$value_campo}%')");
                             }else{
                             $select -> where("{$nome_campo} like '%{$value_campo}%'");
                             }
                         break;
                     default: ;
                         } // switch
                     }
                 }
             $arrayCampos = array('campos' => $campos);
             $this -> _actionController -> view -> assign($arrayCampos);

             $arrayOperadorLogico = array('operadorLogico' => $operadorLogico);
             $this -> _actionController -> view -> assign($arrayOperadorLogico);

             $arrayOperadorBooleano = array('operadorBooleano' => $operadorBooleano);
             $this -> _actionController -> view -> assign($arrayOperadorBooleano);

             $arrayIgnoraCAb = array('ignoraCAb' => $ignoraCAb);
             $this -> _actionController -> view -> assign($arrayIgnoraCAb);
             }
         if(!empty($this -> filtroPadrao)){
             foreach($this -> filtroPadrao as $key => $value){
                 $select -> where($value);
                 }
             }




         $this -> _actionController -> view -> numRegistrosPagina = $numRegistrosPagina;

         $sql = "SELECT COUNT(*) as " . $modelos['from'] . " ";
         try{
             $numTotalRegistros = $db -> fetchRow($sql);
             }
         catch (Exception $e){
             die($select -> __toString());
             break;
             }


         @$numPaginas = $numTotalRegistros -> TOTAL / $numRegistrosPagina;
         $numPaginas = ceil(($numPaginas < 1)?1:$numPaginas);
         $this -> _actionController -> view -> page = $page;
         $this -> _actionController -> view -> numPaginas = $numPaginas;
         @$this -> _actionController -> view -> numTotalRegistros = $numTotalRegistros -> TOTAL;
         $select -> limitPage($page, $numRegistrosPagina);
         $objeto = $db -> fetchAll($select);
         $this -> _actionController -> view -> lista = $objeto;
         }


     protected function ajustaLinkRegistro()
    {
         $linkRegistros = $this -> linkRegistros;

         @list($key, $value) = each($linkRegistros['params']);
         switch ($key){
         case 'chave':

             $value = ucfirst($value);
             Zend_Loader :: loadClass($value);
             $model = new $value;
             $params = $model -> info('primary');
             break;
         case 'todos':

             break;
         case 'informado':
             $params = split('[|.,-]', $value);
             break;
         default:
             Zend_Loader :: loadClass($value);
             $model = new $value;
             $params = $model -> info('primary');
             } // switch$linkRegistros
         @$linkRegistros['params'] = $params;
         return $linkRegistros;
         }


     public function direct($name, $options = null)
    {
         $this -> controller = $this -> getActionController();
         $this -> action = $this -> getRequest();

         return $this;
         }
    }
