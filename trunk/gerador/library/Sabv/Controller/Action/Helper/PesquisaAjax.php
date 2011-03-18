<?php

require_once 'Zend/Controller/Action/Helper/Abstract.php';


class Sabv_Controller_Action_Helper_PesquisaAjax extends Zend_Controller_Action_Helper_Abstract{

     protected $modelos;


     protected $filtros;


     protected $campos;


     protected $linkRegistros;


     protected $filtroPadrao;


     protected $orderPadrao;


     protected $groupBy;


     protected $having;


     protected $sql;


     public function getSQL(){
         return $this -> sql;
         }

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
         $this -> _actionController -> view -> PesquisaAjax($this -> filtros, $this -> campos, $this -> linkRegistros);
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
         $action = $this -> _actionController -> getRequest() -> getActionName();
         $numRegistrosPagina = is_null($this -> _actionController -> getRequest() -> getParam('numRegistrosPagina')) ? 5 : $this -> _actionController -> getRequest() -> getParam('numRegistrosPagina');

         $page = $this -> _actionController -> getRequest() -> getParam('page');

         $orderBy = $this -> _actionController -> getRequest() -> getParam('order_by');


         if (!$page && empty($orderBy)){
             $parametros = $this -> _actionController -> getRequest() -> getParam('campo');
             $campos = array();
             if(isset($parametros)){
                 foreach($parametros as $keyCampo => $valorCampo){
                     $campos[$keyCampo] = utf8_decode($valorCampo);
                     }
                 }

             $ns -> pesquisa[$controller][$action]['campos'] = $campos;
             $ns -> pesquisa[$controller][$action]['operadorLogico'] = $operadorLogico = $this -> _actionController -> getRequest() -> getParam('operadorLogico');
             $ns -> pesquisa[$controller][$action]['operadorBooleano'] = $operadorBooleano = $this -> _actionController -> getRequest() -> getParam('operadorBooleano');
             $ns -> pesquisa[$controller][$action]['ignoraCAb'] = $ignoraCAb = $this -> _actionController -> getRequest() -> getParam('ignoraCAb');
             $ns -> pesquisa[$controller][$action]['numRegistrosPagina'] = $numRegistrosPagina;
             $page = 1;
             }else{
             $campos = $ns -> pesquisa[$controller][$action]['campos'];
             $operadorLogico = $ns -> pesquisa[$controller][$action]['operadorLogico'];
             $operadorBooleano = $ns -> pesquisa[$controller][$action]['operadorBooleano'];
             $ignoraCAb = $ns -> pesquisa[$controller][$action]['ignoraCAb'];
             $numRegistrosPagina = empty($ns -> pesquisa[$controller][$action]['numRegistrosPagina'])?$numRegistrosPagina:$ns -> pesquisa[$controller][$action]['numRegistrosPagina'];
             $page = empty($page)?1:$page;
             }
         if($orderBy){
             $ns -> pesquisa[$controller][$action]['order'] = $orderBy;
             }else if(isset($ns -> pesquisa[$controller][$action]['order'])){
             $orderBy = $ns -> pesquisa[$controller][$action]['order'];
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

         $this -> sql = $select -> __toString();


         $sql = "SELECT COUNT(*) from " . $modelos['from'] . " ";


         try{
             $numTotalRegistros = $db -> fetchRow($sql);
             }
         catch (Exception $e){
             $log = Zend_Registry :: get('log');
             $log -> crit("Consulta - {$this->sql} - " . $e -> getMessage());

             $html = "<span class=\"msg\">";
             $html .= "<div id=\"message\"><ul><li>» Ocorreu um erro ao processar sua consulta, foi gerado um log do erro.</li></ul></div>";
             $html .= "</span>";
             die($html);
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


     public function direct($name, $options = null)
    {
         $this -> controller = $this -> getActionController();
         $this -> action = $this -> getRequest();

         return $this;
         }
    }
